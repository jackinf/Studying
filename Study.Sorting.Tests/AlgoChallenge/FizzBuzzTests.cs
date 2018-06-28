using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Study.Algo.AlgoChallenge;

namespace Study.Algo.Tests.AlgoChallenge
{
    public class FizzBuzzTests
    {
        [Test]
        public void GetFor20First()
        {
            var expected = new List<(int, string)> { (3, "Fizz"), (5, "Buzz"), (6, "Fizz"), (9, "Fizz"), (10, "Buzz"), (12, "Fizz"), (15, "FizzBuzz"), (18, "Fizz"), (20, "Buzz") };
            var input = Enumerable.Range(1, 20).ToArray();
            var result = FizzBuzz.Run(input);
            Assert.AreEqual(expected, result);
        }
    }
}