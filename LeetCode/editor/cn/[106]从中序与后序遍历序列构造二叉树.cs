//根据一棵树的中序遍历与后序遍历构造二叉树。 
//
// 注意: 
//你可以假设树中没有重复的元素。 
//
// 例如，给出 
//
// 中序遍历 inorder = [9,3,15,20,7]
//后序遍历 postorder = [9,15,7,20,3] 
//
// 返回如下的二叉树： 
//
//     3
//   / \
//  9  20
//    /  \
//   15   7
// 
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
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        if (inorder == null || inorder.Length == 0 || postorder == null || postorder.Length == 0 ||
            inorder.Length != postorder.Length)
        {
            return null;
        }

        return help(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
    }


    private TreeNode help(int[] inorder, int inStart, int inEnd, int[] postorder, int posStart, int posEnd)
    {
        //递归终止条件
        if (inStart > inEnd || posStart > posEnd)
        {
            return null;
        }

        //后续遍历的最后一个节点就是根节点
        TreeNode head = new TreeNode(postorder[posEnd]);
        // 左子树节点个数
        int index = 0;
        // 从中序遍历数组中 计数左子树有几个节点
        while (inorder[inStart + index] != postorder[posEnd])
        {
            index++;
        }
        // 左子树
        head.left = help(inorder, inStart, inStart + index - 1, postorder, posStart, posStart + index - 1);
        // 右子树
        head.right = help(inorder, inStart + index + 1, inEnd, postorder, posStart + index, posEnd - 1);
        return head;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
