using System.Xml;
using Celeste.Core.Scheduling;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public interface ISourceAutotilerConstruction
    {
        Autotiler Create(ISourceEngineContext engine, string filename, XmlDocument xml,
            ISourceAutotilingResources resources);
    }
}
