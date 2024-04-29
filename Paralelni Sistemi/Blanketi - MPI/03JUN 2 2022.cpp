#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define m 4
#define n 12

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
    for (int i = 0; i < m; i++)
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




    if (n % size != 0)   exit(-1);



    int q = n / size; //12/3 = 4

    int A[m][n];
    fill(&A[0][0], &A[0][0] + m * n, 0);



    //jebeno me mrzi pravim matricu
    int localA[m][q];
	
	int* localA = new int[m*q];
	

	// 1 2 3 4
	// 5 6 7 8
	// 9 10 11 12
    int b[n];
    fill(&b[0], &b[0] + n, 0);

    int c[m];
     

    int localC[m];
    

    fill(c, c + m, 0);
    fill(localC, localC + m, 0);


    MPI_Datatype vektor, kolonae;

    MPI_Type_vector(m*q, 1, size, MPI_INT, &vektor);
    MPI_Type_commit(&vektor); //ne mora commit mozda ce skine neki poen kurva


    MPI_Type_create_resized(vektor, 0, 1 * sizeof(int), &kolonae);
    MPI_Type_commit(&kolonae);
    

    if(!rank)
    {
        int brojac = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A[i][j] = brojac++;
            }
        }

        ispisiMatricu(A);

        brojac = n;

        for (int i = 0; i < n; i++)
        {
            b[i] = brojac--;
        }

        for (int i = 0; i < n; i++)
        {
            cout << b[i] << " ";
            
        }
        cout << endl;


       


    }
    
    
    MPI_Scatter(A, 1, kolonae, localA, q * m, MPI_INT, 0, MPI_COMM_WORLD);

    MPI_Bcast(b, n, MPI_INT, 0, MPI_COMM_WORLD);

    

    
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < q; j++)
        {
            
            localC[i] += b[j*size + rank] * localA[i * q + j];

        }
    }

    MPI_Reduce(localC, c, m, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    
    

    if (!rank)
    {

        for (int i = 0; i < m; i++)
        {
            
            cout << c[i] << " ";

        }
        cout << endl;
    }








    


    MPI_Finalize();
    return 0;

}