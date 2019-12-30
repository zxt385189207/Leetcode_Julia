using System;
using System.Collections.Generic;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        /// <summary>
        /// 最简单易懂的方法: 维护一个List
        /// </summary>
        /// <param name="s"></param>
        public int LengthOfLongestSubstring(string s)
        {
            List<char> ls = new List<char>();
            // 减少每次for循环判断的次数
            int n = s.Length;

            int intMaxLength = 0;

            for (int i = 0; i < n; i++)
            {
                // 是否包含重复的字符
                if (ls.Contains(s[i]))
                {
                    // RemoveRange 删除指定索引段的项，第一个参数为删除的起始索引，第二个参数为删除的个数
                    // IndexOf 搜索指定的对象，并返回整个范围内第一个匹配项的从零开始的索引
                    ls.RemoveRange(0, ls.IndexOf(s[i]) + 1);
                }

                // 在list中添加字符
                ls.Add(s[i]);
                // 当前子串最大的长度 = list的长度 > 当前最大长度 ? 
                intMaxLength = ls.Count > intMaxLength ? ls.Count : intMaxLength;
            }

            return intMaxLength;
        }

        /*
         * 思路解析:
         * 引入left游标记录字符串左边的起始位置，遍历索引right相当于其右边结束位置。
         * 这里需要注意的是，left更新的时候要更新为left和index[s[right]])二者中较大的一个。
         *
         * 使用数组来代替map，这是一种常用的方法。将map的key作为数组的索引，value作为数组的值进行转化。
         * int[26] for Letters 'a' - 'z' or 'A' - 'Z'
         * int[128] for ASCII
         * int[256] for Extended ASCII
         */

        /// <summary>
        /// 优化的滑动窗口算法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring2(string s)
        {
            int ans = 0;
            // int[128] for ASCII
            int[] index = new int[128];
            // [left, right]字符下标
            int left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                // s[right] 如果字符相同, 则移动left下标
                left            = Math.Max(index[s[right]], left);
                ans             = Math.Max(ans, right - left + 1);
                // 设置right每循环一次向右挪动一格
                // index[`a`] = 2; 代表字符a的下标是1, 第2个字符, s[1] = a;
                index[s[right]] = right + 1; 
            }
            return ans;
//            String s = "adaea" 
//
//            s    [0] = a;
//                [left:0 , right:0]
//            index[`a`] = 1;
//
//            s    [1] = d;
//                [left:0 , right:1]
//            index[`d`] = 2;
//
//            s    [2] = a;
//                [left:1 , right:2]
//            index[`a`] = 3;
//
//            s    [3] = e;
//                [left:1 , right:3]
//            index[`e`] = 4;
//
//            s    [4] = a;
//                [left:3 , right:4]
//            index[`a`] = 5; 

        }
    }
}

