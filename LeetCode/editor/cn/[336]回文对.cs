//给定一组唯一的单词， 找出所有不同 的索引对(i, j)，使得列表中的两个单词， words[i] + words[j] ，可拼接成回文串。 
//
// 示例 1: 
//
// 输入: ["abcd","dcba","lls","s","sssll"]
//输出: [[0,1],[1,0],[3,2],[2,4]] 
//解释: 可拼接成的回文串为 ["dcbaabcd","abcddcba","slls","llssssll"]
// 
//
// 示例 2: 
//
// 输入: ["bat","tab","cat"]
//输出: [[0,1],[1,0]] 
//解释: 可拼接成的回文串为 ["battab","tabbat"] 
// Related Topics 字典树 哈希表 字符串


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            IList<IList<int>> res  = new List<IList<int>>();
            Node              root = BuildTrie(words);

            for (int i = 0; i < words.Length; i++)
            {
                Node   cur  = root;
                string word = words[i];
                int    j    = 0;
                for (; j < word.Length; j++)
                {
                    if (IsPalindrome(word.Substring(j)))
                    {
                        foreach (var k in cur.words)
                        {
                            if (i != k)
                            {
                                res.Add(new List<int> {i, k});
                            }
                        }
                    }

                    if (cur.child[word[j] - 'a'] != null)
                    {
                        cur = cur.child[word[j] - 'a'];
                    }
                    else
                    {
                        break;
                    }
                }

                if (j == word.Length)
                {
                    foreach (var k in cur.suffix)
                    {
                        if (i != k)
                        {
                            res.Add(new List<int> {i, k});
                        }
                    }
                }
            }

            return res;
        }

        public Node BuildTrie(string[] words)
        {
            Node root = new Node();
            for (int i = 0; i < words.Length; i++)
            {
                Node   cur = root;
                string rev = Reverse(words[i]);
                if (IsPalindrome(rev))
                {
                    cur.suffix.Add(i);
                }

                for (int j = 0; j < rev.Length; j++)
                {
                    if (cur.child[rev[j] - 'a'] == null)
                    {
                        cur.child[rev[j] - 'a'] = new Node();
                    }

                    cur = cur.child[rev[j] - 'a'];
                    if (IsPalindrome(rev.Substring(j + 1)))
                    {
                        cur.suffix.Add(i);
                    }
                }

                cur.words.Add(i);
            }

            return root;
        }

        public string Reverse(string word)
        {
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public class Node
        {
            public Node[]    child  = new Node[26];
            public List<int> words  = new List<int>();
            public List<int> suffix = new List<int>();
        }
}
//leetcode submit region end(Prohibit modification and deletion)
