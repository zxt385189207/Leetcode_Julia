//反转一个单链表。 
//
// 示例: 
//
// 输入: 1->2->3->4->5->NULL
//输出: 5->4->3->2->1->NULL 
//
// 进阶: 
//你可以迭代或递归地反转链表。你能否用两种方法解决这道题？ 
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
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;
            
        while (curr != null)
        {
            // 保存下一个节点的地址
            ListNode nextTemp = curr.next;
            // 改变下一个节点的next指针指向上一个.
            curr.next = prev;
            prev      = curr;
            curr      = nextTemp;
        }

        return prev;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
