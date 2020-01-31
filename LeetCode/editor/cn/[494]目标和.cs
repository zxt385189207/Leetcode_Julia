//给定一个非负整数数组，a1, a2, ..., an, 和一个目标数，S。现在你有两个符号 + 和 -。对于数组中的任意一个整数，你都可以从 + 或 -中选
//择一个符号添加在前面。 
//
// 返回可以使最终数组和为目标数 S 的所有添加符号的方法数。 
//
// 示例 1: 
//
// 输入: nums: [1, 1, 1, 1, 1], S: 3
//输出: 5
//解释: 
//
//-1+1+1+1+1 = 3
//+1-1+1+1+1 = 3
//+1+1-1+1+1 = 3
//+1+1+1-1+1 = 3
//+1+1+1+1-1 = 3
//
//一共有5种方法让最终目标和为3。
// 
//
// 注意: 
//
// 
// 数组非空，且长度不会超过20。 
// 初始的数组的和不会超过1000。 
// 保证返回的最终结果能被32位整数存下。 
// 
// Related Topics 深度优先搜索 动态规划


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// TODO: 还没看懂
    /// 01背包问题 耗时100
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="S"></param>
    /// <returns></returns>
    public int FindTargetSumWays(int[] nums, int S)
    {
        //Sum(P)-Sum(N)=S
        //Sum(P)+Sum(N)=Sum(nums)
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        if (sum < S || (sum + S) % 2 == 1)
            return 0;
        int target = (sum + S) / 2;
        //dp数组下标0-target
        //dp[i]含义为nums中和为i的子集个数
        //故而所求即为dp[target]
        int[] dp = new int[target + 1];
        dp[0] = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = target; j >= nums[i]; j--)
                dp[j] += dp[j - nums[i]];
        }

        return dp[target];
    }

    /// <summary>
    /// 递归, 可以看成DFS, 耗时1000
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="S"></param>
    /// <returns></returns>
    public int FindTargetSumWays2(int[] nums, int S)
    {
        int count = 0;
        calculate(nums, 0, 0, S, ref count);
        return count;
    }

    public void calculate(int[] nums, int i, int sum, int S, ref int count)
    {
        // 要有n个数遍历所有可能
        if (i == nums.Length)
        {
            // 结果等于s则计数
            if (sum == S)
                count++;
        }
        else
        {
            // 递归
            calculate(nums, i + 1, sum + nums[i], S, ref count);
            calculate(nums, i + 1, sum - nums[i], S, ref count);
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
