//给定一个已按照升序排列 的有序数组，找到两个数使得它们相加之和等于目标数。 
//
// 函数应该返回这两个下标值 index1 和 index2，其中 index1 必须小于 index2。 
//
// 说明: 
//
// 
// 返回的下标值（index1 和 index2）不是从零开始的。 
// 你可以假设每个输入只对应唯一的答案，而且你不可以重复使用相同的元素。 
// 
//
// 示例: 
//
// 输入: numbers = [2, 7, 11, 15], target = 9
//输出: [1,2]
//解释: 2 与 7 之和等于目标数 9 。因此 index1 = 1, index2 = 2 。 
// Related Topics 数组 双指针 二分查找


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public int[] TwoSum(int[] numbers, int target)
    {
        if (numbers == null || numbers.Length < 2)
            return new int[0];

        // 字典的特性，存取快耗内存
        // 利用字典这种特性实现牺牲空间性能来换取时间的性能提升
        var dic = new Dictionary<int, int>();

        // 第一层循环时将结果存入字典（二叉树）中，利用二叉树查询速度快的特点来提升时间性能。
        for (int i = 0; i < numbers.Length; i++)
        {
            var current = numbers[i];
            var search  = target - current;

            if (dic.ContainsKey(search))
            {
                return new int[] {dic[search]+1, i+1};
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
    
    // 对撞指针
    // 前提升序数组
    public int[] TwoSum2(int[] numbers, int target)
    {
        int right = numbers.Length - 1;
        int left  = 0;

        while (left < right)
        {
            // 首先判断首尾两项和是不是target
            if (numbers[left] + numbers[right] == target)
                return new []{left+1,right+1};
            // 比target小,左边left指针++
            if (numbers[left] + numbers[right] < target)
                left++;
            // 比target大,右边right指针--
            else
                right--;
        }

        return new int[]{};
    }
}
//leetcode submit region end(Prohibit modification and deletion)
