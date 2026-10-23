using System;

namespace Celeste.Core.Rendering.Observation
{
    // The invocation position in the scene render pass, independent of the logical owner.
    public readonly struct SourceRenderPhase
    {
        public readonly bool IsActive;
        public readonly bool HasDepth;
        public readonly double ActualDepth;

        public SourceRenderPhase(in SourceRenderEntityPresentation owner)
        {
            IsActive = true;
            HasDepth = owner.HasDepth;
            ActualDepth = owner.ActualDepth;
        }

        public bool Matches(in SourceRenderPhase other)
            => IsActive == other.IsActive && HasDepth == other.HasDepth &&
               BitConverter.DoubleToInt64Bits(ActualDepth) == BitConverter.DoubleToInt64Bits(other.ActualDepth);
    }
}
