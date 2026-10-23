namespace Celeste.Simulation.Audio
{
    public interface IRoomAudioSession
    {
        RoomAudioState State { get; }
        string ResolveEvent(string handle);
        string ResolveUnlockEvent(string style, string handle);
        void SetMusicHandle(string handle, int progress);
        void SetAltMusicHandle(string handle);
        void SetMusicFade(string parameter, float value);
        void SetAmbienceParameter(string parameter, float value);
        void Apply(bool forceSixteenthNoteHack = false);
        void CompleteTransition();
    }
}
