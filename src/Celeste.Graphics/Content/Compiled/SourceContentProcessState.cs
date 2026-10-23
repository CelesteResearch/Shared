using System;
using System.Collections.Generic;
using Celeste.Audio.Framework;
using Celeste.Audio.IO;
using Celeste.Core.Diagnostics;
using Celeste.Core.IO.Content;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed class SourceContentProcessState
    {
        internal readonly ISourceExtremaArithmetic ExtremaArithmetic;
        internal readonly ISourceVectorArithmetic VectorArithmetic;
        internal readonly ISourceAudioEnvironment AudioEnvironment;
        internal readonly ISourceTheoraEnvironment TheoraEnvironment;
        internal readonly ISourceFnaLoggingEnvironment LoggingEnvironment;
        internal readonly SourceStockEffectResources StockEffects;
        public uint[] LzxPositionBase;
        public byte[] LzxExtraBits;
        internal readonly byte[] XnbHeader = new byte[4];

        internal List<char> targetPlatformIdentifiers =
            ['w', 'x', 'm', 'i', 'a', 'd', 'X', 'W', 'n', 'u', 'p', 'M', 'r', 'P', 'g', 'l'];

        internal readonly string[] effectExtensions = [".fxb"];

        internal readonly string[] texture2DExtensions =
            [".png", ".jpg", ".jpeg", ".dds", ".qoi", ".bmp", ".gif", ".tga", ".tif", ".tiff"];

        internal readonly string[] textureCubeExtensions = [".dds"];
        internal readonly string[] soundEffectExtensions = [".wav"];
        internal readonly IContentSource ContentIo;
        internal readonly string[] ReaderNestedMark;
        internal bool ReaderFalseFlag;
        internal Dictionary<string, Func<SourceContentTypeReader>> ReaderTypeCreators;
        internal readonly object ReaderLock;
        internal readonly Dictionary<Type, SourceContentTypeReader> ReaderCache;
        internal readonly string ReaderAssemblyName;
        internal readonly ISourceContentTypeIdentity TypeIdentity;

        // ReSharper disable once ConvertToPrimaryConstructor
        public SourceContentProcessState(IContentSource io, ISourceContentTypeIdentity actualTypes,
            ISourceExtremaArithmetic actualArithmetic, ISourceVectorArithmetic actualVectorArithmetic,
            ISourceAudioEnvironment actualAudioEnvironment, ISourceTheoraEnvironment actualTheoraEnvironment,
            ISourceFnaLoggingEnvironment actualLoggingEnvironment, SourceStockEffectResources actualStockEffects)
        {
            ExtremaArithmetic = actualArithmetic;
            VectorArithmetic = actualVectorArithmetic;
            AudioEnvironment = actualAudioEnvironment;
            TheoraEnvironment = actualTheoraEnvironment;
            LoggingEnvironment = actualLoggingEnvironment;
            StockEffects = actualStockEffects;
            ContentIo = io;
            TypeIdentity = actualTypes;
            ReaderNestedMark = ["[["];
            ReaderFalseFlag = false;
            ReaderTypeCreators = new();
            ReaderLock = new();
            ReaderCache = new(255);
            ReaderAssemblyName = typeof(SourceContentTypeReaderManager).Assembly.FullName;
        }

        private readonly object ContentManagerLock = new();
        private readonly List<WeakReference> ContentManagers = [];

        internal void AddContentManager(SourceContentManager contentManager)
        {
            lock (ContentManagerLock)
            {
                var flag = false;
                for (var num = ContentManagers.Count - 1; num >= 0; num--)
                {
                    var weakReference = ContentManagers[num];
                    if (weakReference.Target == contentManager)
                        flag = true;
                    if (!weakReference.IsAlive)
                        ContentManagers.RemoveAt(num);
                }

                if (!flag)
                    ContentManagers.Add(new(contentManager));
            }
        }

        internal void RemoveContentManager(SourceContentManager contentManager)
        {
            lock (ContentManagerLock)
            {
                for (var num = ContentManagers.Count - 1; num >= 0; num--)
                {
                    var weakReference = ContentManagers[num];
                    if (!weakReference.IsAlive || weakReference.Target == contentManager)
                        ContentManagers.RemoveAt(num);
                }
            }
        }

        public void ClearReaderTypeCreators()
        {
            ReaderTypeCreators.Clear();
        }
    }
}
