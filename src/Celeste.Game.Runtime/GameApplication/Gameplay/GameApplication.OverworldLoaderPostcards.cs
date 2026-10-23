using Celeste.Everest.Menus.Overworld;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalOverworldLoaderPostcardEnvironment
    {
        private IOriginalOverworldLoaderPostcardPolicy sourceOverworldLoaderPostcards;

        public IOriginalOverworldLoaderPostcardPolicy OverworldLoaderPostcards => sourceOverworldLoaderPostcards ??=
            SourceProfile == GameProfile.Original
                ? new OriginalOverworldLoaderPostcardPolicy()
                : new EverestOverworldLoaderPostcardPolicy();
    }
}
