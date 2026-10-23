using System.IO;
using System.Runtime.CompilerServices;
using Celeste.Audio.Media;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceSongReader : SourceContentTypeReader<SourceSong>
    {
        internal static readonly string[] supportedExtensions = [".ogg", ".oga", ".qoa"];

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceSong Read(SourceContentReader input, SourceSong existingInstance)
        {
            var text = SourceContentFileHelpers.ResolveRelativePath(
                Path.Combine(input.ContentManager.RootDirectoryFullPath, input.AssetName), input.ReadString());
            text = Normalize(text.Substring(0, text.Length - 4));
            if (string.IsNullOrEmpty(text)) throw new SourceContentLoadException();

            var durationMs = input.ReadInt32();
            return new(text, durationMs,
                input.ContentManager.Process.AudioEnvironment.AudioMedia.Audio.TimeSpans);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string Normalize(string fileName)
        {
            if (File.Exists(fileName)) return fileName;

            var array = supportedExtensions;
            foreach (var text in array)
            {
                var text2 = fileName + text;
                if (File.Exists(text2)) return text2;
            }

            return null;
        }
    }
}
