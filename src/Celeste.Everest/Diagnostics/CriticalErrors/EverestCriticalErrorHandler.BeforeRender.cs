using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Game.Execution.Graphics;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandler
    {
        private void BeforeRender()
        {
            if (!UsePlayerSprite) return;
            try
            {
                if (playerSprite == null)
                {
                    playerSprite = new PlayerSprite(EngineContext, PlayerSpriteMode.MadelineNoBackpack)
                        { RenderPosition = Vector2.Zero };
                }

                if (playerHair == null)
                    playerHair = new PlayerHair(playerSprite, EngineContext)
                    {
                        Facing = 1,
                        SimulateMotion = true,
                        StepPerSegment = Vector2.UnitY * 2f,
                        StepInFacingPerSegment = .5f,
                        StepApproach = 64f,
                        StepYSinePerSegment = 0f
                    };
                if (playerRenderTarget == null)
                    playerRenderTarget = ((ISourceVirtualContentEnvironment)EngineContext).VirtualContent
                        .CreateRenderTarget("crit-error-handler-player", 32, 32);
                var context = ((ISourceRenderEnvironment)EngineContext).CurrentContext;
                var device =
                    ((global::Celeste.Graphics.Rendering.Devices.ISourceGraphicsDeviceEnvironment)EngineContext)
                    .GraphicsDevice;
                device.SetRenderTarget(playerRenderTarget.Target);
                device.Clear(PackedColor.Transparent);
                var sortMode = SourceSpriteSortMode.Deferred;
                var blend = SourceBlendState.AlphaBlend;
                var sampler = SourceSamplerState.PointClamp;
                var depthStencil = SourceDepthStencilState.Default;
                var rasterizer = SourceRasterizerState.CullNone;
                global::Celeste.Graphics.Rendering.Effects.SourceEffect effect = null;
                var transform = Matrix4x4.CreateTranslation(16f, 32f, 0f);
                process.BeforePlayerRender(ref sortMode, ref blend, ref sampler,
                    ref depthStencil, ref rasterizer, ref effect, ref transform);
                ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context).Draw.SpriteBatch.Begin(
                    new SourceRenderBatchState(sortMode, blend, sampler, depthStencil,
                        rasterizer, effect, transform));
                try
                {
                    playerHair.AfterUpdate();
                    playerHair.Render(context);
                    playerSprite.Render(context);
                }
                finally
                {
                    ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context).Draw.SpriteBatch.End();
                    process.AfterPlayerRender();
                }
            }
            catch (Exception error)
            {
                process.Logger.Log(EverestLogLevel.Error, "crit-error-handler", "Error while rendering player sprite:");
                process.Logger.LogDetailed(error, "crit-error-handler");
                process.AmendLogFile(LogFile, "Error while rendering player sprite", error);
                disablePlayerSprite = true;
            }
        }
    }
}
