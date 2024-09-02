#include <stdio.h>
#include <stdlib.h>
#include "mpi.h"

int main(int argc, char* argv[]) {
    MPI_Init(&argc, &argv);
    int rank, size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    int n = -1, m = -1;
    int K = rank;

    if (rank == 0) {
        while (n * m != size || m % 2 != 0) {
            printf("n, m (n * m = %d m mod 2 == 0): ", size);
            scanf("%d %d", &n, &m);
        }
    }
    MPI_Bcast(&n, 1, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Bcast(&m, 1, MPI_INT, 0, MPI_COMM_WORLD);

    MPI_Comm CARTESIAN_COMM;
    int ndims = 2;
    int dims[2] = { n, m };
    int periods[2] = { 1, 1 };
    MPI_Cart_create(MPI_COMM_WORLD, ndims, dims, periods, 0, &CARTESIAN_COMM);

    int to_send_to, to_recv_from;
    MPI_Cart_shift(CARTESIAN_COMM, 1, 2, &to_recv_from, &to_send_to);

    if (rank % 2 == 0) {
        printf("K before: %d\n", K);
    }

    MPI_Sendrecv_replace(&K, 1, MPI_INT, to_send_to, 88, to_recv_from, 88, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
    K += rank;
    
    if (rank % 2 == 0) {
        printf("%d's K after: %d\n", rank, K);
    }

    MPI_Finalize();
    return 0;
}