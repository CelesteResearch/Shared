using System;

namespace Celeste.Core.Rendering.Observation
{
    // The invocation position in the scene render pass, independent of the logical owner.
    public readonly struct SourceRenderPhase(in SourceRenderEntityPresentation owner)
    {
        public readonly bool IsActive = true;
        public readonly bool HasDepth = owner.HasDepth;
        public readonly double ActualDepth = owner.ActualDepth;

        public bool Matches(in SourceRenderPhase other)
        {
            return IsActive == other.IsActive && HasDepth == other.HasDepth &&
                   BitConverter.DoubleToInt64Bits(ActualDepth) == BitConverter.DoubleToInt64Bits(other.ActualDepth);
        }
    }
}
