#include <stdio.h>
#include <stdlib.h>

#define BLOCK_SIZE 256
#define GRID_SIZE 256
int elements_per_reduction = BLOCK_SIZE * GRID_SIZE * 2;

__global__ void min_reduction(int* a, int* b) {
    __shared__ int partial_min[BLOCK_SIZE];

    int i = threadIdx.x + blockDim.x * blockIdx.x * 2;
    partial_min[threadIdx.x] = min(a[i], a[i + blockDim.x]);

    __syncthreads();
    for (int s = blockDim.x / 2; s > 0; s >>= 1) {
        if (threadIdx.x < s) {
            partial_min[threadIdx.x] = min(partial_min[threadIdx.x], partial_min[threadIdx.x + s]);
        }
        __syncthreads();
    }

    if (threadIdx.x == 0)
        b[blockIdx.x] = partial_min[0];
}

__host__ int get_min(int* a, int n) {
    int* dev_a, *dev_b;
    cudaMalloc((void**)&dev_a, elements_per_reduction * sizeof(int));
    cudaMalloc((void**)&dev_b, GRID_SIZE * sizeof(int));

    int s = INT_MAX;
    int reduced_min;
    for (int i = 0; i < n; i += elements_per_reduction) {
        cudaMemcpy(dev_a, &a[i], elements_per_reduction * sizeof(int), cudaMemcpyHostToDevice);

        min_reduction<<<GRID_SIZE, BLOCK_SIZE>>>(dev_a, dev_b);
        min_reduction<<<1, GRID_SIZE / 2>>>(dev_b, dev_b);

        cudaMemcpy(&reduced_min, dev_b, sizeof(int), cudaMemcpyDeviceToHost);
        s = min(s, reduced_min);
    }

    cudaFree(dev_a);
    cudaFree(dev_b);

    return s;
}

__host__ int get_new_len(int old_len) {
    if (old_len <= elements_per_reduction)
        return elements_per_reduction;

    int p = elements_per_reduction;
    while (p < old_len)
        p <<= 1;

    return p;
}

int main() {
    int N = 720;
    
    int* matrix = (int*)malloc(N * N * sizeof(int));
    for (int i = 0; i < N * N; ++i)
        matrix[i] = rand();

    int n = get_new_len(N);
    int* a = (int*)malloc(n * sizeof(int));

    int true_min = INT_MAX;
    for (int i = 0; i < N; ++i) {
        a[i] = matrix[i * N + i];
        true_min = min(true_min, a[i]);
    }
    for (int i = N; i < n; ++i) {
        a[i] = INT_MAX;
    }

    int reduced_min = get_min(a, n);

    printf("%d == %d\n", true_min, reduced_min);

    free(a);
    free(matrix);
}