﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            IList<IList<int>> res  = new List<IList<int>>();
            Node              root = BuildTrie(words);

            for (int i = 0; i < words.Length; i++)
            {
                Node   cur  = root;
                string word = words[i];
                int    j    = 0;
                for (; j < word.Length; j++)
                {
                    if (IsPalindrome(word.Substring(j)))
                    {
                        foreach (var k in cur.words)
                        {
                            if (i != k)
                            {
                                res.Add(new List<int> {i, k});
                            }
                        }
                    }

                    if (cur.child[word[j] - 'a'] != null)
                    {
                        cur = cur.child[word[j] - 'a'];
                    }
                    else
                    {
                        break;
                    }
                }

                if (j == word.Length)
                {
                    foreach (var k in cur.suffix)
                    {
                        if (i != k)
                        {
                            res.Add(new List<int> {i, k});
                        }
                    }
                }
            }

            return res;
        }

        public Node BuildTrie(string[] words)
        {
            Node root = new Node();
            for (int i = 0; i < words.Length; i++)
            {
                Node   cur = root;
                string rev = Reverse(words[i]);
                if (IsPalindrome(rev))
                {
                    cur.suffix.Add(i);
                }

                for (int j = 0; j < rev.Length; j++)
                {
                    if (cur.child[rev[j] - 'a'] == null)
                    {
                        cur.child[rev[j] - 'a'] = new Node();
                    }

                    cur = cur.child[rev[j] - 'a'];
                    if (IsPalindrome(rev.Substring(j + 1)))
                    {
                        cur.suffix.Add(i);
                    }
                }

                cur.words.Add(i);
            }

            return root;
        }

        public string Reverse(string word)
        {
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public class Node
        {
            public Node[]    child  = new Node[26];
            public List<int> words  = new List<int>();
            public List<int> suffix = new List<int>();
        }


        class Program
        {
        }


        static void Main(string[] args)
        {
            Program  p  = new Program();
            string[] ss = new[] {"abc", "abbc", "a"};
            int[]    ii = new[] {3, 3, 3};


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