using System.Collections;
using System.Collections.Generic;

namespace Study.Algo.Combinatorics
{
    public class SimpleVariations : IEnumerable<IList<int>>
    {
        private int _myLowerIndex;
        private List<int> _myValues;

        public IEnumerator<IList<int>> GetEnumerator() => new SimpleEnumeratorWithoutRepetition(this);
        IEnumerator IEnumerable.GetEnumerator() => new SimpleEnumeratorWithoutRepetition(this);

        private void Initialize(List<int> values, int lowerIndex)
        {

        }
    }

    public class SimpleEnumeratorWithoutRepetition : IEnumerator<List<int>>
    {
        private readonly SimpleVariations _source;

        public SimpleEnumeratorWithoutRepetition(SimpleVariations source)
        {
            _source = source;
        }

        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public List<int> Current { get; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}