using System.IO;
using System.Runtime.CompilerServices;
using Celeste.Audio.Media;
using Celeste.Graphics.Media;


namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceSongReader : SourceContentTypeReader<SourceSong>
    {
        internal static readonly string[] supportedExtensions = new string[3] { ".ogg", ".oga", ".qoa" };

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceSong Read(SourceContentReader input, SourceSong existingInstance)
        {
            string text = SourceContentFileHelpers.ResolveRelativePath(
                Path.Combine(input.ContentManager.RootDirectoryFullPath, input.AssetName), input.ReadString());
            text = Normalize(text.Substring(0, text.Length - 4));
            if (string.IsNullOrEmpty(text))
            {
                throw new SourceContentLoadException();
            }

            int durationMS = input.ReadInt32();
            return new SourceSong(text, durationMS,
                input.ContentManager.Process.AudioEnvironment.AudioMedia.Audio.TimeSpans);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string Normalize(string fileName)
        {
            if (File.Exists(fileName))
            {
                return fileName;
            }

            string[] array = supportedExtensions;
            foreach (string text in array)
            {
                string text2 = fileName + text;
                if (File.Exists(text2))
                {
                    return text2;
                }
            }

            return null;
        }
    }
}
