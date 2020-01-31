//给定一个包含 0, 1, 2, ..., n 中 n 个数的序列，找出 0 .. n 中没有出现在序列中的那个数。 
//
// 示例 1: 
//
// 输入: [3,0,1]
//输出: 2
// 
//
// 示例 2: 
//
// 输入: [9,6,4,2,3,5,7,0,1]
//输出: 8
// 
//
// 说明: 
//你的算法应具有线性时间复杂度。你能否仅使用额外常数空间来实现? 
// Related Topics 位运算 数组 数学


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 哈希表算法
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MissingNumber(int[] nums)
    {
        HashSet<int> numSet = new HashSet<int>();


        foreach (int num in nums)
            numSet.Add(num);

        int expectedNumCount = nums.Length + 1;
        // 包含0开始到n的序列
        for (int number = 0; number < expectedNumCount; number++)
        {
            if (!numSet.Contains(number))
            {
                return number;
            }
        }

        return -1;
    }

    /// <summary>
    /// 利用异或结合律
    /// 0 1 3 4 
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MissingNumber2(int[] nums)
    {
        int missing = nums.Length;
        for (int i = 0; i < nums.Length; i++)
        {
            // 由于异或运算（XOR）满足结合律
            // 相同的数异或是0,
            // missing = 4∧(0∧0)∧(1∧1)∧(2∧3)∧(3∧4)
            //         = (4∧4)∧(0∧0)∧(1∧1)∧(3∧3)∧2
            //         = 0∧0∧0∧0∧2
            //         = 2
            missing ^= i ^ nums[i];
        }

        return missing;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
