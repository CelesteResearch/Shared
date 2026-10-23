using System;
using System.Numerics;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.Crushing
{
    public interface ICrushingSolidCollisionCallbackSource
    {
        Action<Vector2, Vector2, ISourcePlatformEntity> CrushingCollisionCallback { get; set; }
    }
}
