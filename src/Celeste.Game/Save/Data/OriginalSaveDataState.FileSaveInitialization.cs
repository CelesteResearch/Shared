using System.Runtime.Serialization;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState
    {
        [DataMember] public string Version, TheoSisterName;
        [DataMember] public FileAssists Assists;

        public void AssistModeChecks(
            IOriginalSaveInitializationServices services)
        {
            if (!VariantMode && !AssistMode) Assists = default;
            else if (!VariantMode) Assists.EnforceAssistMode();
            if (Assists.GameSpeed < 5 || Assists.GameSpeed > 20) Assists.GameSpeed = 10;
            services.SetInputInversion(Assists.MirrorMode);
        }
    }
}
