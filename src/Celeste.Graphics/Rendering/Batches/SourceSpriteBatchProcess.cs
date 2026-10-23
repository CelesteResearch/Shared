using System;
using System.Collections.Generic;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Rendering.Batches
{
    // Original class-static SpriteBatch data owned by the one game process.
    public sealed class SourceSpriteBatchProcess
    {
        private readonly SourceStockEffectResources stockResources;
        private readonly object initializationLock = new();
        private bool initializing;
        private bool initialized;
        private Exception initializationFailure;

        internal byte[] SpriteEffectCode { get; private set; }
        internal short[] IndexData { get; private set; }
        internal IComparer<IntPtr> TextureCompare { get; private set; }
        internal IComparer<IntPtr> BackToFrontCompare { get; private set; }
        internal IComparer<IntPtr> FrontToBackCompare { get; private set; }

        public SourceSpriteBatchProcess(SourceStockEffectResources stockResources)
        {
            this.stockResources = stockResources;
        }

        internal void EnsureInitialized()
        {
            lock (initializationLock)
            {
                if (initializationFailure != null)
                {
                    throw initializationFailure;
                }

                if (initialized || initializing)
                {
                    return;
                }

                initializing = true;
                try
                {
                    SpriteEffectCode = stockResources.SpriteEffect;
                    IndexData = GenerateIndexArray();
                    TextureCompare = new TextureComparer();
                    BackToFrontCompare = new BackToFrontComparer();
                    FrontToBackCompare = new FrontToBackComparer();
                    initialized = true;
                }
                catch (Exception failure)
                {
                    initializationFailure =
                        new TypeInitializationException("Microsoft.Xna.Framework.Graphics.SpriteBatch", failure);
                    throw initializationFailure;
                }
                finally
                {
                    initializing = false;
                }
            }
        }

        private sealed class TextureComparer : IComparer<IntPtr>
        {
            public unsafe int Compare(IntPtr first, IntPtr second)
            {
                SourceSpriteInfo* a = (SourceSpriteInfo*)first;
                SourceSpriteInfo* b = (SourceSpriteInfo*)second;
                return a->TextureHash.CompareTo(b->TextureHash);
            }
        }

        private sealed class BackToFrontComparer : IComparer<IntPtr>
        {
            public unsafe int Compare(IntPtr first, IntPtr second)
            {
                SourceSpriteInfo* a = (SourceSpriteInfo*)first;
                SourceSpriteInfo* b = (SourceSpriteInfo*)second;
                return b->Depth.CompareTo(a->Depth);
            }
        }

        private sealed class FrontToBackComparer : IComparer<IntPtr>
        {
            public unsafe int Compare(IntPtr first, IntPtr second)
            {
                SourceSpriteInfo* a = (SourceSpriteInfo*)first;
                SourceSpriteInfo* b = (SourceSpriteInfo*)second;
                return a->Depth.CompareTo(b->Depth);
            }
        }

        private static short[] GenerateIndexArray()
        {
            var indices = new short[12288];
            int index = 0;
            int vertex = 0;
            while (index < 12288)
            {
                indices[index] = (short)vertex;
                indices[index + 1] = (short)(vertex + 1);
                indices[index + 2] = (short)(vertex + 2);
                indices[index + 3] = (short)(vertex + 3);
                indices[index + 4] = (short)(vertex + 2);
                indices[index + 5] = (short)(vertex + 1);
                index += 6;
                vertex += 4;
            }

            return indices;
        }
    }
}
