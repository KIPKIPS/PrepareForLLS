using System;
using System.Collections;
using System.Collections.Generic;

namespace 森林中的兔子 {
    // 森林中，每个兔子都有颜色。其中一些兔子（可能是全部）告诉你还有多少其他的兔子和自己有相同的颜色。我们将这些回答放在 answers 数组里。
    //
    // 返回森林中兔子的最少数量。
    //
    // 来源：力扣（LeetCode）
    // 链接：https://leetcode-cn.com/problems/rabbits-in-forest
    // 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(NumRabbits(new[] { 0, 0, 1, 1, 1 }));
            Console.ReadLine();
        }
        public static int NumRabbits(int[] answers) {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int total = 0;
            for (int i = 0; i < answers.Length; i++) {
                if (answers[i] == 0) {
                    total++;
                } else {
                    if (!dict.ContainsKey(answers[i])) {
                        dict.Add(answers[i], answers[i]);
                        total += answers[i] + 1;
                    } else {
                        if (dict[answers[i]] > 0) {
                            dict[answers[i]]--;
                        } else {
                            dict[answers[i]] = answers[i];
                            total += answers[i] + 1;
                        }
                    }
                }
            }
            return total;
        }
    }
}
