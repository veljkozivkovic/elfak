#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define m 8


int findMax(int* niz, int size)
{
    int max = niz[0];

    for (int i = 1; i < size; i++)
    {
        if (niz[i] > max) max = niz[i];
    }

    return max;
}

void ispisiMatricu(int A[][m]) {
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << setw(5) << right << A[i][j];
        }
        cout << endl;
    }
    cout << "=======================================" << endl;
}


int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);

    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Status stat;


    MPI_Datatype vektor, kolonae;

    if (m % size != 0) exit(-1);

    int A[m][m];
   
    fill(&A[0][0], &A[0][0] + m*m, 0);

    if (size != m) exit(-1);

    int potvrda;



    MPI_Datatype kvazi[m];

    for (int i = m - 1; i >= 1; i--)
    {
        MPI_Type_vector(i, 1, m-1, MPI_INT, &kvazi[i]);
        MPI_Type_commit(&kvazi[i]);
    }

    if (!rank)
    {
        int brojac = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                A[i][j] = brojac++;
            }
        }

        ispisiMatricu(A);


        for (int i = m-1; i >= 1; i--)
        {
            MPI_Send(&A[rank][i-1], 1, kvazi[i], i, 1, MPI_COMM_WORLD);
            MPI_Send(&A[m - i][m-1], 1 ,kvazi[i], i, 2, MPI_COMM_WORLD);
        }
    }

    else
    {
        MPI_Recv(&A[m - 2][0], rank, MPI_INT, 0, 1, MPI_COMM_WORLD, &stat);
        MPI_Recv(&A[m - 1][0], rank, MPI_INT, 0, 2, MPI_COMM_WORLD, &stat);

        if (rank != size - 1)
        {
            MPI_Recv(&potvrda, 1, MPI_INT, rank + 1, 333, MPI_COMM_WORLD, &stat);
        }

        ispisiMatricu(A);

        if (rank != 1)
        {
            MPI_Send(&potvrda, 1, MPI_INT, rank - 1, 333, MPI_COMM_WORLD);
        }

    }


    MPI_Finalize();
    return 0;
}