//给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。 
//
// 你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。 
//
// 
//
// 示例: 
//
// 给定 1->2->3->4, 你应该返回 2->1->4->3.
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
    // 递归
    public ListNode SwapPairs1(ListNode head)
    {
        // 如果没有节点或只剩下单个节点
        if (head == null || head.next == null)
            return head;

        ListNode firstNode  = head;
        ListNode secondNode = head.next;

        firstNode.next  = SwapPairs(secondNode.next);
        secondNode.next = firstNode;

        return secondNode;
    }
    // 迭代
    public ListNode SwapPairs(ListNode head)
    {
        ListNode dummpy = new ListNode(0);
        dummpy.next = head;
        ListNode preNode = dummpy;

        while(preNode.next != null && preNode.next.next != null)
        {
            // 第一个节点
            var a = preNode.next;
            // 第二个节点
            var b = preNode.next.next;
            // 保存第三个节点
            var temp = b.next;
            preNode.next = b;
            b.next       = a;
            a.next       = temp;
            // 保存倍交换到第二个位置的a,作为下次循环的pre节点
            preNode = a;
        }
        return dummpy.next;
    }

}
//leetcode submit region end(Prohibit modification and deletion)
