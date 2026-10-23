using System;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Simulation.Rendering.Lighting
{
    public interface IDynamicLightOwner : ILightComponentOwner
    {
        event Action<EntityLightVisual> LightComponentAdded;

        event Action<EntityBloomVisual>
            BloomComponentAdded;
    }
}
