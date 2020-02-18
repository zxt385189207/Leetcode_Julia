//给定一个嵌套的整数列表，请返回该列表按深度加权后所有整数的总和。 
//
// 每个元素要么是整数，要么是列表。同时，列表中元素同样也可以是整数或者是另一个列表。 
//
// 示例 1: 
//
// 输入: [[1,1],2,[1,1]]
//输出: 10 
//解释: 因为列表中有四个深度为 2 的 1 ，和一个深度为 1 的 2。 
//
// 示例 2: 
//
// 输入: [1,[4,[6]]]
//输出: 27 
//解释: 一个深度为 1 的 1，一个深度为 2 的 4，一个深度为 3 的 6。所以，1 + 4*2 + 6*3 = 27。 
// Related Topics 深度优先搜索


//leetcode submit region begin(Prohibit modification and deletion)
/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution {
    public int DepthSum(IList<NestedInteger> nestedList) 
    {
        return DFS(nestedList, 1);
    }
    public int DFS(IList<NestedInteger> nestedList, int depth )
    {
        int sum = 0;
        foreach(var cur in nestedList)
        {
            if(cur.IsInteger())
                sum += depth * cur.GetInteger();
            else
                sum += DFS(cur.GetList(), depth + 1);
        }
        return sum;   
    }
}
//leetcode submit region end(Prohibit modification and deletion)
