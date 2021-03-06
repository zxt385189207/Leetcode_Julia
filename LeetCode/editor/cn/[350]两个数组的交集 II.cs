//给定两个数组，编写一个函数来计算它们的交集。 
//
// 示例 1: 
//
// 输入: nums1 = [1,2,2,1], nums2 = [2,2]
//输出: [2,2]
// 
//
// 示例 2: 
//
// 输入: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
//输出: [4,9] 
//
// 说明： 
//
// 
// 输出结果中每个元素出现的次数，应与元素在两个数组中出现的次数一致。 
// 我们可以不考虑输出结果的顺序。 
// 
//
// 进阶: 
//
// 
// 如果给定的数组已经排好序呢？你将如何优化你的算法？ 
// 如果 nums1 的大小比 nums2 小很多，哪种方法更优？ 
// 如果 nums2 的元素存储在磁盘上，磁盘内存是有限的，并且你不能一次加载所有的元素到内存中，你该怎么办？ 
// 
// Related Topics 排序 哈希表 双指针 二分查找


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    
    // 字典
    public int[] Intersect(int[] nums1, int[] nums2) {
        Dictionary<int, int> dic  = new Dictionary<int, int>();
        List<int>            list = new List<int>();
        
        for (int i = 0; i < nums1.Length; i++)
        {
            if (dic.ContainsKey(nums1[i]))
                dic[nums1[i]]++;
            else
                dic[nums1[i]] = 1;
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (dic.ContainsKey(nums2[i]) &&  dic[nums2[i]]>0)
            {
                dic[nums2[i]]--;
                list.Add(nums2[i]);
            }
        }

        return list.ToArray();
    }
    
    public int[] Intersect2(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        int i = 0, j = 0, k = 0;
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j])
            {
                i++;
            }
            else if (nums1[i] > nums2[j])
            {
                j++;
            }
            else // nums1[i] == nums2[j]
            {
                // 相同的放到一个新数组里
                nums1[k++] = nums1[i++];
                j++;
            }
        }
        int[] res = new int[k];
        Array.Copy(nums1, res, k);
        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
