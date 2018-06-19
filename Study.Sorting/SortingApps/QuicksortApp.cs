using System.Collections.Generic;

namespace Study.Algo.SortingApps
{
    public class QuicksortApp
    {
        public static List<int> Sort(List<int> list)
        {
            SortInner(list, 0, list.Count - 1);
            return list;
        }

        private static void SortInner(List<int> list, int lower, int upper)
        {
            if (upper <= lower)
                return;

            int pivot = list[lower];
            int start = lower;
            int stop = upper;

            while (lower < upper)
            {
                while (list[lower] <= pivot && lower < upper)
                    lower++;
                while (list[upper] > pivot && lower <= upper)
                    upper--;
                if (lower < upper)
                    (list[lower], list[upper]) = (list[upper], list[lower]);
            }

            (list[upper], list[start]) = (list[start], list[upper]);

            SortInner(list, start, upper - 1);
            SortInner(list, upper + 1, stop);
        }
    }
}