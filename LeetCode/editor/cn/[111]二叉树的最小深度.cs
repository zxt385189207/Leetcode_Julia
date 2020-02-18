//给定一个二叉树，找出其最小深度。 
//
// 最小深度是从根节点到最近叶子节点的最短路径上的节点数量。 
//
// 说明: 叶子节点是指没有子节点的节点。 
//
// 示例: 
//
// 给定二叉树 [3,9,20,null,null,15,7], 
//
//     3
//   / \
//  9  20
//    /  \
//   15   7 
//
// 返回它的最小深度 2. 
// Related Topics 树 深度优先搜索 广度优先搜索


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
    // BFS
    public int MinDepth(TreeNode root)
    {
        if (root == null)
            return 0;
        Queue<TreeNode>           queue = new Queue<TreeNode>();
        Dictionary<TreeNode, int> dic   = new Dictionary<TreeNode, int>();

        int step = 0;

        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            step += 1;
            // 遍历当前一层所有节点, 并将它们的子节点都加入到队列中
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode cur = queue.Dequeue();
                if (cur.left == null && cur.right == null)
                    dic[cur] = step;
                if (cur.left != null)
                    queue.Enqueue(cur.left);
                if (cur.right != null)
                    queue.Enqueue(cur.right);
            }
        }

        return dic.OrderBy(x => x.Value).First().Value;
    }

    // 递归
    public int MinDepth1(TreeNode root)
    {
        if (root == null)
            return 0;
        return GetMinDepth(root);
    }

    public int GetMinDepth(TreeNode node)
    {
        // 叶子节点
        if (node.left == null && node.right == null)
            return 1;
        if (node.right == null)
            return GetMinDepth(node.left) + 1;
        if (node.left == null)
            return GetMinDepth(node.right) + 1;

        // 左右叶子节点都不为null, 需要比较他们的大小
        int leftDepth  = GetMinDepth(node.left);
        int rightDepth = GetMinDepth(node.right);

        return leftDepth > rightDepth ? rightDepth + 1 : leftDepth + 1;
    }

    // 递归简化写法
    public int MinDepth2(TreeNode root)
    {
        if (root == null) return 0;

        int depthL = MinDepth2(root.left);
        int depthR = MinDepth2(root.right);

        if (depthL == 0 || depthR == 0)
            return depthL + depthR + 1;
        return Math.Min(depthL, depthR) + 1;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
