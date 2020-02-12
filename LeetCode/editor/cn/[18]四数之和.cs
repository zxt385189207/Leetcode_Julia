//给定一个包含 n 个整数的数组 nums 和一个目标值 target，判断 nums 中是否存在四个元素 a，b，c 和 d ，使得 a + b + c +
// d 的值与 target 相等？找出所有满足条件且不重复的四元组。 
//
// 注意： 
//
// 答案中不可以包含重复的四元组。 
//
// 示例： 
//
// 给定数组 nums = [1, 0, -1, 0, -2, 2]，和 target = 0。
//
//满足要求的四元组集合为：
//[
//  [-1,  0, 0, 1],
//  [-2, -1, 1, 2],
//  [-2,  0, 0, 2]
//]
// 
// Related Topics 数组 哈希表 双指针


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 字典方法效率不行

    // 改造ThreeSum加以利用
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            // 去除重复计算
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            int search = target - nums[i];

            ThreeSum(nums, i+1, nums[i], search, res);
        }

        return res;
    }
    
    public IList<IList<int>> ThreeSum(int[] nums, int index, int fourth, int target, IList<IList<int>> res)
    {
        // 特殊情况排除
        if (nums.Length < 3)
            return res;

        for (int i = index; i < nums.Length; i++)
        {
            // 去除重复计算
            if (i > index && nums[i] == nums[i - 1])
                continue;

            int curr  = nums[i];
            int left  = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] + nums[right] + curr > target)
                {
                    right--;
                }
                else if (nums[left] + nums[right] + curr < target)
                {
                    left++;
                }
                else
                {
                    res.Add(new List<int> {fourth, curr, nums[left], nums[right]});

                    // 去除重复计算, 前后相同的移动指针
                    while (left < right && nums[left + 1] == nums[left])
                        left++;
                    while (left < right && nums[right - 1] == nums[right])
                        right--;

                    left++;
                    right--;
                }
            }
        }

        return res;
    }
    
}
//leetcode submit region end(Prohibit modification and deletion)
