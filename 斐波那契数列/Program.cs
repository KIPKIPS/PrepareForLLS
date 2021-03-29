using System;
using System.Runtime.CompilerServices;

namespace 斐波那契数列 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(fib(20));
            Console.Read();
        }
        //自顶向下的动态规划
        //带备忘录的递归算法
        public static int fib(int n) {
            //备忘录全初始化为0
            int[] memo = new int[n + 1];
            return helper(memo, n);
        }

        public static int helper(int[] memo, int n) {
            if (n == 0 || n == 1) {
                return n;
            }
            //备忘录
            if (memo[n] != 0) {
                return memo[n];
            }
            memo[n] = helper(memo, n - 1) + helper(memo, n - 2);
            return memo[n];
        }

        //自底向上的动态规划算法
        public int fibDP(int n) {
            if (n == 0) {
                return 0;
            }

            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            for (int i = 2; i <= n; i++) {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

        }
    }
}
