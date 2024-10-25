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
    MPI_Status stat;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    const int m = 4;
    const int n = 3;


    int matrica[m][n];
    int vektor[n];
    
    int vektorZaP[m];
    int elementOdB;


    int Isuma = 0;
    int suma;

    if (size != n && !rank)
    {
        cout << "Sine moras isti broj procesa kao broj kolona si normalannn" << endl;
        return -1;
    }



    if (!rank)
    {
        cout << "Unesite matricu A: " << endl;
        fflush(stdout);

        for(int i = 0; i< m; i ++)
        {
            for (int j = 0; j < n; j++)
                cin >> matrica[i][j];
        }



        for (int i = 0; i < m; i++)
        {
            vektorZaP[i] = matrica[i][0]; // prvi kolonu sam ostavio za 0. proces
           // cout << "Ja sam nulti proces i moja kolona je: " << i << ". element" << vektorZaP[i] << endl;
        }

        

        for (int i = 1; i < size; i++)
        {
            for (int j = 0; j < m; j++)
            {
                MPI_Send(matrica[0] + i + j * n, 1, MPI_INT, i, 1, MPI_COMM_WORLD);

            }

            

        }
            
        cout << "Unesite vektor B: " << endl;
        fflush(stdout);
        for (int i = 0; i < n; i++)
        {
            cin >> vektor[i];
        }

        for (int i = 1; i < size; i++)
        {
            MPI_Send(&vektor[i], 1, MPI_INT, i, 2, MPI_COMM_WORLD);
        }


        elementOdB = vektor[0];

        

    }
    
    else
    {
        for (int j = 0; j < m; j++)
        {
            MPI_Recv(&vektorZaP[j], 1 , MPI_INT, 0, 1, MPI_COMM_WORLD, &stat);

        }
        //cout << " Ja sam proces " << rank << " primio sam kolonu " << vektorZaP[0] << " " << vektorZaP[1] << " " << vektorZaP[2] << " " << vektorZaP[3] << endl;
        fflush(stdout);

        MPI_Recv(&elementOdB, 1, MPI_INT, 0, 2, MPI_COMM_WORLD, &stat);
       // cout << "Ja sam proces " << rank << " i primio sam jedan el od vektora B: " << elementOdB << endl;
        fflush(stdout);

    }

    for (int i = 0; i < m; i++)
    {
        Isuma += elementOdB * vektorZaP[i];
    }

    MPI_Reduce(&Isuma, &suma, 1, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    if (!rank)
    {
        cout << "Ja sam nulti proces i na kraju suma svega je: " << suma << endl;
    }




    MPI_Finalize();
    return 0;
}