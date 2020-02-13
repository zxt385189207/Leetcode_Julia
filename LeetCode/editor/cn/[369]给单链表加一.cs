//用一个 非空 单链表来表示一个非负整数，然后将这个整数加一。 
//
// 你可以假设这个整数除了 0 本身，没有任何前导的 0。 
//
// 这个整数的各个数位按照 高位在链表头部、低位在链表尾部 的顺序排列。 
//
// 示例: 
//
// 输入: [1,2,3]
//输出: [1,2,4]
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
    
    // 解法二双指针, 类似于滑动窗口,快慢指针之间全是9
    public ListNode PlusOne(ListNode head)
    {
        ListNode slow = new ListNode(0);
        slow.next = head;
        ListNode fast = head;

        // 遍历之后, slow指向最后的非9
        // 特殊情况全是9, slow在哨兵处
        while (fast!=null)
        {
            // fast.val != 9 慢指针移动到当前快指针处
            // fast.val = 9，慢指针原地不动
            if (fast.val!=9)
                slow = fast;

            fast = fast.next;
        }

        // 末位+1
        slow.val += 1;
        ListNode cur = slow.next;
        // 快慢指针之间的9全部置0
        while (cur != null)
        {
            cur.val = 0;
            cur     = cur.next;
        }
        // 判断是否全部是9
        return slow.next == head ? slow : head;
    }
    
      // 解法1 翻转两次链表
        public ListNode PlusOne1(ListNode head)
        {
            ListNode pre  = null;
            ListNode curr = head;
            ListNode tail = head;
            while (curr != null)
            {
                // 记录一个next
                ListNode temp = curr.next;
                // 改动当前节点的next指针为前一项
                curr.next = pre;
                // 保存前一项, 下次遍历时使用
                pre = curr;
                tail = curr;
                // 继续遍历下一个
                curr = temp;
            }

            while (pre != null)
            {
                if (pre.val != 9)
                {
                    pre.val++;
                    break;
                }

                pre.val = 0;

                if (pre.next == null)
                {
                    pre.next = new ListNode(1);
                    break;
                }
                curr = pre;
                pre  = pre.next;
            }

            pre = null;
            while (tail != null)
            {
                // 记录一个next
                ListNode temp = tail.next;
                // 改动当前节点的next指针为前一项
                tail.next = pre;
                // 保存前一项, 下次遍历时使用
                pre = tail;
                // 继续遍历下一个
                tail = temp;
            }

            return pre;
        }


}
//leetcode submit region end(Prohibit modification and deletion)
