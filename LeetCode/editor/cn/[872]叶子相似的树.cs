//请考虑一颗二叉树上所有的叶子，这些叶子的值按从左到右的顺序排列形成一个 叶值序列 。 
//
// 
//
// 举个例子，如上图所示，给定一颗叶值序列为 (6, 7, 4, 9, 8) 的树。 
//
// 如果有两颗二叉树的叶值序列是相同，那么我们就认为它们是 叶相似 的。 
//
// 如果给定的两个头结点分别为 root1 和 root2 的树是叶相似的，则返回 true；否则返回 false 。 
//
// 
//
// 提示： 
//
// 
// 给定的两颗树可能会有 1 到 100 个结点。 
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
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        Dfs(root1, list1);
        Dfs(root2, list2);
        return list1.SequenceEqual(list2);
    }

    public void Dfs(TreeNode root, List<int> list)
    {
        if (root == null)
            return;
        if (root.left == null && root.right == null)
            list.Add(root.val);
        Dfs(root.left, list);
        Dfs(root.right, list);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
