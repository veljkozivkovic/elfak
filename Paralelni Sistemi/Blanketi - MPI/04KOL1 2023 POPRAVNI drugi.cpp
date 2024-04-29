#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define n 5
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

    MPI_Comm cart;

    int dims[2] = { n , m };
    int periods[2] = { 1,1 };
    int reorder = 1;
    int K = rank;

    MPI_Cart_create(MPI_COMM_WORLD, 2 ,dims, periods, reorder, &cart);


    if (rank % 2 == 0)
    {
        cout << "ja sam " << rank << " paran sam i K pre mi je " << K << endl;
    }
    else
    {
        cout << "ja sam " << rank << " neparan sam i K pre mi je " << K << endl;

    }


    int send_to, recv_from;
    MPI_Cart_shift(cart, 1, 2, &recv_from, &send_to);

    MPI_Sendrecv_replace(&K, 1, MPI_INT, send_to, 69, recv_from, 69, MPI_COMM_WORLD, &stat);
    K += rank;

    if (rank % 2 == 0)
    {
        cout << "ja sam " << rank << " paran sam i K posle mi je " << K << endl;
    }
    else
    {
        cout << "ja sam " << rank << " neparan sam i K posle mi je " << K << endl;

    }

    MPI_Finalize();
    return 0;
}