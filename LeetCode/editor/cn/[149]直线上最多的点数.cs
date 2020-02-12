//给定一个二维平面，平面上有 n 个点，求最多有多少个点在同一条直线上。 
//
// 示例 1: 
//
// 输入: [[1,1],[2,2],[3,3]]
//输出: 3
//解释:
//^
//|
//|        o
//|     o
//|  o  
//+------------->
//0  1  2  3  4
// 
//
// 示例 2: 
//
// 输入: [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
//输出: 4
//解释:
//^
//|
//|  o
//|     o        o
//|        o
//|  o        o
//+------------------->
//0  1  2  3  4  5  6 
// Related Topics 哈希表 数学


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 1. 没注意垂直和平行线 2. 字典要写在第一层循环内
    // 3. 斜率计算要注意分母为0的情况 4. 重合点的计算 4. 2个for循环会出现重复
    // 5. 最大公约数的计算法
    
    
                // 字典解法, 以约分后的分数形式保存斜率为key
                // 键值为斜率
                public int MaxPoints(int[][] points)
                {
                    if (points == null || points.Length == 0)
                        return 0;

                    if (points.Length <= 2)
                        return points.Length;

                    int res = 2;
                    // 遍历计算每个点连接其他点组成的斜率,放入字典
                    // 用Math.Max来比较出最多的
                    for (int i = 0; i < points.Length - 1; i++)
                    {
                        // 注意以下定义在循环捏
                        Dictionary<(int, int), int> dict = new Dictionary<(int, int), int>();
                        // 重合点
                        int dup      = 1;
                        // 用于计数当前点所在最多点在线上的个数
                        int maxCount = 0;
                        for (int j = i + 1; j < points.Length; j++)
                        {
                            // 重合点数量
                            if (points[i][0] == points[j][0] && points[i][1] == points[j][1])
                                dup++;
                            else
                            {
                                // 约分后的斜率
                                (int, int) slope = GetSlope(points[j], points[i]);

                                if (dict.ContainsKey(slope))
                                    dict[slope]++;
                                else
                                    dict.Add(slope, 1);
                                // 比较之后点的计数
                                maxCount = Math.Max(maxCount, dict[slope]);
                            }
                        }
                        // 加上重复点
                        res = Math.Max(res, maxCount + dup);
                    }

                    return res;
                }

                // 获得斜率,并约分
                public (int, int) GetSlope(int[] pb, int[] pa)
                {
                    int dy = pb[1] - pa[1];
                    int dx = pb[0] - pa[0];

                    // vertical line
                    if (dx == 0)
                        return (0, pa[0]);

                    // horizontal line
                    if (dy == 0)
                        return (pa[1], 0);
                    // 获取公约数,约分斜率
                    int d = GetGCD(dy, dx);
                    return (dy / d, dx / d);
                }

                // 辗转相除法获取最大公约数
                public int GetGCD(int m, int n)
                {
                    return n == 0 ? m : GetGCD(n, m % n);
                }
}
//leetcode submit region end(Prohibit modification and deletion)
