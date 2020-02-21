//给定一个所有节点为非负值的二叉搜索树，求树中任意两节点的差的绝对值的最小值。 
//
// 示例 : 
//
// 
//输入:
//
//   1
//    \
//     3
//    /
//   2
//
//输出:
//1
//
//解释:
//最小绝对差为1，其中 2 和 1 的差的绝对值为 1（或者 2 和 3）。
// 
//
// 注意: 树中至少有2个节点。 
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
    private int      min     = int.MaxValue;
    private TreeNode preNode = null;
    public int GetMinimumDifference(TreeNode root) {
        if (root==null)
            return min;
        
        if (root.left != null)
            GetMinimumDifference(root.left);

        if (preNode!=null)
            min = Math.Min(min, Math.Abs(root.val-preNode.val));
        
        preNode = root;
        
        if (root.right != null)
            GetMinimumDifference(root.right);
        return min;
    }
    
    // 递归
    public int GetMinimumDifference2(TreeNode root)
    {
        Stack<TreeNode> stack   = new Stack<TreeNode>();
        TreeNode        curr    = root;
        TreeNode        preNode = null;
        int             min     = int.MaxValue;
        while (curr != null || stack.Count != 0)
        {
            // 一直Push左子节点到栈中, 
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            
            if (preNode!=null)
                min = Math.Min(min, Math.Abs(curr.val-preNode.val));
            
            preNode = curr;
            curr    = curr.right;
        }
        return min;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
