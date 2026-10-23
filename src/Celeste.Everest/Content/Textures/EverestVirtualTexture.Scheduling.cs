using Celeste.Graphics.Rendering.Textures;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Graphics.Content.Textures;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Runtime.Threading;

namespace Celeste.Everest.Content.Textures
{
    public sealed partial class EverestVirtualTexture
    {
        public override void Unload()
        {
            SourceTexture2DResource tex = Texture;
            object texture_QueuedLoadLock = _Texture_QueuedLoadLock;
            if (texture_QueuedLoadLock != null)
            {
                bool lockTaken = false;
                try
                {
                    Monitor.TryEnter(texture_QueuedLoadLock, ref lockTaken);
                    if (lockTaken)
                    {
                        if (_Texture_QueuedLoadLock != null)
                        {
                            _Texture_QueuedLoadLock = null;
                        }
                    }
                    else
                    {
                        _Texture_UnloadAfterReload = true;
                        Monitor.TryEnter(texture_QueuedLoadLock, ref lockTaken);
                        if (!lockTaken)
                        {
                            return;
                        }

                        _Texture_UnloadAfterReload = false;
                    }
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(texture_QueuedLoadLock);
                    }
                }

                if (!Environment.MainThread.IsMainThread)
                {
                    tex = _Texture_QueuedLoad.Result;
                }
            }

            Texture = null;
            if (tex == null || tex.IsDisposed)
            {
                return;
            }

            if (((!Environment.Settings.ThreadedGL) ?? true) && !Environment.MainThread.IsMainThread)
            {
                Environment.MainThread.Schedule(delegate { tex.Dispose(); });
            }
            else
            {
                tex.Dispose();
            }
        }

        private bool Load(bool wait, Func<SourceTexture2DResource> load)
        {
            if (LoadImmediately)
            {
                Texture?.Dispose();
                Texture = load();
                Environment.FastLoading.Free(ref _Texture_FTLCount, ref _Texture_FTLLoading, ref _Texture_FTLSize);
                return true;
            }

            object queuedLoadLock;
            lock (queuedLoadLock = new object())
            {
                _Texture_QueuedLoadLock = queuedLoadLock;
                Func<SourceTexture2DResource> _load = load;
                load = delegate
                {
                    SourceTexture2DResource texture2D;
                    lock (queuedLoadLock)
                    {
                        if (_Texture_QueuedLoadLock != queuedLoadLock)
                        {
                            _load = null;
                            Environment.FastLoading.Free(ref _Texture_FTLCount, ref _Texture_FTLLoading,
                                ref _Texture_FTLSize);
                            return Texture;
                        }

                        Texture?.Dispose();
                        texture2D = (Texture = _load());
                        Environment.FastLoading.Free(ref _Texture_FTLCount, ref _Texture_FTLLoading,
                            ref _Texture_FTLSize);
                        _Texture_QueuedLoadLock = null;
                    }

                    if (_Texture_UnloadAfterReload)
                    {
                        texture2D?.Dispose();
                        texture2D = Texture;
                        Texture = null;
                        texture2D?.Dispose();
                        _Texture_UnloadAfterReload = false;
                    }

                    return texture2D;
                };
                _Texture_QueuedLoad = Environment.MainThread.Schedule(load, !_Texture_FTLLoading);
            }

            if (wait || _Texture_Requesting)
            {
                _ = _Texture_QueuedLoad.Result;
            }

            return false;
        }
    }
}
