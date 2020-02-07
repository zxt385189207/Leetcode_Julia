//给定一个二叉树 
//
// struct Node {
//  int val;
//  Node *left;
//  Node *right;
//  Node *next;
//} 
//
// 填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。 
//
// 初始状态下，所有 next 指针都被设置为 NULL。 
//
// 
//
// 进阶： 
//
// 
// 你只能使用常量级额外空间。 
// 使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。 
// 
//
// 
//
// 示例： 
//
// 
//
// 输入：root = [1,2,3,4,5,null,7]
//输出：[1,#,2,3,#,4,5,7,#]
//解释：给定二叉树如图 A 所示，你的函数应该填充它的每个 next 指针，以指向其下一个右侧节点，如图 B 所示。 
//
// 
//
// 提示： 
//
// 
// 树中的节点数小于 6000 
// -100 <= node.val <= 100 
// 
//
// 
//
// 
// 
// Related Topics 树 深度优先搜索


//leetcode submit region begin(Prohibit modification and deletion)
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/
public class Solution {
       // 递归
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return null;
            }

            if (root.left != null)
            {
                if (root.right != null)
                {
                    // 若右子树不为空，则左子树的 next 即为右子树
                    root.left.next = root.right;
                }
                else
                {
                    // 若右子树为空，则右子树的 next 由根节点的 next 得出
                    root.left.next = nextNode(root.next);
                }
            }

            if (root.right != null)
            {
                // 右子树的 next 由根节点的 next 得出
                root.right.next = nextNode(root.next);
            }

            // 先确保 root.right 下的节点的已完全连接，因 root.left 下的节点的连接
            // 需要 root.left.next 下的节点的信息，若 root.right 下的节点未完全连
            // 接（即先对 root.left 递归），则 root.left.next 下的信息链不完整，将
            // 返回错误的信息。可能出现的错误情况如下图所示。此时，底层最左边节点将无
            // 法获得正确的 next 信息：
            //                  o root
            //                 / \
            //     root.left  o —— o  root.right
            //               /    / \
            //              o —— o   o
            //             /        / \
            //            o        o   o
            Connect(root.right);
            Connect(root.left);
            return root;
        }

        Node nextNode(Node node)
        {
            while (node != null)
            {
                if (node.left != null)
                {
                    return node.left;
                }

                if (node.right != null)
                {
                    return node.right;
                }

                node = node.next;
            }

            return null;
        }

        // 迭代
        // 模拟队列
        // 一层一层的遍历这颗树，
        // 然后在每一层让前一个非空的节点指向后一个非空的节点
        public Node Connect1(Node root)
        {
            Node cur = root;

            while (cur != null)
            {
                Node dummy = new Node();
                Node tail  = dummy;

                // 单层里进行连接next节点
                while (cur != null)
                {
                    // 构造了2个节点, 一个头和一个尾
                    if (cur.left != null)
                    {
                        tail.next = cur.left;
                        tail      = tail.next;
                    }

                    if (cur.right != null)
                    {
                        tail.next = cur.right;
                        tail      = tail.next;
                    }

                    cur = cur.next;
                }

                // 遍历完一层后.  当前节点设为下一层的第一个节点
                cur = dummy.next;
            }

            return root;
        }
        

        // BFS (解法不符合题意)
        // 你只能使用常量级额外空间。
        // 使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。
        public Node Connect23(Node root)
        {
            if (root == null)
            {
                return root;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                // 第一个节点
                Node pre = queue.Peek();

                for (int i = 0; i < size; i++)
                {
                    Node curr = queue.Dequeue();
                    // 连接同层级的右侧节点, 最后一个节点不用连
                    if (i > 0)
                    {
                        pre.next = curr;
                        pre      = pre.next;
                    }

                    if (curr.left != null)
                    {
                        queue.Enqueue(curr.left);
                    }

                    if (curr.right != null)
                    {
                        queue.Enqueue(curr.right);
                    }
                }
            }

            return root;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
