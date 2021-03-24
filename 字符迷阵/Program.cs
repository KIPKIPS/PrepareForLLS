using System;

// 字符迷阵是一种经典的智力游戏。玩家需要在给定的矩形的字符迷阵中寻找特定的单词。
// 在这题的规则中，单词是如下规定的：
// 1.在字符迷阵中选取一个字符作为单词的开头；
// 2.选取右方、下方、或右下45度方向作为单词的延伸方向；
// 3.以开头的字符，以选定的延伸方向，把连续得到的若干字符拼接在一起，则称为一个单词。
// 以图1为例，如果要在其中寻找单词 "WORD"，则绿色框所标示的都是合法的方案，而红色框所标示的都是不合法的方案。
// 现在的问题是，给出一个字符迷阵，及一个要寻找的单词，问能在字符迷阵中找到多少个该单词的合法方案。注意合法方案是可以重叠的，如图1所示的字符迷阵，其中单词 "WORD"的合法方案有4种。
//
// 输入描述:
// 输入的第一行为一个正整数T，表示测试数据组数。 接下来有T组数据。每组数据的第一行包括两个整数m和n，表示字符迷阵的行数和列数。接下来有m行，每一行为一个长度为n的字符串，按顺序表示每一行之中的字符。再接下来还有一行包括一个字符串，表示要寻找的单词。  数据范围： 对于所有数据，都满足1 <= T <= 9，且输入的所有位于字符迷阵和单词中的字符都为大写字母。要寻找的单词最短为2个字符，最长为9个字符。字符迷阵和行列数，最小为1，最多为99。 对于其中50 % 的数据文件，字符迷阵的行列数更限制为最多为20。
// 对于每一组数据，输出一行，包含一个整数，为在给定的字符迷阵中找到给定的单词的合法方案数。
//
// 输入例子1:
// 3
// 10 10
// AAAAAADROW
// WORDBBBBBB
// OCCCWCCCCC
// RFFFFOFFFF
// DHHHHHRHHH
// ZWZVVVVDID
// ZOZVXXDKIR
// ZRZVXRXKIO
// ZDZVOXXKIW
// ZZZWXXXKIK
// WORD
// 3 3
// AAA
// AAA
// AAA
// AA
// 5 8
// WORDSWOR
// ORDSWORD
// RDSWORDS
// DSWORDSW
// SWORDSWO
// SWORD
namespace 字符迷阵 {
    class Program {
        static void Main(string[] args) {
            int times = Convert.ToInt32(Console.ReadLine());
            int[] result = new int[times];
            for (int i = 0; i < times; i++) {
                string[] inp = Console.ReadLine().Split(' ');
                int col = Convert.ToInt32(inp[0]);
                int row = Convert.ToInt32(inp[1]);

                string[] map = new string[col];
                for (int j = 0; j < col; j++) {
                    map[j] = Console.ReadLine();
                }

                string checkStr = Console.ReadLine();
                int horizontalNum = CheckHorizontal(map, checkStr);
                int verticalNum = CheckVertical(map, row, checkStr);
                int diagonalNum = CheckDiagonal(map, row, checkStr);
                //Console.WriteLine(verticalNum);
                result[i] = horizontalNum + verticalNum + diagonalNum;
            }

            for (int i = 0; i < result.Length; i++) {
                Console.WriteLine(result[i]);
            }

            Console.ReadLine();
        }
        //水平检测
        static int CheckHorizontal(string[] map, string checkStr) {
            int matchTimes = 0;
            for (int i = 0; i < map.Length; i++) {
                for (int j = 0; j < map[i].Length - checkStr.Length + 1; j++) {
                    if (DeltaHorizontal(map[i], j, checkStr)) {
                        matchTimes++;
                    }
                }
            }
            return matchTimes;
        }

        static bool DeltaHorizontal(string str, int starIndex, string checkStr) {
            for (int i = starIndex; i < starIndex + checkStr.Length; i++) {
                if (str[i] != checkStr[i - starIndex]) {
                    return false;
                }
            }
            return true;
        }
        //竖直检测
        static int CheckVertical(string[] map, int row, string checkStr) {
            int matchTimes = 0;
            for (int i = 0; i < row; i++) {

                for (int j = 0; j < map.Length - checkStr.Length + 1; j++) {
                    string str = "";
                    for (int k = 0; k < checkStr.Length; k++) {
                        str = str + map[j + k][i];
                    }

                    if (str == checkStr) {
                        matchTimes++;
                    }
                }
            }
            return matchTimes;
        }
        //斜向检测
        static int CheckDiagonal(string[] map, int row, string checkStr) {
            int matchTimes = 0;
            for (int i = 0; i < row - checkStr.Length + 1; i++) {
                for (int j = 0; j < map.Length - checkStr.Length + 1; j++) {
                    string str = "";
                    for (int k = 0; k < checkStr.Length; k++) {
                        str = str + map[j + k][i + k];
                    }
                    if (str == checkStr) {
                        matchTimes++;
                    }
                    //Console.WriteLine(str);
                }
            }
            return matchTimes;
        }

    }
}
