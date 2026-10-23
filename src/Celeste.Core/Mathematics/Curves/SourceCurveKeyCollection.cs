using System;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Core.Mathematics.Curves
{
    public class SourceCurveKeyCollection : ICollection<SourceCurveKey>, IEnumerable<SourceCurveKey>, IEnumerable
    {
#pragma warning disable CS0649 // The source collection retains this field at its default value.
        private bool isReadOnly;
#pragma warning restore CS0649

        private List<SourceCurveKey> innerlist;

        public int Count => innerlist.Count;

        public bool IsReadOnly => isReadOnly;

        public SourceCurveKey this[int index]
        {
            get { return innerlist[index]; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                if (index >= innerlist.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                if (Celeste.Core.Mathematics.SourceFloatEqualityArithmetic.WithinEpsilon(innerlist[index].Position,
                        value.Position))
                {
                    innerlist[index] = value;
                    return;
                }

                innerlist.RemoveAt(index);
                innerlist.Add(value);
            }
        }

        public SourceCurveKeyCollection()
        {
            innerlist = new List<SourceCurveKey>();
        }

        public void Add(SourceCurveKey item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (innerlist.Count == 0)
            {
                innerlist.Add(item);
                return;
            }

            for (int i = 0; i < innerlist.Count; i++)
            {
                if (item.Position < innerlist[i].Position)
                {
                    innerlist.Insert(i, item);
                    return;
                }
            }

            innerlist.Add(item);
        }

        public void Clear()
        {
            innerlist.Clear();
        }

        public SourceCurveKeyCollection Clone()
        {
            SourceCurveKeyCollection curveKeyCollection = new SourceCurveKeyCollection();
            foreach (SourceCurveKey item in innerlist)
            {
                curveKeyCollection.Add(item);
            }

            return curveKeyCollection;
        }

        public bool Contains(SourceCurveKey item)
        {
            return innerlist.Contains(item);
        }

        public void CopyTo(SourceCurveKey[] array, int arrayIndex)
        {
            innerlist.CopyTo(array, arrayIndex);
        }

        public IEnumerator<SourceCurveKey> GetEnumerator()
        {
            return innerlist.GetEnumerator();
        }

        public int IndexOf(SourceCurveKey item)
        {
            return innerlist.IndexOf(item);
        }

        public bool Remove(SourceCurveKey item)
        {
            return innerlist.Remove(item);
        }

        public void RemoveAt(int index)
        {
            innerlist.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerlist.GetEnumerator();
        }
    }
}
