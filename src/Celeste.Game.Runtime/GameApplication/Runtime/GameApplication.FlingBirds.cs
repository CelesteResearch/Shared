using System;
using Celeste.Core.Gameplay.FlingBirds;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceFlingBirdEnvironment
    {
        private SourceFlingBirdProcessState sourceFlingBirdStatics;

        public SourceFlingBirdProcessState FlingBirdStatics => sourceFlingBirdStatics ??
                                                               throw new InvalidOperationException(
                                                                   "The source FlingBird fields are not published.");

        public void ConstructSourceFlingBirdStatics()
        {
            if (sourceFlingBirdStatics != null)
                throw new InvalidOperationException("The source FlingBird fields are already published.");
            if (SourceProfile == GameProfile.Original)
                sourceFlingBirdStatics = new OriginalSourceFlingBirdProcessState();
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourceFlingBirdStatics = new InstalledSourceFlingBirdProcessState();
            else throw new InvalidOperationException("The source profile is not selected.");
        }
    }
}
