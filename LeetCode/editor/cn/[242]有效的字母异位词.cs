//给定两个字符串 s 和 t ，编写一个函数来判断 t 是否是 s 的字母异位词。 
//
// 示例 1: 
//
// 输入: s = "anagram", t = "nagaram"
//输出: true
// 
//
// 示例 2: 
//
// 输入: s = "rat", t = "car"
//输出: false 
//
// 说明: 
//你可以假设字符串只包含小写字母。 
//
// 进阶: 
//如果输入字符串包含 unicode 字符怎么办？你能否调整你的解法来应对这种情况？ 
// Related Topics 排序 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
        // 排序, 
        public Boolean IsAnagram(String s, String t)
        {
            // 通过将 s 的字母重新排列成 t 来生成变位词。
            // 因此，如果 T 是 S 的变位词，对两个字符串进行排序将产生两个相同的字符串
            // 此外，如果 s 和 t 的长度不同，t 不能是 s 的变位词，我们可以提前返回。

            if (s.Length != t.Length)
            {
                return false;
            }

            char[] str1 = s.ToCharArray();
            char[] str2 = t.ToCharArray();
            Array.Sort(str1);
            Array.Sort(str2);

            return new String(str1).Equals(new String(str2));
        }

        /// <summary>
        /// 只有26个字母的情况下,则初始化 26 个字母哈希表，
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public Boolean isAnagram(String s, String t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            int[] counter = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                counter[s[i] - 'a']++;
                counter[t[i] - 'a']--;
            }

            for (int i = 0; i < 26; i++)
                if (counter[i] != 0)
                    return false;

            return true;
        }


        /// <summary>
        /// unicode情况下,字符太多了,创建的数组长度要按照unicode的长度来,这显然不合理
        /// 改用哈希表动态储存出现过的字符就ok了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram2(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            // s 负责在对应位置增加，
            Dictionary<char, int> dic = new Dictionary<char, int>(); //哈希表存出现过的字符,以及出现次数
            for (int i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                {
                    dic.Add(s[i], 1);
                }
                else
                {
                    dic[s[i]]++;
                }
            }

            // t 负责在对应位置减少
            for (int j = 0; j < t.Length; j++)
            {
                if (!dic.ContainsKey(t[j]))
                {
                    return false;
                }
                else
                {
                    if (--dic[t[j]] < 0)
                    {
                        return false;
                    }
                }
            }

            // 如果哈希表的值都为 0，则二者是字母异位词
            foreach (var item in dic.Values)
            {
                if (item != 0)
                {
                    return false;
                }
            }

            return true;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
