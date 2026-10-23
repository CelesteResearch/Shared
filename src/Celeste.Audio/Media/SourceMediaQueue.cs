using System.Collections.Generic;

namespace Celeste.Audio.Media
{
    public sealed class SourceMediaQueue
    {
        private List<SourceSong> songs = new List<SourceSong>();

        public SourceSong ActiveSong
        {
            get
            {
                if (songs.Count == 0 || ActiveSongIndex < 0)
                {
                    return null;
                }

                return songs[ActiveSongIndex];
            }
        }

        public int ActiveSongIndex { get; set; }

        public int Count => songs.Count;

        public SourceSong this[int index] => songs[index];

        internal SourceMediaQueue()
        {
            ActiveSongIndex = -1;
        }

        internal void Add(SourceSong song)
        {
            songs.Add(song);
        }

        internal void Clear()
        {
            songs.Clear();
        }
    }
}
