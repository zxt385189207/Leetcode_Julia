/*
 * 假设你正在爬楼梯。需要 n 阶你才能到达楼顶。

每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？

注意：给定 n 是一个正整数。

示例 1：

输入： 2
输出： 2
解释： 有两种方法可以爬到楼顶。
1.  1 阶 + 1 阶
2.  2 阶
示例 2：

输入： 3
输出： 3
解释： 有三种方法可以爬到楼顶。
1.  1 阶 + 1 阶 + 1 阶
2.  1 阶 + 2 阶
3.  2 阶 + 1 阶

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/climbing-stairs
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */

using System;
using System.Linq;
using System.Text;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        /// <summary>
        /// 动态规划
        /// 时间复杂度O(n)
        /// 空间复杂度O(n) new了一个数组
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            // 只有两种方式到达第i阶, 就是从n-1阶爬1阶上去, 还有就是从n-2阶爬2阶上去
            // 那么到达第i阶的方法数 = 到达n-1阶时的方案数 + 到达第n-2阶时的方案数
            // dp[n] = dp[n-1] + dp[n-2]   n>2
            // 当n=3时
            // 到第三阶的方案数 = 到第二阶的方案数 + 到第一阶的方案数
            // 3 = 2 + 1
            // 第4阶 = 第3阶+第2阶
            // 5 = 3 + 2
            if (n == 1)
            {
                return 1;
            }

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }


        /// <summary>
        /// 斐波那契数列
        /// dp[i] = dp[i - 1] + dp[i - 2];
        /// 时间复杂度O(n)
        /// 空间复杂度O(1) 常量级空间
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs1(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            int first  = 1;
            int second = 2;
            for (int i = 3; i <= n; i++)
            {
                int third = first + second;
                first  = second;
                second = third;
            }

            return second;
        }
    }
}