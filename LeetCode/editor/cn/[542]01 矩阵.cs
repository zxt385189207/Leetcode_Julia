//给定一个由 0 和 1 组成的矩阵，找出每个元素到最近的 0 的距离。 
//
// 两个相邻元素间的距离为 1 。 
//
// 示例 1: 
//输入: 
//
// 
//0 0 0
//0 1 0
//0 0 0
// 
//
// 输出: 
//
// 
//0 0 0
//0 1 0
//0 0 0
// 
//
// 示例 2: 
//输入: 
//
// 
//0 0 0
//0 1 0
//1 1 1
// 
//
// 输出: 
//
// 
//0 0 0
//0 1 0
//1 2 1
// 
//
// 注意: 
//
// 
// 给定矩阵的元素个数不超过 10000。 
// 给定矩阵中至少有一个元素是 0。 
// 矩阵中的元素只在四个方向上相邻: 上、下、左、右。 
// 
// Related Topics 深度优先搜索 广度优先搜索


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public int[][] UpdateMatrix(int[][] matrix)
    {
        int[][] res = new int[matrix.Length][];

        int rows = matrix.Length;
        int cols = matrix[0].Length;


        Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();


        // 把0的坐标都放入队列中
        for (int i = 0; i < rows; i++)
        {
            res[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == 0)
                {
                    res[i][j] = 0;
                    queue.Enqueue(new KeyValuePair<int, int>(i, j));
                }
                else
                {
                    res[i][j] = int.MaxValue;
                }
            }
        }

        // 方向
        int[][] dir =
        {
            new int[] {-1, 0},
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {0, 1}
        };


        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();

            // 四个方向的数判断
            for (int i = 0; i < 4; i++)
            {
                int newR = curr.Key + dir[i][0];
                int newC = curr.Value + dir[i][1];

                // 是否在边界内
                if (newR >= 0 && newC >= 0 && newR < rows && newC < cols)
                {
                    // 如果的隔壁的值较大, 差值超过2的话, 叠加当前数字
                    if (res[newR][newC] > res[curr.Key][curr.Value] + 1)
                    {
                        res[newR][newC] = res[curr.Key][curr.Value] + 1;
                        queue.Enqueue(new KeyValuePair<int, int>(newR, newC));
                    }
                }
            }
        }
        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
