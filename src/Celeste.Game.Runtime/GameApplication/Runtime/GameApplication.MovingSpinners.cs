using System;
using Celeste.Game.Gameplay.Hazards.Spinners.Moving;
using Celeste.Everest.Gameplay.Hazards.Spinners.Moving;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalMovingSpinnerEnvironment
    {
        private IOriginalMovingSpinnerFactory sourceMovingSpinnerFactory;

        public IOriginalMovingSpinnerFactory MovingSpinnerFactory => sourceMovingSpinnerFactory ??
                                                                     throw new InvalidOperationException(
                                                                         "The actual source moving spinner factory has not been constructed.");

        private void ConstructSourceMovingSpinners()
        {
            if (sourceMovingSpinnerFactory != null)
                throw new InvalidOperationException("The actual source moving spinner factory is already constructed.");
            sourceMovingSpinnerFactory = SourceProfile == GameProfile.Original
                ? new OriginalMovingSpinnerFactory()
                : new InstalledMovingSpinnerFactory();
        }
    }
}
