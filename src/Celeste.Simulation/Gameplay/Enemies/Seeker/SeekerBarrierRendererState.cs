using System;
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
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Barriers;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public class SeekerBarrierRendererState : SceneEntityState
    {
        public sealed class Edge
        {
            public SeekerBarrierState Parent;
            public bool Visible;
            public Vector2 A, B, Min, Max, Normal, Perpendicular;
            public float[] Wave;
            public float Length;

            private readonly ISourceEngineContext engine;

            public Edge(SeekerBarrierState parent, Vector2 a, Vector2 b, ISourceEngineContext engine)
            {
                this.engine = engine;
                Parent = parent;
                Visible = true;
                A = a;
                B = b;
                Min = new(((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(a.X, b.X),
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(a.Y, b.Y));
                Max = new(((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(a.X, b.X),
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(a.Y, b.Y));
                Normal = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(b - a);
                Perpendicular = new(Normal.Y, -Normal.X);
                Length = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(a - b);
            }

            public void UpdateWave(float time)
            {
                if (Wave == null || Wave.Length <= Length) Wave = new float[(int)Length + 2];
                for (var i = 0; i <= Length; i++) Wave[i] = GetWaveAt(time, i, Length);
            }

            private float GetWaveAt(float offset, float along, float length)
            {
                if (along <= 1f || along >= length - 1f) return 0f;
                if (Parent.Solidify >= 1f) return 0f;
                return BarrierTileGeometry.Wave(offset, along, length, Parent.Solidify, engine);
            }

            public bool InView(ref IntRect view)
            {
                return view.Left < Parent.Position.X + Max.X && view.Right > Parent.Position.X + Min.X
                                                             && view.Top < Parent.Position.Y + Max.Y &&
                                                             view.Bottom > Parent.Position.Y + Min.Y;
            }
        }

        private readonly List<SeekerBarrierState> list = [];
        private readonly List<Edge> edges = [];
        private readonly Action<SeekerBarrierState, Vector2, Vector2> addEdge;
        private VirtualMap<bool> tiles;
        private IntRect levelTileBounds;

        private bool dirty;
        private readonly PackedColor tint;
        private readonly float surfaceOpacity;
        private readonly float flashOpacity;
        private readonly ISourceRenderEnvironment environment;
        public ISourceEngineContext BarrierEngineContext { get; }

        public virtual PackedColor BarrierColor()
        {
            return tint;
        }

        public virtual float BarrierTransparency()
        {
            return surfaceOpacity;
        }

        public IReadOnlyList<SeekerBarrierState> Blocks => list;
        public IReadOnlyList<Edge> Edges => edges;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public bool Dirty => dirty;
        public IntRect LevelTileBounds => levelTileBounds;

        public SeekerBarrierRendererState(ISourceEngineContext engine, ISourceRenderEnvironment environment)
            : this(engine, environment, PackedColor.White, .15f, .25f)
        {
        }

        protected SeekerBarrierRendererState(ISourceEngineContext engine, ISourceRenderEnvironment environment,
            PackedColor tint, float surfaceOpacity, float flashOpacity)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            addEdge = AddEdge;
            this.tint = tint;
            this.surfaceOpacity = surfaceOpacity;
            this.flashOpacity = flashOpacity;
            BarrierEngineContext = engine;
            this.environment = environment;
            Tags = ((ISourceGlobalFrozenExecutionTagsEnvironment)engine).GlobalFrozenExecutionTags.Global.Value
                   | ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                   .TransitionUpdate.Value;
            Depth = 0;
            var bloom = new CustomBloomCallbackComponentState(OnRenderBloom);
            OwnedComponents.Add(bloom);
        }

        public void Track(SeekerBarrierState block)
        {
            list.Add(block);
            if (tiles == null)
            {
                levelTileBounds = ((ISourceLevelTileBoundsScene)Scene).TileBounds;
                tiles = ((ISourceVirtualMapFactoryEnvironment)BarrierEngineContext).VirtualMapFactory
                    .Create<bool>(levelTileBounds.Width, levelTileBounds.Height);
            }

            WriteTiles(block, true);
            dirty = true;
        }

        public void Untrack(SeekerBarrierState block)
        {
            list.Remove(block);
            if (list.Count <= 0) tiles = null;
            else WriteTiles(block, false);
            dirty = true;
        }

        private void WriteTiles(SeekerBarrierState block, bool value)
        {
            BarrierTileGeometry.WriteTiles(block, tiles, levelTileBounds, value);
        }

        public override void Update()
        {
            if (Dirty) RebuildEdges();
            UpdateEdges();
        }

        public void UpdateEdges()
        {
            var camera = ((ISourceCameraScene)Scene).Camera;
            var view = new IntRect((int)camera.Left - 4, (int)camera.Top - 4,
                (int)(camera.Right - camera.Left) + 8, (int)(camera.Bottom - camera.Top) + 8);
            for (var i = 0; i < edges.Count; i++)
            {
                if (edges[i].Visible)
                {
                    if (OnInterval(.25f, i * .01f) && !edges[i].InView(ref view)) edges[i].Visible = false;
                }
                else if (OnInterval(.05f, i * .01f) && edges[i].InView(ref view))
                {
                    edges[i].Visible = true;
                }

                if (edges[i].Visible && (OnInterval(.05f, i * .01f) || edges[i].Wave == null))
                    edges[i].UpdateWave(((ISourceScene)Scene).SourceScene.Clock.TimeActive * 3f);
            }
        }

        private bool OnInterval(float interval, float offset)
        {
            return ((ISourceScene)Scene).SourceScene.Clock.OnInterval(interval, offset, BarrierEngineContext);
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
            BarrierTileGeometry.RebuildEdges(list, tiles, levelTileBounds, addEdge);
        }

        private void AddEdge(SeekerBarrierState block, Vector2 a, Vector2 b)
        {
            edges.Add(new(block, a, b, BarrierEngineContext));
        }

        private bool Inside(int x, int y)
        {
            return tiles[x - levelTileBounds.X, y - levelTileBounds.Y];
        }

        protected virtual Vector2 BloomSegmentEnd(Vector2 at, Vector2 perpendicular, float wave)
        {
            return at + perpendicular * wave;
        }

        public virtual void OnRenderBloom()
        {
            var context = environment.CurrentContext;
            var camera = ((ISourceCameraScene)Scene).Camera;
            _ = new IntRect((int)camera.Left, (int)camera.Top,
                (int)(camera.Right - camera.Left), (int)(camera.Bottom - camera.Top));
            foreach (var block in list)
                if (block.Visible)
                    SourcePrimitiveDrawing.Rect(context, this, block.Position.X, block.Position.Y, block.Width,
                        block.Height, BarrierColor());
            foreach (var edge in edges)
                if (edge.Visible)
                {
                    var start = edge.Parent.Position + edge.A;
                    _ = edge.Parent.Position + edge.B;
                    for (var i = 0; i <= edge.Length; i++)
                    {
                        var at = start + edge.Normal * i;
                        SourcePrimitiveDrawing.Line(context, this, at,
                            BloomSegmentEnd(at, edge.Perpendicular, edge.Wave[i]),
                            BarrierColor(), ((ISourceVectorEnvironment)BarrierEngineContext).VectorArithmetic);
                    }
                }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (list.Count <= 0) return;
            var color = BarrierColor() * BarrierTransparency();
            var value = tint * flashOpacity;
            foreach (var block in list)
                if (block.Visible)
                    SourcePrimitiveDrawing.Rect(context, this, block.Collider.AbsoluteLeft, block.Collider.AbsoluteTop,
                        block.Collider.Width, block.Collider.Height, color);
            if (edges.Count <= 0) return;
            foreach (var edge in edges)
                if (edge.Visible)
                {
                    var start = edge.Parent.Position + edge.A;
                    _ = edge.Parent.Position + edge.B;
                    _ = PackedColor.Lerp(value, tint, edge.Parent.Flash);
                    for (var i = 0; i <= edge.Length; i++)
                    {
                        var at = start + edge.Normal * i;
                        SourcePrimitiveDrawing.Line(context, this, at, at + edge.Perpendicular * edge.Wave[i], color,
                            ((ISourceVectorEnvironment)BarrierEngineContext).VectorArithmetic);
                    }
                }
        }
    }
}
