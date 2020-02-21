//给定一个不为空的二叉搜索树和一个目标值 target，请在该二叉搜索树中找到最接近目标值 target 的数值。 
//
// 注意： 
//
// 
// 给定的目标值 target 是一个浮点数 
// 题目保证在该二叉搜索树中只会存在一个最接近目标值的数 
// 
//
// 示例： 
//
// 输入: root = [4,2,5,1,3]，目标值 target = 3.714286
//
//    4
//   / \
//  2   5
// / \
//1   3
//
//输出: 4
// 
// Related Topics 树 二分查找


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
    private double close = double.MaxValue;
    private int    res;
    public int ClosestValue(TreeNode root, double target)
    {
        Helper(root, target);
        return res;
    }
    public void Helper(TreeNode node, double target)
    {
        if (node != null)
        {
            double T = Math.Abs(target - node.val);
            if (T < close)
            {
                close = T;
                res   = node.val;
            }
            Helper(node.left, target);
            Helper(node.right, target);
        }
    }
    // 迭代
    public int ClosestValue2(TreeNode root, double target)
    {
        if (root == null) return 0;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        
        stack.Push(root);
        double min = double.MaxValue;
        int    res = 0;
        while (stack.Count!=0)
        {
            TreeNode cur = stack.Pop();
            if (target > cur.val)
            {
                if (Math.Abs(cur.val-target) < min)
                {
                    min = Math.Abs(cur.val - target);
                    res = cur.val;
                }
                if (cur.right!=null)
                    stack.Push(cur.right);
            }
            else
            {
                if (Math.Abs(cur.val-target) < min)
                {
                    min = Math.Abs(cur.val - target);
                    res = cur.val;
                }

                if (cur.left!=null)
                    stack.Push(cur.left);
            }
        }
        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
