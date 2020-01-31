//给定一个二叉树，检查它是否是镜像对称的。 
//
// 例如，二叉树 [1,2,2,3,4,4,3] 是对称的。 
//
//     1
//   / \
//  2   2
// / \ / \
//3  4 4  3
// 
//
// 但是下面这个 [1,2,2,null,3,null,3] 则不是镜像对称的: 
//
//     1
//   / \
//  2   2
//   \   \
//   3    3
// 
//
// 说明: 
//
// 如果你可以运用递归和迭代两种方法解决这个问题，会很加分。 
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
    /// <summary>
    /// 递归
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public bool IsSymmetric(TreeNode root)
    {
        return isMirror(root, root);
    }

    public bool isMirror(TreeNode t1, TreeNode t2)
    {
        if (t1 == null && t2 == null)
            return true;

        if (t1 == null || t2 == null)
            return false;

        return (t1.val == t2.val) // 判断镜像值是否相等
               && isMirror(t1.right, t2.left)
               && isMirror(t1.left, t2.right);
    }


    /// <summary>
    /// 迭代, 用queue队列, 将节点两两放入队列, 再取出对比,
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public bool IsSymmetric2(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        // 对称加入2个节点
        queue.Enqueue(root);
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            // 一次性出队2个节点
            TreeNode t1 = queue.Dequeue();
            TreeNode t2 = queue.Dequeue();
                
            // 
            if (t1 == null && t2 == null) 
                continue;
            // 其中有一个节点是null, 另一个不是null 则不是对称二叉树
            if (t1 == null || t2 == null) 
                return false;
            // 值不同也不是对称二叉树
            if (t1.val != t2.val) 
                return false;
                
            // 根据镜像的顺序加入4个子节点,
            queue.Enqueue(t1.left);
            queue.Enqueue(t2.right);
            queue.Enqueue(t1.right);
            queue.Enqueue(t2.left);
        }

        return true;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
