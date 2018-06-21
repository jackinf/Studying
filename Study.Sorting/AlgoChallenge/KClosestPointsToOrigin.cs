using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.Algo.AlgoChallenge
{
    public class KClosestPointsToOrigin
    {
        public static List<(int X, int Y, double Distance)> Find(List<(int X, int Y)> points, int k)
        {
            if (k <= 0)
                return new List<(int X, int Y, double Distance)>();

            List<(int X, int Y, double Distance)> pointsWithDistances = points
                .Select(point => (point.X, point.Y, Math.Sqrt(point.X*point.X + point.Y*point.Y)))
                .ToList();

            var maxHeap = new List<(int X, int Y, double Distance)>();
            for (var i = 0; i < k; i++)
                maxHeap.Add(pointsWithDistances[i]);
            var largestDistance = maxHeap.Max(x => x.Distance);

            for (var i = k; i < pointsWithDistances.Count; i++)
            {
                var point = pointsWithDistances[i];
                if (point.Distance < largestDistance)
                {
                    var prevElement = maxHeap.First(x => Math.Abs(x.Distance - largestDistance) < 0.01d);
                    var prevElementIndex = maxHeap.IndexOf(prevElement);
                    maxHeap[prevElementIndex] = point;

                    largestDistance = maxHeap.Max(x => x.Distance);
                }
            }

            return maxHeap;
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public double DistanceFromOrigin { get; set; }
        }
    }
}