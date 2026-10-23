using Celeste.Core.Components;

namespace Celeste.Game.Entities.Metadata
{
// Original Entity has no Everest SID-to-runtime-type registration extension.
    public sealed class OriginalEntitySourceDataRegistration : ISourceEntitySourceDataRegistration
    {
        public void Register(object actualActor, object actualSourceData)
        {
        }
    }
}
