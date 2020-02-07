//给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。 
//
// 百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（
//一个节点也可以是它自己的祖先）。” 
//
// 例如，给定如下二叉树: root = [3,5,1,6,2,0,8,null,null,7,4] 
//
// 
//
// 
//
// 示例 1: 
//
// 输入: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
//输出: 3
//解释: 节点 5 和节点 1 的最近公共祖先是节点 3。
// 
//
// 示例 2: 
//
// 输入: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
//输出: 5
//解释: 节点 5 和节点 4 的最近公共祖先是节点 5。因为根据定义最近公共祖先节点可以为节点本身。
// 
//
// 
//
// 说明: 
//
// 
// 所有节点的值都是唯一的。 
// p、q 为不同节点且均存在于给定的二叉树中。 
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

    // 递归1
    // 此方法总是要遍历全部节点
    //left=1，right=1，mid=0  如果一个节点的左右都能达到终点，那么当前节点一定是公共祖先。
    //left=1，right=0，mid=1  如果当前节点左树可以找到一个值，当前节点值等于另一个值，那么祖先就是当前值。
    //left=0，right=1，mid=1  如果当前节点右树可以找到一个值，当前节点值等于另一个值，那么祖先就是当前值。
    private bool RecurseTree(TreeNode currentNode, TreeNode p, TreeNode q, ref TreeNode ans)
    {
        if (currentNode == null)
        {
            return false;
        }

        int left = RecurseTree(currentNode.left, p, q, ref ans) ? 1 : 0;

        int right = RecurseTree(currentNode.right, p, q, ref ans) ? 1 : 0;

        // 判断当前节点是否是pq
        int mid = currentNode == p || currentNode == q ? 1 : 0;


        if (mid + left + right >= 2)
        {
            ans = currentNode;
        }

        return mid + left + right > 0;
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode ans = null;
        RecurseTree(root, p, q, ref ans);
        return ans;
    }

    // 递归2
    //  root 为根节点的树上是否有p节点或者q节点
    // 有，返回p节点或q节点
    // 无，返回null
    // 左、右子树均能找到
    //    说明此时的p节点和q节点在当前root节点两侧，返回root节点
    public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
    {
        // 如果根节点是PQ之一, 那PQ公共祖先就是根节点
        if (root == null || root == p || root == q)
        {
            return root;
        }

        TreeNode left  = LowestCommonAncestor1(root.left, p, q);
        TreeNode right = LowestCommonAncestor1(root.right, p, q);
        if (left != null && right != null)
        {
            return root;
        }

        return left != null ? left : right;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
