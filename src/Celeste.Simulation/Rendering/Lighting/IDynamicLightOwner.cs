using System;

namespace Celeste.Simulation.Rendering.Lighting
{
    public interface IDynamicLightOwner : ILightComponentOwner
    {
        event Action<EntityLightVisual> LightComponentAdded;

        event Action<global::Celeste.Simulation.Presentation.PostProcessing.Bloom.EntityBloomVisual>
            BloomComponentAdded;
    }
}
