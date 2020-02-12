//给定平面上 n 对不同的点，“回旋镖” 是由点表示的元组 (i, j, k) ，其中 i 和 j 之间的距离和 i 和 k 之间的距离相等（需要考虑元组的顺
//序）。 
//
// 找到所有回旋镖的数量。你可以假设 n 最大为 500，所有点的坐标在闭区间 [-10000, 10000] 中。 
//
// 示例: 
//
// 
//输入:
//[[0,0],[1,0],[2,0]]
//
//输出:
//2
//
//解释:
//两个回旋镖为 [[1,0],[0,0],[2,0]] 和 [[1,0],[2,0],[0,0]]
// 
// Related Topics 哈希表


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    
    // 字典解法, 因为可以交换位置所以*2
    // 键值为距离
    public int NumberOfBoomerangs(int[][] points)
    {
        int res = 0;
        for (int i = 0; i < points.Length; i++)
        {
            // 申明的字典在循环内
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int j = 0; j < points.Length; j++)
            {
                if (i != j)
                {
                    int distance = (points[i][0] - points[j][0]) * (points[i][0] - points[j][0]) +
                                   (points[i][1] - points[j][1]) * (points[i][1] - points[j][1]);

                    if (dic.ContainsKey(distance))
                    {
                        res           += dic[distance] * 2;
                        dic[distance] += 1;
                    }
                    else
                        dic[distance] = 1;
                }
            }
        }
        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
