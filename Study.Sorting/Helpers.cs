using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.Algo
{
    public static class Helpers
    {
        public static IEnumerable<T[]> Combinations<T>(this IList<T> argList, int argSetSize)
        {
            if (argList == null) throw new ArgumentNullException("argList");
            if (argSetSize <= 0) throw new ArgumentException("argSetSize Must be greater than 0", "argSetSize");
            return CombinationsImpl(argList, 0, argSetSize - 1);
        }

        private static IEnumerable<T[]> CombinationsImpl<T>(IList<T> argList, int argStart, int argIteration, List<int> argIndicies = null)
        {
            argIndicies = argIndicies ?? new List<int>();
            for (int i = argStart; i < argList.Count; i++)
            {
                argIndicies.Add(i);
                if (argIteration > 0)
                {
                    foreach (var array in CombinationsImpl(argList, i + 1, argIteration - 1, argIndicies))
                    {
                        yield return array;
                    }
                }
                else
                {
                    var array = new T[argIndicies.Count];
                    for (int j = 0; j < argIndicies.Count; j++)
                    {
                        array[j] = argList[argIndicies[j]];
                    }

                    yield return array;
                }
                argIndicies.RemoveAt(argIndicies.Count - 1);
            }
        }

        // Variations

        public static IEnumerable<string> VariationsOf(string source, int count)
        {
            if (source.Length == 1)
            {
                yield return source;
            }
            else if (count == 1)
            {
                for (var n = 0; n < source.Length; n++)
                {
                    yield return source.Substring(n, 1);
                }
            }
            else
            {
                for (var n = 0; n < source.Length; n++)
                    foreach (var suffix in VariationsOf(
                        source.Substring(0, n)
                        + source.Substring(n + 1, source.Length - n - 1), count - 1))
                    {
                        yield return source.Substring(n, 1) + suffix;
                    }
            }
        }
    }
}