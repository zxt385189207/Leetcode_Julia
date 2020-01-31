//给定一个二叉树，判断其是否是一个有效的二叉搜索树。 
//
// 假设一个二叉搜索树具有如下特征： 
//
// 
// 节点的左子树只包含小于当前节点的数。 
// 节点的右子树只包含大于当前节点的数。 
// 所有左子树和右子树自身必须也是二叉搜索树。 
// 
//
// 示例 1: 
//
// 输入:
//    2
//   / \
//  1   3
//输出: true
// 
//
// 示例 2: 
//
// 输入:
//    5
//   / \
//  1   4
//     / \
//    3   6
//输出: false
//解释: 输入为: [5,1,4,null,null,3,6]。
//     根节点的值为 5 ，但是其右子节点值为 4 。
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
        /// <summary>
        /// 递归, 需要判断上界限和下界限
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            return helper(root, long.MinValue, long.MaxValue);
        }

        public bool helper(TreeNode node, long lower, long upper)
        {
            if (node == null) return true;

            int val = node.val;

            // val要大于下界限, 小于上界限
            if (val <= lower || val >= upper) return false;


            // 判断子树是不是二叉搜索树BST
            if (!helper(node.right, val, upper)) return false;
            // 判断子树是不是二叉搜索树BST
            if (!helper(node.left, lower, val)) return false;

            return true;
        }


        /// <summary>
        /// 通过使用栈，上面的递归法可以转化为迭代法。
        /// 这里使用深度优先搜索DFS，比广度优先搜索要快一些BFS。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST2(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<long> lowers = new Stack<long>(),
                uppers         = new Stack<long>();

            void Update(TreeNode root, long lower, long upper)
            {
                stack.Push(root);
                lowers.Push(lower);
                uppers.Push(upper);
            }

            long lower = long.MinValue, upper = long.MaxValue, val;
            Update(root, lower, upper);

            while (stack.Count != 0)
            {
                root  = stack.Pop();
                lower = lowers.Pop();
                upper = uppers.Pop();

                if (root == null) continue;
                val = root.val;
                if (val <= lower) return false;
                if (val >= upper) return false;

                Update(root.right, val, upper);
                Update(root.left, lower, val);
            }

            return true;
        }

        /// <summary>
        /// 中序遍历
        /// 左子树 -> 结点 -> 右子树 意味着对于二叉搜索树而言，每个元素都应该比下一个元素小。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST3(TreeNode root)
        {
            Stack<TreeNode> stack   = new Stack<TreeNode>();
            long            inorder = long.MinValue;

            while (stack.Count != 0 || root != null)
            {
                // 中序 left-> node -> right
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                // 出栈, 最后一个被压入的最左下叶子节点(是否是最小)
                // 下一个出栈的是 叶子节点的父节点
                root = stack.Pop();

                if (root.val <= inorder)
                    return false;

                inorder = root.val;
                root    = root.right;
            }

            return true;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
