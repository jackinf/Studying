﻿using System;

namespace Study.Algo.AlgoChallenge
{
    /// <summary>
    /// Given an array that contains both positive and negative integers, find the product of the maximum product subarray. 
    /// </summary>
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

        /* Source: https://www.geeksforgeeks.org/maximum-product-subarray/ and https://www.quora.com/How-do-I-solve-maximum-product-subarray-problems */
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