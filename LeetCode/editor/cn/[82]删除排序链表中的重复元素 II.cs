//给定一个排序链表，删除所有含有重复数字的节点，只保留原始链表中 没有重复出现 的数字。 
//
// 示例 1: 
//
// 输入: 1->2->3->3->4->4->5
//输出: 1->2->5
// 
//
// 示例 2: 
//
// 输入: 1->1->1->2->3
//输出: 2->3 
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
    /// <summary>
    /// 快慢指针解法
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode DeleteDuplicates(ListNode head)
    {
        // 增加一个前置节点, 因为要修改原链表
        ListNode pre = new ListNode(-1);
        pre.next = head;
        ListNode slow = pre;
        ListNode fast = head;

        while (fast != null)
        {
            // 快指针下个元素不相同
            if (fast.val != fast.next?.val)
            {
                // 移动慢指针到fast处
                if (slow.next == fast)
                {
                    slow = fast;
                }
                else // 快慢指针之间有相同的元素
                {
                    // 慢指针跳过相同的节点, 指向不同
                    slow.next = fast.next;
                }
            }

            // 快指针遍历下一个
            fast = fast.next;
                
        }

        return pre.next;


    }
}
//leetcode submit region end(Prohibit modification and deletion)
