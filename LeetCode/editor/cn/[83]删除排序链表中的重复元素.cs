//给定一个排序链表，删除所有重复的元素，使得每个元素只出现一次。 
//
// 示例 1: 
//
// 输入: 1->1->2
//输出: 1->2
// 
//
// 示例 2: 
//
// 输入: 1->1->2->3->3
//输出: 1->2->3 
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
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode current = head;
        while (current != null && current.next != null)
        {
            // 因为是有序列表, 就判断当前值和下一个节点中的值
            if (current.next.val == current.val)
            {
                current.next = current.next.next;
            }
            else // 直到不相等, 指针移到下一个节点
            {
                current = current.next;
            }
        }

        return head;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
