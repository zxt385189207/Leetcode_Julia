//给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。 
//
// 最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。 
//
// 你可以假设除了整数 0 之外，这个整数不会以零开头。 
//
// 示例 1: 
//
// 输入: [1,2,3]
//输出: [1,2,4]
//解释: 输入数组表示数字 123。
// 
//
// 示例 2: 
//
// 输入: [4,3,2,1]
//输出: [4,3,2,2]
//解释: 输入数组表示数字 4321。
// 
// Related Topics 数组


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 此题不难，其实就是让我们模拟竖式计算进位，然只需要加11即可。对此，我们将问题分成以下3类：
    //
    // 给定整数中最后一位不是数字99（如12341234）；
    // 给定整数中最后一位是数字99，但不全是数字99（如10991099）；
    // 给定整数所有位全是数字99（如99999999）。
    // 算法思路：
    //
    // 对于上述情况1，直接在最后一位加11即可。
    // 对于上述情况2，只需从后向前遍历数组，逢99进11，直至非99结束。
    // 对于上述情况3，我们在最开始不需要与情况2区分，只需要在按照情况2遍历结束后判断首位，若首位为00，则代表情况3出现，此时直接在vector末尾添加1个00，再将首位由00变为11即可。
    public int[] PlusOne(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            // 最后一位是9, 则继续遍历上一位,
            // 出现全部是9 的情况, 里面的值就会变成全部0
            if (digits[i] == 9)
            {
                digits[i] = 0;
            }
            // 最后一位小于9, 直接加1
            else
            {
                digits[i]++;
                break;
            }
        }
        // 如果首位是0, 表示进位
        if (digits[0] == 0)
        {
            ////因为 C# 中 int 类型的默认值为 0 ，所以现在 digits 数组所有元素其值全部为零
            //只需改变第一个元素的值即可
            digits    = new int[digits.Length + 1];
            digits[0] = 1;
        }

        return digits;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
