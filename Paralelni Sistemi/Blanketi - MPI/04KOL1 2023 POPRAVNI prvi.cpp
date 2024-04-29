#include <iostream>
#include <algorithm>
#include <math.h>
#include "mpi.h"
#include <iomanip>
using namespace std;

#define k 4
#define m 12
#define l 6




int main(int argc, char* argv[])
{
	
	int rank, size;

	MPI_Init(&argc, &argv);
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Comm_size(MPI_COMM_WORLD, &size);

	if (m % size != 0)	exit(-1);

	int q = m / size; // size = 3, m = 12 => q = 4 

	int A[k][m];
	fill(&A[0][0], &A[0][0] + k * m, 0);

	int localA[k][4];
	fill(&localA[0][0], &localA[0][0] + q * k, 0);


	int B[m][l];
	fill(&B[0][0], &B[0][0] + m * l, 0);
	
	int localB[4][l];
	fill(&localB[0][0], &localB[0][0] + q * l, 0);

	int C[k][l], localC[k][l];
	fill(&C[0][0], &C[0][0] + k * l, 0);
	fill(&localC[0][0], &localC[0][0] + k * l, 0);

	MPI_Datatype vektorA, kolonaeA, vektorB, vrstaeB;

	MPI_Type_vector(k * q, 1, size, MPI_INT, &vektorA);
	MPI_Type_create_resized(vektorA, 0, sizeof(int), &kolonaeA);
	MPI_Type_commit(&kolonaeA);

	MPI_Type_vector(q ,l, size*l, MPI_INT,&vektorB);
	MPI_Type_create_resized(vektorB, 0, l * sizeof(int), &vrstaeB);
	MPI_Type_commit(&vrstaeB);

	if (!rank)
	{
		int brojac = 1;
		for (int i = 0; i < k; i++)
		{
			for (int j = 0; j < m; j++)
			{
				A[i][j] = brojac++;
			}
		}

		for (int i = 0; i < k; i++)
		{
			for (int j = 0; j < m; j++)
			{
				cout << setw(5) << right << A[i][j];
			}
			cout << endl;
		}
		cout << "=======================================" << endl;
		fflush(stdout);



		brojac = m * l;
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < l; j++)
			{
				B[i][j] = brojac--;
			}
		}

		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < l; j++)
			{
				cout << setw(5) << right << B[i][j];
			}
			cout << endl;
		}
		cout << "=======================================" << endl;
		fflush(stdout);


	}


	MPI_Scatter(A, 1, kolonaeA, localA, q * k, MPI_INT, 0, MPI_COMM_WORLD);
	MPI_Scatter(B, 1, vrstaeB, localB, q * l, MPI_INT, 0, MPI_COMM_WORLD);



	if (rank == 0)
	{
		for (int i = 0; i < q; i++)
		{
			for (int j = 0; j < l; j++)
			{
				cout << setw(5) << right << localB[i][j];
			}
			cout << endl;
		}
		cout << "=======================================" << endl;
	}










	for (int i = 0; i < k; i++)
	{
		for (int j = 0; j < l; j++)
		{
			//localC[i][j]
			for (int z = 0; z < q; z++)
			{
				localC[i][j] += localA[i][z] * localB[z][j];
			}

		}
	}

	MPI_Reduce(localC, C, k * l, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

	if (!rank)
	{
		for (int i = 0; i < k; i++)
		{
			for (int j = 0; j < l; j++)
			{
				cout << setw(10) << right << C[i][j];
			}
			cout << endl;
		}
		cout << "=======================================" << endl;
		fflush(stdout);
	}




	
	MPI_Finalize();
	return 0;
}
