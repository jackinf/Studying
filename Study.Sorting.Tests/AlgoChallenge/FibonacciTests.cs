using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Study.Algo.AlgoChallenge;

namespace Study.Algo.Tests.AlgoChallenge
{
    public class FibonacciTests
    {
        [Test]
        public void Get10()
        {
            var expected = new List<int> {0, 1, 1, 2, 3, 5, 8, 13, 21, 34};
            var result = Fibonacci.GenerateSequence().Take(10);
            Assert.AreEqual(expected, result);
        }
    }
}