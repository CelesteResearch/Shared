using Celeste.Simulation;
using Celeste.Simulation.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState
    {
        [DataMember] public string Version, TheoSisterName;
        [DataMember] public FileAssists Assists;

        public void AssistModeChecks(
            global::Celeste.Game.Save.Runtime.IOriginalSaveInitializationServices services)
        {
            if (!VariantMode && !AssistMode) Assists = default;
            else if (!VariantMode) Assists.EnforceAssistMode();
            if (Assists.GameSpeed < 5 || Assists.GameSpeed > 20) Assists.GameSpeed = 10;
            services.SetInputInversion(Assists.MirrorMode);
        }
    }
}
