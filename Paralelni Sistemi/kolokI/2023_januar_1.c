#include <stdio.h>
#include <stdlib.h>
#include "mpi.h"
#include <math.h>

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
    int k, n;
    int* my_row, my_row_size;

    if (rank == 0) {
        printf("k, n: ");
        scanf("%d %d", &k, &n);
    }
    MPI_Bcast(&k, 1, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Bcast(&n, 1, MPI_INT, 0, MPI_COMM_WORLD);

    int A[k][n], b[n], res[k];

    if (rank == 0) {
        for (int i = 0; i < k; ++i) {
            for (int j = 0; j < n; ++j) {
                A[i][j] = i * n + j;
            }
        }
        for (int i = 0; i < n; ++i) {
            b[i] = 1;
        }
    }
    MPI_Bcast(&b, n, MPI_INT, 0, MPI_COMM_WORLD);
    if (rank == 0) {
        my_row_size = n;
        my_row = (int*)malloc(n * sizeof(int));
        for (int i = 0; i < n; ++i)
            my_row[i] = A[0][i];
        for (int i = 1; i < size; ++i) {
            if ((int)pow(2, i) - 1 + (int)pow(2, i) <= k) {
                MPI_Send(&A[(int)pow(2, i) - 1][0], (int)pow(2, i) * n, MPI_INT, i, 88, MPI_COMM_WORLD);
            }
            else {
                MPI_Send(&A[(int)pow(2, i) - 1][0], (k - (int)pow(2, i) + 1) * n, MPI_INT, i, 88, MPI_COMM_WORLD);
            }
        }
    }
    else {
        if ((int)pow(2, rank - 1) + (int)pow(2, rank) <= k) {
            my_row_size = (int)pow(2, rank) * n;
            my_row = (int*)malloc(my_row_size * sizeof(int));
            MPI_Recv(my_row, my_row_size, MPI_INT, 0, 88, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        }
        else {
            my_row_size = (k - (int)pow(2,rank) + 1) * n;
            my_row = (int*)malloc(my_row_size * sizeof(int));
            MPI_Recv(my_row, my_row_size, MPI_INT, 0, 88, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        }
    }
    int my_res[my_row_size / n];
    for (int i = 0; i < n; ++i)
        my_res[i] = 0;

    for (int i = 0; i < my_row_size; ++i) {
        my_res[i / n] += my_row[i] * b[i % n];
    }

    struct { int loaded; int rank; } my_max = { my_row_size, rank }, max;
    MPI_Reduce(&my_max, &max, 1, MPI_2INT, MPI_MAXLOC, 0, MPI_COMM_WORLD);
    MPI_Bcast(&max, 1, MPI_2INT, 0, MPI_COMM_WORLD);

    if (rank == max.rank) {
        int c = 0;
        for (int i = 0; i < size; ++i) {
            if (rank == i) {
                for (int j = 0; j < my_row_size / n; ++j) {
                    res[c++] = my_res[j];
                }
            }
            else {
                if ((int)pow(2, i) - 1 + (int)pow(2, i) <= k) {
                    MPI_Recv(&res[c], (int)pow(2, i), MPI_INT, i, 88, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
                    c += (int)pow(2, i);
                }
                else {
                    MPI_Recv(&res[c], (k - (int)pow(2, i) + 1) * n, MPI_INT, i, 88, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
                }    
            }
        }
        for (int i = 0; i < k; ++i) {
            printf("%d ", res[i]);
        }
        printf("\n");
    }
    else {
        MPI_Send(my_res, my_row_size / n , MPI_INT, max.rank, 88, MPI_COMM_WORLD);
    }


    MPI_Finalize();
    return 0;
}