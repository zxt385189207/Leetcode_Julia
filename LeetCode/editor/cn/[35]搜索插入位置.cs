//给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。 
//
// 你可以假设数组中无重复元素。 
//
// 示例 1: 
//
// 输入: [1,3,5,6], 5
//输出: 2
// 
//
// 示例 2: 
//
// 输入: [1,3,5,6], 2
//输出: 1
// 
//
// 示例 3: 
//
// 输入: [1,3,5,6], 7
//输出: 4
// 
//
// 示例 4: 
//
// 输入: [1,3,5,6], 0
//输出: 0
// 
// Related Topics 数组 二分查找


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
          // 暴力解决的话需要 O(n)O(n) 的时间复杂度，
        // 但是如果二分的话则可以降低到 O(logn)O(logn) 的时间复杂度
        // 二分查找模板 : 可以直接套用的模板，记住就好了，免除边界条件出错。
        // public int searchInsert(int[] nums, int target)
        // {
        //     int left = 0, right = nums.Length - 1;   // 注意
        //     while (left <= right)                    // 注意
        //     {
        //        
        //         int mid = left + (right - left) / 2; // 注意
        //         if (nums[mid] == target)             // 注意
        //         {
        //             // 相关逻辑
        //         }
        //         else if (target > nums[mid])
        //         {
        //             left = mid + 1;                  // 注意
        //         }
        //         else
        //         {
        //             right = mid - 1;                 // 注意
        //         }
        //     }
        //
        //     // 相关返回值
        //     return ;
        //}


        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            // 先设定左侧下标 left 和右侧下标 right，
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                // 再计算中间下标 mid
                // 此处mid是左中位数 ( 数组是奇数个数的话就有左中位数和右中位数之分 )
                // left + (right - left + 1) / 2  表示右中位数
                int mid = left + (right - left) / 2; // 防止right + left溢出
                if (nums[mid] == target)
                {
                    return mid;
                }
                // 如果目标值小于中位数
                else if (target < nums[mid])
                {
                    // 移动right下标到中位数左边一位
                    right = mid - 1;
                }
                else
                {
                    // 目标值大于中位数
                    // 移动left下标到中位数左边一位
                    left = mid + 1;
                }
            }

            // 没找到对应值, 根据题意此处应该返回target应该插入的位置
            return left;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
