using System;
using System.Runtime.Serialization;
using Celeste.Core.Audio;

namespace Celeste.Simulation.Audio
{
    // Session-owned audio state; keep this object across room transitions to preserve inherited progress.
    [DataContract]
    public sealed class RoomAudioState
    {
        [DataMember] public EventTrackState Music = new();
        [DataMember] public EventTrackState Ambience = new();
        [DataMember] public float? AmbienceVolume;
        [DataMember] public string MapPackage { get; private set; }
        [DataMember] public bool IgnoreLevelAudioLayerData { get; private set; }
        public RoomAudioSettings CurrentRoom { get; set; }

        public RoomAudioState()
        {
        }

        public RoomAudioState(string music, string ambience)
        {
            Music.Event = music;
            Ambience.Event = ambience;
        }

        public RoomAudioState(EventTrackState music, EventTrackState ambience)
        {
            if (music != null) Music = music.Clone();
            if (ambience != null) Ambience = ambience.Clone();
        }

        public static RoomAudioState CreateFromMetadata(string package, EventTrackState music,
            EventTrackState ambience, bool ignoreLevelAudioLayerData)
        {
            return new(music, ambience)
                { MapPackage = package, IgnoreLevelAudioLayerData = ignoreLevelAudioLayerData };
        }

        public void BindMapMetadata(string package, bool ignoreLevelAudioLayerData)
        {
            MapPackage = package;
            IgnoreLevelAudioLayerData = ignoreLevelAudioLayerData;
        }

        public void BindMapMetadata(RoomAudioState source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            MapPackage = source.MapPackage;
            IgnoreLevelAudioLayerData = source.IgnoreLevelAudioLayerData;
        }

        public RoomAudioState Clone()
        {
            return new(Music, Ambience)
            {
                MapPackage = MapPackage, IgnoreLevelAudioLayerData = IgnoreLevelAudioLayerData,
                CurrentRoom = CurrentRoom,
                AmbienceVolume = AmbienceVolume,
            };
        }
    }
}
