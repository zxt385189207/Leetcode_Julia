//定义栈的数据结构，请在该类型中实现一个能够得到栈的最小元素的 min 函数在该栈中，调用 min、push 及 pop 的时间复杂度都是 O(1)。 
//
// 
//
// 示例: 
//
// MinStack minStack = new MinStack();
//minStack.push(-2);
//minStack.push(0);
//minStack.push(-3);
//minStack.min();   --> 返回 -3.
//minStack.pop();
//minStack.top();      --> 返回 0.
//minStack.min();   --> 返回 -2.
// 
//
// 
//
// 提示： 
//
// 
// 各函数的调用总次数不超过 20000 次 
// 
//
// 
//
// 注意：本题与主站 155 题相同：https://leetcode-cn.com/problems/min-stack/ 
// Related Topics 栈 设计


//leetcode submit region begin(Prohibit modification and deletion)
public class MinStack
{
    private Stack<Int32> stack;
    private Stack<Int32> minStack;

    /** initialize your data structure here. */
    public MinStack()
    {
        stack    = new Stack<Int32>();
        minStack = new Stack<Int32>();
    }

    public void Push(int x)
    {
        stack.Push(x);
        if (minStack.Count != 0)
        {
            int top = minStack.Peek();
            //当前元素小于最小栈栈顶元素的时候才入栈
            if (x <= top)
                minStack.Push(x);
        }
        else
            minStack.Push(x);
    }

    public void Pop()
    {
        int pop = stack.Pop();
        int top = minStack.Peek();
        //等于的时候再出栈
        if (pop == top)
            minStack.Pop();
    }

    public int Top() => stack.Peek();

    public int Min() => minStack.Peek();
}



/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.Min();
 */
//leetcode submit region end(Prohibit modification and deletion)
