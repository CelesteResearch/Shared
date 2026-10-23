using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Maps.Grids;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Settings.Lightning;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public partial class TiledLightningRendererState<TBlock> : SceneEntityState
        where TBlock : LightningHazardState
    {
        public class Edge
        {
            public TBlock Parent;
            public bool Visible = true;
            public Vector2 A, B, Min, Max;

            public Edge(TBlock parent, Vector2 a, Vector2 b)
            {
                Parent = parent;
                A = a;
                B = b;
                Min = new(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y));
                Max = new(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y));
            }

            public virtual bool InView(IntRect view)
            {
                return view.Left < Parent.X + Max.X && view.Right > Parent.X + Min.X &&
                       view.Top < Parent.Y + Max.Y && view.Bottom > Parent.Y + Min.Y;
            }
        }

        public class Bolt
        {
            private readonly TiledLightningRendererState<TBlock> owner;
            public readonly List<Vector2> Nodes = [];
            public readonly SimulationCoroutine Routine;
            public bool Visible;
            public float Size, Gap, Alpha, Flash;
            public uint Seed;
            public PackedColor Color;
            public readonly float Scale;
            public readonly int Width, Height;

            public Bolt(TiledLightningRendererState<TBlock> owner,
                PackedColor color, float scale, int width, int height)
            {
                this.owner = owner;
                Color = color;
                Width = width;
                Height = height;
                Scale = scale;
                Routine = new(owner.engine, Run());
            }

            private float Range(float min, float max)
            {
                return min + (float)owner.random.NextDouble() * (max - min);
            }

            private IEnumerator Run()
            {
                yield return Range(0, 4);
                while (true)
                {
                    var border = new List<Vector2>();
                    for (var i = 0; i < 3; i++)
                    {
                        var choices = new[]
                        {
                            new Vector2(0, owner.random.Next(8, Height - 16)),
                            new Vector2(owner.random.Next(8, Width - 16), 0),
                            new Vector2(Width, owner.random.Next(8, Height - 16)),
                            new Vector2(owner.random.Next(8, Width - 16), Height),
                        };
                        var a = choices[owner.random.Next(choices.Length)];
                        var b = a.X <= 0 || a.X >= Width
                            ? new Vector2(Width - a.X, a.Y)
                            : new Vector2(a.X, Height - a.Y);
                        border.Add(a);
                        border.Add(b);
                    }

                    var inner = new List<Vector2>();
                    for (var i = 0; i < 3; i++)
                        inner.Add(new(Range(.25f, .75f) * Width, Range(.25f, .75f) * Height));
                    Nodes.Clear();
                    foreach (var p in border)
                    {
                        Nodes.Add(p);
                        var nearest = inner[0];
                        var distance = ((ISourceVectorEnvironment)owner.engine)
                            .VectorArithmetic.DistanceSquared(nearest, p);
                        for (var i = 1; i < inner.Count; i++)
                        {
                            var d = ((ISourceVectorEnvironment)owner.engine).VectorArithmetic
                                .DistanceSquared(inner[i], p);
                            if (d < distance)
                            {
                                distance = d;
                                nearest = inner[i];
                            }
                        }

                        Nodes.Add(nearest);
                    }

                    var previous = inner[inner.Count - 1];
                    foreach (var p in inner)
                    {
                        Nodes.Add(previous);
                        Nodes.Add(p);
                        previous = p;
                    }

                    Flash = 1;
                    Visible = true;
                    Size = 5;
                    Gap = 0;
                    Alpha = 1;
                    for (var i = 0; i < 4; i++)
                    {
                        Seed = (uint)owner.random.Next();
                        yield return .1f;
                    }

                    for (var i = 0; i < 5; i++)
                    {
                        if (owner.AllowBoltFlash) Visible = false;
                        yield return .05f + i * .02f;
                        var p = (float)i / 5;
                        Visible = true;
                        Size = (1 - p) * 5;
                        Gap = p;
                        Alpha = 1 - p;
                        Visible = true;
                        Seed = (uint)owner.random.Next();
                        yield return .025f;
                    }

                    Visible = false;
                    yield return Range(4, 8);
                }
            }

            public virtual void Update()
            {
                Routine.Update();
                Flash = ScalarMath.Approach(Flash, 0, owner.engine.DeltaTime * 2,
                    ((ISourceExtremaEnvironment)owner.engine).ExtremaArithmetic);
            }

            public virtual void Render(ISourceRenderContext context)
            {
                if (Flash > 0 && owner.AllowBoltFlash)
                    SourcePrimitiveDrawing.Rect(context, owner, 0, 0, Width, Height,
                        owner.BoltFlashColor * Flash * owner.BoltFlashOpacity * Scale);
                if (Visible)
                    for (var i = 0; i < Nodes.Count; i += 2)
                        DrawFatLightning(context, owner, Seed, Nodes[i], Nodes[i + 1], Size * Scale, Gap,
                            Color * Alpha,
                            ((ISourceVectorEnvironment)owner.engine).VectorArithmetic);
            }
        }

        protected virtual bool AllowBoltFlash => FlashPolicy.AllowLightning;
        protected virtual PackedColor BoltFlashColor => PackedColor.White;
        protected virtual float BoltFlashOpacity => .15f;
        protected virtual float EdgeFadeAmount => Fade;

        protected virtual PackedColor BufferClearColor =>
            PackedColor.Lerp(new PackedColor(247, 178, 98, 255) * .1f, PackedColor.White, Fade);

        protected virtual VirtualRenderTarget LightningBuffer =>
            ((ISourceLightningBufferScene)Scene).LightningBuffer;

        private readonly ISourceRenderEnvironment environment;

        private ISourceLightningFlashPolicy FlashPolicy =>
            ((ISourceLightningFlashEnvironment)engine).LightningFlashPolicy;

        protected readonly ISourceEngineContext engine;

        private ISourceRandom random =>
            ((ISourceRandomEnvironment)engine).Random;

        private readonly PackedColor[] electricityColorsLerped;
        private readonly List<TBlock> list = [];
        private readonly List<Edge> edges = [];
        private readonly List<Bolt> bolts = [];
        private SourceVertexPositionColor[] edgeVerts;

        private VirtualMap<bool> tiles;
        private IntRect levelTileBounds;

        private uint edgeSeed;

        private uint leapSeed;

        private bool dirty;

        protected PackedColor[] electricityColors =
                [new(252, 245, 121, 255), new(140, 247, 226, 255)];

        public IReadOnlyList<TBlock> Blocks => list;
        public IReadOnlyList<Edge> Edges => edges;
        public IReadOnlyList<Bolt> Bolts => bolts;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public VirtualMap<bool> Tiles => tiles;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public uint EdgeSeed => edgeSeed;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public uint LeapSeed => leapSeed;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public bool Dirty => dirty;
        public int VertexCapacity => edgeVerts?.Length ?? 0;
        public const int BoltBufferSize = 160;
        public float Fade;
        public bool UpdateSeeds = true, DrawEdges = true;
        public SoundSourceComponentState AmbientSfx;

        protected TiledLightningRendererState(ISourceEngineContext engine,
            ISourceRenderEnvironment environment,
            ISourceSoundSourceFactory sounds, bool renderBloom = true)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.environment = environment;
            this.engine = engine;
            Tags = ((ISourceGlobalFrozenExecutionTagsEnvironment)engine)
                   .GlobalFrozenExecutionTags.Global.Value |
                   ((ISourcePersistentTransitionExecutionTagsEnvironment)engine)
                   .PersistentTransitionExecutionTags.TransitionUpdate.Value;
            Depth = -1000100;
            electricityColorsLerped = new PackedColor[electricityColors.Length];
            if (renderBloom)
                OwnedComponents.Add(
                    new CustomBloomCallbackComponentState(OnRenderBloom));
            OwnedComponents.Add(
                new BeforeRenderCallbackComponentState(OnBeforeRender));
            AmbientSfx = sounds.Create();
            OwnedComponents.Add(AmbientSfx);
            AmbientSfx.DisposeOnTransition = false;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            for (var i = 0; i < 4; i++)
            {
                bolts.Add(CreateBolt(electricityColors[0], 1, 160, 160));
                bolts.Add(CreateBolt(electricityColors[1], .35f, 160, 160));
            }
        }

        protected virtual Bolt CreateBolt(PackedColor color, float scale, int width, int height)
        {
            return new(this, color, scale, width, height);
        }

        protected virtual Edge CreateEdge(TBlock parent, Vector2 a, Vector2 b)
        {
            return new(parent, a, b);
        }

        public void StartAmbience()
        {
            if (!AmbientSfx.Playing) AmbientSfx.Play("event:/new_content/env/10_electricity");
        }

        public void StopAmbience()
        {
            AmbientSfx.Stop();
        }

        public void Reset()
        {
            UpdateSeeds = true;
            Fade = 0;
        }

        public void Track(TBlock block)
        {
            list.Add(block);
            if (Tiles == null)
            {
                levelTileBounds = ((ISourceLevelTileBoundsScene)Scene).TileBounds;
                tiles = ((ISourceVirtualMapFactoryEnvironment)engine).VirtualMapFactory
                    .Create<bool>(levelTileBounds.Width, levelTileBounds.Height);
            }

            for (var i = (int)block.X / 8; i < ((int)block.X + block.VisualWidth) / 8; i++)
            for (var j = (int)block.Y / 8; j < ((int)block.Y + block.VisualHeight) / 8; j++)
                Tiles[i - levelTileBounds.X, j - levelTileBounds.Y] = true;
            dirty = true;
        }

        public void Untrack(TBlock block)
        {
            list.Remove(block);
            if (list.Count <= 0) tiles = null;
            else
                for (var i = (int)block.X / 8; i < block.Right / 8; i++)
                for (var j = (int)block.Y / 8; j < block.Bottom / 8; j++)
                    Tiles[i - levelTileBounds.X, j - levelTileBounds.Y] = false;
            dirty = true;
        }

        public override void Update()
        {
            if (Dirty) RebuildEdges();
            ToggleEdges();
            if (list.Count <= 0) return;
            foreach (var bolt in bolts) bolt.Update();
            if (UpdateSeeds)
            {
                if (OnInterval(.1f)) edgeSeed = (uint)random.Next();
                if (OnInterval(.7f)) leapSeed = (uint)random.Next();
            }
        }

        public void ToggleEdges(bool immediate = false)
        {
            var c = ((ISourceCameraScene)Scene).Camera;
            var view = new IntRect((int)c.Left - 4, (int)c.Top - 4, (int)(c.Right - c.Left) + 8,
                (int)(c.Bottom - c.Top) + 8);
            for (var i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                if (immediate) edge.Visible = edge.InView(view);
                else if (!edge.Visible && OnInterval(.05f, i * .01f) && edge.InView(view)) edge.Visible = true;
                else if (edge.Visible && OnInterval(.25f, i * .01f) && !edge.InView(view)) edge.Visible = false;
            }
        }

        private bool Inside(int x, int y)
        {
            return Tiles[x - levelTileBounds.X, y - levelTileBounds.Y];
        }

        public void RebuildEdges()
        {
            dirty = false;
            edges.Clear();
            if (list.Count <= 0) return;
            var level = (ISourceLevelTileBoundsScene)Scene;
            _ = level.TileBounds.Left;
            _ = level.TileBounds.Top;
            _ = level.TileBounds.Right;
            _ = level.TileBounds.Bottom;
            var directions = new[] { (X: 0, Y: -1), (X: 0, Y: 1), (X: -1, Y: 0), (X: 1, Y: 0) };
            foreach (var block in list)
                for (var x = (int)block.X / 8; x < block.Right / 8; x++)
                for (var y = (int)block.Y / 8; y < block.Bottom / 8; y++)
                    foreach (var point in directions)
                    {
                        var tangent = (X: -point.Y, Y: point.X);
                        if (Inside(x + point.X, y + point.Y) || (Inside(x - tangent.X, y - tangent.Y) &&
                                                                 !Inside(x + point.X - tangent.X,
                                                                     y + point.Y - tangent.Y))) continue;
                        var first = (X: x, Y: y);
                        var last = (X: x + tangent.X, Y: y + tangent.Y);
                        var offset = new Vector2(4) + new Vector2(point.X - tangent.X, point.Y - tangent.Y) * 4;
                        var count = 1;
                        while (Inside(last.X, last.Y) && !Inside(last.X + point.X, last.Y + point.Y))
                        {
                            last.X += tangent.X;
                            last.Y += tangent.Y;
                            count++;
                            if (count > 8)
                            {
                                edges.Add(new(block, new Vector2(first.X, first.Y) * 8 + offset - block.Position,
                                    new Vector2(last.X, last.Y) * 8 + offset - block.Position));
                                count = 0;
                                first = last;
                            }
                        }

                        if (count > 0)
                            edges.Add(new(block, new Vector2(first.X, first.Y) * 8 + offset - block.Position,
                                new Vector2(last.X, last.Y) * 8 + offset - block.Position));
                    }

            if (edgeVerts == null)
                edgeVerts = new SourceVertexPositionColor[1024];
        }

        private bool OnInterval(float interval, float offset = 0f)
        {
            return ((ISourceScene)Scene).SourceScene.Clock.OnInterval(interval, offset, engine);
        }

        private void OnRenderBloom()
        {
            var context = environment.CurrentContext;
            var camera = ((ISourceCameraScene)Scene).Camera;
            var discardedView = new IntRect((int)camera.Left, (int)camera.Top,
                (int)(camera.Right - camera.Left), (int)(camera.Bottom - camera.Top));
            var color = PackedColor.White * (.25f + Fade * .75f);
            foreach (var edge in edges)
                if (edge.Visible)
                    SourcePrimitiveDrawing.Line(context, this,
                        edge.Parent.Position + edge.A, edge.Parent.Position + edge.B, color, 4,
                        ((ISourceVectorEnvironment)engine).VectorArithmetic);
            foreach (var block in list)
                if (block.Visible)
                    SourcePrimitiveDrawing.Rect(context, this,
                        block.Position.X, block.Position.Y, block.VisualWidth, block.VisualHeight, color);
            if (Fade > 0)
                SourcePrimitiveDrawing.Rect(context, this,
                    camera.Position.X, camera.Position.Y, 320, 180,
                    PackedColor.White * Fade);
        }

        private void OnBeforeRender()
        {
            if (list.Count <= 0) return;
            var context = environment.CurrentContext;
            var device = ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice;
            device.SetRenderTarget(LightningBuffer.Target);
            device.Clear(BufferClearColor);
            var batch = ((ISourceDrawScope)context).Draw.SpriteBatch;
            batch.Begin();
            foreach (var bolt in bolts) bolt.Render(context);
            batch.End();
        }

        protected virtual bool ShouldRenderBlock(TBlock block)
        {
            return block.Visible;
        }

        protected virtual bool ShouldRenderEdges()
        {
            return DrawEdges;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (list.Count <= 0) return;
            var camera = ((ISourceCameraScene)Scene).Camera;
            var discardedView = new IntRect((int)camera.Left, (int)camera.Top,
                (int)(camera.Right - camera.Left), (int)(camera.Bottom - camera.Top));
            foreach (var block in list)
                if (ShouldRenderBlock(block))
                    ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(
                        LightningBuffer.Target, block.Position,
                        new IntRect((int)block.X, (int)block.Y, block.VisualWidth, block.VisualHeight),
                        PackedColor.White.PackedValue);

            if (edges.Count <= 0 || !ShouldRenderEdges()) return;
            for (var i = 0; i < electricityColorsLerped.Length; i++)
                electricityColorsLerped[i] = PackedColor.Lerp(electricityColors[i], PackedColor.White, EdgeFadeAmount);
            var index = 0;
            var seed = LeapSeed;
            foreach (var edge in edges)
                if (edge.Visible)
                {
                    DrawSimpleLightning(ref index, ref edgeVerts, EdgeSeed, edge.Parent.Position, edge.A, edge.B,
                        electricityColorsLerped[0],
                        ((ISourceVectorEnvironment)engine).VectorArithmetic, 1 + Fade * 3);
                    DrawSimpleLightning(ref index, ref edgeVerts, EdgeSeed + 1, edge.Parent.Position, edge.A, edge.B,
                        electricityColorsLerped[1],
                        ((ISourceVectorEnvironment)engine).VectorArithmetic, 1 + Fade * 3);
                    if (PseudoRand(ref seed) % 30 == 0)
                        DrawBezierLightning(ref index, ref edgeVerts, EdgeSeed, edge.Parent.Position, edge.A, edge.B,
                            24, 10, electricityColorsLerped[1],
                            ((ISourceCurveEnvironment)
                                ((ISourceEngineContextScene)Scene).EngineContext)
                            .CurveArithmetic,
                            ((ISourceVectorEnvironment)engine).VectorArithmetic);
                }

            if (index > 0)
            {
                ((ISourceGameplayBatchScopeEnvironment)engine).GameplayBatchScope
                    .End(context);
                SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    camera.Matrix, edgeVerts, index);
                ((ISourceGameplayBatchScopeEnvironment)engine).GameplayBatchScope
                    .Begin(context);
            }
        }

        private static int OriginalHash(Vector2 v)
        {
            return unchecked(v.X.GetHashCode() + v.Y.GetHashCode());
        }
    }
}
