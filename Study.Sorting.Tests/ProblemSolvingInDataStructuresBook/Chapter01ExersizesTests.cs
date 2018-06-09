using System.Collections.Generic;
using NUnit.Framework;
using Study.Sorting.ProblemSolvingInDataStructuresBook;

namespace Study.Sorting.Tests.ProblemSolvingInDataStructuresBook
{
    public class Chapter01ExersizesTests
    {
        [Test]
        public void Exersize05Test()
        {
            var result = Chapter01Exersizes.Exersize05(new List<int> {4, 156, 2, 54, 34, 55, 77, 23, 111});
            Assert.AreEqual(111, result);
        }
    }
}