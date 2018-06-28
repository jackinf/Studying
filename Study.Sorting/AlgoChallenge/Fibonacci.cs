using System.Collections.Generic;

namespace Study.Algo.AlgoChallenge
{
    public static class Fibonacci
    {
        public static IEnumerable<int> GenerateSequence()
        {
            int a = 0, b = 1;
            while (true)
            {
                yield return a;
                (a, b) = (b, a + b);
            }
        }
    }
}