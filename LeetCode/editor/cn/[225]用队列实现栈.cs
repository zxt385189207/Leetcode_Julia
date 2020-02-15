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
    Queue<int>  queue1 = new Queue<int>();
    Queue<int>  queue2 = new Queue<int>();
    private int top    = 0;

    public MyStack()
    {
    }

    public void Push(int x)
    {
        top = x;
        queue1.Enqueue(x);
    }

    public int Pop()
    {
        if (queue2.Count != 0)
            return queue2.Dequeue();

        if (queue1.Count == 0)
            return -1;

        foreach (var val in queue1.Reverse())
            queue2.Enqueue(val);
        queue1.Clear();

        return queue2.Dequeue();
    }

    public int Top()
    {
        if (queue2.Count != 0)
            return queue2.Peek();
        if (queue1.Count == 0)
            return -1;
        return top;
    }

    public bool Empty() => queue1.Count == 0 && queue2.Count == 0;
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
