using System;
using System.Linq;
using System.Text;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        /// <summary>
        /// 判断后一半反转的数和前一半的数是否相等.
        /// 96ms
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            // 末尾为 0 就可以直接返回 false
            // 题目示例:-121负数反转为121-,不认为是回文数,因此此处忽略负数的判断
            if (x < 0 || (x % 10 == 0 && x != 0)) 
                return false;
            int revertedNumber = 0;
            
            // 回文数取后面一半的数字,反转后与前面一半的数字比较
            while (x > revertedNumber)
            {
                // 依次取出x最后一位
                revertedNumber =  revertedNumber * 10 + x % 10;
                // x去掉最后一位
                x /= 10;
                
                // 1221: 122 , 1 -> 12 , 12 -> 12 > 12 ? 判断是否相等
            }

            return x == revertedNumber || x == revertedNumber / 10;
        }
        
        /// <summary>
        /// 反转字符串解法.
        /// 92ms
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome2(int x) 
        {
            return x.ToString() == new String(x.ToString().Reverse().ToArray());
        }
        
        
        
    }
}