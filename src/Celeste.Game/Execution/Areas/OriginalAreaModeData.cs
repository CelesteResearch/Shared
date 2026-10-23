using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Player.Inventory;
using Celeste.Simulation.Runtime.Session.Maps;

namespace Celeste.Game.Execution.Areas
{
    public class OriginalAreaModeData : IChapterSessionModeData
    {
        public string PoemID;
        public string Path;
        public int TotalStrawberries;
        public int StartStrawberries;
        public OriginalLevelEntityData[,] StrawberriesByCheckpoint;
        public OriginalCheckpointData[] Checkpoints;
        public OriginalChapterMapData MapData;
        public RoomPlayerInventory Inventory;
        public RoomAudioState AudioState;
        public bool IgnoreLevelAudioLayerData;

        RoomAudioState
            IChapterSessionModeData.AudioState => AudioState;
    }
}
