using System;
using Celeste.Everest.Menus.Overworld;
using Celeste.Game.Profiles;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalOverworldLoaderEnvironment, IOriginalOverworldEnvironment
    {
        private IOriginalOverworldLoaderFactory sourceOverworldLoaders;
        private IOriginalOverworldFactory sourceOverworlds;

        public IOriginalOverworldFactory Overworlds => sourceOverworlds ??
                                                       throw new InvalidOperationException(
                                                           "The actual Overworld factory is not constructed.");

        public IOriginalOverworldLoaderFactory OverworldLoaders => sourceOverworldLoaders ??
                                                                   throw new InvalidOperationException(
                                                                       "The actual Overworld loader factory is not constructed.");

        public void ConstructSourceOverworldLoaders()
        {
            if (sourceOverworldLoaders != null || sourceOverworlds != null)
                throw new InvalidOperationException("The actual Overworld loader factory is already constructed.");
            sourceOverworldLoaders = new OriginalOverworldLoaderFactory(this);
            sourceOverworlds = SourceProfile == GameProfile.InstalledEverest
                ? (IOriginalOverworldFactory)new EverestOverworldFactory(this)
                : new OriginalOverworldFactory(this);
        }
    }
}
