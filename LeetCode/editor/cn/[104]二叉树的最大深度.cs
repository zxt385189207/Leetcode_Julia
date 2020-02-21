//给定一个二叉树，找出其最大深度。
//
// 二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。
//
// 说明: 叶子节点是指没有子节点的节点。
//
// 示例：
//给定二叉树 [3,9,20,null,null,15,7]，
//
//     3
//   / \
//  9  20
//    /  \
//   15   7
//
// 返回它的最大深度 3 。
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
        /// <summary>
        /// 直观的方法是通过递归来解决问题。
        /// 空间复杂度:线性表最差O(n)、二叉树完全平衡最好O(logn)
        /// 时间复杂度O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            // 返回左子树的深度
            int leftHeight = MaxDepth(root.left);
            // 返回右子树的深度
            int rightHeight = MaxDepth(root.right);

            // 叶子节点 = 1 + Max(0 , 0)
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        /// <summary>
        /// 迭代 BFS层次遍历思想(宽度优先搜索 又称广度优先搜索)
        /// 所有因为展开节点而得到的子节点都会被加进一个先进先出的队列中(队列或者链表)。
        /// 时间复杂度O(n)
        /// 空间复杂度:线性表最差O(n)、二叉树完全平衡最好O(logn)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth2(TreeNode root)
        {
            if (root == null)
                return 0;

            //BFS的层次遍历思想，记录二叉树的层数，
            //横向遍历完，层数即为最大深度
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int maxDepth = 0;

            while (queue.Count != 0)
            {
                // 记录深度
                maxDepth++;
                // 队列里的个数
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    // 从左到右依次出队,
                    TreeNode node = queue.Dequeue();
                    if (node.left != null)
                        queue.Enqueue(node.left);

                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }
            return maxDepth;
        }

        /// <summary>
        /// 迭代, DFS的层次遍历思想(深度优先搜索)
        /// 对每一个可能的分支路径深入到不能再深入为止, 用的一个先进后出的栈
        /// 时间复杂度O(n)
        /// 空间复杂度:线性表最差O(n)、二叉树完全平衡最好O(logn)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth3(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Stack<KeyValuePair<TreeNode, Int32>> stack = new Stack<KeyValuePair<TreeNode, Int32>>();

            // 放入根节点, 深度为1
            stack.Push(new KeyValuePair<TreeNode, Int32>(root, 1));

            int maxDepth = 0;
            // DFS实现前序遍历，每个节点记录其所在深度
            // 栈中元素不为0 继续遍历
            while (stack.Count != 0)
            {
                KeyValuePair<TreeNode, Int32> pair = stack.Pop();
                TreeNode                      node = pair.Key;

                //DFS过程不断比较更新最大深度
                maxDepth = Math.Max(maxDepth, pair.Value);
                //记录当前节点所在深度
                int curDepth = pair.Value;

                // 当前节点的子节点入栈，同时深度+1
                // 先放右子节点,因为是stack 先进后出, 后入先出
                if (node.right != null)
                {
                    stack.Push(new KeyValuePair<TreeNode, Int32>(node.right, curDepth + 1));
                }

                // 再放左子节点
                if (node.left != null)
                {
                    stack.Push(new KeyValuePair<TreeNode, Int32>(node.left, curDepth + 1));
                }
            }

            return maxDepth;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
