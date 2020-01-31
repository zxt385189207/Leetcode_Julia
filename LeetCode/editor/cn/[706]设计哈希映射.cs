//不使用任何内建的哈希表库设计一个哈希映射 
//
// 具体地说，你的设计应该包含以下的功能 
//
// 
// put(key, value)：向哈希映射中插入(键,值)的数值对。如果键对应的值已经存在，更新这个值。 
// get(key)：返回给定的键所对应的值，如果映射中不包含这个键，返回-1。 
// remove(key)：如果映射中存在这个键，删除这个数值对。 
// 
//
// 
//示例： 
//
// 
//MyHashMap hashMap = new MyHashMap();
//hashMap.put(1, 1);          
//hashMap.put(2, 2);         
//hashMap.get(1);            // 返回 1
//hashMap.get(3);            // 返回 -1 (未找到)
//hashMap.put(2, 1);         // 更新已有的值
//hashMap.get(2);            // 返回 1 
//hashMap.remove(2);         // 删除键为2的数据
//hashMap.get(2);            // 返回 -1 (未找到) 
// 
//
// 
//注意： 
//
// 
// 所有的值都在 [1, 1000000]的范围内。 
// 操作的总数目在[1, 10000]范围内。 
// 不要使用内建的哈希库。 
// 
// Related Topics 设计 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class MyHashMap
{
    int[] a;

    /** Initialize your data structure here. */
    public MyHashMap()
    {
        a = new int[1000001];
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = -1;
        }
    }

    /** value will always be non-negative. */
    public void Put(int key, int value)
    {
        a[key] = value;
    }

    /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
    public int Get(int key)
    {
        return a[key];
    }

    /** Removes the mapping of the specified value key if this map contains a mapping for the key */
    public void Remove(int key)
    {
        a[key] = -1;
    }
}

public class MyHashMap2
{
    private       List<int>[] keys;
    private       List<int>[] values;
    private const int         M = 200;

    /** Initialize your data structure here. */
    public MyHashMap2()
    {
        keys   = new List<int>[M];
        values = new List<int>[M];
        for (int i = 0; i < M; i++)
        {
            keys[i]   = new List<int>();
            values[i] = new List<int>();
        }
    }

    /** value will always be non-negative. */
    public void Put(int key, int value)
    {
        int hash = Hash(key);
        if (keys[hash].Contains(key))
        {
            int index = keys[hash].IndexOf(key);
            values[hash][index] = value;
        }
        else
        {
            keys[hash].Add(key);
            values[hash].Add(value);
        }
    }

    /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
    public int Get(int key)
    {
        int hash = Hash(key);
        if (keys[hash].Contains(key))
        {
            int index = keys[hash].IndexOf(key);
            return values[hash][index];
        }
        else
            return -1;
    }

    /** Removes the mapping of the specified value key if this map contains a mapping for the key */
    public void Remove(int key)
    {
        int hash = Hash(key);
        if (keys[hash].Contains(key))
        {
            int index = keys[hash].IndexOf(key);
            values[hash].RemoveAt(index);
            keys[hash].RemoveAt(index);
        }
    }

    private int Hash(int key)
    {
        return key.GetHashCode() % M;
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */
//leetcode submit region end(Prohibit modification and deletion)
