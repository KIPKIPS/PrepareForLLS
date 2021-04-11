using System;
using System.Collections.Generic;

namespace 重排最大数 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(LargestNumber(new[] { 1, 12, 32, 62, 89 }));
            Console.Read();
        }
        public static string LargestNumber(int[] nums) {
            List<int> numList = new List<int>();
            for (int i = 0; i < nums.Length; i++) {
                string str = nums[i].ToString();
                for (int j = 0; j < str.Length; j++) {
                    numList.Add(Convert.ToInt32(str[j].ToString()));
                }
            }
            numList.Sort();
            numList.Reverse();
            string res = "";
            for (int i = 0; i < numList.Count; i++) {
                res += numList[i];
            }

            return res;
        }
    }
}
