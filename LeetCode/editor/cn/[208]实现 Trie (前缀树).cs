//实现一个 Trie (前缀树)，包含 insert, search, 和 startsWith 这三个操作。 
//
// 示例: 
//
// Trie trie = new Trie();
//
//trie.insert("apple");
//trie.search("apple");   // 返回 true
//trie.search("app");     // 返回 false
//trie.startsWith("app"); // 返回 true
//trie.insert("app");   
//trie.search("app");     // 返回 true 
//
// 说明: 
//
// 
// 你可以假设所有的输入都是由小写字母 a-z 构成的。 
// 保证所有输入均为非空字符串。 
// 
// Related Topics 设计 字典树

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
        public bool isEnd;

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
        /// 如果trie中有任何以给定前缀开头的单词，则返回true
        /// </summary>
        public bool StartsWith(string prefix)
        {
            TrieNode node = SearchPrefix(prefix);
            // 不需要检查IsEnd, 只是搜索前缀,
            return node != null;
        }
    }


/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
//leetcode submit region end(Prohibit modification and deletion)
