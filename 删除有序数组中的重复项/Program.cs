using System;

namespace 删除有序数组中的重复项 {
    // 给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使每个元素 最多出现两次 ，返回删除后数组的新长度。
    // 不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。
    // 来源：力扣（LeetCode）
    // 链接：https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array-ii
    // 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(RemoveDuplicates(new[] { 0,0,1,1,1, 1,  2, 3, 3 }));
            Console.ReadLine();
        }
        public static int RemoveDuplicates(int[] nums) {
            if (nums.Length <= 1) {
                return nums.Length;
            }
            int remain = nums.Length;
            int lastIndex = 0;
            int removeCount = 1;
            int curIndex = 0;
            for (int i = 1; i < nums.Length; i++) {
                if (nums[i] != nums[lastIndex]) {
                    for (int j = 0; j < i - lastIndex; j++) {
                        nums[curIndex + j] = nums[lastIndex];
                    }
                    curIndex += i - lastIndex >= 2 ? 2 : 1;
                    if (i - lastIndex > 2) {
                        remain -= removeCount - 2;
                    }
                    lastIndex = i;
                    removeCount = 1;
                    if (i == nums.Length - 1) {
                        nums[curIndex] = nums[i];
                    }
                } else {
                    removeCount++;
                    if (i == nums.Length - 1) {
                        remain -= removeCount - 2;
                        for (int j = 0; j < i - lastIndex + 1; j++) {
                            nums[curIndex + j] = nums[lastIndex];
                        }
                    }
                }
            }
            // for (int i = 0; i < remain; i++) {
            //     Console.Write(nums[i] + " ");
            // }
            //Console.WriteLine();
            return remain;
        }
    }
}
