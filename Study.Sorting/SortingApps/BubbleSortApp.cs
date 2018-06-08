using System.Collections.Generic;

namespace Study.Sorting.SortingApps
{
    public class BubbleSortApp
    {
        public static void Sort(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            for (int j = 0; j < list.Count - 1; j++)
                if (list[j] > list[j + 1])
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
        }
    }
}