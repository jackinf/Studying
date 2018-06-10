using System;
using System.Collections.Generic;

namespace Study.Algo.ProblemSolvingInDataStructuresBook
{
    public class Chapter05
    {
        public static int FindMissingNumber(List<int> list, int range)
        {
            int xorSum = 0;

            for (int j = 1; j <= range; j++)
                xorSum = xorSum ^ j;

            foreach (var item in list)
                xorSum = xorSum ^ item;

            return xorSum;
        }
    }
}