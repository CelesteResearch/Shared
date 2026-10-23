using System.Collections.ObjectModel;
using Celeste.Audio.IO;

namespace Celeste.Audio.Capture
{
    public sealed class SourceMicrophoneProcess
    {
        private bool micInit;
        public ISourceMicrophoneIO IO { get; }
        public Celeste.Core.Framework.Time.ISourceTimeSpanPolicy TimeSpans { get; }
        public ReadOnlyCollection<SourceMicrophone> MicList;

        public SourceMicrophoneProcess(ISourceMicrophoneIO io,
            Celeste.Core.Framework.Time.ISourceTimeSpanPolicy timeSpans)
        {
            IO = io;
            TimeSpans = timeSpans;
        }

        public ReadOnlyCollection<SourceMicrophone> All
        {
            get
            {
                if (MicList == null) MicList = new ReadOnlyCollection<SourceMicrophone>(GetMicrophones());
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

            int count = IO.GetNumAudioDevices(1);
            if (count < 1) return new SourceMicrophone[0];
            var microphones = new SourceMicrophone[count + 1];
            var desired = new Celeste.Audio.Interop.SourceCaptureAudioSpec
                { Frequency = 44100, Format = 32784, Channels = 1, Samples = 4096 };
            microphones[0] = new SourceMicrophone(this, IO.OpenAudioDevice(null, 1, ref desired, out var obtained, 0),
                "Default Device");
            for (int i = 0; i < count; i++)
            {
                string name = IO.GetAudioDeviceName(i, 1);
                microphones[i + 1] =
                    new SourceMicrophone(this, IO.OpenAudioDevice(name, 1, ref desired, out obtained, 0), name);
            }

            return microphones;
        }
    }
}
