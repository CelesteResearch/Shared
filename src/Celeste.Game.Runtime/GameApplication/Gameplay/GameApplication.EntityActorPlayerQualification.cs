using System;
using Celeste.Game.Runtime.Reflection.Members;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private bool sourceEntityActorPlayerBindingsPublished;

        internal void PublishSourceEntityActorPlayerBindings()
        {
            if (sourceEntityActorPlayerBindingsPublished)
                throw new InvalidOperationException(
                    "The canonical Entity/Actor/Player source bindings are already published.");
            var entityDefinition = SourceMembers.GetOriginalTypeDefinition(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Entity");
            SourceEntityActorPlayerMemberBindings.Register(SourceMembers, entityDefinition.AssemblyIdentity);
            sourceEntityActorPlayerBindingsPublished = true;
        }
    }
}
