#include <stdio.h>
#include <stdlib.h>

#define BLOCK_SIZE 256
#define GRID_SIZE 256
int elements_per_reduction = BLOCK_SIZE * GRID_SIZE * 2;

__global__ void min_reduction(int* a, int* b) {
    __shared__ int partial_min[BLOCK_SIZE];
    int i = threadIdx.x + blockIdx.x * blockDim.x * 2;
    partial_min[threadIdx.x] = min(a[i], a[i + blockDim.x]);
    __syncthreads();

    for (int s = blockDim.x / 2; s > 0; s >>= 1) {
        if (threadIdx.x < s)
            partial_min[threadIdx.x] = min(partial_min[threadIdx.x], partial_min[threadIdx.x + s]);
        __syncthreads();
    }

    if (threadIdx.x == 0)
        b[blockIdx.x] = partial_min[0];
}

__host__ int get_min(int* a, int N) {
    int* dev_a, *dev_b;
    cudaMalloc((void**)&dev_a, elements_per_reduction * sizeof(int));
    cudaMalloc((void**)&dev_b, BLOCK_SIZE * sizeof(int));

    int reduced_min;
    int min_ = INT_MAX;
    for (int i = 0; i < N; i += elements_per_reduction) {
        cudaMemcpy(dev_a, &a[i], elements_per_reduction * sizeof(int), cudaMemcpyHostToDevice);

        min_reduction<<<GRID_SIZE, BLOCK_SIZE>>>(dev_a, dev_b);
        min_reduction<<<1, GRID_SIZE / 2>>>(dev_b, dev_b);

        cudaMemcpy(&reduced_min, dev_b, sizeof(int), cudaMemcpyDeviceToHost);
        min_ = min(reduced_min, min_);
    }

    cudaFree(dev_a);
    cudaFree(dev_b);

    return min_;
}

int get_arr_len(int n) {
    if (n <= elements_per_reduction)
        return elements_per_reduction;
    int p = 1;
    while (p < n) {
        p <<= 1;
    }
    return p;
}

int main() {
    int n = 25;

    int* matrix = (int*)malloc(n * n * sizeof(int));
    int actual_min = INT_MAX;

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            matrix[i * n + j] = rand();
            if (i == j) actual_min = min(actual_min, matrix[i * n + j]);
        }
    }

    int N = get_arr_len(n);
    int* diag = (int*)malloc(N * sizeof(int));
    for (int i = 0; i < n; ++i)
        diag[i] = matrix[i * n + i];
    for (int i = n; i < N; ++i)
        diag[i] = INT_MAX;
    
    int reduced_min = get_min(diag, N);
    printf("%d == %d\n", actual_min, reduced_min);

    free(matrix);
    free(diag);
}