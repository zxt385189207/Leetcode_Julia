//给定一个二叉树，返回其按层次遍历的节点值。 （即逐层地，从左到右访问所有节点）。
//
// 例如:
//给定二叉树: [3,9,20,null,null,15,7],
//
//     3
//   / \
//  9  20
//    /  \
//   15   7
//
//
// 返回其层次遍历结果：
//
// [
//  [3],
//  [9,20],
//  [15,7]
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


        // 递归
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            // 结果数组
            List<IList<int>> list = new List<IList<int>>();

            // 如果null就直接返回 否则开始递归
            return root == null ? list : LevelOrder(root, 0, list);
        }
        private List<IList<int>> LevelOrder(TreeNode node, int level, List<IList<int>> list)
        {
            //当前层没有创建数组
            if (list.Count == level)
                list.Add(new List<int>());

            // 将当前节点的值添加到对应的层
            list[level].Add(node.val);

            // 加到对应的层
            if (node.left != null)
                list = LevelOrder(node.left, level + 1, list);

            // 加到对应的层
            if (node.right != null)
                list = LevelOrder(node.right, level + 1, list);

            return list;
        }

        // 迭代
        public IList<IList<int>> LevelOrder2(TreeNode root)
        {
            List<IList<int>> list = new List<IList<int>>(); //结果数组
            if (root == null)
                return list;

            // 节点 深度组成的队列
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
            // 将根节点加入队列中
            queue.Enqueue((root, 0));
            // 迭代
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                // 创建对应层数的数组
                if (list.Count == cur.Item2)
                    list.Add(new List<int>());

                // 将当前节点的值添加到对应的层
                list[cur.Item2].Add(cur.Item1.val);

                // 迭代 把子节点加入队列中, 层数+1
                if (cur.Item1.left != null)
                    queue.Enqueue((cur.Item1.left, cur.Item2 + 1));

                // 迭代 把子节点加入队列中, 层数+1
                if (cur.Item1.right != null)
                    queue.Enqueue((cur.Item1.right, cur.Item2 + 1));
            }

            return list;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
