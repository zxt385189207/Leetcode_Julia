//给定一个二叉树和一个目标和，判断该树中是否存在根节点到叶子节点的路径，这条路径上所有节点值相加等于目标和。 
//
// 说明: 叶子节点是指没有子节点的节点。 
//
// 示例: 
//给定如下二叉树，以及目标和 sum = 22， 
//
//               5
//             / \
//            4   8
//           /   / \
//          11  13  4
//         /  \      \
//        7    2      1
// 
//
// 返回 true, 因为存在目标和为 22 的根节点到叶子节点的路径 5->4->11->2。 
// Related Topics 树 深度优先搜索


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
public class Solution
{
    /// <summary>
    /// 递归
    /// </summary>
    /// <param name="root"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    public bool HasPathSum(TreeNode root, int sum)
    {
        if (root == null)
            return false;

        sum -= root.val;
        // 需要遍历到叶子节点
        if (root.left == null && root.right == null)
            return sum == 0;
        // 递归
        return HasPathSum(root.left, sum) || HasPathSum(root.right, sum);
    }


    /// <summary>
    /// 迭代DFS 深度遍历
    /// </summary>
    /// <param name="root"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    public bool HasPathSum2(TreeNode root, int sum)
    {
        if (root==null)
        {
            return false;
        }
            
        Stack<TreeNode> stack    = new Stack<TreeNode>(); // 存储所有等待处理的节点
        Stack<int>      stacksum = new Stack<int>();      // 存储结果栈
        int             step     = 0;                     // 从根节点到当前节点需要的步骤数

        stack.Push(root);
        stacksum.Push(sum);
        while (stack.Count != 0)
        {
            step = step + 1;
            TreeNode temp = stack.Pop();

            int tempsum = stacksum.Pop() - temp.val;

            if (temp.left == null && temp.right == null && tempsum == 0)
            {
                return true;
            }

            if (temp.left != null)
            {
                stack.Push(temp.left);
                stacksum.Push(tempsum);
            }
            if (temp.right != null)
            {
                stack.Push(temp.right);
                stacksum.Push(tempsum);
            }
        }

        return false;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
