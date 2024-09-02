#include <stdio.h>
#include <stdlib.h>
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
    int n = 4;
    int A[n][n], C[n][n];

    MPI_Datatype DONJA_TROKUTAONA;
    int array_of_blocklengths[n * (n + 1) / 2];
    int array_of_displacements[n * (n + 1) / 2];
    int c = n * (n + 1) / 2 - 1;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; ++j) {
            if (i >= j) {
                array_of_displacements[c] = -((n - i - 1) * n + (n - j - 1));
                array_of_blocklengths[c--] = 1;
            }
        }
    }
    MPI_Type_indexed(n * (n + 1) / 2, array_of_blocklengths, array_of_displacements, MPI_INT, &DONJA_TROKUTAONA);
    MPI_Type_commit(&DONJA_TROKUTAONA);

    MPI_Datatype GORNJA_TROKUTAONA;
    int array_of_displacements_gornji[n * (n + 1) / 2];
    int is, js; is = js = n - 1;
    int i = is, j = js;
    c = 0;
    while (i != -1) {
        array_of_displacements_gornji[c++] = -((is - i) * n + (js - j));
        if (j == js) {
            i -= 1;
            j = i;
        }
        else {
            j += 1;
        }
    }
    MPI_Type_indexed(n * (n + 1) / 2, array_of_blocklengths, array_of_displacements_gornji, MPI_INT, &GORNJA_TROKUTAONA);
    MPI_Type_commit(&GORNJA_TROKUTAONA);    

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            A[i][j] = i * n + j;
            C[i][j] = 0;
        }
    }
    if (rank == 0) {
        for (int i = 1; i < size; ++i) {
            MPI_Send(&A[n-1][n-1], 1, DONJA_TROKUTAONA, i, 88, MPI_COMM_WORLD);
        }
    }
    else {
        MPI_Recv(&C[n-1][n-1], 1, GORNJA_TROKUTAONA, 0, 88, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        printMatrix((int*)C, n, n);
    }

    MPI_Type_free(&GORNJA_TROKUTAONA);
    MPI_Type_free(&DONJA_TROKUTAONA);
    MPI_Finalize();
    return 0;
}