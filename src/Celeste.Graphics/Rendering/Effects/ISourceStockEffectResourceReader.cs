using System.IO;

namespace Celeste.Graphics.Rendering.Effects
{
    public interface ISourceStockEffectResourceReader
    {
        Stream OpenResource(string manifestResourceName);
    }
}
