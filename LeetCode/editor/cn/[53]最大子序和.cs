//给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。 
//
// 示例: 
//
// 输入: [-2,1,-3,4,-1,2,1,-5,4],
//输出: 6
//解释: 连续子数组 [4,-1,2,1] 的和最大，为 6。
// 
//
// 进阶: 
//
// 如果你已经实现复杂度为 O(n) 的解法，尝试使用更为精妙的分治法求解。 
// Related Topics 数组 分治算法 动态规划


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
        // -2,1,-3,4,-1,2,1,-5,4 
        /// <summary>
        /// 动态规划(单线程最优解), 取决于该问题是否能用动态规划解决的是这些”小问题“会不会被被重复调用。
        /// 每一步，我们维护两个变量，一个是全局最优，一个是局部最优,
        /// nums[i] 定义为数组nums 中以num[i]结尾的最大连续子串和.
        /// 时间复杂度：O(N)。只遍历一次数组。
        /// 空间复杂度：O(1)，只使用了常数空间。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                // 局部最优
                // nums[i] 定义为数组nums 中以num[i]结尾的最大连续子串和，
                // 1.  -2 与 1 的最优是 1; 将num[1] = 1
                // 2. 1 与 -3 的最优是 1-3=-2, 将 num[2] = -2
                // 3. -2 与 4  的最优是 4,  将 num[3] = 4
                // 4. 4  与 -1 的最优是 4-1 =3将 num[4] = 3
                // 5. 3 与 2 的最优是 5 将 num[5] = 5
                // 6. 5 与 1 的最优是 6 将 num[6] = 6
                // 7. 6 与 -5 的最优是 1 将 num[7] = 1
                // 8. 1 与 4 的最优是 5 将 num[8] = 5
                nums[i] = Math.Max(nums[i] + nums[i - 1], nums[i]);
                // 全局最优
                // 全局最优解为 num[6] = 6
                max = Math.Max(max, nums[i]);
            }

            return max;
        }


        /// <summary>
        ///  -2,1,-3,4,-1,2,1,-5,4 
        /// Kadane算法(感觉类似于动态规划的思路)
        /// 算法描述：
        ///
        /// 遍历该数组， 在遍历过程中， 将遍历到的元素依次累加起来， 当累加结果小于或等于0时， 从下一个元素开始，重新开始累加。
        /// 累加过程中， 要用一个变量(max_so_far)记录所获得过的最大值。
        /// 一次遍历之后， 变量 max_so_far 中存储的即为最大子片段的和值。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray2(int[] nums)
        {
            // 最大子片段中不可能包含求和值为负的前缀。 例如 【-2， 1，4】 必然不能是最大子数列， 因为去掉值为负的前缀后【-2】， 可以得到一个更大的子数列 【1, 4】、
            // 所以在遍历过程中，每当累加结果成为一个非正值时， 就应当将下一个元素作为潜在最大子数列的起始元素， 重新开始累加。
            // 由于在累加过程中， 出现过的最大值都会被记录， 且每一个可能成为 最大子数列起始元素 的位置， 都会导致新一轮的累加， 这样就保证了答案搜索过程的完备性和正确性。 	 
            int localmax = 0;
            int max   = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                localmax += nums[i];
                if (localmax < 0)
                {
                    localmax = 0;
                }

                if (max < localmax)
                {
                    max = localmax;
                }
            }

            
            return max;
        }
        
        
        
        /// <summary>
        /// 分治法(较难, 没看会,)
        /// 将数组均分为两个部分，那么最大子数组会存在于：
        ///     左侧数组的最大子数组
        ///     右侧数组的最大子数组
        ///     左侧数组的以右侧边界为边界的最大子数组+右侧数组的以左侧边界为边界的最大子数组
        /// 
        ///这个是使用分治法解决问题的典型的例子，并且可以用与合并排序相似的算法求解。下面是用分治法解决问题的模板：

        /// 定义基本情况。
        /// 将问题分解为子问题并递归地解决它们。
        /// 合并子问题的解以获得原始问题的解。
        ///算法：
        /// 当最大子数组有 n 个数字时：
        /// 若         n==1，返回此元素。
        ///left_sum  为最大子数组前 n/2 个元素，在索引为 (left + right) / 2 的元素属于左子数组。
        ///right_sum 为最大子数组的右子数组，为最后 n/2 的元素。
        ///cross_sum 是包含左右子数组且含索引 (left + right) / 2 的最大值。
        /// 时间复杂度：O(NlogN)。
        /// 空间复杂度：O(logN)，递归时栈使用的空间。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray3(int[] nums)
        {
            return maxSubArrayPart(nums,0,nums.Length-1);
        }
        private int maxSubArrayPart(int[] nums, int left, int right) {
            if(left==right){
                return nums[left];
            }
            int mid =(left+right)/2;
            return Math.Max(
                maxSubArrayPart(nums,left,mid),
                Math.Max(
                    maxSubArrayPart(nums,mid+1,right),
                    maxSubArrayAll(nums,left,mid,right)
                )
            );
        }

        //左右两边合起来求解
        private int maxSubArrayAll(int[] nums, int left, int mid, int right) {
            int leftSum =Int32.MinValue;
            int sum     =0;
            for(int i=mid;i>=left;i--){
                sum += nums[i];
                if(sum>leftSum){
                    leftSum = sum;
                }
            }
            sum = 0;
            int rightSum = Int32.MinValue;
            for(int i=mid+1;i<=right;i++){
                sum += nums[i];
                if(sum>rightSum){
                    rightSum = sum;
                }
            }
            return leftSum+rightSum;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
