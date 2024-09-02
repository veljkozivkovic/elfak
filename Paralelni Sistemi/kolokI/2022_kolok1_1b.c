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
    int val;

    if (rank == 0)
        val = 55;

    if ((int)pow(side, 2) != size) {
        MPI_Finalize();
        exit(-1);
    }

    int diag_ranks[side];
    for (int i = 0; i < size; i += (side + 1)) {
        diag_ranks[i / (side + 1)] = i;
    }

    MPI_Group WORLD_GROUP, DIAG_GROUP;
    MPI_Comm DIAG_COMM;
    MPI_Comm_group(MPI_COMM_WORLD, &WORLD_GROUP);
    MPI_Group_incl(WORLD_GROUP, side, diag_ranks, &DIAG_GROUP);
    MPI_Comm_create(MPI_COMM_WORLD, DIAG_GROUP, &DIAG_COMM);

    if (rank % (side + 1) == 0) {
        MPI_Bcast(&val, 1, MPI_INT, 0, DIAG_COMM);
        int newrank;
        MPI_Comm_rank(DIAG_COMM, &newrank);
        printf("I'm %d in COMM_WORLD and %d in DIAG_COMM and val=%d\n", rank, newrank, val);
    }

    MPI_Finalize();
    return 0;
}