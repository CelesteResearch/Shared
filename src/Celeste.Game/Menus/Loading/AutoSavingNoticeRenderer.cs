using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Rendering;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;

namespace Celeste.Game.Menus.Loading
{
// Celeste.AutoSavingNotice is a Renderer. Its icon and Wiggler are directly updated,
// not Entity components dispatched through a second native update list.
    public sealed class AutoSavingNoticeRenderer : SceneRenderer
    {
        private readonly IAutoSavingNoticeResources resources;
        private readonly Sprite icon;
        private readonly WigglerComponent wiggler;
        private float startTimer = .5f;
        private float timer;
        private float ease;

        public bool Display = true;
        public bool StillVisible;
        public bool ForceClose;

        public AutoSavingNoticeRenderer(IAutoSavingNoticeResources resources)
        {
            this.resources = resources ?? throw new ArgumentNullException(nameof(resources));
            icon = resources.CreateSaveIcon();
            icon.Visible = false;
            wiggler = resources.WigglerPool.Create(.4f, 4f, value => icon.Rotation = value * .1f);
        }

        public override void Update(object scene)
        {
            base.Update(scene);
            var engine = ((ISourceEngineContextScene)scene).EngineContext;
            float dt = engine.Frame.DeltaTime;
            if (startTimer > 0)
            {
                startTimer -= dt;
                if (startTimer <= 0)
                {
                    icon.Play("start");
                    icon.Visible = true;
                }
            }

            // Original Scene.OnInterval compares the actual clock against current Engine dt.
            if (((global::Celeste.Scene.Tracking.ISourceScene)scene).SourceScene.Clock.OnInterval(1f, engine))
                wiggler.Start();
            bool closing = ForceClose || (!Display && timer >= 1);
            ease = global::Celeste.Core.Mathematics.ScalarMath.Approach(ease, closing ? 0 : 1, dt,
                ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            timer += dt / 3;
            StillVisible = Display || ease > 0;
            wiggler.Update();
            icon.Update();
            if (closing && !string.IsNullOrEmpty(icon.CurrentAnimationID) && icon.CurrentAnimationID.Equals("idle"))
                icon.Play("end");
        }

        public override void Render(object scene)
        {
            var context = ((ISourceRenderContextScene)scene).SourceRenderContext;
            var engine = ((ISourceEngineContextScene)scene).EngineContext;
            float amount = ((global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)engine)
                .EasingArithmetic.CubeInOut(ease);
            PackedColor color = PackedColor.White * amount;
            var batch = new SourceRenderBatchState(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp, null, null, null,
                ((global::Celeste.Game.Execution.Engine.IOriginalEngineGraphicsEnvironment)engine).EngineGraphics
                .ScreenMatrix);
            context.BeginBatch(in batch);
            resources.ActiveFont.Draw(context, null, resources.CleanDialog("autosaving_title_PC"),
                new Vector2(960, 480 - 30 * amount), new Vector2(.5f, 1), Vector2.One, color);
            if (icon.Visible)
            {
                icon.RenderPosition = new Vector2(960, 540);
                icon.Render(context);
            }

            resources.ActiveFont.Draw(context, null, resources.CleanDialog("autosaving_desc_PC"),
                new Vector2(960, 600 + 30 * amount), new Vector2(.5f, 0), Vector2.One, color);
            context.EndBatch();
        }
    }
}
