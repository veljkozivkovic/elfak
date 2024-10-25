#include <stdio.h>
#include <stdlib.h>

#define BLOCK_DIM 4

__global__ void kernel(int* a, float* b, int* n) {
    __shared__ int shared_mem[BLOCK_DIM + 2][BLOCK_DIM + 2];
    int x = threadIdx.x + blockDim.x * blockIdx.x;
    int y = threadIdx.y + blockDim.y * blockIdx.y;
    int tid = y * *n + x;
    int dir[3] = {1, 0, -1};

    if (x >= *n || y >= *n)
        return;

    shared_mem[threadIdx.y + 1][threadIdx.x + 1] = a[tid];
    if (threadIdx.y == 0 && y > 0) {
        int new_element = tid - *n;
        shared_mem[threadIdx.y][threadIdx.x + 1] = a[new_element];
        if (threadIdx.x == 0 && x > 0) {
            new_element -= 1;
            shared_mem[threadIdx.y][threadIdx.x] = a[new_element];
        }
        if (threadIdx.x == blockDim.x - 1 && x < gridDim.x - 1) {
            new_element += 1;
            shared_mem[threadIdx.y][threadIdx.x + 2] = a[new_element];
        }
    }
    if (threadIdx.y == blockDim.y - 1 && y < gridDim.y - 1) {
        int new_element = tid + *n;
        shared_mem[threadIdx.y + 2][threadIdx.x + 1] = a[new_element];
        if (threadIdx.x == 0 && x > 0) {
            new_element -= 1;
            shared_mem[threadIdx.y + 2][threadIdx.x] = a[new_element];
        }
        if (threadIdx.x == blockDim.x - 1 && x < gridDim.x - 1) {
            new_element += 1;
            shared_mem[threadIdx.y + 2][threadIdx.x + 2] = a[new_element];
        }
    }
    if (threadIdx.x == 0 && x > 0) {
        int new_element = tid - 1;
        shared_mem[threadIdx.y + 1][threadIdx.x] = a[new_element];
    }
    if (threadIdx.x == blockDim.x - 1 && x < gridDim.x - 1) {
        int new_element = tid + 1;
        shared_mem[threadIdx.y + 1][threadIdx.x + 2] = a[new_element];
    }

    __syncthreads();

    int s = 0;
    int c = 0;
    for (int i = 0; i < 3; ++i) {
        for (int j = 0; j < 3; ++j) {
            int new_y = y + dir[i];
            int new_x = x + dir[j];
            if (new_y >= 0 && new_y < *n && new_x >= 0 && new_x < *n) {
                s += shared_mem[threadIdx.y + 1 + dir[i]][threadIdx.x + 1 + dir[j]];
                c += 1;
            }
        }
    }
    b[tid] = (float)s / c;
}

__host__ void initAndCall(int* a, float* b, int n) {
    int* dev_a, *dev_n;
    float* dev_b;
    cudaMalloc((void**)&dev_a, n * n * sizeof(int));
    cudaMalloc((void**)&dev_b, n * n * sizeof(float));
    cudaMalloc((void**)&dev_n, sizeof(int));
    cudaMemcpy(dev_a, a, n * n * sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(dev_n, &n, sizeof(int), cudaMemcpyHostToDevice);

    dim3 blockDim(BLOCK_DIM, BLOCK_DIM);
    dim3 gridDim(n / BLOCK_DIM + 1, n / BLOCK_DIM + 1);

    kernel<<<gridDim, blockDim>>>(dev_a, dev_b, dev_n);

    cudaMemcpy(b, dev_b, n * n * sizeof(float), cudaMemcpyDeviceToHost);

    cudaFree(dev_a);
    cudaFree(dev_b);
    cudaFree(dev_n);
}

int main() {
    int n = 5;
    int* a = (int*)malloc(n * n * sizeof(int));
    float* b = (float*)malloc(n * n * sizeof(float));

    for (int i = 0; i < n * n; ++i)
        a[i] = rand() % 2;

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j)
            printf("%d ", a[i * n + j]);
        printf("\n");
    }
    
    initAndCall(a, b, n);

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j)
            printf("%3.2f ", b[i * n + j]);
        printf("\n");
    }

    free(a);
    free(b);
}