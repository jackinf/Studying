using System;
using System.Linq;
using NUnit.Framework;
using Study.Algo.AlgoChallenge;

namespace Study.Algo.Tests.AlgoChallenge
{
    public class PromoCodesTests
    {
        [Test]
        public void Test00()
        {
            var sum = PromoCodes.GetPromoCodeFormulaSum(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9});
            Assert.AreEqual(165, sum);
        }

        [Test]
        public void Test01()
        {

            var codes = PromoCodes.Generate().Take(1000).ToList();
            Assert.AreEqual(1000, codes.Count);

            foreach (var code in codes)
            {
                var numbersArray = code.Select(x => int.Parse(x.ToString())).ToList();
                Assert.AreEqual(9, numbersArray.Count);

                var hasAnyLetterMoreOccurrencesThan2 = numbersArray
                    .GroupBy(letter => letter, (letter, list) => new { Count = list.Count() })
                    .Any(result => result.Count > 2);
                Assert.IsFalse(hasAnyLetterMoreOccurrencesThan2);

                var index = 9;
                var sum = numbersArray.Aggregate(0, (a, b) => a + b * index--);
                Assert.AreEqual(sum % 11, 0);
            }
        }
    }
}