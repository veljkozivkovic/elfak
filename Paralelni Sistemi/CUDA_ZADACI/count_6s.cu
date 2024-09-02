%%cuda
#include <stdio.h>

#define n 16

__device__ int isEqualTo6(int num) {
    return num == 6;
}

__global__ void count(int* niz, int* res) {
    int tid = threadIdx.x + blockIdx.x * blockDim.x;

    while (tid < n) {
        res[tid] = isEqualTo6(niz[tid]);
        tid += blockDim.x + gridDim.x;
    }
}

int main() {
    int niz[n], res_cpu[n];
    int* dev_niz, *res;

    cudaMalloc((void**)&dev_niz, n * sizeof(int));
    cudaMalloc((void**)&res, n * sizeof(int));

    for (int i = 0; i < n; ++i) {
        niz[i] = rand() % 10;
        printf("%d ", niz[i]);
    }
    printf("\n");

    cudaMemcpy(dev_niz, niz, n * sizeof(int), cudaMemcpyHostToDevice);

    count<<<4, 4>>>(dev_niz, res);
    cudaMemcpy(res_cpu, res, n * sizeof(int), cudaMemcpyDeviceToHost);

    int s = 0;
    for (int i = 0; i < n; ++i) {
        printf("%d ", res_cpu[i]);
        s += res_cpu[i];
    }
    printf("\n6's=%d\n", s);
    

    cudaFree(dev_niz);
    cudaFree(res);
    return 0;
}