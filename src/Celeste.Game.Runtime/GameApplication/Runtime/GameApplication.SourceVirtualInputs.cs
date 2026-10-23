using System;
using Celeste.Everest.Input;
using Celeste.Game.Profiles;
using Celeste.Input.Bindings;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceVirtualInputConstructionEnvironment
    {
        private ISourceVirtualInputConstruction sourceVirtualInputConstruction;

        public ISourceVirtualInputConstruction VirtualInputConstruction => sourceVirtualInputConstruction ??
                                                                           throw new InvalidOperationException(
                                                                               "Source virtual input construction is not selected.");

        public void ConstructSourceVirtualInputConstruction()
        {
            if (sourceVirtualInputConstruction != null)
                throw new InvalidOperationException("Source virtual input construction is already selected.");
            if (SourceProfile == GameProfile.Original)
                sourceVirtualInputConstruction = new OriginalVirtualInputConstruction();
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourceVirtualInputConstruction = new InstalledVirtualInputConstruction();
            else throw new InvalidOperationException("The source profile is not selected.");
        }
    }
}
