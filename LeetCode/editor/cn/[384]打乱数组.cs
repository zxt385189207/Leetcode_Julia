//打乱一个没有重复元素的数组。 
//
// 示例: 
//
// 
//// 以数字集合 1, 2 和 3 初始化数组。
//int[] nums = {1,2,3};
//Solution solution = new Solution(nums);
//
//// 打乱数组 [1,2,3] 并返回结果。任何 [1,2,3]的排列返回的概率应该相同。
//solution.shuffle();
//
//// 重设数组到它的初始状态[1,2,3]。
//solution.reset();
//
//// 随机返回数组[1,2,3]打乱后的结果。
//solution.shuffle();
// 
//


//leetcode submit region begin(Prohibit modification and deletion)
class Solution
{
    private int[] array;
    private int[] original;

    Random rand = new Random();

    /// <summary>
    /// 随机数
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    private int RandRange(int min, int max)
    {
        // Next函数返回一个0 , n 之间的随机数.
        // 这里的写法是返回min, max之间的随机数
        return rand.Next(max - min) + min;
    }

    /// <summary>
    /// 交换算法
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void SwapAt(int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    /// <summary>
    /// 拷贝一个深表副本, 以备还原
    /// </summary>
    /// <param name="nums"></param>
    public Solution(int[] nums)
    {
        array    = nums;
        original = new int[nums.Length];
        Array.Copy(nums,original,nums.Length);
    }

    public int[] Reset()
    {
        Array.Copy(original,array,original.Length);
        return array;
    }

    /// <summary>
    /// 洗牌算法
    /// 排列的可能数必须是n!
    /// 而不是n^n,  这句话是关键 randRange(i, array.Length), 返回从i到array.Length的随机, 而不是0到array.Length
    /// </summary>
    /// <returns></returns>
    public int[] Shuffle()
    {
        for (int i = 0; i < array.Length; i++)
        {
            SwapAt(i, RandRange(i, array.Length));
        }

        return array;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */
//leetcode submit region end(Prohibit modification and deletion)
