//给定一个非空二叉树, 返回一个由每层节点平均值组成的数组. 
//
// 示例 1: 
//
// 输入:
//    3
//   / \
//  9  20
//    /  \
//   15   7
//输出: [3, 14.5, 11]
//解释:
//第0层的平均值是 3,  第1层是 14.5, 第2层是 11. 因此返回 [3, 14.5, 11].
// 
//
// 注意： 
//
// 
// 节点值的范围在32位有符号整数范围内。 
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
    public IList<double> AverageOfLevels(TreeNode root)
    {
        List<double> list = new List<double>();
        if (root == null)
            return list;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            long sum       = 0;
            int  levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++)
            {
                // 从左到右依次出队,
                TreeNode node = queue.Dequeue();
                sum += node.val;
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            list.Add((double)sum/levelSize);
        }
        return list;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
