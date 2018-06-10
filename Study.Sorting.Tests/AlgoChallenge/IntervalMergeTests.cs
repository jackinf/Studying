using System.Collections.Generic;
using NUnit.Framework;
using Study.Algo.AlgoChallenge;

namespace Study.Algo.Tests.AlgoChallenge
{
    public class IntervalMergeTests
    {
        [Test]
        public void RunTest()
        {
            var input = new List<(int Start, int End)> { (1, 4), (8, 10), (3, 6) };
            var output = IntervalMerge.Run(input);
            var expectedOutput = new List<(int Start, int End)> { (1, 6), (8, 10) };
            Assert.AreEqual(expectedOutput, output);
        }
    }
}