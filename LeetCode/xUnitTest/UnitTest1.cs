using System;
using LeetCode.Core;
using Xunit;

namespace xUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void TwoSum()
        {
            Algorithms al = new Algorithms();

            Assert.Equal(new int[] {0, 1}, al.TwoSum(new int[] {2, 7, 11, 15}, 9));
            Assert.NotEqual(new int[] {1, 3}, al.TwoSum(new int[] {2, 7, 11, 15}, 18));
        }
    }
}