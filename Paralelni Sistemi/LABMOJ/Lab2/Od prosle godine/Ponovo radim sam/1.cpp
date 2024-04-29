#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>

using namespace std;

#define m 8


int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);
    
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    MPI_Status stat;
    int potvrda;
   
    int A[m][m];
    fill(&A[0][0], &A[0][0] + m * m, 1);

    if (size != m) exit(-1);

    MPI_Datatype vektor[m];

    for (int i = m - 1; i >= 1; i--)
    {
        MPI_Type_vector(i, 1, m - 1, MPI_INT, &vektor[i]);
        MPI_Type_commit(&vektor[i]);
    }

    

    if (!rank)
    {
        int brojac = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                A[i][j] = brojac++;
            }
        }

        cout << "Ja sam nulti proces" << endl;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < m; j++) {
                cout << setw(5) << right << A[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;







        for (int i = m - 1; i >= 1; i--)
        {
            MPI_Send(&A[0][i-1], 1, vektor[i], i, 69, MPI_COMM_WORLD);
            MPI_Send(&A[m - i][m - 1], 1, vektor[i], i, 420, MPI_COMM_WORLD);
        }

    }

    else
    {
        MPI_Recv(&A[1][0], rank, MPI_INT, 0, 69, MPI_COMM_WORLD, &stat);
        MPI_Recv(&A[2][0], rank, MPI_INT, 0, 420, MPI_COMM_WORLD, &stat);

        if (rank != size - 1)
        {
            MPI_Recv(&potvrda, 1, MPI_INT, rank + 1, 333, MPI_COMM_WORLD, &stat);
        }
       
        cout << "Ja sam" << rank << " proces" << endl;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < m; j++) {
                cout << setw(5) << right << A[i][j];
            }
            cout << endl;
        }
        cout << "=======================================";
        fflush(stdout);
        
        if(rank != 1)
            MPI_Send(&potvrda, 1, MPI_INT, rank - 1, 333, MPI_COMM_WORLD);
    }

    MPI_Finalize();
    return 0;
}