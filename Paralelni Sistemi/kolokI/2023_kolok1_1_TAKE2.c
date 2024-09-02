#include <stdio.h>
#include "mpi.h"

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
    int k, m = -1, l;

    if (rank == 0) {
        while (m % size != 0) {
            printf("(k, l, m), %d | l: ", size);
            scanf("%d %d %d", &k, &m, &l);
        }
    }
    MPI_Bcast(&k, 1, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Bcast(&l, 1, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Bcast(&m, 1, MPI_INT, 0, MPI_COMM_WORLD);

    int A[k][m], B[m][l], C[k][l];

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

    MPI_Datatype COL_TYPE, RESIZED_COL_TYPE;
    MPI_Type_vector(k * m / size, 1, size, MPI_INT, &COL_TYPE);
    MPI_Type_create_resized(COL_TYPE, 0, sizeof(int), &RESIZED_COL_TYPE);
    MPI_Type_commit(&RESIZED_COL_TYPE);

    MPI_Datatype ROW_TYPE, RESIZED_ROW_TYPE;
    MPI_Type_vector(m / size, l, l * size, MPI_INT, &ROW_TYPE);
    MPI_Type_create_resized(ROW_TYPE, 0, l * sizeof(int), &RESIZED_ROW_TYPE);
    MPI_Type_commit(&RESIZED_ROW_TYPE);

    int my_col[k][m / size], my_row[m / size][l];
    MPI_Scatter(A, 1, RESIZED_COL_TYPE, my_col, k * m / size, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Scatter(B, 1, RESIZED_ROW_TYPE, my_row, m * l / size, MPI_INT, 0, MPI_COMM_WORLD);

    int my_res[k][l];
    struct { int min; int rank; } my_min = { INT32_MAX, rank }, min;

    for (int i = 0; i < k; ++i) {
        for (int j = 0; j < l; ++j) {
            my_res[i][j] = 0;
            for (int z = 0; z < m / size; ++z) {
                my_res[i][j] += my_col[i][z] * my_row[z][j];
                if (my_col[i][z] < my_min.min)
                    my_min.min = my_col[i][z];
            }
        }
    }
    MPI_Reduce(&my_min, &min, 1, MPI_2INT, MPI_MINLOC, 0, MPI_COMM_WORLD);
    MPI_Bcast(&min, 1, MPI_2INT, 0, MPI_COMM_WORLD);
    MPI_Reduce(my_res, C, k * l, MPI_INT, MPI_SUM, min.rank, MPI_COMM_WORLD);

    if (rank == min.rank) {
        printMatrix((int*)C, k, l);
    }

    MPI_Type_free(&RESIZED_ROW_TYPE);
    MPI_Type_free(&ROW_TYPE);
    MPI_Type_free(&RESIZED_COL_TYPE);
    MPI_Type_free(&COL_TYPE);
    MPI_Finalize();
}
