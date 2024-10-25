#include <stdio.h>
#include <stdlib.h>

#define BLOCK_SIZE 256
#define GRID_SIZE 256
int elements_per_reduction_kernel_call = BLOCK_SIZE * GRID_SIZE * 2;

__global__ void get_min_vector(int* a, int* b, int* c, int* n) {
    int tid = threadIdx.x + blockIdx.x * blockDim.x;

    if (tid >= *n)
        return;
    
    c[tid] = min(a[tid], b[tid]);
}

__global__ void sum_reduction(int* a, int* b) {
    __shared__ int partial_sum[BLOCK_SIZE];

    int i = threadIdx.x + blockIdx.x * blockDim.x * 2;
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

__host__ void getMatrixC(int** matrixA, int** matrixB, int** matrixC, int* n) {
    int* temp_b = (int*)malloc(*n * sizeof(int));
    int* dev_a, *dev_b, *dev_c, *dev_n;
    cudaMalloc((void**)&dev_a, *n * sizeof(int));
    cudaMalloc((void**)&dev_b, *n * sizeof(int));
    cudaMalloc((void**)&dev_c, *n * sizeof(int));
    cudaMalloc((void**)&dev_n, sizeof(int));

    for (int i = 0; i < *n; ++i) {
        for (int j = 0; j < *n; ++j)
            temp_b[j] = matrixB[j][i];
        
        int offset = 0;
        while (offset < *n) {
            int n_of_elements = offset + BLOCK_SIZE * GRID_SIZE <= *n ?
                BLOCK_SIZE * GRID_SIZE : *n - offset;
            cudaMemcpy(dev_n, &n_of_elements, sizeof(int), cudaMemcpyHostToDevice);
            cudaMemcpy(dev_a, &matrixA[i][offset], n_of_elements * sizeof(int), cudaMemcpyHostToDevice);
            cudaMemcpy(dev_b, &temp_b[offset], n_of_elements * sizeof(int), cudaMemcpyHostToDevice);

            get_min_vector<<<GRID_SIZE, BLOCK_SIZE>>>(dev_a, dev_b, dev_c, dev_n);
            cudaMemcpy(&matrixC[i][offset], dev_c, n_of_elements * sizeof(int), cudaMemcpyDeviceToHost);

            offset += n_of_elements;
        }
    }

    free(temp_b);
    cudaFree(dev_a);
    cudaFree(dev_b);
    cudaFree(dev_c);
    cudaFree(dev_n);
}

__host__ int get_avg(int* a, int n) {
    int* dev_a, *dev_b;
    cudaMalloc((void**)&dev_a, elements_per_reduction_kernel_call * sizeof(int));
    cudaMalloc((void**)&dev_b, GRID_SIZE * sizeof(int));
    int partial_sum;
    int s = 0;
    for (int i = 0; i < n; i += elements_per_reduction_kernel_call) {
        cudaMemcpy(dev_a, &a[i], elements_per_reduction_kernel_call * sizeof(int), cudaMemcpyHostToDevice);
        
        sum_reduction<<<GRID_SIZE, BLOCK_SIZE>>>(dev_a, dev_b);
        sum_reduction<<<1, GRID_SIZE / 2>>>(dev_b, dev_b);

        cudaMemcpy(&partial_sum, dev_b, sizeof(int), cudaMemcpyDeviceToHost);
        s += partial_sum;
    }

    cudaFree(dev_a);
    cudaFree(dev_b);
    return s / n;
}

int get_arr_len(int N) {
    if (N < elements_per_reduction_kernel_call)
        return elements_per_reduction_kernel_call;
    
    int p = elements_per_reduction_kernel_call;
    while (p < N)
        p <<= 1;
    
    return p;
}

int main() {
    int n = 555;

    int* a = (int*)malloc(n * n * sizeof(int));
    int* b = (int*)malloc(n * n * sizeof(int));
    int* c = (int*)malloc(n * n * sizeof(int));
    int** matrixA = (int**)malloc(n * sizeof(int*));
    int** matrixB = (int**)malloc(n * sizeof(int*));
    int** matrixC = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; ++i) {
        matrixA[i] = &a[i * n];
        matrixB[i] = &b[i * n];
        matrixC[i] = &c[i * n];
    }

    for(int i = 0; i < n * n; ++i) {
        a[i] = rand() % 20;
        b[i] = rand() % 20;
    }

    getMatrixC(matrixA, matrixB, matrixC, &n);

    // for (int i = 0; i < n * n; ++i) {
    //     printf("%2d ", a[i]);
    // }
    // printf("\n");
    // for (int i = 0; i < n; ++i) {
    //     for (int j = 0; j < n; ++j) {
    //         printf("%2d ", b[j * n + i]);
    //     }
    // }
    // printf("\n");
    // for (int i = 0; i < n * n; ++i) {
    //     printf("%2d ", c[i]);
    // }
    // printf("\n");
    int N = get_arr_len(n);
    int* elements = (int*)malloc(N * sizeof(int));
    int* avg_arr = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j)
            elements[j] = matrixC[j][i];
        for (int j = n; j < N; ++j)
            elements[j] = 0;
        avg_arr[i] = get_avg(elements, n);
    }
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            printf("%2d ", matrixC[i][j]);
        }
        printf("\n");
    }
    printf("---------------------------------------------------------------------\n");
    for (int i = 0; i < n; ++i)
        printf("%2d ", avg_arr[i]);
    printf("\n");

    free(a);
    free(b);
    free(c);
    free(matrixA);
    free(matrixB);
    free(matrixC);
    free(elements);
    free(avg_arr);
}