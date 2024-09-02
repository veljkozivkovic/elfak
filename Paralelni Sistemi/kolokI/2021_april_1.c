#include <stdio.h>
#include <math.h>
#include "mpi.h"

#define m 8 

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
    int q = (int)sqrt(size);
    int k = m / q;
    int A[m][m], b[m], c[m];

    MPI_Comm ROW_COMM, COL_COMM;
    MPI_Comm_split(MPI_COMM_WORLD, rank / q, 0, &ROW_COMM);
    MPI_Comm_split(MPI_COMM_WORLD, rank % q, 0, &COL_COMM);

    MPI_Datatype BLOCK_TYPE, RESIZED_BLOCK_TYPE;
    MPI_Type_vector(k, 1, q, MPI_INT, &BLOCK_TYPE);
    MPI_Type_create_resized(BLOCK_TYPE, 0, q * m * sizeof(int), &RESIZED_BLOCK_TYPE);
    MPI_Type_commit(&RESIZED_BLOCK_TYPE);

    MPI_Datatype VEC_TYPE, RESIZED_VEC_TYPE;
    MPI_Type_vector(k, 1, q, MPI_INT, &VEC_TYPE);
    MPI_Type_create_resized(VEC_TYPE, 0, sizeof(int), &RESIZED_VEC_TYPE);
    MPI_Type_commit(&RESIZED_VEC_TYPE);

    int my_block[k][k], my_b[k], my_res[k];

    if (rank == 0) {
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < m; ++j) {
                A[i][j] = i * m + j;
            }
            b[i] = 1;
        }
        for (int i = 0; i < k; ++i) {
            for (int j = 0; j < k; ++j) {
                my_block[i][j] = A[i * q][j * q];
            }
        }
        for (int i = 0; i < q; ++i) {
            for (int j = 0; j < q; ++j) {
                if (i == 0 && j == 0) continue;
                MPI_Send(&A[i][j], 2, RESIZED_BLOCK_TYPE, i * q + j, 88, MPI_COMM_WORLD);
            }
        }
    }
    else {
        MPI_Recv(my_block, k * k, MPI_INT, 0, 88, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
    }
    MPI_Scatter(b, 1, RESIZED_VEC_TYPE, my_b, k, MPI_INT, 0, ROW_COMM);
    MPI_Bcast(my_b, k, MPI_INT, 0, COL_COMM);

    for (int i = 0; i < k; ++i) {
        my_res[i] = 0;
        for (int j = 0; j < k; ++j) {
            my_res[i] += my_block[i][j] * my_b[j];
        }
    }

    int temp_res[k];

    MPI_Reduce(my_res, temp_res, k, MPI_INT, MPI_SUM, 0, ROW_COMM);
    MPI_Gather(temp_res, k, MPI_INT, c, 1, RESIZED_VEC_TYPE, 0, COL_COMM);

    if (rank == 0) {
        printMatrix((int*)c, 1, m);
    }

    MPI_Type_free(&RESIZED_VEC_TYPE);
    MPI_Type_free(&VEC_TYPE);
    MPI_Type_free(&RESIZED_BLOCK_TYPE);
    MPI_Type_free(&BLOCK_TYPE);
    MPI_Finalize();
}