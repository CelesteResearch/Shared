using System;

namespace Celeste.Simulation.Rendering.Lighting
{
    public interface ILightComponentOwner : ILightOwner
    {
        event Action<EntityLightVisual, float, float> LightComponentUpdated;
    }
}
