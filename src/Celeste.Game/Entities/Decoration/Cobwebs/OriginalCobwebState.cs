using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Decoration.Cobwebs
{
    public class OriginalCobwebState : SceneEntityState
    {
        protected readonly ISourceEngineContext Engine;
        private PackedColor color;
        private PackedColor edge;
        private readonly Vector2 anchorA;
        private readonly Vector2 anchorB;
        private readonly List<Vector2> offshoots;
        private readonly List<float> offshootEndings;
        private float waveTimer;

        public OriginalCobwebState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            Engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Depth = -1;
            anchorA = Position = data.Position + offset;
            anchorB = data.Nodes[0] + offset;
            foreach (var node in data.Nodes)
                if (offshoots == null)
                {
                    offshoots = [];
                    offshootEndings = [];
                }
                else
                {
                    offshoots.Add(node + offset);
                    offshootEndings.Add(
                        .3f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)Engine).Random, .4f));
                }

            waveTimer = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)Engine).Random);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var level = (OriginalLevelSceneRoot)scene;
            var colors = level.AreaData.CobwebColor;
            color = colors[((ISourceRandomEnvironment)Engine).Random.Next(colors.Length)];
            edge = SourceColorInterpolation.Lerp(color, new(15, 14, 23), .2f,
                ((ISourceScalarEnvironment)Engine).ScalarArithmetic);
            if (!CollidesSolid(level,
                    new(unchecked((int)anchorA.X - 2), unchecked((int)anchorA.Y - 2), 4, 4)) ||
                !CollidesSolid(level, new(unchecked((int)anchorB.X - 2), unchecked((int)anchorB.Y - 2), 4, 4)))
                RemoveSelf();
            for (var i = 0; i < offshoots.Count; i++)
            {
                var point = offshoots[i];
                if (!CollidesSolid(level, new(unchecked((int)point.X - 2), unchecked((int)point.Y - 2), 4, 4)))
                {
                    offshoots.RemoveAt(i);
                    offshootEndings.RemoveAt(i);
                    i--;
                }
            }
        }

        private static bool CollidesSolid(OriginalLevelSceneRoot level, IntRect rectangle)
        {
            foreach (var item in level.Scheduler.Entities.GetTrackedEntities("Celeste.Solid"))
            {
                var solid = (SceneEntityState)item;
                if (solid.Collidable && solid.Collider != null && solid.Collider.Collide(rectangle)) return true;
            }

            return false;
        }

        public override void Update()
        {
            waveTimer += Engine.DeltaTime;
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            DrawCobweb(context, anchorA, anchorB, 12, true);
        }

        protected virtual bool ShouldDrawCurve(SimpleCurve curve)
        {
            return true;
        }

        private void DrawCobweb(ISourceRenderContext context, Vector2 a, Vector2 b, int steps, bool drawOffshoots)
        {
            var vectors = ((ISourceVectorEnvironment)Engine).VectorArithmetic;
            var curves = ((ISourceCurveEnvironment)Engine).CurveArithmetic;
            var curve = new SimpleCurve(a, b,
                vectors.Divide(a + b, 2f) + Vector2.UnitY * (8f + (float)Math.Sin(waveTimer) * 4f));
            if (drawOffshoots && offshoots != null)
                for (var i = 0; i < offshoots.Count; i++)
                    DrawCobweb(context, offshoots[i], curves.GetPoint(curve, offshootEndings[i]), 4, false);
            var previous = curve.Begin;
            if (!ShouldDrawCurve(curve)) return;
            for (var i = 1; i <= steps; i++)
            {
                var percent = (float)i / steps;
                var point = curves.GetPoint(curve, percent);
                SourcePrimitiveDrawing.Line(context, this, previous, point,
                    i <= 2 || i >= steps - 1 ? edge : color, vectors);
                previous = point + vectors.SafeNormalize(previous - point);
            }
        }
    }
}
