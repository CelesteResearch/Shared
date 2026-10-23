using Celeste.Scene.Tagging;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceHudTagEnvironment
    {
        SourceBitTag ISourceHudTagEnvironment.HudTag
            => Tags.HUD;
    }
}
