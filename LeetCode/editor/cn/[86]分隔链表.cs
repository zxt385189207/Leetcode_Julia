//给定一个链表和一个特定值 x，对链表进行分隔，使得所有小于 x 的节点都在大于或等于 x 的节点之前。 
//
// 你应当保留两个分区中每个节点的初始相对位置。 
//
// 示例: 
//
// 输入: head = 1->4->3->2->5->2, x = 3
//输出: 1->2->2->4->3->5
// 
// Related Topics 链表 双指针


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
    public ListNode Partition(ListNode head, int x) {
        ListNode dunmmpyless    = new ListNode(0);
        ListNode less           = dunmmpyless;
        ListNode dunmmpygreater = new ListNode(0);
        ListNode greater        = dunmmpygreater;
            
            
        while (head != null)
        {
            if (head.val < x)
            {
                less.next = head;
                less      = less.next;
            }
            else
            {
                greater.next = head;
                greater      = greater.next;
            }

            head = head.next;
        }
        // 大的尾要设为null,不然会循环
        greater.next = null;
        // 连接小的尾和大的头
        less.next = dunmmpygreater.next;
        return dunmmpyless.next;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
