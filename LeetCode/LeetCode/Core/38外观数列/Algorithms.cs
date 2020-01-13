/*
 * 「外观数列」是一个整数序列，从数字 1 开始，序列中的每一项都是对前一项的描述。前五项如下：

1.     1
2.     11
3.     21
4.     1211
5.     111221
1 被读作  "one 1"  ("一个一") , 即 11。
11 被读作 "two 1s" ("两个一"）, 即 21。
21 被读作 "one 2",  "one 1" （"一个二" ,  "一个一") , 即 1211。

给定一个正整数 n（1 ≤ n ≤ 30），输出外观数列的第 n 项。

注意：整数序列中的每一项将表示为一个字符串。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/count-and-say
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
        /// 迭代,  使用StringBuilder能减少操作string字符串带来的损耗
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            StringBuilder str, res;
            //string str, res;
            // 起始数列
            //res = "1";
            res = new StringBuilder("1");

            for (int i = 1; i < n; i++)
            {
                // 赋值上一个数列
                str = new StringBuilder(res.ToString());
                //res = "";
                res.Clear();

                for (int j = 0; j < str.Length;) // 这里没有进行j的递增
                {
                    int c = 0, k = j;
                    // 比较字符是否相等
                    while (k < str.Length && str[k] == str[j])
                    {
                        k++;
                        c++;
                    }

                    // c是个数, str[j]是值
                    res.Append(c.ToString());
                    res.Append(str[j]);
                    // 跳过连续重复的数字,
                    j = k;
                }
            }

            return res.ToString();
        }

        // 打表的方式, O(1), 速度最快
        // public string CountAndSay2(int n)
        // {
        // switch (n)
        // {
        //     case 1: return "1";
        //     case 2: return "11";
        //     case 3:
        //         return "21";
        //     case 4:
        //         return "1211";
        //     case 5:
        //         return "111221";
        //     case 6:
        //         return "312211";
        //     case 7:
        //         return "13112221";
        //     case 8:
        //         return "1113213211";
        //     case 9:
        //         return "31131211131221";
        //     case 10:
        //         return "13211311123113112211";
        //     case 11:
        //         return "11131221133112132113212221";
        //     case 12:
        //         return "3113112221232112111312211312113211";
        //     case 13:
        //         return "1321132132111213122112311311222113111221131221";
        //     case 14:
        //         return "11131221131211131231121113112221121321132132211331222113112211";
        //     case 15:
        //         return "311311222113111231131112132112311321322112111312211312111322212311322113212221";
        //      ....
        //     return "";
        // }
        //}
    }
}