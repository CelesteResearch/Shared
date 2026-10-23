using System.Collections.Generic;
using Celeste.Game.Content.Maps;
using Celeste.Game.Presentation.Mountain.Views;

namespace Celeste.Game.Execution.Areas
{
    public sealed partial class OriginalAreaRegistryProcess : IOriginalAreaSourceTable
    {
        public List<OriginalAreaData> Areas;
        IReadOnlyList<IOriginalAreaData> IOriginalAreaSourceTable.Areas => Areas;
        private readonly IOriginalAreaDataFactory areaFactory;
        private readonly IOriginalAreaKeyPolicy areaKeys;
        private readonly IOriginalChapterMapStartPolicy mapStartPolicy;
        private readonly IOriginalChapterMapLoadPolicy mapLoadPolicy;
        private readonly IOriginalAreaInterludePolicy interludePolicy;

        private readonly IOriginalMountainViewsEnvironment
            mountainViews;

        public OriginalAreaRegistryProcess(IOriginalAreaDataFactory areaFactory, IOriginalAreaKeyPolicy areaKeys,
            IOriginalChapterMapStartPolicy mapStartPolicy, IOriginalChapterMapLoadPolicy mapLoadPolicy,
            IOriginalAreaInterludePolicy interludePolicy,
            IOriginalMountainViewsEnvironment mountainViews)
        {
            this.areaFactory = areaFactory;
            this.areaKeys = areaKeys;
            this.mapStartPolicy = mapStartPolicy;
            this.mapLoadPolicy = mapLoadPolicy;
            this.interludePolicy = interludePolicy;
            this.mountainViews = mountainViews;
        }
    }
}
