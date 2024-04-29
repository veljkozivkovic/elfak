#include <iostream>
#include "mpi.h"
using namespace std;


#define root 0
#define n 6

int main(int argc, char* argv[])
{
	int i, j;
	int rank, size;
	float a[n], b, c, lokalniA[n], lokalSum = 0, celSum = 0, izraz = 0;
	float sum = 0, avg = 0;


	MPI_Init(&argc, &argv);
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Comm_size(MPI_COMM_WORLD, &size);


	if (n % size != 0) exit(-1);


	if (rank == 0) {
		for (i = 0; i < n; i++) 
		{
			a[i] = (float)i + 1;
			sum += a[i];
		}
		avg = sum / n;
	}
	
	MPI_Bcast(&avg, 1, MPI_FLOAT, 0, MPI_COMM_WORLD);
	//printf("%f", avg);

	if (rank == size - 1) 
	{
		b = 4.0;
		c = 6.0;
		
	}


	MPI_Bcast(&b, 1, MPI_FLOAT, size - 1, MPI_COMM_WORLD);
	MPI_Bcast(&c, 1, MPI_FLOAT, size - 1, MPI_COMM_WORLD);

	MPI_Scatter(a, n / size, MPI_FLOAT, lokalniA, n / size, MPI_FLOAT, 0, MPI_COMM_WORLD);



	for (i = 0; i < n / size; i++) 
	{
		lokalSum += lokalniA[i] + avg;
	}

	MPI_Reduce(&lokalSum, &celSum, 1, MPI_FLOAT, MPI_SUM, 0, MPI_COMM_WORLD);
	MPI_Bcast(&celSum, 1, MPI_FLOAT, 0, MPI_COMM_WORLD);

	izraz = (1 / (b + c)) * celSum;
	printf("cel suma = %f\n", celSum);
	printf("rank = %d izraz = %f\n", rank, izraz);

	/*if (rank == 0) 
	{
		izraz = (1 / (b + c)) * celSum;
		printf("cel suma = %f\n", celSum);
		printf("rank = %d izraz = %f\n", rank, izraz);
	}*/

	MPI_Finalize();


	return 0;


}