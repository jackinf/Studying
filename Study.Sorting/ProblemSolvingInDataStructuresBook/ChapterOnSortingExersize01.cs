using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.Algo.ProblemSolvingInDataStructuresBook
{
    public class ChapterOnSortingExersize01
    {
        public static Dictionary<string, int> PrintWordsWithFrequency(string sentence)
            => sentence.Split(new [] {' ', ',', '\n', '\\'}, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(x => x, (s, enumerable) => (s, enumerable.Count()))
                .OrderByDescending(x => x.Item2)
                .ToDictionary(pair => pair.Item1, pair => pair.Item2);
    }
}