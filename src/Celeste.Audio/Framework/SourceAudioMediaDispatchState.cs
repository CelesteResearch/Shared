using System.Collections.Generic;
using Celeste.Audio.Capture;
using Celeste.Audio.IO;
using Celeste.Audio.Media;
using Celeste.Audio.Sound;
using Celeste.Core.Framework.Time;

namespace Celeste.Audio.Framework
{
    public sealed class SourceAudioMediaDispatchState
    {
        public bool ActiveSongChanged;
        public bool MediaStateChanged;
        public readonly List<SourceDynamicSoundEffectInstance> Streams = [];
        public SourceMicrophoneProcess Microphones { get; }
        public SourceMediaPlayerProcess MediaPlayer { get; }
        public SourceAudioProcess Audio { get; }

        public SourceAudioMediaDispatchState(ISourceFAudioIO audioIO, ISourceMicrophoneIO microphoneIO,
            ISourceTimeSpanPolicy timeSpans)
        {
            Audio = new(audioIO, this, timeSpans);
            Microphones = new(microphoneIO, timeSpans);
            MediaPlayer = new(this, audioIO);
        }
    }
}
