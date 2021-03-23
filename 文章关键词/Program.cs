using System;
using System.Collections.Generic;

namespace 文章关键词 {
    class Program {
        static void Main(string[] args) {
            int num = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, int> timesDict = new Dictionary<string, int>();
            for (int i = 0; i < num; i++) {
                string lowConvertWord = Console.ReadLine().ToLower();
                if (!timesDict.ContainsKey(lowConvertWord)) {
                    timesDict.Add(lowConvertWord, 1);
                } else {
                    timesDict[lowConvertWord]++;
                }
            }

            int res = 0;
            foreach (KeyValuePair<string, int> kvp in timesDict) {
                //Console.WriteLine(kvp.Key + " " + kvp.Value);
                //Console.WriteLine(kvp.Value / num);
                if (kvp.Value / (float)num >= 0.01f) {
                    res++;
                }
            }

            Console.WriteLine(res);
            Console.Read();
        }
    }
}
