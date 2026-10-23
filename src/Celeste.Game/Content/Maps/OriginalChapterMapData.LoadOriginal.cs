using System.IO;
using Celeste.Core.IO;
using Celeste.Core.IO.Content;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps.Levels;

namespace Celeste.Game.Content.Maps
{
    public partial class OriginalChapterMapData
    {
        public string Filename => Data.Mode[Area.Mode].Path;

        public string GetSourceFilepath(ISourceContentDirectoryEnvironment content)
        {
            return Path.Combine(content.ContentDirectory, "Maps", Filename + ".bin");
        }

        public void LoadOriginalSource(ISourceContentDirectoryEnvironment content,
            IOriginalLevelRoomDataExtensions extensions, IOriginalChapterMapHeaderPolicy headerPolicy,
            IContentSource files = null)
        {
            var path = GetSourceFilepath(content);
            if (!(files == null ? File.Exists(path) : files.FileExists(path))) return;
            BeginSourceMapLoad();
            var source = files == null
                ? BinaryPacker.FromBinary(path)
                : BinaryPacker.FromBinary(files.OpenTitleStream(path));
            LoadSourceParsedHeader(source, extensions, headerPolicy);
        }
    }
}
