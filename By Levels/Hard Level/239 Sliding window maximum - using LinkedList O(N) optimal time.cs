using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _239_Sliding_window_maximum
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
        }

        /// <summary>
        /// code was submitted by Jianmin Chen August 2015
        /// Time complexity: O(N), N is is the length of the array
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {

            if (k == 0) return nums;

            int len = nums.Length;
            int maxArrayLen = len - k + 1;
            int[] ans = new int[maxArrayLen];

            // 存的是数组下标
            LinkedList<int> q = new LinkedList<int>();

            // Queue stores indices of array, and 
            // values are in decreasing order.
            // So, the first node in queue is the max in window
            for (int i = 0; i < len; i++)
            {
                // 1. 移除超过滑动窗口大小的左端第一个数字
                if (q.Count > 0 && q.First.Value + k <= i)
                    q.RemoveFirst();

                // 2. 在将i插入队列之前，从队列尾部删除它们数组[i]中值较小的索引。
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
}
