namespace Study.Algo.Patterns
{
    public sealed class SingletonB
    {
        private static SingletonB _instance = null;
        private static readonly object Lock = new object();
        private SingletonB() { }

        public static SingletonB Instance
        {
            get
            {
                lock (Lock)
                    return _instance ?? (_instance = new SingletonB());
            }
        }
    }
}