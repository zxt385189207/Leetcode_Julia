//给定一个仅包含大小写字母和空格 ' ' 的字符串 s，返回其最后一个单词的长度。 
//
// 如果字符串从左向右滚动显示，那么最后一个单词就是最后出现的单词。 
//
// 如果不存在最后一个单词，请返回 0 。 
//
// 说明：一个单词是指仅由字母组成、不包含任何空格的 最大子字符串。 
//
// 
//
// 示例: 
//
// 输入: "Hello World"
//输出: 5
// 
// Related Topics 字符串


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
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
//leetcode submit region end(Prohibit modification and deletion)
