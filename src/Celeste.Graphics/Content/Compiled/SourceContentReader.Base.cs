using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed partial class SourceContentReader : BinaryReader
    {
        internal int version;

        internal char platform;

        private readonly Action<IDisposable> recordDisposableObject;

        private SourceContentTypeReaderManager typeReaderManager;

        private SourceContentTypeReader[] typeReaders;

        private int sharedResourceCount;

        private object[] sharedResources;

        private List<Action<object>>[] sharedResourceFixups;

        public SourceContentManager ContentManager { get; }

        public string AssetName { get; }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        internal SourceContentTypeReader[] TypeReaders => typeReaders;

        internal SourceContentReader(SourceContentManager manager, Stream stream, string assetName, int version,
            char platform, Action<IDisposable> recordDisposableObject)
            : base(stream)
        {
            this.recordDisposableObject = recordDisposableObject;
            ContentManager = manager;
            AssetName = assetName;
            this.version = version;
            this.platform = platform;
        }
    }
}
