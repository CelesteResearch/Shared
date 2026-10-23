namespace Celeste.Formats.Save.Xml
{
    public sealed class AudioState
    {
        public AudioTrackState Music = new(), Ambience = new();
        public float? AmbienceVolume;
    }
}
