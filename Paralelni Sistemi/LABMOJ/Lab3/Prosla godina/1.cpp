#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

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

    MPI_Group cela, dijagonale;

    int koren = sqrt(size);


    // ako 4 procesa  n = 2
    //ako 16 procesa n = 4
    // ako 36 procesa n = 6
    // ako 64 procesa n = 8 itd...
    if (koren % 2 != 0) exit(-1);
    


    //int includeList[koren];

    int* includeList = new int[koren];

    for (int i = 0; i < koren; i++)
    {
        includeList[i] = i * koren + i;
    }

    MPI_Comm_group(MPI_COMM_WORLD, &cela);

    MPI_Group_incl(cela, koren, includeList, &dijagonale);

    int rankD;
    MPI_Comm dija;
    MPI_Comm_create(MPI_COMM_WORLD, dijagonale, &dija);

    // moze ovako ali mora provera sa inArray
    //MPI_Comm_rank(dija, &rankD); 
    MPI_Group_rank(dijagonale, &rankD);

    int poruka = -1;

    if (!rankD)
    {
        poruka = 69;
    }


    if( inArray(includeList, koren, rank))
        MPI_Bcast(&poruka, 1, MPI_INT, 0, dija);



    cout << " ja sam proc " << rank << " ako sam u dijagonali ja sam " << rankD << " i primio sam " << poruka << endl;














    delete[] includeList;
    
    MPI_Finalize();
    return 0;
}#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

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

    MPI_Group cela, dijagonale;

    int koren = sqrt(size);


    // ako 4 procesa  n = 2
    //ako 16 procesa n = 4
    // ako 36 procesa n = 6
    // ako 64 procesa n = 8 itd...
    if (koren % 2 != 0) exit(-1);
    


    //int includeList[koren];

    int* includeList = new int[koren];

    for (int i = 0; i < koren; i++)
    {
        includeList[i] = i * koren + i;
    }

    MPI_Comm_group(MPI_COMM_WORLD, &cela);

    MPI_Group_incl(cela, koren, includeList, &dijagonale);

    int rankD;
    MPI_Comm dija;
    MPI_Comm_create(MPI_COMM_WORLD, dijagonale, &dija);

    // moze ovako ali mora provera sa inArray
    //MPI_Comm_rank(dija, &rankD); 
    MPI_Group_rank(dijagonale, &rankD);

    int poruka = -1;

    if (!rankD)
    {
        poruka = 69;
    }


    if( inArray(includeList, koren, rank))
        MPI_Bcast(&poruka, 1, MPI_INT, 0, dija);



    cout << " ja sam proc " << rank << " ako sam u dijagonali ja sam " << rankD << " i primio sam " << poruka << endl;














    delete[] includeList;
    
    MPI_Finalize();
    return 0;
}