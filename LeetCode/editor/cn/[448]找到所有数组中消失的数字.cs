//给定一个范围在 1 ≤ a[i] ≤ n ( n = 数组大小 ) 的 整型数组，数组中的元素一些出现了两次，另一些只出现一次。 
//
// 找到所有在 [1, n] 范围之间没有出现在数组中的数字。 
//
// 您能在不使用额外空间且时间复杂度为O(n)的情况下完成这个任务吗? 你可以假定返回的数组不算在额外空间内。 
//
// 示例: 
//
// 
//输入:
//[4,3,2,7,8,2,3,1]
//
//输出:
//[5,6]
// 
// Related Topics 数组


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
           // 容易想通
            // 因为所有数字都是1到n之间
            // 将nums[i] 作为索引, 将对应的索引上的数字取负
            // 遍历数组,大于0的那些值+1就是缺失的
            public IList<int> FindDisappearedNumbers(int[] nums)
            {
                List<int> result = new List<int>();
                for(int i = 0; i < nums.Length; i++)
                {
                    int index = Math.Abs(nums[i]) - 1;
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index];
                    }
                }
                for(int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                        result.Add(i + 1);
                }
                return result;
            }
            
            // 桶排序
            // 鸽子巢理论
            // 如果n+1只鸽子放入n个巢里必定有一个巢放了2只
            public IList<int> FindDisappearedNumbers2(int[] nums)
            {
                if (nums.Length == 0)
                    return nums;
                
                List<int> list = new List<int>();
                
                for (int i = 0; i < nums.Length; i++)
                {
                    // 把鸽子放进对应的巢中
                    // 每次swap都会使“正确位置”多一个，那么最多N次交换就能使它们都在
                    // 把鸽子是否在对应的巢中
                    while (nums[i] != nums[nums[i]-1])
                    {
                        Swap(nums, i, nums[i]-1);
                    }
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if ( nums[i] != i+1)
                    {
                        list.Add(i+1);
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
