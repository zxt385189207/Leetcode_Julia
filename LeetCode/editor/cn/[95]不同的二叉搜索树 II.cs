//给定一个整数 n，生成所有由 1 ... n 为节点所组成的二叉搜索树。 
//
// 示例: 
//
// 输入: 3
//输出:
//[
//  [1,null,3,2],
//  [3,2,null,1],
//  [3,1,null,null,2],
//  [2,1,3],
//  [1,null,2,null,3]
//]
//解释:
//以上的输出对应以下 5 种不同结构的二叉搜索树：
//
//   1         3     3      2      1
//    \       /     /      / \      \
//     3     2     1      1   3      2
//    /     /       \                 \
//   2     1         2                 3
// 
// Related Topics 树 动态规划


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
    public IList<TreeNode> GenerateTrees(int n)
    {
        if (n < 1)
        {
            return new List<TreeNode>();
        }

        return GenerateSubTrees(1, n);
    }

    private List<TreeNode> GenerateSubTrees(int start, int end)
    {
        // 每次递归就要创建一个List, 存放以i为根节点的二叉搜索树
        List<TreeNode> res = new List<TreeNode>();
        // 结束条件, 起始索引大于结束索引, 那一侧是null
        // 相等的情况是某侧只有一个节点
        if (start > end)
        {
            res.Add(null);
            return res;
        }
        // 取出数字 i，作为当前树的树根。于是，
        // 剩余 i - 1 个元素可用于左子树，n - i 个元素用于右子树。
        for (int i = start; i <= end; i++)
        {
            // 分别递归左子树和右子树
            List<TreeNode> leftSubTrees  = GenerateSubTrees(start, i - 1);
            List<TreeNode> rightSubTrees = GenerateSubTrees(i + 1, end);
            // 子节点为null的话, list里也有存在一个null元素节点
            // 排列组合, 每种情况都放入res结果
            foreach (TreeNode left in leftSubTrees)
            {
                foreach (TreeNode right in rightSubTrees)
                {
                    var node = new TreeNode(i);
                    node.left  = left;
                    node.right = right;
                    res.Add(node);
                }
            }
        }
        // 返回的是列表存放了不同的组合
        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
