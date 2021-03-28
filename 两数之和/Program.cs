using System;
using System.Collections.Generic;

namespace 两数之和 {
    class Program {
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
                int[] tempArr = new int[2];
                tempArr[0] = nums[i];
                tempArr[1] = i;
                list.Add(tempArr);
            }
            list.Sort(new ListComparer());
            for (int i = 0; i < list.Count; i++) {
                Console.Write(list[i][0] + " ");
            }
            int front = 0;
            int rear = nums.Length - 1;
            for (int i = 0; i < list.Count; i++) {
                if (front < rear) {
                    int sum = list[front][0] + list[rear][0];
                    if (sum < target) {
                        front++;
                    }

                    if (sum > target) {
                        rear--;
                    }

                    if (sum == target) {
                        res[0] = list[front][1];
                        res[1] = list[rear][1];
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

        class ListComparer : IComparer<int[]> { // Can be put outside, in this case, inner class may be better
            public int Compare(int[] arr1, int[] arr2) {
                if (arr1[0] < arr2[0])
                    return -1;
                if (arr1[0] == arr2[0]) {
                    return 0;
                }

                return 1;
            }
        }
    }
}

