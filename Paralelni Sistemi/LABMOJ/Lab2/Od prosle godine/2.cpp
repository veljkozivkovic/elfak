#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
using namespace std;

#define n 8

int findMin(int* niz, int size)
{
    int min = niz[0];
    for (int i = 1; i < size; i++)
    {
        if (niz[i] < min)
            min = niz[i];
    }
    return min;
}

int main(int argc, char* argv[])
{
    int rank, size;
    

    MPI_Init(&argc, &argv);
    
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);


    int local[n];


    if (n % size != 0 || n % 2 != 0) exit(-1);

    MPI_Datatype vektor, ParKolona, prima;

    MPI_Type_vector(n / size * n / 2, 1, 2, MPI_INT, &vektor); // 8 / 4 * 8 / 2 = 8 => 4 procesa po 8 vrednosti...
    MPI_Type_commit(&vektor);

    MPI_Type_create_resized(vektor, 0, n / size * n * sizeof(int), &ParKolona); // 8 / 4 * 8
    MPI_Type_commit(&ParKolona);



    int matrica[n][n]{ 0 };
    if (!rank)
    {
        int brojac = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrica[i][j] = rand() % 125;
            }
        }

        cout << "Ja sam proces 0 :" << endl;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cout << matrica[i][j] << " ";
            }
            cout << endl;
        }
        fflush(stdout);


    }


    MPI_Scatter(&matrica[0][0], 1, ParKolona, local, n / size * n / 2, MPI_INT, 0, MPI_COMM_WORLD);

    //cout << " ja sam proces " << rank << " " << local[0] << " " << local[1] << " " << local[2] << " " << local[3] << " " << local[4] << " " << local[5] << " " << local[6] << " " << local[7] << endl;

    int lokalniMin = findMin(local, n / size * n / 2); // za size = 4 i n = 8 ce bude po 8 za svaki proces
    const int velicina = size;
    int globalniMin;
    MPI_Reduce(&lokalniMin, &globalniMin, 1, MPI_INT, MPI_MIN, 0, MPI_COMM_WORLD);

    if (!rank)
    {
        cout << " Najmanja brojka je: " << lokalniMin << endl;
        fflush(stdout);
    }

    MPI_Finalize();
    return 0;
}