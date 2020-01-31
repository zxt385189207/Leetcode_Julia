//给定一个字符串，逐个翻转字符串中的每个单词。 
//
// 
//
// 示例 1： 
//
// 输入: "the sky is blue"
//输出: "blue is sky the"
// 
//
// 示例 2： 
//
// 输入: "  hello world!  "
//输出: "world! hello"
//解释: 输入字符串可以在前面或者后面包含多余的空格，但是反转后的字符不能包括。
// 
//
// 示例 3： 
//
// 输入: "a good   example"
//输出: "example good a"
//解释: 如果两个单词间有多余的空格，将反转后单词间的空格减少到只含一个。
// 
//
// 
//
// 说明： 
//
// 
// 无空格字符构成一个单词。 
// 输入字符串可以在前面或者后面包含多余的空格，但是反转后的字符不能包括。 
// 如果两个单词间有多余的空格，将反转后单词间的空格减少到只含一个。 
// 
//
// 
//
// 进阶： 
//
// 请选用 C 语言的用户尝试使用 O(1) 额外空间复杂度的原地解法。 
// Related Topics 字符串


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 库函数解决
    public string ReverseWords(string s)
    {
        // Join 在指定 String 数组的每个元素之间串联指定的分隔符 String，从而产生单个串联的字符串
        // 用空格串联 通过Split用空格分割的字符串数组
        // StringSplitOptions.RemoveEmptyEntries 去除空数据, 比如连续两个空格之间会产生""空字符串, 用来去除这样的
        // str.Split(",");//保留空数据
        // 最后再反转这个列表
        return string.Join(" ", s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Reverse());
        
    }
}
//leetcode submit region end(Prohibit modification and deletion)
