using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Display;

namespace Celeste.Game.Entities.Gondolas
{
    public sealed class OriginalGondolaRopeState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public OriginalGondolaState Gondola;

        public OriginalGondolaRopeState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Depth = 8999;
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 vector = Vector2Geometry.Floor(Gondola.LeftCliffside.Position + new Vector2(40f, -12f));
            Vector2 vector2 = Vector2Geometry.Floor(Gondola.RightCliffside.Position + new Vector2(-40f, -4f));
            Vector2 vector3 = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(vector2 - vector);
            Vector2 vector4 = Gondola.Position + new Vector2(0f, -55f) - vector3 * 6f;
            Vector2 vector5 = Gondola.Position + new Vector2(0f, -55f) + vector3 * 6f;
            for (int i = 0; i < 2; i++)
            {
                Vector2 vector6 = Vector2.UnitY * i;
                SourcePrimitiveDrawing.Line(context, this, vector + vector6, vector4 + vector6, PackedColor.Black,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, this, vector5 + vector6, vector2 + vector6, PackedColor.Black,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
            }
        }
    }
}
