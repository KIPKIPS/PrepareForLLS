using System;
using System.Linq.Expressions;

namespace 链表相加 {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }
    }
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            ListNode temp1 = l1;
            ListNode temp2 = l2;
            ListNode head = new ListNode();
            ListNode tempHead = head;
            int num = 0;
            while (temp1 != null || temp2 != null || num != 0) {
                ListNode temp = new ListNode();
                tempHead.next = temp;

                if (num != 0 && temp1 == null && temp2 == null) {
                    temp.val = num;
                    num = 0;
                }
                if (temp1 == null && temp2 != null) {
                    temp.val = (temp2.val + num) % 10;
                    num = (int)Math.Floor((float)(temp2.val + num) / 10);
                }
                if (temp2 == null && temp1 != null) {
                    temp.val = (temp1.val + num) % 10;
                    num = (int)Math.Floor((float)(temp1.val + num) / 10);
                }

                if (temp1 != null && temp2 != null) {
                    temp.val = (temp1.val + temp2.val + num) % 10;
                    num = (int)Math.Floor((float)(temp1.val + temp2.val + num) / 10);
                }

                if (temp1 != null) {
                    temp1 = temp1.next;
                }

                if (temp2 != null) {
                    temp2 = temp2.next;
                }

                tempHead = temp;
            }
            return head.next;
        }
    }
}
