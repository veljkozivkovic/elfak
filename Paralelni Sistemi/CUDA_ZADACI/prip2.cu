%%cuda
#include <stdio.h>

#define BLOCK_SIZE 128
#define GRID_SIZE 128

__global__ void kernel(int* A, int* b, int* n) {
    int tid = threadIdx.x + blockIdx.x * blockDim.x;

    if (tid >= n[0])
        return;

    int s = 0;
    for (int i = 0; i < n[0]; ++i) {
        s += A[tid + i * n[0]];
    }
    b[tid] = s;
}

__host__ void initAndCall(int* A, int* b, int* n) {
    int* dev_a, *dev_b, *dev_n;
    cudaMalloc((void**)&dev_a, n[0] * n[0] * sizeof(int));
    cudaMalloc((void**)&dev_b, n[0] * sizeof(int));
    cudaMalloc((void**)&dev_n, sizeof(int));
    cudaMemcpy(dev_a, A, n[0] * n[0] * sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(dev_n, n, sizeof(int), cudaMemcpyHostToDevice);

    kernel<<<GRID_SIZE, BLOCK_SIZE>>>(dev_a, dev_b, dev_n);

    cudaMemcpy(b, dev_b, n[0] * sizeof(int), cudaMemcpyDeviceToHost);

    cudaFree(dev_a);
    cudaFree(dev_b);
    cudaFree(dev_n);
}

int main() {
    int* n = (int*)malloc(sizeof(int));

    n[0] = 10;
    printf("%d\n", n[0]);

    int* A, *b;
    A = (int*)malloc(n[0] * n[0] * sizeof(int));
    b = (int*)malloc(n[0] * sizeof(int));

    int c = 0;
    for (int i = 0; i < n[0]; ++i) {
        for (int j = 0; j < n[0]; ++j) {
            A[i * n[0] + j] = i * n[0] + j;
        }
    }


    initAndCall(A, b, n);
    for (int i = 0; i < n[0]; ++i) {
        for (int j = 0; j < n[0]; ++j) {
            printf("%4d ", A[i * n[0] + j]);
        }
        printf("\n");
    }

    for (int i = 0; i < n[0]; ++i) {
        printf("%4d ", b[i]);
    }
    printf("\n");

    return 0;
}