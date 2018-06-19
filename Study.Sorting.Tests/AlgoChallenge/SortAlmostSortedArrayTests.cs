using NUnit.Framework;
using Study.Algo.AlgoChallenge;

namespace Study.Algo.Tests.AlgoChallenge
{
    public class SortAlmostSortedArrayTests
    {
        [TestCase(new [] { 2, 8, 6, 4, 10 }, true, new[] { 2, 4, 6, 8, 10 })]
        [TestCase(new [] { 2, 10, 6, 8, 4 }, true, new[] { 2, 4, 6, 8, 10 })]
        [TestCase(new [] { 8, 4, 6, 2, 10 }, true, new[] { 2, 4, 6, 8, 10 })]
        [TestCase(new [] { 10, 4, 6, 8, 2 }, true, new[] { 2, 4, 6, 8, 10 })]
        public void Test1(int[] arr, bool expectedSuccess, int[] sortedArr)
        {
            var success = SortAlmostSortedArray.Run(arr);
            Assert.AreEqual(expectedSuccess, success);
            Assert.AreEqual(sortedArr, arr);
        }
    }
}