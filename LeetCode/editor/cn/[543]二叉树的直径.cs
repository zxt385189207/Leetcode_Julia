//给定一棵二叉树，你需要计算它的直径长度。一棵二叉树的直径长度是任意两个结点路径长度中的最大值。这条路径可能穿过根结点。 
//
// 示例 : 
//给定二叉树 
//
// 
//          1
//         / \
//        2   3
//       / \     
//      4   5    
// 
//
// 返回 3, 它的长度是路径 [4,2,1,3] 或者 [5,2,1,3]。 
//
// 注意：两结点之间的路径长度是以它们之间边的数目表示。 
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
    // 根结点的左右子树深度和
    int ans = 1;
    // 根节点所在的子树的最大深度。
    public int DiameterOfBinaryTree(TreeNode root)
    {
        DFS(root);
        return ans - 1;
    }

    public int DFS(TreeNode root)
    {
        if (root == null)
            return 0;
        int left_depth  = DFS(root.left);
        int right_depth = DFS(root.right);
        ans = Math.Max(ans, left_depth + right_depth + 1);
        return Math.Max(left_depth, right_depth) + 1;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
