//给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。 
//
// 示例: 
//
// 输入: ["eat", "tea", "tan", "ate", "nat", "bat"],
//输出:
//[
//  ["ate","eat","tea"],
//  ["nat","tan"],
//  ["bat"]
//] 
//
// 说明： 
//
// 
// 所有输入均为小写字母。 
// 不考虑答案输出的顺序。 
// 
// Related Topics 哈希表 字符串


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 先遍历, 排序字符, 相等的放入字典中
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var res = new List<IList<string>>();
        var grp = new Dictionary<string, IList<string>>();

        // 遍历每一个字符串
        foreach (var str in strs)
        {
            // Concat:将指定字符串连接到此字符串的结尾
            // OrderBy 将char升序排列
            // rt是排序过的字母 eat -> aet
            string rt = String.Concat(str.OrderBy(ch => ch));

            // 放入字典中
            if (grp.ContainsKey(rt))
            {
                grp[rt].Add(str);
            }
            else
            {
                grp[rt] = new List<string>{str};
            }
        }

        foreach (var key in grp.Keys)
        {
            res.Add(grp[key]);
        }

        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
