using System.Collections.Generic;
using NUnit.Framework;
using Study.Sorting.ProblemSolvingInDataStructuresBook;

namespace Study.Sorting.Tests.ProblemSolvingInDataStructuresBook
{
    public class Chapter1Tests
    {
        [Test]
        public void PermutationTest()
        {
            var outputs = new List<string>();
            Chapter01.Permutation(new List<int> {1, 2, 3, 4, 5}, 0, outputs);
        }

        [Test]
        public void RotateArray()
        {
            var array = new List<int> {10, 20, 30, 40, 50, 60};
            Chapter01.RotateArray(array, 2);
            Assert.AreEqual(new List<int> {30, 40, 50, 60, 10, 20}, array);
        }
    }
}