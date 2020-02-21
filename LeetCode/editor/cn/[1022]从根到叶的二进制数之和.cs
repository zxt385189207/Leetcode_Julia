//给出一棵二叉树，其上每个结点的值都是 0 或 1 。每一条从根到叶的路径都代表一个从最高有效位开始的二进制数。例如，如果路径为 0 -> 1 -> 1 ->
// 0 -> 1，那么它表示二进制数 01101，也就是 13 。 
//
// 对树上的每一片叶子，我们都要找出从根到该叶子的路径所表示的数字。 
//
// 以 10^9 + 7 为模，返回这些数字之和。 
//
// 
//
// 示例： 
//
// 
//
// 输入：[1,0,1,0,1,0,1]
//输出：22
//解释：(100) + (101) + (110) + (111) = 4 + 5 + 6 + 7 = 22
// 
//
// 
//
// 提示： 
//
// 
// 树中的结点数介于 1 和 1000 之间。 
// node.val 为 0 或 1 。 
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
    public int SumRootToLeaf(TreeNode root)
    {
        List<string> res  = new List<string>();
        List<string> list = new List<string>();
        int          sum  = 0;
        if (root == null)
            return sum;
        // 存储节点深度
        Stack<(TreeNode, int)> stack = new Stack<(TreeNode, int)>();
        stack.Push((root, 0));

        while (stack.Count > 0)
        {
            (TreeNode, int) cur = stack.Pop();
            // 判断深度,删掉后半部分
            if (list.Count > cur.Item2)
                list.RemoveRange(cur.Item2, list.Count - cur.Item2);

            list.Add(cur.Item1.val.ToString());
            
            if (cur.Item1.left == null && cur.Item1.right == null)
                res.Add(String.Join("", list)); //用->连接列表中的字符串

            if (cur.Item1.right != null)
                stack.Push((cur.Item1.right, cur.Item2 + 1));
            if (cur.Item1.left != null)
                stack.Push((cur.Item1.left, cur.Item2 + 1));
        }

        foreach (var str in res)
            sum += Convert.ToInt32(str, 2);
        
        
        return sum;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
