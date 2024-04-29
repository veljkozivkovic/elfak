#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
using namespace std;

#define m 5


int findMax(int* niz, int size)
{
    int max = niz[0];

    for (int i = 1; i < size; i++)
    {
        if (niz[i] > max) max = niz[i];
    }

    return max;
}




int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);
    
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    int A[m][m], B[m][m];

    int localC[m][m]{ 0 };
    int C[m][m]{ 0 };
    if (size != m) exit(-1);


    if (!rank)
    {
        int brojac = 1;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                A[i][j] = brojac;
                brojac += 2;
            }
        }
        cout << "MATRICA A" << endl;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                cout << A[i][j] << " " ;
            }
            cout << endl;
        }


        cout << "============================" << endl;

        brojac = 2;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                B[i][j] = brojac;
                brojac += 2;
            }
        }

        cout << "MATRICA B" << endl;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                cout << B[i][j] << " ";
            }
            cout << endl;
        }


    }
    
    int niz[m];

    MPI_Datatype vektor, vektorK, kolona;

    //za slanje vrsta za mnozenje
    MPI_Type_vector(1, m, m, MPI_INT, &vektor);
    MPI_Type_commit(&vektor);


    //za slanje kolona za trazenje maksa
    MPI_Type_vector(m, 1, m, MPI_INT, &vektorK);
    MPI_Type_commit(&vektorK);

    MPI_Type_create_resized(vektorK, 0, 1 * sizeof(int), &kolona);
    MPI_Type_commit(&kolona);

    MPI_Bcast(B, m * m, MPI_INT, 0, MPI_COMM_WORLD);

    MPI_Scatter(A, 1, vektor, niz, m, MPI_INT, 0, MPI_COMM_WORLD);


    //dobro je
    //cout << "proc " << rank << " " << niz[0] << " " << niz[1] << " " << niz[2] << " " << niz[3] << " " << niz[4] << endl;

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < m; j++)
        {
            localC[rank][i] += niz[j] * B[j][i];
        }
    }


    //dobro je
    /*cout << "local MATRICA C za " << rank  << endl;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << localC[i][j] << " ";
        }
        cout << endl;
    }*/

    MPI_Reduce(localC, C, m * m, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);


    if (!rank)
    {
        cout << "MATRICA C" << endl;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                cout << C[i][j] << " ";
            }
            cout << endl;
        }
    }

    int lokalnaK[m];


    MPI_Scatter(C, 1, kolona, lokalnaK, m, MPI_INT, 0, MPI_COMM_WORLD);

    cout << "Za kolonu " << rank << " max je " << findMax(lokalnaK, m) << endl;

    MPI_Finalize();
    return 0;
}