using System;

namespace Study.Algo.Patterns
{
    public class SingletonF
    {
        private static Lazy<SingletonF> lazy => new Lazy<SingletonF>(() => new SingletonF());
        private SingletonF() { }
        public static SingletonF Instance => lazy.Value;
    }
}