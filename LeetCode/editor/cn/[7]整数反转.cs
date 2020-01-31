//给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。 
//
// 示例 1: 
//
// 输入: 123
//输出: 321
// 
//
// 示例 2: 
//
// 输入: -123
//输出: -321
// 
//
// 示例 3: 
//
// 输入: 120
//输出: 21
// 
//
// 注意: 
//
// 假设我们的环境只能存储得下 32 位的有符号整数，则其数值范围为 [−231, 231 − 1]。请根据这个假设，如果反转后整数溢出那么就返回 0。 
// Related Topics 数学


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
        /// <summary>
        /// 使用C#自带的checked和异常解法
        /// 耗时56ms
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            int ret = 0;
            while (x != 0)
            {
                // 取模, 最后一位
                int nextDigit = x % 10;
                // 缩小一位取整
                x = x / 10;
                try
                {
                    //溢出检查的整数型算术运算和转换。
                    //[-2147483648, 2147483647]
                    ret = checked((ret * 10) + nextDigit);
                }
                catch (System.OverflowException)
                {
                    return 0;
                }
            }

            return ret;
        }

        /// <summary>
        /// 不用try catch官方解法
        ///  耗时52ms(替换成数字44ms)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse2(int x)
        {
            //[-2147483648, 2147483647]
            // 思路: 因为(ret * 10) + nextDigit可能会溢出,要检查这句话是否溢出
            // 假设: x是正数, 如果(ret * 10) + nextDigit溢出, 则一定ret >= Int32.MaxValue/10;
            // 判断两种情况, 如果ret > Int32.MaxValue/10;肯定溢出.
            //               如果ret == Int32.MaxValue/10; 只要nextDigit > 7就会溢出(2147483640+8就溢出了)
            // 负数同理 如果ret == Int32.MaxValue/10; 只要只要nextDigit < -8就会溢出(-2147483640-9就溢出)
            int ret = 0;
            while (x != 0)
            {
                // 取模, 最后一位
                int nextDigit = x % 10;
                // 缩小一位取整
                x = x / 10;

                // 如果使用2147483647和-2147483648,运算时间会更快一点
                if (ret > Int32.MaxValue / 10 || (ret == Int32.MaxValue / 10 && nextDigit > 7)) return 0;
                if (ret < Int32.MinValue / 10 || (ret == Int32.MinValue / 10 && nextDigit < -8)) return 0;

                ret = (ret * 10) + nextDigit;
            }

            return ret;
        }

        /// <summary>
        /// 解析字符串解法, 内存耗费略高于前面两种
        /// 耗时:44ms
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse3(int x)
        {
            StringBuilder str = new StringBuilder("");
            if (x < 0)
            {
                str.Append("-");
            }

            try
            {
                return Int32.Parse(str.Append(Math.Abs(x).ToString().Reverse().ToArray()).ToString());
            }
            catch (Exception e)
            {
                return 0;
            }
        }
}
//leetcode submit region end(Prohibit modification and deletion)
