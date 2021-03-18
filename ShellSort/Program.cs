using System;

namespace ShellSort {
    class Program {
        static void Main(string[] args) {
            int[] array = { 6, 3, 1, 4, 2, 9, 7, 11, 8, 5 };
            InsertionSort(array);
            PrintArray(array);
            Console.ReadLine();
        }

        public static void ShellSort(int[] array) {
            //先按照间隔进行排序
            int gap = 4;
            for (int i = gap; i < array.Length; i++) { //i从1开始,默认第一个元素是有序的,以第一个元素为基准进行比较插入
                for (int j = i; j > gap - 1; j -= gap) {
                    if (array[j] < array[j - gap]) {
                        Swap(array, j, j - gap);
                    }
                }
            }
        }

        //普通的插入排序
        public static void InsertionSort(int[] array) {
            for (int i = 1; i < array.Length; i++) { //i从1开始,默认第一个元素是有序的,以第一个元素为基准进行比较插入
                for (int j = i; j > 0; j--) {
                    if (array[j] < array[j - 1]) {
                        Swap(array, j, j - 1);
                    }
                }
            }
        }

        //工具函数
        static void PrintArray(int[] array) {
            for (int i = 0; i < array.Length; i++) {
                Console.Write(array[i] + " ");
            }
        }
        static void Swap(int[] array, int i, int j) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
