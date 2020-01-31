//设计一个支持 push，pop，top 操作，并能在常数时间内检索到最小元素的栈。 
//
// 
// push(x) -- 将元素 x 推入栈中。 
// pop() -- 删除栈顶的元素。 
// top() -- 获取栈顶元素。 
// getMin() -- 检索栈中的最小元素。 
// 
//
// 示例: 
//
// MinStack minStack = new MinStack();
//minStack.push(-2);
//minStack.push(0);
//minStack.push(-3);
//minStack.getMin();   --> 返回 -3.
//minStack.pop();
//minStack.top();      --> 返回 0.
//minStack.getMin();   --> 返回 -2.
// 
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
  if (!(minStack.Count == 0))
  {
   int top = minStack.Peek();
   //小于的时候才入栈
   if (x <= top)
   {
    minStack.Push(x);
   }
  }
  else
  {
   minStack.Push(x);
  }
 }

 public void Pop()
 {
  int pop = stack.Pop();

  int top = minStack.Peek();
  //等于的时候再出栈
  if (pop == top)
  {
   minStack.Pop();
  }
 }

 public int Top()
 {
  return stack.Peek();
 }

 public int GetMin()
 {
  return minStack.Peek();
 }
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
