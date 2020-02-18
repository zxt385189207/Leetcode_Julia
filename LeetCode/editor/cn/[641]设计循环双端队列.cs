//设计实现双端队列。 
//你的实现需要支持以下操作： 
//
// 
// MyCircularDeque(k)：构造函数,双端队列的大小为k。 
// insertFront()：将一个元素添加到双端队列头部。 如果操作成功返回 true。 
// insertLast()：将一个元素添加到双端队列尾部。如果操作成功返回 true。 
// deleteFront()：从双端队列头部删除一个元素。 如果操作成功返回 true。 
// deleteLast()：从双端队列尾部删除一个元素。如果操作成功返回 true。 
// getFront()：从双端队列头部获得一个元素。如果双端队列为空，返回 -1。 
// getRear()：获得双端队列的最后一个元素。 如果双端队列为空，返回 -1。 
// isEmpty()：检查双端队列是否为空。 
// isFull()：检查双端队列是否满了。 
// 
//
// 示例： 
//
// MyCircularDeque circularDeque = new MycircularDeque(3); // 设置容量大小为3
//circularDeque.insertLast(1);			        // 返回 true
//circularDeque.insertLast(2);			        // 返回 true
//circularDeque.insertFront(3);			        // 返回 true
//circularDeque.insertFront(4);			        // 已经满了，返回 false
//circularDeque.getRear();  				// 返回 2
//circularDeque.isFull();				        // 返回 true
//circularDeque.deleteLast();			        // 返回 true
//circularDeque.insertFront(4);			        // 返回 true
//circularDeque.getFront();				// 返回 4
//  
//
// 
//
// 提示： 
//
// 
// 所有值的范围为 [1, 1000] 
// 操作次数的范围为 [1, 1000] 
// 请不要使用内置的双端队列库。 
// 
// Related Topics 设计 队列


//leetcode submit region begin(Prohibit modification and deletion)
public class MyCircularDeque
    {
        private int[] data;
        private int   head;
        private int   tail;
        private int   size;

        public MyCircularDeque(int k)
        {
            data = new int[k];
            head = 0;
            tail = 0;
            size = 0;
        }

        public bool InsertFront(int value)
        {
            if (size < data.Length)
            {
                if (head > 0)
                    head--;
                else
                    head = data.Length - 1;
                // 特殊判断,如果没有元素,
                // 则头和尾应该是指向同一个新加的元素
                if (size == 0)
                    tail = head;
                data[head] = value;
                size++;
                return true;
            }

            return false;
        }

        public bool InsertLast(int value)
        {
            if (size < data.Length)
            {
                tail       = (tail + 1) % data.Length;
                data[tail] = value;
                // 特殊判断,如果没有元素,
                // 则头和尾应该是指向同一个新加的元素
                if (size == 0)
                    head = tail;
                size++;
                return true;
            }

            return false;
        }

        public bool DeleteFront()
        {
            if (size <= data.Length && size > 0)
            {
                data[head] = default;
                head       = (head + 1) % data.Length;
                size--;
                return true;
            }

            return false;
        }

        public bool DeleteLast()
        {
            if (size <= data.Length && size > 0)
            {
                data[tail] = default;
                if (tail > 0)
                    tail--;
                else
                    tail = data.Length - 1;
                size--;
                return true;
            }

            return false;
        }

        public int GetFront()
        {
            if (size > 0)
                return data[head];
            return -1;
        }

        public int GetRear()
        {
            if (size > 0)
                return data[tail];
            return -1;
        }

        public bool IsEmpty() => size == 0;
        public bool IsFull()  => size == data.Length;
    }

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */
//leetcode submit region end(Prohibit modification and deletion)
