#include <stdio.h>
#include <stdlib.h>

#define BLOCK_DIM 4

__global__ void anti_aliasing_gpu(float* a, int* N) {
    __shared__ float shm[BLOCK_DIM + 2][BLOCK_DIM + 2];
    int x = threadIdx.x + blockDim.x * blockIdx.x;
    int y = threadIdx.y + blockDim.y * blockIdx.y;
    int n = *N;
    int dirs[3] = { 1, 0, -1 };

    if (x >= n || y >= n)
        return;
    
    int tid = y * n + x;
    shm[threadIdx.y + 1][threadIdx.x + 1] = a[tid];
    if (threadIdx.y == 0 && y > 0) {
        int new_element = tid - n;
        shm[threadIdx.y][threadIdx.x + 1] = a[new_element];
        if (threadIdx.x == 0 && x > 0) {
            new_element -= 1;
            shm[threadIdx.y][threadIdx.x] = a[new_element];
        }
        else if (threadIdx.x == blockDim.x && x < gridDim.x - 1) {
            new_element += 1;
            shm[threadIdx.y][threadIdx.x + 2] = a[new_element];
        }
    }
    if (threadIdx.y == blockDim.y && y < gridDim.y - 1) {
        int new_element = tid + n;
        shm[threadIdx.y + 2][threadIdx.x + 1] = a[new_element];
        if (threadIdx.x == 0 && x > 0) {
            new_element -= 1;
            shm[threadIdx.y + 2][threadIdx.x] = a[new_element];
        }
        else if (threadIdx.x == blockDim.x && x < gridDim.x - 1) {
            new_element += 1;
            shm[threadIdx.y + 2][threadIdx.x + 2] = a[new_element];
        }
    }
    if (threadIdx.x == 0 && x > 0) {
        int new_element = tid - 1;
        shm[threadIdx.y + 1][threadIdx.x] = a[new_element];
    }
    if (threadIdx.x == blockDim.x && x < gridDim.x - 1) {
        int new_element = tid + 1;
        shm[threadIdx.y + 1][threadIdx.x + 2] = a[new_element];
    }
    __syncthreads();

    float s = 0;
    int c = 0;
    for (int i = 0; i < 3; ++i) {
        for (int j = 0; j < 3; ++j) {
            int new_x = x + dirs[i];
            int new_y = y + dirs[j];
            if (new_x >= 0 && new_x < n && new_y >= 0 && new_y < n) {
                s += shm[threadIdx.y + 1 + dirs[j]][threadIdx.x + 1 + dirs[i]];
                c += 1;
            }
        }
    }
    a[tid] = s / c;
}

__host__ void anti_aliasing(float* a, int n, int k) {
    float* dev_a;
    int* dev_n;
    cudaMalloc((void**)&dev_a, n * n * sizeof(float));
    cudaMalloc((void**)&dev_n, sizeof(int));
    cudaMemcpy(dev_n, &n, sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(dev_a, a, n * n * sizeof(float), cudaMemcpyHostToDevice);

    int grid_size = n / BLOCK_DIM + 1;
    dim3 blockDim(BLOCK_DIM, BLOCK_DIM);
    dim3 gridDim(grid_size, grid_size);

    for (int i = 0; i < k; ++i) {
        anti_aliasing_gpu<<<gridDim, blockDim>>>(dev_a, dev_n);
    }
    cudaMemcpy(a, dev_a, n * n * sizeof(int), cudaMemcpyDeviceToHost);

    cudaFree(dev_a);
    cudaFree(dev_n);
}

int main() {
    int n = 6;
    float* slika = (float*)malloc(n * n * sizeof(float));
    for (int i = 0; i < n * n; ++i)
        slika[i] = rand() % 2;


    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            printf("%5.2f ", slika[i * n + j]);
        }
        printf("\n");
    }
    printf("\n---------------------------------------------\n");

    anti_aliasing(slika, n, 1);
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            printf("%5.2f ", slika[i * n + j]);
        }
        printf("\n");
    }

    free(slika);
}