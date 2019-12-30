/* mark一个解法
 *
 *
 * 这道题让我们求两个有序数组的中位数，而且限制了时间复杂度为O(log (m+n))，看到这个时间复杂度，
 * 自然而然的想到了应该使用二分查找法来求解。那么回顾一下中位数的定义，如果某个有序数组长度是奇数，
 * 那么其中位数就是最中间那个，如果是偶数，那么就是最中间两个数字的平均值。这里对于两个有序数组也是一样的，
 * 假设两个有序数组的长度分别为m和n，由于两个数组长度之和 m+n 的奇偶不确定，因此需要分情况来讨论，对于奇数的情况，
 * 直接找到最中间的数即可，偶数的话需要求最中间两个数的平均值。为了简化代码，不分情况讨论，我们使用一个小trick，
 * 我们分别找第 (m+n+1) / 2 个，和 (m+n+2) / 2 个，然后求其平均值即可，这对奇偶数均适用。加入 m+n 为奇数的话，
 * 那么其实 (m+n+1) / 2 和 (m+n+2) / 2 的值相等，相当于两个相同的数字相加再除以2，还是其本身。

这里我们需要定义一个函数来在两个有序数组中找到第K个元素，下面重点来看如何实现找到第K个元素。
首先，为了避免产生新的数组从而增加时间复杂度，我们使用两个变量i和j分别来标记数组nums1和nums2的起始位置。
然后来处理一些边界问题，比如当某一个数组的起始位置大于等于其数组长度时，说明其所有数字均已经被淘汰了，
相当于一个空数组了，那么实际上就变成了在另一个数组中找数字，直接就可以找出来了。还有就是如果K=1的话，
那么我们只要比较nums1和nums2的起始位置i和j上的数字就可以了。难点就在于一般的情况怎么处理？因为我们需要在两个有序数组中找到第K个元素，
为了加快搜索的速度，我们要使用二分法，对K二分，意思是我们需要分别在nums1和nums2中查找第K/2个元素，注意这里由于两个数组的长度不定，
所以有可能某个数组没有第K/2个数字，所以我们需要先检查一下，数组中到底存不存在第K/2个数字，如果存在就取出来，
否则就赋值上一个整型最大值。如果某个数组没有第K/2个数字，那么我们就淘汰另一个数字的前K/2个数字即可。
有没有可能两个数组都不存在第K/2个数字呢，这道题里是不可能的，因为我们的K不是任意给的，
而是给的m+n的中间值，所以必定至少会有一个数组是存在第K/2个数字的。最后就是二分法的核心啦，
比较这两个数组的第K/2小的数字midVal1和midVal2的大小，如果第一个数组的第K/2个数字小的话，
那么说明我们要找的数字肯定不在nums1中的前K/2个数字，所以我们可以将其淘汰，将nums1的起始位置向后移动K/2个，
并且此时的K也自减去K/2，调用递归。反之，我们淘汰nums2中的前K/2个数字，并将nums2的起始位置向后移动K/2个，并且此时的K也自减去K/2，调用递归即可。

class Solution {
  public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.length;
        int n = nums2.length;
        int left = (m + n + 1) / 2;
        int right = (m + n + 2) / 2;
        return (findKth(nums1, 0, nums2, 0, left) + findKth(nums1, 0, nums2, 0, right)) / 2.0;
    }
    //i: nums1的起始位置 j: nums2的起始位置
    public int findKth(int[] nums1, int i, int[] nums2, int j, int k){
        if( i >= nums1.length) return nums2[j + k - 1];//nums1为空数组
        if( j >= nums2.length) return nums1[i + k - 1];//nums2为空数组
        if(k == 1){
            return Math.min(nums1[i], nums2[j]);
        }
        int midVal1 = (i + k / 2 - 1 < nums1.length) ? nums1[i + k / 2 - 1] : Integer.MAX_VALUE;
        int midVal2 = (j + k / 2 - 1 < nums2.length) ? nums2[j + k / 2 - 1] : Integer.MAX_VALUE;
        if(midVal1 < midVal2){
            return findKth(nums1, i + k / 2, nums2, j , k - k / 2);
        }else{
            return findKth(nums1, i, nums2, j + k / 2 , k - k / 2);
        }        
    }
}
 */

public class Solution
{
    public double FindMedianSortedArrays(int[] A, int[] B)
    {
        int n = A.Length;

        int m = B.Length;

        bool isEven = (m + n) % 2 == 0;

        int firstIndex = 0;

        int lastIndex = m + n - 1;

        int middle = firstIndex + (lastIndex - firstIndex) / 2;

        int middleToRight = middle + 1;

        if (n == 0)
        {
            return (!isEven) ? B[middle] : (B[middle] + B[middleToRight]) / 2.0;
        }

        if (m == 0)
        {
            return (!isEven) ? A[middle] : (A[middle] + A[middleToRight]) / 2.0;
        }

        if (isEven)
        {
            double mVal1 = FindKthLargestElement(A, B, getKthLargest(middle, lastIndex));

            double mVal2 = FindKthLargestElement(A, B, getKthLargest(middleToRight, lastIndex));

            return (mVal1 + mVal2) / 2.0;
        }

        else
        {
            return FindKthLargestElement(A, B, getKthLargest(middle, lastIndex));
        }
    }

    private static int getKthLargest(int index, int lastIndex)
    {
        return lastIndex - index + 1;
    }

    public static double FindKthLargestElement(int[] array1, int[] array2, int k)
    {
        int length1 = array1.Length;
        int length2 = array2.Length;
        int nthSmallest = length1 + length2 - k + 1;  // bug in code review, need to add 1 here

        return FindKthSmallestElement_BinarySearch(array1, 0, array1.Length, array2, 0, array2.Length, nthSmallest);
    }

    private static double FindKthSmallestElement_BinarySearch(
       int[] array1,
       int start1,
       int length1,
       int[] array2,
       int start2,
       int length2,
       int k)
    {
        //always assume that length1 is equal or smaller than length2
        if (length1 > length2)
        {
            return FindKthSmallestElement_BinarySearch(array2, start2, length2, array1, start1, length1, k);
        }

        if (length1 == 0)
        {
            return array2[start2 + k - 1];
        }

        if (k == 1)
        {
            return Math.Min(array1[start1], array2[start2]); ///
        }

        //divide k into two parts  
        int half_k = Math.Min(k / 2, length1);
        int rest_kElements = k - half_k;

        int firstNode1 = start1 + half_k - 1;
        int firstNode2 = start2 + rest_kElements - 1;

        if (array1[firstNode1] == array2[firstNode2])
        {
            return array1[firstNode1];
        }

        if (array1[firstNode1] < array2[firstNode2]) // remove half_k
        {
            // Go to solve a smaller subproblem, remove first part of the array1
            int newStart = start1 + half_k;  // bug - missing start1 value
            int newLength = length1 - half_k;
            int searchNew = k - half_k;

            return FindKthSmallestElement_BinarySearch(
                array1,
                newStart,
                newLength,
                array2,
                start2,
                length2,
                searchNew);
        }
        else   // remove rest_kElements
        {
            // Go to solve a smaller subproblem, remove first part of the array2
            int newStart = start2 + rest_kElements;  // missing start2
            int newLength = length2 - rest_kElements;
            int searchNew = k - rest_kElements;

            return FindKthSmallestElement_BinarySearch(
                array1,
                start1,
                length1,
                array2,
                newStart,
                newLength,
                searchNew);
        }
    }

}