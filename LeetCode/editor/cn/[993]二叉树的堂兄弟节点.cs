//在二叉树中，根节点位于深度 0 处，每个深度为 k 的节点的子节点位于深度 k+1 处。 
//
// 如果二叉树的两个节点深度相同，但父节点不同，则它们是一对堂兄弟节点。 
//
// 我们给出了具有唯一值的二叉树的根节点 root，以及树中两个不同节点的值 x 和 y。 
//
// 只有与值 x 和 y 对应的节点是堂兄弟节点时，才返回 true。否则，返回 false。 
//
// 
//
// 示例 1： 
// 
//
// 输入：root = [1,2,3,4], x = 4, y = 3
//输出：false
// 
//
// 示例 2： 
// 
//
// 输入：root = [1,2,3,null,4,null,5], x = 5, y = 4
//输出：true
// 
//
// 示例 3： 
//
// 
//
// 输入：root = [1,2,3,null,4], x = 2, y = 3
//输出：false 
//
// 
//
// 提示： 
//
// 
// 二叉树的节点数介于 2 到 100 之间。 
// 每个节点的值都是唯一的、范围为 1 到 100 的整数。 
// 
//
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
    // BFS
    public bool IsCousins(TreeNode root, int x, int y)
    {
        if (root == null || root.val == x || root.val == y)
            return false;
        Queue<TreeNode> queue = new Queue<TreeNode>();

        // 记录找到的两个节点
        (int, int)[] temp  = new (int, int)[2];
        int          index = 0;

        // 根节点到当前节点需要的步数
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
                // 因为后续节点肯定不是前一个节点的堂兄弟
                if (cur.val == x || cur.val == y)
                    continue;

                if (cur.left != null)
                {
                    queue.Enqueue(cur.left);
                    if (cur.left.val == x || cur.left.val == y)
                        temp[index++] = (cur.val, step);
                }

                if (cur.right != null)
                {
                    queue.Enqueue(cur.right);
                    if (cur.right.val == x || cur.right.val == y)
                        temp[index++] = (cur.val, step);
                }
            }
        }
        if (temp[0].Item1 != temp[1].Item1 && temp[0].Item2 == temp[1].Item2)
            return true;
        return false;
    }


    private int xParent, xDepth;
    private int yParent, yDepth;

    // DFS递归
    public bool IsCousins2(TreeNode root, int x, int y)
    {
        dfs(root.left, 1, root.val, x, y);
        dfs(root.right, 1, root.val, x, y);
        return xDepth == yDepth && xParent != yParent;
    }

    private void dfs(TreeNode root, int depth, int parent, int x, int y)
    {
        // 递归结束条件 1. 节点为null 2. 找到X节点, 3. 找到Y节点
        if (root == null)
            return;
        // 这里之所以可以直接返回, 因为它的子节点肯定不是它的邻居
        if (root.val == x)
        {
            xParent = parent;
            xDepth  = depth;
            return;
        }

        if (root.val == y)
        {
            yParent = parent;
            yDepth  = depth;
            return;
        }

        // 深度加1
        dfs(root.left, 1 + depth, root.val, x, y);
        dfs(root.right, 1 + depth, root.val, x, y);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
