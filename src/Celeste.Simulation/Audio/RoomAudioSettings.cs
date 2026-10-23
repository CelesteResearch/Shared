namespace Celeste.Simulation.Audio
{
    public sealed class RoomAudioSettings
    {
        public string Music = "", AltMusic = "", Ambience = "";
        public readonly float[] MusicLayers = new float[4];
        public int MusicProgress = -1, AmbienceProgress = -1;
        public bool MusicWhispers, DelayAltMusic;
    }
}
