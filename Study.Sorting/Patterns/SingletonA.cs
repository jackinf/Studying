namespace Study.Algo.Patterns
{
    public sealed class SingletonA
    {
        private static SingletonA instance = null;
        private SingletonA() { }

        public static SingletonA Instance => instance ?? (instance = new SingletonA());
    }
}