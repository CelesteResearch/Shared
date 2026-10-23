using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Everest.Content.Reloading
{
    public sealed partial class EverestAssetReloadScene
    {
        private static readonly Vector2 CogwheelAnchor = new(96f, 96f);
        private bool capturedSnapshots;
        private bool cogwheelInit;
        private AtlasEntry cogwheelTex;
        private ISourceRenderContext Context => ((ISourceRenderEnvironment)EngineContext).CurrentContext;

        public override void BeforeRender()
        {
            if (!capturedSnapshots)
            {
                CaptureSnapshots(process.ReturnToScene);
                capturedSnapshots = true;
            }

            base.BeforeRender();
            if (!(Context.Graphics.HudTarget != null))
                return;
            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.SetRenderTarget(
                ((VirtualRenderTarget)Context.Graphics.HudTarget).Target);
            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Clear(PackedColor.Transparent);
            RenderContent(true);
        }

        public override void Render()
        {
            base.Render();
            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Clear(PackedColor.Black);
            if (Context.Graphics.HudTarget == null)
            {
                RenderContent(false);
                return;
            }

            var state = new SourceRenderBatchState(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp, SourceDepthStencilState.Default, SourceRasterizerState.CullNone,
                null, Context.Graphics.ScreenMatrix);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.Begin(in state);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.Draw(
                ((VirtualRenderTarget)Context.Graphics.HudTarget).Target,
                new Vector2(-1f), PackedColor.White.PackedValue);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.End();
        }

        private void RenderContent(bool toHiresBuffer)
        {
            var context = Context;
            var state = new SourceRenderBatchState(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp, SourceDepthStencilState.None, SourceRasterizerState.CullNone,
                null, toHiresBuffer ? Matrix4x4.Identity : context.Graphics.ScreenMatrix);
            ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(in state);
            try
            {
                var amount = outTransition ? 1f - transitionTimer / .15f : transitionTimer / .3f;
                var easing = ((ISourceEasingEnvironment)EngineContext).EasingArithmetic;
                var scalar = ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic;
                var eased = easing.SineInOut(amount);
                var zoom = scalar.Lerp(0f, .01f,
                    outTransition ? easing.CubeOut(amount) : 1f - easing.ElasticIn(1f - amount));
                var destination = new IntRect((int)(1920f * zoom), (int)(1080f * zoom),
                    (int)(1920f * (1f - 2f * zoom)), (int)(1080f * (1f - 2f * zoom)));
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(snapshotTex, destination,
                    (PackedColor.White * scalar.Lerp(1f, .25f, eased)).PackedValue);
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(snapshotGrayScaleTex, destination,
                    (PackedColor.White * scalar.Lerp(0f, .45f, eased)).PackedValue);
                if (!cogwheelInit)
                {
                    cogwheelTex =
                        ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)EngineContext).GameGraphics)
                        .GuiAtlas != null
                            ? ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)EngineContext)
                                .GameGraphics)
                            .GuiAtlas["reloader/cogwheel"]
                            : null;
                    cogwheelInit = true;
                }

                if (cogwheelInit && !(cogwheelTex?.Texture?.TextureSafe?.IsDisposed ?? true))
                {
                    var scale = scalar.Lerp(.2f, .25f, easing.CubeOut(eased));
                    for (var i = -2; i <= 2; i++)
                    for (var j = -2; j <= 2; j++)
                        if (i != 0 || j != 0)
                            SourceAtlasDrawing.DrawCentered(context, this, cogwheelTex,
                                CogwheelAnchor + new Vector2(i, j), PackedColor.Black * easing.CubeIn(eased), scale,
                                cogwheelRot);
                    SourceAtlasDrawing.DrawCentered(context, this, cogwheelTex, CogwheelAnchor,
                        PackedColor.White * eased, scale, cogwheelRot);
                }

                try
                {
                    var position = CogwheelAnchor + Vector2.UnitX * 48f;
                    var text = ((IOriginalGameTextEnvironment)EngineContext).Text;
                    if (curDisplayText != null && text.Dialog.Language != null && text.ActiveFont.Font != null)
                    {
                        var size = text.ActiveFont.Measure(curDisplayText);
                        text.ActiveFont.DrawOutline(context, this, curDisplayText,
                            position + Vector2.UnitX * size.X / 2f,
                            Vector2.One / 2f, Vector2.One * scalar.Lerp(.8f, 1f, easing.CubeOut(eased)),
                            PackedColor.White * eased, 2f, PackedColor.Black * easing.CubeIn(eased));
                    }
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                process.Logger.Log(EverestLogLevel.Warn, "reload", "Failed to draw reload scene contents:");
                process.Logger.LogDetailed(error, "reload");
            }
            finally
            {
                ((ISourceDrawScope)context).Draw.SpriteBatch.End();
            }
        }
    }
}
