//给定一个二叉搜索树（Binary Search Tree），把它转换成为累加树（Greater Tree)，使得每个节点的值是原来的节点值加上所有大于它的节
//点值之和。 
//
// 例如： 
//
// 
//输入: 二叉搜索树:
//              5
//            /   \
//           2     13
//
//输出: 转换为累加树:
//             18
//            /   \
//          20     13
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
    private int sum = 0;
    public TreeNode ConvertBST(TreeNode root) 
    {
        
        if (root==null)
            return root;
        if (root.right != null)
            ConvertBST(root.right);

        sum += root.val;

        root.val = sum;
        
        if (root.left != null)
            ConvertBST(root.left);
        return root;
    }   
    // 迭代
    public TreeNode ConvertBST2(TreeNode root) 
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode        curr  = root;
        int             sum   = 0;
        while (curr != null || stack.Count != 0)
        {
            // 一直Push左子节点到栈中, 
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.right;
            }
            curr = stack.Pop();
            
            sum      += curr.val;
            curr.val =  sum;
            
            curr = curr.left;
        }
        return root;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
