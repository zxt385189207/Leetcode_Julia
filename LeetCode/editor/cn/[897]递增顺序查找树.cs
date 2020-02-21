//给定一个树，按中序遍历重新排列树，使树中最左边的结点现在是树的根，并且每个结点没有左子结点，只有一个右子结点。 
//
// 
//
// 示例 ： 
//
// 输入：[5,3,6,2,4,null,8,1,null,null,null,7,9]
//
//       5
//      / \
//    3    6
//   / \    \
//  2   4    8
// /        / \ 
//1        7   9
//
//输出：[1,null,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9]
//
// 1
//  \
//   2
//    \
//     3
//      \
//       4
//        \
//         5
//          \
//           6
//            \
//             7
//              \
//               8
//                \
//                 9  
//
// 
//
// 提示： 
//
// 
// 给定树中的结点数介于 1 和 100 之间。 
// 每个结点都有一个从 0 到 1000 范围内的唯一整数值。 
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
    // 做一个哨兵节点, 想成链表,保存前一个节点来连接, 中序遍历
    TreeNode preNode;
    public TreeNode IncreasingBST(TreeNode root) 
    {
        TreeNode dummpy = new TreeNode(0);
        preNode = dummpy;
        DFS(root);
        return dummpy.right;
    }

    public void DFS(TreeNode root)
    {
        if(root==null) return;
        
        DFS(root.left);
        root.left     = null;
        preNode.right = root;
        preNode       = root;
        DFS(root.right);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
