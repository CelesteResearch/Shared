using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Formats.Graphics.Tiles;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles.Autotiling;

namespace Celeste.Game.Execution.Graphics
{
    public sealed class OriginalAutotilerConstruction : ISourceAutotilerConstruction
    {
        public Autotiler Create(ISourceEngineContext engine, string filename, XmlDocument xml,
            ISourceAutotilingResources resources)
        {
            var rules = AutotileXmlCompiler.Compile(xml,
                ((ISourceGameGraphicsResources)resources).GameAtlas);
            return new(rules, engine, null, resources);
        }
    }
}
