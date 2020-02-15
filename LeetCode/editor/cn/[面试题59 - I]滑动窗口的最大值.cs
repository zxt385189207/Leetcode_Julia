//给定一个数组 nums 和滑动窗口的大小 k，请找出所有滑动窗口里的最大值。 
//
// 示例: 
//
// 输入: nums = [1,3,-1,-3,5,3,6,7], 和 k = 3
//输出: [3,3,5,5,6,7] 
//解释: 
//
//  滑动窗口的位置                最大值
//---------------               -----
//[1  3  -1] -3  5  3  6  7       3
// 1 [3  -1  -3] 5  3  6  7       3
// 1  3 [-1  -3  5] 3  6  7       5
// 1  3  -1 [-3  5  3] 6  7       5
// 1  3  -1  -3 [5  3  6] 7       6
// 1  3  -1  -3  5 [3  6  7]      7 
//
// 
//
// 提示： 
//
// 你可以假设 k 总是有效的，在输入数组不为空的情况下，1 ≤ k ≤ 输入数组的大小。 
//
// 注意：本题与主站 239 题相同：https://leetcode-cn.com/problems/sliding-window-maximum/ 
// Related Topics 栈 Sliding Window


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (k == 0) return nums;

        int   len         = nums.Length;
        int   maxArrayLen = len - k + 1;
        int[] ans         = new int[maxArrayLen];

        // 存的是数组下标
        LinkedList<int> q = new LinkedList<int>();
        
        for (int i = 0; i < len; i++)
        {
            // 1. 移除超过滑动窗口大小的左端第一个数字
            if (q.Count > 0 && q.First.Value + k <= i)
                q.RemoveFirst();

            // 2. 在将i插入队列之前，从队列尾部删除它们值比nums[i]小的索引。
            while (q.Count > 0 && nums[q.Last.Value] <= nums[i])
                q.RemoveLast();

            q.AddLast(i);

            // 3. 需要滑动窗口的左下标和右下标相差K个数才开始放入结果数组
            // 第一个值总是最大的
            int leftindex = i + 1 - k;
            if (leftindex >= 0)
                ans[leftindex] = nums[q.First.Value];
        }

        return ans;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
