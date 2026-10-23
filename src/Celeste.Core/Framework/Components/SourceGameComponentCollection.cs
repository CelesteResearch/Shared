using System;
using System.Collections.ObjectModel;

namespace Celeste.Core.Framework.Components
{
    public sealed class SourceGameComponentCollection : Collection<ISourceGameComponent>
    {
        public event EventHandler<SourceGameComponentCollectionEventArgs> ComponentAdded;
        public event EventHandler<SourceGameComponentCollectionEventArgs> ComponentRemoved;

        protected override void ClearItems()
        {
            for (int i = 0; i < Count; i++)
                OnComponentRemoved(new SourceGameComponentCollectionEventArgs(this[i]));
            base.ClearItems();
        }

        protected override void InsertItem(int index, ISourceGameComponent item)
        {
            if (IndexOf(item) != -1) throw new ArgumentException("Cannot Add Same Component Multiple Times");
            base.InsertItem(index, item);
            if (item != null) OnComponentAdded(new SourceGameComponentCollectionEventArgs(item));
        }

        protected override void RemoveItem(int index)
        {
            ISourceGameComponent item = this[index];
            base.RemoveItem(index);
            if (item != null) OnComponentRemoved(new SourceGameComponentCollectionEventArgs(item));
        }

        protected override void SetItem(int index, ISourceGameComponent item) => throw new NotSupportedException();

        private void OnComponentAdded(SourceGameComponentCollectionEventArgs e)
        {
            if (ComponentAdded != null) ComponentAdded(this, e);
        }

        private void OnComponentRemoved(SourceGameComponentCollectionEventArgs e)
        {
            if (ComponentRemoved != null) ComponentRemoved(this, e);
        }
    }
}
