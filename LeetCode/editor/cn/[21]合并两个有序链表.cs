//将两个有序链表合并为一个新的有序链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
//
// 示例： 
//
// 输入：1->2->4, 1->3->4
//输出：1->1->2->3->4->4
// 
// Related Topics 链表


//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
            public ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {
                if (l1 == null)
                {
                    return l2;
                }
                else if (l2 == null)
                {
                    return l1;
                }
                else if (l1.val < l2.val)
                {
                    l1.next = MergeTwoLists(l1.next, l2);
                    return l1;
                }
                else
                {
                    l2.next = MergeTwoLists(l1, l2.next);
                    return l2;
                }
            }


            
            /*
             * --------------------------------------------------
             *                  1    4  → 5    null
             *  prehead -1  ↗  ↓      ↖   ↘
             *                  1  → 2  → 3    6 → null
             *  最终返回prehead.next
             * --------------------------------------------------
             * 
             */
            /// <summary>
            /// 迭代
            /// </summary>
            /// <param name="l1"></param>
            /// <param name="l2"></param>
            /// <returns></returns>
            public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
            {
                //在返回节点之前维护对节点的不变引用。
                // 我们设定一个哨兵节点 "prehead" ，
                // 这可以在最后让我们比较容易地返回合并后的链表。
                ListNode prehead = new ListNode(-1);
                // 我们维护一个 prev 指针，我们需要做的是调整它的 next 指针
                ListNode prev = prehead;
                
                // 我们重复以下过程，直到 l1 或者 l2 指向了 null ：
                // 如果 l1 当前位置的值小于等于 l2 ，
                // 我们就把 l1 的值接在 prev 节点的后面同时将 l1 指针往后移一个。
                // 否则，我们对 l2 做同样的操作。
                // 不管我们将哪一个元素接在了后面，我们都把 prev 向后移一个元素。
                while (l1 != null && l2 != null)
                {
                    if (l1.val <= l2.val)
                    {
                        prev.next = l1;
                        l1        = l1.next;
                    }
                    else
                    {
                        prev.next = l2;
                        l2        = l2.next;
                    }

                    prev = prev.next;
                }

                // exactly one of l1 and l2 can be non-null at this point, so connect
                // the non-null list to the end of the merged list.
                prev.next = l1 == null ? l2 : l1;

                return prehead.next;
            }
}
//leetcode submit region end(Prohibit modification and deletion)
