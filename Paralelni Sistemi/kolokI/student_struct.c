#include <stdio.h>
#include <stdlib.h>
#include "mpi.h"

#define MAX_IME 20

typedef struct student {
    int idx;
    char ime[MAX_IME];
    char prezime[MAX_IME];
    float avg;
    int godina;
} student;

int main(int argc, char* argv[]) {
    MPI_Init(&argc, &argv);
    int rank, size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    student stud1;
    MPI_Datatype STUDENT_TYPE;

    int block_lengths[5] = { 1, MAX_IME, MAX_IME, 1, 1 };
    MPI_Aint displs[5];
    MPI_Address(&stud1.idx, &displs[0]);
    MPI_Address(&stud1.ime, &displs[1]);
    MPI_Address(&stud1.prezime, &displs[2]);
    MPI_Address(&stud1.avg, &displs[3]);
    MPI_Address(&stud1.godina, &displs[4]);
    displs[4] -= displs[0];
    displs[3] -= displs[0];
    displs[2] -= displs[0];
    displs[1] -= displs[0];
    displs[0] = 0;

    MPI_Datatype old_types[5] = { MPI_INT, MPI_CHAR, MPI_CHAR, MPI_FLOAT, MPI_INT }; 
    MPI_Type_struct(5, block_lengths, displs, old_types, &STUDENT_TYPE);
    MPI_Type_commit(&STUDENT_TYPE);

    if (rank == 0) {
        printf("index: ");
        scanf("%d", &stud1.idx);
        printf("ime: ");
        scanf("%s", &stud1.ime);
        printf("prezime: ");
        scanf("%s", &stud1.prezime);
        printf("avg: ");
        scanf("%f", &stud1.avg);
        printf("godina: ");
        scanf("%d", &stud1.godina);
    }
    MPI_Bcast(&stud1, 1, STUDENT_TYPE, 0, MPI_COMM_WORLD);

    if (rank == 3) {
        printf("%d %s %s %f %d\n", stud1.idx, stud1.ime, stud1.prezime, stud1.avg, stud1.godina);
    }

    MPI_Type_free(&STUDENT_TYPE);
    MPI_Finalize();
    return 0;
}