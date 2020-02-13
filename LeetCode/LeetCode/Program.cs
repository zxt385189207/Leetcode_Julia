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
    class Program
    {
        public class ListNode
        {
            public int      val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }
        }

        // 证明过程在https://leetcode-cn.com/problems/linked-list-cycle-ii/solution/huan-xing-lian-biao-ii-by-leetcode/
        // 结论: F=b
        // F: 无环的那一段
        // a: 进入环到快慢指针相遇的那一段
        // b: 快慢指针相遇点到环入口的那一段
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            // 计算相遇点
            ListNode intersect = getIntersect(head);
            if (intersect == null)
                return null;
            

            // 相遇点之后, 用2个指针,1个从头开始
            // 1个从相遇点开始 一起走
            // 再次相遇就是环的入口
            ListNode ptr1 = head;
            ListNode ptr2 = intersect;
            while (ptr1 != ptr2)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            return ptr1;
        }

        // 计算相遇点
        public ListNode getIntersect(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return slow;
            }
            return null;
        }


        static void Main(string[] args)
        {
            Program  p  = new Program();
            string[] ss = new[] {"abc", "abbc", "a"};
            int[][]  ii = new int[6][];
            ii[0] = new[] {1, 1};
            ii[1] = new[] {3, 2};
            ii[2] = new[] {5, 3};
            ii[3] = new[] {4, 1};
            ii[4] = new[] {2, 3};
            ii[5] = new[] {1, 4};
            //int[]     ii   = new[] {0,0,0,0};
            //List<int> list = new List<int>(ii);
            Console.WriteLine();
            ListNode a = new ListNode(1);
            a.next      = new ListNode(2);
            a.next.next = new ListNode(3);


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