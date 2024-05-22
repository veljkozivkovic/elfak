#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
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

void ispisiMatricu(int A[][n]) {
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            cout << setw(5) << right << A[i][j];
        }
        cout << endl;
    }
    cout << "=======================================" << endl;
}


int findMin(int* niz, int size)
{
    int min = niz[0];

    for (int i = 1; i < size; i++)
    {
        if (niz[i] < min) min = niz[i];
    }

    return min;
}


typedef struct {
    int val;
    int rank;
}minLoc;


int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);

    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Status stat;

    


    if (size != n * 2)   exit(-1);

    int q = sqrt(size);
    int k = n / q;
    int A[n][n], B[n], C[n];
    
    
    MPI_Datatype blok;

    MPI_Type_vector(k, k, n, MPI_INT, &blok);
    MPI_Type_commit(&blok);


    int localA[2][2], localB[2];

    int komC[n];
    fill(&komC[0], &komC[0] + n, 0);


    int localC[2];

    fill(&A[0][0], &A[0][0] + n * n, 0);
    fill(&localA[0][0], &localA[0][0] + k*k , 0);

    fill(&B[0], &B[0] + n, 0);
    fill(&localB[0], &localB[0] + k, 0);

    fill(&C[0], &C[0] + n, 0);
    fill(&localC[0], &localC[0] + 2, 0);

    




    if (!rank)
    {
        int brojac = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A[i][j] = brojac++;
            }
        }

        
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                localA[i][j] = A[i][j];


        brojac = 1;
        for (int i = 0; i <= 6; i += 2)
        {

            for (int j = 0; j <= 6; j += 2)
            {
                if(i==0 && j==0) {}
                else 
                {
                    MPI_Send(&A[i][j], 1, blok, brojac++, 69, MPI_COMM_WORLD);

                }
            }
        }

        brojac = 1;
        ispisiMatricu(A);
        for (int i = 0; i < n; i++)
        {
            B[i] = brojac++;
        }


    }



    else
    {
        MPI_Recv(&localA[0][0], 4 , MPI_INT, 0, 69, MPI_COMM_WORLD, &stat);
    }
    


    MPI_Comm kolone, vrste;

    int colorKol = rank % q;
    int colorVrste = rank / q;


    //key stavljam na nule jer ce on sam da im raspodeli
    MPI_Comm_split(MPI_COMM_WORLD, colorKol, 0, &kolone);
    MPI_Comm_split(MPI_COMM_WORLD, colorVrste, 0, &vrste);

    // ovaj comm split sad ce da splituje ceo komunikator na onoliko komunikatora koliko
    //vidi razlicitih boja, u ovom slucaju je 4 razlicitih boja i on ce napravi 4 komunik
    // i dodavace kako ide redom u svaki komunikator ce krene brojanje od 0


    //sad cu da izvucem rankove
    int rKol, rVrs;
    MPI_Comm_rank(kolone, &rKol);
    MPI_Comm_rank(vrste, &rVrs);

    //cout << rank << " primio sam " << endl;

   // cout << rank << " " << rKol << " " << rVrs << endl;


    // svi u nultoj vrsti su u svom komunikatoru za kolonu rank = 0
   if (rKol == 0)
    {
       //jebme ti mamu glupu ovde se zbunjujes s glupost
       // kolko inta saljes tolko primas, sencount i recv count postoje ako saljes jebeni izvedeni
        MPI_Scatter(B, k, MPI_INT, localB, k, MPI_INT, 0, vrste);
    }


   
   
   MPI_Bcast(localB, 2, MPI_INT, 0, kolone);
   
   for (int i = 0; i < k; i++)
   {
       for (int j = 0; j < k; j++)
       {
           localC[i] += localA[i][j] * localB[j];
           //cout << localA[i][j] << " " << localB[j] << " " <<  localC[i] << " ";
       }
       //cout << endl;
   }


   MPI_Gather(localC, 2, MPI_INT, komC, 2, MPI_INT, 0, kolone);



   if (rKol == 0)
   {
       MPI_Reduce(komC, C, n, MPI_INT, MPI_SUM, 0, vrste);
   }

   if (!rank)
   {
       for (int i = 0; i < n; i++)
           cout << C[i] << " ";
       cout << endl;
   }
    

    MPI_Finalize();
    return 0;
}