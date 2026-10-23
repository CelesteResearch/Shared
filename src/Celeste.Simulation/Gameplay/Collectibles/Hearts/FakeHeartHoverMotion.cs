using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Simulation.Gameplay.Collectibles.Hearts
{
    public static class FakeHeartHoverMotion
    {
        public static Vector2 Offset(float timer, Vector2 moveWiggleDirection, WigglerComponent moveWiggler)
        {
            return Vector2.UnitY * (float)Math.Sin(timer * 2f) * 2f +
                   moveWiggleDirection * moveWiggler.Value * -8f;
        }

        public static bool AdvanceRespawnTimer(ref float respawnTimer, ISourceEngineContext engine)
        {
            if (respawnTimer > 0f)
            {
                respawnTimer -= engine.DeltaTime;
                return respawnTimer <= 0f;
            }

            return false;
        }
    }
}
