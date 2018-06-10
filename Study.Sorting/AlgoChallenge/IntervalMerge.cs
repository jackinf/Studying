using System;
using System.Collections.Generic;

namespace Study.Algo.AlgoChallenge
{
    public class IntervalMerge
    {
        public static List<(int Start, int End)> Run(List<(int Start, int End)> input)
        {
            var output = new List<(int Start, int End)>();

            input.Sort((a, b) => a.Start.CompareTo(b.Start));

            (int Start, int End)? mergedInterval = null;
            foreach (var interval in input)
            {
                if (mergedInterval == null)
                {
                    mergedInterval = interval;
                }
                else if (interval.Start > mergedInterval.Value.End)
                {
                    output.Add(mergedInterval.Value);
                    mergedInterval = interval;
                }
                else
                {
                    mergedInterval = (mergedInterval.Value.Start, Math.Max(mergedInterval.Value.End, interval.End));
                }
            }
            if (mergedInterval != null)
                output.Add(mergedInterval.Value);

            return output;
        }
    }
}