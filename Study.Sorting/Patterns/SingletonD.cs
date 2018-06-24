namespace Study.Algo.Patterns
{
    public sealed class SingletonD
    {
        static SingletonD() { }
        private SingletonD() { }
        public static SingletonD Instance { get; } = new SingletonD();
    }
}