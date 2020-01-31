//统计所有小于非负整数 n 的质数的数量。 
//
// 示例: 
//
// 输入: 10
//输出: 4
//解释: 小于 10 的质数一共有 4 个, 它们是 2, 3, 5, 7 。
// 
// Related Topics 哈希表 数学


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 厄拉多塞筛法
    /// 我们可以声明一个长度为最大限制数的布尔数组。用布尔值来区别筛选出的数和质数。
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int CountPrimes(int n)
    {
        int count = 0;

        // 字节（Byte）可以优化为 位 (bit)
        bool[] signs = new bool[n];

        for (int i = 2; i < n; i++)
        {
            //因为在 C# 中，布尔类型的默认值为 假。所以在此处用了逻辑非（！）操作符。
            if (!signs[i])
            {
                count++;
                // 倍数都标记 例如, 5, 则 10 ,15, 20...都不是质数
                for (int j = i + i; j < n; j += i)
                {
                    //排除不是质数的数
                    signs[j] = true;
                }
            }
        }

        return count;
    }

    /// <summary>
    /// 普通暴力解法, 会超时
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int CountPrimes2(int n)
    {
        int count = 0;
        for (int i = 2; i < n; i++)
        {
            if (IsPrime(i))
                count++;
        }
        return count;
    }

    // 判断整数 n 是否是素数
    bool IsPrime(int n)
    {
        // 可优化成不需要遍历到 n，而只需要到 sqrt(n)
        // 如果在 [2,sqrt(n)] 这个区间之内没有发现可整除因子，就可以直接断定 n 是素数了
        for (int i = 2; i < n; i++)
            if (n % i == 0)
                // 有其他整除因子
                return false;
            
        return true;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
