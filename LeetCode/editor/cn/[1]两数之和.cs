//给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。 
//
// 你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。 
//
// 示例: 
//
// 给定 nums = [2, 7, 11, 15], target = 9
//
//因为 nums[0] + nums[1] = 2 + 7 = 9
//所以返回 [0, 1]
// 
// Related Topics 数组 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 优化解, 空间换时间
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] nums, int target)
    {
        if (nums == null || nums.Length < 2)
            return new int[0];

        // 字典的特性，存取快耗内存
        // 利用字典这种特性实现牺牲空间性能来换取时间的性能提升
        var dic = new Dictionary<int, int>();

        // 第一层循环时将结果存入字典（二叉树）中，利用二叉树查询速度快的特点来提升时间性能。
        for (int i = 0; i < nums.Length; i++)
        {
            var current = nums[i];
            var search  = target - current;

            if (dic.ContainsKey(search))
            {
                return new int[] {dic[search], i};
            }
            else
            {
                if (!dic.ContainsKey(current))
                {
                    // 把数组值作为key, 和下标作为值放入字典中
                    dic.Add(current, i);
                }
            }
        }

        return new int[0];
    }

    /// <summary>
    /// 暴力解法,会超时
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum2(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[i] + nums[j] == target)
                return new int[] {i, j};
        }

        return null;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
