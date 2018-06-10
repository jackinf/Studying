using System.Collections.Generic;
using System.Linq;

namespace Study.Algo.SortingApps
{
    public class BubbleSortApp
    {
        public static List<int> Sort(List<int> list)
        {
            var result = list.ToList();

            for (int i = 0; i < list.Count; i++)
            for (int j = 0; j < list.Count - 1; j++)
                if (list[j] > list[j + 1])
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);

            return result;
        }
    }
}