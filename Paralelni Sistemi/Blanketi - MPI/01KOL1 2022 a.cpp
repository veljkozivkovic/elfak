#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define n 6
#define m 5
#define k 4

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

bool inArray(int* niz, int size, int broj)
{
    for (int i = 0; i < size; i++)
    {
        if (niz[i] == broj)
            return true;
    }
    return false;
}





int main(int argc, char* argv[])
{
    int rank, size;
    MPI_Init(&argc, &argv);

    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Status stat;


    if (n % size != 0) exit(-1);

    int A[n][m];
    fill(&A[0][0], &A[0][0] + n * m, 0);

    int B[m][k];
    fill(&B[0][0], &B[0][0] + m * k, 0);

    int C[n][k];
    fill(&C[0][0], &C[0][0] + n * k, 0);

    int localC[n][k];
    fill(&localC[0][0], &localC[0][0] + n * k, 0);


    MPI_Datatype vektor, tip;

    MPI_Type_vector(n / size, m, size * m , MPI_INT, &vektor);
    MPI_Type_commit(&vektor);

    MPI_Type_create_resized(vektor, 0, m * sizeof(int), &tip);
    MPI_Type_commit(&tip);


    int* primljeno = new int[n/size*m];


    if (!rank)
    {
        int brojac = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                A[i][j] = brojac++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                cout << setw(5) << right << A[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;



        brojac = m * k;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < k; j++)
            {
                B[i][j] = brojac--;
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < k; j++)
            {
                cout << setw(5) << right << B[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;




    }

    MPI_Scatter(A, 1, tip, primljeno, n / size * m, MPI_INT, 0, MPI_COMM_WORLD);
    

    //cout << rank << " " << primljeno[0] << " " << primljeno[1] << " " << primljeno[2] << " " << primljeno[3] << " " << primljeno[4] << " " << primljeno[5] << " " << primljeno[6] << " " << primljeno[7] << " " << primljeno[8] << " " << primljeno[9] << endl;

    MPI_Bcast(B, m * k, MPI_INT, 0, MPI_COMM_WORLD);

    for (int i = 0; i < n / size; i++)
    {
        for (int j = 0; j < k; j++)
        {

            for (int z = 0; z < m; z++)
            {
                localC[rank + i * size][j] += primljeno[z + m * i] * B[z][j];
            }

        }
    }

    
   


    MPI_Reduce(localC, C, n * k, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    if (!rank)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                cout << setw(5) << right << C[i][j];
            }
            cout << endl;
        }
        cout << "=======================================" << endl;
    }


    delete[] primljeno;

    MPI_Finalize();
    return 0;

}