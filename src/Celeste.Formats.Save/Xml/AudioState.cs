using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Celeste.Formats.Save.Xml
{
    public sealed class AudioState
    {
        public AudioTrackState Music = new AudioTrackState(), Ambience = new AudioTrackState();
        public float? AmbienceVolume;
    }
}
