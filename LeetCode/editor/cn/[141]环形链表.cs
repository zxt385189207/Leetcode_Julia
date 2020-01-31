//给定一个链表，判断链表中是否有环。 
//
// 为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 如果 pos 是 -1，则在该链表中没有环。 
//
// 
//
// 示例 1： 
//
// 输入：head = [3,2,0,-4], pos = 1
//输出：true
//解释：链表中有一个环，其尾部连接到第二个节点。
// 
//
// 
//
// 示例 2： 
//
// 输入：head = [1,2], pos = 0
//输出：true
//解释：链表中有一个环，其尾部连接到第一个节点。
// 
//
// 
//
// 示例 3： 
//
// 输入：head = [1], pos = -1
//输出：false
//解释：链表中没有环。
// 
//
// 
//
// 
//
// 进阶： 
//
// 你能用 O(1)（即，常量）内存解决此问题吗？ 
// Related Topics 链表 双指针


//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    /// <summary>
    /// 我们可以通过检查一个结点此前是否被访问过来判断链表是否为环形链表。常用的方法是使用哈希表。
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public bool HasCycle(ListNode head)
    {
        HashSet<ListNode> nodesSet = new HashSet<ListNode>();
        while (head != null)
        {
            if (nodesSet.Contains(head))
            {
                return true;
            }
            else
            {
                nodesSet.Add(head);
            }

            head = head.next;
        }

        return false;
    }

    /// <summary>
    /// 快慢指针
    /// 如果列表中不存在环，最终快指针将会最先到达尾部，此时我们可以返回false
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public bool HasCycle2(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return false;
        }

        ListNode slow = head;
        ListNode fast = head.next;
            
        // 如果快慢指针相遇了, 则存在环
        while (slow != fast)
        {
            if (fast == null || fast.next == null)
            {
                return false;
            }
            // 快指针跑2步, 慢指针跑1步
            slow = slow.next;
            fast = fast.next.next;
        }

        return true;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
