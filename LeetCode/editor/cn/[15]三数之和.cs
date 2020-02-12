//给定一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？找出所有满足条件且不重复的三
//元组。 
//
// 注意：答案中不可以包含重复的三元组。 
//
// 
//
// 示例： 
//
// 给定数组 nums = [-1, 0, 1, 2, -1, -4]，
//
//满足要求的三元组集合为：
//[
//  [-1, 0, 1],
//  [-1, -1, 2]
//]
// 
// Related Topics 数组 双指针


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 双指针 效率高于字典
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        // 特殊情况排除
        if (nums.Length < 3 || nums[0] > 0)
            return res;
                
        for (int i = 0; i < nums.Length; i++)
        {
            // 后面都是正数,不能相加为0
            if (nums[i] > 0)
                return res;
            // 去除重复计算
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
                    
            int curr  = nums[i];
            int left  = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] + nums[right] + curr > 0)
                {
                    right--;
                }
                else if (nums[left] + nums[right] + curr < 0)
                {
                    left++;
                }
                else
                {
                    res.Add(new List<int> {curr, nums[left], nums[right]});

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
    
    
    // 字典解法
    // HashSet<int>去重
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        if (nums.Length < 3 || nums[0]> 0)
            return res;
        // a+b=-c
        var dic = new Dictionary<int, int>();
        var set = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // 后面都是正数,不能相加为0
            if (nums[i] > 0)
                break;
            // 去除重复计算
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            
            var first = nums[i];
            
            dic.Clear();
            set.Clear();
            for (int j = i + 1; j < nums.Length; j++)
            {
                var second = nums[j];
                var third  = -first - second;
                if (dic.ContainsKey(third))
                {
                    // 去重
                    if (!set.Contains(third))
                    {
                        res.Add(new List<int> {first, third, second});
                    }

                    set.Add(third);
                }
                else
                {
                    if (!dic.ContainsKey(second))
                        dic.Add(second, j);
                }
            }
        }
        return res;
    }
    
    // 字典解法
    // HashSet值元组去重
    public IList<IList<int>> ThreeSum2(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        if (nums.Length < 3 || nums[0] > 0)
            return res;
                
        var dic = new Dictionary<int, int>();
        // 利用值元组去重
        HashSet<(int, int, int)> set = new HashSet<(int, int, int)>();

        for (int i = 0; i < nums.Length; i++)
        {
            // 后面都是正数,不能相加为0
            if (nums[i] > 0)
                break;
            // 去除重复计算
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
                    
            int first = nums[i];
            dic.Clear();
            for (int j = i + 1; j < nums.Length; j++)
            {
                var second = nums[j];
                //a + b = -c
                var third = -first - second;
                if (dic.ContainsKey(third))
                {
                    set.Add((first, third, second));
                }
                else
                {
                    if (!dic.ContainsKey(second))
                        dic.Add(second, j);
                }
            }
        }

        foreach (var item in set)
        {
            res.Add(new List<int> { item.Item1, item.Item2, item.Item3 });
        }
        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
