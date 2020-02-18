//在给定的网格中，每个单元格可以有以下三个值之一： 
//
// 
// 值 0 代表空单元格； 
// 值 1 代表新鲜橘子； 
// 值 2 代表腐烂的橘子。 
// 
//
// 每分钟，任何与腐烂的橘子（在 4 个正方向上）相邻的新鲜橘子都会腐烂。 
//
// 返回直到单元格中没有新鲜橘子为止所必须经过的最小分钟数。如果不可能，返回 -1。 
//
// 
//
// 示例 1： 
//
// 
//
// 输入：[[2,1,1],[1,1,0],[0,1,1]]
//输出：4
// 
//
// 示例 2： 
//
// 输入：[[2,1,1],[0,1,1],[1,0,1]]
//输出：-1
//解释：左下角的橘子（第 2 行， 第 0 列）永远不会腐烂，因为腐烂只会发生在 4 个正向上。
// 
//
// 示例 3： 
//
// 输入：[[0,2]]
//输出：0
//解释：因为 0 分钟时已经没有新鲜橘子了，所以答案就是 0 。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= grid.length <= 10 
// 1 <= grid[0].length <= 10 
// grid[i][j] 仅为 0、1 或 2 
// 
// Related Topics 广度优先搜索


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public int OrangesRotting(int[][] grid) 
    
    {
        Queue<int>           queue = new Queue<int>();
        Dictionary<int, int> depth = new Dictionary<int, int>();
        //bool[][]             visited = new bool[grid.Length][];
        int ans = 0;
        
        int rows = grid.Length;
        int cols = grid[0].Length;

        // // 初始化交错数组
        // for (int i = 0; i < rows; i++)
        //     visited[i] = new bool[cols];

        // 方向
        int[][] dir =
        {
            new int[] {-1, 0}, // 上
            new int[] {1, 0},  // 下
            new int[] {0, -1}, // 左
            new int[] {0, 1}   // 右
        };

        int goodOrange = 0;
        
        for (int r = 0; r < rows; r++)
        for (int c = 0; c < cols; c++)
        {
            // 把坏橘子做记录
            if (grid[r][c] == 2)
            {
                queue.Enqueue(r * cols + c);
                depth[r * cols + c] = 0;
            }

            if (grid[r][c] == 1)
                goodOrange++;
        }
            


        while (queue.Count != 0)
        {
            int cur = queue.Dequeue();
            int r   = cur / cols;
            int c   = cur % cols;

            for (int i = 0; i < 4; i++)
            {
                int dx = r + dir[i][0];
                int dy = c + dir[i][1];
                // 判断边界, 是否是好橘子
                if (dx >= 0 && dx < rows && dy >= 0 && dy < cols && grid[dx][dy] == 1)
                {
                    // 变成坏橘子
                    grid[dx][dy] = 2;
                    // 好橘子数量减少
                    goodOrange--;
                    // 并把此节点放入queue
                    queue.Enqueue(dx * cols + dy);
                    depth[dx * cols + dy] = depth[cur] + 1;
                    ans                   = depth[dx * cols + dy];
                }
            }
        }

        if (goodOrange>0)
            return -1;
        return ans;
    }
        
}
//leetcode submit region end(Prohibit modification and deletion)
