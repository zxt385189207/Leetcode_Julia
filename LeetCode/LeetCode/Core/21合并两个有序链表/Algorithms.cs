/*
 * 给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。

有效字符串需满足：

左括号必须用相同类型的右括号闭合。
左括号必须以正确的顺序闭合。
注意空字符串可被认为是有效字符串。

示例 1:

输入: "()"
输出: true
示例 2:

输入: "()[]{}"
输出: true
示例 3:

输入: "(]"
输出: false
示例 4:

输入: "([)]"
输出: false
示例 5:

输入: "{[]}"
输出: true

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/valid-parentheses
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        /// <summary>
        /// 用栈配对
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool isValid(String s)
        {
            // 用栈保存 (，[，{
            Stack<char> stack = new Stack<char>();

            // dic中保存的是 ):(, ]:[,}:{
            // 当遍历到 )时候就会去dic中找对应的value，也就是(
            // 再用这个value和stack弹出的元素比较，如果相等则匹配上，不等则返回false
            Dictionary<char, char> dic = new Dictionary<char, char>
            {
                {')', '('},
                {']', '['},
                {'}', '{'}
            };
            char[] c = s.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                // 如果字符是 ( [ { 就放入栈
                if (!dic.ContainsKey(c[i]))
                {
                    stack.Push(c[i]);
                }
                else // 字符是) ] }
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    // 取出栈顶的元素
                    char temp = stack.Pop();
                    // 比较字符和dic中的对应值, 是否匹配
                    if (dic[c[i]] != temp)
                    {
                        return false;
                    }
                }
            }

            //返回的时候还要判断栈是否为空
            //如果输入的字符串是 (((，那么最后栈就不为空
            return stack.Count == 0;
        }

        /// <summary>
        /// 字符串replace,消消乐方式.
        /// 超时
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool isValid2(String s)
        {
            StringBuilder sb = new StringBuilder(s);

            while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
            {
                //假设输入的字符是((()))，第一次替换完字符串就变成了(())
                //第二次替换变成()，第三次就是""
                if (s.Contains("()"))
                {
                    sb.Replace(@"()", "");
                }

                //对于嵌套包含也是一样，([{}])
                //第一次会被替换成([])，第二次替换成()，第三次是""
                if (s.Contains("[]"))
                {
                    sb.Replace(@"[]", "");
                }

                if (s.Contains("{}"))
                {
                    sb.Replace(@"()", "");
                }

                s = sb.ToString();
            }

            return "".Equals(s);
        } 
        

        /// <summary>
        /// 递归,执行很慢
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool isValid3(String s)
        {
            if (s.Contains("()") || s.Contains("[]") || s.Contains("{}") || s.Contains(" "))
            {
                string news = s.Replace("()", "").Replace("[]", "").Replace("{}", "").Replace(" ", "");
                return isValid3(news);
            }
            else
            {
                return s.Length > 0 ? false : true;
            }
        }
    }
}