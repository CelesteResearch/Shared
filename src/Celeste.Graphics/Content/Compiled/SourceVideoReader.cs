using System.IO;
using System.Runtime.CompilerServices;
using Celeste.Audio.Media;
using Celeste.Graphics.Media;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVideoReader : SourceContentTypeReader<SourceVideo>
    {
        internal static readonly string[] supportedExtensions = [".ogv", ".ogg"];

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceVideo Read(SourceContentReader input, SourceVideo existingInstance)
        {
            var text = SourceContentFileHelpers.ResolveRelativePath(
                Path.Combine(input.ContentManager.RootDirectoryFullPath, input.AssetName), input.ReadObject<string>());
            text = Normalize(text.Substring(0, text.Length - 4));
            if (string.IsNullOrEmpty(text)) throw new SourceContentLoadException();

            var durationMs = input.ReadObject<int>();
            var width = input.ReadObject<int>();
            var height = input.ReadObject<int>();
            var framesPerSecond = input.ReadObject<float>();
            var soundtrackType = (SourceVideoSoundtrackType)input.ReadObject<int>();
            return new(text, input.ContentManager.GetGraphicsDevice(),
                input.ContentManager.Process.TheoraEnvironment.TheoraIO,
                input.ContentManager.Process.AudioEnvironment.AudioMedia.Audio.TimeSpans, durationMs, width, height,
                framesPerSecond, soundtrackType);
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
