namespace Celeste.Game.Audio.Runtime
{
    public partial class OriginalGameAudioSession
    {
        public bool BusMuted(string path, bool? mute)
            => Runtime.BusMutedNative(path, mute);

        public void BusStopAll(string path, bool immediate = false)
            => Runtime?.BusStopAllNative(path, immediate);
    }
}
