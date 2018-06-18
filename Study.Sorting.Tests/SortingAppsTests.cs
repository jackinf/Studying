using System.Collections.Generic;
using NUnit.Framework;
using Study.Algo.SortingApps;

namespace Study.Algo.Tests
{
    public class SortingAppsTests
    {
        [Test]
        public void BubbleSortTest()
        {
            var list = new List<int> {5, 4, 2, 3, 2, 1};
            var result = BubbleSortApp.Sort(list);
            Assert.AreEqual(new List<int> {1, 2, 2, 3, 4, 5}, result);
        }

        [Test]
        public void MergeSortTest()
        {
            var list = new List<int> {5, 4, 2, 3, 2, 1};
            var result = MergeSortApp.Sort(list);
            Assert.AreEqual(new List<int> {1, 2, 2, 3, 4, 5}, result);
        }

        [Test]
        public void QuickSortTest()
        {
            var list = new List<int> {3,4,2,1,6,5,7,8,1,1};
            var result = QuicksortApp.Sort(list);
            Assert.AreEqual(new List<int> {1,1,1,2,3,4,5,6,7,8}, result);
        }
    }
}