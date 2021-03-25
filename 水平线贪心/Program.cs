using System;

namespace 水平线贪心 {
    // 伞屉国是一个以太阳能为主要发电手段的国家，因此他们国家中有着非常多的太阳能基站，链接着的基站会组合成一个发电集群。
    // 但是不幸的是伞屉国不时会遭遇滔天的洪水，当洪水淹没基站时，基站只能停止发电，同时被迫断开与相邻基站的链接。你作为伞屉国的洪水观察员，
    // 有着这样的任务：在洪水到来时，计算出发电集群被洪水淹没后被拆分成了多少个集群。
    //
    // 由于远古的宇宙战争的原因，伞屉文明是一个二维世界里的文明，所以你可以这样理解发电基站的位置与他们的链接关系：给你一个一维数组a，长度为n，
    // 表示了n个基站的位置高度信息。数组的第i个元素a[i] 表示第i个基站的海拔高度是a[i], 而下标相邻的基站才相邻并且建立链接，
    // 即x号基站与x-1号基站、x+1号基站相邻。特别的，1号基站仅与2号相邻，而n号基站仅与n-1号基站相邻。当一场海拔高度为y的洪水到来时，
    // 海拔高度小于等于y的基站都会被认为需要停止发电，同时断开与相邻基站的链接。
    class Program {
        static void Main(string[] args) {

            Console.ReadLine();
            string input = Console.ReadLine().TrimEnd(' ');
            string[] inp = input.Split(' ');
            int[] heightList = new int[inp.Length];
            for (int i = 0; i < inp.Length; i++) {
                heightList[i] = Convert.ToInt32(inp[i]);
            }
            Console.ReadLine();
            string[] inpFloor = Console.ReadLine().Split(' ');
            for (int i = 0; i < inpFloor.Length; i++) {
                int area = CalDivideArea(heightList, Convert.ToInt32(inpFloor[i]));
                Console.WriteLine(area);
            }

        }

        static int CalDivideArea(int[] heights, int floor) {
            int area = 0;
            int lastIndex = -2;
            for (int i = 0; i < heights.Length; i++) {
                if (heights[i] - floor > 0) {
                    if (i - lastIndex > 1) {
                        area++;
                    }
                    lastIndex = i;
                }
            }
            return area;
        }
    }
}
