using System;

namespace Study.Algo.AlgoChallenge
{
    public class MaximumProductSubarray
    {
        public static int? RunImplementationA(int[] numberArray)
        {
            int? lastNegativeNumber = null;
            int? currentMax = null, lastMax = null;
            foreach (var number in numberArray)
            {
                if (number < 0 && lastNegativeNumber == null)
                    lastNegativeNumber = number;
                else if (number > 0)
                    currentMax = currentMax == null ? number : currentMax * number;
                else if (number < 0 && lastNegativeNumber < 0)
                {
                    var temp = number * lastNegativeNumber.Value;
                    currentMax = currentMax == null ? temp : currentMax * temp;
                    lastNegativeNumber = null; // reset
                }
                else if (number == 0)
                {
                    lastMax = GetMax(currentMax, lastMax, number);
                    currentMax = null;
                    lastNegativeNumber = null; // reset
                }
            }
            return GetMax(currentMax, lastMax, lastNegativeNumber);
        }

        private static int? GetMax(int? currentMax, int? lastMax, int? defaultValue)
            => lastMax == null
                ? currentMax ?? defaultValue
                : currentMax != null ? Math.Max(lastMax.Value, currentMax.Value) : lastMax;

        /* Returns the product of max product subarray.
        Assumes that the given array always has a subarray
        with product more than 1 */
        public static int? RunImplementationB(int[] arr)
        {
            int maxEndingHere = 1, minEndingHere = 1, maxSoFar = 1;
            foreach (var number in arr)
            {
                if (number > 0)
                {
                    maxEndingHere = maxEndingHere * number;
                    minEndingHere = Min(minEndingHere * number, 1);
                }
                else if (number == 0)
                {
                    maxEndingHere = 1;
                    minEndingHere = 1;
                }

                else
                {
                    var temp = maxEndingHere;
                    maxEndingHere = Max(minEndingHere * number, 1);
                    minEndingHere = temp * number;
                }

                if (maxSoFar < maxEndingHere)
                    maxSoFar = maxEndingHere;
            }

            return maxSoFar;
        }

        private static int Min(int x, int y) => x < y ? x : y;
        private static int Max(int x, int y) => x > y ? x : y;
    }
}