using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering.States;
using Celeste.Input.Gameplay;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Game.Diagnostics.Scenes;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Content.Dialogs;
using Celeste.Simulation.Runtime.Session;
using Celeste.Everest.Content.Registry;

namespace Celeste.Everest.Diagnostics.Scenes
{
    public class EverestPreviewRecordingState : PreviewRecordingState
    {
        public ChapterCompletionSession CurrentSession;

        public EverestPreviewRecordingState(ISourceEngineContext engine, string filename)
            : base(engine, filename)
        {
            if (engine.Frame.Scenes.CurrentScene is EverestPreviewRecordingState previewRecording)
                CurrentSession = previewRecording.CurrentSession;
            else
                CurrentSession = (engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot)?.Session;
        }

        protected override byte[] ReadRecordingBytes(string filename)
            => ((ISourceEverestFileProxyEnvironment)EngineContext).FileProxy.ReadAllBytes(filename);

        protected override PreviewRecordingState CreateNextPreview(string filename)
            => new EverestPreviewRecordingState(EngineContext, filename);

        public override void Update()
        {
            base.Update();
            PressCancelBackToPreviousScene();
        }

        public override void Render()
        {
            base.Render();
            RenderManual();
        }

        private void PressCancelBackToPreviousScene()
        {
            if (((IGameInputEnvironment)EngineContext).Input[GameAction.Escape].Pressed ||
                ((IGameInputEnvironment)EngineContext).Input[GameAction.MenuCancel].Pressed)
            {
                if (CurrentSession != null)
                    EngineContext.Frame.Scenes.NextScene = ((IOriginalLevelLoaderEnvironment)EngineContext)
                        .LevelLoaders.CreateLevelLoader(CurrentSession);
                else
                    EngineContext.Frame.Scenes.NextScene = ((IOriginalOverworldLoaderEnvironment)EngineContext)
                        .OverworldLoaders.CreateOverworldLoader(OverworldStartMode.Titlescreen);
            }
        }

        private void RenderManual()
        {
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null,
                SourceRasterizerState.CullNone, null,
                ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix);
            ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.Draw(SourceRenderContext, this,
                "Cancel: Back to Previous Scene", new Vector2(8f, 80f), Vector2.Zero,
                Vector2.One * 0.5f, PackedColor.White);
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
        }
    }
}
