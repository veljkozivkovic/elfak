#include <stdio.h>
#include <stdlib.h>

#define BLOCK_SIZE 256
#define GRID_SIZE 256
int elements_per_reduction = BLOCK_SIZE * GRID_SIZE * 2;

__global__ void get_c(int* a, int* b, int* c, int* n) {
    int tid = threadIdx.x + blockIdx.x * blockDim.x;
    int N = *n;
    while (tid < N * N) {
        int row = tid / N;
        int col = tid % N;
        int b_ind = col * N + row;
        c[tid] = min(a[tid], b[b_ind]);
        tid += blockDim.x * gridDim.x;
    }
}

__host__ void get_matrix_c(int* a, int* b, int* c, int n) {
    int* dev_a, *dev_b, *dev_c, *dev_n;
    cudaMalloc((void**)&dev_a, n * n * sizeof(int));
    cudaMalloc((void**)&dev_b, (n + 1) * (n + 1) * sizeof(int));
    cudaMalloc((void**)&dev_c, n * n * sizeof(int));
    cudaMalloc((void**)&dev_n, sizeof(int));

    cudaMemcpy(dev_a, a, n * n * sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(dev_b, b, n * n * sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(dev_n, &n, sizeof(int), cudaMemcpyHostToDevice);

    get_c<<<GRID_SIZE, BLOCK_SIZE>>>(dev_a, dev_b, dev_c, dev_n);

    cudaMemcpy(c, dev_c, n * n * sizeof(int), cudaMemcpyDeviceToHost);

    cudaFree(dev_a);
    cudaFree(dev_c);
    cudaFree(dev_b);
    cudaFree(dev_n);
}

__global__ void sum_reduction(int* a, int* b) {
    __shared__ int partial_sum[BLOCK_SIZE];
    int i = threadIdx.x + blockIdx.x * blockDim.x * 2;
    partial_sum[threadIdx.x] = a[i] + a[i + blockDim.x];
    __syncthreads();

    for (int s = blockDim.x / 2; s > 0; s >>= 1) {
        if (threadIdx.x < s)
            partial_sum[threadIdx.x] += partial_sum[threadIdx.x + s];
        __syncthreads();
    }

    if (threadIdx.x == 0)
        b[blockIdx.x] = partial_sum[0];
}

__host__ int get_sum(int* a, int N) {
    int* dev_a, *dev_b;
    cudaMalloc((void**)&dev_a, elements_per_reduction * sizeof(int));
    cudaMalloc((void**)&dev_b, BLOCK_SIZE * sizeof(int));

    int s = 0;
    int reduced_sum;
    for (int i = 0; i < N; i += elements_per_reduction) {
        cudaMemcpy(dev_a, &a[i], elements_per_reduction * sizeof(int), cudaMemcpyHostToDevice);

        sum_reduction<<<GRID_SIZE, BLOCK_SIZE>>>(dev_a, dev_b);
        sum_reduction<<<1, GRID_SIZE / 2>>>(dev_b, dev_b);

        cudaMemcpy(&reduced_sum, dev_b, sizeof(int), cudaMemcpyDeviceToHost);
        s += reduced_sum;
    }

    cudaFree(dev_a);
    cudaFree(dev_b);

    return s;
}

int get_arr_len(int n) {
    if (n <= elements_per_reduction)
        return elements_per_reduction;
    int p = 1;
    while (p < n)
        p <<= 1;
    return p;
}

int main() {
    int n = 5;
    int* a = (int*)malloc(n * n * sizeof(int));
    int* b = (int*)malloc(n * n * sizeof(int));
    int* c = (int*)malloc(n * n * sizeof(int));

    for (int i = 0; i < n * n; ++i) {
        a[i] = 10 + rand() % 89;
        b[i] = 10 + rand() % 89;
    }

    get_matrix_c(a, b, c, n);

    int N = get_arr_len(n);
    float* avgs = (float*)malloc(n * sizeof(float));
    int* col = (int*)malloc(N * sizeof(int));

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            col[j] = c[j * n + i];
        }
        for (int j = n; j < N; ++j) {
            col[j] = 0;
        }
        int s = get_sum(col, N);
        avgs[i] = (float)s / n;
    }

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            printf("%5d ", c[i * n + j]);
        }
        printf("\n");
    }
    for (int i = 0; i < n; ++i) {
        printf("%5.2f ", avgs[i]);
    }

    free(a);
    free(b);
    free(c);
    free(avgs);
    free(col);

    return 0;
}