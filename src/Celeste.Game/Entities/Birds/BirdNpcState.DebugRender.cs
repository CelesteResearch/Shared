using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Birds
{
    public partial class BirdNpcState
    {
        public override void DebugRender(ISourceRenderContext context, object camera)
        {
            base.DebugRender(context, camera);
            if (mode == BirdNpcMode.DashingTutorial)
            {
                float x = StartPosition.X - 92f;
                float x2 = level.Bounds.Right;
                float y = StartPosition.Y - 20f;
                float y2 = StartPosition.Y - 10f;
                SourcePrimitiveDrawing.Line(context, this, new Vector2(x, y), new Vector2(x, y2), PackedColor.Aqua,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, this, new Vector2(x, y), new Vector2(x2, y), PackedColor.Aqua,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, this, new Vector2(x2, y), new Vector2(x2, y2), PackedColor.Aqua,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, this, new Vector2(x, y2), new Vector2(x2, y2), PackedColor.Aqua,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                float x3 = StartPosition.X - 60f;
                float x4 = level.Bounds.Right;
                float y3 = StartPosition.Y;
                float y4 = StartPosition.Y + 34f;
                SourcePrimitiveDrawing.Line(context, this, new Vector2(x3, y3), new Vector2(x3, y4), PackedColor.Aqua,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, this, new Vector2(x3, y3), new Vector2(x4, y3), PackedColor.Aqua,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, this, new Vector2(x4, y3), new Vector2(x4, y4), PackedColor.Aqua,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                SourcePrimitiveDrawing.Line(context, this, new Vector2(x3, y4), new Vector2(x4, y4), PackedColor.Aqua,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
            }
        }
    }
}
