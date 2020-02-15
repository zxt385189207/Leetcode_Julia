//使用栈实现队列的下列操作： 
//
// 
// push(x) -- 将一个元素放入队列的尾部。 
// pop() -- 从队列首部移除元素。 
// peek() -- 返回队列首部的元素。 
// empty() -- 返回队列是否为空。 
// 
//
// 示例: 
//
// MyQueue queue = new MyQueue();
//
//queue.push(1);
//queue.push(2);  
//queue.peek();  // 返回 1
//queue.pop();   // 返回 1
//queue.empty(); // 返回 false 
//
// 说明: 
//
// 
// 你只能使用标准的栈操作 -- 也就是只有 push to top, peek/pop from top, size, 和 is empty 操作是合法的。
// 
// 你所使用的语言也许不支持栈。你可以使用 list 或者 deque（双端队列）来模拟一个栈，只要是标准的栈操作即可。 
// 假设所有操作都是有效的 （例如，一个空的队列不会调用 pop 或者 peek 操作）。 
// 
// Related Topics 栈 设计


//leetcode submit region begin(Prohibit modification and deletion)
    public class MyQueue 
    {
        Stack<int> stack1 = new Stack<int>();
        // 用来保存反转的栈1元素
        Stack<int> stack2 = new Stack<int>();
        // 因为反转栈的栈顶就是最先进的元素, 需要记录栈1的最先进的元素
        // 是否用front取决于栈2是否已经出完
        private int front;
        
        public MyQueue() { }
        
        public void Push(int x)
        {
            if (stack1.Count==0)
                front = x;
            stack1.Push(x);
        }
        
        public int Pop() 
        {
            // 如果反转栈中有元素就弹出
            if (stack2.Count != 0)
                return stack2.Pop();
            // 栈1中不存在元素就返回-1
            if (stack1.Count == 0)
                return -1;
            // 反转栈1中的元素,放入栈2实现先入先出
            while (stack1.Count != 0)
                stack2.Push(stack1.Pop());
            return stack2.Pop();
        }

        public int Peek() 
        {
            // 如果反转栈中还有元素,就peek
            if (stack2.Count!=0)
                return stack2.Peek();
            // 否则就出front
            return front;
        }
        
        public bool Empty() => stack1.Count == 0 && stack2.Count == 0;
    }

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
//leetcode submit region end(Prohibit modification and deletion)
