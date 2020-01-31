//编写一个函数来查找字符串数组中的最长公共前缀。 
//
// 如果不存在公共前缀，返回空字符串 ""。 
//
// 示例 1: 
//
// 输入: ["flower","flow","flight"]
//输出: "fl"
// 
//
// 示例 2: 
//
// 输入: ["dog","racecar","car"]
//输出: ""
//解释: 输入不存在公共前缀。
// 
//
// 说明: 
//
// 所有输入只包含小写字母 a-z 。 
// Related Topics 字符串


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 利用IndexOf去匹配不断分割的字符串s[0],
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public String LongestCommonPrefix(String[] strs)
    {
        if (strs.Length == 0)
            return "";
            
        String prefix = strs[0];
        for (int i = 1; i < strs.Length; i++)
        {
            // IndexOf就返回-1是没找到, 其他代表找到的序号
            while (strs[i].IndexOf(prefix, StringComparison.Ordinal) != 0)
            {
                // 不存在则不断剪切第一串字符串strs[0]
                prefix = prefix.Substring(0, prefix.Length - 1);
                   
                // 不存在这个公共前缀
                if (String.IsNullOrEmpty(prefix))
                    return "";
            }
        }
        return prefix;
    }
        
    /// <summary>
    /// 字符逐个匹配
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public string LongestCommonPrefix2(string[] strs)
    {
        if (strs == null || strs.Length == 0)
            return string.Empty;

        for (int i = 0; i < strs[0].Length; i++) // 遍历第一个字符串所有的字符
        {
            var current = strs[0][i];

            for (int j = 1; j < strs.Length; j++) // 遍历字符串数组
            {
                // 判断第二个字符串的对应字符是否相等, 不相等可以直接返回结果
                if (strs[j].Length < i + 1 || current != strs[j][i])
                    return strs[0].Substring(0, i);
            }
        }

        return strs[0];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
