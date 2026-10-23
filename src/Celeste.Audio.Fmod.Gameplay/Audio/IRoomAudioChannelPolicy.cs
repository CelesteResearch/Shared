namespace Celeste.Audio.Fmod.Gameplay.Audio
{
    public interface IRoomAudioChannelPolicy
    {
        bool SetMusic(RoomAudioDriver device, string path, bool startPlaying, bool allowFadeOut);
        bool SetAmbience(RoomAudioDriver device, string path, bool startPlaying);
        void SetAltMusic(RoomAudioDriver device, string path);
    }
}
