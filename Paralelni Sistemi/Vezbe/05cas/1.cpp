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

    MPI_Group cela, parni, neparni;

    int brParni, brNeparni;
    int rParni, rNeparni;

    brParni = (size + 1) / 2;
    brNeparni = size - brParni;

    int Parni[8]; //jebemim majku sto mi ne daju promenljive

    for (int i = 0; i < brParni; i++)
    {
        Parni[i] = 2 * i;
    }

    MPI_Comm_group(MPI_COMM_WORLD, &cela);

    MPI_Group_incl(cela, brParni, Parni, &parni);
    MPI_Group_excl(cela, brNeparni, Parni, &neparni);

    MPI_Group_rank(parni, &rParni);
    MPI_Group_rank(neparni, &rNeparni);

    cout << "Rank u celi " << rank << " rank u parni " << rParni << " rank u neparni " << rNeparni << endl;


    MPI_Finalize();
    return 0;
}