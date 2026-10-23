using System;

namespace Celeste.Formats.Map.Audio
{
    public static class RoomAudioSettingsCodec
    {
        public static RoomAudioSettingsData Read(global::Celeste.Core.Maps.MapElement room)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));
            var result = new RoomAudioSettingsData();
            foreach (var attribute in room.Attributes)
            {
                switch (attribute.Key)
                {
                    case "music": result.Music = (string)attribute.Value; break;
                    case "alt_music": result.AltMusic = (string)attribute.Value; break;
                    case "ambience": result.Ambience = (string)attribute.Value; break;
                    case "musicLayer1": result.MusicLayers[0] = (bool)attribute.Value ? 1 : 0; break;
                    case "musicLayer2": result.MusicLayers[1] = (bool)attribute.Value ? 1 : 0; break;
                    case "musicLayer3": result.MusicLayers[2] = (bool)attribute.Value ? 1 : 0; break;
                    case "musicLayer4": result.MusicLayers[3] = (bool)attribute.Value ? 1 : 0; break;
                    case "musicProgress": result.MusicProgress = ParseProgress(attribute.Value); break;
                    case "ambienceProgress": result.AmbienceProgress = ParseProgress(attribute.Value); break;
                    case "whisper": result.MusicWhispers = (bool)attribute.Value; break;
                    case "delayAltMusicFade": result.DelayAltMusic = (bool)attribute.Value; break;
                }
            }

            return result;
        }

        private static int ParseProgress(object value) =>
            int.TryParse(value.ToString(), out int progress) ? progress : -1;
    }
}
