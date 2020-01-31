//给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回 -1。 
//
// 案例: 
//
// 
//s = "leetcode"
//返回 0.
//
//s = "loveleetcode",
//返回 2.
// 
//
// 
//
// 注意事项：您可以假定该字符串只包含小写字母。 
// Related Topics 哈希表 字符串


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public int FirstUniqChar(string s)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>(); //建立一个哈希表储存出现过的元素
        for (int i = 0; i < s.Length; i++)
        {
            if (!dic.ContainsKey(s[i]))
            {
                dic.Add(s[i], i); //未出现的元素,保存数值和索引
            }
            else
            {
                dic[s[i]] = -1; //出现过的元素,将value改为-1,意思是已经作废了
            }
        }

        foreach (var item in dic.Values)
        {
            //从字典里找一个value不是-1的value,就是答案需要的索引
            if (item != -1)
            {
                return item;
            }
        }

        return -1;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
