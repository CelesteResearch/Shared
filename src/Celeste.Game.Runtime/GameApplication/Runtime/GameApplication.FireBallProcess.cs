using System;
using Celeste.Everest.Gameplay.Hazards.FireBalls;
using Celeste.Game.Gameplay.Hazards.FireBalls;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalFireBallProcess
    {
        private IOriginalFireBallPathPolicy sourceFireBallPath;

        public IOriginalFireBallPathPolicy FireBallPath => sourceFireBallPath ??
                                                           throw new InvalidOperationException(
                                                               "The actual FireBall path policy is not constructed.");

        internal void ConstructSourceFireBallProcess()
        {
            if (sourceFireBallPath != null)
                throw new InvalidOperationException("The actual FireBall path policy is already constructed.");
            if (SourceProfile == GameProfile.Original)
                sourceFireBallPath = new OriginalFireBallPathPolicy();
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourceFireBallPath = new InstalledFireBallPathPolicy();
            else
                throw new InvalidOperationException("No actual FireBall path policy exists for this source profile.");
        }
    }
}
