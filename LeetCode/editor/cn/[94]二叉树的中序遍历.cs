//给定一个二叉树，返回它的中序 遍历。 
//
// 示例: 
//
// 输入: [1,null,2,3]
//   1
//    \
//     2
//    /
//   3
//
//输出: [1,3,2] 
//
// 进阶: 递归算法很简单，你可以通过迭代算法完成吗？ 
// Related Topics 栈 树 哈希表


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

    // 中序: 左子节点-> 根节点->右子节点
    // 栈, 迭代
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int>       res   =n ew List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode        curr  = root;
        while (curr != null || stack.Count != 0)
        {
            // 一直Push左子节点到栈中, 
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }

            curr = stack.Pop();
            res.Add(curr.val);
            curr = curr.right;
        }

        return res;
    }


    /// <summary>
    /// 递归
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> InorderTraversal2(TreeNode root)
    {
        List<int> res = new List<int>();
        helper(root, res);
        return res;
    }

    public void helper(TreeNode root, List<int> res)
    {
        if (root != null)
        {
            if (root.left != null)
            {
                helper(root.left, res);
            }

            res.Add(root.val);
            if (root.right != null)
            {
                helper(root.right, res);
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
