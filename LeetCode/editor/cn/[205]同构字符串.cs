//给定两个字符串 s 和 t，判断它们是否是同构的。 
//
// 如果 s 中的字符可以被替换得到 t ，那么这两个字符串是同构的。 
//
// 所有出现的字符都必须用另一个字符替换，同时保留字符的顺序。两个字符不能映射到同一个字符上，但字符可以映射自己本身。 
//
// 示例 1: 
//
// 输入: s = "egg", t = "add"
//输出: true
// 
//
// 示例 2: 
//
// 输入: s = "foo", t = "bar"
//输出: false 
//
// 示例 3: 
//
// 输入: s = "paper", t = "title"
//输出: true 
//
// 说明: 
//你可以假设 s 和 t 具有相同的长度。 
// Related Topics 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // s中各字母首次出现下标的序列为: [0, 1, 0, 3, 4]， paper
    // t中各字母首次出现下标的序列为: [0, 1, 0, 3, 4],  title
    // 因为下标数组一致，所以两字符串同构。
    public bool IsIsomorphic(string s, string t)
    {
        List<int> indexS = new List<int>();
        List<int> indexT = new List<int>();

        for (int i = 0; i < s.Length; i++)
            indexS.Add(s.IndexOf(s[i]));

        for (int j = 0; j < t.Length; j++)
            indexT.Add(t.IndexOf(t[j]));

        return indexS.SequenceEqual(indexT);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
