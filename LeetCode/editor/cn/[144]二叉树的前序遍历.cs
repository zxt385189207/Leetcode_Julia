//给定一个二叉树，返回它的 前序 遍历。
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
//输出: [1,2,3]
//
//
// 进阶: 递归算法很简单，你可以通过迭代算法完成吗？
// Related Topics 栈 树


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
    // 前序: 先根节点->左子节点->右子节点
    // 入栈顺序就是先放右子节点, 再放左子节点
    public IList<int> PreorderTraversal(TreeNode root)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        IList<int>      list  = new List<int>();

        if (root == null)
            return list;
        stack.Push(root);

        while (stack.Count!=0)
        {
            TreeNode cur = stack.Pop();
            list.Add(cur.val);

            if (cur.right!=null)
                stack.Push(cur.right);
            if (cur.left!=null)
                stack.Push(cur.left);
        }
        return list;
    }
        
    // 递归
    public IList<int> PreorderTraversal2(TreeNode root)
    {
        List<int> res = new List<int>();
        if (root == null)
            return res;

        Traverse(root, res);
        return res;
    }

    private void Traverse(TreeNode root, List<int> res)
    {
        if (root == null)
            return;

        res.Add(root.val);
        // 先递归左字节节点
        Traverse(root.left, res);
    }

}
//leetcode submit region end(Prohibit modification and deletion)
