//根据一棵树的前序遍历与中序遍历构造二叉树。 
//
// 注意: 
//你可以假设树中没有重复的元素。 
//
// 例如，给出 
//
// 前序遍历 preorder = [3,9,20,15,7]
//中序遍历 inorder = [9,3,15,20,7] 
//
// 返回如下的二叉树： 
//
//     3
//   / \
//  9  20
//    /  \
//   15   7 
// Related Topics 树 深度优先搜索 数组


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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (inorder == null || inorder.Length == 0 || preorder == null || preorder.Length == 0 ||
            inorder.Length != preorder.Length)
        {
            return null;
        }


        return help(inorder, 0, inorder.Length - 1, preorder, 0, preorder.Length - 1);
    }


    private TreeNode help(int[] inorder, int inStart, int inEnd, int[] preorder, int preStart, int preEnd)
    {
        //递归终止条件
        if (inStart > inEnd || preStart > preEnd)
        {
            return null;
        }

        //前序遍历的第一个节点就是根节点
        TreeNode head = new TreeNode(preorder[preStart]);
        // 左子树节点个数
        int index = 0;
        // 从中序遍历数组中 计数左子树有几个节点
        while (inorder[inStart + index] != preorder[preStart])
        {
            index++;
        }

        // 左子树
        head.left = help(inorder, inStart, inStart + index - 1, preorder, preStart + 1, preStart + index);
        // 右子树
        head.right = help(inorder, inStart + index + 1, inEnd, preorder, preStart + index + 1, preEnd);
        return head;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
