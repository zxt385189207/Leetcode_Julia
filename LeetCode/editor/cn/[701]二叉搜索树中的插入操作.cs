//给定二叉搜索树（BST）的根节点和要插入树中的值，将值插入二叉搜索树。 返回插入后二叉搜索树的根节点。 保证原始二叉搜索树中不存在新值。 
//
// 注意，可能存在多种有效的插入方式，只要树在插入后仍保持为二叉搜索树即可。 你可以返回任意有效的结果。 
//
// 例如, 
//
// 
//给定二叉搜索树:
//
//        4
//       / \
//      2   7
//     / \
//    1   3
//
//和 插入的值: 5
// 
//
// 你可以返回这个二叉搜索树: 
//
// 
//         4
//       /   \
//      2     7
//     / \   /
//    1   3 5
// 
//
// 或者这个树也是有效的: 
//
// 
//         5
//       /   \
//      2     7
//     / \   
//    1   3
//         \
//          4
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
    // 递归
    // 空间复杂度O(H) 树的高度, 递归过程中堆栈使用的空间
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null)
            return new TreeNode(val);

        if (val > root.val)
            root.right = InsertIntoBST(root.right, val);
        else
            root.left = InsertIntoBST(root.left, val);

        return root;
    }

    // 迭代
    // 空间复杂度O(1)
    public TreeNode InsertIntoBST1(TreeNode root, int val)
    {
        TreeNode node = root;
        while (node != null)
        {
            // 值>节点 在右子树里判断
            if (val > node.val)
            {
                // 判断右子树的节点
                if (node.right == null)
                {
                    node.right = new TreeNode(val);
                    return root;
                }

                node = node.right;
            }
            // 左子树里判断
            else
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(val);
                    return root;
                }

                node = node.left;
            }
        }
        // 如果传入的节点是null,则返回一个新节点
        return new TreeNode(val);
    }

}
//leetcode submit region end(Prohibit modification and deletion)
