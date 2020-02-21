//你需要采用前序遍历的方式，将一个二叉树转换成一个由括号和整数组成的字符串。 
//
// 空节点则用一对空括号 "()" 表示。而且你需要省略所有不影响字符串与原始二叉树之间的一对一映射关系的空括号对。 
//
// 示例 1: 
//
// 
//输入: 二叉树: [1,2,3,4]
//       1
//     /   \
//    2     3
//   /    
//  4     
//
//输出: "1(2(4))(3)"
//
//解释: 原本将是“1(2(4)())(3())”，
//在你省略所有不必要的空括号对之后，
//它将是“1(2(4))(3)”。
// 
//
// 示例 2: 
//
// 
//输入: 二叉树: [1,2,3,null,4]
//       1
//     /   \
//    2     3
//     \  
//      4 
//
//输出: "1(2()(4))(3)"
//
//解释: 和第一个示例相似，
//除了我们不能省略第一个对括号来中断输入和输出之间的一对一映射关系。
// 
// Related Topics 树 字符串


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
    public string Tree2str(TreeNode t) 
    {
        // 终止条件
        if (t==null)
            return "";
        
        // 返回处理后的字符串, 不同节点和叶子不同的处理方式
        if (t.left == null && t.right == null)
            return $"{t.val}";
        
        if (t.right == null)
            return $"{t.val}({Tree2str(t.left)})";

        // 这种情况与下面情况相同
        // if (t.left == null)
        //     return $"{t.val}()({Tree2str(t.right)})";
        
        // 左右节点都不为null
        return $"{t.val}({Tree2str(t.left)})({Tree2str(t.right)})";
    }

}
//leetcode submit region end(Prohibit modification and deletion)
