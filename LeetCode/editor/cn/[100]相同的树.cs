//给定两个二叉树，编写一个函数来检验它们是否相同。 
//
// 如果两个树在结构上相同，并且节点具有相同的值，则认为它们是相同的。 
//
// 示例 1: 
//
// 输入:       1         1
//          / \       / \
//         2   3     2   3
//
//        [1,2,3],   [1,2,3]
//
//输出: true 
//
// 示例 2: 
//
// 输入:      1          1
//          /           \
//         2             2
//
//        [1,2],     [1,null,2]
//
//输出: false
// 
//
// 示例 3: 
//
// 输入:       1         1
//          / \       / \
//         2   1     1   2
//
//        [1,2,1],   [1,1,2]
//
//输出: false
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
public class Solution 
{
    /// <summary>
        /// 递归
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (q == null || p == null) return false;

            if (p.val != q.val)
                return false;
            return IsSameTree(p.right, q.right) && IsSameTree(p.left, q.left);
        }

        /// <summary>
        /// 迭代 BFS
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree2(TreeNode p, TreeNode q)
        {
            Queue<TreeNode> queue1 = new Queue<TreeNode>(); // 存储所有等待处理的节点
            Queue<TreeNode> queue2 = new Queue<TreeNode>(); // 存储所有等待处理的节点

            int step = 0; //从根节点到当前节点需要的步骤数

            queue1.Enqueue(p);
            queue2.Enqueue(q);

            while (queue1.Count != 0 && queue2.Count != 0)
            {
                step += 1;

                if (queue1.Count != queue2.Count) return false;

                TreeNode temp1 = queue1.Dequeue();
                TreeNode temp2 = queue2.Dequeue();

                if (temp1 == null && temp2 == null)
                    continue;
                if (temp1 == null || temp2 == null)
                    return false;
                if (temp1.val != temp2.val)
                    return false;


                queue1.Enqueue(temp1.left);
                queue1.Enqueue(temp1.right);
                queue2.Enqueue(temp2.left);
                queue2.Enqueue(temp2.right);
            }

            return true;
        } 
    
}
//leetcode submit region end(Prohibit modification and deletion)
