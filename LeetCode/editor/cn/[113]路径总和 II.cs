//给定一个二叉树和一个目标和，找到所有从根节点到叶子节点路径总和等于给定目标和的路径。 
//
// 说明: 叶子节点是指没有子节点的节点。 
//
// 示例: 
//给定如下二叉树，以及目标和 sum = 22， 
//
//               5
//             / \
//            4   8
//           /   / \
//          11  13  4
//         /  \    / \
//        7    2  5   1
// 
//
// 返回: 
//
// [
//   [5,4,11,2],
//   [5,8,4,5]
//]
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
    // 递归
    public IList<IList<int>> PathSum(TreeNode root, int sum)
    {
        var result     = new List<IList<int>>();
        var innerArray = new List<int>();
        Helper(root, sum, result, innerArray);
        return result;
    }

    private void Helper(TreeNode root, int sum, List<IList<int>> result, List<int> innerArray)
    {
        if (root == null)
            return;

        innerArray.Add(root.val);
        if (root.val == sum && root.left == null && root.right == null)
            result.Add(new List<int>(innerArray));
        
        Helper(root.left, sum - root.val, result, innerArray);
        Helper(root.right, sum - root.val, result, innerArray);
        innerArray.RemoveAt(innerArray.Count - 1);
    }

    // 迭代
    public IList<IList<int>> PathSum2(TreeNode root, int sum)
    {
        List<IList<int>> res = new List<IList<int>>();

        if (root == null)
            return res;
        List<int>              list  = new List<int>();
        Stack<(TreeNode, int)> stack = new Stack<(TreeNode, int)>();
        stack.Push((root, 0));
        while (stack.Count > 0)
        {
            (TreeNode, int) cur = stack.Pop();

            if (list.Count > cur.Item2)
                list.RemoveRange(cur.Item2, list.Count - cur.Item2);

            list.Add(cur.Item1.val);

            if (cur.Item1.left == null && cur.Item1.right == null)
                if (list.Sum() == sum)
                    res.Add(new List<int>(list));


            if (cur.Item1.right != null)
                stack.Push((cur.Item1.right, cur.Item2 + 1));
            if (cur.Item1.left != null)
                stack.Push((cur.Item1.left, cur.Item2 + 1));
        }

        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
