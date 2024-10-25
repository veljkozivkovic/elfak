#include <stdio.h>
#include <stdlib.h>

#define BLOCK_SIZE 8

typedef struct Tacka {
    int x;
    int y;
    int index;
} Tacka;

__device__ float distance(Tacka t1, Tacka t2) {
    return sqrtf(powf(t1.x - t2.x, 2) + powf(t1.y - t2.y, 2));
}

__global__ void min_reduction(Tacka* a, Tacka* b, Tacka* ref_tacka) {
    __shared__ Tacka partial_min[BLOCK_SIZE];

    int i = threadIdx.x + blockIdx.x * blockDim.x * 2;

    if (distance(a[i], *ref_tacka) < distance(a[i + blockDim.x], *ref_tacka))
        partial_min[threadIdx.x] = a[i];
    else
        partial_min[threadIdx.x] = a[i + blockDim.x];

    __syncthreads();

    for (int s = blockDim.x / 2; s > 0; s >>= 1) {
        if (threadIdx.x < s) {
            if (distance(partial_min[threadIdx.x], *ref_tacka) > distance(partial_min[threadIdx.x + s], *ref_tacka))
                partial_min[threadIdx.x] = partial_min[threadIdx.x + s];
        }
        __syncthreads();
    }

    if (threadIdx.x == 0)
        b[blockIdx.x] = partial_min[0];
}

__host__ void get_mins(Tacka* a, int n) {
    int grid_size = n / BLOCK_SIZE / 2;

    Tacka* dev_a, *dev_b, *ref_tacka;
    cudaMalloc((void**)&dev_a, n * sizeof(Tacka));
    cudaMalloc((void**)&dev_b, grid_size * sizeof(Tacka));
    cudaMalloc((void**)&ref_tacka, sizeof(Tacka));
    cudaMemcpy(ref_tacka, a, sizeof(Tacka), cudaMemcpyHostToDevice);
    Tacka min_tacka;

    for (int i = 1; i < 11; ++i) {
        cudaMemcpy(dev_a, &a[i], n * sizeof(Tacka), cudaMemcpyHostToDevice);
        min_reduction<<<grid_size, BLOCK_SIZE>>>(dev_a, dev_b, ref_tacka);
        min_reduction<<<1, grid_size / 2>>>(dev_b, dev_b, ref_tacka);
        cudaMemcpy(&min_tacka, dev_b, sizeof(Tacka), cudaMemcpyDeviceToHost);

        // printf("%d %d %d\n", min_tacka.x, min_tacka.y, min_tacka.index);
        a[min_tacka.index] = a[i];
        a[min_tacka.index].index = min_tacka.index;
        a[i] = min_tacka;
        a[i].index = i;
    }

    cudaFree(dev_a);
    cudaFree(dev_b);
    cudaFree(ref_tacka);
}

int get_new_size(int n) {
    if (n < 2 * BLOCK_SIZE)
        return 2 * BLOCK_SIZE;
    
    int p = 2 * BLOCK_SIZE;
    while (p < n)
        p <<= 1;
    
    return p;
}

int main() {
    int N = 25;

    int n = get_new_size(N);

    Tacka* tacke = (Tacka*)malloc((n + 12) * sizeof(Tacka));
    for (int i = 0; i < N; ++i) {
        tacke[i].x = i;
        tacke[i].y = i;
        tacke[i].index = i;
    }
    for (int i = N; i < n + 12; ++i) {
        tacke[i].x = sqrt(INT_MAX) - 1;
        tacke[i].y = sqrt(INT_MAX) - 1;
        tacke[i].index = i;
    }
    tacke[0].x = tacke[N - 1].x + 1;
    tacke[0].y = tacke[N - 1].y + 1;

    get_mins(tacke, n);
    for (int i = 1; i < 11; ++i) {
        printf("%d %d\n", tacke[i].x, tacke[i].y);
    }

    free(tacke);
}