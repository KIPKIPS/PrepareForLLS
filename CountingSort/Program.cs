using System;

namespace CountingSort {
    //计数排序
    class Program {
        static void Main(string[] args) {
            int[] array = { 1, 5, 2, 3, 8, 7, 9, 6, 6, 1, 6, 8, 9, 2 };
            int[] result = CountSort(array);
            PrintArray(result);
            Console.Read();
        }

        //计数排序适用于数据量大,但是范围有限,如高考成绩排名,上万员工年龄数据
        static int[] CountSort(int[] array) {
            int[] result = new int[array.Length];
            int[] count = new int[10]; //10代表原数组的所有元素范围为0 - 10
            for (int i = 0; i < array.Length; i++) {
                count[array[i]]++;
            }

            for (int i = 0, j = 0; i < count.Length; i++) {
                if (count[i] > 0) {
                    for (int k = 0; k < count[i]; k++) {
                        result[j] = i;
                        j++;
                    }
                }
            }
            return result;
        }

        static void PrintArray(int[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
