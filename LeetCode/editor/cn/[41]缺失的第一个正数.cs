//给定一个未排序的整数数组，找出其中没有出现的最小的正整数。 
//
// 示例 1: 
//
// 输入: [1,2,0]
//输出: 3
// 
//
// 示例 2: 
//
// 输入: [3,4,-1,1]
//输出: 2
// 
//
// 示例 3: 
//
// 输入: [7,8,9,11,12]
//输出: 1
// 
//
// 说明: 
//
// 你的算法的时间复杂度应为O(n)，并且只能使用常数级别的空间。 
// Related Topics 数组




//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public int FirstMissingPositive(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            // 把鸽子放进对应的巢中
            // 每次swap都会使“正确位置”多一个，那么最多N次交换就能使它们都在
            // 条件1,2: 元素值如果是负数,或者大于数组长度,
            //        说明索引越界, 不去交换它, 遍历下一个
            // 条件3: 把鸽子是否在对应的巢中
            while (nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i] - 1] != nums[i])
            {
                // 满足在指定范围内、并且没有放在正确的位置上，才交换
                // 例如：数值 3 应该放在索引 2 的位置上
                Swap(nums, nums[i] - 1, i);
            }
        }

        // [1, -1, 3, 4]
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }
        // 都正确则返回数组长度 + 1
        return nums.Length + 1;
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
}
//leetcode submit region end(Prohibit modification and deletion)
