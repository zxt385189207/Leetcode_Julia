//在英语中，我们有一个叫做 词根(root)的概念，它可以跟着其他一些词组成另一个较长的单词——我们称这个词为 继承词(successor)。例如，词根an，
//跟随着单词 other(其他)，可以形成新的单词 another(另一个)。 
//
// 现在，给定一个由许多词根组成的词典和一个句子。你需要将句子中的所有继承词用词根替换掉。如果继承词有许多可以形成它的词根，则用最短的词根替换它。 
//
// 你需要输出替换之后的句子。 
//
// 示例 1: 
//
// 
//输入: dict(词典) = ["cat", "bat", "rat"]
//sentence(句子) = "the cattle was rattled by the battery"
//输出: "the cat was rat by the bat"
// 
//
// 注: 
//
// 
// 输入只包含小写字母。 
// 1 <= 字典单词数 <=1000 
// 1 <= 句中词语数 <= 1000 
// 1 <= 词根长度 <= 100 
// 1 <= 句中词语长度 <= 1000 
// 
// Related Topics 字典树 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
        public class Trie
        {
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

                public string word;

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

                node.word = word;
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

        // 前缀树解法
        // 时间复杂度：O(N)，其中 N 是 sentence 的长度。每次查询操作为线性时间复杂度。
        // 空间复杂度：O(N)，前缀树的大小。
        public string ReplaceWords(IList<string> dict, string sentence)
        {
            Trie trie = new Trie();

            // 把词根放入前缀树
            foreach (var str in dict)
            {
                trie.Insert(str);
            }

            IList<string> list = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var str in list)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                Trie.TrieNode cur = trie.root;
                for (int i = 0; i < str.Length; i++)
                {
                    // 如果当前是完整的前缀, 打断循环替换成这个词缀
                    if (cur.ContainsKey(str[i]) == false || cur.IsEnd())
                        break;

                    cur = cur.dic[str[i]];
                    // 以下是二货做法, 没有利用好前缀树, 耗时很多
                    // if (trie.Search(str.Substring(0, i + 1)))
                    // {
                    //     sb.Append(str.Substring(0, i + 1));
                    //     break;
                    // }
                    //
                    // if (i == str.Length - 1)
                    // {
                    //     sb.Append(str);
                    // }
                }

                sb.Append(cur.word ?? str);
            }

            return sb.ToString();
        }


        // 前缀哈希 超时
        public string ReplaceWords1(IList<string> dict, string sentence)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var str in dict)
            {
                set.Add(str);
            }

            IList<string> list = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb   = new StringBuilder();
            foreach (var str in list)
            {
                String prefix = "";
                for (int i = 0; i < str.Length; i++)
                {
                    prefix = str.Substring(0, i + 1);
                    if (set.Contains(prefix))
                        break;
                }

                sb.Append(prefix + " ");
            }

            return sb.ToString().Trim();
        }
}
//leetcode submit region end(Prohibit modification and deletion)
