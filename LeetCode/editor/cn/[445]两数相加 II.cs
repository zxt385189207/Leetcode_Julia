//给定两个非空链表来代表两个非负整数。数字最高位位于链表开始位置。它们的每个节点只存储单个数字。将这两数相加会返回一个新的链表。 
//
// 
//
// 你可以假设除了数字 0 之外，这两个数字都不会以零开头。 
//
// 进阶: 
//
// 如果输入链表不能修改该如何处理？换句话说，你不能对列表中的节点进行翻转。 
//
// 示例: 
//
// 
//输入: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
//输出: 7 -> 8 -> 0 -> 7
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
    // 用双栈解决
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        Stack<int> s1 = new Stack<int>(); 
        Stack<int> s2 = new Stack<int>();
        while(l1!= null)
        {
            s1.Push(l1.val);
            l1 = l1.next;
        }
        while(l2 != null)
        {
            s2.Push(l2.val);
            l2 = l2.next;
        }
        
        int      carry   = 0;
        ListNode preNode = null;
        while(s1.Count > 0 || s2.Count >0)
        {
            var e1  = s1.Count > 0 ? s1.Pop() : 0;
            var e2  = s2.Count > 0 ? s2.Pop() : 0;
            var sum = e1 + e2 + carry;
            if(sum > 9)
            {
                carry = 1;
                sum   = sum % 10;
            }else{
                carry = 0;
            }
            var newNode = new ListNode(sum);
            newNode.next = preNode;
            preNode      = newNode;
        }

        if(carry == 1)
        {
            var newNode = new ListNode(1);
            newNode.next = preNode;
            preNode      = newNode;
        }

        return preNode;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
