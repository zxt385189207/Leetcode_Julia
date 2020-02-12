//定义一个函数，输入一个链表的头节点，反转该链表并输出反转后链表的头节点。 
//
// 
//
// 示例: 
//
// 输入: 1->2->3->4->5->NULL
//输出: 5->4->3->2->1->NULL 
//
// 
//
// 限制： 
//
// 0 <= 节点个数 <= 5000 
//
// 
//
// 注意：本题与主站 206 题相同：https://leetcode-cn.com/problems/reverse-linked-list/ 
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
    public ListNode ReverseList(ListNode head) {
        ListNode pre  = null;
        ListNode curr = head;

        while (curr!=null)
        {
            // 记录一个next
            ListNode temp = curr.next;
            // 改动当前节点的next指针为前一项
            curr.next = pre;
            // 记录前一项
            pre = curr;
            // 继续遍历下一个
            curr = temp;
        }

        return pre;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
