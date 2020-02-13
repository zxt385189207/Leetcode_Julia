//反转从位置 m 到 n 的链表。请使用一趟扫描完成反转。 
//
// 说明: 
//1 ≤ m ≤ n ≤ 链表长度。 
//
// 示例: 
//
// 输入: 1->2->3->4->5->NULL, m = 2, n = 4
//输出: 1->4->3->2->5->NULL 
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
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (m > n || head == null)
                return head;

            ListNode dummpy = new ListNode(0);
            dummpy.next = head;

            ListNode premNode = dummpy;
            ListNode mNode    = head;
            ListNode nNode    = dummpy;

            ListNode pre = null; // 保存前一个节点

            // 把head当做工作指针, 不断后移
            while (n-- > 0)
            {
                // m=1时, mNode就是head,前置节点是哨兵节点
                if (m-- <= 1)
                {
                    // 反转链表
                    // 记录一个next
                    ListNode temp = head.next;
                    // 改动当前节点的next指针为前一项
                    head.next = pre;
                    // 保存前一项, 下次遍历时使用
                    pre = head;
                    // 继续遍历下一个
                    head = temp;
                }
                else
                {
                    premNode = premNode.next;
                    mNode    = mNode.next;
                    // 工作指针也要跟着移动,并记录前一项
                    pre  = head;
                    head = head.next;
                }

                nNode = pre;
            }
            // 
            premNode.next = nNode;
            mNode.next = head;

            return dummpy.next;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
