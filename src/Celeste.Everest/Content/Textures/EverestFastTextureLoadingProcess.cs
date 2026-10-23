using System;
using System.Threading;

namespace Celeste.Everest.Content.Textures
{
    public sealed class EverestFastTextureLoadingProcess
    {
        private bool enabled;
        private readonly object loadLock = new();
        private readonly ManualResetEventSlim free = new(initialState: true);
        private readonly ManualResetEventSlim finish = new(initialState: true);
        private volatile uint limit;
        private volatile uint used;
        private volatile int totalCount;
        private volatile int usedCount;

        internal bool Enabled => enabled;

        public void Start(long byteLimit)
        {
            lock (loadLock)
            {
                limit = byteLimit >= uint.MaxValue ? uint.MaxValue : (uint)byteLimit;
                enabled = true;
            }
        }

        public void Stop()
        {
            lock (loadLock) enabled = false;
        }

        internal void Count(ref bool textureCounted)
        {
            lock (loadLock)
            {
                if (!textureCounted)
                {
                    textureCounted = true;
                    totalCount++;
                }
            }
        }

        internal void Grab(int width, int height, string name, ref bool textureLoading, ref uint textureSize)
        {
            long size = width * height * 4;
            if (size == 0L)
                throw new Exception("Fast texture loading encountered zero-size texture: " + name);
            if (size < 1048576) size = 1048576L;
            size += 1048576;
            long rounded = size;
            rounded--;
            rounded |= rounded >> 1;
            rounded |= rounded >> 2;
            rounded |= rounded >> 4;
            rounded |= rounded >> 8;
            rounded |= rounded >> 16;
            rounded |= rounded >> 32;
            rounded++;
            size += (long)((double)(rounded - size) * 0.3);
            if (size >= limit || size >= uint.MaxValue) size = limit;
            while (true)
            {
                if (size <= limit ? used + size > limit : usedCount > 1)
                {
                    free.Wait();
                    free.Reset();
                    continue;
                }

                lock (loadLock)
                {
                    if (size <= limit ? used + size > limit : usedCount > 1) continue;
                    finish.Reset();
                    usedCount++;
                    used += textureSize = (uint)size;
                    textureLoading = true;
                    break;
                }
            }
        }

        internal void Free(ref bool textureCounted, ref bool textureLoading, ref uint textureSize)
        {
            lock (loadLock)
            {
                if (!textureLoading)
                {
                    if (textureCounted)
                    {
                        totalCount--;
                        if (totalCount == 0) finish.Set();
                        textureCounted = false;
                    }

                    return;
                }

                uint size = textureSize;
                textureLoading = false;
                textureSize = 0u;
                used -= size;
                usedCount--;
                totalCount--;
                if (totalCount == 0) finish.Set();
                free.Set();
                textureCounted = false;
            }
        }

        public void WaitFinish() => WaitFinish(null);

        public void WaitFinish(Action pump)
        {
            lock (loadLock) enabled = false;
            if (pump == null)
            {
                finish.Wait();
                return;
            }

            while (!finish.IsSet)
            {
                pump();
                // Yield to decoders when the owner queue is empty; completion has no timeout.
                finish.Wait(1);
            }
        }
    }
}
