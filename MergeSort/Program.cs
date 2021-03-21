using System;

namespace MergeSort {
    class Program {
        static void Main(string[] args) {
            int[] arr = new[] { 1, 4, 7, 8, 3, 6, 9, 2, 6, 0 };
            MergeSort(arr, 0, arr.Length - 1);
            PrintArray(arr);
            Console.Read();
        }

        static void MergeSort(int[] array, int left, int right) {
            if (left >= right) {
                return;
            }
            //将数组分成两半
            //左排序
            int mid = left + (right - left) / 2;//中间值
            MergeSort(array, left, mid);
            //右排序
            MergeSort(array, mid + 1, right);

            MergeProcess(array, left, mid + 1, right);//合并起来
        }

        //一次归并步骤,假设左边和右边的数据都已经是有序的,归并的数组,左指针,右指针,右边界
        static void MergeProcess(int[] array, int leftPtr, int rightPtr, int border) {
            if (leftPtr >= rightPtr) {
                return;
            }
            int mid = rightPtr - 1;
            int[] temp = new int[border - leftPtr + 1];

            int i = leftPtr;//指向数组的起点
            int j = rightPtr;//指向数组中间的索引
            int k = 0;//新数组的起点
            while (i <= mid && j <= border) {
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

            while (j <= border) {
                temp[k++] = array[j++];
            }
            //将归并好的数据赋值回原数组
            for (int tempIndex = 0; tempIndex < temp.Length; tempIndex++) {
                array[leftPtr + tempIndex] = temp[tempIndex];
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
