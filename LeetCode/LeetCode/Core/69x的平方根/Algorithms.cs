/*
 * 实现 int sqrt(int x) 函数。

计算并返回 x 的平方根，其中 x 是非负整数。

由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。

示例 1:

输入: 4
输出: 2
示例 2:

输入: 8
输出: 2
说明: 8 的平方根是 2.82842..., 
     由于返回类型是整数，小数部分将被舍去。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/sqrtx
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */

using System;
using System.Linq;
using System.Text;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        // 二分查找
        public int MySqrt1(int x)
        {
            long left  = 0;
            long right = x;
            while (left < right)
            {
                long mid        = (right + left + 1) / 2;
                long tempResult = mid * mid;

                if (tempResult > x)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid;
                }
            }

            return (int)left;

        }       
        
        public int MySqrt2(int x)
        {
            long left = 0, right = x;
            while (left <= right)                  
            {
                long mid = left + (right - left) / 2; 
                long tempResult = mid * mid;
                if (tempResult == x)
                {
                    return (int) mid;
                }
                else if (x > tempResult)
                {
                    left = mid + 1; // 移动left下标到中位数右边一位
                }
                else
                {
                    right = mid - 1; // 移动right下标到中位数左边一位
                }
            }

            // 相关返回值
            return (int) right;
        }

        // 牛顿迭代法
        // 下面这种方法可以很有效地求出根号 x 的近似值：
        // 首先随便猜一个近似值 x，然后不断令 y 等于 y 和 x/y 的平均数，
        // 迭代个六七次后 x 的值就已经相当精确了。
        // x^2-a=0 的根。根号a实际上就是的一个正实根
        // 列方程f(x) = x^2 -a; 求根号a的值
        // 求导可的该函数任意一点上的斜率是2x        
        // 斜率公式 f'(x0) = (f(x) - f(x0)) / (x-x0);
        // => f(x) = f'(x0) * (x - x0) + f(x0)
        // 令f(x) = 0; 求解
        // 得: f'(x0) * (x - x0) + f(x0) = 0;
        // => x = x0 - f(x0)/f'(x0);
        // => x = x0 - (x0^2 -a)/(2*x0)
        // => 1/2 * (x0 + a/x0);
        // 故迭代公式为:
        // x0 = 1/2 * (x0 + a/x0);
        public int MySqrt(int x)
        {
            // 要用long型防止溢出
            long y = x;
            while (y * y > x)
            {
                y = (y + x / y) / 2;
            }

            return (int) y;
        } 

    }
}