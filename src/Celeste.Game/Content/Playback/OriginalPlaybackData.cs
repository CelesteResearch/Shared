using System;
using System.Collections.Generic;
using System.IO;
using Celeste.Core.IO.Content;
using Celeste.Formats.Replay.Timelines;
using Celeste.Graphics.Animation.Replay;

namespace Celeste.Game.Content.Playback
{
// Process-owned PlaybackData.Tutorials. Load runs at Celeste.LoadContent, never per room.
    public sealed class OriginalPlaybackData
    {
        public Dictionary<string, List<CharacterReplayFrame>> Tutorials =
            new Dictionary<string, List<CharacterReplayFrame>>();

        private readonly Action<IDictionary<string, List<CharacterReplayFrame>>> additionalTimelineLoader;
        private readonly Action<IDictionary<string, List<CharacterReplayFrame>>, string, byte[]> tutorialLoader;

        public OriginalPlaybackData() : this(null, null)
        {
        }

        public OriginalPlaybackData(Action<IDictionary<string, List<CharacterReplayFrame>>> additionalTimelineLoader,
            Action<IDictionary<string, List<CharacterReplayFrame>>, string, byte[]> tutorialLoader)
        {
            this.additionalTimelineLoader = additionalTimelineLoader;
            this.tutorialLoader = tutorialLoader;
        }

        public void Load(string contentDirectory, IContentSource contentFiles)
        {
            if (additionalTimelineLoader != null) Tutorials.Clear();
            string[] files = contentFiles.GetFiles(Path.Combine(contentDirectory, "Tutorials"));
            foreach (string path in files)
            {
                string name = Path.GetFileNameWithoutExtension(path);
                using Stream stream = contentFiles.OpenTitleStream(path);
                using var bytes = new MemoryStream();
                stream.CopyTo(bytes);
                if (tutorialLoader != null) tutorialLoader(Tutorials, name, bytes.ToArray());
                else
                {
                    List<CharacterReplayFrame> value = PlaybackTimelineCodec.Import(bytes.ToArray());
                    Tutorials[name] = value;
                }
            }

            additionalTimelineLoader?.Invoke(Tutorials);
        }
    }
}
