#include <stdio.h>
#include <stdlib.h>
#include "mpi.h"
#include <math.h>

int main(int argc, char* argv[]) {
    MPI_Init(&argc, &argv);
    int rank, size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    int side = (int)sqrt(size);
    int msg = 0;
    if (rank == 0) msg = 52;

    if ((int)pow(side, 2) != size) {
        perror("ERROR");
        MPI_Finalize();
        exit(1);
    }


    int n_of_diag_procs = (size % 2) ? (2 * side - 1) : (2 * side);
    int diag_ranks[n_of_diag_procs];
    int c = 0;
    for (int i = 0; i < size; ++i) {
        if (i % (side - 1) == 0 || i % (side + 1) == 0) {
            diag_ranks[c++] = i;
        }
    }

    MPI_Group WORLD_GROUP, DIAG_GROUP;
    MPI_Comm_group(MPI_COMM_WORLD, &WORLD_GROUP);
    MPI_Group_incl(WORLD_GROUP, n_of_diag_procs, diag_ranks, &DIAG_GROUP);
    MPI_Comm DIAG_COMM;
    MPI_Comm_create(MPI_COMM_WORLD, DIAG_GROUP, &DIAG_COMM);

    if (rank % (side - 1) == 0 || rank % (side + 1) == 0) {
        MPI_Bcast(&msg, 1, MPI_INT, 0, DIAG_COMM);
        printf("%d %d\n", rank, msg);
    }

    MPI_Finalize();
    return 0;
}