using Celeste.Everest.Content.Maps.Binary;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Simulation.Audio;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public class EverestAudioMetadata
    {
        public string Music { get; set; }

        public string Ambience { get; set; }

        public EverestAudioMetadata()
        {
        }

        public EverestAudioMetadata(BinaryPackerElement meta)
        {
            Parse(meta);
        }

        public RoomAudioState Convert()
        {
            return new(Music, Ambience);
        }

        public void Parse(BinaryPackerElement meta)
        {
            meta.AttrIf("Music", delegate(string v) { Music = v; });
            meta.AttrIf("Ambience", delegate(string v) { Ambience = v; });
        }
    }
}
