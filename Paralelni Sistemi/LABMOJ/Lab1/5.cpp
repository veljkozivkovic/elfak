#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
using namespace std;

#define n 32

bool Uslov(int* niz, int size, int rank)
{

    int sum = 0;
    for (int i = 0; i < size; i++)
    {
        sum += niz[i];
    }

    return (sum % rank) == 0;

}

int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);
    
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    MPI_Status stat;
   
    int buffer[n];
    bool tacan;

    for (int i = 0; i < n; i++)
    {
        buffer[i] = rand() % 32;
    }

    if (!rank)
    {
        for (int i = 1; i < size; i++)
        {
            
            MPI_Recv(&tacan, 1, MPI_C_BOOL, i, 69, MPI_COMM_WORLD, &stat);
            cout << "Proces " << i << " je ";
            if (tacan)
            {
                cout << "tacan" << endl;
            }
            else
            {
                cout << "netacan" << endl;

            }
        }

    }
    else
    {
        tacan = Uslov(buffer, n, rank);
        MPI_Send(&tacan, 1, MPI_C_BOOL, 0, 69, MPI_COMM_WORLD);
    }

    MPI_Finalize();
    return 0;
}