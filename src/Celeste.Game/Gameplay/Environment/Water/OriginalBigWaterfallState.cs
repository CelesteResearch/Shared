using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Simulation.Rendering.Waterfalls;
using Color = Celeste.Core.Display.PackedColor;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;

namespace Celeste.Game.Gameplay.Environment.Water
{
    public class OriginalBigWaterfallState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        private enum Layers
        {
            FG,
            BG,
        }

        private readonly Layers layer;

        private readonly float width;

        private readonly float height;

        private float parallax;

        private readonly List<float> lines = [];

        protected Color surfaceColor;

        protected Color fillColor;

        private float sine;

        private readonly SoundSource loopingSfx;

        private float fade;

        private Vector2 RenderPosition =>
            RenderPositionAtCamera((Scene as Level).Camera.Position + new Vector2(160f, 90f));

        public OriginalBigWaterfallState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            layer = EntityAttributeReader.Enum(data.Values, "layer", Layers.BG);
            width = data.Width;
            height = data.Height;
            if (layer == Layers.FG)
            {
                Depth = -49900;
                parallax = 0.1f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * 0.2f;
                surfaceColor = ((IOriginalWaterStaticsEnvironment)engine).WaterStatics.SurfaceColor;
                fillColor = ((IOriginalWaterStaticsEnvironment)engine).WaterStatics.FillColor;
                Add(new DisplacementRenderHookState(RenderDisplacement));
                lines.Add(3f);
                lines.Add(width - 4f);
                Add(loopingSfx = ((IOriginalWaterfallSoundEnvironment)engine).SoundSources.Create());
                loopingSfx.Play("event:/env/local/waterfall_big_main");
            }
            else
            {
                Depth = 10010;
                parallax = 0f - (0.7f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * 0.2f);
                surfaceColor = SourceHexColor.HexToColor("89dbf0") * 0.5f;
                fillColor = SourceHexColor.HexToColor("29a7ea") * 0.3f;
                lines.Add(6f);
                lines.Add(width - 7f);
            }

            fade = 1f;
            Add(new RoomTransitionListener
            {
                OnIn = delegate(float f) { fade = f; },
                OnOut = delegate(float f) { fade = 1f - f; },
            });
            if (width > 16f)
            {
                var num = ((ISourceRandomEnvironment)engine).Random.Next((int)(width / 16f));
                for (var num2 = 0; num2 < num; num2++)
                    lines.Add(8f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, width - 16f));
            }
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if ((Scene as Level).Transitioning) fade = 0f;
        }

        public Vector2 RenderPositionAtCamera(Vector2 camera)
        {
            var vector = Position + new Vector2(width, height) / 2f - camera;
            var zero = Vector2.Zero;
            if (layer == Layers.BG)
                zero -= vector * 0.6f;
            else if (layer == Layers.FG) zero += vector * 0.2f;

            return Position + zero;
        }

        public void RenderDisplacement()
        {
            var context = ((ISourceRenderEnvironment)engine).CurrentContext;
            SourcePrimitiveDrawing.Rect(context, this, RenderPosition.X, Y, width, height,
                new(0.5f, 0.5f, 1f, 1f));
        }

        public override void Update()
        {
            sine += engine.DeltaTime;
            if (loopingSfx != null)
            {
                var position = (Scene as Level).Camera.Position;
                loopingSfx.Position = new(RenderPosition.X - X,
                    ScalarMath.Clamp(position.Y + 90f, Y, height,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic) - Y);
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var x = RenderPosition.X;
            var color = fillColor * fade;
            var color2 = surfaceColor * fade;
            SourcePrimitiveDrawing.Rect(context, this, x, Y, width, height, color);
            if (layer == Layers.FG)
            {
                WaterfallSurfaceDrawing.Straight(
                    (ISourceDrawScope)context, x, x - 1f, x + width - 2f,
                    Y, height, lines, color2);
                return;
            }

            var position = (Scene as Level).Camera.Position;
            var num = 3;
            var num2 =
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(Y,
                    (float)Math.Floor(position.Y / num) * num);
            var num3 = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(Y + height, position.Y + 180f);
            WaterfallSurfaceDrawing.Wavy(
                (ISourceDrawScope)context, x, width, num2, num3,
                num, sine, lines, color2);
        }
    }
}
