using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using LeetCode;
using Microsoft.VisualBasic;

namespace LeetCode
{
}

public class Solution
{
    // 模拟出栈
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        if (pushed.Length < 1)
            return true;
        Stack<int> stackPush = new Stack<int>();

        int j = 0;
        for (int i = 0; i < pushed.Length; i++)
        {
            stackPush.Push(pushed[i]);
            // 1. 每push一个元素都与Popped数组第一个元素对比, 相等就出栈
            // 2. 出栈之后索引自增
            // 3. 循环结束条件: 栈内无元素 && 元素不相等 && popped遍历结束,
            while (stackPush.Count != 0 && popped[j] == stackPush.Peek() && j < popped.Length)
            {
                stackPush.Pop();
                j++;
            }
        }
        // 如果栈内还有元素, 证明popped是不可能存在的序列
        return stackPush.Count == 0;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Program  p  = new Program();
            string[] ss = new[] {"abc", "abbc", "a"};
            // int[][]  ii = new int[6][];
            // ii[0] = new[] {1, 1};
            // ii[1] = new[] {3, 2};
            // ii[2] = new[] {5, 3};
            // ii[3] = new[] {4, 1};
            // ii[4] = new[] {2, 3};
            // ii[5] = new[] {1, 4};
            int[] ii  = new[] {4, 1, 2};
            int[] ii2 = new[] {1, 3, 4, 2};
            //List<int> list = new List<int>(ii);
            Console.WriteLine();


            HashSet<(int, int, int)> set = new HashSet<(int, int, int)>();
            set.Add((1, 1, 1));
            set.Add((1, 1, 1));


            // HashSet<IList<int>> set = new HashSet<IList<int>>();
            //
            // List<int> list1 = new List<int>{1,1,1};
            // List<int> list2 = new List<int>{1,1,1};
            //
            // Console.WriteLine(list1.All(list2.Contains));
            //

            // set.Add(list1.ToArray());
            // set.Add(list1.ToArray());

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