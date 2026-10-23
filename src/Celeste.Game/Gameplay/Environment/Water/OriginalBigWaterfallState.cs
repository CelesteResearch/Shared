using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Color = Celeste.Core.Display.PackedColor;
using Rectangle = Celeste.Core.Geometry.IntRect;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;
using Water = Celeste.Game.Gameplay.Environment.Water.OriginalWaterState;
using Solid = Celeste.Simulation.Gameplay.Platforms.Foundation.SourceSolidEntityState;
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
            BG
        }

        private Layers layer;

        private float width;

        private float height;

        private float parallax;

        private List<float> lines = new List<float>();

        protected Color surfaceColor;

        protected Color fillColor;

        private float sine;

        private SoundSource loopingSfx;

        private float fade;

        private Vector2 RenderPosition =>
            RenderPositionAtCamera((base.Scene as Level).Camera.Position + new Vector2(160f, 90f));

        public OriginalBigWaterfallState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            base.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            layer = EntityAttributeReader.Enum(data.Values, "layer", Layers.BG);
            width = data.Width;
            height = data.Height;
            if (layer == Layers.FG)
            {
                base.Depth = -49900;
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
                base.Depth = 10010;
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
                OnOut = delegate(float f) { fade = 1f - f; }
            });
            if (width > 16f)
            {
                int num = ((ISourceRandomEnvironment)engine).Random.Next((int)(width / 16f));
                for (int num2 = 0; num2 < num; num2++)
                {
                    lines.Add(8f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, width - 16f));
                }
            }
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if ((base.Scene as Level).Transitioning)
            {
                fade = 0f;
            }
        }

        public Vector2 RenderPositionAtCamera(Vector2 camera)
        {
            Vector2 vector = Position + new Vector2(width, height) / 2f - camera;
            Vector2 zero = Vector2.Zero;
            if (layer == Layers.BG)
            {
                zero -= vector * 0.6f;
            }
            else if (layer == Layers.FG)
            {
                zero += vector * 0.2f;
            }

            return Position + zero;
        }

        public void RenderDisplacement()
        {
            var context = ((ISourceRenderEnvironment)engine).CurrentContext;
            SourcePrimitiveDrawing.Rect(context, this, RenderPosition.X, base.Y, width, height,
                new Color(0.5f, 0.5f, 1f, 1f));
        }

        public override void Update()
        {
            sine += engine.DeltaTime;
            if (loopingSfx != null)
            {
                Vector2 position = (base.Scene as Level).Camera.Position;
                loopingSfx.Position = new Vector2(RenderPosition.X - base.X,
                    ScalarMath.Clamp(position.Y + 90f, base.Y, height,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic) - base.Y);
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            float x = RenderPosition.X;
            Color color = fillColor * fade;
            Color color2 = surfaceColor * fade;
            SourcePrimitiveDrawing.Rect(context, this, x, base.Y, width, height, color);
            if (layer == Layers.FG)
            {
                global::Celeste.Simulation.Rendering.Waterfalls.WaterfallSurfaceDrawing.Straight(
                    (global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context, x, x - 1f, x + width - 2f,
                    base.Y, height, lines, color2);
                return;
            }

            Vector2 position = (base.Scene as Level).Camera.Position;
            int num = 3;
            float num2 =
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(base.Y,
                    (float)Math.Floor(position.Y / (float)num) * (float)num);
            float num3 = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(base.Y + height, position.Y + 180f);
            global::Celeste.Simulation.Rendering.Waterfalls.WaterfallSurfaceDrawing.Wavy(
                (global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context, x, width, num2, num3,
                num, sine, lines, color2);
        }
    }
}
