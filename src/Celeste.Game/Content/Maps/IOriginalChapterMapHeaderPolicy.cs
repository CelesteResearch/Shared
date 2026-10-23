using System;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Formats.Map.Binary.Source;

namespace Celeste.Game.Content.Maps
{
    public interface IOriginalChapterMapHeaderPolicy
    {
        void CheckPackage(BinaryPackerElement source, OriginalAreaModeData actualMode);
        bool TrackableContains(OriginalLevelEntityData actualEntity);
        OriginalLevelEntityData GrowAndGet(ref OriginalLevelEntityData[,] actualGrid, int y, int x);
    }
}
