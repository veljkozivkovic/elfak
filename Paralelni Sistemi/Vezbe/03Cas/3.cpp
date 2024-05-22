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

    const int n = 3;
    
    int matrica[n][n];

    int vektor[n];
   
    int vektorZaP[n];
    int vektorZaVrste[n];
    int rezultat[n];

    if (!rank)
    {
        cout << "Unesi elemente matrice A : " << endl;
        fflush(stdout);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                cin >> matrica[i][j];
            }
        }

        cout << "Unesi elemente vektora B:  " << endl;
        fflush(stdout);

        for (int j = 0; j < n; j++)
        {
            cin >> vektor[j];
        }


    }

    MPI_Scatter(matrica, n, MPI_INT, vektorZaVrste, n, MPI_INT, 0, MPI_COMM_WORLD);
    //MPI_Scatter(vektor, n, MPI_INT, vektorZaP, n, MPI_INT, 0, MPI_COMM_WORLD);
    // NE MOZES SA SCATTER ISTI VEKTOR B DA IM SALJES VEC SA BCAST
    MPI_Bcast(vektor, n, MPI_INT, 0, MPI_COMM_WORLD);
    for (int i = 0; i < n; i++)
    {
        cout << "Ja sam proces " << rank << "vrsta mi je: " << i << " " << vektorZaVrste[i] <<
            "preneti B je: " << i << vektor[i] << endl;
    }

    int lokalna_vr = 0;
    for (int i = 0; i < n; i++)
    {
        lokalna_vr += vektor[i] * vektorZaVrste[i];
    }

    cout << "ja sam proces" << rank << "vektor mi je " << vektor[0]<< " " << vektor[1]<< " " << vektor[2] << " " << endl;

    //PAZI KAKO GATHER RADI!!!
    MPI_Gather(&lokalna_vr, 1, MPI_INT, rezultat, 1,MPI_INT, 0, MPI_COMM_WORLD);

    if (!rank)
    {
        cout << "Rezultujuci vektor je: " << endl;
        fflush(stdout);

        for (int i = 0; i < n; i++)
        {
            cout << rezultat[i] << " ";
            fflush(stdout);
        }



    }





    MPI_Finalize();
    return 0;
}