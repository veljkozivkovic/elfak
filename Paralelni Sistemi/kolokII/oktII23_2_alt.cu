#include <stdio.h>
#include <stdlib.h>

#define BLOCK_SIZE 256
#define GRID_SIZE 256
int elements_per_reduction = BLOCK_SIZE * GRID_SIZE * 2;

__global__ void get_new_arr(int* a, int* b, int* c, int* n) {
    int tid_a = threadIdx.x + blockIdx.x * blockDim.x;

    while (tid_a < *n * *n) {
        int row = tid_a / *n;
        int col = tid_a % *n;
        int tid_b = col * *n + row;
        
        c[tid_a] = min(a[tid_a], b[tid_b]);
        tid_a += blockDim.x * gridDim.x;
    }    
}

__host__ void get_matrix_c(int* a, int* b, int* c, int* n) {
    int* dev_a, *dev_b, *dev_c, *dev_n;
    cudaMalloc((void**)&dev_a, *n * *n * sizeof(int));
    cudaMalloc((void**)&dev_b, (*n * *n + 1) * sizeof(int));
    cudaMalloc((void**)&dev_c, *n * *n * sizeof(int));
    cudaMalloc((void**)&dev_n, sizeof(int));

    cudaMemcpy(dev_a, a, *n * *n * sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(dev_b, b, *n * *n * sizeof(int), cudaMemcpyHostToDevice);
    cudaMemcpy(dev_n, n, sizeof(int), cudaMemcpyHostToDevice);

    get_new_arr<<<GRID_SIZE, BLOCK_SIZE>>>(dev_a, dev_b, dev_c, dev_n);
    cudaMemcpy(c, dev_c, *n * *n * sizeof(int), cudaMemcpyDeviceToHost);

    cudaFree(dev_a);
    cudaFree(dev_b);
    cudaFree(dev_c);
    cudaFree(dev_n);
}

__global__ void sum_reduction(int* a, int* b) {
    __shared__ int partial_sum[BLOCK_SIZE];

    int i = threadIdx.x + blockDim.x * blockIdx.x * 2;
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

__host__ void get_col_avgs(int* c, int* arr, int new_n, int old_n) {
    int* dev_a, *dev_b;
    cudaMalloc((void**)&dev_a, elements_per_reduction * sizeof(int));
    cudaMalloc((void**)&dev_b, GRID_SIZE * sizeof(int));
    int s;

    int* temp = (int*)malloc(new_n * sizeof(int));
    for (int i = old_n; i < new_n; ++i)
        temp[i] = 0;
    
    for (int i = 0; i < old_n; ++i) {
        arr[i] = 0;
        for (int j = 0; j < old_n; ++j) {
            temp[j] = c[j * old_n + i];
        }
        for (int j = 0; j < new_n; j += elements_per_reduction) {
            cudaMemcpy(dev_a, &temp[j], elements_per_reduction * sizeof(int), cudaMemcpyHostToDevice);

            sum_reduction<<<BLOCK_SIZE, GRID_SIZE>>>(dev_a, dev_b);
            sum_reduction<<<1, GRID_SIZE / 2>>>(dev_b, dev_b);

            cudaMemcpy(&s, dev_b, sizeof(int), cudaMemcpyDeviceToHost);
            arr[i] += s;
        }
    }

    free(temp);
    cudaFree(dev_a);
    cudaFree(dev_b);
}

int get_arr_size(int n) {
    if (n <= elements_per_reduction)
        return elements_per_reduction;
    int p = elements_per_reduction;
    while (p < n)
        p <<= 1;
    return p;
}

int main() {
    int N = 5;
    // scanf("%d", &N);
    int* a = (int*)malloc(N * N * sizeof(int));
    int* b = (int*)malloc(N * N * sizeof(int));
    int* c = (int*)malloc(N * N * sizeof(int));

    for (int i = 0; i < N * N; ++i) {
        a[i] = rand() % 50;
        b[i] = rand() % 50;
    }

    get_matrix_c(a, b, c, &N);
    int n = get_arr_size(N);
    int* avg_c = (int*)malloc(n * sizeof(int));
    get_col_avgs(c, avg_c, n, N);

    for (int i = 0; i < N; ++i) {
        for (int j = 0; j < N; ++j) {
            printf("%4d ", c[i * N + j]);
        }
        printf("\n");
    }
    for (int i = 0; i < N; ++i)
        printf("%4d ", avg_c[i]);
    printf("\n");

    free(a);
    free(b);
    free(c);
    free(avg_c);
}