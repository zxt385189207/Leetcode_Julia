//给定一个非空二叉树，返回其最大路径和。 
//
// 本题中，路径被定义为一条从树中任意节点出发，达到任意节点的序列。该路径至少包含一个节点，且不一定经过根节点。 
//
// 示例 1: 
//
// 输入: [1,2,3]
//
//       1
//      / \
//     2   3
//
//输出: 6
// 
//
// 示例 2: 
//
// 输入: [-10,9,20,null,null,15,7]
//
//   -10
//   / \
//  9  20
//    /  \
//   15   7
//
//输出: 42 
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
public class Solution {
    private int res = int.MinValue;
    public int MaxPathSum(TreeNode root)
    {
        // 终止条件
        if (root == null)
            return 0;
        DFS(root);

        return res;
    }

    public int DFS(TreeNode root)
    {
        // 终止条件
        if (root == null)
            return 0;

        int leftMax  = Math.Max(DFS(root.left), 0);
        int rightMax = Math.Max(DFS(root.right), 0);

        // 计算当前节点为根节点时,左+右+本身的最大值
        int max = root.val + leftMax + rightMax;
        
        res = Math.Max(res, max);
        
        // 返回此节点单条最优(大)的路径
        return root.val + Math.Max(leftMax, rightMax);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
