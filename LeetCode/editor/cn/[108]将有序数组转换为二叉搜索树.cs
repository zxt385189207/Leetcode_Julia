//将一个按照升序排列的有序数组，转换为一棵高度平衡二叉搜索树。 
//
// 本题中，一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1。 
//
// 示例: 
//
// 给定有序数组: [-10,-3,0,5,9],
//
//一个可能的答案是：[0,-3,9,-10,null,5]，它可以表示下面这个高度平衡二叉搜索树：
//
//      0
//     / \
//   -3   9
//   /   /
// -10  5
// 
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
    /// <summary>
    /// 二分法, 递归
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return nums == null ? null : BuildTree(nums, 0, nums.Length - 1);
    }

    private TreeNode BuildTree(int[] nums, int iLeft, int iRight)
    {
        if (iLeft > iRight)
        {
            return null;
        }

        int mid  = iLeft + (iRight - iLeft) / 2; //中间索引值
        var root = new TreeNode(nums[mid]);      //创建根部

        root.left  = BuildTree(nums, iLeft, mid - 1);  //左子树
        root.right = BuildTree(nums, mid + 1, iRight); //右子树
        return root;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
