//你被给定一个 m × n 的二维网格，网格中有以下三种可能的初始化值： 
//
// 
// -1 表示墙或是障碍物 
// 0 表示一扇门 
// INF 无限表示一个空的房间。然后，我们用 231 - 1 = 2147483647 代表 INF。你可以认为通往门的距离总是小于 2147483647 
//的。 
// 
//
// 你要给每个空房间位上填上该房间到 最近 门的距离，如果无法到达门，则填 INF 即可。 
//
// 示例： 
//
// 给定二维网格： 
//
// INF  -1  0  INF
//INF INF INF  -1
//INF  -1 INF  -1
//  0  -1 INF INF
// 
//
// 运行完你的函数后，该网格应该变成： 
//
//   3  -1   0   1
//  2   2   1  -1
//  1  -1   2  -1
//  0  -1   3   4
// 
// Related Topics 广度优先搜索


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public void WallsAndGates(int[][] rooms)
    {
        if (rooms.Length == 0) return;
        
        Queue<int> queue = new Queue<int>();
        // 用字典记录节点是否已访问
        Dictionary<int, int> depth = new Dictionary<int, int>();

        // 判断输入参数是否有效 
        int rows = rooms.Length;
        int cols = rooms[0].Length;

        // 方向
        int[][] dir =
        {
            new int[] {-1, 0}, // 上
            new int[] {1, 0},  // 下
            new int[] {0, -1}, // 左
            new int[] {0, 1}   // 右
        };

        for (int r = 0; r < rows; r++)
        for (int c = 0; c < cols; c++)
        {
            // 记录门
            if (rooms[r][c] == 0)
            {
                // 用 r * cols + c 方式记录某个坐标, 入队
                queue.Enqueue(r * cols + c);
                // 记录初始深度
                depth[r * cols + c] = 0;
            }
        }

        // BFS迭代
        while (queue.Count != 0)
        {
            int cur = queue.Dequeue();
            // 出队计算坐标
            int r = cur / cols;
            int c = cur % cols;
            // 四个方向循环遍历
            for (int i = 0; i < 4; i++)
            {
                int dx = r + dir[i][0];
                int dy = c + dir[i][1];
                // 1. 判断x边界  2, 判断y边界, 3. 逻辑判断,是否碰到墙和障碍物
                // 如果四个方向有一个是房间,那么设置此房间的深度
                if (dx >= 0 && dx < rows && dy >= 0 && dy < cols && rooms[dx][dy] == 2147483647)
                {
                    // 并把此节点放入queue
                    queue.Enqueue(dx * cols + dy);
                    // 深度计算
                    depth[dx * cols + dy] = depth[cur] + 1;
                    rooms[dx][dy]         = depth[cur] + 1;
                }
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
