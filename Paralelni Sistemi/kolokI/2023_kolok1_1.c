#include <stdio.h>
#include <stdlib.h>
#include "mpi.h"

#define k 4
#define m 6
#define l 4

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
    int A[k][m], B[m][l], C[k][l];

    MPI_Datatype COL_TYPE, RESIZED_COL_TYPE;
    MPI_Type_vector(k * m / size, 1, size, MPI_INT, &COL_TYPE);
    MPI_Type_create_resized(COL_TYPE, 0, sizeof(int), &RESIZED_COL_TYPE);
    MPI_Type_commit(&RESIZED_COL_TYPE);

    MPI_Datatype ROW_TYPE, RESIZED_ROW_TYPE;
    MPI_Type_vector(m / size, l, size * l, MPI_INT, &ROW_TYPE);
    MPI_Type_create_resized(ROW_TYPE, 0, l * sizeof(int), &RESIZED_ROW_TYPE);
    MPI_Type_commit(&RESIZED_ROW_TYPE);

    int A_cols[k][m / size], B_rows[m / size][l], C_local[k][l];

    if (rank == 0) {
        for (int i = 0; i < k; ++i) {
            for (int j = 0; j < m; ++j) {
                A[i][j] = i * m + j;
            }
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < l; ++j) {
                B[i][j] = i * l + j;
            }
        }
    }
    MPI_Scatter(A, 1, RESIZED_COL_TYPE, A_cols, k * m / size, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Scatter(B, 1, RESIZED_ROW_TYPE, B_rows, m / size * l, MPI_INT, 0, MPI_COMM_WORLD);

    struct { int min; int rank; } my_min = { INT32_MAX, rank }, total_min; 

    for (int i = 0; i < k; ++i) {
        for (int j = 0; j < l; ++j) {
            C_local[i][j] = 0;
            for (int z = 0; z < m / size; ++z) {
                C_local[i][j] += A_cols[i][z] * B_rows[z][j];
            }
        }
    }

    for (int i = 0; i < k; ++i) {
        for (int j = 0; j < m / size; ++j) {
            if (A_cols[i][j] < my_min.min) {
                my_min.min = A_cols[i][j];
            }
        }
    }

    MPI_Reduce(&my_min, &total_min, 1, MPI_2INT, MPI_MINLOC, 0, MPI_COMM_WORLD);
    MPI_Bcast(&total_min, 1, MPI_2INT, 0, MPI_COMM_WORLD);
    MPI_Reduce(C_local, C, k * l, MPI_INT, MPI_SUM, total_min.rank, MPI_COMM_WORLD);
    if (rank == total_min.rank) {
        printf("I am %d\n", rank);
        printMatrix((int*)C, k, l);
    }

    MPI_Type_free(&RESIZED_COL_TYPE);
    MPI_Type_free(&COL_TYPE);
    MPI_Type_free(&RESIZED_ROW_TYPE);
    MPI_Type_free(&ROW_TYPE);
    MPI_Finalize();
    return 0;
}