using Celeste.Core.Rendering.Diagnostics;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEntityListDebugRenderHooksEnvironment
    {
        public SourceEntityListDebugRenderHooks EntityListDebugRenderHooks { get; } = new();
    }
}
