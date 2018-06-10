using System;
using System.Collections.Generic;

namespace Study.Algo.ProblemSolvingInDataStructuresBook
{
    public class Chapter01Exersizes
    {
        /// <summary>
        /// Find the average of all the elemens in an array
        /// </summary>
        public static int Exersize01(List<int> list)
        {
            var sum = 0;
            for (int i = 0; i < list.Count; i++)
                sum += list[i];
            return sum / list.Count;
        }

        /// <summary>
        /// Find the sum of all the elements of a two dimensional array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int Exersize02(int[][] arr)
        {
            var sum = 0;
            for (int i = 0; i < arr.Length; i++)
            for (int j = 0; j < arr[i].Length; j++)
                sum += arr[i][j];
            return sum;
        }

        /// <summary>
        /// Find the largest item
        /// </summary>
        /// <returns></returns>
        public static int Exersize03(List<int> list)
        {
            int largest = int.MinValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > largest)
                    largest = list[i];
            }

            return largest;
        }

        /// <summary>
        /// Find the second largest item
        /// </summary>
        /// <returns></returns>
        public static int Exersize05(List<int> list)
        {
            int largest = int.MinValue;
            int secondLargest = int.MinValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > largest)
                {
                    secondLargest = largest;
                    largest = list[i];
                }
                else if (list[i] > secondLargest)
                    secondLargest = list[i];
            }

            return secondLargest;
        }

        /// <summary>
        /// Given a list of intervals, merge all overlapping intervals
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static List<(int, int)> Exersize09(List<(int, int)> intervals)
        {
            var results = new List<(int, int)>();
            for (int i = 0; i < intervals.Count; i++)
            {
                for (int j = 0; j < intervals.Count-1; j++)
                {
                    if (i == j)
                        continue;
                    // TODO
                    //if (intervals[i].Item1 >= intervals[j].Item2 && intervals[i].Item2 >= intervals[j].Item1)
                    //{
                    //    results.Add();
                    //}
                }
            }
            throw new NotImplementedException();
        }
    }
}