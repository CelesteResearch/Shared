using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Everest.Presentation.Mountain.Policies;
using Celeste.Game.Presentation.Mountain.Policies;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalMountainPresentationEnvironment,
        IOriginalOverworldGraphicsEnvironment, IEverestMountainThreadSettingsEnvironment
    {
        IOriginalMountainPresentationPolicy IOriginalMountainPresentationEnvironment.MountainPresentationPolicy
            => SourceProfile == GameProfile.Original
                ? OriginalMountainPresentationPolicy.Instance
                : EverestMountainPresentationPolicy.Instance;

        bool? IEverestMountainThreadSettingsEnvironment.ThreadedGL => CurrentCoreSettings.ThreadedGL;
    }
}
