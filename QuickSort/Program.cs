using System;

namespace QuickSort {
    class Program {
        static void Main(string[] args) {
            int[] array = { 1, 8, 2, 56, 51, 5, 35 };
            int topK = QuickSelect(array, 2);
            Console.WriteLine(topK);
            Console.ReadLine();

        }

        //快选实现
        static int QuickSelect(int[] array, int k) {
            return Quick(array, 0, array.Length - 1, array.Length - k);
        }

        static int Quick(int[] array, int left, int right, int k) {
            int index;
            if (left < right) {
                //划分数组
                index = Partition(array, left, right);
                if (index == k) {
                    return array[k];
                } else if (left < index - 1) {
                    return Quick(array, left, index - 1, k);
                } else {
                    return Quick(array, index, right, k);
                }
            }
            return array[left];
        }

        //快排实现
        static void QuickSort(int[] array) {
            Quick(array, 0, array.Length - 1);
        }

        //快排划分步骤
        static void Quick(int[] array, int left, int right) {
            int index;
            if (left < right) {
                //划分数组
                index = Partition(array, left, right);
                if (left < index - 1) {
                    Quick(array, left, index - 1);
                }

                if (index < right) {
                    Quick(array, index, right);
                }
            }
        }

        //一次快排过程
        static int Partition(int[] array, int left, int right) {
            //随机一个索引作为pivot
            Random random = new Random();
            int randomIndex = random.Next(left, right + 1);
            int pivot = array[randomIndex];
            int l = left;
            int r = right;
            while (l <= r) {
                while (array[l] < pivot) {//左指针右移,找第一个大于基准数的
                    l++;
                }
                while (array[r] > pivot) {//右指针左移,找第一个小于基准数的
                    r--;
                }
                //交换
                if (l <= r) {
                    Swap(array, l, r);
                    l++;
                    r--;
                }
            }
            return l;
        }

        static void Swap(int[] array, int l, int r) {
            int temp = array[l];
            array[l] = array[r];
            array[r] = temp;
        }
    }
}
