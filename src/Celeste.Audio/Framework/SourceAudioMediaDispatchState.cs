using System.Collections.Generic;
using Celeste.Audio.Capture;
using Celeste.Audio.Media;
using Celeste.Audio.Sound;
using Celeste.Audio.IO;

namespace Celeste.Audio.Framework
{
    public sealed class SourceAudioMediaDispatchState
    {
        public bool ActiveSongChanged;
        public bool MediaStateChanged;
        public readonly List<SourceDynamicSoundEffectInstance> Streams = new List<SourceDynamicSoundEffectInstance>();
        public SourceMicrophoneProcess Microphones { get; }
        public SourceMediaPlayerProcess MediaPlayer { get; }
        public SourceAudioProcess Audio { get; }

        public SourceAudioMediaDispatchState(ISourceFAudioIO audioIO, ISourceMicrophoneIO microphoneIO,
            Celeste.Core.Framework.Time.ISourceTimeSpanPolicy timeSpans)
        {
            Audio = new SourceAudioProcess(audioIO, this, timeSpans);
            Microphones = new SourceMicrophoneProcess(microphoneIO, timeSpans);
            MediaPlayer = new SourceMediaPlayerProcess(this, audioIO);
        }
    }
}
