//给定一个数组 nums，有一个大小为 k 的滑动窗口从数组的最左侧移动到数组的最右侧。你只可以看到在滑动窗口内的 k 个数字。滑动窗口每次只向右移动一位。 
//
//
// 返回滑动窗口中的最大值。 
//
// 
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
// 
//
// 进阶： 
//
// 你能在线性时间复杂度内解决此题吗？ 
// Related Topics 堆 Sliding Window


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    
    // Queue没办法移除末尾元素,栈没办法出栈底元素, 不适合此题
    // 维护双向循环链表LinkedList作为一个单调递减的双端队列
    // O(N)时间复杂度
    // 双向循环链表LinkedList的增加删除操作都是O(1)
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
    
    // 解法二
    // 二叉搜索树+字典
    public int[] MaxSlidingWindow2(int[] nums, int k)
    {
        if (k < 1 || nums.Length == 0)
        {
            return new int[0];
        }

        var result = new int[nums.Length - k + 1];

        var map = new Dictionary<int, int>(nums.Length);

        var binarySearchTree = new SortedSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var visit = nums[i];

            binarySearchTree.Add(visit); // O(LogK)

            map[visit] = i; // O(1), duplicate number will be updated with latest index

            if (i < k - 1)
            {
                continue;
            }

            if (i >= k && map[nums[i - k]] == (i - k)) // O(1)
            {
                var kStepAway = nums[i - k];

                binarySearchTree.Remove(kStepAway); // O(logK)

                map.Remove(kStepAway); // O(1)
            }

            result[i - k + 1] = binarySearchTree.Max; // O(1)
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
