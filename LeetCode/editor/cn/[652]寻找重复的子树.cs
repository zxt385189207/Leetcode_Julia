//给定一棵二叉树，返回所有重复的子树。对于同一类的重复子树，你只需要返回其中任意一棵的根结点即可。 
//
// 两棵树重复是指它们具有相同的结构以及相同的结点值。 
//
// 示例 1： 
//
//         1
//       / \
//      2   3
//     /   / \
//    4   2   4
//       /
//      4
// 
//
// 下面是两个重复的子树： 
//
//       2
//     /
//    4
// 
//
// 和 
//
//     4
// 
//
// 因此，你需要以列表的形式返回上述重复子树的根结点。 
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
    private readonly IDictionary<string, int> _dict = new Dictionary<string, int>();
    private readonly IList<TreeNode>          res   = new List<TreeNode>();
    // DFS 深度遍历, 把子串序列化成字符串, 放入Hash字典中
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        if (root == null) 
            return res;

        PrintNode(root);

        return res;
    }
    // 序列化子节点成字符串, 放入字典中,判断是否重复
    private string PrintNode(TreeNode node)
    {
        if (node == null) 
            return "#";
        // 进入递归
        // 先放入最小的子串, 深度遍历搜索
        string str = node.val + PrintNode(node.left) + PrintNode(node.right);
        if (!_dict.ContainsKey(str))
        {
            _dict.Add(str, 1);
        }
        // 对于同一类的重复子树，你只需要返回其中任意一棵的根结点即可。 
        else if (_dict[str] == 1)
        {
            res.Add(node);
            _dict[str]++;
        }

        return str;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
