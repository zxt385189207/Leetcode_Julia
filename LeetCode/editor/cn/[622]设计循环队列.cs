//设计你的循环队列实现。 循环队列是一种线性数据结构，其操作表现基于 FIFO（先进先出）原则并且队尾被连接在队首之后以形成一个循环。它也被称为“环形缓冲器”
//。 
//
// 循环队列的一个好处是我们可以利用这个队列之前用过的空间。在一个普通队列里，一旦一个队列满了，我们就不能插入下一个元素，即使在队列前面仍有空间。但是使用循环
//队列，我们能使用这些空间去存储新的值。 
//
// 你的实现应该支持如下操作： 
//
// 
// MyCircularQueue(k): 构造器，设置队列长度为 k 。 
// Front: 从队首获取元素。如果队列为空，返回 -1 。 
// Rear: 获取队尾元素。如果队列为空，返回 -1 。 
// enQueue(value): 向循环队列插入一个元素。如果成功插入则返回真。 
// deQueue(): 从循环队列中删除一个元素。如果成功删除则返回真。 
// isEmpty(): 检查循环队列是否为空。 
// isFull(): 检查循环队列是否已满。 
// 
//
// 
//
// 示例： 
//
// MyCircularQueue circularQueue = new MycircularQueue(3); // 设置长度为 3
//
//circularQueue.enQueue(1);  // 返回 true
//
//circularQueue.enQueue(2);  // 返回 true
//
//circularQueue.enQueue(3);  // 返回 true
//
//circularQueue.enQueue(4);  // 返回 false，队列已满
//
//circularQueue.Rear();  // 返回 3
//
//circularQueue.isFull();  // 返回 true
//
//circularQueue.deQueue();  // 返回 true
//
//circularQueue.enQueue(4);  // 返回 true
//
//circularQueue.Rear();  // 返回 4
//  
//
// 
//
// 提示： 
//
// 
// 所有的值都在 0 至 1000 的范围内； 
// 操作数将在 1 至 1000 的范围内； 
// 请不要使用内置的队列库。 
// 
// Related Topics 设计 队列


//leetcode submit region begin(Prohibit modification and deletion)
public class MyCircularQueue
{
    private int[] data;
    private int   head;
    private int   tail;
    private int   size;

    public MyCircularQueue(int k)
    {
        data = new int[k];
        head = 0;
        tail = -1; // 因为入队里操作顺序原因, 是-1起始
        size = 0;
    }

    public bool EnQueue(int value)
    {
        if (size < data.Length)
        {
            // 要获取队尾元素, 要先加再赋值
            tail       = (tail + 1) % data.Length;
            data[tail] = value;
            size++;
            return true;
        }
        return false;
    }

    public bool DeQueue()
    {
        if (size > 0)
        {
            data[head] = default;
            head       = (head + 1) % data.Length;
            size--;
            return true;
        }
        return false;
    }
        
    public int Front()
    {
        if (size > 0)
            return data[head];
        return -1;
    }
        
    public int Rear()
    {
        if (size > 0)
            return data[tail];
        return -1;
    }

    public bool IsEmpty() => size == 0;
        
    public bool IsFull() => size == data.Length;
}
/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */
//leetcode submit region end(Prohibit modification and deletion)
