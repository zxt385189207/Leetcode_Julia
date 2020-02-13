//对链表进行插入排序。 
//
// 
//插入排序的动画演示如上。从第一个元素开始，该链表可以被认为已经部分排序（用黑色表示）。 
//每次迭代时，从输入数据中移除一个元素（用红色表示），并原地将其插入到已排好序的链表中。 
//
// 
//
// 插入排序算法： 
//
// 
// 插入排序是迭代的，每次只移动一个元素，直到所有元素可以形成一个有序的输出列表。 
// 每次迭代中，插入排序只从输入数据中移除一个待排序的元素，找到它在序列中适当的位置，并将其插入。 
// 重复直到所有输入数据插入完为止。 
// 
//
// 
//
// 示例 1： 
//
// 输入: 4->2->1->3
//输出: 1->2->3->4
// 
//
// 示例 2： 
//
// 输入: -1->5->3->4->0
//输出: -1->0->3->4->5
// 
// Related Topics 排序 链表


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
    // 插入排序
    public ListNode InsertionSortList(ListNode head)
    {
        ListNode dummy = new ListNode(0);
        ListNode pre;
            
        dummy.next = head;

        while (head != null && head.next != null)
        {
            // 已经排序好的
            if (head.val <= head.next.val)
            {
                head = head.next;
                continue;
            }
            // 和最前面的节点(dummy.next)头节点比较
            // 找出要插入的位置, pre是前一个节点
            pre = dummy;
            while (pre.next.val < head.next.val) 
                pre = pre.next;

            // 插入对应位置, 修改3个节点的指针
            // 1(pre)3(head)2(curr)4 修改成 
            // 1(pre)2(curr)3(head)4
            ListNode curr = head.next;
            head.next = curr.next;
            curr.next = pre.next;
            pre.next  = curr;
        }

        return dummy.next;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
