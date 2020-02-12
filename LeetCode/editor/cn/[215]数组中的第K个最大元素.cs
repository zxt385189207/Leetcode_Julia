//在未排序的数组中找到第 k 个最大的元素。请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。 
//
// 示例 1: 
//
// 输入: [3,2,1,5,6,4] 和 k = 2
//输出: 5
// 
//
// 示例 2: 
//
// 输入: [3,2,3,1,2,4,5,5,6] 和 k = 4
//输出: 4 
//
// 说明: 
//
// 你可以假设 k 总是有效的，且 1 ≤ k ≤ 数组的长度。 
// Related Topics 堆 分治算法


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    
    // 堆写法
    // TODO
    
    // 快速排序思想
    // 从数组 S 中随机找出一个元素 X，把数组分为两部分 Sa 和 Sb。Sa 中的元素大于等于 X，Sb 中元素小于 X。这时有两种情况：
    // Sa 中元素的个数小于 k，则     Sb 中的第 k-|Sa| 个元素即为第k大数；
    // Sa 中元素的个数大于等于 k，则返回 Sa 中的第 k 大数。时间复杂度近似为 O(n)
    // TODO
    
    // 直接API
    public int FindKthLargest(int[] nums, int k)
    {
        var list = new List<int>(nums);
        list.Sort();
        // 返回倒数第K个
        return list[list.Count - k];
        //return list[^k];
    }

    //LINQ
    public int FindKthLargest2(int[] nums, int k)
    {
        if (k < nums.Length / 2)
            return nums.OrderByDescending(i => i).Skip(k - 1).First();
        else
            return nums.OrderBy(i => i).Skip(nums.Length - k).First();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
