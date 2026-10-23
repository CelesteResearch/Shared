using Celeste.Simulation.Audio;

namespace Celeste.Everest.Content.Maps.Metadata
{
    public sealed class EverestModeAudioMetadata
    {
        public string Music { get; set; }
        public string Ambience { get; set; }

        public RoomAudioState Convert()
        {
            return new(Music, Ambience);
        }
    }
}
