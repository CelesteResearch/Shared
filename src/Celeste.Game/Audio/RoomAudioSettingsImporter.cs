using System;
using Celeste.Core.Maps;
using Celeste.Formats.Map.Audio;
using Celeste.Simulation.Audio;

namespace Celeste.Game.Audio
{
    public static class RoomAudioSettingsImporter
    {
        public static RoomAudioSettings Read(MapElement room)
        {
            return Import(RoomAudioSettingsCodec.Read(room));
        }

        public static RoomAudioSettings Import(RoomAudioSettingsData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var room = new RoomAudioSettings
            {
                Music = data.Music, AltMusic = data.AltMusic, Ambience = data.Ambience,
                MusicProgress = data.MusicProgress, AmbienceProgress = data.AmbienceProgress,
                MusicWhispers = data.MusicWhispers, DelayAltMusic = data.DelayAltMusic,
            };
            Array.Copy(data.MusicLayers, room.MusicLayers, data.MusicLayers.Length);
            return room;
        }
    }
}
