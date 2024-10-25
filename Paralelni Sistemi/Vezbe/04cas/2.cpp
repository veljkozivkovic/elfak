#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>

#define n 5
using namespace std;


int main(int argc, char* argv[])
{
    int rank, size;
    
    MPI_Init(&argc, &argv);
    MPI_Status stat;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    int matr[n][n];
    int brojac;
    
    int blocklens[] = { 5, 4, 3, 2, 1 }; //n-i
    int displacements[] = { 0, 6, 12, 18, 24 }; // i * (n+1)


    //ZA DONJU TROUGAONU ZA 2b
    // int blocklens[] = { 1, 2, 3, 4, 5 }; - i+1
    // int displacements[] = { 0, 5, 10, 15, 20 }; i*n


    MPI_Datatype gornjeTrougaona;

    MPI_Type_indexed(n, blocklens, displacements, MPI_INT, &gornjeTrougaona);

    MPI_Type_commit(&gornjeTrougaona);

    

    if (!rank)
    {
        brojac = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matr[i][j] = brojac++;
            }
        }


       /* cout << "Ja sam proces " << rank << "moja matrica je :" << endl;
        fflush(stdout);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cout << matr[i][j] << " ";
                fflush(stdout);

            }
            cout << endl;
            fflush(stdout);

        }*/

        MPI_Send(&matr[0][0], 1, gornjeTrougaona,1, 69, MPI_COMM_WORLD );

    }





    else
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matr[i][j] = 0;
            }
        }


        MPI_Recv(&matr[0][0], 1, gornjeTrougaona, 0, 69, MPI_COMM_WORLD, &stat);

        cout << "Ja sam proces " << rank << "moja matrica posle je :" << endl;
        fflush(stdout);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cout << matr[i][j] << " ";
                fflush(stdout);

            }
            cout << endl;
            fflush(stdout);

        }
    }




    MPI_Finalize();
    return 0;
}