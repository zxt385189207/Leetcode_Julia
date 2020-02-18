//给定正整数 n，找到若干个完全平方数（比如 1, 4, 9, 16, ...）使得它们的和等于 n。你需要让组成和的完全平方数的个数最少。 
//
// 示例 1: 
//
// 输入: n = 12
//输出: 3 
//解释: 12 = 4 + 4 + 4. 
//
// 示例 2: 
//
// 输入: n = 13
//输出: 2
//解释: 13 = 4 + 9. 
// Related Topics 广度优先搜索 数学 动态规划


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
        // BFS1
        public int NumSquares(int n)
        {
            // 括号内是重复的
            // [0] [1 4 9] [2 5 10 (5) 8 (10)]
            // [0*0],  [1*1, 2*2, 3*3], [1*1+1, 2*2+1, 3*3+1 ,(4+1*1),4+2*2 , (9+1*1)]

            Queue<int>   queue   = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            // 与0点的距离
            int step = 0;

            queue.Enqueue(0);
            visited.Add(0);

            while (queue.Count != 0)
            {
                step++;
                int size = queue.Count;
                for (int j = 0; j < size; j++)
                {
                    int cur = queue.Dequeue();
                    // i * i <= n - cur
                    for (int i = 1; i * i + cur <= n; i++)
                    {
                        int squre = i * i;
                        int next  = squre + cur;
                        // 如果是目标值,返回当前层数就是最短路径
                        if (next == n)
                            return step;
                        if (!visited.Contains(next) && next < n)
                        {
                            queue.Enqueue(next);
                            visited.Add(next);
                        }
                    }
                }
            }

            return step;
        }

        // BFS2
        public int NumSquares2(int n)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(new Tuple<int, int>(n, 0));
            bool[] visited = new bool[n + 1];
            visited[n] = true;

            while (q.Count != 0)
            {
                var front = q.Dequeue();
                int num   = front.Item1;
                int step  = front.Item2;

                for (int i = 1; num - i * i >= 0; i++)
                {
                    int a = num - i * i;
                    if (a < 0)
                        break;
                    if (a == 0)
                        return step + 1;
                    if (!visited[a])
                        q.Enqueue(new Tuple<int, int>(a, step + 1));
                    visited[a] = true;
                }
            }

            return 0;
        }
        // 公式
        public int NumSquares3(int n)
        {
            //先根据上面提到的公式来缩小n
            while (n % 4 == 0)
            {
                n /= 4;
            }

            //如果满足公式 则返回4
            if (n % 8 == 7)
            {
                return 4;
            }

            //在判断缩小后的数是否可以由一个数的平方或者两个数平方的和组成
            int a = 0;
            while ((a * a) <= n)
            {
                int b = (int) Math.Sqrt(n - a * a);
                if (a * a + b * b == n)
                {
                    //如果可以 在这里返回
                    if (a != 0 && b != 0)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }

                a++;
            }

            //如果不行 返回3
            return 3;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
