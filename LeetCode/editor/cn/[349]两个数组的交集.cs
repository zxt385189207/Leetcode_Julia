//给定两个数组，编写一个函数来计算它们的交集。 
//
// 示例 1: 
//
// 输入: nums1 = [1,2,2,1], nums2 = [2,2]
//输出: [2]
// 
//
// 示例 2: 
//
// 输入: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
//输出: [9,4] 
//
// 说明: 
//
// 
// 输出结果中的每个元素一定是唯一的。 
// 我们可以不考虑输出结果的顺序。 
// 
// Related Topics 排序 哈希表 双指针 二分查找


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // C# LINQ 内置函数
    public int[] Intersection2(int[] nums1, int[] nums2)
    {
        return nums1.Intersect(nums2).ToArray();
    }


    // 放到集合里判断
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        HashSet<int> set1 = new HashSet<int>();
        HashSet<int> set2 = new HashSet<int>();

        foreach (var item in nums1)
            set1.Add(item);

        foreach (var item in nums2)
            set2.Add(item);


        List<int> res = new List<int>();
        
        if (set1.Count > set2.Count)
        {
            foreach (var temp in set2)
            {
                if (set1.Contains(temp))
                {
                    res.Add(temp);
                }
            }
        }
        else
        {
            foreach (var temp in set1)
            {
                if (set2.Contains(temp))
                {
                    res.Add(temp);
                }
            }
        }

        return res.ToArray();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
