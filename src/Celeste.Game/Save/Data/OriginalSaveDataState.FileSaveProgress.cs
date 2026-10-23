using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState
    {
        [DataMember] public HashSet<string> Flags;
    }
}
