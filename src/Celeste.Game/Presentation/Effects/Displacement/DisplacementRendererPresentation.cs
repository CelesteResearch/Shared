using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Components;
using Celeste.Scene.Entities;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Presentation.Backdrops.HeatWave;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Game.Presentation.Effects.Displacement
{
    public class DisplacementRendererPresentation : SceneRenderer
    {
        private readonly ISourceEngineContext engine;
        public bool Enabled = true;
        private float timer;
        private readonly List<DisplacementBurst> points = [];

        public DisplacementRendererPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public bool HasDisplacement(object scene)
        {
            if (points.Count <= 0 && ((SceneComponentTracker)((ISourceComponentIndexScene)scene).ComponentIndex)
                .GetTrackedComponent<DisplacementRenderHookState>("Celeste.DisplacementRenderHook") == null)
                return (scene as OriginalLevelSceneRoot).Foreground.Get<HeatWaveBackdropPresentation>() != null;
            return true;
        }

        public DisplacementBurst Add(DisplacementBurst point)
        {
            points.Add(point);
            return point;
        }

        public DisplacementBurst Remove(DisplacementBurst point)
        {
            points.Remove(point);
            return point;
        }

        public DisplacementBurst AddBurst(Vector2 position, float duration, float radiusFrom, float radiusTo,
            float alpha = 1f, Func<float, float> alphaEaser = null, Func<float, float> radiusEaser = null)
        {
            var texture =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GameAtlas[
                    "util/displacementcircle"];
            var burst = new DisplacementBurst(texture, position, texture.Center, duration);
            burst.ScaleFrom = radiusFrom / (texture.FrameWidth / 2);
            burst.ScaleTo = radiusTo / (texture.FrameWidth / 2);
            burst.AlphaFrom = alpha;
            burst.AlphaTo = 0f;
            burst.AlphaEaser = alphaEaser;
            return Add(burst);
        }

        public override void Update(object scene)
        {
            timer += engine.DeltaTime;
            for (var i = points.Count - 1; i >= 0; i--)
                if (points[i].Percent >= 1f)
                    points.RemoveAt(i);
                else
                    points[i].Update(engine.DeltaTime);
        }

        public void Clear()
        {
            points.Clear();
        }

        public override void BeforeRender(object scene)
        {
            engine.Effects.WaterSine = timer * 16f;
            engine.Effects.WaterCameraY =
                (int)Math.Floor((scene as OriginalLevelSceneRoot).Camera.Y);
            var camera = (scene as OriginalLevelSceneRoot).Camera;
            var color = new PackedColor(.5f, .5f, 0f, 1f);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget((scene as OriginalLevelSceneRoot)
                .Buffers.Displacement.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(color);
            if (!Enabled)
                return;
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp,
                SourceDepthStencilState.Default, SourceRasterizerState.CullNone, null, camera.Matrix);
            (scene as OriginalLevelSceneRoot).Foreground.Get<HeatWaveBackdropPresentation>()
                ?.RenderDisplacement((scene as OriginalLevelSceneRoot).SourceRenderContext,
                    scene as OriginalLevelSceneRoot);
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var raw in ((ISourceTrackedComponents)((ISourceComponentIndexScene)scene).ComponentIndex)
                     .GetTrackedComponents("Celeste.DisplacementRenderHook"))
            {
                var component = (DisplacementRenderHookState)raw;
                if (component.Visible && component.RenderDisplacement != null)
                    component.RenderDisplacement();
            }

            foreach (var point in points)
                point.Render((scene as OriginalLevelSceneRoot).SourceRenderContext);
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var raw in (scene as OriginalLevelSceneRoot).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.FakeWall"))
            {
                var entity = (SceneEntityState)raw;
                SourcePrimitiveDrawing.Rect((scene as OriginalLevelSceneRoot).SourceRenderContext, entity,
                    entity.X, entity.Y, entity.Width, entity.Height, color);
            }

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }
    }
}
