//删除链表中等于给定值 val 的所有节点。 
//
// 示例: 
//
// 输入: 1->2->6->3->4->5->6, val = 6
//输出: 1->2->3->4->5
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
    // 哨兵节点广泛应用于树和链表中，如伪头、伪尾、标记等，
    // 它们是纯功能的，通常不保存任何数据，其主要目的是使链表标准化，
    // 如使链表永不为空、永不无头、简化插入和删除。
    public ListNode RemoveElements(ListNode head, int val)
    {
        // 哨兵节点
        ListNode sentinel = new ListNode(0);
        sentinel.next = head;

        ListNode prev = sentinel, curr = head;
        while (curr != null)
        {
            if (curr.val == val)
                prev.next = curr.next;
            else
                prev = curr;
            
            curr = curr.next;
        }

        return sentinel.next;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
