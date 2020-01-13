/*
 * 实现 strStr() 函数。

给定一个 haystack 字符串和一个 needle 字符串，在 haystack 字符串中找出 needle 字符串出现的第一个位置 (从0开始)。如果不存在，则返回  -1。

示例 1:

输入: haystack = "hello", needle = "ll"
输出: 2
示例 2:

输入: haystack = "aaaaa", needle = "bba"
输出: -1
说明:

当 needle 是空字符串时，我们应当返回什么值呢？这是一个在面试中很好的问题。

对于本题而言，当 needle 是空字符串时我们应当返回 0 。这与C语言的 strstr() 以及 Java的 indexOf() 定义相符。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/implement-strstr
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */


using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        
        // API IndexOf()
        
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            int n = haystack.Length; // 查找的字符串长度
            int m = needle.Length; // 需要查找的字符串长度
            
            // 这里只需要遍历n-m+1次
            for (int i = 0; i < n - m + 1; i++)
            {
                int j = 0;
                for (; j < m; j++)
                {
                    // 不匹配
                    if (haystack[i + j] != needle[j])
                        // 为了保证在这个循环里haystack的索引也跟着needle索引一起向前推进，
                        // i的含义设置为起始点，i + j才是haystack的索引
                        break;
                }
                // 如果匹配的字符串长度等于needle长度, 就返回下标
                if (j == m)
                    return i;
            }

            return -1;
        }
    }
}