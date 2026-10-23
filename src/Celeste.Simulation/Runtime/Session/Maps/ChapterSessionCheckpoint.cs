using Celeste.Simulation.Audio;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using Celeste.Simulation;

namespace Celeste.Simulation.Runtime.Session.Maps
{
    public sealed class ChapterSessionCheckpoint
    {
        public string Level, Name, ColorGrade;
        public global::Celeste.Core.Campaigns.CampaignAreaKey Area;
        public bool Dreaming;
        public global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory? Inventory;
        public global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode? CoreMode;
        public RoomAudioState Audio;
        public HashSet<string> Flags;
    }
}
