using System;

namespace Celeste.Core.Framework.Loading
{
    public sealed class SourceLoadingWorkInfo(
        string name,
        ISourceLoadingContentContext contentContext = null,
        bool blocksSourceUpdates = false)
    {
        public string Name { get; }
            = name ?? throw new ArgumentNullException(nameof(name));

        public ISourceLoadingContentContext ContentContext { get; }
            = contentContext;

        public bool BlocksSourceUpdates { get; }
            = blocksSourceUpdates;
    }
}
