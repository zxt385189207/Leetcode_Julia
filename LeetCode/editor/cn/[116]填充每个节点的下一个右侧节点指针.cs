//给定一个完美二叉树，其所有叶子节点都在同一层，每个父节点都有两个子节点。二叉树定义如下： 
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
// 示例： 
//
// 
//
// 输入：{"$id":"1","left":{"$id":"2","left":{"$id":"3","left":null,"next":null,"ri
//ght":null,"val":4},"next":null,"right":{"$id":"4","left":null,"next":null,"right
//":null,"val":5},"val":2},"next":null,"right":{"$id":"5","left":{"$id":"6","left"
//:null,"next":null,"right":null,"val":6},"next":null,"right":{"$id":"7","left":nu
//ll,"next":null,"right":null,"val":7},"val":3},"val":1}
//
//输出：{"$id":"1","left":{"$id":"2","left":{"$id":"3","left":null,"next":{"$id":"4
//","left":null,"next":{"$id":"5","left":null,"next":{"$id":"6","left":null,"next"
//:null,"right":null,"val":7},"right":null,"val":6},"right":null,"val":5},"right":
//null,"val":4},"next":{"$id":"7","left":{"$ref":"5"},"next":null,"right":{"$ref":
//"6"},"val":3},"right":{"$ref":"4"},"val":2},"next":null,"right":{"$ref":"7"},"va
//l":1}
//
//解释：给定二叉树如图 A 所示，你的函数应该填充它的每个 next 指针，以指向其下一个右侧节点，如图 B 所示。
// 
//
// 
//
// 提示： 
//
// 
// 你只能使用常量级额外空间。 
// 使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。 
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
        // 迭代
        public Node Connect(Node root)
        {
            Node pre = root;
            while (pre!=null)
            {
                Node curr = pre;
                while (curr!=null)
                {
                    if (curr.left !=null)
                    {
                        curr.left.next = curr.right;
                    }

                    if (curr.right!=null && curr.next!=null)
                    {
                        curr.right.next = curr.next.left;
                    }

                    curr = curr.next;
                }
                // 迭代到下一层的第一个节点left
                pre = pre.left;
            }

            return root;
        }

        // 递归
        public Node Connect1(Node root)
        {
            if (root == null)
            {
                return null;
            }

            if (root.left != null)
            {
                root.left.next = root.right;
                if (root.next != null)
                {
                    root.right.next = root.next.left;
                }
            }

            root.left = Connect(root.left);
            root.right = Connect(root.right);

            return root;
        }


        // BFS (解法不符合题意)
        // 你只能使用常量级额外空间。
        // 使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。
        public Node Connect2(Node root)
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
