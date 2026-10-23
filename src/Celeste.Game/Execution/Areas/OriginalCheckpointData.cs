using System.Collections.Generic;
using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Game.Execution.Areas
{
    public class OriginalCheckpointData
    {
        public string Level;
        public string Name;
        public bool Dreaming;
        public int Strawberries;
        public string ColorGrade;
        public RoomPlayerInventory? Inventory;
        public RoomAudioState AudioState;
        public HashSet<string> Flags;
        public RoomCoreMode? CoreMode;

        public OriginalCheckpointData(string level, string name, RoomPlayerInventory? inventory = null,
            bool dreaming = false, RoomAudioState audioState = null)
        {
            Level = level;
            Name = name;
            Inventory = inventory;
            Dreaming = dreaming;
            AudioState = audioState;
            CoreMode = null;
            ColorGrade = null;
        }
    }
}
