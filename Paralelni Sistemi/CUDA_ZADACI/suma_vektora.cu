%%cuda
#include <stdio.h>

#define n 155

__global__ void add(int* a, int* b, int* c) {
    int tid = threadIdx.x + blockIdx.x * blockDim.x;

    while (tid < n) {
        c[tid] = a[tid] + b[tid];
        tid += gridDim.x * blockDim.x;
    }
}

int main() {
    int a[n], b[n], c[n];
    int* dev_a, *dev_b, *dev_c;

    cudaMalloc((void**)&dev_a, n * sizeof(int));
    cudaMalloc((void**)&dev_b, n * sizeof(int));
    cudaMalloc((void**)&dev_c, n * sizeof(int));

    for (int i = 0; i < n; ++i) {
        a[i] = i;
        b[i] = i;
    }

    cudaMemcpy(dev_a, a, n * sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(dev_b, b, n * sizeof(int), cudaMemcpyHostToDevice);

    add<<<1, 15>>>(dev_a, dev_b, dev_c);

    cudaMemcpy(c, dev_c, n * sizeof(int), cudaMemcpyDeviceToHost);

    for (int i = 0; i < n; ++i) {
        printf("%d ", c[i]);
    }
    printf("\n");

    cudaFree(dev_a);
    cudaFree(dev_b);
    cudaFree(dev_c);

    return 0;
}