//不使用任何内建的哈希表库设计一个哈希集合 
//
// 具体地说，你的设计应该包含以下的功能 
//
// 
// add(value)：向哈希集合中插入一个值。 
// contains(value) ：返回哈希集合中是否存在这个值。 
// remove(value)：将给定值从哈希集合中删除。如果哈希集合中没有这个值，什么也不做。 
// 
//
// 
//示例: 
//
// MyHashSet hashSet = new MyHashSet();
//hashSet.add(1);         
//hashSet.add(2);         
//hashSet.contains(1);    // 返回 true
//hashSet.contains(3);    // 返回 false (未找到)
//hashSet.add(2);          
//hashSet.contains(2);    // 返回 true
//hashSet.remove(2);          
//hashSet.contains(2);    // 返回  false (已经被删除)
// 
//
// 
//注意： 
//
// 
// 所有的值都在 [0, 1000000]的范围内。 
// 操作的总数目在[1, 10000]范围内。 
// 不要使用内建的哈希集合库。 
// 
// Related Topics 设计 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
/// <summary>
/// 官方实现时使用数组的
/// </summary>
public class MyHashSet
{
    private int[] arr = new int[1000001];

    /** Initialize your data structure here. */
    public MyHashSet()
    {
    }

    public void Add(int key)
    {
        arr[key] = key + 1;
    }

    public void Remove(int key)
    {
        arr[key] = 0;
    }

    /** Returns true if this set contains the specified element */
    public bool Contains(int key)
    {
        return arr[key] != 0;
    }
}

/// <summary>
/// ListNode来实现
/// </summary>
public class MyHashSet1
{
    private readonly ListNode[] _buckets;
    private readonly int[]      _counts;
    private readonly int        _capacity;

    /** Initialize your data structure here. */
    public MyHashSet1()
    {
        _capacity = 100;
        _buckets  = new ListNode[_capacity];
        _counts   = new int[_capacity];
    }

    public void Add(int key)
    {
        // 计算哈希码
        var mod = GetHashKey(key);
        // 判断有没有对应"桶"
        if (_counts[mod] == 0)
        {
            _buckets[mod] = new ListNode(key);
        }
        else
        {
            var      head = _buckets[mod];
            ListNode prev = null;
            while (head != null)
            {
                if (head.val == key)
                {
                    // 说明已经添加过了
                    return;
                }

                // 最后一个节点
                prev = head;
                head = head.next;
            }

            // 新增一个
            prev.next = new ListNode(key);
        }

        _counts[mod]++;
    }

    public void Remove(int key)
    {
        var mod = GetHashKey(key);
        if (_counts[mod] == 0)
        {
            return;
        }
        else
        {
            var      head = _buckets[mod];
            ListNode prev = null;
            while (head != null)
            {
                if (head.val == key)
                {
                    break;
                }

                prev = head;
                head = head.next;
            }

            if (prev == null)
            {
                _buckets[mod] = head.next;
                _counts[mod]--;
            }
            else if (head != null)
            {
                prev.next = head.next;
                _counts[mod]--;
            }
        }
    }

    /** Returns true if this set contains the specified element */
    public bool Contains(int key)
    {
        var mod = GetHashKey(key);
        if (_counts[mod] == 0)
        {
            return false;
        }
        else
        {
            var head = _buckets[mod];
            while (head != null)
            {
                if (head.val == key)
                {
                    return true;
                }

                head = head.next;
            }

            return false;
        }
    }

    private int GetHashKey(int key)
    {
        return key % _capacity;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
//leetcode submit region end(Prohibit modification and deletion)
