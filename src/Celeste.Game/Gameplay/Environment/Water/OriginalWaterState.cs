using Celeste.Core.Display;
using Celeste.Formats.Map.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Presentation.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Color = Celeste.Core.Display.PackedColor;
using VertexPositionColor = Celeste.Graphics.Rendering.Vertices.SourceVertexPositionColor;
using Rectangle = Celeste.Core.Geometry.IntRect;
using WaterInteraction = Celeste.Simulation.Gameplay.Environment.Water.WaterInteractionState;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;
using Player = Celeste.Simulation.RoomPlayerSession;

namespace Celeste.Game.Gameplay.Environment.Water
{
    public class OriginalWaterState : SceneEntityState, ISourceEngineContextEntity, ISourceWater
    {
        public class Ripple
        {
            public float Position;

            public float Speed;

            public float Height;

            public float Percent;

            public float Duration;
        }

        public class Tension
        {
            public float Position;

            public float Strength;
        }

        public class Ray
        {
            public float Position;

            public float Percent;

            public float Duration;

            public float Width;

            public float Length;

            private float MaxWidth;

            private readonly ISourceEngineContext engine;

            public Ray(ISourceEngineContext engine, float maxWidth)
            {
                this.engine = engine;
                MaxWidth = maxWidth;
                Reset(SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random));
            }

            public void Reset(float percent)
            {
                Position = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * MaxWidth;
                Percent = percent;
                Duration = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 2f, 8f);
                Width = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 2, 16);
                Length = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 8f, 128f);
            }
        }

        public class Surface : ISourceWaterSurface
        {
            public const int Resolution = 4;

            public const float RaysPerPixel = 0.2f;

            public const float BaseHeight = 6f;

            public readonly Vector2 Outwards;

            public readonly int Width;

            public readonly int BodyHeight;

            public Vector2 Position;

            public List<Ripple> Ripples = new List<Ripple>();

            public List<Ray> Rays = new List<Ray>();

            public List<Tension> Tensions = new List<Tension>();

            protected float timer;

            protected VertexPositionColor[] mesh;

            protected int fillStartIndex;

            protected int rayStartIndex;

            protected int surfaceStartIndex;

            private readonly ISourceEngineContext engine;
            private readonly IOriginalWaterStatics appearance;

            private IOriginalWaterStatics Statics =>
                appearance ?? ((IOriginalWaterStaticsEnvironment)engine).WaterStatics;

            public Surface(ISourceEngineContext engine, Vector2 position, Vector2 outwards, float width,
                float bodyHeight) : this(engine, position, outwards, width, bodyHeight, null)
            {
            }

            protected Surface(ISourceEngineContext engine, Vector2 position, Vector2 outwards, float width,
                float bodyHeight, IOriginalWaterStatics appearance)
            {
                this.engine = engine;
                this.appearance = appearance;
                Position = position;
                Outwards = outwards;
                Width = (int)width;
                BodyHeight = (int)bodyHeight;
                int num = (int)(width / 4f);
                int num2 = (int)(width * 0.2f);
                Rays = new List<Ray>();
                for (int i = 0; i < num2; i++)
                {
                    Rays.Add(new Ray(engine, width));
                }

                fillStartIndex = 0;
                rayStartIndex = num * 6;
                surfaceStartIndex = (num + num2) * 6;
                mesh = new VertexPositionColor[(num * 2 + num2) * 6];
                for (int j = fillStartIndex; j < fillStartIndex + num * 6; j++)
                {
                    mesh[j].Color = Statics.FillColor;
                }

                for (int k = rayStartIndex; k < rayStartIndex + num2 * 6; k++)
                {
                    mesh[k].Color = Color.Transparent;
                }

                for (int l = surfaceStartIndex; l < surfaceStartIndex + num * 6; l++)
                {
                    mesh[l].Color = Statics.SurfaceColor;
                }
            }

            public float GetPointAlong(Vector2 position)
            {
                Vector2 vector = Vector2Geometry.Perpendicular(Outwards);
                Vector2 vector2 = Position + vector * (-Width / 2);
                Vector2 lineB = Position + vector * (Width / 2);
                Vector2 vector3 =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.ClosestPointOnLine(vector2, lineB, position);
                return ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector2 - vector3);
            }

            public Tension SetTension(Vector2 position, float strength)
            {
                Tension tension = new Tension
                {
                    Position = GetPointAlong(position),
                    Strength = strength
                };
                Tensions.Add(tension);
                return tension;
            }

            public void RemoveTension(Tension tension)
            {
                Tensions.Remove(tension);
            }

            public void DoRipple(Vector2 position, float multiplier)
            {
                float num = 80f;
                float num2 = 3f;
                float pointAlong = GetPointAlong(position);
                int num3 = 2;
                if (Width < 200)
                {
                    num2 *= ScalarMath.ClampedMap(Width, 0f, 200f, 0.25f);
                    multiplier *= ScalarMath.ClampedMap(Width, 0f, 200f, 0.5f);
                }

                Ripples.Add(new Ripple
                {
                    Position = pointAlong,
                    Speed = 0f - num,
                    Height = (float)num3 * multiplier,
                    Percent = 0f,
                    Duration = num2
                });
                Ripples.Add(new Ripple
                {
                    Position = pointAlong,
                    Speed = num,
                    Height = (float)num3 * multiplier,
                    Percent = 0f,
                    Duration = num2
                });
            }

            public virtual void Update()
            {
                timer += engine.DeltaTime;
                Vector2 vector = Vector2Geometry.Perpendicular(Outwards);
                for (int num = Ripples.Count - 1; num >= 0; num--)
                {
                    Ripple ripple = Ripples[num];
                    if (ripple.Percent > 1f)
                    {
                        Ripples.RemoveAt(num);
                    }
                    else
                    {
                        ripple.Position += ripple.Speed * engine.DeltaTime;
                        if (ripple.Position < 0f || ripple.Position > (float)Width)
                        {
                            ripple.Speed = 0f - ripple.Speed;
                            ripple.Position = ScalarMath.Clamp(ripple.Position, 0f, Width);
                        }

                        ripple.Percent += engine.DeltaTime / ripple.Duration;
                    }
                }

                int num2 = 0;
                int num3 = fillStartIndex;
                int num4 = surfaceStartIndex;
                while (num2 < Width)
                {
                    int num5 = num2;
                    float surfaceHeight = GetSurfaceHeight(num5);
                    int num6 = Math.Min(num2 + 4, Width);
                    float surfaceHeight2 = GetSurfaceHeight(num6);
                    mesh[num3].Position =
                        new Vector3(Position + vector * (-Width / 2 + num5) + Outwards * surfaceHeight, 0f);
                    mesh[num3 + 1].Position =
                        new Vector3(Position + vector * (-Width / 2 + num6) + Outwards * surfaceHeight2, 0f);
                    mesh[num3 + 2].Position = new Vector3(Position + vector * (-Width / 2 + num5), 0f);
                    mesh[num3 + 3].Position =
                        new Vector3(Position + vector * (-Width / 2 + num6) + Outwards * surfaceHeight2, 0f);
                    mesh[num3 + 4].Position = new Vector3(Position + vector * (-Width / 2 + num6), 0f);
                    mesh[num3 + 5].Position = new Vector3(Position + vector * (-Width / 2 + num5), 0f);
                    mesh[num4].Position =
                        new Vector3(Position + vector * (-Width / 2 + num5) + Outwards * (surfaceHeight + 1f), 0f);
                    mesh[num4 + 1].Position =
                        new Vector3(Position + vector * (-Width / 2 + num6) + Outwards * (surfaceHeight2 + 1f), 0f);
                    mesh[num4 + 2].Position =
                        new Vector3(Position + vector * (-Width / 2 + num5) + Outwards * surfaceHeight, 0f);
                    mesh[num4 + 3].Position =
                        new Vector3(Position + vector * (-Width / 2 + num6) + Outwards * (surfaceHeight2 + 1f), 0f);
                    mesh[num4 + 4].Position =
                        new Vector3(Position + vector * (-Width / 2 + num6) + Outwards * surfaceHeight2, 0f);
                    mesh[num4 + 5].Position =
                        new Vector3(Position + vector * (-Width / 2 + num5) + Outwards * surfaceHeight, 0f);
                    num2 += 4;
                    num3 += 6;
                    num4 += 6;
                }

                Vector2 vector2 = Position + vector * ((float)(-Width) / 2f);
                int num7 = rayStartIndex;
                foreach (Ray ray in Rays)
                {
                    if (ray.Percent > 1f)
                    {
                        ray.Reset(0f);
                    }

                    ray.Percent += engine.DeltaTime / ray.Duration;
                    float num8 = 1f;
                    if (ray.Percent < 0.1f)
                    {
                        num8 = ScalarMath.ClampedMap(ray.Percent, 0f, 0.1f);
                    }
                    else if (ray.Percent > 0.9f)
                    {
                        num8 = ScalarMath.ClampedMap(ray.Percent, 0.9f, 1f, 1f, 0f);
                    }

                    float num9 =
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(0f, ray.Position - ray.Width / 2f);
                    float num10 =
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(Width, ray.Position + ray.Width / 2f);
                    float num11 =
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(BodyHeight, 0.7f * ray.Length);
                    float num12 = 0.3f * ray.Length;
                    Vector2 value = vector2 + vector * num9 + Outwards * GetSurfaceHeight(num9);
                    Vector2 value2 = vector2 + vector * num10 + Outwards * GetSurfaceHeight(num10);
                    Vector2 value3 = vector2 + vector * (num10 - num12) - Outwards * num11;
                    Vector2 value4 = vector2 + vector * (num9 - num12) - Outwards * num11;
                    mesh[num7].Position = new Vector3(value, 0f);
                    mesh[num7].Color = Statics.RayTopColor * num8;
                    mesh[num7 + 1].Position = new Vector3(value2, 0f);
                    mesh[num7 + 1].Color = Statics.RayTopColor * num8;
                    mesh[num7 + 2].Position = new Vector3(value4, 0f);
                    mesh[num7 + 3].Position = new Vector3(value2, 0f);
                    mesh[num7 + 3].Color = Statics.RayTopColor * num8;
                    mesh[num7 + 4].Position = new Vector3(value3, 0f);
                    mesh[num7 + 5].Position = new Vector3(value4, 0f);
                    num7 += 6;
                }
            }

            public float GetSurfaceHeight(Vector2 position)
            {
                return GetSurfaceHeight(GetPointAlong(position));
            }

            public float GetSurfaceHeight(float position)
            {
                if (position < 0f || position > (float)Width)
                {
                    return 0f;
                }

                float num = 0f;
                foreach (Ripple ripple in Ripples)
                {
                    float num2 = Math.Abs(ripple.Position - position);
                    float num3 = 0f;
                    num3 = ((!(num2 < 12f))
                        ? ScalarMath.ClampedMap(num2, 16f, 32f, -0.75f, 0f)
                        : ScalarMath.ClampedMap(num2, 0f, 16f, 1f, -0.75f));
                    num += num3 * ripple.Height *
                           ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(1f - ripple.Percent);
                }

                num = ScalarMath.Clamp(num, -4f, 4f);
                foreach (Tension tension in Tensions)
                {
                    float t = ScalarMath.ClampedMap(Math.Abs(tension.Position - position), 0f, 24f, 1f, 0f);
                    num += ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(t) * tension.Strength * 12f;
                }

                float val = position / (float)Width;
                num *= ScalarMath.ClampedMap(val, 0f, 0.1f, 0.5f);
                num *= ScalarMath.ClampedMap(val, 0.9f, 1f, 1f, 0.5f);
                num += (float)Math.Sin(timer + position * 0.1f);
                return num + 6f;
            }

            public void Render(CameraState camera)
            {
                SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    camera.Matrix, mesh, mesh.Length);
            }
        }

        protected readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;
        private IOriginalWaterStatics Statics => ((IOriginalWaterStaticsEnvironment)engine).WaterStatics;

        protected virtual Color FillColor => Statics.FillColor;

        public Surface TopSurface;

        ISourceWaterSurface ISourceWater.TopSurface => TopSurface;

        public Surface BottomSurface;

        public List<Surface> Surfaces = new List<Surface>();

        protected Rectangle fill;

        private bool[,] grid;

        protected Tension playerBottomTension;

        protected HashSet<WaterInteraction> contains = new HashSet<WaterInteraction>();

        public OriginalWaterState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : this(engine, data.Position + offset, topSurface: true,
                EntityAttributeReader.Bool(data.Values, "hasBottom"), data.Width, data.Height)
        {
        }

        public OriginalWaterState(ISourceEngineContext engine, Vector2 position, bool topSurface, bool bottomSurface,
            float width, float height)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            base.Depth = -9999;
            base.Collider = new HitboxColliderGeometry(width, height);
            grid = new bool[(int)(width / 8f), (int)(height / 8f)];
            fill = new Rectangle(0, 0, (int)width, (int)height);
            int num = 8;
            if (topSurface)
            {
                TopSurface = new Surface(engine, Position + new Vector2(width / 2f, num), new Vector2(0f, -1f), width,
                    height);
                Surfaces.Add(TopSurface);
                fill.Y += num;
                fill.Height -= num;
            }

            if (bottomSurface)
            {
                BottomSurface = new Surface(engine, Position + new Vector2(width / 2f, height - (float)num),
                    new Vector2(0f, 1f), width, height);
                Surfaces.Add(BottomSurface);
                fill.Height -= num;
            }

            OwnedComponents.Add(new DisplacementRenderHookState(RenderDisplacement));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            int i = 0;
            for (int length = grid.GetLength(0); i < length; i++)
            {
                int j = 0;
                for (int length2 = grid.GetLength(1); j < length2; j++)
                {
                    grid[i, j] = !SolidAt(new Rectangle((int)base.X + i * 8, (int)base.Y + j * 8, 8, 8));
                }
            }
        }

        public override void Update()
        {
            UpdateComponentsAndSurfaces();
            foreach (WaterInteraction component in ((ISourceScene)Scene).SourceScene.Components.GetTrackedComponents(
                         "Celeste.WaterInteraction"))
            {
                var entity = (ISourceEntityCollider)component.Entity;
                bool flag = contains.Contains(component);
                bool flag2 = SourceEntityCollision.Check(this, entity);
                if (flag != flag2)
                {
                    if (((ISourceEntityCenter)entity).Center.Y <= base.Center.Y && TopSurface != null)
                    {
                        TopSurface.DoRipple(((ISourceEntityCenter)entity).Center, 1f);
                    }
                    else if (((ISourceEntityCenter)entity).Center.Y > base.Center.Y && BottomSurface != null)
                    {
                        BottomSurface.DoRipple(((ISourceEntityCenter)entity).Center, 1f);
                    }

                    bool flag3 = component.IsDashing();
                    int num = ((((ISourceEntityCenter)entity).Center.Y < base.Center.Y && !SolidAt(
                        new Rectangle((int)((ISourceEntityCenter)entity).Center.X - 4,
                            (int)((ISourceEntityCenter)entity).Center.Y, 8, 16)))
                        ? 1
                        : 0);
                    if (flag)
                    {
                        if (flag3)
                        {
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_dash_out",
                                ((ISourceEntityCenter)entity).Center, ((IOriginalGameplayProcess)engine).SaveContext,
                                "deep", num);
                        }
                        else
                        {
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_out",
                                ((ISourceEntityCenter)entity).Center, ((IOriginalGameplayProcess)engine).SaveContext,
                                "deep", num);
                        }

                        component.DrippingTimer = 2f;
                    }
                    else
                    {
                        if (flag3 && num == 1)
                        {
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_dash_in",
                                ((ISourceEntityCenter)entity).Center, ((IOriginalGameplayProcess)engine).SaveContext,
                                "deep", num);
                        }
                        else
                        {
                            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/water_in",
                                ((ISourceEntityCenter)entity).Center, ((IOriginalGameplayProcess)engine).SaveContext,
                                "deep", num);
                        }

                        component.DrippingTimer = 0f;
                    }

                    if (flag)
                    {
                        contains.Remove(component);
                    }
                    else
                    {
                        contains.Add(component);
                    }
                }

                if (BottomSurface == null || !(component.Entity is RoomPlayerSession))
                {
                    continue;
                }

                if (flag2 && entity.Position.Y > base.Bottom - 8f)
                {
                    if (playerBottomTension == null)
                    {
                        playerBottomTension = BottomSurface.SetTension(entity.Position, 0f);
                    }

                    playerBottomTension.Position = BottomSurface.GetPointAlong(entity.Position);
                    playerBottomTension.Strength =
                        ScalarMath.ClampedMap(entity.Position.Y, base.Bottom - 8f, base.Bottom + 4f);
                }
                else if (playerBottomTension != null)
                {
                    BottomSurface.RemoveTension(playerBottomTension);
                    playerBottomTension = null;
                }
            }
        }

        public void RenderDisplacement()
        {
            WaterDisplacementGridDrawing.Draw(((ISourceRenderEnvironment)engine).CurrentContext, this, grid, X, Y,
                new Color(0.5f, 0.5f, 0.25f, 1f));
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, base.X + (float)fill.X, base.Y + (float)fill.Y, fill.Width,
                fill.Height, FillColor);
            GameplayRendererState.End(context);
            foreach (Surface surface in Surfaces)
            {
                surface.Render((Scene as Level).Camera);
            }

            GameplayRendererState.Begin(context);
        }

        protected void UpdateComponentsAndSurfaces()
        {
            base.Update();
            foreach (Surface surface in Surfaces) surface.Update();
        }

        protected bool SolidAt(Rectangle rectangle)
            => SourceSceneCollision.CheckRect(((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", rectangle);
    }
}
