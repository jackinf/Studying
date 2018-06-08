using System.Collections.Generic;
using NUnit.Framework;
using Study.Sorting.SortingApps;

namespace Study.Sorting.Tests.SortingApps
{
    public class BubbleSortAppTests
    {
        [Test]
        public void Simple()
        {
            var list = new List<int> {5, 4, 2, 3, 2, 1};
            BubbleSortApp.Sort(list);
            Assert.AreEqual(new List<int> {1, 2, 2, 3, 4, 5}, list);
        }
    }
}