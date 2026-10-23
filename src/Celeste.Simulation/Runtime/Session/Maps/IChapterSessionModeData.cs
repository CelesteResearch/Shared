using Celeste.Simulation.Audio;

namespace Celeste.Simulation.Runtime.Session.Maps
{
// MapData borrows the actual ModeProperties object. The getter reads its
// current AudioState field; it does not cache the value at map publication.
    public interface IChapterSessionModeData
    {
        RoomAudioState AudioState { get; }
    }
}
