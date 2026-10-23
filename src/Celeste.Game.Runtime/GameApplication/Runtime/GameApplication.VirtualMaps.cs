using Celeste.Core.Maps.Grids;
using Celeste.Everest.Content.Maps.Grids;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceVirtualMapFactoryEnvironment
    {
        public IVirtualMapFactory VirtualMapFactory => SourceProfile == GameProfile.Original
            ? Core.Maps.Grids.VirtualMapFactory.Instance
            : EverestVirtualMapFactory.Instance;
    }
}
