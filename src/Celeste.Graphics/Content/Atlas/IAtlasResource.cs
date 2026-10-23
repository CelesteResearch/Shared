using System;

namespace Celeste.Graphics.Content.Atlas
{
    // Atlas metadata and the lifetime of its backing device pages travel together.
    public interface IAtlasResource : IDisposable
    {
        AtlasData Atlas { get; }
    }
}
