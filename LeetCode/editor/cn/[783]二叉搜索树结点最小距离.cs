//给定一个二叉搜索树的根结点 root, 返回树中任意两节点的差的最小值。 
//
// 示例： 
//
// 
//输入: root = [4,2,6,1,3,null,null]
//输出: 1
//解释:
//注意，root是树结点对象(TreeNode object)，而不是数组。
//
//给定的树 [4,2,6,1,3,null,null] 可表示为下图:
//
//          4
//        /   \
//      2      6
//     / \    
//    1   3  
//
//最小的差值是 1, 它是节点1和节点2的差值, 也是节点3和节点2的差值。 
//
// 注意： 
//
// 
// 二叉树的大小范围在 2 到 100。 
// 二叉树总是有效的，每个节点的值都是整数，且不重复。 
// 
// Related Topics 树 递归


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
    private int res = int.MaxValue;

    public int MinDiffInBST(TreeNode root) 
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();

        TreeNode cur     = root;
        TreeNode preNode = null;
       
        while (cur!=null || stack.Count!=0)
        {
            while (cur!=null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            cur = stack.Pop();
            if (preNode!=null)
            {
                res = Math.Min(res, Math.Abs(cur.val - preNode.val));
            }

            preNode = cur;
            cur     = cur.right;
        }

        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
