#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
using namespace std;




int main(int argc, char* argv[])
{
    int rank, size;
    

    MPI_Init(&argc, &argv);
    
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    const int m = 2; 
    const int n = 3;
    const int k = 4;

    int localA[m];
    int localB[k];
    int localC[m][k];

    int brojac;

    int A[m][n];
    int B[n][k];
    int C[m][k];


    if (size != n) exit(-1);

    MPI_Datatype kolona;
    MPI_Datatype krajnaKolona;

    MPI_Type_vector(m, 1, n, MPI_INT, &kolona);
    MPI_Type_commit(&kolona);

    MPI_Type_create_resized(kolona, 0, 1 * sizeof(int), &krajnaKolona); // SLIKU IMAS DODATNU
    MPI_Type_commit(&krajnaKolona);



    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < k; j++)
        {
            localC[i][j] = 0;
            C[i][j] = 0;
        }
    }



    if (!rank)
    {
        brojac = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A[i][j] = brojac++;
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cout << A[i][j] << " ";
            }
            cout << endl;
        }


        cout << "========================================" << endl;
        brojac = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                B[i][j] = brojac * 10 + brojac++;
            }
            
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                cout << B[i][j] << " ";
            }
            cout << endl;
        }

    }

    

    MPI_Scatter(A, 1, krajnaKolona, localA, m, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Scatter(B, k, MPI_INT, localB, k, MPI_INT, 0, MPI_COMM_WORLD);

   
    cout << " ja sam proces " << rank << " primiosam :" << endl;
    for (int i = 0; i < m; i++)
        cout << localA[i] << " ";
        
    cout << endl;
    for (int i = 0; i < k; i++)
        cout << localB[i] << " ";
    fflush(stdout);
    

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < k; j++)
        {
            localC[i][j] = localA[i] * localB[j];
        }
    }

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < k; j++)
            C[i][j] = 0;
    }

    // do ovde je dobro!!!
    MPI_Reduce(&localC[0][0], &C[0][0], m*k , MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    if (!rank)
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < k; j++)
            {
                cout << C[i][j] << " ";
            }
            cout << endl;
        }
    }

    MPI_Finalize();
    return 0;
}