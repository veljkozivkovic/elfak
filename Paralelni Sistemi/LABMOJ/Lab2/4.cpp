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
int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);

    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Status stat;





    if (m % size != 0) exit(-1);


    int A[m][m];
    fill(&A[0][0], &A[0][0] + m *m, 0);
    
    int primljeno[m * 2];

    
    MPI_Datatype vektor;
    MPI_Type_vector(m / 2, 1, 2 * m, MPI_INT, &vektor);
    MPI_Type_commit(&vektor);

    MPI_Datatype kolonae;
    MPI_Type_create_resized(vektor, 0, sizeof(int), &kolonae);
    MPI_Type_commit(&kolonae);

    if (rank == 2)
    {
        int brojac = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                A[i][j] = rand() % 100;
            }
        }

        ispisiMatricu(A);
    }

    MPI_Scatter(&A[1][0], m / size, kolonae, primljeno, m / size * m / 2, MPI_INT, 2, MPI_COMM_WORLD);

    cout << rank << " " << primljeno[0] << " " << primljeno[1] << " " << primljeno[2] << " " << primljeno[3] << " " << primljeno[4] << " " << primljeno[5] << " " << primljeno[6] << " " << primljeno[7] << endl;
    
    minLoc trenutni;
    minLoc globalni;

    trenutni.val = findMin(primljeno, m / size * m / 2);
    trenutni.rank = rank;

    MPI_Reduce(&trenutni, &globalni, 1, MPI_2INT, MPI_MINLOC, 2, MPI_COMM_WORLD);

    if (rank == 2)
    {
        cout << "proces sa najmanji min je: " << globalni.rank << " sa vrednost " << globalni.val << endl;
    }



    MPI_Finalize();
    return 0;
}