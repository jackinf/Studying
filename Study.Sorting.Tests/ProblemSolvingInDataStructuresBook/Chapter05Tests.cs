using System.Collections.Generic;
using NUnit.Framework;
using Study.Algo.ProblemSolvingInDataStructuresBook;

namespace Study.Algo.Tests.ProblemSolvingInDataStructuresBook
{
    public class Chapter05Tests
    {
        [Test]
        public void FindMissingNumberTest()
        {
            var list = new List<int> {1, 2, 3, 5, 6, 7};
            var result = Chapter05.FindMissingNumber(list, list.Count+1);
            Assert.AreEqual(4, result);
        }
    }
}