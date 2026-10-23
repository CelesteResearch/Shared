using Celeste.Simulation.Save.Runtime;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState : ISourceSaveMirrorData
    {
        bool ISourceSaveMirrorData.MirrorMode => Assists.MirrorMode;
    }
}
