using Celeste.Simulation.Audio;

namespace Celeste.Game.Audio
{
    public static class OriginalRoomAudioFactory
    {
        public static RoomAudioState CreateForMap(string mapPackage, string checkpoint = null)
        {
            var state = RoomAudioDefaults.Create(mapPackage, checkpoint);
            state.BindMapMetadata(mapPackage, mapPackage == "9-Core");
            return state;
        }
    }
}
