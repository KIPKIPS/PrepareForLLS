using System;
using System.Collections;
using System.Collections.Generic;

namespace 无重复字符的最长子串 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
            Console.ReadLine();
        }
        public static int LengthOfLongestSubstring(string s) {
            Dictionary<char, int> charDict = new Dictionary<char, int>();
            int frontPointer = 0;
            int rearPointer = 0;
            int max = 0;
            while (rearPointer < s.Length && frontPointer < s.Length) {
                if (!charDict.ContainsKey(s[rearPointer])) {
                    charDict.Add(s[rearPointer], rearPointer);
                    rearPointer++;
                    if (rearPointer - frontPointer > max) {
                        max = rearPointer - frontPointer;
                    }

                } else {
                    int index = charDict[s[rearPointer]];
                    if (rearPointer - frontPointer > max) {
                        max = rearPointer - frontPointer;
                    }
                    frontPointer = index + 1;
                    rearPointer = index + 1;
                    charDict.Clear();
                }
            }
            return max;
        }
    }
}
