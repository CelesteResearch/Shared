using System;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Core.Mathematics.Curves
{
    public class SourceCurveKeyCollection : ICollection<SourceCurveKey>, IEnumerable<SourceCurveKey>, IEnumerable
    {
        private readonly List<SourceCurveKey> _innerlist;

        public int Count => _innerlist.Count;

        public bool IsReadOnly { get; }

        public SourceCurveKey this[int index]
        {
            get => _innerlist[index];
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                if (index >= _innerlist.Count) throw new IndexOutOfRangeException();

                if (SourceFloatEqualityArithmetic.WithinEpsilon(_innerlist[index].Position,
                        value.Position))
                {
                    _innerlist[index] = value;
                    return;
                }

                _innerlist.RemoveAt(index);
                _innerlist.Add(value);
            }
        }

        public SourceCurveKeyCollection()
        {
            _innerlist = [];
        }

        public void Add(SourceCurveKey item)
        {
            if (item == null) throw new ArgumentNullException("item");

            if (_innerlist.Count == 0)
            {
                _innerlist.Add(item);
                return;
            }

            for (var i = 0; i < _innerlist.Count; i++)
                if (item.Position < _innerlist[i].Position)
                {
                    _innerlist.Insert(i, item);
                    return;
                }

            _innerlist.Add(item);
        }

        public void Clear()
        {
            _innerlist.Clear();
        }

        public SourceCurveKeyCollection Clone()
        {
            var curveKeyCollection = new SourceCurveKeyCollection();
            foreach (var item in _innerlist) curveKeyCollection.Add(item);

            return curveKeyCollection;
        }

        public bool Contains(SourceCurveKey item)
        {
            return _innerlist.Contains(item);
        }

        public void CopyTo(SourceCurveKey[] array, int arrayIndex)
        {
            _innerlist.CopyTo(array, arrayIndex);
        }

        public IEnumerator<SourceCurveKey> GetEnumerator()
        {
            return _innerlist.GetEnumerator();
        }

        public int IndexOf(SourceCurveKey item)
        {
            return _innerlist.IndexOf(item);
        }

        public bool Remove(SourceCurveKey item)
        {
            return _innerlist.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _innerlist.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerlist.GetEnumerator();
        }
#pragma warning disable CS0649 // The source collection retains this field at its default value.
#pragma warning restore CS0649
    }
}
