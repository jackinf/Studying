using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Study.Algo.AlgoChallenge;

namespace Study.Algo.Tests.AlgoChallenge
{
    public class LinkedListDeleteGreaterValueNodesTests
    {
        [TestCase(new []{1, 10}, 2, new [] {1})]
        [TestCase(new []{1, 2, 8, 4, -2, 15, 14, 7}, 6, new [] {1, 2, 4, -2})]
        [TestCase(new int[0], 0, new int[0])]
        public void Test1(int[] arr, int maxAllowedValue, int[] expectedArr)
        {
            var linkedList = new LinkedList<int>(arr);
            LinkedListDeleteGreaterValueNodes.Run(linkedList, maxAllowedValue);
            var result = linkedList.ToArray();
            Assert.AreEqual(expectedArr, result);
        }
    }
}