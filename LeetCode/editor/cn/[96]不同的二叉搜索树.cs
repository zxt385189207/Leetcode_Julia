//给定一个整数 n，求以 1 ... n 为节点组成的二叉搜索树有多少种？ 
//
// 示例: 
//
// 输入: 3
//输出: 5
//解释:
//给定 n = 3, 一共有 5 种不同结构的二叉搜索树:
//
//   1         3     3      2      1
//    \       /     /      / \      \
//     3     2     1      1   3      2
//    /     /       \                 \
//   2     1         2                 3 
// Related Topics 树 动态规划


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 对于根 i 的不同二叉搜索树数量 F(i, n)F(i,n)，是左右子树个数的笛卡尔积
    // F(3,7) =G(2)⋅G(4)。 以3为根,长度为7的序列, 个数=左*右,
    // 当序列长度为 1 （只有根）或为 0 （空树）时，只有一种情况G[0]=G[1]=1
    public int NumTrees(int n)
    {
        int[] G = new int[n + 1];
        G[0] = 1;
        G[1] = 1;

        for (int i = 2; i <= n; ++i)
        {
            for (int j = 1; j <= i; ++j)
            {
                G[i] += G[j - 1] * G[i - j];
            }
        }
        return G[n];
    }

}
//leetcode submit region end(Prohibit modification and deletion)
