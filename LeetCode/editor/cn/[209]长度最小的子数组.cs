//给定一个含有 n 个正整数的数组和一个正整数 s ，找出该数组中满足其和 ≥ s 的长度最小的连续子数组。如果不存在符合条件的连续子数组，返回 0。 
//
// 示例: 
//
// 输入: s = 7, nums = [2,3,1,2,4,3]
//输出: 2
//解释: 子数组 [4,3] 是该条件下的长度最小的连续子数组。
// 
//
// 进阶: 
//
// 如果你已经完成了O(n) 时间复杂度的解法, 请尝试 O(n log n) 时间复杂度的解法。 
// Related Topics 数组 双指针 二分查找


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 双指针
    // 用双指针 left 和 right 表示一个窗口。
    // ht 向右移增大窗口，直到窗口内的数字和大于等于了 s。进行第 2 步。
    // 记录此时的长度，left 向右移动，开始减少长度，每减少一次，就更新最小长度。
    // 直到当前窗口内的数字和小于了 s，回到第 1 步。
    public int MinSubArrayLen(int s, int[] nums)
    {
        if (nums.Length < 1)
            return 0;

        int left  = 0;
        int right = 0;
        int sum   = 0;
        int min   = int.MaxValue;
        while (right < n)
        {
            sum += nums[right];
            right++;
            // 如果和已经大于等于s, sum减去left并
            // 右移left
            while (sum >= s)
            {
                min =  Math.Min(min, right - left);
                sum -= nums[left];
                left++;
            }
        }

        return min == int.MaxValue ? 0 : min;
    }
    

    // 暴力解法 O(n^2)
    // 从第 0 个数字开始，依次添加数字，记录当总和大于等于 s 时的长度。
    // 从第 1 个数字开始，依次添加数字，记录当总和大于等于 s 时的长度。
    public int MinSubArrayLen2(int s, int[] nums)
    {
        int min = int.MaxValue;
        int n   = nums.Length;
        for (int i = 0; i < n; i++)
        {
            int start = i;
            int sum   = 0;
            while (start < n)
            {
                sum += nums[start];
                start++;
                //当前和大于等于 s 的时候结束
                if (sum >= s)
                {
                    min = Math.Min(min, start - i);
                    break;
                }
            }
        }

        //min 是否更新，如果没有更新说明数组所有的数字和小于 s, 没有满足条件的解, 返回 0
        return min == int.MaxValue ? 0 : min;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
