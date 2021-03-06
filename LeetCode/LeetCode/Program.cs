﻿using System;
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
    // 对于根 i 的不同二叉搜索树数量 F(i, n)F(i,n)，是左右子树个数的笛卡尔积
    // F(3,7) =G(2)⋅G(4)。 以3为根,长度为7的序列, 个数=左*右,
    // 当序列长度为 1 （只有根）或为 0 （空树）时，只有一种情况G[0]=G[1]=1
    public int NumTrees(int n)
    {
        int[] G = new int[n + 1];
        G[0] = 1;
        G[1] = 1;

        for (int i = 2; i <= n; ++i)
        {
            for (int j = 1; j <= i; ++j)
            {
                G[i] += G[j - 1] * G[i - j];
            }
        }
        return G[n];
    }




    public class TreeNode
    {
        public int      val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Program  p  = new Program();
            string[] ss = new[] {"hello"};
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
            TreeNode t = new TreeNode(1);
            t.left  = new TreeNode(1);
            t.right = new TreeNode(2);


            Solution s = new Solution();


            HashSet<(int, int, int)> set = new HashSet<(int, int, int)>();
            set.Add((1, 1, 1));
            set.Add((1, 1, 1));
            s.GenerateTrees(3);

            // Console.WriteLine(sizeof(byte));
            // Console.WriteLine(sizeof(Boolean));
            // Console.WriteLine(sizeof(int));
            Console.ReadLine();

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