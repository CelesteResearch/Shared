using System;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Formats.Map.Binary.Source;

namespace Celeste.Game.Content.Maps
{
    public sealed class OriginalChapterMapHeaderPolicy : IOriginalChapterMapHeaderPolicy
    {
        public void CheckPackage(BinaryPackerElement source, OriginalAreaModeData actualMode)
        {
            if (!source.Package.Equals(actualMode.Path)) throw new Exception("Corrupted Level Data");
        }

        public bool TrackableContains(OriginalLevelEntityData actualEntity) => actualEntity.Name == "strawberry";

        public OriginalLevelEntityData GrowAndGet(ref OriginalLevelEntityData[,] actualGrid, int y, int x)
            => actualGrid[y, x];
    }
}
