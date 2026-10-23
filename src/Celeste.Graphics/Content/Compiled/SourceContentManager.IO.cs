using System;
using System.IO;
using Celeste.Audio.Media;
using Celeste.Audio.Sound;
using Celeste.Graphics.Media;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.Compiled
{
    public partial class SourceContentManager
    {
        internal string RootDirectoryFullPath => Path.IsPathRooted(RootDirectory)
            ? RootDirectory
            : Path.Combine(Process.ContentIo.TitleLocation, RootDirectory);

        protected virtual Stream OpenStream(string assetName)
        {
            try
            {
                return Process.ContentIo.OpenTitleStream(Path.Combine(RootDirectory, assetName) + ".xnb");
            }
            catch (FileNotFoundException innerException)
            {
                throw new SourceContentLoadException("The content file was not found.", innerException);
            }
            catch (DirectoryNotFoundException innerException2)
            {
                throw new SourceContentLoadException("The directory was not found.", innerException2);
            }
            catch (Exception innerException3)
            {
                throw new SourceContentLoadException("Opening stream error.", innerException3);
            }
        }

        private Stream CheckRawExtensions(string assetName, string[] extensions)
        {
            var text =
                SourceContentFileHelpers.NormalizeFilePathSeparators(Path.Combine(RootDirectoryFullPath, assetName));
            if (Process.ContentIo.FileExists(text)) return Process.ContentIo.OpenTitleStream(text);

            var array = extensions;
            foreach (var text2 in array)
            {
                var text3 = text + text2;
                if (Process.ContentIo.FileExists(text3)) return Process.ContentIo.OpenTitleStream(text3);
            }

            text = SourceContentFileHelpers.NormalizeFilePathSeparators(assetName);
            try
            {
                return OpenStream(text);
            }
            catch
            {
                array = extensions;
                foreach (var text4 in array)
                {
                    var assetName2 = text + text4;
                    try
                    {
                        return OpenStream(assetName2);
                    }
                    catch
                    {
                    }
                }
            }

            return null;
        }

        private Stream OpenStreamRaw<T>(string assetName)
        {
            if (typeof(T) == typeof(SourceTexture2DResource) || typeof(T) == typeof(SourceTextureResource))
                return CheckRawExtensions(assetName, Process.texture2DExtensions);

            if (typeof(T) == typeof(SourceTextureCubeResource))
                return CheckRawExtensions(assetName, Process.textureCubeExtensions);

            if (typeof(T) == typeof(SourceSoundEffect))
                return CheckRawExtensions(assetName, Process.soundEffectExtensions);

            if (typeof(T) == typeof(SourceEffect)) return CheckRawExtensions(assetName, Process.effectExtensions);

            if (typeof(T) == typeof(SourceSong))
                return CheckRawExtensions(assetName, SourceSongReader.supportedExtensions);

            if (typeof(T) == typeof(SourceVideo))
                return CheckRawExtensions(assetName, SourceVideoReader.supportedExtensions);

            return null;
        }
    }
}
