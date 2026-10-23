using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Decoration.Wires
{
    public class OriginalWireState : SceneEntityState
    {
        protected readonly ISourceEngineContext Engine;
        public PackedColor Color = new(89, 88, 102);
        public SimpleCurve Curve;
        private readonly float sineX;
        private readonly float sineY;

        public OriginalWireState(Vector2 from, Vector2 to, bool above, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            Engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Curve = new(from, to, Vector2.Zero);
            Depth = above ? -8500 : 2000;
            var random = ((ISourceRandomProcessEnvironment)Engine).RandomProcess.Factory.CreateSeeded(
                unchecked((int)((ISourceExtremaEnvironment)Engine).ExtremaArithmetic.Min(from.X, to.X)));
            sineX = SourceRandomMath.NextFloat(random, 4f);
            sineY = SourceRandomMath.NextFloat(random, 4f);
        }

        public OriginalWireState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, data.Nodes[0] + offset,
                EntityAttributeReader.Bool(data.Values, "above"), engine)
        {
        }

        protected virtual float ReadVisualWind(OriginalLevelSceneRoot level)
        {
            return level.VisualWind;
        }

        protected virtual bool ShouldDrawCurve()
        {
            return true;
        }

        public override void Render(ISourceRenderContext context)
        {
            var level = (OriginalLevelSceneRoot)Scene;
            var wave = new Vector2((float)Math.Sin(sineX + level.WindSineTimer * 2f),
                (float)Math.Sin(sineY + level.WindSineTimer * 2.8f)) * 8f;
            var wind = wave * ReadVisualWind(level);
            Curve.Control = ((ISourceVectorEnvironment)Engine).VectorArithmetic.Divide(Curve.Begin + Curve.End, 2f)
                            + new Vector2(0f, 24f) + wind;
            if (!ShouldDrawCurve()) return;
            var start = Curve.Begin;
            var curves = ((ISourceCurveEnvironment)Engine).CurveArithmetic;
            for (var i = 1; i <= 16; i++)
            {
                var point = curves.GetPoint(Curve, i / 16f);
                SourcePrimitiveDrawing.Line(context, this, start, point, Color,
                    ((ISourceVectorEnvironment)Engine).VectorArithmetic);
                start = point;
            }
        }
    }
}
