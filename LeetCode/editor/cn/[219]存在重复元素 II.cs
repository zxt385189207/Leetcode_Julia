//给定一个整数数组和一个整数 k，判断数组中是否存在两个不同的索引 i 和 j，使得 nums [i] = nums [j]，并且 i 和 j 的差的绝对值最
//大为 k。 
//
// 示例 1: 
//
// 输入: nums = [1,2,3,1], k = 3
//输出: true 
//
// 示例 2: 
//
// 输入: nums = [1,0,1,1], k = 1
//输出: true 
//
// 示例 3: 
//
// 输入: nums = [1,2,3,1,2,3], k = 2
//输出: false 
// Related Topics 数组 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 题目: 序号差绝对值不超过K


    // 哈希集,只需遍历一遍数组, set中最多只加入k个数, 如果重复就返回true
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < nums.Length; ++i)
        {
            if (set.Contains(nums[i])) 
                return true;
            // 如果不包含,就添加
            set.Add(nums[i]);
            // 如果集合的个数超过了K, 则移除第i-k个
            if (set.Count > k)
            {
                set.Remove(nums[i - k]);
            }
        }
        return false;
    }
        
    // 直接搜索会超时
    public bool ContainsNearbyDuplicate0(int[] nums, int k)
    {
        for (int i = 0; i < nums.Length; ++i)
        {
            for (int j = Math.Max(i - k, 0); j < i; ++j)
            {
                if (nums[i] == nums[j]) return true;
            }
        }

        return false;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
