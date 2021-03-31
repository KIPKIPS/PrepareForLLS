// 给定不同面额的硬币 coins 和一个总金额 amount。编写一个函数来计算可以凑成总金额所需的最少的硬币个数。如果没有任何一种硬币组合能组成总金额，返回 -1。
// 你可以认为每种硬币的数量是无限的。
// 示例 1：
//
// 输入：coins = [1, 2, 5], amount = 11
// 输出：3 
// 解释：11 = 5 + 5 + 1
// 示例 2：
//
// 输入：coins = [2], amount = 3
// 输出：-1
// 示例 3：
//
// 输入：coins = [1], amount = 0
// 输出：0
// 示例 4：
//
// 输入：coins = [1], amount = 1
// 输出：1
// 示例 5：
//
// 输入：coins = [1], amount = 2
// 输出：2
using System;
namespace 零钱兑换问题 {

    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            //22 58
        }

        //暴力递归
        public static int CoinChange(int[] coins, int amount) {
            //第一步先写base case
            if (amount == 0) {
                return 0;
            }

            if (amount < 0) {
                return -1;
            }
            int res = Int32.MaxValue;
            for (int i = 0; i < coins.Length; i++) {
                int coin = coins[i];
                int subProblem = CoinChange(coins, amount - coin);//子问题的拆分
                //子问题无解则跳过
                if (subProblem == -1) {
                    continue;
                }

                res = Math.Min(res, subProblem + 1);
            }
            return res == Int32.MaxValue ? -1 : res;
        }

        //备忘录算法,自顶向下
        //第一步,先声明备忘录
        private static int[] memo;
        public static int CoinChangeMemo(int[] coins, int amount) {
            memo = new int[amount + 1];
            //初始化备忘录
            Array.Fill(memo, -100);
            return DP(coins, amount);
        }

        //dp过程
        public static int DP(int[] coins, int amount) {
            //第一步先写base case
            if (amount == 0) {
                return 0;
            }

            if (amount < 0) {
                return -1;
            }
            //第二步,如果备忘录找到了值,直接返回
            if (memo[amount] != -100) {
                return memo[amount];
            }
            int res = Int32.MaxValue;
            for (int i = 0; i < coins.Length; i++) {
                int coin = coins[i];
                //使用dp函数进行子问题求解
                int subProblem = DP(coins, amount - coin);
                if (subProblem == -1) {
                    continue;
                }
                res = Math.Min(res, subProblem + 1);
            }
            //备忘录存值
            memo[amount] = (res == Int32.MaxValue ? -1 : res);
            return memo[amount];
        }

        //自底向上的动态规划,迭代解法
        //32:52
        public static int CoinChangeIteration(int[] coins, int amount) {
            int[] dp = new int[amount + 1];//初始化数组
            Array.Fill(dp, amount + 1);

            dp[0] = 0;//base case
            for (int i = 0; i < dp.Length; i++) {
                for (int j = 0; j < coins.Length; j++) {
                    int coin = coins[j];
                    if (i - coin < 0) {
                        continue;
                    }
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }

            return (dp[amount] == amount + 1) ? -1 : dp[amount];
        }

    }
}
