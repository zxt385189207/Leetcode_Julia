//给定一个整数数组 a，其中1 ≤ a[i] ≤ n （n为数组长度）, 其中有些元素出现两次而其他元素出现一次。 
//
// 找到所有出现两次的元素。 
//
// 你可以不用到任何额外空间并在O(n)时间复杂度内解决这个问题吗？ 
//
// 示例： 
//
// 
//输入:
//[4,3,2,7,8,2,3,1]
//
//输出:
//[2,3]
// 
// Related Topics 数组


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
            // 容易想通
            // 因为所有数字都是1到n之间
            // 将nums[i] 作为索引, 将对应的索引上的数字取负
            // 遍历数组,碰到值为负的就代表已经出现了一次,放入结果数组中
            public IList<int> FindDuplicates2(int[] nums)
            {
                List<int> res = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    var index = Math.Abs(nums[i]) - 1;
                    if (nums[index] < 0)
                    {
                        res.Add(Math.Abs(nums[i]));
                    }
                    else
                    {
                        nums[index] = -1 * nums[index];
                    }
                }

                return res.ToArray();
            }

            // 桶排序
            // 鸽子巢理论
            // 如果n+1只鸽子放入n个巢里必定有一个巢放了2只
            public IList<int> FindDuplicates(int[] nums)
            {
                if (nums.Length == 0)
                    return nums;

                List<int> list = new List<int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    // 把鸽子放进对应的巢中
                    // 每次swap都会使“正确位置”多一个，那么最多N次交换就能使它们都在
                    // 正确的位置
                    while (nums[i] != nums[nums[i] - 1])
                    {
                        Swap(nums, i, nums[i] - 1);
                    }
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != i + 1)
                    {
                        list.Add(nums[i]);
                    }
                }

                return list;
            }

            // 在数组中使用异或运算交换两个变量的值的时候，
            // 一定要保证这两个变量不是同一个变量，
            // 即索引不能相同，否则会把这个位置上的数变成 0 。
            public void Swap(int[] nums, int i, int j)
            {
                if (i == j)
                    return;
                // 异或法
                // 用异或运算交换变量，并且不能加快运算，也不能节省内存。
                // nums[i] = nums[i] ^ nums[j]; // a ^ b = c
                // nums[j] = nums[i] ^ nums[j]; //nums[j] =  a = c ^ b;
                // nums[i] = nums[i] ^ nums[j]; //nums[i] =  b = c ^ a;
                
                // 加减法
                nums[i] = nums[i] + nums[j]; // a = a + b
                nums[j] = nums[i] - nums[j]; // b = a - b
                nums[i] = nums[i] - nums[j]; // a = a - b
                
                // 临时变量
                // int temp = nums[i];
                // nums[i] = nums[j];
                // nums[j] = temp;
            }
}
//leetcode submit region end(Prohibit modification and deletion)
