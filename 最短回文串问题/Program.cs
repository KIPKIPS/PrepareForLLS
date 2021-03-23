using System;

namespace 最短回文串问题 {
    class Program {
        static void Main(string[] args) {
            string inp = Console.ReadLine();
            int front = 0;
            int rear = inp.Length - 1;
            string rearStr = "";//尾巴拼接的串
            int lastIndex = -1;//上一次不匹配拼接的索引
            while (front < rear) {
                if (inp[front] != inp[rear]) {
                    //不匹配就把当前索引到上一次不匹配的都拼接起来,倒序的
                    string temp = "";
                    for (int i = front; i > lastIndex; i--) {
                        temp = temp + inp[i];
                    }
                    rearStr = temp + rearStr;
                    lastIndex = front;//维护上一次索引
                    front++;//前指针++
                    rear = inp.Length - 1;//尾指针回退到串尾
                } else {
                    front++;
                    rear--;
                }
            }
            Console.Write(inp + rearStr);
            Console.Read();
        }
    }
}
