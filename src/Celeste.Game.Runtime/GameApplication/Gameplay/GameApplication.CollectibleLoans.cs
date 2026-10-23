using System;
using Celeste.Core.Maps;
using Celeste.Core.Randomness;
using Celeste.Everest.Content.Extensions.Collectibles;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Collectibles.Strawberries.Points;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Presentation.Mountain.Views;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceInstalledStrawberryRegistryEnvironment,
        IOriginalMountainViewsEnvironment, IOriginalStrawberryProcess,
        IOriginalStrawberryPointsProcess
    {
        private InstalledStrawberryRegistryState sourceStrawberryRegistry;
        private OriginalMountainViewsProcess sourceMountainViews;

        public InstalledStrawberryRegistryState StrawberryRegistry => sourceStrawberryRegistry ??
                                                                      throw new InvalidOperationException(
                                                                          "The actual installed strawberry registry is not constructed.");

        public OriginalMountainViewsProcess MountainViews => sourceMountainViews ??
                                                             throw new InvalidOperationException(
                                                                 "The original Mountain views process is not constructed.");

        public ISourceRandom SpriteRandom => RandomProcess.Random;

        public bool CheckStrawberry(MapEntityId id)
        {
            return SaveContext.CheckStrawberry(id);
        }

        public void RegisterMoonBerryAchievement()
        {
            Statistics.Achievements.Register(OriginalAchievement.WOW);
        }

        public void RegisterOneUpAchievement()
        {
            Statistics.Achievements.Register(OriginalAchievement.ONEUP);
        }

        public void ConstructSourceMountainViews()
        {
            if (sourceMountainViews != null)
                throw new InvalidOperationException("The original Mountain views process is already constructed.");
            sourceMountainViews = new(this);
        }

        public void ConstructSourceInstalledStrawberryRegistry()
        {
            if (sourceStrawberryRegistry != null)
                throw new InvalidOperationException("The actual installed strawberry registry is already constructed.");
            sourceStrawberryRegistry = new();
        }
    }
}
