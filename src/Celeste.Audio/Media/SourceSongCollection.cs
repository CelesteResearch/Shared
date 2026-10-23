using System;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Audio.Media
{
    public sealed class SourceSongCollection : IEnumerable<SourceSong>, IEnumerable, IDisposable
    {
        private readonly List<SourceSong> _innerlist;

        public SourceSong this[int index] => _innerlist[index];

        public int Count => _innerlist.Count;

        public bool IsDisposed { get; private set; }

        internal SourceSongCollection(List<SourceSong> songs)
        {
            _innerlist = songs;
            IsDisposed = false;
        }

        public void Dispose()
        {
            _innerlist.Clear();
            IsDisposed = true;
        }

        public IEnumerator<SourceSong> GetEnumerator()
        {
            return _innerlist.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerlist.GetEnumerator();
        }
    }
}
