using System;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Content.Maps
{
    public partial class OriginalChapterMapData
    {
        /// <summary>
        /// Creates an in-memory map without loading a map file. The generator populates its
        /// rooms and presentation data; the supplied policies own start selection and regeneration.
        /// </summary>
        public static OriginalChapterMapData CreateGenerated(OriginalAreaKey area, IOriginalAreaData data,
            IOriginalChapterMapStartPolicy startPolicy, IOriginalChapterMapLoadPolicy generationPolicy)
            => new(area, data, startPolicy, generationPolicy);

        private OriginalChapterMapData(OriginalAreaKey area, IOriginalAreaData data,
            IOriginalChapterMapStartPolicy startPolicy, IOriginalChapterMapLoadPolicy generationPolicy)
        {
            Area = area;
            Data = data ?? throw new ArgumentNullException(nameof(data));
            ModeData = data.GetOriginalMode(area.Mode);
            this.startPolicy = startPolicy ?? throw new ArgumentNullException(nameof(startPolicy));
            loadPolicy = generationPolicy ?? throw new ArgumentNullException(nameof(generationPolicy));
        }
    }
}
