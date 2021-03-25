using System;
using System.Collections;
using System.Collections.Generic;
// 小A刚学了二进制，他十分激动。为了确定他的确掌握了二进制，你给他出了这样一道题目：给定N个非负整数，将这N个数字按照二进制下1的个数分类，二进制下1的个数相同的数字属于同一类。求最后一共有几类数字？
// 输入描述:
// 输入的第一行是一个正整数T（0 < T <= 10），表示样例个数。对于每一个样例，第一行是一个正整数N（0 < N <= 100），表示有多少个数字。接下来一行是N个由空格分隔的非负整数，大小不超过2 ^ 31 – 1。，
//
// 输出描述:
// 对于每一组样例，输出一个正整数，表示输入的数字一共有几类。
namespace 二进制计数 {
    class Program {
        static void Main(string[] args) {
            int times = Convert.ToInt32(Console.ReadLine());
            List<int[]> inpList = new List<int[]>();
            for (int i = 0; i < times; i++) {
                Console.ReadLine();
                string[] inp = Console.ReadLine().Split(' ');
                int[] convertArr = new int[inp.Length];
                for (int j = 0; j < inp.Length; j++) {
                    convertArr[j] = Convert.ToInt32(inp[j]);
                }
                inpList.Add(convertArr);
            }

            for (int i = 0; i < inpList.Count; i++) {
                Hashtable tab = new Hashtable();
                int tempRes = 0;
                for (int j = 0; j < inpList[i].Length; j++) {
                    int oneCounts = CalBinaryOneCount(inpList[i][j]);
                    if (!tab.ContainsKey(oneCounts)) {
                        tab[oneCounts] = true;
                        tempRes++;
                    }
                    //Console.Write(oneCounts);
                    //Console.Write(inpList[i][j] + " ");
                }

                //Console.WriteLine();
                Console.WriteLine(tempRes);
            }

            Console.ReadLine();
        }

        static int CalBinaryOneCount(int num) {
            int count = 0;
            while (num > 1) {
                if (num % 2 == 0) {
                    num /= 2;
                } else {
                    num = (num - 1) / 2;
                    count++;
                }
            }

            if (num == 1) {
                count++;
            }
            return count;
        }
    }
}
