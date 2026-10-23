using Celeste.Audio.Sound;
using Celeste.Audio.Media;
using Celeste.Graphics.Media;
using System;
using System.IO;
using Celeste.Core.Rendering.Resources;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.Compiled
{
    public partial class SourceContentManager
    {
        protected T ReadAsset<T>(string assetName, Action<IDisposable> recordDisposableObject)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                throw new ArgumentNullException("assetName");
            }

            if (disposed)
            {
                throw new ObjectDisposedException("ContentManager");
            }

            object obj = null;
            Stream stream = null;
            try
            {
                stream = OpenStream(assetName);
            }
            catch (Exception ex)
            {
                stream = OpenStreamRaw<T>(assetName);
                if (stream == null)
                {
                    throw new SourceContentLoadException("Could not load asset " + assetName + "! Error: " + ex.Message,
                        ex);
                }
            }

            stream.Read(process.XnbHeader, 0, process.XnbHeader.Length);
            if (process.XnbHeader[0] == 88 && process.XnbHeader[1] == 78 && process.XnbHeader[2] == 66 &&
                process.targetPlatformIdentifiers.Contains((char)process.XnbHeader[3]))
            {
                using BinaryReader xnbReader = new BinaryReader(stream);
                using SourceContentReader contentReader = GetSourceContentReaderFromXnb(assetName, ref stream,
                    xnbReader,
                    (char)process.XnbHeader[3], recordDisposableObject);
                obj = contentReader.ReadAsset<T>();
                if (obj is SourceGraphicsResource graphicsResource)
                {
                    graphicsResource.Name = assetName;
                }
            }
            else
            {
                stream.Seek(0L, SeekOrigin.Begin);
                if (typeof(T) == typeof(SourceTexture2DResource) || typeof(T) == typeof(SourceTextureResource))
                {
                    SourceTexture2DResource texture2D =
                        ((process.XnbHeader[0] != 68 || process.XnbHeader[1] != 68 || process.XnbHeader[2] != 83 ||
                          process.XnbHeader[3] != 32)
                            ? SourceTexture2DResource.FromStream(GetGraphicsDevice(), stream)
                            : SourceTexture2DResource.DDSFromStreamEXT(GetGraphicsDevice(), stream));
                    texture2D.Name = assetName;
                    obj = texture2D;
                }
                else if (typeof(T) == typeof(SourceTextureCubeResource))
                {
                    SourceTextureCubeResource textureCube =
                        SourceTextureCubeResource.DDSFromStreamEXT(GetGraphicsDevice(), stream);
                    textureCube.Name = assetName;
                    obj = textureCube;
                }
                else if (typeof(T) == typeof(SourceSoundEffect))
                {
                    SourceSoundEffect soundEffect =
                        SourceSoundEffect.FromStream(stream, process.AudioEnvironment.AudioMedia.Audio);
                    soundEffect.Name = assetName;
                    obj = soundEffect;
                }
                else if (typeof(T) == typeof(SourceEffect))
                {
                    byte[] array = new byte[stream.Length];
                    stream.Read(array, 0, (int)stream.Length);
                    obj = new SourceEffect(GetGraphicsDevice(), array)
                    {
                        Name = assetName
                    };
                }
                else if (typeof(T) == typeof(SourceSong))
                {
                    string name = (stream as FileStream).Name;
                    stream.Close();
                    obj = new SourceSong(name);
                }
                else
                {
                    if (!(typeof(T) == typeof(SourceVideo)))
                    {
                        stream.Close();
                        throw new SourceContentLoadException("Could not load " + assetName + " asset!");
                    }

                    string name2 = (stream as FileStream).Name;
                    stream.Close();
                    obj = new SourceVideo(name2, GetGraphicsDevice(), process.TheoraEnvironment.TheoraIO);
                    process.LoggingEnvironment.FnaLogger.LogWarn("Video " + name2 +
                                                                 " does not have an XNB file! Hacking Duration property!");
                }

                if (obj is IDisposable disposable)
                {
                    if (recordDisposableObject != null)
                    {
                        recordDisposableObject(disposable);
                    }
                    else
                    {
                        disposableAssets.Add(disposable);
                    }
                }

                stream.Close();
            }

            return (T)obj;
        }
    }
}
