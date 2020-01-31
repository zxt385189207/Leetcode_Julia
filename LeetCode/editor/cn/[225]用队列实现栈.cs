//使用队列实现栈的下列操作： 
//
// 
// push(x) -- 元素 x 入栈 
// pop() -- 移除栈顶元素 
// top() -- 获取栈顶元素 
// empty() -- 返回栈是否为空 
// 
//
// 注意: 
//
// 
// 你只能使用队列的基本操作-- 也就是 push to back, peek/pop from front, size, 和 is empty 这些操作是合
//法的。 
// 你所使用的语言也许不支持队列。 你可以使用 list 或者 deque（双端队列）来模拟一个队列 , 只要是标准的队列操作即可。 
// 你可以假设所有操作都是有效的（例如, 对一个空的栈不会调用 pop 或者 top 操作）。 
// 
// Related Topics 栈 设计


//leetcode submit region begin(Prohibit modification and deletion)
public class MyStack
{
    private Queue<int> q1;
    private Queue<int> q2;
    private int        top;

    /** Initialize your data structure here. */
    public MyStack()
    {
        q1 = new Queue<int>();
        q2 = new Queue<int>();
    }

    /** Push element x onto stack. */
    // q1 :   head 1 2 3  tail
    public void Push(int x)
    {
        q1.Enqueue(x);
        top = x;
    }

    /** Removes the element on top of the stack and returns that element. */
    // q2 : head 1 2 3  tail pop之后 1 2
    public int Pop()
    {
        // 出队到只剩一个元素
        while (q1.Count > 1)
        {
            // 倒数第二个
            if (q1.Count == 2)
            {
                top = q1.Peek();
            }
            q2.Enqueue(q1.Dequeue());
        }

        int val = q1.Dequeue();

        // 交换q1 q2队列
        Queue<int> temp = q1;
        q1 = q2;
        q2 = temp;
        return val;
    }

    /** Get the top element. */
    public int Top()
    {
        return top;
    }

    /** Returns whether the stack is empty. */
    public bool Empty()
    {
        return q1.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
//leetcode submit region end(Prohibit modification and deletion)
