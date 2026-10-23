namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : global::Celeste.Scene.Tagging.ISourceHudTagEnvironment
    {
        global::Celeste.Scene.Tagging.SourceBitTag global::Celeste.Scene.Tagging.ISourceHudTagEnvironment.HudTag
            => ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)this).Tags.HUD;
    }
}
