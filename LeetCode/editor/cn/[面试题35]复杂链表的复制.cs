//请实现 copyRandomList 函数，复制一个复杂链表。在复杂链表中，每个节点除了有一个 next 指针指向下一个节点，还有一个 random 指针指
//向链表中的任意节点或者 null。 
//
// 
//
// 示例 1： 
//
// 
//
// 输入：head = [[7,null],[13,0],[11,4],[10,2],[1,0]]
//输出：[[7,null],[13,0],[11,4],[10,2],[1,0]]
// 
//
// 示例 2： 
//
// 
//
// 输入：head = [[1,1],[2,1]]
//输出：[[1,1],[2,1]]
// 
//
// 示例 3： 
//
// 
//
// 输入：head = [[3,null],[3,0],[3,null]]
//输出：[[3,null],[3,0],[3,null]]
// 
//
// 示例 4： 
//
// 输入：head = []
//输出：[]
//解释：给定的链表为空（空指针），因此返回 null。
// 
//
// 
//
// 提示： 
//
// 
// -10000 <= Node.val <= 10000 
// Node.random 为空（null）或指向链表中的节点。 
// 节点数目不超过 1000 。 
// 
//
// 
//
// 注意：本题与主站 138 题相同：https://leetcode-cn.com/problems/copy-list-with-random-point
//er/ 
//
// 
// Related Topics 链表


//leetcode submit region begin(Prohibit modification and deletion)
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/
public class Solution {
    // 思路1 借助哈希保存节点信息。
    public Node CopyRandomList(Node head)
    {
        if (head == null)
            return null;

        Node curr = head;

        Dictionary<Node, Node> dic = new Dictionary<Node, Node>();

        // 遍历节点, 将原节点作为KEY拷贝节点作为value保存在字典中
        while (curr != null)
        {
            Node copy = new Node(curr.val);
            dic[curr] = copy;
            curr      = curr.next;
        }

        // 复制next和random指针
        curr = head;
        while (curr != null)
        {
            dic[curr].next   = curr.next == null ? null : dic[curr.next];
            dic[curr].random = curr.random == null ? null : dic[curr.random];
            curr             = curr.next;
        }

        return dic[head];
    }

    // 思路二：原地复制
    //    复制节点，同时将复制节点链接到原节点后面，如A->B->C 变为 A->A'->B->B'->C->C'。
    // 设置节点random值。
    // 将复制链表从原链表分离。
    public Node CopyRandomList2(Node head)
    {
        if (head == null)
            return null;

        Node curr = head;
        // 复制节点添加到原节点后面
        while (curr != null)
        {
            Node copy = new Node(curr.val);
            copy.next = curr.next;
            curr.next = copy;
            curr      = copy.next;
        }

        // 复制random节点
        curr = head;
        while (curr != null)
        {
            if (curr.random != null)
            {
                // curr.next 是copy节点, 
                curr.next.random = curr.random.next;
            }

            // 跳过copy节点
            curr = curr.next.next;
        }

        // 分离链表
        curr = head;
        Node newHead = head.next;
        Node newNode = newHead;
        while (curr != null)
        {
            curr.next = curr.next.next;
            // 不可能是空指针, 因为只要head不为null,肯定有下一个复制copy节点
            if (newNode.next != null)
            {
                newNode.next = newNode.next.next;
            }

            curr    = curr.next;
            newNode = newNode.next;
        }

        return newHead;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
