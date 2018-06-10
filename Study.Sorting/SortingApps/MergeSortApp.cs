using System.Collections.Generic;

namespace Study.Algo.SortingApps
{
    public class MergeSortApp
    {
        public static List<int> Sort(List<int> list)
        {
            if (list.Count <= 1)
                return list;

            var left = new List<int>();
            var right = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i < list.Count / 2)
                    left.Add(list[i]);
                else
                    right.Add(list[i]);
            }

            left = Sort(left);
            right = Sort(right);

            var merged = Merge(left, right);
            return merged;
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }

            while (left.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }

            return result;
        }
    }
}