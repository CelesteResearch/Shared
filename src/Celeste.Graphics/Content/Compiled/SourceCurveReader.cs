using System.Runtime.CompilerServices;
using Celeste.Core.Mathematics.Curves;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceCurveReader : SourceContentTypeReader<SourceCurve>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceCurve Read(SourceContentReader input, SourceCurve existingInstance)
        {
            var curve = existingInstance;
            if (curve == null) curve = new();

            curve.PreLoop = (SourceCurveLoopType)input.ReadInt32();
            curve.PostLoop = (SourceCurveLoopType)input.ReadInt32();
            var num = input.ReadInt32();
            for (var i = 0; i < num; i++)
            {
                var position = input.ReadSingle();
                var value = input.ReadSingle();
                var tangentIn = input.ReadSingle();
                var tangentOut = input.ReadSingle();
                var continuity = (SourceCurveContinuity)input.ReadInt32();
                curve.Keys.Add(new(position, value, tangentIn, tangentOut, continuity));
            }

            return curve;
        }
    }
}
