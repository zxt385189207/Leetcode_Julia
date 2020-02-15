//给定一个整数数据流和一个窗口大小，根据该滑动窗口的大小，计算其所有整数的移动平均值。 
//
// 示例: 
//
// MovingAverage m = new MovingAverage(3);
//m.next(1) = 1
//m.next(10) = (1 + 10) / 2
//m.next(3) = (1 + 10 + 3) / 3
//m.next(5) = (10 + 3 + 5) / 3
// 
//
// 
// Related Topics 设计 队列


public class MovingAverage
{
    private Queue<int> _queue;
    private int        _mslidingwindow = 0;
    private int        sum             = 0;


    /** Initialize your data structure here. */
    public MovingAverage(int size)
    {
        _mslidingwindow = size;
        _queue          = new Queue<int>(size);
    }

    public double Next(int val)
    {
        sum += val;
        _queue.Enqueue(val);

        if (_queue.Count > _mslidingwindow)
        {
            sum -= _queue.Dequeue();
        }

        return (double)sum / _queue.Count;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */
//leetcode submit region end(Prohibit modification and deletion)
