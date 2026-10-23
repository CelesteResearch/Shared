using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Runtime.Platform;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private GamePlatformServices physicalIO;
        public ISourceEngineContext EngineContext => this;

        public GamePlatformServices PhysicalIO => physicalIO ??
                                                  throw new InvalidOperationException(
                                                      "The physical host endpoints are not bound.");

        public void BindPhysicalIO(GamePlatformServices actualPhysicalIO)
        {
            if (physicalIO != null)
                throw new InvalidOperationException("The physical host endpoints are already bound.");
            physicalIO = actualPhysicalIO ?? throw new ArgumentNullException(nameof(actualPhysicalIO));
        }
    }
}
