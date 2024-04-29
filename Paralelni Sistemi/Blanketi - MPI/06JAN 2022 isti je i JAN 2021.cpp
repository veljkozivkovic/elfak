#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;


#define n 12
#define _q 3

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
    for (int i = 0; i < n; i++)
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

    // size = 9, q = 3, n = 12
    int q = (int)sqrt(size);
    if (n % q != 0)    exit(-1);


    int A[n][n];
    fill(&A[0][0], &A[0][0] + n * n, 0);

    //        n/q  
    int localA[n/_q][n];
    fill(&localA[0][0], &localA[0][0] + n/_q * n, 0);

    
    int B[n][n];
    fill(&B[0][0], &B[0][0] + n * n, 0);

    int localB[n][n / _q];
    fill(&localB[0][0], &localB[0][0] + n * n/_q , 0);

    int C[n][n];
    fill(&C[0][0], &C[0][0] + n * n, 0);

    int localC[n][n];
    fill(&localC[0][0], &localC[0][0] + n * n, 0);

    MPI_Datatype vektorA, vrstaA, vektorB, kolonaB;

    MPI_Type_vector(n / q, n, q * n, MPI_INT, &vektorA);
    MPI_Type_create_resized(vektorA, 0, n * sizeof(int), &vrstaA);
    MPI_Type_commit(&vrstaA);


    MPI_Type_vector(n / q * n, 1, q, MPI_INT, &vektorB);
    MPI_Type_create_resized(vektorB, 0, sizeof(int), &kolonaB);
    MPI_Type_commit(&kolonaB);

    if (!rank)
    {
        int brojac = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A[i][j] = brojac++;
            }
           
        }
        ispisiMatricu(A);
        brojac = n * n;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                B[i][j] = brojac--;
            }
        }
        ispisiMatricu(B);

    }

    MPI_Comm vrsta, kolona;

    int colorV = rank / q;
    int colorK = rank % q;

    int rankV, rankK, sizeV, sizeK;



    MPI_Comm_split(MPI_COMM_WORLD, colorV, 0, &vrsta);
    MPI_Comm_split(MPI_COMM_WORLD, colorK, 0, &kolona);


    MPI_Comm_rank(vrsta, &rankV);
    MPI_Comm_rank(kolona, &rankK);

    MPI_Comm_size(vrsta, &sizeV);
    MPI_Comm_size(kolona, &sizeK);

    //scatterujemo vrste od matrice A;
    if (!rankV)
    {
        MPI_Scatter(A, 1, vrstaA, localA, n * n / q, MPI_INT, 0, kolona);
    }

    MPI_Bcast(localA, n * n / q, MPI_INT, 0,vrsta);

    if (!rankK)
    {
        MPI_Scatter(B, 1, kolonaB, localB, n / q * n, MPI_INT, 0, vrsta);
    }

    MPI_Bcast(localB, n / q * n, MPI_INT, 0, kolona);

    for (int i = rankK; i < n ; i+=q) //vrste od localC
    { 
        for (int j = rankV; j < n; j += q) // kolone od localC
        {
            for (int z = 0; z < 12; z++)
            {
                localC[i][j] += localA[i/q][z] * localB[z][j/q];

            }
        }
    }

    MPI_Reduce(localC, C, n * n, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    if (!rank)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cout << setw(10) << right << C[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;
    }
    MPI_Finalize();
    return 0;
}