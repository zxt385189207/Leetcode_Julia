//给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。 
//
// 此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。 
//
// 注意: 
//不能使用代码库中的排序函数来解决这道题。 
//
// 示例: 
//
// 输入: [2,0,2,1,1,0]
//输出: [0,0,1,1,2,2] 
//
// 进阶： 
//
// 
// 一个直观的解决方案是使用计数排序的两趟扫描算法。 
// 首先，迭代计算出0、1 和 2 元素的个数，然后按照0、1、2的排序，重写当前数组。 
// 你能想出一个仅使用常数空间的一趟扫描算法吗？ 
// 
// Related Topics 排序 数组 双指针


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public void SortColors(int[] nums)
    {
        int slowleft  = 0;
        int slowright = nums.Length - 1;
        int fast      = 0;
        // 快指针和末尾慢指针相遇就遍历完所有的数
        // 如果判断慢指针和末尾慢指针相遇,
        // 会把已经排序好的2放到中间
        while (fast <= slowright)
        {
            if (nums[fast] == 2)
            {
                // 要注意快指针把2交换到末尾,交换回来的值不确定是1还是0
                // 这里不递增快指针, 重新判断一次
                Swap(nums, fast, slowright--);
            }
            else if (nums[fast] == 0)
                Swap(nums, fast++, slowleft++);
            else 
                fast++;
        }
    }

    // 在数组中使用异或运算交换两个变量的值的时候，
    // 一定要保证这两个变量不是同一个变量，
    // 即索引不能相同，否则会把这个位置上的数变成 0 。
    public void Swap(int[] nums, int i, int j)
    {
        if (i == j)
            return;
        // 异或法
        // 用异或运算交换变量，并且不能加快运算，也不能节省内存。
        // nums[i] = nums[i] ^ nums[j]; // a ^ b = c
        // nums[j] = nums[i] ^ nums[j]; //nums[j] =  a = c ^ b;
        // nums[i] = nums[i] ^ nums[j]; //nums[i] =  b = c ^ a;

        // 加减法
        nums[i] = nums[i] + nums[j]; // a = a + b
        nums[j] = nums[i] - nums[j]; // b = a - b
        nums[i] = nums[i] - nums[j]; // a = a - b

        // 临时变量
        // int temp = nums[i];
        // nums[i] = nums[j];
        // nums[j] = temp;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
