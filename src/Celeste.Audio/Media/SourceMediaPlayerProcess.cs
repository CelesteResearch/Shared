using System;
using System.Diagnostics;

namespace Celeste.Audio.Media
{
    public sealed class SourceMediaPlayerProcess
    {
        private readonly Celeste.Audio.Framework.SourceAudioMediaDispatchState dispatch;
        private readonly Celeste.Audio.IO.ISourceMediaPlayerIO io;
        private bool INTERNAL_isMuted;

        private SourceMediaState INTERNAL_state;

        private float INTERNAL_volume;

        private bool initialized;

        private int numSongsInQueuePlayed;

        private Stopwatch timer;

        private readonly Random random;

        public bool GameHasControl => true;

        public bool IsMuted
        {
            get { return INTERNAL_isMuted; }
            set
            {
                INTERNAL_isMuted = value;
                io.XNA_SetSongVolume(INTERNAL_isMuted ? 0f : INTERNAL_volume);
            }
        }

        public bool IsRepeating { get; set; }

        public bool IsShuffled { get; set; }

        public TimeSpan PlayPosition => timer.Elapsed;

        public SourceMediaQueue Queue { get; private set; }

        public SourceMediaState State
        {
            get { return INTERNAL_state; }
            private set
            {
                if (INTERNAL_state != value)
                {
                    INTERNAL_state = value;
                    dispatch.MediaStateChanged = true;
                }
            }
        }

        public float Volume
        {
            get { return INTERNAL_volume; }
            set
            {
                INTERNAL_volume = Celeste.Core.Mathematics.ScalarMath.Clamp(value, 0f, 1f);
                io.XNA_SetSongVolume(IsMuted ? 0f : INTERNAL_volume);
            }
        }

        public bool IsVisualizationEnabled
        {
            get { return io.XNA_VisualizationEnabled() == 1; }
            set { io.XNA_EnableVisualization(value ? 1u : 0u); }
        }

        public event EventHandler<EventArgs> ActiveSongChanged;

        public event EventHandler<EventArgs> MediaStateChanged;

        public SourceMediaPlayerProcess(Celeste.Audio.Framework.SourceAudioMediaDispatchState dispatch,
            Celeste.Audio.IO.ISourceMediaPlayerIO io)
        {
            this.dispatch = dispatch;
            this.io = io;
            INTERNAL_isMuted = false;
            INTERNAL_state = SourceMediaState.Stopped;
            INTERNAL_volume = 1f;
            initialized = false;
            numSongsInQueuePlayed = 0;
            timer = new Stopwatch();
            random = new Random();
            Queue = new SourceMediaQueue();
        }

        public void MoveNext()
        {
            NextSong(1);
        }

        public void MovePrevious()
        {
            NextSong(-1);
        }

        public void Pause()
        {
            if (State == SourceMediaState.Playing && !(Queue.ActiveSong == null))
            {
                io.XNA_PauseSong();
                timer.Stop();
                State = SourceMediaState.Paused;
            }
        }

        public void Play(SourceSong song)
        {
            SourceSong obj = ((Queue.Count > 0) ? Queue[0] : null);
            Queue.Clear();
            numSongsInQueuePlayed = 0;
            LoadSong(song);
            Queue.ActiveSongIndex = 0;
            PlaySong(song);
            if (obj != song)
            {
                dispatch.ActiveSongChanged = true;
            }
        }

        public void Play(SourceSongCollection songs)
        {
            Play(songs, 0);
        }

        public void Play(SourceSongCollection songs, int index)
        {
            Queue.Clear();
            numSongsInQueuePlayed = 0;
            foreach (SourceSong song in songs)
            {
                LoadSong(song);
            }

            Queue.ActiveSongIndex = index;
            PlaySong(Queue.ActiveSong);
        }

        public void Resume()
        {
            if (State == SourceMediaState.Paused)
            {
                io.XNA_ResumeSong();
                timer.Start();
                State = SourceMediaState.Playing;
            }
        }

        public void Stop()
        {
            if (State != SourceMediaState.Stopped)
            {
                io.XNA_StopSong();
                timer.Stop();
                timer.Reset();
                for (int i = 0; i < Queue.Count; i++)
                {
                    Queue[i].PlayCount = 0;
                }

                State = SourceMediaState.Stopped;
            }
        }

        public void GetVisualizationData(SourceVisualizationData data)
        {
            io.XNA_GetSongVisualizationData(data.freq, data.samp, 256u);
        }

        public void Update()
        {
            if (Queue == null || Queue.ActiveSong == null || State != SourceMediaState.Playing ||
                io.XNA_GetSongEnded() == 0)
            {
                return;
            }

            numSongsInQueuePlayed++;
            if (numSongsInQueuePlayed >= Queue.Count)
            {
                numSongsInQueuePlayed = 0;
                if (!IsRepeating)
                {
                    Stop();
                    dispatch.ActiveSongChanged = true;
                    return;
                }
            }

            MoveNext();
        }

        internal void DisposeIfNecessary()
        {
            if (initialized)
            {
                io.XNA_SongQuit();
                initialized = false;
            }
        }

        public void OnActiveSongChanged()
        {
            if (ActiveSongChanged != null)
            {
                ActiveSongChanged(null, EventArgs.Empty);
            }
        }

        public void OnMediaStateChanged()
        {
            if (MediaStateChanged != null)
            {
                MediaStateChanged(null, EventArgs.Empty);
            }
        }

        private void LoadSong(SourceSong song)
        {
            Queue.Add(new SourceSong(song.handle, song.Name));
        }

        private void NextSong(int direction)
        {
            Stop();
            if (IsRepeating && Queue.ActiveSongIndex >= Queue.Count - 1)
            {
                Queue.ActiveSongIndex = 0;
                direction = 0;
            }

            if (IsShuffled)
            {
                Queue.ActiveSongIndex = random.Next(Queue.Count);
            }
            else
            {
                Queue.ActiveSongIndex =
                    Celeste.Core.Mathematics.Framework.SourceFrameworkMath.Clamp(Queue.ActiveSongIndex + direction, 0,
                        Queue.Count - 1);
            }

            SourceSong song = Queue[Queue.ActiveSongIndex];
            if (song != null)
            {
                PlaySong(song);
            }

            dispatch.ActiveSongChanged = true;
        }

        private void PlaySong(SourceSong song)
        {
            if (!initialized)
            {
                io.XNA_SongInit();
                initialized = true;
            }

            song.Duration = dispatch.Audio.TimeSpans.FromSeconds(io.XNA_PlaySong(song.handle));
            timer.Start();
            State = SourceMediaState.Playing;
        }
    }
}
