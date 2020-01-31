//给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。 
//
// 示例: 
//
// 输入: [0,1,0,3,12]
//输出: [1,3,12,0,0] 
//
// 说明: 
//
// 
// 必须在原数组上操作，不能拷贝额外的数组。 
// 尽量减少操作次数。 
// 
// Related Topics 数组 双指针


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 双指针, 0的位置用后面非0的位置填补. 最后补0
    /// </summary>
    /// <param name="nums"></param>
    public void MoveZeroes(int[] nums)
    {
        int slow = 0;
            
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[slow++] = nums[i];
            }
        }

        for (int i = slow; i < nums.Length; i++)
        {
            nums[i] = 0;
        }

    }
}
//leetcode submit region end(Prohibit modification and deletion)
