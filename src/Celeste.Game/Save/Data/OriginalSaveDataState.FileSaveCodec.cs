using System;
using System.Runtime.Serialization;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState
    {
        [DataMember] public DateTime LastSave;

        [DataMember] public int TotalJumps, TotalWallJumps, TotalDashes;
    }
}
