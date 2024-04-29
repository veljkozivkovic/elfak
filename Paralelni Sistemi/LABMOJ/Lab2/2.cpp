#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define m 16


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


    int A[m];
    int B[m];
    int C = 0;

    int localA[m];
    int localB[m];
    int localC = 0;

    fill(A, A + m, 0);
    fill(B, B + m, 0);
    fill(localA, localA + m, 0);
    fill(localB, localB + m, 0);
    



    if (m % size != 0) exit(-1);
    // k = m / size size = 4 => k = 4

    MPI_Datatype vektor;
    MPI_Type_vector(m / size, 1, m / size, MPI_INT, &vektor);
    MPI_Type_commit(&vektor);

    MPI_Datatype novi;
    MPI_Type_create_resized(vektor, 0, 1 * sizeof(int), &novi);
    MPI_Type_commit(&novi);


    if (!rank)
    {
        int brojac = 1;
        for (int i = 0; i < m; i++)
        {
            A[i] = B[i] = brojac++;
        }

        cout << "Ja sam nulti proces" << endl;
        cout << "A: ";
        for (int i = 0; i < m; i++)
        {
            cout << A[i] << " ";
        }
        cout << endl << "B: ";

        for (int i = 0; i < m; i++)
        {
            cout << B[i] << " ";
        }
        cout << endl << "==============================" << endl;
    }

    MPI_Scatter(A, 1, novi, localA, m/size, MPI_INT , 0, MPI_COMM_WORLD);
    MPI_Scatter(B, 1, novi, localB, m / size, MPI_INT, 0, MPI_COMM_WORLD);

    //cout << rank << " " << localA[0] << " " << localA[1] << " " << localA[2] << " " << localA[3] << " " << localA[4] << " " << localA[5] << " " << localA[6] << " " << localA[7] << " " << localA[8] << " " << localA[9] << " " << localA[10] << " " << localA[11] << " " << localA[12] << " " << localA[13] << " " << localA[14] << " " << localA[15] << endl;
    //cout << rank << " " << localB[0] << " " << localB[1] << " " << localB[2] << " " << localB[3] << " " << localB[4] << " " << localB[5] << " " << localB[6] << " " << localB[7] << " " << localB[8] << " " << localB[9] << " " << localB[10] << " " << localB[11] << " " << localB[12] << " " << localB[13] << " " << localB[14] << " " << localB[15] << endl;


    for (int i = 0; i < m / size; i++)
    {
        localC += localA[i] * localB[i];
    }

    MPI_Reduce(&localC, &C, 1, MPI_INT, MPI_SUM, 1, MPI_COMM_WORLD);

    if (rank == 1)
    {
        cout << " Skalarani proizvod je: " << C;
    }

    MPI_Finalize();
    return 0;
}