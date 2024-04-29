#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
using namespace std;

#define n 32

int FindMin(int* niz, int size)
{
    int min = niz[0];

    for (int i = 1; i < size; i++)
    {
        if (min > niz[i]) min = niz[i];
    }

    return min;
}

int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);
    
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    MPI_Status stat;
   
    int niz[n];

    if (n % size != 0)    exit(-1);

    if (!rank)
    {
        int primam[n];

        /*for (int i = 0; i < n; i++)
        {
            cout << "Unesi " << i << " element: ";
            cin >> niz[i];
            cout << endl;
        }*/

        for (int i = 0; i < n; i++)
        {
            niz[i] = rand() % 15;
        }

        cout << "Ja sam root proces pocetan niz je:" << endl;

        for (int i = 0; i < n; i++)
        {
            cout << niz[i] << " ";
        }
        cout << endl;
        cout << "===============================================" << endl;



        for (int i = 1; i < size; i++)
        {
            MPI_Send(&niz[i * n / size], n / size, MPI_INT, i, 69, MPI_COMM_WORLD);
            MPI_Recv(&primam[i], 1 , MPI_INT, i, 420, MPI_COMM_WORLD, &stat);
        }
        
        primam[0] = FindMin(niz, n / size);

        cout << "Ja sam proces " << rank << " min mi je " << primam[0] << endl;
        fflush(stdout);

        int globalMin = FindMin(primam, size);
        cout << "Ja sam root proces i global min je:" << globalMin << endl;
        fflush(stdout);

        cout << primam[0] << " " << primam[1] << " " << primam[2] << " " << primam[3] << " " << primam[4] << " " << primam[5] << " " << primam[6] << " " << primam[7] << " " << endl;

    }
    else
    {
        int primam[n];
        MPI_Recv(primam, n / size, MPI_INT, 0, 69, MPI_COMM_WORLD, &stat);
        
        int min = FindMin(primam, n / size);
        cout << "Ja sam proces " << rank << " min mi je " << min << endl;
        fflush(stdout);

        MPI_Send(&min, 1, MPI_INT, 0, 420, MPI_COMM_WORLD);
    
    }




    MPI_Finalize();
    return 0;
}