//请判断一个链表是否为回文链表。 
//
// 示例 1: 
//
// 输入: 1->2
//输出: false 
//
// 示例 2: 
//
// 输入: 1->2->2->1
//输出: true
// 
//
// 进阶： 
//你能否用 O(n) 时间复杂度和 O(1) 空间复杂度解决此题？ 
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
    /// <summary>
    /// 快慢指针 + 反转前半部分链表
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public bool IsPalindrome(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return true;
        }

        ListNode slow = head, fast   = head;
        ListNode pre  = head, prepre = null;
        // 链表个数为奇数的时候可以这样判断
        while (fast != null && fast.next != null)
        {
            pre = slow;
            // 快慢指针, 快指针是慢指针步进的2倍, 当快指针到最后时
            // 慢指针在中间位置
            slow = slow.next;
            fast = fast.next.next;
            // 反转链表, 反转前半部分
            pre.next = prepre;
            prepre   = pre;
        }

        // fast.next = null 的偶数个数情况
        // 将slow向后挪一位
        if (fast != null)
        {
            slow = slow.next;
        }

        // 判断前半部分(已反转)和后半部分是否是回文项
        while (pre != null && slow != null)
        {
            // 
            if (pre.val != slow.val)
            {
                return false;
            }

            pre  = pre.next;
            slow = slow.next;
        }

        return true;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
