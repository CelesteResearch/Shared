using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceDecalAttachmentScene, ISourceDecalEnvironment,
        ISourceDecalFlagScene
    {
        public ISourceDecalAttachmentHistory DecalAttachmentHistory =>
            ((ISourceDecalAttachmentHistoryEnvironment)EngineContext).DecalAttachmentHistory;

        float ISourceDecalEnvironment.WindX => Wind.X;
        bool ISourceDecalEnvironment.CoreCold => CoreMode == RoomCoreMode.Cold;
        bool ISourceDecalFlagScene.GetFlag(string flag) => Session.GetFlag(flag);
    }
}
