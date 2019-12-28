/*
 * 执行用时 :284 ms, 在所有 csharp 提交中击败了97.09%的用户
 * 内存消耗 :30.1 MB, 在所有 csharp 提交中击败了6.18%的用户
 */

using System.Collections.Generic;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        /// <summary>
        /// 优化解, 空间换时间
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
                return new int[0];

            // 字典的特性，存取快耗内存
            // 利用字典这种特性实现牺牲空间性能来换取时间的性能提升
            var dic = new Dictionary<int, int>();

            // 第一层循环时将结果存入字典（二叉树）中，利用二叉树查询速度快的特点来提升时间性能。
            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                var search  = target - current;

                if (dic.ContainsKey(search))
                {
                    return new int[] {dic[search], i};
                }
                else
                {
                    if (!dic.ContainsKey(current))
                    {
                        // 把数组值作为key, 和下标作为值放入字典中
                        dic.Add(current, i);
                    }
                }
            }

            return new int[0];
        }

        /// <summary>
        /// 暴力解法,会超时
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return new int[] {i, j};
            }

            return null;
        }
    }
}