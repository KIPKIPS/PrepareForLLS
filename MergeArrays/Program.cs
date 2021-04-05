using System;
//给你两个有序整数数组 nums1 和 nums2，请你将 nums2 合并到 nums1 中，使 nums1 成为一个有序数组。
// 初始化 nums1 和 nums2 的元素数量分别为 m 和 n 。你可以假设 nums1 的空间大小等于 m + n，这样它就有足够的空间保存来自 nums2 的元素。
namespace MergeArrays {
    class Program {
        static void Main(string[] args) {
            Merge(new[] { 1, 2, 3, 0, 0, 0 }, 3, new[] { 2, 5, 6 }, 3);
            Console.ReadLine();
        }
        public static void Merge(int[] nums1, int m, int[] nums2, int n) {
            int count = 0;
            int mPointer = 0;
            int nPointer = 0;
            int[] res = new int[m + n];
            while (count < m + n) {
                if (mPointer < m && nPointer < n) {
                    if (nums1[mPointer] < nums2[nPointer]) {
                        res[count] = nums1[mPointer];
                        mPointer++;
                    } else {
                        res[count] = nums2[nPointer];
                        nPointer++;
                    }
                    count++;
                } else {
                    if (mPointer >= m && nPointer < n) {
                        for (int i = nPointer; i < n; i++) {
                            //Console.WriteLine(i + nPointer + " " + i);
                            res[count] = nums2[i];
                            count++;
                        }
                    }
                    if (nPointer >= n && mPointer < m) {
                        for (int i = mPointer; i < m; i++) {
                            res[count] = nums1[i];
                            count++;
                        }
                    }
                }
            }
            for (int i = 0; i < nums1.Length; i++) {
                nums1[i] = res[i];
            }
            for (int i = 0; i < nums1.Length; i++) {
                Console.Write(nums1[i] + " ");
            }
        }
    }

}
