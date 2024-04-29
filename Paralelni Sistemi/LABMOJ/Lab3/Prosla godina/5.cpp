#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define n 5
#define m 3
#define v 27
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

    int dims[2] = { n,n };
    int periods[2] = { 1,1 };
    int reorder = 1;

    MPI_Comm cart, trougaona;

    MPI_Cart_create(MPI_COMM_WORLD, 2, dims, periods, reorder, &cart);

    if (!rank)
    {
        int brojac = 0;
        int A[n][n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A[i][j] = brojac++;
            }
        }

        ispisiMatricu(A);
    }

    int coords[2];

    MPI_Cart_coords(cart, rank, 2, coords);


    bool color = coords[0] <= coords[1];
    
    MPI_Comm_split(MPI_COMM_WORLD, color, 0, &trougaona);

    int sizeT;
    int rankT;
    
    MPI_Comm_size(trougaona, &sizeT);
    MPI_Comm_rank(trougaona, &rankT);

    int suma;

    int gornja;
    int donja;

    MPI_Reduce(&rank, &suma, 1, MPI_INT, MPI_SUM, sizeT - 1, trougaona);

    if (rankT == sizeT - 1)
    {
        MPI_Send(&suma, 1, MPI_INT, 0, 69, MPI_COMM_WORLD);
    }

    

    if (!rank)

    {
        MPI_Recv(&donja, 1, MPI_INT, size - 2, 69, MPI_COMM_WORLD, &stat); // zadnji el u donju ce uvek bude levo od najveceg procesa
                                                                           // tj size -2
        MPI_Recv(&gornja, 1,MPI_INT, size - 1, 69, MPI_COMM_WORLD, &stat); // najveci u gornju je size-1
        

        cout << " ja sam master na SVI, donja suma je " << donja << " gornja suma je " << gornja << endl;
    }

    
    MPI_Finalize();
    return 0;
}