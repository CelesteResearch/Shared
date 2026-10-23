using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Birds
{
    public partial class BirdNpcState
    {
        public override void DebugRender(ISourceRenderContext context, object camera)
        {
            base.DebugRender(context, camera);
            if (!(Mode == BirdNpcMode.DashingTutorial))
                return;
            var x = StartPosition.X - 92f;
            float x2 = Level.Bounds.Right;
            var y = StartPosition.Y - 20f;
            var y2 = StartPosition.Y - 10f;
            SourcePrimitiveDrawing.Line(context, this, new(x, y), new(x, y2), PackedColor.Aqua,
                ((ISourceVectorEnvironment)EngineContext).VectorArithmetic);
            SourcePrimitiveDrawing.Line(context, this, new(x, y), new(x2, y), PackedColor.Aqua,
                ((ISourceVectorEnvironment)EngineContext).VectorArithmetic);
            SourcePrimitiveDrawing.Line(context, this, new(x2, y), new(x2, y2), PackedColor.Aqua,
                ((ISourceVectorEnvironment)EngineContext).VectorArithmetic);
            SourcePrimitiveDrawing.Line(context, this, new(x, y2), new(x2, y2), PackedColor.Aqua,
                ((ISourceVectorEnvironment)EngineContext).VectorArithmetic);
            var x3 = StartPosition.X - 60f;
            float x4 = Level.Bounds.Right;
            var y3 = StartPosition.Y;
            var y4 = StartPosition.Y + 34f;
            SourcePrimitiveDrawing.Line(context, this, new(x3, y3), new(x3, y4), PackedColor.Aqua,
                ((ISourceVectorEnvironment)EngineContext).VectorArithmetic);
            SourcePrimitiveDrawing.Line(context, this, new(x3, y3), new(x4, y3), PackedColor.Aqua,
                ((ISourceVectorEnvironment)EngineContext).VectorArithmetic);
            SourcePrimitiveDrawing.Line(context, this, new(x4, y3), new(x4, y4), PackedColor.Aqua,
                ((ISourceVectorEnvironment)EngineContext).VectorArithmetic);
            SourcePrimitiveDrawing.Line(context, this, new(x3, y4), new(x4, y4), PackedColor.Aqua,
                ((ISourceVectorEnvironment)EngineContext).VectorArithmetic);
        }
    }
}
