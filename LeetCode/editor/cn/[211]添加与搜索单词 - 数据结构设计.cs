//设计一个支持以下两种操作的数据结构： 
//
// void addWord(word)
//bool search(word)
// 
//
// search(word) 可以搜索文字或正则表达式字符串，字符串只包含字母 . 或 a-z 。 . 可以表示任何一个字母。 
//
// 示例: 
//
// addWord("bad")
//addWord("dad")
//addWord("mad")
//search("pad") -> false
//search("bad") -> true
//search(".ad") -> true
//search("b..") -> true
// 
//
// 说明: 
//
// 你可以假设所有单词都是由小写字母 a-z 组成的。 
// Related Topics 设计 字典树 回溯算法


//leetcode submit region begin(Prohibit modification and deletion)
using System.Text;
using System.Text.RegularExpressions;
public class TrieNode
{
    public TrieNode() => dic = new Dictionary<char, TrieNode>();

    /// <summary>
    /// 维护节点中的字典, 字符和对应的节点(连线)
    /// </summary>
    public Dictionary<char, TrieNode> dic;

    /// <summary>
    /// 是否是单词末尾
    /// </summary>
    private bool isEnd;

    /// <summary>
    /// 节点中的字典是否存在ch这个字符对应连接的下一个节点
    /// </summary>
    public bool ContainsKey(char ch) => dic.ContainsKey(ch);

    /// <summary>
    /// 获取字符对应连接的下一个节点
    /// </summary>
    public TrieNode Get(char ch) => dic[ch];

    /// <summary>
    /// 放入字符和对应连接的下一个节点
    /// </summary>
    public void Put(char ch, TrieNode node) => dic[ch] = node;

    /// <summary>
    /// 设置单词结束
    /// </summary>
    public void SetEnd() => isEnd = true;

    /// <summary>
    /// 返回是否是一个完整单词
    /// </summary>
    public bool IsEnd() => isEnd;
}

// 减少空间浪费, 使用字典,而不是固定长度的数组
public class Trie
{
    public TrieNode root;

    /** Initialize your data structure here. */
    public Trie()
    {
        root = new TrieNode();
    }

    /// <summary>
    /// 往前缀树插入单词
    /// </summary>
    public void Insert(string word)
    {
        TrieNode node = root;
        for (int i = 0; i < word.Length; i++)
        {
            char currentChar = word[i];
            // 填充根节点对应字符的子节点
            if (!node.ContainsKey(currentChar))
            {
                node.Put(currentChar, new TrieNode());
            }

            // 进入该字符的子节点, 迭代下一个字符
            // 沿着链接移动到树的下一个子层。算法继续搜索下一个键字符。
            node = node.Get(currentChar);
        }

        // 遍历完此单词设置标志位flag
        node.SetEnd();
    }

    /// <summary>
    /// 搜索前缀,返回最后一个字符连接的下一个节点
    /// </summary>
    private TrieNode SearchPrefix(String word)
    {
        TrieNode node = root;
        for (int i = 0; i < word.Length; i++)
        {
            char currentChar = word[i];
            if (node.ContainsKey(currentChar))
            {
                node = node.Get(currentChar);
            }
            else
            {
                return null;
            }
        }

        return node;
    }

    /// <summary>
    /// 是否包含单词(标有End结尾)
    /// </summary>
    public bool Search(string word)
    {
        var node = SearchPrefix(word);
        // 需要判断是否设置了单词结束的标志位
        return node != null && node.IsEnd();
    }

    /// <summary>
    /// 递归匹配
    /// </summary>
    /// <param name="word"></param>
    /// <param name="node"></param>
    /// <param name="start"></param>
    /// <returns></returns>
    public bool SearchMatch(string word, TrieNode node, int start)
    {
        TrieNode curr = node;

        for (int i = start; i < word.Length; i++)
        {
            if (word[i] == '.')
            {
                foreach (var trieNode in curr.dic)
                {
                    if (SearchMatch(word, trieNode.Value, start + 1))
                    {
                        return true;
                    }
                }

                return false;
            }

            // 如果不包括对应的连接, 返回false
            if (!curr.ContainsKey(word[i]))
            {
                return false;
            }

            // 
            curr = curr.Get(word[i]);
            start++;
        }

        return curr.IsEnd();
    }

    /// <summary>
    /// 如果trie中有任何以给定前缀开头的单词，则返回true
    /// </summary>
    public bool StartsWith(string prefix)
    {
        TrieNode node = SearchPrefix(prefix);
        // 不需要检查IsEnd, 只是搜索前缀,
        return node != null;
    }
}

// 前缀树解法
public class WordDictionary
{
    public Trie Trie = new Trie();

    public WordDictionary()
    {
    }

    /** Adds a word into the data structure. */
    public void AddWord(string word)
    {
        Trie.Insert(word);
    }

    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word)
    {
        return Trie.SearchMatch(word, Trie.root, 0);
    }
}

// 正则表达式解法
// 会超时
public class WordDictionary2
{
    StringBuilder sb;

    public WordDictionary2()
    {
        sb = new StringBuilder();
        sb.Append('#');
    }

    /** Adds a word into the data structure. */
    public void AddWord(string word)
    {
        sb.Append(word);
        sb.Append('#');
    }

    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word)
    {
        string p = new string('#' + word + '#');
        var    m = Regex.Matches(sb.ToString(), p);
        return m.Count == 0;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
//leetcode submit region end(Prohibit modification and deletion)
