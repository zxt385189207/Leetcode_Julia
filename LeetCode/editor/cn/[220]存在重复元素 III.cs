//给定一个整数数组，判断数组中是否有两个不同的索引 i 和 j，使得 nums [i] 和 nums [j] 的差的绝对值最大为 t，并且 i 和 j 之间的
//差的绝对值最大为 ķ。 
//
// 示例 1: 
//
// 输入: nums = [1,2,3,1], k = 3, t = 0
//输出: true 
//
// 示例 2: 
//
// 输入: nums = [1,0,1,1], k = 1, t = 2
//输出: true 
//
// 示例 3: 
//
// 输入: nums = [1,5,9,1,5,9], k = 2, t = 3
//输出: false 
// Related Topics 排序 Ordered Map


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
       // 为了能让算法的效率得到真正的提升，我们需要引入一个支持 插入，搜索，删除 操作的 动态 数据结构，
        // 那就是自平衡二叉搜索树。
        // 自平衡 这个词的意思是，这个树在随机进行插入,删除操作之后，
        // 它会自动保证树的高度最小。
        // 为什么一棵树需要自平衡呢？
        // 这是因为在二叉搜索树上的大部分操作需要花费的时间跟这颗树的高度直接相关。
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (t < 0)
            {
                return false;
            }

            var binarySearchTree = new SortedSet<long>();
            for (int i = 0; i < nums.Length; i++)
            {
                // 当前值
                var visit = (long)nums[i];

                // 判断有序集里是否存在指定范围(与visit比较 +-t范围)内的值的子集 
                if (binarySearchTree.GetViewBetween(visit - t, visit + t).Count > 0)
                {
                    return true;
                }
                // 添加元素
                binarySearchTree.Add(nums[i]);

                // r超过k个节点, 移除一个最前面的元素
                if (i >= k)
                {
                    var nodeKStepAway = nums[i - k];
                    binarySearchTree.Remove(nodeKStepAway);
                }
            }

            return false;
        }
        
        // 桶排序
        // x: 值
        // w: 桶宽
        private long GetID(long x, long w)
        {
            // 需要考虑下负数分的桶
            //  `-3 / 5 = 0` and but we need `-3 / 5 = -1`.
            return x < 0 ? (x + 1) / w - 1 : x / w;
        }
        // 桶排序
        // 我们不妨把把每个元素当做一个人的生日来考虑一下吧。
        // 假设你是班上新来的一位学生，你的生日在 三月 的某一天，
        // 你想知道班上是否有人生日跟你生日在 t=30 天以内。
        // 在这里我们先假设每个月都是30天，很明显，
        // 我们只需要检查所有生日在 二月，三月，四月 的同学就可以了。
        //
        // 我们把上面提到的桶的思想应用到这个问题里面来，我们设计一些桶，
        // 让他们分别包含区间 ..., [0,t], [t+1, 2t+1], ......,
        // 我们把桶来当做窗口，于是每次我们只需要检查 xx 所属的那个桶和相邻桶中的元素就可以了。终于，我们可以在常量时间解决在窗口中搜索的问题了。
        public bool ContainsNearbyAlmostDuplicate1(int[] nums, int k, int t)
        {
            if (t < 0) 
                return false;
            
            var  d = new Dictionary<long, long>();
            
            long w = (long)t + 1;
            
            for (int i = 0; i < nums.Length; ++i)
            {
                // 获取对应的桶
                long m = GetID(nums[i], w);

                // 同一个桶中存在2个, 返回true
                if (d.ContainsKey(m))
                {
                    return true;
                }
                // 不在同一个桶中, 从前一个桶中尝试取值
                // 获取值进行比较, 是否小于桶长
                if (d.ContainsKey(m - 1) && Math.Abs(nums[i] - d[m - 1]) < w)
                {
                    return true;
                }
                // 不在同一个桶中, 从后一个桶中尝试取值
                // 获取值进行比较, 是否小于桶长
                if (d.ContainsKey(m + 1) && Math.Abs(nums[i] - d[m + 1]) < w)
                {
                    return true;
                }
                // 把值加到对应的桶中
                d.Add(m, nums[i]);
                
                // 滑动窗口, 把获取最前面元素的桶,移除, 因为不符合<=k的要求
                if (i >= k)
                {
                    d.Remove(GetID(nums[i - k], w));
                }
            }
            return false;
        }
        
        
        // 暴力法,超时
        // 滑动窗口
        public bool ContainsNearbyAlmostDuplicate2(int[] nums, int k, int t)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                for (int j = Math.Max(i - k, 0); j < i; ++j)
                {
                    if (Math.Abs(nums[i] - nums[j]) <= t) 
                        return true;
                }
            }

            return false;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
