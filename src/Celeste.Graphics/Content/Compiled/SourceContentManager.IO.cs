using Celeste.Audio.Sound;
using Celeste.Audio.Media;
using Celeste.Graphics.Media;
using System;
using System.IO;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Content.Compiled
{
    public partial class SourceContentManager
    {
        internal string RootDirectoryFullPath => Path.IsPathRooted(RootDirectory)
            ? RootDirectory
            : Path.Combine(process.ContentIo.TitleLocation, RootDirectory);

        protected virtual Stream OpenStream(string assetName)
        {
            try
            {
                return process.ContentIo.OpenTitleStream(Path.Combine(RootDirectory, assetName) + ".xnb");
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
            string text =
                SourceContentFileHelpers.NormalizeFilePathSeparators(Path.Combine(RootDirectoryFullPath, assetName));
            if (process.ContentIo.FileExists(text))
            {
                return process.ContentIo.OpenTitleStream(text);
            }

            string[] array = extensions;
            foreach (string text2 in array)
            {
                string text3 = text + text2;
                if (process.ContentIo.FileExists(text3))
                {
                    return process.ContentIo.OpenTitleStream(text3);
                }
            }

            text = SourceContentFileHelpers.NormalizeFilePathSeparators(assetName);
            try
            {
                return OpenStream(text);
            }
            catch
            {
                array = extensions;
                foreach (string text4 in array)
                {
                    string assetName2 = text + text4;
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
            {
                return CheckRawExtensions(assetName, process.texture2DExtensions);
            }

            if (typeof(T) == typeof(SourceTextureCubeResource))
            {
                return CheckRawExtensions(assetName, process.textureCubeExtensions);
            }

            if (typeof(T) == typeof(SourceSoundEffect))
            {
                return CheckRawExtensions(assetName, process.soundEffectExtensions);
            }

            if (typeof(T) == typeof(SourceEffect))
            {
                return CheckRawExtensions(assetName, process.effectExtensions);
            }

            if (typeof(T) == typeof(SourceSong))
            {
                return CheckRawExtensions(assetName, SourceSongReader.supportedExtensions);
            }

            if (typeof(T) == typeof(SourceVideo))
            {
                return CheckRawExtensions(assetName, SourceVideoReader.supportedExtensions);
            }

            return null;
        }
    }
}
