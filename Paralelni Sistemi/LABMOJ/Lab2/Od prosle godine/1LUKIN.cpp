#include <stdio.h>
#include <stdlib.h>
#include "mpi.h"

int main(int argc, char* argv[]) {
    MPI_Init(&argc, &argv);
    int rank, size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    int matrix[size][size];
    MPI_Status status;

    int print_Signal = -1;
    int recv[2 * (size - rank)];

    MPI_Datatype datatypes[size - 1];
    for (int i = 0; i < size - 1; ++i) {
        int array_of_blocklengths[2 * (i + 1)];
        for (int j = 0; j < 2 * (i + 1); ++j)
            array_of_blocklengths[j] = 1;
        int array_of_displacements[2 * (i + 1)];
        for (int j = 0; j < (i + 1); ++j) {
            array_of_displacements[j] = j * (size - 1);
        }
        for (int j = 0; j < (i + 1); ++j) {
            array_of_displacements[i + 1 + j] = (size + 1) * (size - i - 1) + (size - 1) * j; 
        }
        if (rank == 0) {
            for (int j = 0; j < 2 * (i + 1); ++j)
                printf("%d ", array_of_displacements[j]);
            printf("\n");
            fflush(stdout);
        }
        MPI_Type_indexed(2 * (i + 1), array_of_blocklengths, array_of_displacements, MPI_INT, &datatypes[i]);
        MPI_Type_commit(&datatypes[i]);
    }
    MPI_Datatype RECV_TYPE;
    MPI_Type_vector(2, (size - rank), size, MPI_INT, &RECV_TYPE);
    MPI_Type_commit(&RECV_TYPE);

    if (rank == 0) {
        for (int i = 0; i < size; ++i)
            for (int j = 0; j < size; ++j)
                matrix[i][j] = i * size + j;

        for (int i = 0; i < size * size; ++i) {
            printf("%d ", matrix[i / size][i % size]);
        }
        printf("\n");
        for (int i = 0; i < size - 1; ++i) {
            MPI_Send(&matrix[0][i], 1, datatypes[i], size - 1 - i, 88, MPI_COMM_WORLD);
        }
    }
    else {
        for (int i = 0; i < size; ++i)
            for (int j = 0; j < size; ++j)
                matrix[i][j] = 1;
        MPI_Recv(&matrix[1][0], 1, RECV_TYPE, 0, 88, MPI_COMM_WORLD, &status);

        if (rank == 1) {
            printf("Process %d has\n", rank);
            for (int i = 0; i < size; ++i) {
                for (int j = 0; j < size; ++j)
                    printf("%d ", matrix[i][j]);
                printf("\n");
            }
            printf("\n");
            fflush(stdout);
            MPI_Send(&print_Signal, 1, MPI_INT, rank + 1, 88, MPI_COMM_WORLD);
        }
        else if (rank != size - 1) {
            MPI_Recv(&print_Signal, 1, MPI_INT, rank - 1, 88, MPI_COMM_WORLD, &status);
            printf("Process %d has\n", rank);
            for (int i = 0; i < size; ++i) {
                for (int j = 0; j < size; ++j)
                    printf("%d ", matrix[i][j]);
                printf("\n");
            }
            printf("\n");
            fflush(stdout);
            MPI_Send(&print_Signal, 1, MPI_INT, rank + 1, 88, MPI_COMM_WORLD);
        }
        else {
            MPI_Recv(&print_Signal, 1, MPI_INT, rank - 1, 88, MPI_COMM_WORLD, &status);
            printf("Process %d has\n", rank);
            for (int i = 0; i < size; ++i) {
                for (int j = 0; j < size; ++j)
                    printf("%d ", matrix[i][j]);
                printf("\n");
            }
            printf("\n");
            fflush(stdout);
        }
    }

    for (int i = 0; i < size - 1; ++i)
        MPI_Type_free(&datatypes[i]);
    MPI_Type_free(&RECV_TYPE);
    MPI_Finalize();
    return 0;
}