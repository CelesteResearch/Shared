using System;
using Celeste.Core.Components;
using Celeste.Scene.Components;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Hair
{
    public static class PlayerHairScenePass
    {
        public static void Update(SceneComponentTracker tracker, float deltaTime)
        {
            if (tracker == null) throw new ArgumentNullException(nameof(tracker));
            // This is the actual Tracker list, including its duplicates and live order.
            foreach (var component in tracker.GetTrackedComponents("Celeste.PlayerHair"))
            {
                if (component is not PlayerHair hair)
                    throw new InvalidOperationException("The tracked PlayerHair is not its actual source object.");
                if (!hair.Active) continue;
                if (((ISourceEntityUpdate)hair.Entity).Active) hair.AfterUpdate();
            }
        }
    }
}
