using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed class EverestDecalRegistrationPolicy : IOriginalDecalRegistrationPolicy
    {
        private readonly IOriginalDecalRegistrationPolicy vanilla;
        private readonly IEverestDecalRegistryEnvironment process;

        public EverestDecalRegistrationPolicy(IOriginalDecalRegistrationPolicy vanilla,
            IEverestDecalRegistryEnvironment process)
        {
            this.vanilla = vanilla;
            this.process = process;
        }

        public void Apply(OriginalDecalEntity decal, int depthBeforeAdded)
        {
            vanilla.Apply(decal, depthBeforeAdded);
            if (decal.DepthSetByPlacement) decal.Depth = depthBeforeAdded;
            process.DecalRegistry.Apply(decal);
        }

        public void AfterAwake(OriginalDecalEntity decal)
        {
            if (decal.StaticMover?.Platform == null &&
                ((ISourceDecalAttachmentScene)decal.Scene).DecalAttachmentHistory.Contains(decal.Name, decal.Position))
                decal.RemoveSelf();
        }
    }
}
