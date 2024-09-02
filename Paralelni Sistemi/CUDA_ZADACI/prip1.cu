%%cuda
#include <stdio.h>

#define GRID_DIM 32
#define BLOCK_DIM 32

__global__ void kernel(int* a, int* b, int* n) {    
    __shared__ int local_a[BLOCK_DIM + 2];

    int tid = blockIdx.x * blockDim.x + threadIdx.x;
    if (tid >= n[0]) return;
    
    local_a[threadIdx.x] = a[tid];

    if (tid >= n[0] - 2) return; 

    __syncthreads();

    int temp = local_a[threadIdx.x] + local_a[threadIdx.x + 1] + local_a[threadIdx.x + 2];
    b[threadIdx.x] = temp;
}

__host__ void initAndCall(int* a, int* b, int* n) {
    int* dev_a, *dev_b, *dev_n;
    cudaMalloc((void**)&dev_a, n[0] * sizeof(int));
    cudaMalloc((void**)&dev_b, (n[0] - 2) * sizeof(int));
    cudaMalloc((void**)&dev_n, sizeof(int));
    cudaMemcpy(dev_a, a, n[0] * sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(dev_n, n, sizeof(int), cudaMemcpyHostToDevice);

    kernel<<<GRID_DIM, BLOCK_DIM>>>(dev_a, dev_b, dev_n);

    cudaMemcpy(b, dev_b, (n[0] - 2) * sizeof(int), cudaMemcpyDeviceToHost);

    cudaFree(dev_a);
    cudaFree(dev_b);
    cudaFree(dev_n);
}

int main() {
    int* a, *b, *n;

    n = (int*)malloc(sizeof(int));

    n[0] = 5 + rand() % 15;
    printf("%d:\n", n[0]); 

    a = (int*)malloc(n[0] * sizeof(int));
    b = (int*)malloc((n[0] - 2) * sizeof(int));

    for (int i = 0; i < n[0]; ++i) {
        a[i] = i;
    }

    initAndCall(a, b, n);

    for (int i = 0; i < n[0] - 2; ++i) {
        printf("%d ", b[i]);
    }
    printf("\n");

    free(a);
    free(b);
    free(n);
}