//给定一个由 '1'（陆地）和 '0'（水）组成的的二维网格，计算岛屿的数量。一个岛被水包围，并且它是通过水平方向或垂直方向上相邻的陆地连接而成的。你可以假设
//网格的四个边均被水包围。 
//
// 示例 1: 
//
// 输入:
//11110
//11010
//11000
//00000
//
//输出: 1
// 
//
// 示例 2: 
//
// 输入:
//11000
//11000
//00100
//00011
//
//输出: 3
// 
// Related Topics 深度优先搜索 广度优先搜索 并查集


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
        /// <summary>
        /// 广度优先遍历
        /// 用到辅助队列queue
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            int rows;
            int cols;
            //           x-1,y
            //  x,y-1    x,y      x,y+1
            //           x+1,y
            int[][] directions =
            {
                new int[] {-1, 0}, // 上
                new int[] {0, -1}, // 左
                new int[] {1, 0},  // 下
                new int[] {0, 1}   // 右
            };                     // 交错数组初始化要加new, 二维数组[,]初始化可以{{-1, 0}}


            rows = grid.Length;
            if (rows == 0)
            {
                return 0;
            }

            cols = grid[0].Length;
            bool[][] marked = new bool[rows][];
            // 初始化交错数组
            for (int i = 0; i < rows; i++)
                marked[i] = new bool[cols];


            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // 如果是岛屿中的一个点，并且没有被访问过
                    // 从坐标为 (i,j) 的点开始进行广度优先遍历
                    if (!marked[i][j] && grid[i][j] == '1')
                    {
                        count++;
                        Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();

                        KeyValuePair<int, int> keyValuePair = new KeyValuePair<int, int>(i, j);
                        queue.Enqueue(keyValuePair);
                        // 注意：这里要标记上已经访问过
                        marked[i][j] = true;

                        while (queue.Count != 0)
                        {
                            KeyValuePair<int, int> cur  = queue.Dequeue();
                            int                    curX = cur.Key;
                            int                    curY = cur.Value;

                            // 得到 4 个方向的坐标
                            for (int k = 0; k < 4; k++)
                            {
                                int newX = curX + directions[k][0];
                                int newY = curY + directions[k][1];
                                // 如果不越界、没有被访问过、并且还要是陆地，我就继续放入队列，放入队列的同时，要记得标记已经访问过
                                if (InArea(newX, newY, rows, cols) && grid[newX][newY] == '1' && !marked[newX][newY])
                                {
                                    queue.Enqueue(new KeyValuePair<int, int>(newX, newY));
                                    // 【特别注意】在放入队列以后，要马上标记成已经访问过，语义也是十分清楚的：反正只要进入了队列，你迟早都会遍历到它
                                    // 而不是在出队列的时候再标记
                                    // 【特别注意】如果是出队列的时候再标记，会造成很多重复的结点进入队列，造成重复的操作，这句话如果你没有写对地方，代码会严重超时的
                                    marked[newX][newY] = true;
                                }
                            }
                        }
                    }
                }
            }

            return count;
        }

        private bool InArea(int x, int y, int rows, int cols)
        {
            // 等于号这些细节不要忘了
            return x >= 0 && x < rows && y >= 0 && y < cols;
        }

        /// <summary>
        /// 深度优先遍历
        /// 用到辅助队列stack
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands2(char[][] grid)
        {
            int rows;
            int cols;
            //           x-1,y
            //  x,y-1    x,y      x,y+1
            //           x+1,y
            int[][] directions =
            {
                new int[] {-1, 0}, // 上
                new int[] {0, -1}, // 左
                new int[] {1, 0},  // 下
                new int[] {0, 1}   // 右
            };                     // 交错数组初始化要加new, 二维数组[,]初始化可以{{-1, 0}}


            rows = grid.Length;
            if (rows == 0)
            {
                return 0;
            }

            cols = grid[0].Length;
            bool[][] marked = new bool[rows][];
            // 初始化交错数组
            for (int i = 0; i < rows; i++)
                marked[i] = new bool[cols];


            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // 如果是岛屿中的一个点，并且没有被访问过
                    // 从坐标为 (i,j) 的点开始进行深度优先遍历
                    if (!marked[i][j] && grid[i][j] == '1')
                    {
                        count++;

                        Stack<KeyValuePair<int, int>> stack        = new Stack<KeyValuePair<int, int>>();
                        KeyValuePair<int, int>        keyValuePair = new KeyValuePair<int, int>(i, j);
                        stack.Push(keyValuePair);
                        // 注意：这里要标记上已经访问过
                        marked[i][j] = true;

                        while (stack.Count != 0)
                        {
                            KeyValuePair<int, int> cur  = stack.Pop();
                            int                    curX = cur.Key;
                            int                    curY = cur.Value;

                            // 得到 4 个方向的坐标
                            for (int k = 0; k < 4; k++)
                            {
                                int newX = curX + directions[k][0];
                                int newY = curY + directions[k][1];

                                if (InArea(newX, newY, rows, cols) && grid[newX][newY] == '1' && !marked[newX][newY])
                                {
                                    stack.Push(new KeyValuePair<int, int>(newX, newY));
                                    marked[newX][newY] = true;
                                }
                            }
                        }
                    }
                }
            }

            return count;
        }


        /// <summary>
        /// 使用并查集
        /// 使用并查集解决本问题的思想很简单：
        /// 1、如果当前是“陆地”，尝试与周围合并一下；
        /// 2、如果当前是“水域”，就把所有的“水域”合并在一起，为此，
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands3(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int rows = grid.Length;
            int cols = grid[0].Length;
            if (rows == 0 || cols == 0) return 0;

            // 初始化陆地和海
            int[] pre = new int[rows * cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        // 标记为1的代表一块陆地, 暂时只归自己掌管
                        pre[i * cols + j] = i * cols + j; 
                    }
                    else
                    {
                        // 海
                        pre[i * cols + j] = -1;
                    }
                }
            }

            // 将竖直或水平相邻的陆地联结
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // 水平
                    // 如果前和后都是1,则合并他们
                    if (j != cols - 1 && grid[i][j] == '1' && grid[i][j + 1] == '1')
                    {
                        Join(i * cols + j, i * cols + j + 1, pre);
                    }

                    // 竖直
                    // 如果上和下都是1,则合并他们
                    if (i != rows - 1 && grid[i][j] == '1' && grid[i + 1][j] == '1')
                    {
                        Join(i * cols + j, (i + 1) * cols + j, pre);
                    }
                }
            }


            HashSet<int> hashSet = new HashSet<int>();
            for (int i = 0; i < pre.Length; i++)
            {
                // 排除海
                if (pre[i] == -1)
                    continue;
                // 搜索每一块陆地归属者
                int temp = Unionsearch(i, pre);
                if (!hashSet.Contains(temp))
                {
                    // 岛屿
                    hashSet.Add(temp); 
                }
            }

            return hashSet.Count;
        }

        private int Unionsearch(int root, int[] pre)
        {
            int son, tmp;
            son = root;
            // 判断当前陆地的上一级是不是掌管者
            // 最后相等的就是掌管一片陆地的掌管者
            while (root != pre[root]) 
                root = pre[root];

            // 使层级低的大侠直接拜在掌门手下
            // 下次查询只要问一次就能知道是否是同一个掌门
            while (son != root) //路径压缩
            {
                tmp      = pre[son];
                pre[son] = root;
                son      = tmp;
            }

            return root;
        }

        // 判断是否连通，不连通就合并
        private void Join(int root1, int root2, int[] pre)
        {
            int x, y;
            // 掌门1
            x = Unionsearch(root1, pre);
            // 掌门2
            y = Unionsearch(root2, pre);
            // 两个掌门不同,说明两个大侠的阵营不同
            if (x != y) //如果不连通，就把它们所在的连通分支合并
            {
                // 归属于一块岛
                pre[x] = y;
            }
        }
}
//leetcode submit region end(Prohibit modification and deletion)
