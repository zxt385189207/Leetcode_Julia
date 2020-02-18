//设计并实现一个 TwoSum 的类，使该类需要支持 add 和 find 的操作。 
//
// add 操作 - 对内部数据结构增加一个数。 
//find 操作 - 寻找内部数据结构中是否存在一对整数，使得两数之和与给定的数相等。 
//
// 示例 1: 
//
// add(1); add(3); add(5);
//find(4) -> true
//find(7) -> false
// 
//
// 示例 2: 
//
// add(3); add(1); add(2);
//find(3) -> true
//find(6) -> false 
// Related Topics 设计 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
// 使用双指针的前提是排序好的数组, 这里每插入一个树都要重新排序,效率不如字典
public class TwoSum
{
    Dictionary<int,int> dic = new Dictionary<int,int>();
    public TwoSum()
    {
    }

    public void Add(int number)
    {
        if (dic.ContainsKey(number))
            dic[number]++;
        else
            dic[number] = 1;
    }

    public bool Find(int value)
    {
        foreach (var i in dic.Keys)
        {
            if (value == i + i && dic.ContainsKey(value - i)  && dic[value - i] > 1)
                return true;
            if (dic.ContainsKey(value - i) && value != i + i)
                return true;
        }

        return false;
    }
}

/**
 * Your TwoSum object will be instantiated and called as such:
 * TwoSum obj = new TwoSum();
 * obj.Add(number);
 * bool param_2 = obj.Find(value);
 */
//leetcode submit region end(Prohibit modification and deletion)
