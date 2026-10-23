using System.IO;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceStockEffectEmbeddedReader : ISourceStockEffectResourceReader
    {
        public Stream OpenResource(string manifestName)
            => typeof(SourceEffect).Assembly.GetManifestResourceStream(manifestName);
    }
}
