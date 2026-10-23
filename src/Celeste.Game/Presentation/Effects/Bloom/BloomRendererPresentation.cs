using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Effects.Bloom;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Scene.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Presentation.Effects.Bloom
{
    public class BloomRendererPresentation : SceneRenderer, IBloomParameters
    {
        public float Strength = 1f;

        public float Base;

        private readonly AtlasEntry gradient;

        private readonly IOriginalBloomProcess engine;

        float IBloomParameters.Base
        {
            get => Base;
            set => Base = value;
        }

        float IBloomParameters.Strength
        {
            get => Strength;
            set => Strength = value;
        }

        public BloomRendererPresentation(IOriginalBloomProcess engine)
        {
            this.engine = engine;
            gradient = engine.Graphics.GameAtlas["util/bloomgradient"];
        }

        public void Apply(VirtualRenderTarget target, object scene)
        {
            if (!(Strength > 0f)) return;

            var tempA = engine.Graphics.Buffers.TempA;
            var texture = GaussianBlurPresentation.Blur(engine,
                target.Target,
                engine.Graphics.Buffers.TempA, engine.Graphics.Buffers.TempB);
            var components =
                ((ISourceScene)scene).SourceScene.Components.GetTrackedComponents("Celeste.BloomPoint");
            var components2 =
                ((ISourceScene)scene).SourceScene.Components.GetTrackedComponents("Celeste.EffectCutout");
            engine.GraphicsDevice.SetRenderTarget(tempA.Target);
            engine.GraphicsDevice.Clear(PackedColor.Transparent);
            if (Base < 1f)
            {
                var camera = (scene as OriginalLevelSceneRoot).Camera;
                engine.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                    SourceSamplerState.PointClamp, SourceDepthStencilState.None, SourceRasterizerState.CullNone, null,
                    camera.Matrix);
                var num = 1f / gradient.Width;
                foreach (var item in components)
                {
                    var bloomPoint = item as BloomPointState;
                    if (bloomPoint.Visible && !(bloomPoint.Radius <= 0f) && !(bloomPoint.Alpha <= 0f))
                        SourceAtlasDrawing.DrawCentered(engine, gradient,
                            ((ISourceEntityPosition)bloomPoint.Entity).Position + bloomPoint.Position,
                            PackedColor.White * bloomPoint.Alpha, bloomPoint.Radius * 2f * num);
                }

                foreach (CustomBloomCallbackComponentState component in ((ISourceScene)scene).SourceScene.Components
                         .GetTrackedComponents("Celeste.CustomBloom"))
                    if (component.Visible && component.OnRenderBloom != null)
                        component.OnRenderBloom();

                foreach (var entity in ((ISourceScene)scene).SourceScene.Entities.GetTrackedEntities(
                             "Celeste.SeekerBarrier"))
                {
                    if (entity is SeekerBarrierState barrier &&
                        !barrier.BloomMaskAllowed()) continue;
                    var collider = ((ISourceEntityCollider)entity).Collider;
                    SourcePrimitiveDrawing.Rect(engine, collider.AbsoluteLeft, collider.AbsoluteTop, collider.Width,
                        collider.Height, PackedColor.White);
                }

                engine.Draw.SpriteBatch.End();
                if (components2.Count > 0)
                {
                    engine.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                        engine.BloomBlendStates.CutoutBlendstate,
                        SourceSamplerState.PointClamp, null, null, null, camera.Matrix);
                    foreach (var item2 in components2)
                    {
                        var effectCutout = item2 as EffectCutoutState;
                        if (effectCutout.Visible)
                            SourcePrimitiveDrawing.Rect(engine, effectCutout.Left, effectCutout.Top,
                                effectCutout.Right - effectCutout.Left, effectCutout.Bottom - effectCutout.Top,
                                PackedColor.White * (1f - effectCutout.Alpha));
                    }

                    engine.Draw.SpriteBatch.End();
                }
            }

            engine.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend);
            SourcePrimitiveDrawing.Rect(engine, -10f, -10f, 340f, 200f, PackedColor.White * Base);
            engine.Draw.SpriteBatch.End();
            engine.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred, engine.BloomBlendStates.BlurredScreenToMask);
            engine.Draw.SpriteBatch.Draw(texture, Vector2.Zero, PackedColor.White.PackedValue);
            engine.Draw.SpriteBatch.End();
            engine.GraphicsDevice.SetRenderTarget(target.Target);
            var capture = engine.Draw.SpriteBatch.PresentationCapture;
            var layer = capture?.CameraLayer;
            var observing = false;
            try
            {
                if (capture != null)
                {
                    var camera = capture.CameraTransform;
                    observing = layer.Begin(tempA.Target, target.Target,
                        capture.Room, in camera, capture.FrameSequence);
                }

                engine.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    engine.BloomBlendStates.AdditiveMaskToScreen);
                for (var i = 0; i < Strength; i++)
                {
                    var num2 = i < Strength - 1f ? 1f : Strength - i;
                    engine.Draw.SpriteBatch.Draw(tempA.Target, Vector2.Zero,
                        (PackedColor.White * num2).PackedValue);
                }

                engine.Draw.SpriteBatch.End();
                if (observing) layer.Complete();
            }
            finally
            {
                if (observing) layer.Abort();
            }
        }
    }
}
