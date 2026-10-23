using Celeste.Core.Scheduling;
using Celeste.Core.Rendering.States;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Game.Entities.StarJump;
using Celeste.Game.Execution.Engine;

namespace Celeste.Game.Diagnostics.Scenes
{
    public class TestBreathingGameState : SourceSceneState
    {
        private OriginalBreathingMinigameState game;

        public TestBreathingGameState(ISourceEngineContext engine)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            game = new OriginalBreathingMinigameState(engine);
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
