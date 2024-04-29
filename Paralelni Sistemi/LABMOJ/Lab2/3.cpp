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


    if (size != m) exit(-1);


    int A[m][m];
    int B[m][m];
    int C[m][m];

    int localA[m];
    int localB[m];
    int localC[m][m];

    fill(&A[0][0], &A[0][0] + m *m, 0);
    fill(&B[0][0], &B[0][0] + m* m, 0);
    fill(&C[0][0], &C[0][0] + m * m, 0);
    fill(&localC[0][0], &localC[0][0] + m * m, 0);


    MPI_Datatype vektor, kolona;

    MPI_Type_vector(m, 1, m, MPI_INT, &vektor);
    MPI_Type_commit(&vektor);

    MPI_Type_create_resized(vektor, 0, 1 * sizeof(int), &kolona);



    if (!rank)
    {
        int brojacA = 1;
        int brojacB = m * m;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                A[i][j] = brojacA++;
                B[i][j] = brojacB--;
            }
        }
        ispisiMatricu(A);
        ispisiMatricu(B);


    }

    MPI_Scatter(A, 1, kolona, localA, m, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Bcast(B, m * m, MPI_INT, 0, MPI_COMM_WORLD);

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < m; j++)
        {
            localC[i][rank] += localA[j] * B[j][rank]; // deblcine su jer treba vrsta od A iz inat necu radim

        }
    }
    //stao sam kod 3 mrzi me vise radimx

    MPI_Finalize();
    return 0;
}