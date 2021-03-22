using System;

namespace RadixSort {
    //基数排序
    class Program {
        static void Main(string[] args) {
            int[] array = { 102, 501, 251, 325, 835, 721, 917, 653, 642, 156, 644, 857, 965, 287 };
            int[] result = RadixSort(array);
            PrintArray(result);
            Console.Read();
        }

        static int[] RadixSort(int[] array) {
            int[] result = new int[array.Length];
            int[] count = new int[10];
            for (int i = 0; i < 3; i++) { //这里的三代表,最大数的位数
                int division = (int)Math.Pow(10, i);
                for (int j = 0; j < array.Length; j++) {
                    int num = array[j] / division % 10;//求出个十百每一位的数字
                    count[num]++;
                }
                // for (int k = 1; k < count.Length; k++) {
                //     count[k] = count[k] + count[k - 1];
                // }
                //PrintArray(count);
                for (int m = array.Length - 1; m >= 0; m--) {
                    int num = array[m] / division % 10;
                    result[--count[num]] = array[m];
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
