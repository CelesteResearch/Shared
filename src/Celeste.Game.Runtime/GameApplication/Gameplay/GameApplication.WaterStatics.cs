using System;
using Celeste.Game.Profiles;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Everest.Gameplay.Environment.Water;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalWaterStaticsEnvironment
    {
        private IOriginalWaterStatics sourceWaterStatics;

        public IOriginalWaterStatics WaterStatics => sourceWaterStatics ??
                                                     throw new InvalidOperationException(
                                                         "The actual Water static fields are not published.");

        public void ConstructSourceWaterStatics()
        {
            if (sourceWaterStatics != null)
                throw new InvalidOperationException("The actual Water static fields are already constructed.");
            if (SourceProfile == GameProfile.Original)
                sourceWaterStatics = new OriginalWaterStatics(engine);
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourceWaterStatics = new EverestWaterStatics(engine);
            else throw new InvalidOperationException("A supported source profile is required.");
        }
    }
}
