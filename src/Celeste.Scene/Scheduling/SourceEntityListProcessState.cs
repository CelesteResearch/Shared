using System;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Scheduling
{
    public sealed class SourceEntityListProcessState
    {
        public readonly Celeste.Scene.Tagging.SourceBitTagProcessState BitTags;

        public SourceEntityListProcessState(Celeste.Scene.Tagging.SourceBitTagProcessState bitTags) =>
            BitTags = bitTags;

        public Comparison<object> CompareDepth = (a, b) =>
            Math.Sign(((ISceneEntityDepth)b).DepthState.ActualDepth - ((ISceneEntityDepth)a).DepthState.ActualDepth);
    }
}
