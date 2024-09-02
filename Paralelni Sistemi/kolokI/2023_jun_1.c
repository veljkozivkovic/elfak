#include <stdio.h>
#include <stdlib.h>
#include "mpi.h"

#define MAX_LEN 20

typedef struct Zaposleni {
    int id;
    char ime[MAX_LEN];
    char prezime[MAX_LEN];
    float avg;
} Zaposleni;

int main(int argc, char* argv[]) {
    MPI_Init(&argc, &argv);
    int rank, size;
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);


    int n;
    if (rank == 0) {
        scanf("%d", &n);
    }
    MPI_Bcast(&n, 1, MPI_INT, 0, MPI_COMM_WORLD);
    Zaposleni* svi_zaposleni = (Zaposleni*)malloc(n * sizeof(Zaposleni));
    Zaposleni* moji_zaposleni = (Zaposleni*)malloc(n / size * sizeof(Zaposleni));

    MPI_Datatype ZAPOSLENI_DTYPE;
    int array_of_blocklengths[4] = {1, MAX_LEN, MAX_LEN, 1};
    MPI_Aint array_of_displacements[4];
    MPI_Address(&svi_zaposleni[0].id, &array_of_displacements[0]);
    MPI_Address(&svi_zaposleni[0].ime, &array_of_displacements[1]);
    MPI_Address(&svi_zaposleni[0].prezime, &array_of_displacements[2]);
    MPI_Address(&svi_zaposleni[0].avg, &array_of_displacements[3]);

    array_of_displacements[1] = array_of_displacements[1] - array_of_displacements[0];
    array_of_displacements[2] = array_of_displacements[2] - array_of_displacements[0];
    array_of_displacements[3] = array_of_displacements[3] - array_of_displacements[0];
    array_of_displacements[0] = 0;

    MPI_Datatype array_of_types[4] = { MPI_INT, MPI_CHAR, MPI_CHAR, MPI_FLOAT};
    MPI_Type_struct(4, array_of_blocklengths, array_of_displacements, array_of_types, &ZAPOSLENI_DTYPE);
    MPI_Type_commit(&ZAPOSLENI_DTYPE);

    if (rank == 0) {
        int i = 0;
        while (i < n) {
            scanf("%d %s %s %f", &svi_zaposleni[i].id, &svi_zaposleni[i].ime, &svi_zaposleni[i].prezime, &svi_zaposleni[i].avg);
            i += 1;
        }
    }
    MPI_Scatter(svi_zaposleni, n / size, ZAPOSLENI_DTYPE, moji_zaposleni, n / size, ZAPOSLENI_DTYPE, 0, MPI_COMM_WORLD);

    struct { float zappl; int rank; } minzap, totalminzap;
    minzap.zappl = moji_zaposleni[0].avg;
    minzap.rank = rank;

    MPI_Reduce(&minzap, &totalminzap, 1, MPI_FLOAT_INT, MPI_MINLOC, 0, MPI_COMM_WORLD);
    if (rank == 0) {
        printf("%fd\n", totalminzap.zappl);
        for (int i = 0; i < n; ++i) {
            if (svi_zaposleni[i].avg == totalminzap.zappl) {
                printf("%d %f\n", svi_zaposleni[i].id, svi_zaposleni[i].avg);
                break;
            }
        }
    }


    MPI_Type_free(&ZAPOSLENI_DTYPE);
    MPI_Finalize();
    return 0;
}