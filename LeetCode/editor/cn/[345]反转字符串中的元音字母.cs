//编写一个函数，以字符串作为输入，反转该字符串中的元音字母。 
//
// 示例 1: 
//
// 输入: "hello"
//输出: "holle"
// 
//
// 示例 2: 
//
// 输入: "leetcode"
//输出: "leotcede" 
//
// 说明: 
//元音字母不包含字母"y"。 
// Related Topics 双指针 字符串


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public string ReverseVowels(string s)
    {
        List<char> list = new List<char> {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};

        int    left  = 0;
        int    right = s.Length - 1;
        char[] chars = s.ToCharArray();
        char   temp;
        while (left < right)
        {
            if (list.Contains(chars[left]) && list.Contains(chars[right]))
            {
                temp         = chars[left];
                chars[left]  = chars[right];
                chars[right] = temp;

                left++;
                right--;
            }
            else if (!list.Contains(chars[left]) && list.Contains(chars[right]))
                left++;
            else if (list.Contains(chars[left]) && !list.Contains(chars[right]))
                right--;
            else
            {
                left++;
                right--;
            }
        }

        return new string(chars);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
