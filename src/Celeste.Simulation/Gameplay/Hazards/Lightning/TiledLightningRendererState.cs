using Celeste.Core.Display;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Core.Geometry;
using Celeste.Scene.Scheduling;
using Celeste.Core.Collections;
using Celeste.Physics.Collision;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public partial class TiledLightningRendererState<TBlock> : Celeste.Scene.Entities.SceneEntityState
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
                Min = new Vector2(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y));
                Max = new Vector2(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y));
            }

            public virtual bool InView(Celeste.Core.Geometry.IntRect view) =>
                view.Left < Parent.X + Max.X && view.Right > Parent.X + Min.X &&
                view.Top < Parent.Y + Max.Y && view.Bottom > Parent.Y + Min.Y;
        }

        public class Bolt
        {
            readonly TiledLightningRendererState<TBlock> owner;
            public readonly List<Vector2> Nodes = new List<Vector2>();
            public readonly global::Celeste.Core.Scheduling.SimulationCoroutine Routine;
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
                Routine = new global::Celeste.Core.Scheduling.SimulationCoroutine(owner.engine, Run());
            }

            float Range(float min, float max) => min + (float)owner.random.NextDouble() * (max - min);

            IEnumerator Run()
            {
                yield return Range(0, 4);
                while (true)
                {
                    var border = new List<Vector2>();
                    for (int i = 0; i < 3; i++)
                    {
                        var choices = new[]
                        {
                            new Vector2(0, owner.random.Next(8, Height - 16)),
                            new Vector2(owner.random.Next(8, Width - 16), 0),
                            new Vector2(Width, owner.random.Next(8, Height - 16)),
                            new Vector2(owner.random.Next(8, Width - 16), Height)
                        };
                        var a = choices[owner.random.Next(choices.Length)];
                        var b = a.X <= 0 || a.X >= Width
                            ? new Vector2(Width - a.X, a.Y)
                            : new Vector2(a.X, Height - a.Y);
                        border.Add(a);
                        border.Add(b);
                    }

                    var inner = new List<Vector2>();
                    for (int i = 0; i < 3; i++)
                        inner.Add(new Vector2(Range(.25f, .75f) * Width, Range(.25f, .75f) * Height));
                    Nodes.Clear();
                    foreach (var p in border)
                    {
                        Nodes.Add(p);
                        var nearest = inner[0];
                        float distance = ((Celeste.Core.Mathematics.ISourceVectorEnvironment)owner.engine)
                            .VectorArithmetic.DistanceSquared(nearest, p);
                        for (int i = 1; i < inner.Count; i++)
                        {
                            float d = ((Celeste.Core.Mathematics.ISourceVectorEnvironment)owner.engine).VectorArithmetic
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
                    for (int i = 0; i < 4; i++)
                    {
                        Seed = (uint)owner.random.Next();
                        yield return .1f;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        if (owner.AllowBoltFlash) Visible = false;
                        yield return .05f + i * .02f;
                        float p = (float)i / 5;
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
                Flash = global::Celeste.Core.Mathematics.ScalarMath.Approach(Flash, 0, owner.engine.DeltaTime * 2,
                    ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)owner.engine).ExtremaArithmetic);
            }

            public virtual void Render(Celeste.Core.Rendering.ISourceRenderContext context)
            {
                if (Flash > 0 && owner.AllowBoltFlash)
                    Celeste.Graphics.Rendering.SourcePrimitiveDrawing.Rect(context, owner, 0, 0, Width, Height,
                        owner.BoltFlashColor * Flash * owner.BoltFlashOpacity * Scale);
                if (Visible)
                    for (int i = 0; i < Nodes.Count; i += 2)
                        DrawFatLightning(context, owner, Seed, Nodes[i], Nodes[i + 1], Size * Scale, Gap,
                            Color * Alpha,
                            ((Celeste.Core.Mathematics.ISourceVectorEnvironment)owner.engine).VectorArithmetic);
            }
        }

        protected virtual bool AllowBoltFlash => FlashPolicy.AllowLightning;
        protected virtual PackedColor BoltFlashColor => PackedColor.White;
        protected virtual float BoltFlashOpacity => .15f;
        protected virtual float EdgeFadeAmount => Fade;

        protected virtual PackedColor BufferClearColor =>
            PackedColor.Lerp(new PackedColor(247, 178, 98, 255) * .1f, PackedColor.White, Fade);

        protected virtual Celeste.Graphics.Content.VirtualAssets.VirtualRenderTarget LightningBuffer =>
            ((ISourceLightningBufferScene)Scene).LightningBuffer;

        private readonly Celeste.Core.Rendering.ISourceRenderEnvironment environment;

        private Celeste.Core.Settings.Lightning.ISourceLightningFlashPolicy FlashPolicy =>
            ((Celeste.Core.Settings.Lightning.ISourceLightningFlashEnvironment)engine).LightningFlashPolicy;

        protected readonly Celeste.Core.Scheduling.ISourceEngineContext engine;

        private Celeste.Core.Randomness.ISourceRandom random =>
            ((Celeste.Core.Randomness.ISourceRandomEnvironment)engine).Random;

        private PackedColor[] electricityColorsLerped;
        List<TBlock> list = new List<TBlock>();
        List<Edge> edges = new List<Edge>();
        List<Bolt> bolts = new List<Bolt>();
        global::Celeste.Graphics.Rendering.Vertices.SourceVertexPositionColor[] edgeVerts;
        VirtualMap<bool> tiles;
        Celeste.Core.Geometry.IntRect levelTileBounds;
        uint edgeSeed, leapSeed;
        bool dirty;

        protected PackedColor[] electricityColors =
            { new PackedColor(252, 245, 121, 255), new PackedColor(140, 247, 226, 255) };

        public IReadOnlyList<TBlock> Blocks => list;
        public IReadOnlyList<Edge> Edges => edges;
        public IReadOnlyList<Bolt> Bolts => bolts;
        public VirtualMap<bool> Tiles => tiles;
        public uint EdgeSeed => edgeSeed;
        public uint LeapSeed => leapSeed;
        public bool Dirty => dirty;
        public int VertexCapacity => edgeVerts?.Length ?? 0;
        public const int BoltBufferSize = 160;
        public float Fade;
        public bool UpdateSeeds = true, DrawEdges = true;
        public Celeste.Simulation.Audio.Sources.SoundSourceComponentState AmbientSfx;

        protected TiledLightningRendererState(Celeste.Core.Scheduling.ISourceEngineContext engine,
            Celeste.Core.Rendering.ISourceRenderEnvironment environment,
            Celeste.Simulation.Audio.Sources.ISourceSoundSourceFactory sounds, bool renderBloom = true)
            : base(((Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.environment = environment;
            this.engine = engine;
            Tags = ((Celeste.Scene.Scheduling.ExecutionTags.ISourceGlobalFrozenExecutionTagsEnvironment)engine)
                   .GlobalFrozenExecutionTags.Global.Value |
                   ((Celeste.Scene.Scheduling.ExecutionTags.ISourcePersistentTransitionExecutionTagsEnvironment)engine)
                   .PersistentTransitionExecutionTags.TransitionUpdate.Value;
            Depth = -1000100;
            electricityColorsLerped = new PackedColor[electricityColors.Length];
            if (renderBloom)
                OwnedComponents.Add(
                    new Celeste.Core.Components.Rendering.CustomBloomCallbackComponentState(OnRenderBloom));
            OwnedComponents.Add(
                new Celeste.Core.Components.Rendering.BeforeRenderCallbackComponentState(OnBeforeRender));
            AmbientSfx = sounds.Create();
            OwnedComponents.Add(AmbientSfx);
            AmbientSfx.DisposeOnTransition = false;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            for (int i = 0; i < 4; i++)
            {
                bolts.Add(CreateBolt(electricityColors[0], 1, 160, 160));
                bolts.Add(CreateBolt(electricityColors[1], .35f, 160, 160));
            }
        }

        protected virtual Bolt CreateBolt(PackedColor color, float scale, int width, int height) =>
            new Bolt(this, color, scale, width, height);

        protected virtual Edge CreateEdge(TBlock parent, Vector2 a, Vector2 b) => new Edge(parent, a, b);

        public void StartAmbience()
        {
            if (!AmbientSfx.Playing) AmbientSfx.Play("event:/new_content/env/10_electricity");
        }

        public void StopAmbience() => AmbientSfx.Stop();

        public void Reset()
        {
            UpdateSeeds = true;
            Fade = 0;
        }

        public void Track(TBlock block)
        {
            list.Add(block);
            if (tiles == null)
            {
                levelTileBounds = ((ISourceLevelTileBoundsScene)Scene).TileBounds;
                tiles = ((Celeste.Core.Maps.Grids.ISourceVirtualMapFactoryEnvironment)engine).VirtualMapFactory
                    .Create<bool>(levelTileBounds.Width, levelTileBounds.Height, false);
            }

            for (int i = (int)block.X / 8; i < ((int)block.X + block.VisualWidth) / 8; i++)
            for (int j = (int)block.Y / 8; j < ((int)block.Y + block.VisualHeight) / 8; j++)
                tiles[i - levelTileBounds.X, j - levelTileBounds.Y] = true;
            dirty = true;
        }

        public void Untrack(TBlock block)
        {
            list.Remove(block);
            if (list.Count <= 0) tiles = null;
            else
                for (int i = (int)block.X / 8; i < block.Right / 8; i++)
                for (int j = (int)block.Y / 8; j < block.Bottom / 8; j++)
                    tiles[i - levelTileBounds.X, j - levelTileBounds.Y] = false;
            dirty = true;
        }

        public override void Update()
        {
            if (dirty) RebuildEdges();
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
            var c = ((Celeste.Graphics.Geometry.TwoD.Camera.ISourceCameraScene)Scene).Camera;
            var view = new Celeste.Core.Geometry.IntRect((int)c.Left - 4, (int)c.Top - 4, (int)(c.Right - c.Left) + 8,
                (int)(c.Bottom - c.Top) + 8);
            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                if (immediate) edge.Visible = edge.InView(view);
                else if (!edge.Visible && OnInterval(.05f, i * .01f) && edge.InView(view)) edge.Visible = true;
                else if (edge.Visible && OnInterval(.25f, i * .01f) && !edge.InView(view)) edge.Visible = false;
            }
        }

        bool Inside(int x, int y) => tiles[x - levelTileBounds.X, y - levelTileBounds.Y];

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
                for (int x = (int)block.X / 8; x < block.Right / 8; x++)
                for (int y = (int)block.Y / 8; y < block.Bottom / 8; y++)
                    foreach (var point in directions)
                    {
                        var tangent = (X: -point.Y, Y: point.X);
                        if (Inside(x + point.X, y + point.Y) || Inside(x - tangent.X, y - tangent.Y) &&
                            !Inside(x + point.X - tangent.X, y + point.Y - tangent.Y)) continue;
                        var first = (X: x, Y: y);
                        var last = (X: x + tangent.X, Y: y + tangent.Y);
                        var offset = new Vector2(4) + new Vector2(point.X - tangent.X, point.Y - tangent.Y) * 4;
                        int count = 1;
                        while (Inside(last.X, last.Y) && !Inside(last.X + point.X, last.Y + point.Y))
                        {
                            last.X += tangent.X;
                            last.Y += tangent.Y;
                            count++;
                            if (count > 8)
                            {
                                edges.Add(new Edge(block, new Vector2(first.X, first.Y) * 8 + offset - block.Position,
                                    new Vector2(last.X, last.Y) * 8 + offset - block.Position));
                                count = 0;
                                first = last;
                            }
                        }

                        if (count > 0)
                            edges.Add(new Edge(block, new Vector2(first.X, first.Y) * 8 + offset - block.Position,
                                new Vector2(last.X, last.Y) * 8 + offset - block.Position));
                    }

            if (edgeVerts == null)
                edgeVerts = new global::Celeste.Graphics.Rendering.Vertices.SourceVertexPositionColor[1024];
        }

        private bool OnInterval(float interval, float offset = 0f)
        {
            return ((Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Clock.OnInterval(interval, offset, engine);
        }

        private void OnRenderBloom()
        {
            var context = environment.CurrentContext;
            var camera = ((Celeste.Graphics.Geometry.TwoD.Camera.ISourceCameraScene)Scene).Camera;
            var discardedView = new Celeste.Core.Geometry.IntRect((int)camera.Left, (int)camera.Top,
                (int)(camera.Right - camera.Left), (int)(camera.Bottom - camera.Top));
            var color = PackedColor.White * (.25f + Fade * .75f);
            foreach (var edge in edges)
                if (edge.Visible)
                    Celeste.Graphics.Rendering.SourcePrimitiveDrawing.Line(context, this,
                        edge.Parent.Position + edge.A, edge.Parent.Position + edge.B, color, 4,
                        ((Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic);
            foreach (var block in list)
                if (block.Visible)
                    Celeste.Graphics.Rendering.SourcePrimitiveDrawing.Rect(context, this,
                        block.Position.X, block.Position.Y, block.VisualWidth, block.VisualHeight, color);
            if (Fade > 0)
                Celeste.Graphics.Rendering.SourcePrimitiveDrawing.Rect(context, this,
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

        protected virtual bool ShouldRenderBlock(TBlock block) => block.Visible;
        protected virtual bool ShouldRenderEdges() => DrawEdges;

        public override void Render(Celeste.Core.Rendering.ISourceRenderContext context)
        {
            if (list.Count <= 0) return;
            var camera = ((Celeste.Graphics.Geometry.TwoD.Camera.ISourceCameraScene)Scene).Camera;
            var discardedView = new Celeste.Core.Geometry.IntRect((int)camera.Left, (int)camera.Top,
                (int)(camera.Right - camera.Left), (int)(camera.Bottom - camera.Top));
            foreach (var block in list)
                if (ShouldRenderBlock(block))
                {
                    ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(
                        LightningBuffer.Target, block.Position,
                        new IntRect((int)block.X, (int)block.Y, block.VisualWidth, block.VisualHeight),
                        PackedColor.White.PackedValue);
                }

            if (edges.Count <= 0 || !ShouldRenderEdges()) return;
            for (int i = 0; i < electricityColorsLerped.Length; i++)
                electricityColorsLerped[i] = PackedColor.Lerp(electricityColors[i], PackedColor.White, EdgeFadeAmount);
            int index = 0;
            uint seed = leapSeed;
            foreach (var edge in edges)
                if (edge.Visible)
                {
                    DrawSimpleLightning(ref index, ref edgeVerts, edgeSeed, edge.Parent.Position, edge.A, edge.B,
                        electricityColorsLerped[0],
                        ((Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic, 1 + Fade * 3);
                    DrawSimpleLightning(ref index, ref edgeVerts, edgeSeed + 1, edge.Parent.Position, edge.A, edge.B,
                        electricityColorsLerped[1],
                        ((Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic, 1 + Fade * 3);
                    if (PseudoRand(ref seed) % 30 == 0)
                        DrawBezierLightning(ref index, ref edgeVerts, edgeSeed, edge.Parent.Position, edge.A, edge.B,
                            24, 10, electricityColorsLerped[1],
                            ((Celeste.Core.Mathematics.ISourceCurveEnvironment)
                                ((Celeste.Core.Scheduling.ISourceEngineContextScene)Scene).EngineContext)
                            .CurveArithmetic,
                            ((Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic);
                }

            if (index > 0)
            {
                ((Celeste.Graphics.Rendering.ISourceGameplayBatchScopeEnvironment)engine).GameplayBatchScope
                    .End(context);
                SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    camera.Matrix, edgeVerts, index);
                ((Celeste.Graphics.Rendering.ISourceGameplayBatchScopeEnvironment)engine).GameplayBatchScope
                    .Begin(context);
            }
        }

        static int OriginalHash(Vector2 v) => unchecked(v.X.GetHashCode() + v.Y.GetHashCode());
    }
}
