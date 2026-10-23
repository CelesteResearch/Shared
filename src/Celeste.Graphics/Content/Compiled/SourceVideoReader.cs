using System.IO;
using System.Runtime.CompilerServices;
using Celeste.Audio.Media;
using Celeste.Graphics.Media;


namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVideoReader : SourceContentTypeReader<SourceVideo>
    {
        internal static readonly string[] supportedExtensions = new string[2] { ".ogv", ".ogg" };

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceVideo Read(SourceContentReader input, SourceVideo existingInstance)
        {
            string text = SourceContentFileHelpers.ResolveRelativePath(
                Path.Combine(input.ContentManager.RootDirectoryFullPath, input.AssetName), input.ReadObject<string>());
            text = Normalize(text.Substring(0, text.Length - 4));
            if (string.IsNullOrEmpty(text))
            {
                throw new SourceContentLoadException();
            }

            int durationMS = input.ReadObject<int>();
            int width = input.ReadObject<int>();
            int height = input.ReadObject<int>();
            float framesPerSecond = input.ReadObject<float>();
            SourceVideoSoundtrackType soundtrackType = (SourceVideoSoundtrackType)input.ReadObject<int>();
            return new SourceVideo(text, input.ContentManager.GetGraphicsDevice(),
                input.ContentManager.Process.TheoraEnvironment.TheoraIO,
                input.ContentManager.Process.AudioEnvironment.AudioMedia.Audio.TimeSpans, durationMS, width, height,
                framesPerSecond, soundtrackType);
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
