using Celeste.Core.IO;
using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Content.Maps
{
    public sealed class OriginalChapterMapLoadPolicy : IOriginalChapterMapLoadPolicy
    {
        private readonly ISourceContentDirectoryEnvironment content;
        private readonly IOriginalLevelRoomDataExtensions roomExtensions;
        private readonly IOriginalChapterMapHeaderPolicy headerPolicy;
        private readonly global::Celeste.Core.IO.Content.IContentSource files;

        public OriginalChapterMapLoadPolicy(ISourceContentDirectoryEnvironment content,
            IOriginalLevelRoomDataExtensions roomExtensions, IOriginalChapterMapHeaderPolicy headerPolicy,
            global::Celeste.Core.IO.Content.IContentSource files = null)
        {
            this.content = content;
            this.roomExtensions = roomExtensions;
            this.headerPolicy = headerPolicy;
            this.files = files;
        }

        public void Load(OriginalChapterMapData map) =>
            map.LoadOriginalSource(content, roomExtensions, headerPolicy, files);

        public OriginalLevelRoomData Get(OriginalChapterMapData map, string levelName)
        {
            foreach (OriginalLevelRoomData level in map.Levels)
                if (level.Name.Equals(levelName))
                    return level;
            return null;
        }
    }
}
