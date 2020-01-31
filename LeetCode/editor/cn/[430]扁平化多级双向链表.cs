//您将获得一个双向链表，除了下一个和前一个指针之外，它还有一个子指针，可能指向单独的双向链表。这些子列表可能有一个或多个自己的子项，依此类推，生成多级数据结构
//，如下面的示例所示。 
//
// 扁平化列表，使所有结点出现在单级双链表中。您将获得列表第一级的头部。 
//
// 
//
// 示例: 
//
// 输入:
// 1---2---3---4---5---6--NULL
//         |
//         7---8---9---10--NULL
//             |
//             11--12--NULL
//
//输出:
//1-2-3-7-8-11-12-9-10-4-5-6-NULL
// 
//
// 
//
// 以上示例的说明: 
//
// 给出以下多级双向链表: 
//
// 
//
// 
//
// 我们应该返回如下所示的扁平双向链表: 
//
// 
// Related Topics 深度优先搜索 链表


//leetcode submit region begin(Prohibit modification and deletion)
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}
*/
public class Solution {
    // DFS 迭代
    public Node Flatten(Node head)
    {
        if (head == null) return head;

        Node pseudoHead = new Node(0, null, head, null);
        Node curr, prev = pseudoHead;

        Stack<Node> stack = new Stack<Node>();
        stack.Push(head);

        while (stack.Count != 0)
        {
            curr      = stack.Pop();
            prev.next = curr;
            curr.prev = prev;

            if (curr.next != null) 
                stack.Push(curr.next);
            
            // 有子列表会先出栈这个节点进行遍历
            if (curr.child != null)
            {
                stack.Push(curr.child);
                curr.child = null; // 最后要归于一条链表,这边赋值null
            }

            prev = curr;
        }

        // 去除头节点和哨兵节点之间的关系
        pseudoHead.next.prev = null;
        return pseudoHead.next;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
