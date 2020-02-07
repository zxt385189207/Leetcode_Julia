//给定一个二叉树，判断它是否是高度平衡的二叉树。 
//
// 本题中，一棵高度平衡二叉树定义为： 
//
// 
// 一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过1。 
// 
//
// 示例 1: 
//
// 给定二叉树 [3,9,20,null,null,15,7] 
//
//     3
//   / \
//  9  20
//    /  \
//   15   7 
//
// 返回 true 。 
// 
//示例 2: 
//
// 给定二叉树 [1,2,2,3,3,null,null,4,4] 
//
//        1
//      / \
//     2   2
//    / \
//   3   3
//  / \
// 4   4
// 
//
// 返回 false 。 
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
    public bool IsBalanced(TreeNode root)
    {
        return Depth(root) != -1;
    }

    // 返回-1的话说明 不满足要求不用求了直接 -1 退出
    // 从底至顶（提前阻断法）
    // 0是叶子节点的层数
    private int Depth(TreeNode root)
    {
        // 当前节点不存在其层数为0
        if (root == null)
            return 0;

        // 获取左节点的层数
        int left = Depth(root.left);
        // 如果层数为-1直接截断
        if (left == -1)
            return -1;

        // 获取右节点的层数
        int right = Depth(root.right);
        // 如果层数为-1直接退出
        if (right == -1)
            return -1;

        // 如果左右节点层数相差大于1 直接返回-1 否则返回真实层数
        return Math.Abs(left - right) < 2 ? Math.Max(left, right) + 1 : -1;
    }

    // 从顶至底（暴力法）
    // 若所有根节点都满足平衡二叉树性质，则返回 True ；
    // 本方法产生大量重复的节点访问和计算，最差情况下时间复杂度 O(N^2)。
    public bool IsBalanced2(TreeNode root)
    {
        if (root == null) return true;
        // 判断左右子树的节点深度,并且左右子树都满足平衡二叉树
        return Math.Abs(Depth1(root.left) - Depth1(root.right)) <= 1
               && IsBalanced2(root.left)
               && IsBalanced2(root.right);
    }

    private int Depth1(TreeNode root)
    {
        if (root == null) return 0;
        return Math.Max(Depth1(root.left), Depth1(root.right)) + 1;
    }

}
//leetcode submit region end(Prohibit modification and deletion)
