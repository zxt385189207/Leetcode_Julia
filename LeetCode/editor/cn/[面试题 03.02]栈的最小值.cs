//请设计一个栈，除了常规栈支持的pop与push函数以外，还支持min函数，该函数返回栈元素中的最小值。执行push、pop和min操作的时间复杂度必须为O(
//1)。 示例： MinStack minStack = new MinStack(); minStack.push(-2); minStack.push(0);
// minStack.push(-3); minStack.getMin();   --> 返回 -3. minStack.pop(); minStack.top
//();      --> 返回 0. minStack.getMin();   --> 返回 -2. Related Topics 栈


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

    public int GetMin() => minStack.Peek();
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
//leetcode submit region end(Prohibit modification and deletion)
