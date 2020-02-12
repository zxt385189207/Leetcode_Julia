//给定两个有序整数数组 nums1 和 nums2，将 nums2 合并到 nums1 中，使得 num1 成为一个有序数组。 
//
// 说明: 
//
// 
// 初始化 nums1 和 nums2 的元素数量分别为 m 和 n。 
// 你可以假设 nums1 有足够的空间（空间大小大于或等于 m + n）来保存 nums2 中的元素。 
// 
//
// 示例: 
//
// 输入:
//nums1 = [1,2,3,0,0,0], m = 3
//nums2 = [2,5,6],       n = 3
//
//输出: [1,2,2,3,5,6] 
// Related Topics 数组 双指针


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int p1 = m - 1;
        int p2 = n - 1;

        // 合并之后最后一个数的index
        int p = m + n - 1;

        // 数组最后一个数, 比较2个数组的最后一个值, 大的写入, 并且对应指针向左移动
        while (p1 >= 0 && p2 >= 0)
        {
            // 语法糖形式
            //nums1[p--] = nums1[p1] < nums2[p2] ? nums2[p2--] : nums1[p1--];
            if (nums1[p1] < nums2[p2])
                nums1[p--] = nums2[p2--];
            else
                nums1[p--] = nums1[p1--];
        }

        // 循环结束后只有两种情况:p1= -1或者p2=-1
        // p1=-1 数组2中可能还有0到p2+1个数未遍历
        // p2=-1 数组2都已正确填充进数组1中,
        if (p1 == -1)
            Array.Copy(nums2, 0, nums1, 0, p2 + 1);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
