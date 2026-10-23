using System;
using System.Collections.Generic;
using Celeste.Core.Framework.Loading;

namespace Celeste.Game.Content.Loading
{
    // Immutable original-data snapshot. The common scheduler never examines these fields.
    public sealed class OriginalChapterPreparationContext : ISourceLoadingContentContext
    {
        public int AreaId { get; }
        public int Mode { get; }
        public string MapPath { get; }
        public string ChapterGroup { get; }
        public string CompletionAtlas { get; }
        public IReadOnlyList<string> ContentGroups { get; }

        public OriginalChapterPreparationContext(int areaId, int mode, string mapPath, string chapterGroup,
            string completionAtlas, IEnumerable<string> contentGroups)
        {
            AreaId = areaId;
            Mode = mode;
            MapPath = mapPath ?? throw new ArgumentNullException(nameof(mapPath));
            ChapterGroup = chapterGroup ?? throw new ArgumentNullException(nameof(chapterGroup));
            CompletionAtlas = completionAtlas;
            ContentGroups = new List<string>(contentGroups ?? throw new ArgumentNullException(nameof(contentGroups)))
                .AsReadOnly();
        }
    }
}
