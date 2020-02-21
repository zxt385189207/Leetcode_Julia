//计算给定二叉树的所有左叶子之和。 
//
// 示例： 
//
// 
//    3
//   / \
//  9  20
//    /  \
//   15   7
//
//在这个二叉树中，有两个左叶子，分别是 9 和 15，所以返回 24 
//
// 
// Related Topics 树


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
    // 递归
    public int SumOfLeftLeaves(TreeNode root)
    {
        if (root == null)
            return 0;

        int sum = 0;
        if (root.left != null && root.left.left == null && root.left.right == null)
            sum = root.left.val;

        return sum + SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
    }

    // 迭代
    public int SumOfLeftLeaves2(TreeNode root)
    {
        int res = 0;

        if (root == null)
            return res;
        // 存储节点深度
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            TreeNode cur = stack.Pop();

            if (cur.left != null && cur.left.left == null && cur.left.right == null)
                res += cur.left.val;

            if (cur.left != null)
                stack.Push(cur.left);
            if (cur.right != null)
                stack.Push(cur.right);
        }

        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
