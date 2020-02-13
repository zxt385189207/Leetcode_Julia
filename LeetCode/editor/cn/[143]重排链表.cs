//给定一个单链表 L：L0→L1→…→Ln-1→Ln ， 
//将其重新排列后变为： L0→Ln→L1→Ln-1→L2→Ln-2→… 
//
// 你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。 
//
// 示例 1: 
//
// 给定链表 1->2->3->4, 重新排列为 1->4->2->3. 
//
// 示例 2: 
//
// 给定链表 1->2->3->4->5, 重新排列为 1->5->2->4->3. 
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
    public void ReorderList(ListNode head) {
            if (head==null || head.next ==null)
                return;
            
            ListNode slow = head;
            ListNode fast = head;
            while (fast!=null && fast.next!=null)
            {
                // 指向下一个节点的next指针
                fast = fast.next.next;
                slow = slow.next;
            }
            
            // slow是最后一个节点
            // 反转slow.next为头结点之后的链表
            ListNode pre  = null;
            ListNode curr = slow.next;
            while (curr!=null)
            {
                // 记录一个next
                ListNode temp = curr.next;
                // 改动当前节点的next指针为前一项
                curr.next = pre;
                // 保存前一项, 下次遍历时使用
                pre = curr;
                // 继续遍历下一个
                curr = temp;
            }

            slow.next = null;
            // pre是最后一个节点, 也就是第二条链表的起始
            // 合并插入链表
            while (head!=null && pre!=null)
            {
                ListNode temp = head.next;
                ListNode temp2= pre.next;
                head.next = pre;
                pre.next = temp;
                head = temp;
                pre = temp2;

            }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
