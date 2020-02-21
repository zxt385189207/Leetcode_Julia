//给定一个二叉树，返回所有从根节点到叶子节点的路径。 
//
// 说明: 叶子节点是指没有子节点的节点。 
//
// 示例: 
//
// 输入:
//
//   1
// /   \
//2     3
// \
//  5
//
//输出: ["1->2->5", "1->3"]
//
//解释: 所有根节点到叶子节点的路径为: 1->2->5, 1->3 
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
    // 迭代
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        List<string> res  = new List<string>();
        List<string> list = new List<string>();
        if (root == null)
            return list;
        // 存储节点深度
        Stack<(TreeNode, int)> stack = new Stack<(TreeNode, int)>();
        stack.Push((root, 0));

        while (stack.Count > 0)
        {
            (TreeNode, int) cur = stack.Pop();
            // 判断深度,删掉后半部分
            if (list.Count > cur.Item2)
                list.RemoveRange(cur.Item2, list.Count - cur.Item2);

            list.Add(cur.Item1.val.ToString());
            // 直到叶子节点才连接当前列表中的字符串
            if (cur.Item1.left == null && cur.Item1.right == null)
                res.Add(String.Join("->", list)); //用->连接列表中的字符串

            if (cur.Item1.right != null)
                stack.Push((cur.Item1.right, cur.Item2 + 1));
            if (cur.Item1.left != null)
                stack.Push((cur.Item1.left, cur.Item2 + 1));
        }
        return res;
    }

    // 递归
    public IList<string> BinaryTreePaths2(TreeNode root)
    {
        List<string> result = new List<string>();
        if (root == null)
            return result;
        if (root.left == null && root.right == null)
        {
            result.Add(root.val.ToString());
            return result;
        }
        if (root.left != null)
            foreach (var item in BinaryTreePaths2(root.left))
                result.Add(root.val + "->" + item);
        if (root.right != null)
            foreach (var item in BinaryTreePaths2(root.right))
                result.Add(root.val + "->" + item);
        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
