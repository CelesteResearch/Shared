namespace Celeste.Game.Execution.Areas
{
    public class OriginalAreaModeData : global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionModeData
    {
        public string PoemID;
        public string Path;
        public int TotalStrawberries;
        public int StartStrawberries;
        public global::Celeste.Game.Content.Maps.Entities.OriginalLevelEntityData[,] StrawberriesByCheckpoint;
        public OriginalCheckpointData[] Checkpoints;
        public global::Celeste.Game.Content.Maps.OriginalChapterMapData MapData;
        public global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory Inventory;
        public global::Celeste.Simulation.Audio.RoomAudioState AudioState;
        public bool IgnoreLevelAudioLayerData;

        global::Celeste.Simulation.Audio.RoomAudioState
            global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionModeData.AudioState => AudioState;
    }
}
