namespace Study.Algo.Patterns
{
    public sealed class SingletonC
    {
        private static SingletonC _instance = null;
        private static readonly object Lock = new object();
        private SingletonC() { }

        public static SingletonC Instance
        {
            get
            {
                if (_instance == null)
                    lock (Lock)
                        if (_instance == null)
                            _instance = new SingletonC();
                return _instance;
            }
        }

    }
}