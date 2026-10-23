using System;
using Celeste.Core.Reflection.Assemblies;
using Celeste.Game.Profiles;
using Celeste.Game.Runtime.Reflection;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceExternalBaseClosureEnvironment
    {
        private SourceExternalBaseClosureFacts sourceExternalBaseClosureFacts;

        public SourceExternalBaseClosureFacts ExternalBaseClosureFacts => sourceExternalBaseClosureFacts ??
                                                                          throw new InvalidOperationException(
                                                                              "The selected source external assembly closure has not been published.");

        internal void ConstructSourceExternalBaseClosureFacts()
        {
            if (sourceExternalBaseClosureFacts != null)
                throw new InvalidOperationException(
                    "The selected source external assembly closure is already published.");
            sourceExternalBaseClosureFacts = SourceProfile == GameProfile.Original
                ? SourceExternalBaseClosurePublication.CreateOriginal4()
                : SourceExternalBaseClosurePublication.CreateInstalled8();
        }
    }
}
