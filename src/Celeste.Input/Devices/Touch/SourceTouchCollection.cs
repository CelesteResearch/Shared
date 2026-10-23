using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Input.Devices.Touch
{
    public struct SourceTouchCollection : IList<SourceTouchLocation>, ICollection<SourceTouchLocation>,
        IEnumerable<SourceTouchLocation>, IEnumerable
    {
        public struct Enumerator : IEnumerator<SourceTouchLocation>, IDisposable, IEnumerator
        {
            private SourceTouchCollection collection;

            private int position;

            public SourceTouchLocation Current => collection[position];

            object IEnumerator.Current => collection[position];

            internal Enumerator(SourceTouchCollection collection)
            {
                this.collection = collection;
                position = -1;
            }

            public bool MoveNext()
            {
                position++;
                return position < collection.Count;
            }

            public void Dispose()
            {
            }

            void IEnumerator.Reset()
            {
                position = -1;
            }
        }

        private readonly List<SourceTouchLocation> touches;

        public int Count => touches.Count;

        public bool GetIsConnected(SourceFnaTouchPanel sameProcessPanel) => sameProcessPanel.TouchDeviceExists;

        public bool IsReadOnly => true;

        public SourceTouchLocation this[int index]
        {
            get { return touches[index]; }
            set { touches[index] = value; }
        }

        public SourceTouchCollection(SourceTouchLocation[] touches)
        {
            this.touches = new List<SourceTouchLocation>(touches);
        }

        public void Add(SourceTouchLocation item)
        {
            touches.Add(item);
        }

        public void Clear()
        {
            touches.Clear();
        }

        public bool Contains(SourceTouchLocation item)
        {
            return touches.Contains(item);
        }

        public void CopyTo(SourceTouchLocation[] array, int arrayIndex)
        {
            touches.CopyTo(array, arrayIndex);
        }

        public bool FindById(int id, out SourceTouchLocation touchLocation)
        {
            foreach (SourceTouchLocation touch in touches)
            {
                if (touch.Id == id)
                {
                    touchLocation = touch;
                    return true;
                }
            }

            touchLocation = new SourceTouchLocation(-1, SourceTouchLocationState.Invalid, Vector2.Zero);
            return false;
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public int IndexOf(SourceTouchLocation item)
        {
            return touches.IndexOf(item);
        }

        public void Insert(int index, SourceTouchLocation item)
        {
            touches.Insert(index, item);
        }

        public bool Remove(SourceTouchLocation item)
        {
            return touches.Remove(item);
        }

        public void RemoveAt(int index)
        {
            touches.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<SourceTouchLocation> IEnumerable<SourceTouchLocation>.GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
