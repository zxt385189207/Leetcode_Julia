//给定两个没有重复元素的数组 nums1 和 nums2 ，其中nums1 是 nums2 的子集。找到 nums1 中每个元素在 nums2 中的下一个比其
//大的值。 
//
// nums1 中数字 x 的下一个更大元素是指 x 在 nums2 中对应位置的右边的第一个比 x 大的元素。如果不存在，对应位置输出-1。 
//
// 示例 1: 
//
// 
//输入: nums1 = [4,1,2], nums2 = [1,3,4,2].
//输出: [-1,3,-1]
//解释:
//    对于num1中的数字4，你无法在第二个数组中找到下一个更大的数字，因此输出 -1。
//    对于num1中的数字1，第二个数组中数字1右边的下一个较大数字是 3。
//    对于num1中的数字2，第二个数组中没有下一个更大的数字，因此输出 -1。 
//
// 示例 2: 
//
// 
//输入: nums1 = [2,4], nums2 = [1,2,3,4].
//输出: [3,-1]
//解释:
//    对于num1中的数字2，第二个数组中的下一个较大数字是3。
//    对于num1中的数字4，第二个数组中没有下一个更大的数字，因此输出 -1。
// 
//
// 注意: 
//
// 
// nums1和nums2中所有元素是唯一的。 
// nums1和nums2 的数组大小都不超过1000。 
// 
// Related Topics 栈


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 我们可以忽略数组 nums1，先对将 nums2 中的每一个元素，
    // 求出其下一个更大的元素。随后对于将这些答案放入哈希映射（HashMap）中，
    // 再遍历数组 nums1，并直接找出答案。
    // 对于 nums2，我们可以使用单调栈来解决这个问题。
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        Stack<int> stack = new Stack<int>(nums2.Length);

        Dictionary<int, int> dic = new Dictionary<int, int>();
        int[]                res = new int[nums1.Length];

        // 维护一个递增的单调栈,栈顶最小,栈底最大
        for (int i = 0; i < nums2.Length; i++)
        {
            // 当前元素和栈顶元素进行比较
            // 如果当前元素大于栈顶元素, 则出栈,说明比栈顶元素大的元素找到了
            while (stack.Count != 0 && nums2[i] > stack.Peek())
                dic[stack.Pop()] = nums2[i];

            stack.Push(nums2[i]);
        }

        while (stack.Count != 0)
            dic[stack.Pop()] = -1;

        for (int i = 0; i < nums1.Length; i++)
            res[i] = dic[nums1[i]];

        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
