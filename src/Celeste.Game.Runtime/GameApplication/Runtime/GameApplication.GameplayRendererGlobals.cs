using Celeste.Game.Presentation.Rendering;
using Celeste.Scene.Tagging;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalGameplayRendererGlobalsEnvironment
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private GameplayRendererSourceGlobals sourceGameplayRendererGlobals;

        public GameplayRendererSourceGlobals GameplayRendererGlobals => sourceGameplayRendererGlobals;

        public SourceBitTag SourceSubHudTag
            => EverestTags.SubHUD;

        internal void ConstructSourceGameplayRendererGlobals()
        {
            sourceGameplayRendererGlobals = new();
        }
    }
}
