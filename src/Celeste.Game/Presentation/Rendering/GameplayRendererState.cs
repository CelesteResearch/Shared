#nullable enable annotations
using System;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Scene.Rendering;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Game.Presentation.Rendering
{
    public sealed class GameplayRendererState : SceneRenderer
    {
        public readonly CameraState Camera;
        private static GameplayRendererState instance;

        // Runs in the active gameplay batch when the global debug pass is disabled.
        public static event Action<GameplayRendererState, object>? RenderAdditionalDebug;

        public GameplayRendererState(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            instance = this;
            Camera = new CameraState(320, 180,
                ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic);
        }

        public static void Begin(ISourceRenderContext context)
            => context.BeginBatch(new SourceRenderBatchState(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.PointWrap,
                SourceDepthStencilState.None, SourceRasterizerState.CullNone, null, instance.Camera.Matrix));

        public static void End(ISourceRenderContext context) => context.EndBatch();

        public override void Render(object scene)
        {
            var actual = (global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot)scene;
            var capture = ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)actual.SourceRenderContext)
                .Draw.SpriteBatch.PresentationCapture;
            var cameraMatrix = Camera.Matrix;
            bool recording = capture?.BeginFrame(actual.Session.Level, in cameraMatrix,
                ((ISourceRenderTargetContext)actual.SourceRenderContext).CurrentTarget) ?? false;
            bool completed = false;
            try
            {
                Begin(actual.SourceRenderContext);
                int hud = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)actual.EngineContext)
                    .Tags.HUD.Value;
                bool installed =
                    ((global::Celeste.Game.Profiles.IGameProfileEnvironment)actual
                        .EngineContext).SourceProfile == global::Celeste.Game.Profiles
                        .GameProfile.InstalledEverest;
                if (installed)
                    hud |= ((IOriginalGameplayRendererGlobalsEnvironment)actual.EngineContext).SourceSubHudTag.Value;
                var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
                long gameplayEntityRenderStarted = 0;
                bool measuringGameplayEntityRender =
                    diagnostics?.BeginGameplayEntityRender(out gameplayEntityRenderStarted) ?? false;
                try
                {
                    actual.SourceScene.RenderEntitiesExcept(actual.SourceRenderContext, hud);
                }
                finally
                {
                    if (measuringGameplayEntityRender) diagnostics.EndGameplayEntityRender(gameplayEntityRenderStarted);
                }

                bool renderDebug = installed
                    ? ((IOriginalGameplayRendererGlobalsEnvironment)actual.EngineContext).GameplayRendererGlobals
                      .RenderDebug
                      || ((global::Celeste.Framework.Diagnostics.Commands.ISourceCommandsProcessEnvironment)actual
                          .EngineContext).Commands.Open
                    : ((global::Celeste.Framework.Diagnostics.Commands.ISourceCommandsProcessEnvironment)actual
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

                else RenderAdditionalDebug?.Invoke(this, scene);

                long gameplayEndBatchStarted = 0;
                bool measuringGameplayEndBatch =
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
