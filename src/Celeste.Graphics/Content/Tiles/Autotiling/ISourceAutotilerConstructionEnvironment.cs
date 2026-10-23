using System.Xml;
using Celeste.Core.Scheduling;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public interface ISourceAutotilerConstructionEnvironment
    {
        ISourceAutotilerConstruction AutotilerConstruction { get; }
    }
}
