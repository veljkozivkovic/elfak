#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>

using namespace std;

#define m 8

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
   
    int primljeno[2 * m]; // 2*m je maks sto moze primi, jer size nije const nmg stavljam
    int A[m][m];
    fill(&A[0][0], &A[0][0] + m * m, 0);


    if (m % size != 0) exit(-1);

    MPI_Datatype pocetni;
    MPI_Type_vector(m/size * m/2, 1, 2, MPI_INT, &pocetni);
    MPI_Type_commit(&pocetni);


    MPI_Datatype krajni;
    MPI_Type_create_resized(pocetni, 0, m / size * m * sizeof(int), &krajni);
    MPI_Type_commit(&krajni);

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
        ispisiMatricu(A);



    }

    //PAZI SALJES SAMO 1 PODATAK TIPA KRAJNI, NISTA DRUGO
    MPI_Scatter(A, 1, krajni, primljeno, m / size * m / 2, MPI_INT, 0, MPI_COMM_WORLD);

    if(rank)
        MPI_Recv(&potvrda, 1, MPI_INT, rank - 1, 69, MPI_COMM_WORLD, &stat);

    cout << "Ja sam proces " << rank << " primio sam: " << endl;
    for (int i = 0; i < m / size * m / 2; i++)
    {
        cout << primljeno[i] << " ";
    }
    cout << endl;
    fflush(stdout);

    if (rank != size - 1)
        MPI_Send(&potvrda, 1, MPI_INT, rank + 1, 69, MPI_COMM_WORLD);

    MPI_Finalize();
    return 0;
}