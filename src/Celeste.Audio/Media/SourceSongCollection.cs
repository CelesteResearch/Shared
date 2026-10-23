using System;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Audio.Media
{
    public sealed class SourceSongCollection : IEnumerable<SourceSong>, IEnumerable, IDisposable
    {
        private List<SourceSong> innerlist;

        public SourceSong this[int index] => innerlist[index];

        public int Count => innerlist.Count;

        public bool IsDisposed { get; private set; }

        internal SourceSongCollection(List<SourceSong> songs)
        {
            innerlist = songs;
            IsDisposed = false;
        }

        public void Dispose()
        {
            innerlist.Clear();
            IsDisposed = true;
        }

        public IEnumerator<SourceSong> GetEnumerator()
        {
            return innerlist.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerlist.GetEnumerator();
        }
    }
}
