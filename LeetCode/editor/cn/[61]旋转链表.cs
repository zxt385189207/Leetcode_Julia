//给定一个链表，旋转链表，将链表每个节点向右移动 k 个位置，其中 k 是非负数。 
//
// 示例 1: 
//
// 输入: 1->2->3->4->5->NULL, k = 2
//输出: 4->5->1->2->3->NULL
//解释:
//向右旋转 1 步: 5->1->2->3->4->NULL
//向右旋转 2 步: 4->5->1->2->3->NULL
// 
//
// 示例 2: 
//
// 输入: 0->1->2->NULL, k = 4
//输出: 2->0->1->NULL
//解释:
//向右旋转 1 步: 2->0->1->NULL
//向右旋转 2 步: 1->2->0->NULL
//向右旋转 3 步: 0->1->2->NULL
//向右旋转 4 步: 2->0->1->NULL 
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
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null)
            return null;
        if (head.next == null)
            return head;

        ListNode curr    = head;
        ListNode newhead = head;

        int length = 1;
        while (curr.next != null)
        {
            curr = curr.next;
            length++;
        }

        // 做成环
        curr.next = head;
        // 1 2 3 4 5 
        // 1 2 3 null 4 5
        ListNode newtail = head;
        // 右移k%length次, 应该是倒序遍历k%length次, 遍历到的是头
        // 再减1是尾巴
        for (int i = 0; i < length - k % length - 1; i++)
        {
            newtail = newtail.next;
        }

        // 3
        newhead      = newtail.next;
        newtail.next = null;

        return newhead;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
