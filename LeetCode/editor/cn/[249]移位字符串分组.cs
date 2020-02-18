//给定一个字符串，对该字符串可以进行 “移位” 的操作，也就是将字符串中每个字母都变为其在字母表中后续的字母，比如："abc" -> "bcd"。这样，我们可
//以持续进行 “移位” 操作，从而生成如下移位序列： 
//
// "abc" -> "bcd" -> ... -> "xyz" 
//
// 给定一个包含仅小写字母字符串的列表，将该列表中所有满足 “移位” 操作规律的组合进行分组并返回。 
//
// 示例： 
//
// 输入: ["abc", "bcd", "acef", "xyz", "az", "ba", "a", "z"]
//输出: 
//[
//  ["abc","bcd","xyz"],
//  ["az","ba"],
//  ["acef"],
//  ["a","z"]
//]
// 
// Related Topics 哈希表 字符串


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public IList<IList<string>> GroupStrings(string[] strings)
    {
        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        StringBuilder                    sb  = new StringBuilder();

        foreach (var str in strings)
        {
            sb.Clear();
            char[] chars = str.ToCharArray();
            //如果只有一个元素，则将差值记为"*"
            if (chars.Length == 1)
                sb.Append("*");
            for (int i = 1; i < chars.Length; i++)
            {
                // 前后两个字符差如果是负数就加26
                int diff = chars[i] - chars[i - 1] < 0 ? chars[i] - chars[i - 1] + 26 : chars[i] - chars[i - 1];
                // abc -> "1,1,1,"
                sb.Append(diff).Append(",");
            }

            if (!dic.ContainsKey(sb.ToString()))
                dic[sb.ToString()] = new List<string>();
            dic[sb.ToString()].Add(str);
        }
        return new List<IList<string>>(dic.Values);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
