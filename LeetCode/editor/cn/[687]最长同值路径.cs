//给定一个二叉树，找到最长的路径，这个路径中的每个节点具有相同值。 这条路径可以经过也可以不经过根节点。 
//
// 注意：两个节点之间的路径长度由它们之间的边数表示。 
//
// 示例 1: 
//
// 输入: 
//
// 
//              5
//             / \
//            4   5
//           / \   \
//          1   1   5
// 
//
// 输出: 
//
// 
//2
// 
//
// 示例 2: 
//
// 输入: 
//
// 
//              1
//             / \
//            4   5
//           / \   \
//          4   4   5
// 
//
// 输出: 
//
// 
//2
// 
//
// 注意: 给定的二叉树不超过10000个结点。 树的高度不超过1000。 
// Related Topics 树 递归


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
    private int res = 0;
    // 自下而上
    // 因为主函数和递归函数返回的不是同一个东西,不能合并
    public int LongestUnivaluePath(TreeNode root)
    {
        // 终止条件
        if (root == null)
            return 0;
        DFS(root);

        return res; // 根节点所在的子树的最大深度。
    }

    public int DFS(TreeNode root)
    {
        // 终止条件
        if (root == null)
            return 0;

        int left_path  = DFS(root.left);
        int right_path = DFS(root.right);

        int leftcountsum  = 0;
        int rightcountsum = 0;
        // 本次函数要完成的任务是: 判断左子节点和右子节点是否等于根节点的值
        // 相等就路径+1
        if (root.left != null && root.left.val == root.val)
            leftcountsum = left_path + 1;
        if (root.right != null && root.right.val == root.val)
            rightcountsum = right_path + 1;


        res = Math.Max(res, leftcountsum + rightcountsum);

        return Math.Max(leftcountsum, rightcountsum); // 根节点所在的子树的最大深度。
    }
}
//leetcode submit region end(Prohibit modification and deletion)
