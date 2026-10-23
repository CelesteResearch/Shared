using System;
using System.Threading;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Everest.Content.Textures
{
    public sealed partial class EverestVirtualTexture
    {
        public override void Unload()
        {
            var tex = Texture;
            var textureQueuedLoadLock = _Texture_QueuedLoadLock;
            if (textureQueuedLoadLock != null)
            {
                var lockTaken = false;
                try
                {
                    Monitor.TryEnter(textureQueuedLoadLock, ref lockTaken);
                    if (lockTaken)
                    {
                        if (_Texture_QueuedLoadLock != null) _Texture_QueuedLoadLock = null;
                    }
                    else
                    {
                        _Texture_UnloadAfterReload = true;
                        Monitor.TryEnter(textureQueuedLoadLock, ref lockTaken);
                        if (!lockTaken) return;

                        _Texture_UnloadAfterReload = false;
                    }
                }
                finally
                {
                    if (lockTaken) Monitor.Exit(textureQueuedLoadLock);
                }

                if (!Environment.MainThread.IsMainThread) tex = _Texture_QueuedLoad.Result;
            }

            Texture = null;
            if (tex == null || tex.IsDisposed) return;

            if ((!Environment.Settings.ThreadedGL ?? true) && !Environment.MainThread.IsMainThread)
                Environment.MainThread.Schedule(delegate { tex.Dispose(); });
            else
                tex.Dispose();
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
            lock (queuedLoadLock = new())
            {
                _Texture_QueuedLoadLock = queuedLoadLock;
                var originalLoad = load;
                load = delegate
                {
                    SourceTexture2DResource texture2D;
                    lock (queuedLoadLock)
                    {
                        if (_Texture_QueuedLoadLock != queuedLoadLock)
                        {
                            originalLoad = null;
                            Environment.FastLoading.Free(ref _Texture_FTLCount, ref _Texture_FTLLoading,
                                ref _Texture_FTLSize);
                            return Texture;
                        }

                        Texture?.Dispose();
                        texture2D = Texture = originalLoad();
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

            if (wait || _Texture_Requesting) _ = _Texture_QueuedLoad.Result;

            return false;
        }
    }
}
