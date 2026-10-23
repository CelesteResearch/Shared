using System;

namespace Celeste.Core.Framework.Loading
{
    public sealed class SourceLoadingWorkInfo
    {
        public string Name { get; }
        public ISourceLoadingContentContext ContentContext { get; }
        public bool BlocksSourceUpdates { get; }

        public SourceLoadingWorkInfo(string name, ISourceLoadingContentContext contentContext = null,
            bool blocksSourceUpdates = false)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ContentContext = contentContext;
            BlocksSourceUpdates = blocksSourceUpdates;
        }
    }
}
