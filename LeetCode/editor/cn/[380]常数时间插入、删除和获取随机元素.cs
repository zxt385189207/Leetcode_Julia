//设计一个支持在平均 时间复杂度 O(1) 下，执行以下操作的数据结构。 
//
// 
// insert(val)：当元素 val 不存在时，向集合中插入该项。 
// remove(val)：元素 val 存在时，从集合中移除该项。 
// getRandom：随机返回现有集合中的一项。每个元素应该有相同的概率被返回。 
// 
//
// 示例 : 
//
// 
//// 初始化一个空的集合。
//RandomizedSet randomSet = new RandomizedSet();
//
//// 向集合中插入 1 。返回 true 表示 1 被成功地插入。
//randomSet.insert(1);
//
//// 返回 false ，表示集合中不存在 2 。
//randomSet.remove(2);
//
//// 向集合中插入 2 。返回 true 。集合现在包含 [1,2] 。
//randomSet.insert(2);
//
//// getRandom 应随机返回 1 或 2 。
//randomSet.getRandom();
//
//// 从集合中移除 1 ，返回 true 。集合现在包含 [2] 。
//randomSet.remove(1);
//
//// 2 已在集合中，所以返回 false 。
//randomSet.insert(2);
//
//// 由于 2 是集合中唯一的数字，getRandom 总是返回 2 。
//randomSet.getRandom();
// 
// Related Topics 设计 数组 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class RandomizedSet
{
    private Dictionary<int, int> _dictionary;
    private List<int>            _list;
    private Random               _random = new Random();

    /** Initialize your data structure here. */
    public RandomizedSet()
    {
        _dictionary = new Dictionary<int, int>();
        _list       = new List<int>();
    }

    // 添加元素到动态数组。
    // 在哈希表中添加值到索引的映射
    public bool Insert(int val)
    {
        if (_dictionary.ContainsKey(val))
        {
            return false;
        }

        // 字典存储值对应的 数组下标映射
        _dictionary[val] = _list.Count;
        _list.Insert(_list.Count, val);
        return true;
    }

    // 在哈希表中查找要删除元素的索引。
    // 将要删除元素与最后一个元素交换。
    // 删除最后一个元素。
    // 更新哈希表中的对应关系。
    public bool Remove(int val)
    {
        if (!_dictionary.ContainsKey(val))
        {
            return false;
        }

        // 最后一个元素值
        int lastElement = _list[_list.Count - 1];
        // 要删除的值的索引
        int idx = _dictionary[val];
        // 删除位置的值替换成最后一个元素值
        _list[idx] = lastElement;
        // 更新字典里的索引
        _dictionary[lastElement] = idx;
        // 移除掉最后一个元素
        _list.RemoveAt(_list.Count - 1);
        // 字典里也移除
        _dictionary.Remove(val);
            
        return true;
    }

    /** Get a random element from the set. */
    public int GetRandom()
    {
        return _list[_random.Next(_list.Count)];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
//leetcode submit region end(Prohibit modification and deletion)
