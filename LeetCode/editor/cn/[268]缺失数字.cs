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
    // 鸽巢原理解法
    public int MissingNumber(int[] nums) 
    {
        for (int i = 0; i < nums.Length; i++)
        {
            while (nums[i] < nums.Length && nums[nums[i]] != nums[i])
            {
                Swap(nums, nums[i], i);
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i)
            {
                return i;
            }
        }

        return nums.Length;
    }
    // 在数组中使用异或运算交换两个变量的值的时候，
    // 一定要保证这两个变量不是同一个变量，
    // 即索引不能相同，否则会把这个位置上的数变成 0 。
    public void Swap(int[] nums, int i, int j)
    {
        if (i == j)
            return;
        // 异或法
        // 用异或运算交换变量，并且不能加快运算，也不能节省内存。
        // nums[i] = nums[i] ^ nums[j]; // a ^ b = c
        // nums[j] = nums[i] ^ nums[j]; //nums[j] =  a = c ^ b;
        // nums[i] = nums[i] ^ nums[j]; //nums[i] =  b = c ^ a;
                
        // 加减法
        nums[i] = nums[i] + nums[j]; // a = a + b
        nums[j] = nums[i] - nums[j]; // b = a - b
        nums[i] = nums[i] - nums[j]; // a = a - b
                
        // 临时变量
        // int temp = nums[i];
        // nums[i] = nums[j];
        // nums[j] = temp;
    }
    
    
    // 哈希表算法
    public int MissingNumber2(int[] nums)
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
    public int MissingNumber3(int[] nums)
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
