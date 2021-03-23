using System;
using System.Collections.Generic;

namespace 子项目问题 {
    class Program {
        static void Main(string[] args) {
            //处理输入
            string aList = Console.ReadLine();
            string bList = Console.ReadLine();
            string[] bTemp = bList.Split(' ');
            int[] bData = new int[bTemp.Length];
            for (int i = 0; i < bTemp.Length; i++) {
                bData[i] = Convert.ToInt32(bTemp[i]);
            }
            string numStr = Console.ReadLine();
            int num = Convert.ToInt32(numStr);
            string[] infoList = new string[num];
            for (int i = 0; i < num; i++) {
                infoList[i] = Console.ReadLine();
            }

            Dictionary<int, List<int>> BADic = new Dictionary<int, List<int>>();
            for (int i = 0; i < infoList.Length; i++) {
                string[] temp = infoList[i].Split(' ');
                int a = Convert.ToInt32(temp[0]);
                int b = Convert.ToInt32(temp[1]);
                if (!BADic.ContainsKey(b)) {
                    BADic.Add(b, new List<int>());
                }
                if (!BADic[b].Contains(a)) {
                    BADic[b].Add(a);
                }
            }
            HashSet<int> res = new HashSet<int>();
            foreach (KeyValuePair<int, List<int>> kvp in BADic) {
                for (int i = 0; i < kvp.Value.Count; i++) {
                    if (!res.Contains(kvp.Value[i])) {
                        res.Add(kvp.Value[i]);
                    }

                    //Console.Write(kvp.Value[i] + " ");
                }

                //Console.WriteLine();
            }
            Console.WriteLine(res.Count);
            Console.ReadLine();
        }
    }
}
