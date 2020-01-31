//判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。 
//
// 示例 1: 
//
// 输入: 121
//输出: true
// 
//
// 示例 2: 
//
// 输入: -121
//输出: false
//解释: 从左向右读, 为 -121 。 从右向左读, 为 121- 。因此它不是一个回文数。
// 
//
// 示例 3: 
//
// 输入: 10
//输出: false
//解释: 从右向左读, 为 01 。因此它不是一个回文数。
// 
//
// 进阶: 
//
// 你能不将整数转为字符串来解决这个问题吗？ 
// Related Topics 数学


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 判断后一半反转的数和前一半的数是否相等.
    /// 96ms
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public bool IsPalindrome(int x)
    {
        // 末尾为 0 就可以直接返回 false
        // 题目示例:-121负数反转为121-,不认为是回文数,因此此处忽略负数的判断
        if (x < 0 || (x % 10 == 0 && x != 0)) 
            return false;
        int revertedNumber = 0;
            
        // 回文数取后面一半的数字,反转后与前面一半的数字比较
        while (x > revertedNumber)
        {
            // 依次取出x最后一位
            revertedNumber = revertedNumber * 10 + x % 10;
            // x去掉最后一位
            x /= 10;
                
            // 1221: 122 , 1 -> 12 , 12 -> 12 > 12 ? 判断是否相等
        }

        return x == revertedNumber || x == revertedNumber / 10;
    }
        
    /// <summary>
    /// 反转字符串解法.
    /// 92ms
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public bool IsPalindrome2(int x) 
    {
        return x.ToString() == new String(x.ToString().Reverse().ToArray());
    }

}
//leetcode submit region end(Prohibit modification and deletion)
