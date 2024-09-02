#include <stdio.h>
#include <stdlib.h>

#define BLOCK_SIZE 4
#define GRID_SIZE 4
int len_per_reduction = BLOCK_SIZE * GRID_SIZE * 2; 

__global__ void reduction(int* a, int* b) {
    __shared__ int partial_sum[BLOCK_SIZE];

    int i = threadIdx.x + blockDim.x * blockIdx.x * 2;
    partial_sum[threadIdx.x] = a[i] + a[i + blockDim.x];
    __syncthreads();

    for (int s = blockDim.x / 2; s > 0; s >>= 1) {
        if (threadIdx.x < s) {
            partial_sum[threadIdx.x] += partial_sum[threadIdx.x + s];
        }
        __syncthreads();
    }

    if (threadIdx.x == 0)
        b[blockIdx.x] = partial_sum[0];
}

__host__ int sum_array(int* a, int* b, int* n) {
    int* dev_a, *dev_b;
    cudaMalloc((void**)&dev_a, len_per_reduction * sizeof(int));
    cudaMalloc((void**)&dev_b, len_per_reduction * sizeof(int));

    int s = 0;
    for (int i = 0; i < *n; i += len_per_reduction) {
        cudaMemcpy(dev_a, &a[i], len_per_reduction * sizeof(int), cudaMemcpyHostToDevice);

        reduction<<<GRID_SIZE, BLOCK_SIZE>>>(dev_a, dev_b);
        reduction<<<1, GRID_SIZE / 2>>>(dev_b, dev_b);

        cudaMemcpy(b, dev_b, len_per_reduction * sizeof(int), cudaMemcpyDeviceToHost);
        s += b[0];
    }

    cudaFree(dev_a);
    cudaFree(dev_b);

    return s;
}

__host__ int new_array_length(int old_len) {
    if (old_len <= len_per_reduction)
        return len_per_reduction;
    
    int p = len_per_reduction;
    while (p < old_len)
        p <<= 1;
    
    return p;
}

int main() {
    int N = 22;
    int n = new_array_length(N);
    int* a = (int*)malloc(n * sizeof(int));
    int* b = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < N; ++i)
        a[i] = 1;
    for (int i = N; i < n; ++i)
        a[i] = 0;
    
    int suma = sum_array(a, b, &n);
    printf("%d\n", suma);

    free(a);
    free(b);
}
