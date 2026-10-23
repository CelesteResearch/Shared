#nullable enable annotations
using System;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Profiles;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Rendering;

namespace Celeste.Game.Presentation.Rendering
{
    public sealed class GameplayRendererState : SceneRenderer
    {
        public readonly CameraState Camera;
        private static GameplayRendererState instance;

        // Runs in the active gameplay batch when the global debug pass is disabled.
        public static event Action<GameplayRendererState, object>? RenderAdditionalDebug;

        public GameplayRendererState(ISourceEngineContext engine)
        {
            instance = this;
            Camera = new(320, 180,
                ((ISourceVectorEnvironment)engine).VectorArithmetic);
        }

        public static void Begin(ISourceRenderContext context)
        {
            context.BeginBatch(new(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.PointWrap,
                SourceDepthStencilState.None, SourceRasterizerState.CullNone, null, instance.Camera.Matrix));
        }

        public static void End(ISourceRenderContext context)
        {
            context.EndBatch();
        }

        public override void Render(object scene)
        {
            var actual = (OriginalLevelSceneRoot)scene;
            var capture = ((ISourceDrawScope)actual.SourceRenderContext)
                .Draw.SpriteBatch.PresentationCapture;
            var cameraMatrix = Camera.Matrix;
            var recording = capture?.BeginFrame(actual.Session.Level, in cameraMatrix,
                ((ISourceRenderTargetContext)actual.SourceRenderContext).CurrentTarget) ?? false;
            var completed = false;
            try
            {
                Begin(actual.SourceRenderContext);
                var hud = ((IOriginalGameTagsEnvironment)actual.EngineContext)
                    .Tags.HUD.Value;
                var installed =
                    ((IGameProfileEnvironment)actual
                        .EngineContext).SourceProfile == GameProfile.InstalledEverest;
                if (installed)
                    hud |= ((IOriginalGameplayRendererGlobalsEnvironment)actual.EngineContext).SourceSubHudTag.Value;
                var diagnostics = SourceFrameDiagnostics.Current;
                long gameplayEntityRenderStarted = 0;
                var measuringGameplayEntityRender =
                    diagnostics?.BeginGameplayEntityRender(out gameplayEntityRenderStarted) ?? false;
                try
                {
                    actual.SourceScene.RenderEntitiesExcept(actual.SourceRenderContext, hud);
                }
                finally
                {
                    if (measuringGameplayEntityRender) diagnostics.EndGameplayEntityRender(gameplayEntityRenderStarted);
                }

                var renderDebug = installed
                    ? ((IOriginalGameplayRendererGlobalsEnvironment)actual.EngineContext).GameplayRendererGlobals
                      .RenderDebug
                      || ((ISourceCommandsProcessEnvironment)actual
                          .EngineContext).Commands.Open
                    : ((ISourceCommandsProcessEnvironment)actual
                        .EngineContext).Commands.Open;
                if (renderDebug)
                {
                    var previous = recording ? capture.EnterDebug() : default;
                    try
                    {
                        actual.SourceScene.DebugRenderEntities(actual.SourceRenderContext, Camera);
                    }
                    finally
                    {
                        if (recording) capture.Exit(in previous);
                    }
                }

                else
                {
                    RenderAdditionalDebug?.Invoke(this, scene);
                }

                long gameplayEndBatchStarted = 0;
                var measuringGameplayEndBatch =
                    diagnostics?.BeginGameplayEndBatch(out gameplayEndBatchStarted) ?? false;
                try
                {
                    End(actual.SourceRenderContext);
                }
                finally
                {
                    if (measuringGameplayEndBatch) diagnostics.EndGameplayEndBatch(gameplayEndBatchStarted);
                }

                completed = true;
            }
            finally
            {
                if (recording)
                {
                    if (completed) capture.CompleteFrame();
                    else capture.AbortFrame();
                }
            }
        }
    }
}
