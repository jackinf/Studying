using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Study.Algo.Tests.Combinatorics
{
    public class VariationsTests
    {
        [Test]
        public void Test01()
        {
            int[] ints = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Variations<int> variations = new Variations<int>(ints.ToList(), 3);
            foreach (IList<int> variation in variations)
                TestContext.Out.WriteLine(string.Join("", variation));
        }
    }
}