using System.IO;
using Celeste.Core.IO;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Formats.Map.Binary.Source;

namespace Celeste.Game.Content.Maps
{
    public partial class OriginalChapterMapData
    {
        public string Filename => Data.Mode[Area.Mode].Path;

        public string GetSourceFilepath(ISourceContentDirectoryEnvironment content)
            => Path.Combine(content.ContentDirectory, "Maps", Filename + ".bin");

        public void LoadOriginalSource(ISourceContentDirectoryEnvironment content,
            IOriginalLevelRoomDataExtensions extensions, IOriginalChapterMapHeaderPolicy headerPolicy,
            global::Celeste.Core.IO.Content.IContentSource files = null)
        {
            string path = GetSourceFilepath(content);
            if (!(files == null ? File.Exists(path) : files.FileExists(path))) return;
            BeginSourceMapLoad();
            BinaryPackerElement source = files == null
                ? BinaryPacker.FromBinary(path)
                : BinaryPacker.FromBinary(files.OpenTitleStream(path));
            LoadSourceParsedHeader(source, extensions, headerPolicy);
        }
    }
}
