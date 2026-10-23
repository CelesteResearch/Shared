using System.Collections.Generic;
using Celeste.Physics.Collision;

namespace Celeste.Scene.Tracking
{
    public sealed class SourceTrackedPlatformSource<TPlatform> : IPixelPlatformSource<TPlatform>
        where TPlatform : PixelPlatform
    {
        private readonly SceneEntityRegistry tracker;
        private readonly string solidType;
        private readonly string jumpThruType;

        public SourceTrackedPlatformSource(SceneEntityRegistry tracker, string solidType, string jumpThruType)
        {
            this.tracker = tracker;
            this.solidType = solidType;
            this.jumpThruType = jumpThruType;
        }

        public List<object> GetSolids() => tracker.GetTrackedEntities(solidType);
        public List<object> GetJumpThrus() => tracker.GetTrackedEntities(jumpThruType);
    }
}
