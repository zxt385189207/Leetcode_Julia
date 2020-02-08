using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace LeetCode
{
    // public class TreeNode
    // {
    //     public int      val;
    //     public TreeNode left;
    //     public TreeNode right;
    //
    //     public TreeNode(int x)
    //     {
    //         val = x;
    //     }
    // }
    public class Node
    {
        public int         val;
        public IList<Node> children;

        public Node()
        {
        }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val      = _val;
            children = _children;
        }
    }


    public class Solution
    {
        class Program
        {
            
            public int MissingNumber(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    // 鸽巢原理, 也就是抽屉原理
                    // 将对应的鸽子放到对应的巢中
                    while (nums[i] <= nums.Length && nums[nums[i]] != nums[i])
                    {
                        Swap(nums, nums[i], i);
                    }
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != i)
                    {
                        return i;
                    }
                }

                return nums.Length;
            }
            // 在数组中使用异或运算交换两个变量的值的时候，
            // 一定要保证这两个变量不是同一个变量，
            // 即索引不能相同，否则会把这个位置上的数变成 0 。
            public void Swap(int[] nums, int i, int j)
            {
                if (i == j)
                    return;
                // 异或法
                // 用异或运算交换变量，并且不能加快运算，也不能节省内存。
                // nums[i] = nums[i] ^ nums[j]; // a ^ b = c
                // nums[j] = nums[i] ^ nums[j]; //nums[j] =  a = c ^ b;
                // nums[i] = nums[i] ^ nums[j]; //nums[i] =  b = c ^ a;
                
                // 加减法
                nums[i] = nums[i] + nums[j]; // a = a + b
                nums[j] = nums[i] - nums[j]; // b = a - b
                nums[i] = nums[i] - nums[j]; // a = a - b
                
                // 临时变量
                // int temp = nums[i];
                // nums[i] = nums[j];
                // nums[j] = temp;
            }
            
            public int FirstMissingPositive(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    // 把鸽子放进对应的巢中
                    // 每次swap都会使“正确位置”多一个，那么最多N次交换就能使它们都在
                    // 条件1,2: 元素值如果是负数,或者大于数组长度,
                    //        说明索引越界, 不去交换它, 遍历下一个
                    // 条件3: 把鸽子放进对应的巢中
                    while (nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i] - 1] != nums[i])
                    {
                        // 满足在指定范围内、并且没有放在正确的位置上，才交换
                        // 例如：数值 3 应该放在索引 2 的位置上
                        Swap(nums, nums[i] - 1, i);
                    }
                }

                // [1, -1, 3, 4]
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != i + 1)
                    {
                        return i + 1;
                    }
                }
                // 都正确则返回数组长度 + 1
                return nums.Length + 1;
            }



            static void Main(string[] args)
            {
                Program  p  = new Program();
                string[] ss = new[] {"abc", "abbc", "a"};
                int[]    ii = new[] {4, 3, 2, 7, 8, 2, 3, 1};


                Console.ReadKey();
                //
                //
                // Solution s = new Solution();
                //
                // TreeNode a = new TreeNode(3);
                // a.left        = new TreeNode(5);
                // a.right       = new TreeNode(1);
                // a.right.right = new TreeNode(0);
                // a.right.right = new TreeNode(8);
                //
                //
                // a.left.left  = new TreeNode(6);
                // a.left.right = new TreeNode(2);
                //
                // a.left.right.left  = new TreeNode(7);
                // a.left.right.right = new TreeNode(4);
                //
                // s.LowestCommonAncestor(a, a.left, a.right);
                //
                //Console.WriteLine(a.LengthOfLongestSubstring2("abcda"));
                // int[] aa = new[] {-2,1,-3,4,-1,2,1,-5,4};
                //

                // ListNode b = new ListNode(1);
                // a.RemoveNthFromEnd(b,1);


                // Stopwatch stopwatch = new Stopwatch();
                //
                // List<Int32> list = new List<int>();
                // for (int i = 0; i < 10000000; i++)
                // {
                //     list.Add(i);
                // }
                //
                //
                // stopwatch.Start(); //  开始监视代码运行时间
                // list.Remove(8);
                // stopwatch.Stop(); //  停止监视
                //
                // Console.WriteLine(stopwatch.Elapsed);
                // stopwatch.Reset();
                //
                // stopwatch.Start(); //  开始监视代码运行时间
                // list.Remove(9);
                // stopwatch.Stop(); //  停止监视
                //
                // Console.WriteLine(stopwatch.Elapsed);
            }
        }
    }
}