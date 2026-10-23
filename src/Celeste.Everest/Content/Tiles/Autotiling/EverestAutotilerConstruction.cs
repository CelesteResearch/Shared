using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Tiles.Autotiling;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    public sealed class EverestAutotilerConstruction : ISourceAutotilerConstruction
    {
        public Autotiler Create(ISourceEngineContext engine, string filename, XmlDocument xml,
            ISourceAutotilingResources resources) => new EverestAutotiler(engine, filename, xml);
    }
}
