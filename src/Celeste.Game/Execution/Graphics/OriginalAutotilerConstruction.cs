using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Formats.Graphics.Tiles;

namespace Celeste.Game.Execution.Graphics
{
    public sealed class OriginalAutotilerConstruction : ISourceAutotilerConstruction
    {
        public Autotiler Create(ISourceEngineContext engine, string filename, XmlDocument xml,
            ISourceAutotilingResources resources)
        {
            var rules = AutotileXmlCompiler.Compile(xml,
                ((Celeste.Graphics.Content.ISourceGameGraphicsResources)resources).GameAtlas);
            return new Autotiler(rules, engine, null, resources);
        }
    }
}
