using System;

namespace Celeste.Core.Framework.Components
{
    public sealed class SourceGameComponentCollectionEventArgs(ISourceGameComponent component) : EventArgs
    {
        public ISourceGameComponent GameComponent { get; private set; } = component;
    }
}
