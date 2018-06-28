using System.Collections.Generic;

namespace Study.Algo.AlgoChallenge
{
    public class FizzBuzz
    {
        public static List<(int, string)> Run(params int[] input)
        {
            var prepared = new List<(int Number, string Sentence)>();
            foreach (var number in input)
            {
                if (number % (3 * 5) == 0)
                    prepared.Add((number, "FizzBuzz"));
                else if (number % 5 == 0)
                    prepared.Add((number, "Buzz"));
                else if (number % 3 == 0)
                    prepared.Add((number, "Fizz"));
            }

            return prepared;
        }
    }
}