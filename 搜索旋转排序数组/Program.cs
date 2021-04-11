﻿using System;

namespace 搜索旋转排序数组 {
    // 已知存在一个按非降序排列的整数数组 nums ，数组中的值不必互不相同。
    //
    // 在传递给函数之前，nums 在预先未知的某个下标 k（0 <= k<nums.length）上进行了 旋转 ，使数组变为[nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]]（下标 从 0 开始 计数）。例如， [0, 1, 2, 4, 4, 4, 5, 6, 6, 7] 在下标 5 处经旋转后可能变为[4, 5, 6, 6, 7, 0, 1, 2, 4, 4] 。
    //
    // 给你 旋转后 的数组 nums 和一个整数 target ，请你编写一个函数来判断给定的目标值是否存在于数组中。如果 nums 中存在这个目标值 target ，则返回 true ，否则返回 false 。
    //
    // 来源：力扣（LeetCode）
    // 链接：https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii
    // 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
        public bool Search(int[] nums, int target) {
            for (int i = 0; i < nums.Length; i++) {
                if (target == nums[i]) {
                    return true;
                }
            }

            return false;
        }
    }
}
