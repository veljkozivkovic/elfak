#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define m 5
#define n 6

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

    int dims[2] = { m , n };
    int periods[2] = { 1,1 };
    int reorder = 1;
    
    int coords[2];

    MPI_Cart_create(MPI_COMM_WORLD, 2 ,dims, periods, reorder, &cart);

    MPI_Cart_coords(cart, rank, 2, coords);
    
    int podatak[3] = { rank, coords[0], coords[1] };

    int send_to, recv_from;

    MPI_Cart_shift(cart, 1, 2, &recv_from, &send_to);

    if (rank % 2 == 0)
    {
        cout << "ja sam " << rank << " paran sam i podaci pre su mi " << podatak[0] << " " << podatak[1] << " " << podatak[2] << endl;
    }
    else
    {
        cout << "ja sam " << rank << " neparan sam i podaci pre su mi " << podatak[0] << " " << podatak[1] << " " << podatak[2] << endl;

    }


    MPI_Sendrecv_replace(podatak, 3, MPI_INT, send_to, 69, recv_from, 69, cart, &stat);
    podatak[0] += rank;
    podatak[1] += rank;
    podatak[2] += rank;

    if (!rank)
    {
        cout << "==============================================================" << endl;
    }

    MPI_Barrier(cart);

    if (rank % 2 == 0)
    {
        cout << "ja sam " << rank << " paran sam i podaci posle su mi " << podatak[0] << " " << podatak[1] << " " << podatak[2] << endl;
    }
    else
    {
        cout << "ja sam " << rank << " neparan sam i podaci posle su mi " << podatak[0] << " " << podatak[1] << " " << podatak[2] << endl;

    }


    MPI_Finalize();
    return 0;
}