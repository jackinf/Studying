namespace Study.Algo.Patterns
{
    public class SingletonE
    {
        private SingletonE() { }
        public static SingletonE Instance => Nested.NestedInstance;

        private class Nested
        {
            static Nested() { }
            internal static readonly SingletonE NestedInstance = new SingletonE();
        }
    }
}