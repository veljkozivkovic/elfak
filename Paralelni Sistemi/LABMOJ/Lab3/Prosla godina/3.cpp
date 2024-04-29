#include <iostream>
#include "mpi.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <iomanip>
#include <algorithm>
using namespace std;

#define n 4
#define m 3
#define v 27
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

    int broj = size / 3;
    int* vrsta = new int[broj];

    int* includeList = new int[broj];
    
    MPI_Group cela, trojke;

    MPI_Comm_group(MPI_COMM_WORLD, &cela);

    int brojac = 0;
    for (int i = 0; i < size; i++)
    {
        if (i % 3 == 0)
            includeList[brojac++] = i;
    }

    MPI_Group_incl(cela, broj, includeList, &trojke);

    int rankTro;
    MPI_Comm tri;
    MPI_Comm_create(MPI_COMM_WORLD, trojke, &tri);

    if (inArray(includeList, broj, rank))
    {
        MPI_Comm_rank(tri, &rankTro);
        cout << " ja sam u novi comm, rank iz stari: " << rank << " rank iz novi: " << rankTro << endl;


        MPI_Barrier(tri);
        if (!rankTro)
        {
            int** A = new int* [broj];
            for (int i = 0; i < broj; i++) {
                A[i] = new int[broj];
            }

            // Popunjavanje matrice vrednostima od 1 do krajnjegBroj
            int brojac = 1;
            for (int i = 0; i < broj; i++) {
                for (int j = 0; j < broj; j++) {
                    A[i][j] = brojac++;
                }
            }

            cout << " ja sam nulti proc u novi comm, matrica je: " << endl;
            for (int i = 0; i < broj; i++)
            {
                for (int j = 0; j < broj; j++)
                {
                    cout << setw(5) << right << A[i][j];
                }
                cout << endl;
            }
            cout << "=======================================" << endl;

            for (int i = 0; i < broj; i++)
            {
                vrsta[i] = A[0][i];
            }


            for (int i = 1; i < broj; i++)
            {
                MPI_Send(&A[i][0], broj, MPI_INT, i, 69, tri);
            }

        }

        else
        {
            MPI_Recv(vrsta, broj, MPI_INT, 0, 69, tri, &stat);
            
        }

        int sum = 0;
        for (int i = 0; i < broj; i++)
        {
            sum += vrsta[i];
        }
        if (sum > v)
        {
            cout << "ja sam " << rank << " (stari rank), " << rankTro << " (novi rank) i suma mi veca i jednaka" << sum << endl;
        }



    }



    

    




    delete[] includeList;
    MPI_Finalize();
    return 0;
}