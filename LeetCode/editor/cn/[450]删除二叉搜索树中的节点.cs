//给定一个二叉搜索树的根节点 root 和一个值 key，删除二叉搜索树中的 key 对应的节点，并保证二叉搜索树的性质不变。返回二叉搜索树（有可能被更新）的
//根节点的引用。 
//
// 一般来说，删除节点可分为两个步骤： 
//
// 
// 首先找到需要删除的节点； 
// 如果找到了，删除它。 
// 
//
// 说明： 要求算法时间复杂度为 O(h)，h 为树的高度。 
//
// 示例: 
//
// 
//root = [5,3,6,2,4,null,7]
//key = 3
//
//    5
//   / \
//  3   6
// / \   \
//2   4   7
//
//给定需要删除的节点值是 3，所以我们首先找到 3 这个节点，然后删除它。
//
//一个正确的答案是 [5,4,6,2,null,null,7], 如下图所示。
//
//    5
//   / \
//  4   6
// /     \
//2       7
//
//另一个正确答案是 [5,2,6,null,4,null,7]。
//
//    5
//   / \
//  2   6
//   \   \
//    4   7
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
    // 后继节点: 也就是右子树第一个left节点
    // 中序遍历, 该节点后一位节点
    public int Successor(TreeNode root)
    {
        root = root.right;
        while (root.left != null)
            root = root.left;
        return root.val;
    }

    // 前驱节点:也就是左子树最后一个Right节点
    // 中序遍历, 该节点前一位节点
    public int Predecessor(TreeNode root)
    {
        root = root.left;
        while (root.right != null)
            root = root.right;
        return root.val;
    }

    // 一种使整体操作变化最小的方法: 用前驱和后继节点来替换删除节点的方式
    // 之所以整体变化最小,是因为不会更改其他的节点层次
    // 如果整体上移, 那子树的层次都要递增
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null) return null;

        // 递归搜索: 删除的节点在右子树
        if (key > root.val)
            root.right = DeleteNode(root.right, key);
        // 递归搜索: 删除的节点在左子树
        else if (key < root.val)
            root.left = DeleteNode(root.left, key);
        // 删除当前节点
        else
        {
            // 第一种情况, 左右子树都是空, 直接删除当前节点
            if (root.left == null && root.right == null)
                root = null;
            // 第二种情况: 如果右子树不为空, 则获取当前节点的后继节点
            // 左子树是否为空都没关系
            else if (root.right != null)
            {
                // 后继节点的值替换到当前节点
                root.val = Successor(root);
                // 去右子树把后继节点给删了
                root.right = DeleteNode(root.right, root.val);
            }
            // 第三种情况: 左子树不为空,右子树为空 , 则获取当前节点的前驱节点
            // 删除前驱节点的值
            else
            {
                // 前驱节点的值替换到当前节点
                root.val = Predecessor(root);
                // 去左子树把后继节点给删了
                root.left = DeleteNode(root.left, root.val);
            }
        }

        return root;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
