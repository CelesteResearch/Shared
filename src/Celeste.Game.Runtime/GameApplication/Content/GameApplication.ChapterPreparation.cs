using Celeste.Core.IO.Content;
using Celeste.Game.Content.Loading;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalChapterPreparationEnvironment
    {
        private OriginalChapterPreparationProcess? sourceChapterPreparation;

        public OriginalChapterPreparationProcess? ChapterPreparation
            => SourceProfile == GameProfile.Original && PhysicalIO.ContentFiles is ResidentContentSource source
                ? sourceChapterPreparation ??=
                    new(source, Threads, this, GraphicsResources)
                : null;
    }
}
