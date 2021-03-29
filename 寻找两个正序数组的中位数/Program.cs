using System;

namespace 寻找两个正序数组的中位数 {
    class Program {
        static void Main(string[] args) {
            int[] num1 = { 1, 3, 4 };
            int[] num2 = { 2 };
            Console.WriteLine(FindMedianSortedArrays(num1, num2));
            Console.ReadLine();
        }
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            int totalLength = nums1.Length + nums2.Length;
            bool isEven = totalLength % 2 == 0;
            int findIndex = isEven ? totalLength / 2 : (totalLength - 1) / 2;
            int[] numTotal = new int[totalLength];
            int p1 = 0;
            int p2 = 0;
            for (int i = 0; i <= findIndex; i++) {
                if (p1 < nums1.Length && p2 < nums2.Length) {
                    if (nums1[p1] <= nums2[p2]) {
                        numTotal[i] = nums1[p1];
                        p1++;
                    } else {
                        numTotal[i] = nums2[p2];
                        p2++;
                    }
                } else {
                    if (p1 >= nums1.Length && p2 < nums2.Length) {
                        numTotal[i] = nums2[p2];
                        p2++;
                    }

                    if (p2 >= nums2.Length && p1 < nums1.Length) {
                        numTotal[i] = nums1[p1];
                        p1++;
                    }
                }
            }

            if (isEven) {
                return (numTotal[findIndex] + (double)numTotal[findIndex - 1]) / 2;
            }
            return numTotal[findIndex];
        }
    }
}
