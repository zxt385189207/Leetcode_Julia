//「外观数列」是一个整数序列，从数字 1 开始，序列中的每一项都是对前一项的描述。前五项如下： 
//
// 1.     1
//2.     11
//3.     21
//4.     1211
//5.     111221
// 
//
// 1 被读作 "one 1" ("一个一") , 即 11。 
//11 被读作 "two 1s" ("两个一"）, 即 21。 
//21 被读作 "one 2", "one 1" （"一个二" , "一个一") , 即 1211。 
//
// 给定一个正整数 n（1 ≤ n ≤ 30），输出外观数列的第 n 项。 
//
// 注意：整数序列中的每一项将表示为一个字符串。 
//
// 
//
// 示例 1: 
//
// 输入: 1
//输出: "1"
// 
//
// 示例 2: 
//
// 输入: 4
//输出: "1211"
// 
// Related Topics 字符串




//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public string CountAndSay(int n) {
                    string str, res;
                    // 起始数列
                    res = "1";
                    for (int i = 1; i < n; i++)
                    {
                        // 赋值上一个数列
                        str = res;
                        res = "";
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
                            res += c.ToString() + str[j];
                            // 跳过连续重复的数字,
                            j   =  k;
                        }
                    }
        
                    return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
