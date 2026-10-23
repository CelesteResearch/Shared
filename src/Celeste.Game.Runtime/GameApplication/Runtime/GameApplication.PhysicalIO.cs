using System;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private global::Celeste.Game.Runtime.Platform.GamePlatformServices physicalIO;
        public ISourceEngineContext EngineContext => this;

        public global::Celeste.Game.Runtime.Platform.GamePlatformServices PhysicalIO => physicalIO ??
            throw new InvalidOperationException(
                "The physical host endpoints are not bound.");

        public void BindPhysicalIO(global::Celeste.Game.Runtime.Platform.GamePlatformServices actualPhysicalIO)
        {
            if (physicalIO != null)
                throw new InvalidOperationException("The physical host endpoints are already bound.");
            physicalIO = actualPhysicalIO ?? throw new ArgumentNullException(nameof(actualPhysicalIO));
        }
    }
}
