using System;
using System.IO;

namespace Celeste.Audio.Media
{
    public sealed class SourceSong : IEquatable<SourceSong>, IDisposable
    {
        internal string handle;

        public string Name { get; private set; }

        public TimeSpan Duration { get; internal set; }

        public bool IsProtected => false;

        public bool IsRated => false;

        public int PlayCount { get; internal set; }

        public int Rating => 0;

        public int TrackNumber => 0;

        public bool IsDisposed { get; private set; }

        public SourceSong(string fileName, string name = null)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            handle = fileName;
            Name = name;
            IsDisposed = false;
        }

        public SourceSong(string fileName, int durationMS, Celeste.Core.Framework.Time.ISourceTimeSpanPolicy timeSpans)
            : this(fileName)
        {
            Duration = timeSpans.FromMilliseconds(durationMS);
        }

        ~SourceSong()
        {
            Dispose();
        }

        public void Dispose()
        {
            IsDisposed = true;
        }

        public bool Equals(SourceSong song)
        {
            if ((object)song != null)
            {
                return handle == song.handle;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return Equals(obj as SourceSong);
        }

        public static bool operator ==(SourceSong song1, SourceSong song2)
        {
            return song1?.Equals(song2) ?? ((object)song2 == null);
        }

        public static bool operator !=(SourceSong song1, SourceSong song2)
        {
            return !(song1 == song2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static SourceSong FromUri(string name, Uri uri, Celeste.Audio.IO.ISourceAudioFileEnvironment environment)
        {
            string fileName;
            if (uri.IsAbsoluteUri)
            {
                if (!uri.IsFile)
                {
                    throw new InvalidOperationException("Only local file URIs are supported for now");
                }

                fileName = uri.LocalPath;
            }
            else
            {
                fileName = Path.Combine(environment.TitleDirectory, uri.ToString());
            }

            return new SourceSong(fileName, name);
        }
    }
}
