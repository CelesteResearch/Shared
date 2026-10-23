using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering.Renderers;
using Celeste.Input.Gameplay;
using Celeste.Game.Presentation.Effects.Distortion;
using Celeste.Game.Presentation.Effects.Glitch;
using Celeste.Game.Presentation.PostProcessing.ColorGrading;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Profiles;
using Celeste.Simulation;
using Celeste.Simulation.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public ISceneRenderer SubHudRenderer { get; private set; }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public void TransformLevelPresentation(ref Vector2 padding, ref Vector2 origin)
        {
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public SourceSpriteEffects TransformLevelPresentationEffects(SourceSpriteEffects effects) => effects;

        public override void Render()
        {
            var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
            long gameplayRenderStarted = 0;
            bool measuringGameplayRender = diagnostics?.BeginGameplayRender(out gameplayRenderStarted) ?? false;
            try
            {
                ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.SetRenderTarget(
                    Buffers.Gameplay.Target);
                ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Clear(PackedColor.Transparent);
                GameplayRenderer.Render(this);
            }
            finally
            {
                if (measuringGameplayRender) diagnostics.EndGameplayRender(gameplayRenderStarted);
            }

            long lightingRenderStarted = 0;
            bool measuringLightingRender = diagnostics?.BeginLightingRender(out lightingRenderStarted) ?? false;
            try
            {
                Lighting.Render(this);
            }
            finally
            {
                if (measuringLightingRender) diagnostics.EndLightingRender(lightingRenderStarted);
            }

            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.SetRenderTarget(Buffers.Level.Target);
            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Clear(BackgroundColor);
            Background.Render(this);
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.PresentationCapture?.CaptureBackground(Buffers.Level
                .Target);
            OriginalDistortionRender.Render(EngineContext, Buffers.Gameplay.Target,
                Buffers.Displacement.Target, Displacement.HasDisplacement(this));
            Bloom.Apply(Buffers.Level, this);
            var foregroundCapture = ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.PresentationCapture;
            var foregroundPair = foregroundCapture?.ForegroundPair;
            bool observingForeground = false;
            try
            {
                if (foregroundCapture != null)
                {
                    var foregroundCamera = foregroundCapture.CameraTransform;
                    observingForeground = foregroundPair.Begin(Buffers.Level.Target,
                        foregroundCapture.Room, in foregroundCamera, foregroundCapture.FrameSequence);
                }

                Foreground.Render(this);
                if (observingForeground) foregroundPair.Complete();
            }
            finally
            {
                if (observingForeground) foregroundPair.Abort();
            }

            OriginalGlitchRender.Apply(EngineContext, Buffers.Level, Glitch.Timer * 2f,
                Glitch.Seed, (float)Math.PI * 2f);
            if (EngineContext.Effects.DashAssistFreeze)
            {
                var entity =
                    SourceScene.Entities.GetTrackedEntity<PlayerDashAssistPresentation>("Celeste.PlayerDashAssist");
                if (entity != null)
                {
                    ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                        SourceBlendState.AlphaBlend,
                        SourceSamplerState.PointClamp, SourceDepthStencilState.Default,
                        SourceRasterizerState.CullNone, null, Camera.Matrix);
                    entity.Render(SourceRenderContext);
                    ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
                }
            }

            if (flash > 0f)
            {
                ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend,
                    SourceSamplerState.PointClamp, SourceDepthStencilState.Default,
                    SourceRasterizerState.CullNone, null);
                SourcePrimitiveDrawing.Rect(SourceRenderContext, this, -1f, -1f, 322f, 182f, flashColor * flash);
                ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
                if (flashDrawPlayer)
                {
                    ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                        SourceBlendState.AlphaBlend,
                        SourceSamplerState.PointClamp, SourceDepthStencilState.Default,
                        SourceRasterizerState.CullNone, null, Camera.Matrix);
                    var entity =
                        SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                            typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                    if (entity != null && entity.Visible)
                        entity.Render(SourceRenderContext);
                    ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
                }
            }

            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.SetRenderTarget(null);
            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Clear(PackedColor.Black);
            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Viewport = EngineRuntime.Viewport;
            var matrix = SourceMatrixMath.Multiply(SourceMatrixMath.CreateScale(6f), EngineRuntime.ScreenMatrix);
            var size = new Vector2(320f, 180f);
            var view = size * (1f / ZoomTarget);
            var origin = ZoomTarget != 1f
                ? Vector2ComponentDivision.Divide(ZoomFocusPoint - view * (1f / 2f), size - view) * size
                : Vector2.Zero;
            var previous =
                graphicsResources.ColorGradesAtlas.GetOrDefault(ColorGrade.LastGrade,
                    graphicsResources.ColorGradesAtlas["none"]);
            var current =
                graphicsResources.ColorGradesAtlas.GetOrDefault(Session.ColorGrade,
                    graphicsResources.ColorGradesAtlas["none"]);
            var grades = ((IOriginalColorGradeEnvironment)EngineContext).ColorGradeProcess;
            if (ColorGrade.Ease > 0f && previous != current)
                grades.Set(previous, current, ColorGrade.Ease);
            else
                grades.Set(current);
            float scale = Zoom * ((320f - ScreenPadding * 2f) / 320f);
            var padding = new Vector2(ScreenPadding, ScreenPadding * .5625f);
            TransformLevelPresentation(ref padding, ref origin);
            if (((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.Assists.MirrorMode)
            {
                padding.X = -padding.X;
                origin.X = 160f - (origin.X - 160f);
            }

            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.PointClamp, SourceDepthStencilState.Default,
                SourceRasterizerState.CullNone, grades.Effect, matrix);
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Draw(Buffers.Level.Target, origin + padding,
                Buffers.Level.Bounds,
                PackedColor.White.PackedValue, 0f, origin, scale,
                TransformLevelPresentationEffects(
                    ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave.Assists.MirrorMode
                        ? SourceSpriteEffects.FlipHorizontally
                        : SourceSpriteEffects.None), 0f);
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
            if (Pathfinder != null && Pathfinder.DebugRenderEnabled)
            {
                ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend,
                    SourceSamplerState.PointClamp, SourceDepthStencilState.Default,
                    SourceRasterizerState.CullNone, null, SourceMatrixMath.Multiply(Camera.Matrix, matrix));
                Pathfinder.Render(SourceRenderContext);
                ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
            }

            if (((IGameProfileEnvironment)EngineContext).SourceProfile ==
                GameProfile.InstalledEverest)
                SubHudRenderer.Render(this);
            if (((!Paused || !PauseMainMenuOpen) && !(wasPausedTimer < 1f))
                || !((IGameInputEnvironment)EngineContext).Input[GameAction.MenuJournal].Check || !AllowHudHide)
                HudRenderer.Render(this);
            if (Wipe != null)
                Wipe.Render(this);
            if (HiresSnow != null)
                HiresSnow.Render(this);
        }
    }
}
