using System.Collections.ObjectModel;
using Celeste.Audio.Interop;
using Celeste.Audio.IO;
using Celeste.Core.Framework.Time;

namespace Celeste.Audio.Capture
{
    public sealed class SourceMicrophoneProcess
    {
        private bool micInit;
        public ISourceMicrophoneIO IO { get; }
        public ISourceTimeSpanPolicy TimeSpans { get; }
        public ReadOnlyCollection<SourceMicrophone> MicList;

        public SourceMicrophoneProcess(ISourceMicrophoneIO io,
            ISourceTimeSpanPolicy timeSpans)
        {
            IO = io;
            TimeSpans = timeSpans;
        }

        public ReadOnlyCollection<SourceMicrophone> All
        {
            get
            {
                if (MicList == null) MicList = new(GetMicrophones());
                return MicList;
            }
        }

        public SourceMicrophone Default
        {
            get
            {
                if (All.Count == 0) return null;
                return All[0];
            }
        }

        private SourceMicrophone[] GetMicrophones()
        {
            if (!micInit)
            {
                IO.InitializeCaptureAudio();
                micInit = true;
            }

            var count = IO.GetNumAudioDevices(1);
            if (count < 1) return /* ReSharper disable once UseCollectionExpression */ new SourceMicrophone[0];
            var microphones = new SourceMicrophone[count + 1];
            var desired = new SourceCaptureAudioSpec
                { Frequency = 44100, Format = 32784, Channels = 1, Samples = 4096 };
            microphones[0] = new(this, IO.OpenAudioDevice(null, 1, ref desired, out var obtained, 0),
                "Default Device");
            for (var i = 0; i < count; i++)
            {
                var name = IO.GetAudioDeviceName(i, 1);
                microphones[i + 1] =
                    new(this, IO.OpenAudioDevice(name, 1, ref desired, out obtained, 0), name);
            }

            return microphones;
        }
    }
}
