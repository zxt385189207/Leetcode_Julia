//给定一个经过编码的字符串，返回它解码后的字符串。 
//
// 编码规则为: k[encoded_string]，表示其中方括号内部的 encoded_string 正好重复 k 次。注意 k 保证为正整数。 
//
// 你可以认为输入字符串总是有效的；输入字符串中没有额外的空格，且输入的方括号总是符合格式要求的。 
//
// 此外，你可以认为原始数据不包含数字，所有的数字只表示重复的次数 k ，例如不会出现像 3a 或 2[4] 的输入。 
//
// 示例: 
//
// 
//s = "3[a]2[bc]", 返回 "aaabcbc".
//s = "3[a2[c]]", 返回 "accaccacc".
//s = "2[abc]3[cd]ef", 返回 "abcabccdcdcdef".
// 
// Related Topics 栈 深度优先搜索


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 辅助栈
    public string DecodeString(string s)
    {
        StringBuilder res   = new StringBuilder();
        int           multi = 0;

        Stack<int>    stack_multi = new Stack<int>();
        Stack<String> stack_res   = new Stack<String>();

        foreach (char c in s.ToArray())
        {
            if (c == '[')
            {
                // 把要重复的次数放入栈中
                stack_multi.Push(multi);
                stack_res.Push(res.ToString());
                multi = 0;
                res   = new StringBuilder();
            }
            else if (c == ']')
            {
                StringBuilder tmp       = new StringBuilder();
                int           cur_multi = stack_multi.Pop();
                for (int i = 0; i < cur_multi; i++)
                    tmp.Append(res);
                res = new StringBuilder(stack_res.Pop() + tmp);
            }
            else if (c >= '0' && c <= '9')
            {
                // 如果出现多位数字, *10递增
                multi = multi * 10 + Int32.Parse(c.ToString());
            }
            else 
                res.Append(c);
        }

        return res.ToString();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
