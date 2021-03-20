using System;

namespace MergeSort {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }

        static void MergeSort(int[] array) {
            int mid = array.Length / 2;
            int[] temp = new int[array.Length];

            int i = 0;//指向数组的起点
            int j = mid + 1;//指向数组中间的索引
            int k = 0;//新数组的起点
            while (i <= mid && j < array.Length) {
                if (array[i] <= array[j]) {
                    temp[k] = array[i];
                    i++;
                } else {
                    temp[k] = array[j];
                    j++;
                }
                k++;
            }

            while (i <= mid) {
                temp[k++] = array[i++];
            }

            while (j < array.Length) {
                temp[k++] = array[j++];
            }
        }

        //工具函数
        //Swap
        static void Swap(int[] array, int i, int j) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        //打印数组
        static void PrintArray(int[] array) {
            for (int i = 0; i < array.Length; i++) {
                Console.Write(array[i] + " ");
            }
        }
    }
}
