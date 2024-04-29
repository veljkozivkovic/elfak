#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define k 15
#define n 8

int findMax(int* niz, int size)
{
    int max = niz[0];

    for (int i = 1; i < size; i++)
    {
        if (niz[i] > max) max = niz[i];
    }

    return max;
}

void ispisiMatricu(int A[][n]) {
    for (int i = 0; i < k; i++)
    {
        for (int j = 0; j < n; j++)
        {
            cout << setw(5) << right << A[i][j];
        }
        cout << endl;
    }
    cout << "=======================================" << endl;
}


int findMin(int* niz, int size)
{
    int min = niz[0];

    for (int i = 1; i < size; i++)
    {
        if (niz[i] < min) min = niz[i];
    }

    return min;
}


typedef struct {
    int val;
    int rank;
}minLoc;

bool inArray(int* niz, int size, int broj)
{
    for (int i = 0; i < size; i++)
    {
        if (niz[i] == broj)
            return true;
    }
    return false;
}





int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);

    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Status stat;

    int A[k][n];
    fill(&A[0][0], &A[0][0] + k * n, 0);


    int kolkoVrsta = pow(2, rank);
    int* localA = new int[kolkoVrsta * n];
    fill(&localA[0],&localA[0] + kolkoVrsta * n, 0);

    int b[n];
    fill(&b[0], &b[0] + n, 0);

    int d[k];
    fill(&d[0], &d[0] + k, 0);
    int localD[k];
    fill(&localD[0], &localD[0] + k, 0);



    MPI_Datatype vrsta;
    MPI_Type_vector(1, n, n, MPI_INT, &vrsta);
    MPI_Type_commit(&vrsta);

    if(!rank)
    {
        int brojac = 1;
        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A[i][j] = brojac++;
            }
        }

        ispisiMatricu(A);

        brojac = 1;
        for (int i = 0; i < n; i++)
        {
            b[i] = brojac++;
        }
        for (int i = 0; i < n; i++)
        {
            cout << b[i] << " ";
            localA[i] = A[0][i];
        }
        cout << endl;


        for (int i = 1; i < size; i++)
        {
            int korak = pow(2, i) - 1; // korak je 2^rank - 1 jer za P1 krece od A[1] za P2 od A[3] za P3 od A[7]
            MPI_Send(&A[korak ][0], pow(2, i), vrsta, i, 69, MPI_COMM_WORLD); // pazi sjebao si od kog elementa se krece
        }


    }
    
    else 
    {
        MPI_Recv(localA, kolkoVrsta * n, MPI_INT, 0, 69, MPI_COMM_WORLD, &stat);
    }


    MPI_Bcast(b, n, MPI_INT, 0, MPI_COMM_WORLD);


    for (int i = 0; i < kolkoVrsta; i++)
    {
        for (int j = 0; j < n; j++)
            localD[kolkoVrsta - 1 + i] += b[j] * localA[j + i * n]; // kolkoVrsta - 1 + i pobrinjavam se da samo pokrivam lokalniD za vrste koje fata a ostale su 0
    }

    MPI_Reduce(localD, d, k, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);


    if (!rank)
    {
        for (int i = 0; i < k; i++)
        {
            cout << d[i] << " ";
        }
        cout << endl;
    }


    MPI_Finalize();
    return 0;

}