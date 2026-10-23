using Celeste.Core.Display;
using Celeste.Scene.Tracking;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision;
using Celeste.Scene.Rendering;
using Celeste.Scene.Scenes;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Effects.Bloom;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Presentation.Effects.Bloom
{
    public class BloomRendererPresentation : SceneRenderer, IBloomParameters
    {
        public float Strength = 1f;

        public float Base;

        private AtlasEntry gradient;

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
            if (!(Strength > 0f))
            {
                return;
            }

            VirtualRenderTarget tempA = engine.Graphics.Buffers.TempA;
            SourceTexture2DResource texture = GaussianBlurPresentation.Blur(engine,
                (SourceTexture2DResource)target.Target,
                engine.Graphics.Buffers.TempA, engine.Graphics.Buffers.TempB);
            List<SourceComponentState> components =
                ((ISourceScene)scene).SourceScene.Components.GetTrackedComponents("Celeste.BloomPoint");
            List<SourceComponentState> components2 =
                ((ISourceScene)scene).SourceScene.Components.GetTrackedComponents("Celeste.EffectCutout");
            engine.GraphicsDevice.SetRenderTarget((SourceRenderTarget2DResource)tempA.Target);
            engine.GraphicsDevice.Clear(PackedColor.Transparent);
            if (Base < 1f)
            {
                var camera = (scene as OriginalLevelSceneRoot).Camera;
                engine.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                    SourceSamplerState.PointClamp, SourceDepthStencilState.None, SourceRasterizerState.CullNone, null,
                    camera.Matrix);
                float num = 1f / (float)gradient.Width;
                foreach (SourceComponentState item in components)
                {
                    BloomPointState bloomPoint = item as BloomPointState;
                    if (bloomPoint.Visible && !(bloomPoint.Radius <= 0f) && !(bloomPoint.Alpha <= 0f))
                    {
                        SourceAtlasDrawing.DrawCentered(engine, gradient,
                            ((ISourceEntityPosition)bloomPoint.Entity).Position + bloomPoint.Position,
                            PackedColor.White * bloomPoint.Alpha, bloomPoint.Radius * 2f * num);
                    }
                }

                foreach (CustomBloomCallbackComponentState component in ((ISourceScene)scene).SourceScene.Components
                         .GetTrackedComponents("Celeste.CustomBloom"))
                {
                    if (component.Visible && component.OnRenderBloom != null)
                    {
                        component.OnRenderBloom();
                    }
                }

                foreach (object entity in ((ISourceScene)scene).SourceScene.Entities.GetTrackedEntities(
                             "Celeste.SeekerBarrier"))
                {
                    if (entity is Celeste.Simulation.Gameplay.Enemies.Seeker.SeekerBarrierState barrier &&
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
                    foreach (SourceComponentState item2 in components2)
                    {
                        EffectCutoutState effectCutout = item2 as EffectCutoutState;
                        if (effectCutout.Visible)
                        {
                            SourcePrimitiveDrawing.Rect(engine, effectCutout.Left, effectCutout.Top,
                                effectCutout.Right - effectCutout.Left, effectCutout.Bottom - effectCutout.Top,
                                PackedColor.White * (1f - effectCutout.Alpha));
                        }
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
            engine.GraphicsDevice.SetRenderTarget((SourceRenderTarget2DResource)target.Target);
            var capture = engine.Draw.SpriteBatch.PresentationCapture;
            var layer = capture?.CameraLayer;
            bool observing = false;
            try
            {
                if (capture != null)
                {
                    var camera = capture.CameraTransform;
                    observing = layer.Begin((SourceRenderTarget2DResource)tempA.Target, target.Target,
                        capture.Room, in camera, capture.FrameSequence);
                }

                engine.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    engine.BloomBlendStates.AdditiveMaskToScreen);
                for (int i = 0; (float)i < Strength; i++)
                {
                    float num2 = (((float)i < Strength - 1f) ? 1f : (Strength - (float)i));
                    engine.Draw.SpriteBatch.Draw((SourceTexture2DResource)tempA.Target, Vector2.Zero,
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
