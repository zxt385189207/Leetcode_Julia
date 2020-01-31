//给定一个二叉树，返回其节点值自底向上的层次遍历。 （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历） 
//
// 例如： 
//给定二叉树 [3,9,20,null,null,15,7], 
//
//     3
//   / \
//  9  20
//    /  \
//   15   7
// 
//
// 返回其自底向上的层次遍历为： 
//
// [
//  [15,7],
//  [9,20],
//  [3]
//]
// 
// Related Topics 树 广度优先搜索


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
    /// <summary>
    /// 迭代 BFS(广度) 与102相同, 只是最后反转数组
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        IList<IList<int>> list = new List<IList<int>>(); //结果数组
        if (root == null)
        {
            return list;
        }

        // 节点 层,数据对组成的队列
        Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
        // 将根节点加入队列中
        queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));
        // 迭代
        while (queue.Count > 0)
        {
            var kvp = queue.Dequeue();

            // 创建对应层数的数组
            if (list.Count == kvp.Value)
            {
                list.Add(new List<int>());
            }

            // 将当前节点的值添加到对应的层
            list[kvp.Value].Add(kvp.Key.val);

            // 迭代 把子节点加入队列中, 层数+1
            if (kvp.Key.left != null)
            {
                queue.Enqueue(new KeyValuePair<TreeNode, int>(kvp.Key.left, kvp.Value + 1));
            }

            // 迭代 把子节点加入队列中, 层数+1
            if (kvp.Key.right != null)
            {
                queue.Enqueue(new KeyValuePair<TreeNode, int>(kvp.Key.right, kvp.Value + 1));
            }
        }

        // 反转
        return list.Reverse().ToList();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
