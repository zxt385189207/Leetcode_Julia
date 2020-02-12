//给定一个字符串，验证它是否是回文串，只考虑字母和数字字符，可以忽略字母的大小写。 
//
// 说明：本题中，我们将空字符串定义为有效的回文串。 
//
// 示例 1: 
//
// 输入: "A man, a plan, a canal: Panama"
//输出: true
// 
//
// 示例 2: 
//
// 输入: "race a car"
//输出: false
// 
// Related Topics 双指针 字符串


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 对撞指针
    // 双指针判断回文串, 从字符串两头往中间遍历并进行比对，跳过非数字或字母项。
    public bool IsPalindrome(string s)
    {
        if (s == null)
        {
            return false;
        }

        int left  = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            var leftElement  = s[left];
            var rightElement = s[right];
            //case1: 左右指针指向的都是字母或字符串
            if (char.IsLetterOrDigit(leftElement) && char.IsLetterOrDigit(rightElement))
            {
                // 如果 确认当前的比较和区域性无关的话，推荐使用ToUppperInvariant
                if (char.ToUpperInvariant(leftElement) != char.ToUpperInvariant(rightElement))
                    return false;

                left++;
                right--;
            }
            //case2: 左指针指向的是字母或字符串
            else if (char.IsLetterOrDigit(leftElement))
                right--;
            //case3: 右指针指向的是字母或字符串
            else
                left++;
        }
        return true;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
