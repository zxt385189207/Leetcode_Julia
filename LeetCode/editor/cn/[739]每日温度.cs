//根据每日 气温 列表，请重新生成一个列表，对应位置的输入是你需要再等待多久温度才会升高超过该日的天数。如果之后都不会升高，请在该位置用 0 来代替。 
//
// 例如，给定一个列表 temperatures = [73, 74, 75, 71, 69, 72, 76, 73]，你的输出应该是 [1, 1, 4, 2
//, 1, 1, 0, 0]。 
//
// 提示：气温 列表长度的范围是 [1, 30000]。每个气温的值的均为华氏度，都是在 [30, 100] 范围内的整数。 
// Related Topics 栈 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 栈
    public int[] DailyTemperatures(int[] T)
    {
        // "递减"栈  栈顶一定小于栈底
        // 维护一个单调递减栈，保存的是下标用于计算相差的天数
        Stack<int> stack = new Stack<int>();
            
        // 用于记录的数组, 默认都是0
        int[] res = new int[T.Length];

        for (int i = 0; i < T.Length; i++)
        {
            // 一直和栈顶元素比较, 如果大, 就出栈对应序号, 并计算序号差
            while (stack.Count!=0 && T[i] > T[stack.Peek()])
            {
                var temp = stack.Pop();
                res[temp] = i - temp;
            }
                
            // 压入一个下标
            stack.Push(i);
        }

        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
