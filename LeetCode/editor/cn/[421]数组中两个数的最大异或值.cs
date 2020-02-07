//给定一个非空数组，数组中元素为 a0, a1, a2, … , an-1，其中 0 ≤ ai < 231 。 
//
// 找到 ai 和aj 最大的异或 (XOR) 运算结果，其中0 ≤ i, j < n 。 
//
// 你能在O(n)的时间解决这个问题吗？ 
//
// 示例: 
//
// 
//输入: [3, 10, 5, 25, 2, 8]
//
//输出: 28
//
//解释: 最大的结果是 5 ^ 25 = 28.
// 
// Related Topics 位运算 字典树


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
            public class TrieNode
            {
                public TrieNode[] path = new TrieNode[2];
            }
            public class Trie
            {
                public TrieNode root;

                public Trie()
                {
                    root = new TrieNode();
                }

                public void Insert(int value)
                {
                    TrieNode cur = root;
                    for (int i = 31; i >= 0; i--)
                    {
                        // 第i位,是否是1
                        int v = value >> i & 1;
                        if (cur.path[v] == null)
                        {
                            cur.path[v] = new TrieNode();
                        }

                        cur = cur.path[v];
                    }
                }

                public int GetMaxXorNum(int value)
                {
                    TrieNode cur    = root;
                    int      result = 0;
                    for (int i = 31; i >= 0; i--)
                    {
                        // 第i位是否是1
                        int v    = (value >> i) & 1;
                        int path = v;
                        if (i == 31)
                        {
                            if (cur.path[v] == null)
                            {
                                path = 1 ^ v; //~v
                            }
                        }
                        else
                        {
                            if (cur.path[1 ^ v] != null)
                            {
                                path = 1 ^ v; //~v
                            }
                        }

                        cur    = cur.path[path];
                        result = result | ((path ^ v) << i);
                    }

                    return result;
                }
            }
            
            public int FindMaximumXOR(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }

                Trie tree   = new Trie();
                int  result = Int32.MinValue;
                for (int i = 0; i < nums.Length; i++)
                {
                    tree.Insert(nums[i]);
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    result = Math.Max(result, tree.GetMaxXorNum(nums[i]));
                }

                return result;
            }
}
//leetcode submit region end(Prohibit modification and deletion)
