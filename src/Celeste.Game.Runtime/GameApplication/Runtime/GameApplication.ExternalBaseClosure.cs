using System;
using Celeste.Core.Reflection.Assemblies;
using Celeste.Game.Profiles;

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
                ? global::Celeste.Game.Runtime.Reflection.SourceExternalBaseClosurePublication.CreateOriginal4()
                : global::Celeste.Game.Runtime.Reflection.SourceExternalBaseClosurePublication.CreateInstalled8();
        }
    }
}
