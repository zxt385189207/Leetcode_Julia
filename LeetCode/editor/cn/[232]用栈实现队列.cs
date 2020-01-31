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
 private Stack<int> s1;
 private Stack<int> s2;
 private int        front;

 /** Initialize your data structure here. */
 public MyQueue()
 {
  s1 = new Stack<int>();
  s2 = new Stack<int>();
 }

 /** Push element x to the back of queue. */
 public void Push(int x)
 {
  if (s1.Count == 0)
  {
   front = x;
  }

  s1.Push(x);
 }

 /** Removes the element from in front of queue and returns that element. */
 // 123
 public int Pop()
 {
  // 栈2里有元素先出栈完,再倒置栈1
  if (s2.Count==0)
  {
   // 如果栈1里面有元素, 就往栈2里塞, 这样栈2就是倒置的栈1
   // 栈1就为空
   while (s1.Count != 0)
   {
    s2.Push(s1.Pop());
   } 
  }
            
  return s2.Pop();
 }

 /** Get the front element. */
 public int Peek()
 {
  if (s2.Count!=0)
  {
   return s2.Peek();
  }

  return front;
 }

 /** Returns whether the queue is empty. */
 public bool Empty()
 {
  return s1.Count == 0 && s2.Count == 0;
 }
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
