using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed partial class SourceContentReader : BinaryReader
    {
        internal int version;

        internal char platform;

        private SourceContentManager contentManager;

        private Action<IDisposable> recordDisposableObject;

        private SourceContentTypeReaderManager typeReaderManager;

        private SourceContentTypeReader[] typeReaders;

        private string assetName;

        private int sharedResourceCount;

        private object[] sharedResources;

        private List<Action<object>>[] sharedResourceFixups;

        public SourceContentManager ContentManager => contentManager;

        public string AssetName => assetName;

        internal SourceContentTypeReader[] TypeReaders => typeReaders;

        internal SourceContentReader(SourceContentManager manager, Stream stream, string assetName, int version,
            char platform, Action<IDisposable> recordDisposableObject)
            : base(stream)
        {
            this.recordDisposableObject = recordDisposableObject;
            contentManager = manager;
            this.assetName = assetName;
            this.version = version;
            this.platform = platform;
        }
    }
}
