using Celeste.Game.Presentation.Rendering;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalGameplayRendererGlobalsEnvironment
    {
        private GameplayRendererSourceGlobals sourceGameplayRendererGlobals;
        public GameplayRendererSourceGlobals GameplayRendererGlobals => sourceGameplayRendererGlobals;

        public global::Celeste.Scene.Tagging.SourceBitTag SourceSubHudTag
            => ((global::Celeste.Everest.Runtime.Startup.IEverestGameTagsEnvironment)this).EverestTags.SubHUD;

        internal void ConstructSourceGameplayRendererGlobals()
        {
            sourceGameplayRendererGlobals = new GameplayRendererSourceGlobals();
        }
    }
}
