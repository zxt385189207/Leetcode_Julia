//请定义一个队列并实现函数 max_value 得到队列里的最大值，要求函数max_value、push_back 和 pop_front 的时间复杂度都是O
//(1)。 
//
// 若队列为空，pop_front 和 max_value 需要返回 -1 
//
// 示例 1： 
//
// 输入: 
//["MaxQueue","push_back","push_back","max_value","pop_front","max_value"]
//[[],[1],[2],[],[],[]]
//输出: [null,null,null,2,1,2]
// 
//
// 示例 2： 
//
// 输入: 
//["MaxQueue","pop_front","max_value"]
//[[],[],[]]
//输出: [null,-1,-1]
// 
//
// 
//
// 限制： 
//
// 
// 1 <= push_back,pop_front,max_value的总操作数 <= 10000 
// 1 <= value <= 10^5 
// 
// Related Topics 栈 Sliding Window


//leetcode submit region begin(Prohibit modification and deletion)
// 用辅助双向队列来实现
public class MaxQueue 
{
    private Queue<int>      queue;
    private LinkedList<int> linkedList;

    public MaxQueue()
    {
        queue      = new Queue<int>();
        linkedList = new LinkedList<int>();
    }

    public int Max_value()
    {
        if (linkedList.Count > 0)
        {
            return linkedList.First.Value;
        }

        return -1;
    }

    public void Push_back(int value)
    {
        queue.Enqueue(value);
        // 移除比队尾比当前元素小的
        // 因为队列是先进先出, 因此移除的那些元素不会被用到,不可能作为最大值
        while (linkedList.Count > 0 && value > linkedList.Last.Value)
            linkedList.RemoveLast();

        linkedList.AddLast(value);
    }

    public int Pop_front()
    {
        if (queue.Count == 0)
            return -1;
        int ans = queue.Dequeue();
        // 出队的值和辅助双向队列中的值相等时一起出队
        if (ans == linkedList.First.Value)
            linkedList.RemoveFirst();
        return ans;
    }
}

/**
 * Your MaxQueue object will be instantiated and called as such:
 * MaxQueue obj = new MaxQueue();
 * int param_1 = obj.Max_value();
 * obj.Push_back(value);
 * int param_3 = obj.Pop_front();
 */
//leetcode submit region end(Prohibit modification and deletion)
