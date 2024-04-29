#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define n 6
#define m 5
#define k 4

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


    int q = sqrt(size);

   


    int* includeList = new int[q];

    for (int i = 0; i < q; i++)
    {
        includeList[i] = i + i * q;
    }

    MPI_Group cela, grupa;
    MPI_Comm novi;

    MPI_Comm_group(MPI_COMM_WORLD, &cela);
    MPI_Group_incl(cela, q, includeList, &grupa);

    MPI_Comm_create(MPI_COMM_WORLD, grupa, &novi);

    if (inArray(includeList, q, rank))
    {
        int rankC;
        int sizeC;
        MPI_Comm_rank(novi, &rankC);
        MPI_Comm_size(novi, &sizeC); // mada size je = q svakako

        int poruka;

        if (!rankC)
        {
            poruka = 69;
        }
        
        MPI_Bcast(&poruka, 1, MPI_INT, 0, novi);
        cout << "stari rank " << rank << " novi rank " << rankC << " primljena poruka: " << poruka << endl;

    }


    delete[] includeList;
    MPI_Finalize();
    return 0;

}