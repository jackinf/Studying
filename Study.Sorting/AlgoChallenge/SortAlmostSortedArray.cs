using System.Collections.Generic;

namespace Study.Algo.AlgoChallenge
{
    /// <summary>
    /// Sort an almost sorted array where only two elements are swapped.
    /// </summary>
    public class SortAlmostSortedArray
    {
        public static bool Run(int[] arr)
        {
            int? i1 = null, i2 = null;
            var n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (i1 == null && n - 1 > i && arr[i] > arr[i + 1])
                    i1 = i;
                else if (i2 == null && i != 0 && arr[i] < arr[i - 1] && i1 != i-1)
                    i2 = i;

                if (i1 != null && i2 != null)
                {
                    (arr[i1.Value], arr[i2.Value]) = (arr[i2.Value], arr[i1.Value]);
                    return true;
                }
            }

            return false;
        }
    }
}