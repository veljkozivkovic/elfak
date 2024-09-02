#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "mpi.h"

#define n 8

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
    int A[n][n], b[n], c[n];
    int q = (int)sqrt(size);
    int k = n / q;

    MPI_Comm ROW_COMM, COL_COMM;
    MPI_Comm_split(MPI_COMM_WORLD, rank / q, 0, &ROW_COMM);
    MPI_Comm_split(MPI_COMM_WORLD, rank % q, 0, &COL_COMM);

    MPI_Datatype MAT_TYPE;
    MPI_Type_vector(k * k, 1, q, MPI_INT, &MAT_TYPE);
    MPI_Type_commit(&MAT_TYPE);

    MPI_Datatype B_TYPE, RESIZED_B_TYPE;
    MPI_Type_vector(k, 1, q, MPI_INT, &B_TYPE);
    MPI_Type_create_resized(B_TYPE, 0, sizeof(int), &RESIZED_B_TYPE);
    MPI_Type_commit(&RESIZED_B_TYPE);

    int my_block[k][k], my_b[k];

    if (rank == 0) {
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                A[i][j] = i * n + j;
            }
            b[i] = 1;
        }
        for (int i = 0; i < k; ++i) {
            for (int j = 0; j < k; ++j) {
                my_block[i][j] = A[i][j * q];
            }
        }
        int c = 0;
        for (int i = 0; i < size / 2; i += 2) {
            for (int j = 0; j < q; ++j) {
                if (i == 0 && j == 0) continue;
                MPI_Send(&A[i][j], 1, MAT_TYPE, ++c, 88, MPI_COMM_WORLD);
            }
        }
    }
    else {
        MPI_Recv(my_block, k * k, MPI_INT, 0, 88, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
    }
    
    MPI_Scatter(b, 1, RESIZED_B_TYPE, my_b, k, MPI_INT, 0, ROW_COMM);
    MPI_Bcast(my_b, k, MPI_INT, 0, COL_COMM);

    int my_res[k];

    for (int i = 0; i < k; ++i) {
        my_res[i] = 0;
        for (int j = 0; j < k; ++j) {
            my_res[i] += my_block[i][j] * my_b[j];
        }
    }

    int my_res_reduced[k];
    MPI_Reduce(my_res, my_res_reduced, k, MPI_INT, MPI_SUM, 0, ROW_COMM);
    MPI_Gather(my_res_reduced, k, MPI_INT, c, k, MPI_INT, 0, COL_COMM);


    if (rank == 0) {
        printMatrix((int*)c, 1, n);
    }


    MPI_Type_free(&MAT_TYPE);
    MPI_Type_free(&B_TYPE);
    MPI_Type_free(&RESIZED_B_TYPE);
    MPI_Finalize();
    return 0;
}