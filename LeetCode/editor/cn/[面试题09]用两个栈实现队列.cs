//用两个栈实现一个队列。队列的声明如下，请实现它的两个函数 appendTail 和 deleteHead ，分别完成在队列尾部插入整数和在队列头部删除整数的
//功能。(若队列中没有元素，deleteHead 操作返回 -1 ) 
//
// 
//
// 示例 1： 
//
// 输入：
//["CQueue","appendTail","deleteHead","deleteHead"]
//[[],[3],[],[]]
//输出：[null,null,3,-1]
// 
//
// 示例 2： 
//
// 输入：
//["CQueue","deleteHead","appendTail","appendTail","deleteHead","deleteHead"]
//[[],[],[5],[2],[],[]]
//输出：[null,-1,null,null,5,2]
// 
//
// 提示： 
//
// 
// 1 <= values <= 10000 
// 最多会对 appendTail、deleteHead 进行 10000 次调用 
// 
// Related Topics 栈 设计


//leetcode submit region begin(Prohibit modification and deletion)
public class CQueue 
{
        Stack<int> stack1 = new Stack<int>();
        // 用来保存反转的栈1元素
        Stack<int> stack2 = new Stack<int>();

        public CQueue()
        {
        }

        public void AppendTail(int value) => stack1.Push(value);

        public int DeleteHead()
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
}

/**
 * Your CQueue object will be instantiated and called as such:
 * CQueue obj = new CQueue();
 * obj.AppendTail(value);
 * int param_2 = obj.DeleteHead();
 */
//leetcode submit region end(Prohibit modification and deletion)
