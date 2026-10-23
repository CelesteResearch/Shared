using System;

namespace Celeste.Core.Framework.Components
{
    public sealed class SourceGameComponentCollectionEventArgs : EventArgs
    {
        public ISourceGameComponent GameComponent { get; private set; }
        public SourceGameComponentCollectionEventArgs(ISourceGameComponent component) => GameComponent = component;
    }
}
