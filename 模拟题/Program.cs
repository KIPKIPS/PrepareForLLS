using System;

namespace 模拟题 {
    class Program {
        static void Main(string[] args) {
            string[] inp = Console.ReadLine().Split(' ');
            int[] num = new int[inp.Length];
            int min = Convert.ToInt32(inp[0]);
            for (int i = 0; i < inp.Length; i++) {
                int intConvert = Convert.ToInt32(inp[i]);
                num[i] = intConvert;
            }

            int res = 0;
            while (CheckCanAllot(num)) {
                if (num[0] > num[1]) {
                    num[0]--;
                } else {
                    num[1]--;
                }

                int max = num[1];
                int maxIndex = 1;
                for (int i = 1; i <= 3; i++) {
                    if (num[i] > max) {
                        maxIndex = i;
                        max = num[i];
                    }
                }
                num[maxIndex]--;

                if (num[3] > num[4]) {
                    num[3]--;
                } else {
                    num[4]--;
                }

                res++;
            }

            Console.WriteLine(res);
            Console.ReadLine();

        }

        static bool CheckCanAllot(int[] array) {
            if (array[0] == 0 && array[1] == 0) {
                return false;
            }

            if (array[1] == 0 && array[2] == 0 && array[3] == 0) {
                return false;
            }
            if (array[3] == 0 && array[4] == 0) {
                return false;
            }
            return true;
        }
    }
}
