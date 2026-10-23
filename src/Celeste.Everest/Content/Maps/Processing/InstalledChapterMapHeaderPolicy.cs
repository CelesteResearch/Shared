using System;
using Celeste.Everest.Content.Extensions.Collectibles;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Processing
{
    public sealed class InstalledChapterMapHeaderPolicy : IOriginalChapterMapHeaderPolicy
    {
        private readonly ISourceInstalledStrawberryRegistryEnvironment environment;

        public InstalledChapterMapHeaderPolicy(ISourceInstalledStrawberryRegistryEnvironment environment)
        {
            this.environment = environment;
        }

        public void CheckPackage(BinaryPackerElement source, OriginalAreaModeData actualMode)
        {
            if (!source.Package.Equals(actualMode.Path)) _ = new Exception("Corrupted Level Data");
        }

        public bool TrackableContains(OriginalLevelEntityData actualEntity)
        {
            return environment.StrawberryRegistry.TrackableContains(actualEntity.Name);
        }

        public OriginalLevelEntityData GrowAndGet(ref OriginalLevelEntityData[,] actualGrid, int y, int x)
        {
            if (y < 0) y = -y;
            if (x < 0) x = -x;
            if (actualGrid.GetLength(0) <= y || actualGrid.GetLength(1) <= x)
            {
                var grown = new OriginalLevelEntityData[y + 10, x + 25];
                var oldWidth = actualGrid.GetLength(1);
                var newWidth = grown.GetLength(1);
                var oldHeight = actualGrid.GetLength(0);
                for (var i = 0; i < oldHeight; i++)
                    Array.Copy(actualGrid, i * oldWidth, grown, i * newWidth, oldWidth);
                actualGrid = grown;
            }

            return actualGrid[y, x];
        }
    }
}
