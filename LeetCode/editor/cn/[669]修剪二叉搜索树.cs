//给定一个二叉搜索树，同时给定最小边界L 和最大边界 R。通过修剪二叉搜索树，使得所有节点的值在[L, R]中 (R>=L) 。你可能需要改变树的根节点，所以
//结果应当返回修剪好的二叉搜索树的新的根节点。 
//
// 示例 1: 
//
// 
//输入: 
//    1
//   / \
//  0   2
//
//  L = 1
//  R = 2
//
//输出: 
//    1
//      \
//       2
// 
//
// 示例 2: 
//
// 
//输入: 
//    3
//   / \
//  0   4
//   \
//    2
//   /
//  1
//
//  L = 1
//  R = 3
//
//输出: 
//      3
//     / 
//   2   
//  /
// 1
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
    public TreeNode TrimBST(TreeNode root, int L, int R)
    {
        // 终止情况1
        if (root == null) return null;
        // 终止情况2, 根节点小于左边界,删除整个左分支和根节点,递归进入右子节点
        if (root.val < L) 
            return TrimBST(root.right, L, R);
        // 终止情况3, 根节点大于右边界,删除整个右分支和根节点
        if (root.val > R) 
            return TrimBST(root.left, L, R);
        
        // 根节点的值在LR之间保留根节点, 递归去修剪左子节点和右子节点
        root.left  = TrimBST(root.left, L, R);
        root.right = TrimBST(root.right, L, R);
        
        return root;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
