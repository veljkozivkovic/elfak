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
    int potvrda;


    MPI_Datatype zaNulti, zaPrvi;


    MPI_Type_vector(1, n, n, MPI_INT, &zaNulti);
    MPI_Type_vector(n, 1, n, MPI_INT, &zaPrvi);


    MPI_Type_commit(&zaNulti);
    MPI_Type_commit(&zaPrvi);

    if (!rank)
    {

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matr[i][j] = 69;
            }
        }


        cout << "Ja sam proces " << rank << "moja matrica je :" << endl;
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

        MPI_Send(&potvrda, 1, MPI_INT, 1, 69, MPI_COMM_WORLD);
        MPI_Send(&matr[0][0], 1, zaNulti, 1, 69, MPI_COMM_WORLD);

    }





    else
    {
        brojac = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matr[i][j] = brojac++;
            }
        }

        MPI_Recv(&potvrda, 1, MPI_INT, 0, 69, MPI_COMM_WORLD, &stat);

        cout << "Ja sam proces " << rank << "moja matrica pre je :" << endl;
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

        MPI_Recv(&matr[0][0], 1, zaPrvi, 0, 69, MPI_COMM_WORLD, &stat);



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