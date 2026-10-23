using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.StarJump;
using Celeste.Game.Execution.Engine;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Diagnostics.Scenes
{
    public class TestBreathingGameState : SourceSceneState
    {
        private readonly OriginalBreathingMinigameState game;

        public TestBreathingGameState(ISourceEngineContext engine)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            game = new(engine);
            SourceScene.QueueSourceEntity(game);
        }

        public override void BeforeRender()
        {
            game.BeforeRender();
            base.BeforeRender();
        }

        public override void Render()
        {
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(
                SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp, null, null, null,
                ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix);
            game.Render(SourceRenderContext);
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
        }
    }
}
