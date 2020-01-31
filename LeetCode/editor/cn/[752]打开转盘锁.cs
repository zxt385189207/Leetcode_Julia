//你有一个带有四个圆形拨轮的转盘锁。每个拨轮都有10个数字： '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
// 。每个拨轮可以自由旋转：例如把 '9' 变为 '0'，'0' 变为 '9' 。每次旋转都只能旋转一个拨轮的一位数字。 
//
// 锁的初始数字为 '0000' ，一个代表四个拨轮的数字的字符串。 
//
// 列表 deadends 包含了一组死亡数字，一旦拨轮的数字和列表里的任何一个元素相同，这个锁将会被永久锁定，无法再被旋转。 
//
// 字符串 target 代表可以解锁的数字，你需要给出最小的旋转次数，如果无论如何不能解锁，返回 -1。 
//
// 
//
// 示例 1: 
//
// 
//输入：deadends = ["0201","0101","0102","1212","2002"], target = "0202"
//输出：6
//解释：
//可能的移动序列为 "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202"。
//注意 "0000" -> "0001" -> "0002" -> "0102" -> "0202" 这样的序列是不能解锁的，
//因为当拨动到 "0102" 时这个锁就会被锁定。
// 
//
// 示例 2: 
//
// 
//输入: deadends = ["8888"], target = "0009"
//输出：1
//解释：
//把最后一位反向旋转一次即可 "0000" -> "0009"。
// 
//
// 示例 3: 
//
// 
//输入: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], targ
//et = "8888"
//输出：-1
//解释：
//无法旋转到目标数字且不被锁定。
// 
//
// 示例 4: 
//
// 
//输入: deadends = ["0000"], target = "8888"
//输出：-1
// 
//
// 
//
// 提示： 
//
// 
// 死亡列表 deadends 的长度范围为 [1, 500]。 
// 目标数字 target 不会在 deadends 之中。 
// 每个 deadends 和 target 中的字符串的数字会在 10,000 个可能的情况 '0000' 到 '9999' 中产生。 
// 
// Related Topics 广度优先搜索


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 广度优先BFS
    /// </summary>
    /// <param name="deadends"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int OpenLock(string[] deadends, string target)
    {
        HashSet<string> deadSet = new HashSet<string>(deadends);
        // 特殊情况, 还没开始就是死锁了
        if (deadSet.Contains("0000"))
            return -1;
        // 特殊情况, 开始就已经解开了
        if (target == "0000")
            return 0;

        HashSet<string> set = new HashSet<string>();

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("0000");
        set.Add("0000");
        int step = 0;

        while (queue.Count != 0)
        {
            step++;
            int len = queue.Count;

            for (int j = 0; j < len; j++)
            {
                // 当前密码
                char[] current = queue.Dequeue().ToCharArray();
                // 每个密码 对应 8个子树0000->1000,9000,0100,0900,0010,0090,0001,0009
                for (int i = 0; i < 8; i++)
                {
                    char c = current[i / 2];
                    // 因为锁可以从0-1也可以从0-9两个方向旋转
                    // 每一位需要2次遍历,一共就要遍历8次, 分别是正向反向
                    // %10 取个位
                    current[i / 2] = char.Parse(((10 + (c - '0') + (i % 2 == 0 ? 1 : -1)) % 10).ToString());
                    // 可以看成计算左子树和右子树
                    string neighbor = new string(current);
                    // 还原当前项成
                    current[i / 2] = c;

                    if (neighbor == target)
                        return step;
                    // 加入到队列中
                    if (!deadSet.Contains(neighbor) && set.Add(neighbor))
                        queue.Enqueue(neighbor);
                }
            }
        }

        return -1;
    }
    
      /// <summary>
    /// 优化方法, string改int
    /// </summary>
    public class OpenLock1
    {
        private Queue<int> q        = new Queue<int>();
        private bool[]     visited  = new bool[10000];
        private bool[]     deadlist = new bool[10000];

        public int OpenLock(string[] deadends, string target)
        {
            // 优化，把string改成int类型
            foreach (var dead in deadends)
            {
                var i = Convert.ToInt32(dead);
                deadlist[i] = true;
            }

            int round = -1;
            int t     = Convert.ToInt32(target);
            if (!deadlist[0])
            {
                q.Enqueue(0);
                visited[0] = true;
            }

            while (q.Count > 0)
            {
                round++;
                var length = q.Count;
                for (var i = 0; i < length; i++)
                {
                    var item = q.Dequeue();
                    if (item == t)
                    {
                        return round;
                    }
                    else
                    {
                        var nbs = GetNbs(item);
                        foreach (var nb in nbs)
                        {
                            q.Enqueue(nb);
                        }
                    }
                }
            }

            return -1;
        }

        private List<int> GetNbs(int input)
        {
            List<int> a = new List<int>();
            for (var i = 0; i < 4; i++)
            {
                var d = -1;
                for (; d < 2; d += 2)
                {
                    var s1 = GetNbNumbers(input, i, d);
                    if (s1 != null)
                    {
                        visited[s1.Value] = true;
                        a.Add(s1.Value);
                    }
                }
            }

            return a;
        }

        private int? GetNbNumbers(int input, int index, int d)
        {
            int? res   = null;
            var  times = Convert.ToInt32(Math.Pow(10, 3 - index));
            var  m     = (input / times) % 10;
            if ((m == 9 && d == 1) || (m == 0 && d == -1))
            {
                input -= (9 * d * times);
            }
            else
            {
                input += (d * times);
            }

            if (!visited[input] && !deadlist[input] && input < 10000)
            {
                res = input;
            }

            return res;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
