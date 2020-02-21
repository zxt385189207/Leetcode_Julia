//给定一个二叉树，返回它的 后序 遍历。
//
// 示例:
//
// 输入: [1,null,2,3]
//   1
//    \
//     2
//    /
//   3
//
//输出: [3,2,1]
//
// 进阶: 递归算法很简单，你可以通过迭代算法完成吗？
// Related Topics 栈 树


//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
       // 用一个辅助栈实现的后序遍历
        public IList<int> PostorderTraversal0(TreeNode root)
        {
            IList<int> res = new List<int>();
            if (root == null)
                return res;

            Stack<(TreeNode, bool)> stack = new Stack<(TreeNode, bool)>();
            stack.Push((root, false));

            while (stack.Count > 0)
            {
                (TreeNode, bool) cur = stack.Pop();
                // 是否访问过, 只有访问过2次的才会加入res列表
                if (cur.Item2)
                    res.Add(cur.Item1.val);
                else
                {
                    // 此处的顺序把3个节点都压栈, 直到遍历到子节点为null
                    // 第二次访问节点时, 会设为true, 然后加入res列表

                    // 压根节点
                    stack.Push((cur.Item1, true));

                    // 压右子节点
                    if (cur.Item1.right != null)
                        stack.Push((cur.Item1.right, false));
                    // 压左子节点
                    if (top.Item1.left != null)
                        stack.Push((cur.Item1.left, false));
                }
            }

            return res;
        }

        // 后序: 左-> 右->根
        // 迭代解法1:
        // 思路: 前序是 根->左->右
        //       后序是 左->右->根
        //
        // 把前序左右节点顺序写反就是:
        //  反左右前序: 根->右->左   就是后序的逆序形式
        //
        // 然后写入链表的方式改为 插入首位.就相当于反转 反左右前序的输出链表.
        //  左->右->根
        public IList<int> PostorderTraversal1(TreeNode root)
        {
            List<int>       res   = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (root == null)
                return res;
            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode  curr = stack.Pop();
                // 不是插入在最后,而是首位
                res.Insert(0, curr.val);
                // 因为左子节点是第一个输出, 所以压栈底
                if (curr.left != null)
                    stack.Push(curr.left);

                if (curr.right != null)
                    stack.Push(curr.right);
            }

            return res;
        }

        List<int> res = new List<int>();
        public IList<int> PostorderTraversal(TreeNode root)
        {
            if (root==null)
                return list;
            if (root.left != null)
                PostorderTraversal(root.left);
            if (root.right != null)
                PostorderTraversal(root.right);
        	list.Add(root.val);
            return res;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
