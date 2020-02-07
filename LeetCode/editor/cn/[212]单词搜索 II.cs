//给定一个二维网格 board 和一个字典中的单词列表 words，找出所有同时在二维网格和字典中出现的单词。 
//
// 单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母在一个单词中不允许被重复使用。
// 
//
// 示例: 
//
// 输入: 
//words = ["oath","pea","eat","rain"] and board =
//[
//  ['o','a','a','n'],
//  ['e','t','a','e'],
//  ['i','h','k','r'],
//  ['i','f','l','v']
//]
//
//输出: ["eat","oath"] 
//
// 说明: 
//你可以假设所有输入都由小写字母 a-z 组成。 
//
// 提示: 
//
// 
// 你需要优化回溯算法以通过更大数据量的测试。你能否早点停止回溯？ 
// 如果当前单词不存在于所有单词的前缀中，则可以立即停止回溯。什么样的数据结构可以有效地执行这样的操作？散列表是否可行？为什么？ 前缀树如何？如果你想学习如何
//实现一个基本的前缀树，请先查看这个问题： 实现Trie（前缀树）。 
// 
// Related Topics 字典树 回溯算法


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
            //数组构造前缀树
            public class TrieNode
            {
                public TrieNode[] children;
                public String     word; //节点直接存当前的单词

                public TrieNode()
                {
                    children = new TrieNode[26];
                    word     = null;
                    for (int i = 0; i < 26; i++)
                    {
                        children[i] = null;
                    }
                }
            }

            public class Trie
            {
                public TrieNode root;

                /** Initialize your data structure here. */
                public Trie()
                {
                    root = new TrieNode();
                }

                /** Inserts a word into the trie. */
                public void Insert(String word)
                {
                    char[]   array = word.ToCharArray();
                    TrieNode cur   = root;
                    for (int i = 0; i < array.Length; i++)
                    {
                        // 当前孩子是否存在
                        if (cur.children[array[i] - 'a'] == null)
                        {
                            cur.children[array[i] - 'a'] = new TrieNode();
                        }

                        cur = cur.children[array[i] - 'a'];
                    }

                    // 当前节点结束，存入当前单词
                    cur.word = word;
                }
            }

            // 递归
            public List<String> FindWords(char[][] board, String[] words)
            {
                Trie trie = new Trie();
                //将所有单词存入前缀树中
                List<String> res = new List<String>();
                foreach (String word in words)
                {
                    trie.Insert(word);
                }

                int rows = board.Length;
                if (rows == 0)
                {
                    return res;
                }

                int cols = board[0].Length;
                //从每个位置开始遍历
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        ExistRecursive(board, i, j, trie.root, res);
                    }
                }

                return res;
            }

            public void ExistRecursive(char[][] board, int row, int col, TrieNode node, List<String> res)
            {
                if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length)
                {
                    return;
                }

                char cur = board[row][col]; //将要遍历的字母
                //当前节点遍历过或者将要遍历的字母在前缀树中不存在
                if (cur == '$' || node.children[cur - 'a'] == null)
                {
                    return;
                }

                node = node.children[cur - 'a'];
                //判断当前节点是否是一个单词的结束
                if (node.word != null)
                {
                    //加入到结果中
                    res.Add(node.word);
                    //将当前单词置为 null，防止重复加入
                    node.word = null;
                }

                char temp = board[row][col];
                //上下左右去遍历
                board[row][col] = '$';
                ExistRecursive(board, row - 1, col, node, res);
                ExistRecursive(board, row + 1, col, node, res);
                ExistRecursive(board, row, col - 1, node, res);
                ExistRecursive(board, row, col + 1, node, res);
                board[row][col] = temp;
            }
            
            
            // 字典构造前缀树
            // public class TrieNode
            // {
            //     public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
            //     public string                     Word     { get; set; }
            // }
            // public IList<string> FindWords(char[][] board, string[] words)
            // {
            //     TrieNode root = new TrieNode();
            //
            //     foreach (string word in words)
            //     {
            //         AddWord(word, root);
            //     }
            //
            //     Console.WriteLine(string.Join(",", root.Children.Count()));
            //
            //     HashSet<string> result = new HashSet<string>();
            //     for (int i = 0; i < board.Length; ++i)
            //     {
            //         for (int j = 0; j < board[i].Length; ++j)
            //         {
            //             Dfs(board, i, j, root, result);
            //         }
            //     }
            //
            //     return result.ToList();
            // }
            // public void Dfs(char[][] board, int i, int j, TrieNode node, HashSet<string> record)
            // {
            //     if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length)
            //     {
            //         return;
            //     }
            //
            //     if (!node.Children.ContainsKey(board[i][j]))
            //     {
            //         return;
            //     }
            //
            //     var nextNode = node.Children[board[i][j]];
            //     if (!string.IsNullOrEmpty(nextNode.Word))
            //     {
            //         record.Add(nextNode.Word);
            //     }
            //
            //     char tmp = board[i][j];
            //     board[i][j] = '#';
            //
            //     Dfs(board, i + 1, j, nextNode, record);
            //     Dfs(board, i - 1, j, nextNode, record);
            //     Dfs(board, i, j + 1, nextNode, record);
            //     Dfs(board, i, j - 1, nextNode, record);
            //
            //     board[i][j] = tmp;
            // }
            // private void AddWord(string word, TrieNode root)
            // {
            //     TrieNode current = root;
            //
            //     for (int i = 0; i < word.Length; ++i)
            //     {
            //         if (!current.Children.ContainsKey(word[i]))
            //         {
            //             current.Children[word[i]] = new TrieNode();
            //         }
            //
            //         current = current.Children[word[i]];
            //     }
            //
            //     current.Word = word;
            // }

}
//leetcode submit region end(Prohibit modification and deletion)
