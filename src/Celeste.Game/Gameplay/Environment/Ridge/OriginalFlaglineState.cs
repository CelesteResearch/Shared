using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Display.Colors;
using Color = Celeste.Core.Display.PackedColor;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation.Audio.Sources;
using Image = Celeste.Graphics.Animation.SpriteImage;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;
using SineWave = Celeste.Scene.Components.Oscillation.SineWaveState;
using BloomPoint = Celeste.Simulation.Presentation.PostProcessing.Bloom.BloomPointState;
using VertexLight = Celeste.Simulation.Presentation.Lighting.VertexLightState;
using Hitbox = Celeste.Physics.Collision.Shapes.HitboxColliderGeometry;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;
using Player = Celeste.Simulation.RoomPlayerSession;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalFlaglineState : SourceComponentState
    {
        protected readonly ISourceEngineContext engine;

        protected struct Cloth
        {
            public int Color;

            public int Height;

            public int Length;

            public int Step;
        }

        private Color[] colors;

        private Color[] highlights;

        private Color lineColor;

        private Color pinColor;

        protected Cloth[] clothes;

        protected float waveTimer;

        public float ClothDroopAmount = 0.6f;

        public Vector2 To;

        public Vector2 From => ((ISourceEntityPosition)base.Entity).Position;

        public OriginalFlaglineState(ISourceEngineContext engine, Vector2 to, Color lineColor, Color pinColor,
            Color[] colors, int minFlagHeight, int maxFlagHeight, int minFlagLength, int maxFlagLength, int minSpace,
            int maxSpace)
            : base(active: true, visible: true)
        {
            this.engine = engine;
            To = to;
            this.colors = colors;
            this.lineColor = lineColor;
            this.pinColor = pinColor;
            waveTimer = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * ((float)Math.PI * 2f);
            highlights = new Color[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                highlights[i] = SourceColorInterpolation.Lerp(colors[i], Color.White, 0.1f,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            }

            clothes = new Cloth[10];
            for (int j = 0; j < clothes.Length; j++)
            {
                clothes[j] = new Cloth
                {
                    Color = ((ISourceRandomEnvironment)engine).Random.Next(colors.Length),
                    Height = ((ISourceRandomEnvironment)engine).Random.Next(minFlagHeight, maxFlagHeight),
                    Length = ((ISourceRandomEnvironment)engine).Random.Next(minFlagLength, maxFlagLength),
                    Step = ((ISourceRandomEnvironment)engine).Random.Next(minSpace, maxSpace)
                };
            }
        }

        public override void Update()
        {
            waveTimer += engine.DeltaTime;
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 vector = ((From.X < To.X) ? From : To);
            Vector2 vector2 = ((From.X < To.X) ? To : From);
            float num = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector - vector2);
            float num2 = num / 8f;
            SimpleCurve simpleCurve = new SimpleCurve(vector, vector2,
                (vector2 + vector) / 2f + Vector2.UnitY * (num2 + (float)Math.Sin(waveTimer) * num2 * 0.3f));
            RenderCurve(context, vector, simpleCurve, num);
        }

        protected void RenderCurve(ISourceRenderContext context, Vector2 vector, SimpleCurve simpleCurve, float num)
        {
            Vector2 vector3 = vector;
            Vector2 vector4 = vector;
            float num3 = 0f;
            int num4 = 0;
            bool flag = false;
            while (num3 < 1f)
            {
                Cloth cloth = clothes[num4 % clothes.Length];
                num3 += (float)(flag ? cloth.Length : cloth.Step) / num;
                vector4 = ((ISourceCurveEnvironment)engine).CurveArithmetic.GetPoint(simpleCurve, num3);
                SourcePrimitiveDrawing.Line(context, Entity, vector3, vector4, lineColor,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                if (num3 < 1f && flag)
                {
                    float num5 = (float)cloth.Length * ClothDroopAmount;
                    SimpleCurve simpleCurve2 = new SimpleCurve(vector3, vector4,
                        (vector3 + vector4) / 2f +
                        new Vector2(0f, num5 + (float)Math.Sin(waveTimer * 2f + num3) * num5 * 0.4f));
                    Vector2 vector5 = vector3;
                    for (float num6 = 1f; num6 <= (float)cloth.Length; num6 += 1f)
                    {
                        Vector2 point =
                            ((ISourceCurveEnvironment)engine).CurveArithmetic.GetPoint(simpleCurve2,
                                num6 / (float)cloth.Length);
                        if (point.X != vector5.X)
                        {
                            SourcePrimitiveDrawing.Rect(context, Entity, vector5.X, vector5.Y, point.X - vector5.X + 1f,
                                cloth.Height, colors[cloth.Color]);
                            vector5 = point;
                        }
                    }

                    SourcePrimitiveDrawing.Rect(context, Entity, vector3.X, vector3.Y, 1f, cloth.Height,
                        highlights[cloth.Color]);
                    SourcePrimitiveDrawing.Rect(context, Entity, vector4.X, vector4.Y, 1f, cloth.Height,
                        highlights[cloth.Color]);
                    SourcePrimitiveDrawing.Rect(context, Entity, vector3.X, vector3.Y - 1f, 1f, 3f, pinColor);
                    SourcePrimitiveDrawing.Rect(context, Entity, vector4.X, vector4.Y - 1f, 1f, 3f, pinColor);
                    num4++;
                }

                vector3 = vector4;
                flag = !flag;
            }
        }
    }
}
