//一个单词的缩写需要遵循 <起始字母><中间字母数><结尾字母> 这样的格式。 
//
// 以下是一些单词缩写的范例： 
//
// a) it                      --> it    (没有缩写)
//
//     1
//     ↓
//b) d|o|g                   --> d1g
//
//              1    1  1
//     1---5----0----5--8
//     ↓   ↓    ↓    ↓  ↓    
//c) i|nternationalizatio|n  --> i18n
//
//              1
//     1---5----0
//     ↓   ↓    ↓
//d) l|ocalizatio|n          --> l10n
// 
//
// 假设你有一个字典和一个单词，请你判断该单词的缩写在这本字典中是否唯一。若单词的缩写在字典中没有任何 其他 单词与其缩写相同，则被称为单词的唯一缩写。 
//
// 示例： 
//
// 给定 dictionary = [ "deer", "door", "cake", "card" ]
//
//isUnique("dear") -> false
//isUnique("cart") -> true
//isUnique("cane") -> false
//isUnique("make") -> true
// 
// Related Topics 设计 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class ValidWordAbbr
{
    Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

    public ValidWordAbbr(string[] dictionary)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var str in dictionary)
        {
            sb.Clear();
            if (str.Length < 2)
                sb.Append(str);
            else
                sb.Append(str[0]).Append(str.Length - 2).Append(str[str.Length - 1]);

            if (!dic.ContainsKey(sb.ToString()))
                dic[sb.ToString()] = new List<string>();
            // 字典中重复的字符串不加入列表
            if(!dic[sb.ToString()].Contains(str))
                dic[sb.ToString()].Add(str);
        }
    }

    public bool IsUnique(string word)
    {
        StringBuilder sb = new StringBuilder();
        if (word.Length < 2)
            sb.Append(word);
        else
            sb.Append(word[0]).Append(word.Length - 2).Append(word[word.Length - 1]);
            
        if(!dic.ContainsKey(sb.ToString()))
            return true;

        if (dic[sb.ToString()].Contains(word) && dic[sb.ToString()].Count==1)
            return true;
        return false;
    }
}

/**
 * Your ValidWordAbbr object will be instantiated and called as such:
 * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
 * bool param_1 = obj.IsUnique(word);
 */
//leetcode submit region end(Prohibit modification and deletion)
