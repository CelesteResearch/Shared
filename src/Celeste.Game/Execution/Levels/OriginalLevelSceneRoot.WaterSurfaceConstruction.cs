using Celeste.Core.Components;
using Celeste.Game.Gameplay.Environment.Water;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public OriginalWaterSurface WaterSurface { get; private set; }

        public void ConstructSourceWaterSurface()
        {
            WaterSurface =
                new(((ISourceEntitySourceDataEnvironment)EngineContext)
                    .EntitySourceDataRegistration);
            AddEntity(WaterSurface);
        }
    }
}
