using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Study.Algo.AlgoChallenge;

namespace Study.Algo.Tests.AlgoChallenge
{
    public class KClosestPointsToOriginTests
    {
        [Test]
        public void Test01()
        {
            var points = new List<(int X, int Y)> { (-2, -4), (0, -2), (-1, 0), (3, -5), (-2, -3), (3, 2)};
            var results = KClosestPointsToOrigin.Find(points, 3).ToList();
            var xyResults = results.Select(result => (result.X, result.Y)).OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
            Assert.AreEqual(new List<(int X, int Y)> { (-2, -3), (-1, 0), (0, -2)}, xyResults);
        }
    }
}