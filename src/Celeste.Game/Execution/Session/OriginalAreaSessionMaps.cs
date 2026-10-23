using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Runtime.Session.Maps;

namespace Celeste.Game.Execution.Session
{
    public sealed class OriginalAreaSessionMaps : IChapterSessionData
    {
        private readonly IOriginalAreaSourceTable table;
        public OriginalAreaSessionMaps(IOriginalAreaSourceTable table) => this.table = table;

        public global::Celeste.Simulation.Audio.RoomAudioState GetAudioState(int areaID, int mode)
            => table.Areas[areaID].GetOriginalMode(mode).AudioState;

        public IChapterSessionMapData GetMap(int areaID, int mode)
            => table.Areas[areaID].GetOriginalMode(mode).MapData;
    }
}
