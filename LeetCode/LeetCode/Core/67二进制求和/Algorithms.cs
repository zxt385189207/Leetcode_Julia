/*
给定两个二进制字符串，返回他们的和（用二进制表示）。

输入为非空字符串且只包含数字 1 和 0。

示例 1:

输入: a = "11", b = "1"
输出: "100"
示例 2:

输入: a = "1010", b = "1011"
输出: "10101"

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/add-binary
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */

using System;
using System.Linq;
using System.Text;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        public String AddBinary(String a, String b)
        {
            StringBuilder ans = new StringBuilder();
            // 是否进位
            int           ca  = 0;
            // 两个字符串都遍历完才退出循环
            for (int i = a.Length - 1, j = b.Length - 1; i >= 0 || j >= 0; i--, j--)
            {
                int sum = ca;
                // 如果下标小于0, 则代表遍历完, 自动补0
                sum += i >= 0 ? a[i] - '0' : 0;
                sum += j >= 0 ? b[j] - '0' : 0;
                ans.Append(sum % 2);
                // sum 大于等于2 就表示要进位 也就是ca=1就要进位
                ca = sum / 2;
            }
            // 判断第一位是否进位
            ans.Append(ca == 1 ? ca.ToString() : "");
            // 反转字符串
            return new String(ans.ToString().Reverse().ToArray());
        }
    }
}