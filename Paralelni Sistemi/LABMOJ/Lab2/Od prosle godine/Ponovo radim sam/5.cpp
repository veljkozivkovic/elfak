#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define m 6


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

    MPI_Datatype vektor, kolonae;

    if (m % size != 0) exit(-1);

    int A[m][m];
    int primljeno[m * m / 2]; // ako je m 6 onda je maks br sto treba za niz 18 tj pola od m*m
    fill(&A[0][0], &A[0][0] + m*m, 0);

    MPI_Type_vector(m / 2, 1, 2 * m, MPI_INT, &vektor);
    MPI_Type_commit(&vektor);

    MPI_Type_create_resized(vektor, 0, sizeof(int), &kolonae);
    MPI_Type_commit(&kolonae);

    if (!rank)
    {

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                A[i][j] = rand() % 25;
                
            }
        }

        ispisiMatricu(A);
    }

    MPI_Scatter(A, m / size, kolonae, primljeno, m/size * m/2, MPI_INT,0 ,MPI_COMM_WORLD);

    //cout << rank << primljeno[0] << " " << primljeno[1] << " " << primljeno[2] << " " << primljeno[3] << " " << primljeno[4] << " " << primljeno[5] << endl;

    int max = findMax(primljeno, m / size * m / 2);
    int globalMax;
    cout << "Ja sam proc " << rank << " lokalni max je " << max << endl;
    fflush(stdout);

    MPI_Reduce(&max, &globalMax, 1, MPI_INT, MPI_MAX, 0, MPI_COMM_WORLD);
    if (!rank)
    {
        cout << " Globalni max je " << globalMax << endl;
    }

    MPI_Finalize();
    return 0;
}