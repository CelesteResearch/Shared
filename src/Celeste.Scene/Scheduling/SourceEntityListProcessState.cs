using System;
using Celeste.Scene.Tagging;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Scheduling
{
    public sealed class SourceEntityListProcessState
    {
        public readonly SourceBitTagProcessState BitTags;

        public SourceEntityListProcessState(SourceBitTagProcessState bitTags)
        {
            BitTags = bitTags;
        }

        public Comparison<object> CompareDepth = (a, b) =>
            Math.Sign(((ISceneEntityDepth)b).DepthState.ActualDepth - ((ISceneEntityDepth)a).DepthState.ActualDepth);
    }
}
