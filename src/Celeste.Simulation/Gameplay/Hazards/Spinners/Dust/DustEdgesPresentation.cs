using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public sealed class DustEdgesPresentation : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private bool hasDust;
        private float noiseEase;
        private Vector2 noiseFromPos;
        private Vector2 noiseToPos;
        private VirtualTexture DustNoiseFrom;
        private VirtualTexture DustNoiseTo;

        public DustEdgesPresentation(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            AddTag(((ISourceGlobalFrozenExecutionTagsEnvironment)engine).GlobalFrozenExecutionTags.Global.Value |
                   ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                   .TransitionUpdate.Value);
            Depth = -48;
            OwnedComponents.Add(new BeforeRenderCallbackComponentState(BeforeRender));
        }

        private void CreateTextures()
        {
            var content = ((ISourceVirtualContentEnvironment)engine).VirtualContent;
            DustNoiseFrom = content.CreateTexture("dust-noise-a", 128, 72, PackedColor.White);
            DustNoiseTo = content.CreateTexture("dust-noise-b", 128, 72, PackedColor.White);
            var array = new PackedColor[DustNoiseFrom.Width * DustNoiseTo.Height];
            for (var i = 0; i < array.Length; i++)
                array[i] = new(SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random), 0f,
                    0f,
                    0f);
            GetSourceTexture(DustNoiseFrom).SetData(array);
            for (var j = 0; j < array.Length; j++)
                array[j] = new(SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random), 0f,
                    0f,
                    0f);
            GetSourceTexture(DustNoiseTo).SetData(array);
        }

        public override void Update()
        {
            noiseEase = ScalarMath.Approach(noiseEase, 1f, engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (noiseEase == 1f)
            {
                var dustNoiseFrom = DustNoiseFrom;
                DustNoiseFrom = DustNoiseTo;
                DustNoiseTo = dustNoiseFrom;
                noiseFromPos = noiseToPos;
                noiseToPos = new(SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random),
                    SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random));
                noiseEase = 0f;
            }

            ((ISourceDustProcessEnvironment)engine).DustProcess.DustGraphicEstabledCounter = 0;
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            Dispose();
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            Dispose();
        }

        public override void HandleGraphicsReset()
        {
            base.HandleGraphicsReset();
            Dispose();
        }

        private void Dispose()
        {
            if (DustNoiseFrom != null) DustNoiseFrom.Dispose();
            if (DustNoiseTo != null) DustNoiseTo.Dispose();
        }

        public void BeforeRender()
        {
            var components = ((ISourceScene)Scene).SourceScene.Components.GetTrackedComponents("Celeste.DustEdge");
            hasDust = components.Count > 0;
            if (!hasDust) return;
            var level = (IDustEdgesRenderScene)Scene;
            var device = ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice;
            var batch = ((ISourceDrawScope)engine).Draw.SpriteBatch;
            var context = ((ISourceRenderEnvironment)engine).CurrentContext;
            device.SetRenderTarget(level.DustTempA.Target);
            device.Clear(PackedColor.Transparent);
            batch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp,
                SourceDepthStencilState.None, SourceRasterizerState.CullNone, null, level.Camera.Matrix);
            foreach (var item in components)
            {
                var dustEdge = item as DustEdgePresentation;
                if (dustEdge.Visible && ((ISourceEntityVisibility)dustEdge.Entity).Visible)
                    dustEdge.RenderDust(context);
            }

            batch.End();
            if (DustNoiseFrom == null || DustNoiseFrom.IsDisposed) CreateTextures();
            var vector = FlooredCamera();
            device.SetRenderTarget(level.ResortDust.Target);
            device.Clear(PackedColor.Transparent);
            device.Textures[1] = GetSourceTexture(DustNoiseFrom);
            device.Textures[2] = GetSourceTexture(DustNoiseTo);
            level.DustEffect.Parameters["colors"]
                .SetValue(((ISourceDustStyleEnvironment)engine).DustStyles.GetStyle(level.DustAreaId).EdgeColors);
            level.DustEffect.Parameters["noiseEase"].SetValue(noiseEase);
            level.DustEffect.Parameters["noiseFromPos"]
                .SetValue(noiseFromPos + new Vector2(vector.X / 320f, vector.Y / 180f));
            level.DustEffect.Parameters["noiseToPos"]
                .SetValue(noiseToPos + new Vector2(vector.X / 320f, vector.Y / 180f));
            level.DustEffect.Parameters["pixel"].SetValue(new Vector2(.003125f, 1f / 180f));
            batch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp,
                SourceDepthStencilState.None, SourceRasterizerState.CullNone, level.DustEffect, Matrix4x4.Identity);
            batch.Draw(level.DustTempA.Target, Vector2.Zero, PackedColor.White.PackedValue);
            batch.End();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (hasDust)
            {
                var position = FlooredCamera();
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(((IDustEdgesRenderScene)Scene).ResortDust.Target,
                    position, PackedColor.White.PackedValue);
            }
        }

        private SourceTexture2DResource GetSourceTexture(VirtualTexture texture)
        {
            return ((IDustEdgesRenderScene)Scene).UseSafeDustTextures ? texture.TextureSafe : texture.Texture;
        }

        private Vector2 FlooredCamera()
        {
            var position = ((IDustEdgesRenderScene)Scene).Camera.Position;
            position.X = (int)Math.Floor(position.X);
            position.Y = (int)Math.Floor(position.Y);
            return position;
        }
    }
}
