/*
 * 给定一个仅包含大小写字母和空格 ' ' 的字符串，返回其最后一个单词的长度。

如果不存在最后一个单词，请返回 0 。

说明：一个单词是指由字母组成，但不包含任何空格的字符串。

示例:

输入: "Hello World"
输出: 5

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/length-of-last-word
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */

using System;
using System.Linq;
using System.Text;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        public int LengthOfLastWord(string s)
        {
            // 去除首尾空格, 反转字符串,IndexOf(" ")计算
            s = new string(s.Trim().Reverse().ToArray());
            int i = s.IndexOf(" ");
            if (i > 0)
            {
                return i;
            }
            else if(i == -1 && s.Length > 0)
            {
                return s.Length;
            }
            else
            {
                return 0;
            }
        }

    }
}