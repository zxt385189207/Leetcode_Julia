//翻转一棵二叉树。 
//
// 示例： 
//
// 输入： 
//
//      4
//   /   \
//  2     7
// / \   / \
//1   3 6   9 
//
// 输出： 
//
//      4
//   /   \
//  7     2
// / \   / \
//9   6 3   1 
//
// 备注: 
//这个问题是受到 Max Howell 的 原问题 启发的 ： 
//
// 谷歌：我们90％的工程师使用您编写的软件(Homebrew)，但是您却无法在面试时在白板上写出翻转二叉树这道题，这太糟糕了。 
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
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return null;
        TreeNode left  = InvertTree(root.left);
        TreeNode right = InvertTree(root.right);

        root.left  = right;
        root.right = left;
        return root;
    }
    // 迭代
    public TreeNode InvertTree1(TreeNode root)
    {
        if (root == null)
            return null;
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count!=0)
        {
            TreeNode cur  = queue.Dequeue();
            TreeNode temp = cur.left;
            cur.left  = cur.right;
            cur.right = temp;

            if (cur.left != null) 
                queue.Enqueue(cur.left);
            if (cur.right != null) 
                queue.Enqueue(cur.right);
        }
        return root;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
