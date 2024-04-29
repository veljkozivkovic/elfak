#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>

using namespace std;

#define m 4
#define n 5
#define k 6

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

int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);
    
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    MPI_Status stat;
    int potvrda;
   

    if (k % size != 0)  exit(-1);



    int primljeno[n * k / 2]; // n*k/2 je maks ako B ima 30 el jednom ide petnes drugom 15 ako su 2 procesa
    int A[m][n];
    int B[n][k];
    int C[m][k];
    int localC[m][k];
    

    fill(&A[0][0], &A[0][0] + m * n, 0);
    fill(&B[0][0], &B[0][0] + n * k, 0);
    fill(&C[0][0], &C[0][0] + m * k, 0);
    fill(&localC[0][0], &localC[0][0] + m * k, 0);

    
    MPI_Datatype vektor;
    MPI_Type_vector(n, 1, k, MPI_INT, &vektor);
    MPI_Type_commit(&vektor);

    MPI_Datatype kolonae;
    MPI_Type_create_resized(vektor, 0, 1 * sizeof(int), &kolonae);
    MPI_Type_commit(&kolonae);


    if (!rank)
    {
        int brojac = 1;
        for (int i = 0; i < m; i++)
        {

            for (int j = 0; j < n; j++)
            {
                A[i][j] = brojac++;
            }
        }

        cout << "Matrica A" << endl;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cout << setw(5) << right << A[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;

        brojac = n * k;
        for (int i = 0; i < n; i++)
        {
            
            for (int j = 0; j < k; j++)
            {
                B[i][j] = brojac--;
            }
        }

        cout << "Matrica B" << endl;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                cout << setw(5) << right << B[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;

    }
    
    MPI_Bcast(A, m * n, MPI_INT, 0, MPI_COMM_WORLD);


    MPI_Scatter(&B[0][0], k / size, kolonae, primljeno, k / size * n, MPI_INT, 0, MPI_COMM_WORLD);


    int pocetak = rank * k / size;



    // slanje je dobro primi se kolko treba se primi
    /*cout << "ja sam proces " << rank << " pocetak je(ukljucujuci): " << pocetak << " kraj je (ne ukljucujuci) " << pocetak + k / size << endl;
    fflush(stdout);
    cout << primljeno[0] << " " << primljeno[1] << " " << primljeno[2] << " " << primljeno[3] << " " << primljeno[4] << " " << primljeno[5] << " " << primljeno[6] << " " << primljeno[7] << " " << primljeno[8] << " " << primljeno[9] << " " << endl;
    fflush(stdout);*/

    for (int i = pocetak; i < pocetak + k / size ; i++)
    {
        for (int j = 0; j < m; j++)
        {
            //localC[j][i] 
            for (int l = 0; l < n; l++)
            {
                if (!rank)
                {
                    localC[j][i] += A[j][l] * primljeno[l + i * n];
                }
                else
                {
                    localC[j][i] += A[j][l] * primljeno[l + ((i % pocetak) * n)];
                }
                
            }
        }
    }

    //cout << rank <<" uespesno mnozenje" << endl;



    MPI_Reduce(localC, C, m * k, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    if (rank == 0)
    {
        cout << "lokalna matrica C za rank: " << rank << endl;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < k; j++)
            {
                cout << setw(5) << right << localC[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;
    }

    MPI_Barrier(MPI_COMM_WORLD);

    if (rank == 1)
    {
        cout << "lokalna matrica C za rank: " << rank << endl;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < k; j++)
            {
                cout << setw(5) << right << localC[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;
    }

    MPI_Barrier(MPI_COMM_WORLD);
    if (rank == 2)
    {
        cout << "lokalna matrica C za rank: " << rank << endl;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < k; j++)
            {
                cout << setw(5) << right << localC[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;
    }

    MPI_Barrier(MPI_COMM_WORLD);

    if (rank == 0)
    {
        cout << "Krajna matrica C" << endl;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < k; j++)
            {
                cout << setw(5) << right << C[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;
    }

    MPI_Finalize();
    return 0;
}