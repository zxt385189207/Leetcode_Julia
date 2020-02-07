//给定一个单词集合 （没有重复），找出其中所有的 单词方块 。 
//
// 一个单词序列形成了一个有效的单词方块的意思是指从第 k 行和第 k 列 (0 ≤ k < max(行数, 列数)) 来看都是相同的字符串。 
//
// 例如，单词序列 ["ball","area","lead","lady"] 形成了一个单词方块，因为每个单词从水平方向看和从竖直方向看都是相同的。 
//
// b a l l
//a r e a
//l e a d
//l a d y
// 
//
// 注意： 
//
// 
// 单词个数大于等于 1 且不超过 500。 
// 所有的单词长度都相同。 
// 单词长度大于等于 1 且不超过 5。 
// 每个单词只包含小写英文字母 a-z。 
// 
//
// 
//
// 示例 1： 
//
// 输入：
//["area","lead","wall","lady","ball"]
//
//输出：
//[
//  [ "wall",
//    "area",
//    "lead",
//    "lady"
//  ],
//  [ "ball",
//    "area",
//    "lead",
//    "lady"
//  ]
//]
//
//解释：
//输出包含两个单词方块，输出的顺序不重要，只需要保证每个单词方块内的单词顺序正确即可。 
// 
//
// 
//
// 示例 2： 
//
// 输入：
//["abat","baba","atan","atal"]
//
//输出：
//[
//  [ "baba",
//    "abat",
//    "baba",
//    "atan"
//  ],
//  [ "baba",
//    "abat",
//    "baba",
//    "atal"
//  ]
//]
//
//解释：
//输出包含两个单词方块，输出的顺序不重要，只需要保证每个单词方块内的单词顺序正确即可。 
// 
//
// 
// Related Topics 字典树 回溯算法


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
        public class Trie
        {
            public TrieNode root = new TrieNode();

            public void Insert(String word, int n)
            {
                TrieNode node = root;
                int      charNo;
                for (int i = 0; i < n; ++i)
                {
                    charNo = word[i] - 'a';
                    if (node.children[charNo] == null)
                        node.children[charNo] = new TrieNode();
                    node = node.children[charNo];
                }

                node.word = word;
            }
        }

        public class TrieNode
        {
            public TrieNode[] children = new TrieNode[26];
            public String     word     = null;

            public TrieNode getChild(char c)
            {
                return children[c - 'a'];
            }
        }

        public IList<IList<string>> WordSquares(String[] words)
        {
            int  n    = words[0].Length;
            Trie trie = new Trie();
            foreach (String word in words)
                trie.Insert(word, n);

            List<IList<String>> result   = new List<IList<String>>();
            String[]            finished = new String[n];
            char[][]            board    = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new char[n];
            }

            Search(trie.root, trie.root, board, 0, 0, n, finished, result);

            return result;
        }

        /*
        *   current：当前搜索节点
        *   root：根节点
        *   board：字符矩阵
        *   i：正要处理的行（第几个单词）
        *   j：正要处理的列（第几个字符）
        *   n：单词长度（矩阵宽度）
        *   finished：已经填好的单词（0 ~ i-1 已经填好）
        *   result：输出结果
        */
        private void Search(TrieNode current, TrieNode root, char[][] board, int i, int j, int n,
            IList<String>            finished,
            List<IList<String>>      result)
        {
            // 全部n个单词填好，输出结果
            if (i == n)
            {
                result.Add(new List<String>(finished));
                return;
            }

            // 第i个单词填好，放入finished
            if (j == n)
            {
                finished[i] = current.word;
                Search(root, root, board, i + 1, 0, n, finished, result);
                return;
            }

            // 之前已经填过的格子，检查是否可以找到
            // 比如在填第一个单词wall时，(0, 1) 处字符填了a，同时在(1, 0)处也填了a
            // 那么在处理第二个单词时，先要看第一个字符（也就是 i = 0, j = 1 处是否可以为a
            // 如果不能为 a，结束该搜索过程，回溯
            if (j < i)
            {
                TrieNode child = current.getChild(board[i][j]);
                if (child != null)
                    Search(child, root, board, i, j + 1, n, finished, result);
                return;
            }

            // 尝试在该点添堵所有可能的字符
            for (int c = 0; c < 26; ++c)
            {
                if (current.children[c] != null)
                {
                    // 如果在填第一个单词时，同时可以判断每个字符是否可以作为起始字符，从而减少递归分支
                    if (i == 0 && root.children[c] == null)
                        continue;
                    board[j][i] = board[i][j] = (char) ('a' + c);
                    Search(current.children[c], root, board, i, j + 1, n, finished, result);
                }
            }
        }
}
//leetcode submit region end(Prohibit modification and deletion)
