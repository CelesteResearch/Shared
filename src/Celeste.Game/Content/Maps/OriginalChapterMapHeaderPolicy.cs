using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Content.Maps
{
    public sealed class OriginalChapterMapHeaderPolicy : IOriginalChapterMapHeaderPolicy
    {
        public void CheckPackage(BinaryPackerElement source, OriginalAreaModeData actualMode)
        {
            if (!source.Package.Equals(actualMode.Path)) throw new("Corrupted Level Data");
        }

        public bool TrackableContains(OriginalLevelEntityData actualEntity)
        {
            return actualEntity.Name == "strawberry";
        }

        public OriginalLevelEntityData GrowAndGet(ref OriginalLevelEntityData[,] actualGrid, int y, int x)
        {
            return actualGrid[y, x];
        }
    }
}
