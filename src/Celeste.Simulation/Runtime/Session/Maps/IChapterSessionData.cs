using Celeste.Simulation.Audio;

namespace Celeste.Simulation.Runtime.Session.Maps
{
    // Runtime AreaData/ModeProperties/MapData lookup; it is rebound after loading a save.
    public interface IChapterSessionData
    {
        IChapterSessionMapData GetMap(int areaID, int mode);
        RoomAudioState GetAudioState(int areaID, int mode);
    }
}
