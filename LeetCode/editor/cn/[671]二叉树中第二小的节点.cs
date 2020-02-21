//给定一个非空特殊的二叉树，每个节点都是正数，并且每个节点的子节点数量只能为 2 或 0。如果一个节点有两个子节点的话，那么这个节点的值不大于它的子节点的值。
// 
//
// 给出这样的一个二叉树，你需要输出所有节点中的第二小的值。如果第二小的值不存在的话，输出 -1 。 
//
// 示例 1: 
//
// 
//输入: 
//    2
//   / \
//  2   5
//     / \
//    5   7
//
//输出: 5
//说明: 最小的值是 2 ，第二小的值是 5 。
// 
//
// 示例 2: 
//
// 
//输入: 
//    2
//   / \
//  2   2
//
//输出: -1
//说明: 最小的值是 2, 但是不存在第二小的值。
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
    public int FindSecondMinimumValue(TreeNode root) {
        // 子节点只能是0个或2个
        if (root?.left == null)
            return -1;

        int left  = root.left.val;
        int right = root.right.val;
        // 如果节点和子节点值相等, 递归进入子节点
        if (root.val == left)
            left = FindSecondMinimumValue(root.left);
        if (root.val == right)
            right = FindSecondMinimumValue(root.right);

        if (left != -1 && right != -1) 
            return Math.Min(left, right);

        // right=-1 代表根节点和右子节点相等或为null, 那left就是第二小的
        if (left != -1) 
            return left;

        return right;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
