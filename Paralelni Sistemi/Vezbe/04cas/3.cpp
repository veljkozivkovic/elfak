#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>

#define n 5
using namespace std;




int main(int argc, char* argv[])
{
    int rank, size;
    
    struct { int a; double b; }val;

    MPI_Init(&argc, &argv);
    MPI_Status stat;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    MPI_Datatype mystruct;

    int blocklens[2];
    MPI_Aint indices[2];

    MPI_Datatype old_types[2];

    blocklens[0] = 1;
    blocklens[1] = 1;

    old_types[0] = MPI_INT;
    old_types[1] = MPI_DOUBLE;


    MPI_Get_address(&val.a, &indices[0]);
    MPI_Get_address(&val.b, &indices[1]);

    indices[1] = indices[1] - indices[0];
    indices[0] = 0;

    MPI_Type_create_struct(2, blocklens, indices, old_types, &mystruct);

    MPI_Type_commit(&mystruct);

    if (!rank)
    {
        cout << "Ja sam " << rank << " unesi val.a i val.b: ";
        fflush(stdout);
        cin >> val.a >> val.b;
    }

    MPI_Bcast(&val, 1, mystruct, 0, MPI_COMM_WORLD);

    cout << " Ja sam proces " << rank << " primio sam: " << val.a << " " << val.b << endl;
    fflush(stdout);

    MPI_Finalize();
    return 0;
}