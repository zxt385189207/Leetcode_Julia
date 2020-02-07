//给一非空的单词列表，返回前 k 个出现次数最多的单词。 
//
// 返回的答案应该按单词出现频率由高到低排序。如果不同的单词有相同出现频率，按字母顺序排序。 
//
// 示例 1： 
//
// 
//输入: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
//输出: ["i", "love"]
//解析: "i" 和 "love" 为出现次数最多的两个单词，均为2次。
//    注意，按字母顺序 "i" 在 "love" 之前。
// 
//
// 
//
// 示例 2： 
//
// 
//输入: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k
// = 4
//输出: ["the", "is", "sunny", "day"]
//解析: "the", "is", "sunny" 和 "day" 是出现次数最多的四个单词，
//    出现次数依次为 4, 3, 2 和 1 次。
// 
//
// 
//
// 注意： 
//
// 
// 假定 k 总为有效值， 1 ≤ k ≤ 集合元素数。 
// 输入的单词均由小写字母组成。 
// 
//
// 
//
// 扩展练习： 
//
// 
// 尝试以 O(n log k) 时间复杂度和 O(n) 空间复杂度解决。 
// 
// Related Topics 堆 字典树 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 字典
    public IList<string> TopKFrequent(string[] words, int k)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();

        foreach (var word in words)
        {
            dic[word] = dic.ContainsKey(word) ? dic[word] + 1 : 1;
        }

        var res = dic.OrderByDescending(s => s.Value).ThenBy(s => s.Key).Take(k).ToList();

        List<string> list = new List<string>();

        for (int i = 0; i < k; i++)
        {
            list.Add(res[i].Key);
        }


        return list;
    }

    // LINQ
    public IList<string> TopKFrequent2(string[] words, int k)
    {
        IList<string> list = new List<string>();
        
        // 以单个字符串为键分组
        words.GroupBy(x => x)
            // 创建一个匿名类, 存储键和重复的个数
            .Select(x => new {id = x, count = x.Count()})
            // 以个数升序排列
            .OrderByDescending(x => x.count)
            // 个数相同的情况下以匿名类的id也就是string字符串升序排列
            .ThenBy(x => x.id.Key)
            // 取前K个
            .Take(k)
            .ToList()
            .ForEach(x=>list.Add(x.id.Key));  
            
        return list;
    }
    
}
//leetcode submit region end(Prohibit modification and deletion)
