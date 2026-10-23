using Celeste.Core.Mathematics.Curves;
using System.Runtime.CompilerServices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceCurveReader : SourceContentTypeReader<SourceCurve>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceCurve Read(SourceContentReader input, SourceCurve existingInstance)
        {
            SourceCurve curve = existingInstance;
            if (curve == null)
            {
                curve = new SourceCurve();
            }

            curve.PreLoop = (SourceCurveLoopType)input.ReadInt32();
            curve.PostLoop = (SourceCurveLoopType)input.ReadInt32();
            int num = input.ReadInt32();
            for (int i = 0; i < num; i++)
            {
                float position = input.ReadSingle();
                float value = input.ReadSingle();
                float tangentIn = input.ReadSingle();
                float tangentOut = input.ReadSingle();
                SourceCurveContinuity continuity = (SourceCurveContinuity)input.ReadInt32();
                curve.Keys.Add(new SourceCurveKey(position, value, tangentIn, tangentOut, continuity));
            }

            return curve;
        }
    }
}
