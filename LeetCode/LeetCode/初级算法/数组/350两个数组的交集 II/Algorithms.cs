/*
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int i = 0, j = 0, k = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    j++;
                }
                else // nums1[i] == nums2[j]
                {
                    // 相同的放到一个新数组里
                    nums1[k++] = nums1[i++];
                    j++;
                }
            }
            int[] res = new int[k];
            Array.Copy(nums1, res, k);
            return res;
        }
    }
}