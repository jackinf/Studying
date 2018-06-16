using System.Collections.Generic;
using System.Linq;

namespace Study.Algo.AlgoChallenge
{
    /// <summary>
    /// #### LP-1: As LeasePlan I would like to have 1000 pregenerated promotion codes for use on printed posters.
    /// 
    ///     The promotion code should be of the following format:
    /// 
    ///     * Nine numerical characters
    ///     * When multiplying the first number by 9, the second by 8, the third by 7, and so on...the resulting number should be divisible by 11 and a single digit may not appear more the twice.
    /// 
    ///     Examples:
    ///     * 613884922 is valid, because 6 x 9 + 1 x 8 + 3 x 7 + 8 x 6 + 8 x 5 + 4 x 4 + 9 x 3 + 2 x 2 + 2 x 1 = 220 / 11 = 20 (whole number, no digit is repeated 3+ times)
    ///     * 538820102 is invalid, because 5 x 9 + 3 x 8 + 8 x 7 + 8 x 6 + 2 x 5 + 0 x 4 + 1 x 3 + 0 x 2 + 2 x 1 = 188 / 11 = 17.09 (not a whole number)
    ///     * 131888331 is invalid(digits 1, 3 and 8 appear too often)
    /// 
    /// Note: you can store the 1000 codes in any format.Please also keep the source code by which you generated them.
    /// </summary>
    public static class PromoCodes
    {
        private static readonly int MinimalPossibleSum = GetPromoCodeFormulaSum(1, 1, 2, 2, 3, 3, 4, 4, 5); // 95
        private static readonly int MaximumPossibleSum = GetPromoCodeFormulaSum(9, 9, 8, 8, 7, 7, 6, 6, 5); // 355
        private static readonly IEnumerable<int> ValidRange = Enumerable.Range(MinimalPossibleSum, MaximumPossibleSum - MinimalPossibleSum);

        // 24 numbers: 99, 110, 121, 132, 143, 154, 165, 176, 187, 198, 209, 220, 231, 242, 253, 264, 275, 286, 297, 308, 319, 330, 341, 352
        private static readonly HashSet<int> ValidSumsDivisiblesBy11 = ValidRange.Where(number => number % 11 == 0).ToHashSet();
        
        public static IEnumerable<string> Generate()
        {
            List<int> numbersPossibleToUse = new List<int> {1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
            Dictionary<string, bool> usedCodes = new Dictionary<string, bool>();

            Variations<int> variations = new Variations<int>(numbersPossibleToUse, 9);
            foreach (var permutation in variations)
            {
                var calculatedSum = GetPromoCodeFormulaSum(permutation.ToArray());
                if (ValidSumsDivisiblesBy11.Contains(calculatedSum))
                {
                    var code = permutation.Aggregate("", (s, i) => s + i);
                    if (!usedCodes.ContainsKey(code))
                    {
                        usedCodes[code] = true;
                        yield return code;
                    }
                }
            }

            yield return "";
        }

        public static int GetPromoCodeFormulaSum(params int[] numbers)
        {
            var index = numbers.Length;
            return numbers.Aggregate(0, (a, b) => a + b * index--);
        }

        public static int GetPromoCodeFormulaSum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) 
            => GetPromoCodeFormulaSum(new [] {a1, a2, a3, a4, a5, a6, a7, a8, a9});
    }
}