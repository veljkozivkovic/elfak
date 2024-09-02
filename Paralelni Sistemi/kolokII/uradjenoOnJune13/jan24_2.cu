#include <stdio.h>
#include <stdlib.h>

#define BLOCK_SIZE 8

typedef struct Tacka {
    float x;
    float y;
    int index;
} Tacka;

__device__ float distance(Tacka t1, Tacka t2) {
    return sqrtf(powf(t1.x - t2.x, 2) + powf(t1.y - t2.y, 2));
}

__global__ void min_reduction(Tacka* a, Tacka* b, Tacka* ref_tacka) {
    __shared__ Tacka tacke[BLOCK_SIZE];
    Tacka ref = *ref_tacka;
    int i = threadIdx.x + blockIdx.x * blockDim.x * 2;
    if (distance(a[i], ref) < distance(a[i + blockDim.x], ref))
        tacke[threadIdx.x] = a[i];
    else
        tacke[threadIdx.x] = a[i + blockDim.x];
    __syncthreads();

    for (int s = blockDim.x / 2; s > 0; s >>= 1) {
        if (threadIdx.x < s && 
            distance(tacke[threadIdx.x + s], ref) < distance(tacke[threadIdx.x], ref))
            tacke[threadIdx.x] = tacke[threadIdx.x + s];
        __syncthreads();
    }

    if (threadIdx.x == 0)
        b[blockIdx.x] = tacke[0];
}

__host__ void get_10_min(Tacka* tacke, int n) {
    int grid_size = n / BLOCK_SIZE / 2;
    Tacka* dev_a, *dev_b, *ref_tacka;
    cudaMalloc((void**)&dev_a, n * sizeof(Tacka));
    cudaMalloc((void**)&dev_b, n * sizeof(Tacka));
    cudaMalloc((void**)&ref_tacka, sizeof(Tacka));
    cudaMemcpy(ref_tacka, tacke, sizeof(Tacka), cudaMemcpyHostToDevice);
    Tacka reduced_tacka;

    for (int i = 1; i < 11; ++i) {
        cudaMemcpy(dev_a, &tacke[i], n * sizeof(Tacka), cudaMemcpyHostToDevice);

        min_reduction<<<grid_size, BLOCK_SIZE>>>(dev_a, dev_b, ref_tacka);
        min_reduction<<<1, grid_size / 2>>>(dev_b, dev_b, ref_tacka);

        cudaMemcpy(&reduced_tacka, dev_b, sizeof(Tacka), cudaMemcpyDeviceToHost);

        tacke[reduced_tacka.index] = tacke[i];
        tacke[reduced_tacka.index].index = reduced_tacka.index;
        tacke[i] = reduced_tacka;
        tacke[i].index = i;
    }

    cudaFree(dev_a);
    cudaFree(dev_b);
    cudaFree(ref_tacka);
}

int get_arr_len(int n) {
    if (n <= 4 * BLOCK_SIZE)
        return 4 * BLOCK_SIZE;
    int p = 1;
    while (p < n)
        p <<= 1;
    return p;
}

int main() {
    int n = 25;
    int N = get_arr_len(n);

    Tacka* tacke = (Tacka*)malloc((N + 12) * sizeof(Tacka));
    for (int i = 0; i < n; ++i) {
        tacke[i].x = i;
        tacke[i].y = i;
        tacke[i].index = i;
    }
    for (int i = n; i < N + 12; ++i) {
        tacke[i].x = sqrtf(INT_MAX) - 1;
        tacke[i].y = sqrtf(INT_MAX) - 1;
        tacke[i].index = i;
    }
    get_10_min(tacke, N);
    for (int i = 1; i < 11; ++i) {
        printf("%5.2f %5.2f\n", tacke[i].x, tacke[i].y);
    }

    free(tacke);
}