using System.Collections.Generic;
using Celeste.Core.Campaigns;
using Celeste.Simulation.Audio;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Inventory;

namespace Celeste.Simulation.Runtime.Session.Maps
{
    public sealed class ChapterSessionCheckpoint
    {
        public string Level, Name, ColorGrade;
        public CampaignAreaKey Area;
        public bool Dreaming;
        public RoomPlayerInventory? Inventory;
        public RoomCoreMode? CoreMode;
        public RoomAudioState Audio;
        public HashSet<string> Flags;
    }
}
