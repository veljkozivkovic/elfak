#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
using namespace std;

#define n 32

bool Paran(int* niz)
{
    int suma = 0;
    for (int i = 0; i < 31; i++)
    {
        suma += niz[i];
    }

    return (suma % 2) == 0;
}

int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);
    
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    MPI_Status stat;
   

    int prva;
    int druga;

    if (!rank)
    {
        for (int i = 1; i < size; i++)
        {
            prva = i * 3;
            druga = i * 2;

            MPI_Send(&prva, 1, MPI_INT, i, 69, MPI_COMM_WORLD);
            MPI_Send(&druga, 1, MPI_INT, i, 699, MPI_COMM_WORLD);

            MPI_Recv(&prva, 1, MPI_INT, i, 420, MPI_COMM_WORLD, &stat);
            cout << " Primio sam poruku od procesa " << prva << endl;
        }
    }
    else
    {
        MPI_Recv(&druga, 1, MPI_INT, 0, 699, MPI_COMM_WORLD, &stat);
        cout << "Ja sam proces " << rank << "primio sam DRUGU poruku: " << druga << endl;
        MPI_Recv(&prva, 1, MPI_INT, 0, 69, MPI_COMM_WORLD, &stat);
        cout << "Ja sam proces " << rank << "primio sam PRVU poruku: " << prva << endl;


        MPI_Send(&rank, 1, MPI_INT, 0, 420, MPI_COMM_WORLD);
    }



    MPI_Finalize();
    return 0;
}