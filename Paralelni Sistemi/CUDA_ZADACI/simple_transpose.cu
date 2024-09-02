%%cuda
#include <stdio.h>

#define n 8

__global__ void transpose(int* mat1, int* matT) {
    int xIndex = blockIdx.x * blockDim.x + threadIdx.x;
    int yIndex = blockIdx.y * blockDim.y + threadIdx.y;

    if (xIndex < n && yIndex < n) {
        int index_in = xIndex + n * yIndex;
        int index_out = yIndex + n * xIndex;
        matT[index_out] = mat1[index_in];
    }

}

int main() {
    int mat[n][n], matT[n][n];
    int* dev_mat, *dev_matT;

    cudaMalloc((void**)&dev_mat, n * n * sizeof(int));
    cudaMalloc((void**)&dev_matT, n * n * sizeof(int));

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            mat[i][j] = i * n + j;
        }
    }

    cudaMemcpy(dev_mat, mat, n * n * sizeof(int), cudaMemcpyHostToDevice);

    dim3 gridDef2(2, 2, 1);
    dim3 blockDef2(4, 4, 1);

    transpose<<<gridDef2, blockDef2>>>(dev_mat, dev_matT);
    cudaMemcpy(matT, dev_matT, n * n * sizeof(int), cudaMemcpyDeviceToHost);

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            printf("%d ", matT[i][j]);
        }
        printf("\n");
    }

    cudaFree(dev_mat);
    cudaFree(dev_matT);
}