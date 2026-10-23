using Celeste.Core.IO.Content;
using System;
using System.Collections.Generic;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed class SourceContentProcessState
    {
        internal readonly global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic ExtremaArithmetic;
        internal readonly global::Celeste.Core.Mathematics.ISourceVectorArithmetic VectorArithmetic;
        internal readonly global::Celeste.Audio.Framework.ISourceAudioEnvironment AudioEnvironment;
        internal readonly global::Celeste.Audio.IO.ISourceTheoraEnvironment TheoraEnvironment;
        internal readonly global::Celeste.Core.Diagnostics.ISourceFnaLoggingEnvironment LoggingEnvironment;
        internal readonly global::Celeste.Graphics.Rendering.Effects.SourceStockEffectResources StockEffects;
        public uint[] LzxPositionBase;
        public byte[] LzxExtraBits;
        internal readonly byte[] XnbHeader = new byte[4];

        internal List<char> targetPlatformIdentifiers = new List<char>
        {
            'w', 'x', 'm', 'i', 'a', 'd', 'X', 'W', 'n', 'u',
            'p', 'M', 'r', 'P', 'g', 'l'
        };

        internal readonly string[] effectExtensions = new string[1] { ".fxb" };

        internal readonly string[] texture2DExtensions = new string[10]
            { ".png", ".jpg", ".jpeg", ".dds", ".qoi", ".bmp", ".gif", ".tga", ".tif", ".tiff" };

        internal readonly string[] textureCubeExtensions = new string[1] { ".dds" };

        internal readonly string[] soundEffectExtensions = new string[1] { ".wav" };


        internal readonly IContentSource ContentIo;

        internal readonly string[] ReaderNestedMark;
        internal bool ReaderFalseFlag;
        internal Dictionary<string, Func<SourceContentTypeReader>> ReaderTypeCreators;
        internal readonly object ReaderLock;
        internal readonly Dictionary<Type, SourceContentTypeReader> ReaderCache;
        internal readonly string ReaderAssemblyName;
        internal readonly ISourceContentTypeIdentity TypeIdentity;

        public SourceContentProcessState(IContentSource io, ISourceContentTypeIdentity actualTypes,
            global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic actualArithmetic,
            global::Celeste.Core.Mathematics.ISourceVectorArithmetic actualVectorArithmetic,
            global::Celeste.Audio.Framework.ISourceAudioEnvironment actualAudioEnvironment,
            global::Celeste.Audio.IO.ISourceTheoraEnvironment actualTheoraEnvironment,
            global::Celeste.Core.Diagnostics.ISourceFnaLoggingEnvironment actualLoggingEnvironment,
            global::Celeste.Graphics.Rendering.Effects.SourceStockEffectResources actualStockEffects)
        {
            ExtremaArithmetic = actualArithmetic;
            VectorArithmetic = actualVectorArithmetic;
            AudioEnvironment = actualAudioEnvironment;
            TheoraEnvironment = actualTheoraEnvironment;
            LoggingEnvironment = actualLoggingEnvironment;
            StockEffects = actualStockEffects;
            ContentIo = io;
            TypeIdentity = actualTypes;
            ReaderNestedMark = new string[1] { "[[" };
            ReaderFalseFlag = false;
            ReaderTypeCreators = new Dictionary<string, Func<SourceContentTypeReader>>();
            ReaderLock = new object();
            ReaderCache = new Dictionary<Type, SourceContentTypeReader>(255);
            ReaderAssemblyName = typeof(SourceContentTypeReaderManager).Assembly.FullName;
        }

        private object ContentManagerLock = new object();
        private List<WeakReference> ContentManagers = new List<WeakReference>();

        internal void AddContentManager(SourceContentManager contentManager)
        {
            lock (ContentManagerLock)
            {
                bool flag = false;
                for (int num = ContentManagers.Count - 1; num >= 0; num--)
                {
                    WeakReference weakReference = ContentManagers[num];
                    if (weakReference.Target == contentManager)
                    {
                        flag = true;
                    }

                    if (!weakReference.IsAlive)
                    {
                        ContentManagers.RemoveAt(num);
                    }
                }

                if (!flag)
                {
                    ContentManagers.Add(new WeakReference(contentManager));
                }
            }
        }

        internal void RemoveContentManager(SourceContentManager contentManager)
        {
            lock (ContentManagerLock)
            {
                for (int num = ContentManagers.Count - 1; num >= 0; num--)
                {
                    WeakReference weakReference = ContentManagers[num];
                    if (!weakReference.IsAlive || weakReference.Target == contentManager)
                    {
                        ContentManagers.RemoveAt(num);
                    }
                }
            }
        }

        public void ClearReaderTypeCreators() => ReaderTypeCreators.Clear();
    }
}
