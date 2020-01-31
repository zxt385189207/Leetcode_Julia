//给定一个整数，写一个函数来判断它是否是 3 的幂次方。 
//
// 示例 1: 
//
// 输入: 27
//输出: true
// 
//
// 示例 2: 
//
// 输入: 0
//输出: false 
//
// 示例 3: 
//
// 输入: 9
//输出: true 
//
// 示例 4: 
//
// 输入: 45
//输出: false 
//
// 进阶： 
//你能不使用循环或者递归来完成本题吗？ 
// Related Topics 数学


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 最简单方法迭代,
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool IsPowerOfThree(int n)
    {
        // 哨兵判断, 防止while中n=0进入无限循环
        if (n < 1)
        {
            return false;
        }

        // n不能为0
        // 先判断%3是否为0, 不为0 结果是1,2 
        while (n % 3 == 0)
        {
            n /= 3;
        }

        return n == 1;
    }

    /// <summary>
    /// 用最大的幂次数来限制
    /// 这种方法迭代次数越高性能越好, 用处不大
    /// </summary>
    public bool IsPowerOfThree2(int n)
    {
        return n > 0 && 1162261467 % n == 0;
    }
    
}
//leetcode submit region end(Prohibit modification and deletion)
