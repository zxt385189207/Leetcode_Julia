//根据逆波兰表示法，求表达式的值。 
//
// 有效的运算符包括 +, -, *, / 。每个运算对象可以是整数，也可以是另一个逆波兰表达式。 
//
// 说明： 
//
// 
// 整数除法只保留整数部分。 
// 给定逆波兰表达式总是有效的。换句话说，表达式总会得出有效数值且不存在除数为 0 的情况。 
// 
//
// 示例 1： 
//
// 输入: ["2", "1", "+", "3", "*"]
//输出: 9
//解释: ((2 + 1) * 3) = 9
// 
//
// 示例 2： 
//
// 输入: ["4", "13", "5", "/", "+"]
//输出: 6
//解释: (4 + (13 / 5)) = 6
// 
//
// 示例 3： 
//
// 输入: ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"]
//输出: 22
//解释: 
//  ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
//= ((10 * (6 / (12 * -11))) + 17) + 5
//= ((10 * (6 / -132)) + 17) + 5
//= ((10 * 0) + 17) + 5
//= (0 + 17) + 5
//= 17 + 5
//= 22 
// Related Topics 栈


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 栈
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();
        foreach (String s in tokens)
        {
            // 一旦是运算符就取出2个栈顶元素进行计算
            if (s.Equals("+"))
            {
                stack.Push(stack.Pop() + stack.Pop());
            }
            else if (s.Equals("-"))
            {
                stack.Push(-stack.Pop() + stack.Pop());
            }
            else if (s.Equals("*"))
            {
                stack.Push(stack.Pop() * stack.Pop());
            }
            else if (s.Equals("/"))
            {
                // 除法要注意顺序
                int num1 = stack.Pop();
                stack.Push(stack.Pop() / num1);
            }
            else
            {
                // 除了运算符号,都放入栈中,
                stack.Push(Int32.Parse(s));
            }
        }
        return stack.Pop();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
