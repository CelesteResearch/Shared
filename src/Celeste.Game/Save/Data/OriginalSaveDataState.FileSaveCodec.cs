using Celeste.Simulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml.Serialization;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState
    {
        [DataMember] public DateTime LastSave;

        [DataMember] public int TotalJumps, TotalWallJumps, TotalDashes;
    }
}
