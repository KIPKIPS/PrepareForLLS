using System;
using System.Collections.Generic;

namespace 两数之和 {
    class Program:IComparer<int[]> {
        static void Main(string[] args) {
            int[] testArr = { 1, 5, 2, 3, 8, 7, 9, 11, 23, 56, 21, 65, 35 };
            int[] resArr = NumSum(testArr, 9);
            PrintArray(resArr);
            Console.ReadLine();
        }
        public static int[] NumSum(int[] nums, int target) {
            int[] res = new int[2];
            List<int[]> list = new List<int[]>();

            for (int i = 0; i < nums.Length; i++) {
                list[i] = new int[2];
                list[i][0] = nums[i];
                list[i][1] = i;
            }
            list.Sort();
            int front = 0;
            int rear = nums.Length - 1;
            for (int i = 0; i < nums.Length; i++) {
                if (front < rear) {
                    int sum = nums[front] + nums[rear];
                    if (sum < target) {
                        front++;
                    }

                    if (sum > target) {
                        rear--;
                    }

                    if (sum == target) {
                        record[0] = nums[front];
                        record[1] = nums[rear];
                    }
                }
            }

            

            return res;
        }

        public static void PrintArray(int[] array) {
            for (int i = 0; i < array.Length; i++) {
                Console.Write(array[i] + " ");
            }
        }
    }
}
