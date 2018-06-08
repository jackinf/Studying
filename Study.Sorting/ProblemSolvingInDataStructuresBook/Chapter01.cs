using System;
using System.Collections.Generic;

namespace Study.Sorting.ProblemSolvingInDataStructuresBook
{
    public class Chapter01
    {
        /// <summary>
        /// Euclid: GDC(n, m) == GDC(m, n%m)
        /// </summary>
        public static int Gdc(int m, int n)
            => m < n ? Gdc(n, m) : m % n == 0 ? n : Gdc(n, m % n);

        public static int Fibonacci(int n) => n <= 1 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);

        public static void Permutation(List<int> arr, int i, List<string> outputs)
        {
            if (arr.Count == i)
            {
                outputs.Add(string.Join(", ", arr));
                return;
            }

            for (var j = i; j < arr.Count; j++)
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
                Permutation(arr, i+1, outputs);
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }

        public static void RotateArray(List<int> list, int positions)
        {
            void ReverseArray(int start, int end)
            {
                for (int i = start, j = end; i < j; i++, j--)
                    (list[i], list[j]) = (list[j], list[i]);
            }

            ReverseArray(0, positions -1);
            ReverseArray(positions, list.Count -1);
            ReverseArray(0, list.Count -1);
        }
    }
}