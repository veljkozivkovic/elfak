#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
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


void printMatrix(int k, int l, int** A)
{

    for (int i = 0; i < k; i++)
    {
        for (int j = 0; j < l; j++)
        {
            cout << A[i][j] << " ";

        }
        cout << endl;
    }

}



int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);
    
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    int A[n][n];


    if (n % size != 0 || n % 2 != 0) exit(-1);


    MPI_Datatype vektorP, vrsta;
    // 4 bloka velicine 8 / 4 = 2 na rastojanju po 16
    MPI_Type_vector(n / 2, n / size, 2 * n, MPI_INT, &vektorP);
    MPI_Type_commit(&vektorP);

    //mora ipak resize iako je po vrstama jbg
    MPI_Type_create_resized(vektorP, 0, n / size * sizeof(int), &vrsta);
    MPI_Type_commit(&vrsta);


    // n je maks jbg ne daje mi non-constant
    int niz[2*n];

    if (!rank)
    {
        int brojac = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A[i][j] = rand() % 125;

            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cout << A[i][j] << " ";

            }
            cout << endl;
        }

        cout << "==========================" << endl;
        

    }
//                                ako ima 8 procesa primaju po 4
    MPI_Scatter(A, 1, vrsta, niz, n * n / (2 * size), MPI_INT, 0, MPI_COMM_WORLD);


    //dobro je
    //cout << " proc: " << rank << " " << niz[0] << " " << niz[1] << " " << niz[2] << " " << niz[3] << endl;

    int globalniMax;



    int lokalniMax = findMax(niz, n * n / (2 * size));

    MPI_Reduce(&lokalniMax, &globalniMax, 1, MPI_INT, MPI_MAX, 0, MPI_COMM_WORLD);

    if (!rank)
    {
        cout << " Ja sam nulti proces i max je: " << globalniMax << endl;
    }


    MPI_Finalize();
    return 0;
}