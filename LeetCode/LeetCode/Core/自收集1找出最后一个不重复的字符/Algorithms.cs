/*
//     格式如下：
//     给一个字符串str，找出最后一个不重复的元素 如果存在则返回该元素 否则 返回 "null"（计算时间复杂度)
//     格式如下：
// public string getLastUniqueElement(string str){
// //代码
// }
 */

using System;
using System.Collections.Generic;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        // 利用字典, 遍历2次
        public static string getLastUniqueElement(string str)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int                   min = Int32.MaxValue;
            char                  c   = new char();
            for (int i = 0; i < str.Length; i++)
            {
                if (!dic.ContainsKey(str[i]))
                {
                    dic.Add(str[i], 1);
                }
                else
                {
                    dic[str[i]]++;
                }
            }

            foreach (var item in dic)
            {
                if (item.Value <= min)
                {
                    min = item.Value;
                    c   = item.Key;
                }
            }

            if (min > 1)
            {
                return "false";
            }
            else
            {
                return c.ToString();
            }
        }
    }
}