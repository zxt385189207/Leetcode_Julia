//为搜索引擎设计一个搜索自动补全系统。用户会输入一条语句（最少包含一个字母，以特殊字符 '#' 结尾）。除 '#' 以外用户输入的每个字符，返回历史中热度前三
//并以当前输入部分为前缀的句子。下面是详细规则： 
//
// 
// 一条句子的热度定义为历史上用户输入这个句子的总次数。 
// 返回前三的句子需要按照热度从高到低排序（第一个是最热门的）。如果有多条热度相同的句子，请按照 ASCII 码的顺序输出（ASCII 码越小排名越前）。 
// 如果满足条件的句子个数少于 3，将它们全部输出。 
// 如果输入了特殊字符，意味着句子结束了，请返回一个空集合。 
// 
//
// 你的工作是实现以下功能： 
//
// 构造函数： 
//
// AutocompleteSystem(String[] sentences, int[] times): 这是构造函数，输入的是历史数据。 Sentenc
//es 是之前输入过的所有句子，Times 是每条句子输入的次数，你的系统需要记录这些历史信息。 
//
// 现在，用户输入一条新的句子，下面的函数会提供用户输入的下一个字符： 
//
// List<String> input(char c): 其中 c 是用户输入的下一个字符。字符只会是小写英文字母（'a' 到 'z' ），空格（' '）和
//特殊字符（'#'）。输出历史热度前三的具有相同前缀的句子。 
//
// 
//
// 样例 ： 
//操作 ： AutocompleteSystem(["i love you", "island","ironman", "i love leetcode"],
// [5,3,2,2]) 
//系统记录下所有的句子和出现的次数： 
//"i love you" : 5 次 
//"island" : 3 次 
//"ironman" : 2 次 
//"i love leetcode" : 2 次 
//现在，用户开始新的键入： 
//
// 
//输入 ： input('i') 
//输出 ： ["i love you", "island","i love leetcode"] 
//解释 ： 
//有四个句子含有前缀 "i"。其中 "ironman" 和 "i love leetcode" 有相同的热度，由于 ' ' 的 ASCII 码是 32 而 '
//r' 的 ASCII 码是 114，所以 "i love leetcode" 在 "ironman" 前面。同时我们只输出前三的句子，所以 "ironman" 
//被舍弃。 
// 
//输入 ： input(' ') 
//输出 ： ["i love you","i love leetcode"] 
//解释: 
//只有两个句子含有前缀 "i "。 
// 
//输入 ： input('a') 
//输出 ： [] 
//解释 ： 
//没有句子有前缀 "i a"。 
// 
//输入 ： input('#') 
//输出 ： [] 
//解释 ： 
//
// 用户输入结束，"i a" 被存到系统中，后面的输入被认为是下一次搜索。 
//
// 
//
// 注释 ： 
//
// 
// 输入的句子以字母开头，以 '#' 结尾，两个字母之间最多只会出现一个空格。 
// 即将搜索的句子总数不会超过 100。每条句子的长度（包括已经搜索的和即将搜索的）也不会超过 100。 
// 即使只有一个字母，输出的时候请使用双引号而不是单引号。 
// 请记住清零 AutocompleteSystem 类中的变量，因为静态变量、类变量会在多组测试数据中保存之前结果。详情请看这里。 
// 
//
// 
// Related Topics 设计 字典树


//leetcode submit region begin(Prohibit modification and deletion)
public class AutocompleteSystem
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

            public int times;

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
            public void Insert(string word, int times)
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

                node.times += times;
                node.word  =  word;
                // 遍历完此单词设置标志位flag
                node.SetEnd();
            }

            /// <summary>
            /// 搜索前缀,返回最后一个字符连接的下一个节点
            /// </summary>
            public TrieNode SearchPrefix(String word)
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

            public List<TrieNode> LookUp(string prefix, ref List<TrieNode> list)
            {
                var node = SearchPrefix(prefix);
                Dfs(node, ref list);
                return list;
            }

            private void Dfs(TrieNode node, ref List<TrieNode> list)
            {
                if (node != null)
                {
                    if (node.isEnd)
                    {
                        list.Add(node);
                    }

                    foreach (var trieNode in node.dic)
                    {
                        Dfs(trieNode.Value, ref list);
                    }
                }
            }
        }

        public Trie trie = new Trie();

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            if (trie == null)
                trie = new Trie();

            for (int i = 0; i < sentences.Length; i++)
            {
                trie.Insert(sentences[i], times[i]);
            }
        }

        private String cur_sent = "";

        public IList<string> Input(char c)
        {
            List<String>   res      = new List<String>();
            List<TrieNode> resNodes = new List<TrieNode>();
            // 输入完成#结束
            if (c == '#')
            {
                // 记入搜索次数
                trie.Insert(cur_sent, 1);
                // 清空
                cur_sent = "";
            }
            else
            {
                cur_sent += c;
                // 查找匹配此前缀的句子列表
                trie.LookUp(cur_sent, ref resNodes);
                if (resNodes.Count == 0)
                {
                    return res;
                }

                resNodes
                    .Select(x => new {id = x.word, x.times})
                    .OrderByDescending(o => o.times)
                    .ThenBy(o => o.id)
                    .Take(3)
                    .ToList()
                    .ForEach(x => res.Add(x.id));
            }

            return res;
        }
    }

/**
 * Your AutocompleteSystem object will be instantiated and called as such:
 * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
 * IList<string> param_1 = obj.Input(c);
 */
//leetcode submit region end(Prohibit modification and deletion)
