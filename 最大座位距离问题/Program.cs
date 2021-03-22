using System;
using System.Collections.Generic;
using System.Linq;

// 疫情逐步缓和后，电影院终于开业了，但是由于当前仍处于疫情期间，应尽量保持人群不聚集的原则。
// 所以当小易来电影院选定一排后，尽量需要选择一个远离人群的位置。
// 已知由0和1组成的数组表示当前排的座位情况,其中1表示已被选座，0表示空座
//     请问小易所选座位和最近人的距离座位数最大是多少？
// 有如下假设：至少有一个人已选座，至少有一个空座位，且座位数限制为 2-1000

namespace 最大座位距离问题 {
    class Program {
        static void Main(string[] args) {
            string[] inp = Console.ReadLine().Split(' ');
            int max = 0;
            int tempCount = 0;
            bool isForward = inp.Length > 0 ? inp[0] == "0" : false;
            bool isRear = inp.Length > 0 ? inp[inp.Length - 1] == "0" : false;
            int rearCount = 0;

            bool forwardFlag = false;
            if (isRear) {
                for (int i = inp.Length - 1; i >= 0; i--) {
                    if (inp[i] == "0") {
                        rearCount++;
                    } else {
                        break;
                    }
                }
            }

            int forwordCount = 0;
            List<int> list = new List<int>();
            for (int i = 0; i < inp.Length; i++) {
                if (inp[i] == "0") {
                    if (i == 0) {
                        forwardFlag = true;
                    }
                    tempCount++;
                    if (tempCount > max) {
                        max = tempCount;
                    }

                } else {
                    tempCount = 0;
                    if (forwardFlag) {
                        forwardFlag = false;
                        forwordCount = i;
                    }
                }
            }

            //Console.WriteLine(forwordCount + " " + rearCount + " " + max);
            //Console.WriteLine(isForward + " " + isRear);
            if (isForward || isRear) {
                Console.WriteLine(new int[] { forwordCount, rearCount, (int)Math.Ceiling(max / 2f) }.Max());
            } else {
                Console.WriteLine((int)Math.Ceiling(max / 2f));
            }

            Console.ReadLine();
        }
    }
}
