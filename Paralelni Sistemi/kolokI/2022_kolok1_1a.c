#include <stdio.h>
#include <stdlib.h>
#include "mpi.h"

#define k 4
#define n 6
#define m 4

void printMatrix(int* matrix, int rows, int cols) {
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            printf("%d ", matrix[i * cols + j]);
        }
        printf("\n");
    }
}

int main(int argc, char* argv[]) {
    MPI_Init(&argc, &argv);
    int rank, size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    int A[k][n], B[n][m], C[k][m];

    if (k % size != 0) {
        MPI_Finalize();
        exit(-1);
    }

    MPI_Datatype ROW_TYPE, RESIZED_ROW_TYPE;
    MPI_Type_vector(k / size, n, size * n, MPI_INT, &ROW_TYPE);
    MPI_Type_create_resized(ROW_TYPE, 0, n * sizeof(int), &RESIZED_ROW_TYPE);
    MPI_Type_commit(&RESIZED_ROW_TYPE);

    MPI_Datatype RECV_TYPE, RESIZED_RECV_TYPE;
    MPI_Type_vector(k / size, m, size * m, MPI_INT, &RECV_TYPE);
    MPI_Type_create_resized(RECV_TYPE, 0, m * sizeof(int), &RESIZED_RECV_TYPE);
    MPI_Type_commit(&RESIZED_RECV_TYPE);


    int my_rows[k / size][n];

    if (rank == 0) {
        for (int i = 0; i < k; ++i) {
            for (int j = 0; j < n; ++j) {
                A[i][j] = i * n + j;
            }
        }
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                B[i][j] = i * m + j;
            }
        }
    }
    
    MPI_Bcast(B, n * m, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Scatter(A, 1, RESIZED_ROW_TYPE, my_rows, k * n / size, MPI_INT, 0, MPI_COMM_WORLD);
    
    int my_res[k / size][m];
    for (int i = 0; i < k / size; ++i) {
        for (int j = 0; j < m; ++j) {
            my_res[i][j] = 0;
            for (int z = 0; z < n; ++z) {
                my_res[i][j] += my_rows[i][z] * B[z][j];
            }
        }
    }

    MPI_Gather(my_res, k * m / size, MPI_INT, C, 1, RESIZED_RECV_TYPE, 0, MPI_COMM_WORLD);

    if (rank == 0) {
        printMatrix((int*)C, k, m);
    }

    MPI_Type_free(&RESIZED_ROW_TYPE);
    MPI_Type_free(&ROW_TYPE);
    MPI_Type_free(&RESIZED_RECV_TYPE);
    MPI_Type_free(&RECV_TYPE);
    MPI_Finalize();
    return 0;
}