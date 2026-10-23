using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Scene.Following;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries
{
// Required actual strawberry producer is owned by the collectible construction family.
    public static class OriginalStrawberryTransfer
    {
        private static List<OriginalStrawberryState> storedBerries;
        private static List<Vector2> storedOffsets;

        public static void StoreStrawberries(LeaderState leader)
        {
            storedBerries = new List<OriginalStrawberryState>();
            storedOffsets = new List<Vector2>();
            foreach (var follower in leader.Followers)
            {
                if (follower.Entity is OriginalStrawberryState strawberry)
                {
                    storedBerries.Add(strawberry);
                    storedOffsets.Add(strawberry.Position - ((ISourceEntityPosition)leader.Entity).Position);
                }
            }

            foreach (var strawberry in storedBerries)
            {
                leader.Followers.Remove(strawberry.Follower);
                strawberry.Follower.Leader = null;
                strawberry.Tags |= OriginalSceneTags.Global;
            }
        }

        public static void RestoreStrawberries(LeaderState leader)
        {
            leader.PastPoints.Clear();
            for (int i = 0; i < storedBerries.Count; i++)
            {
                var strawberry = storedBerries[i];
                leader.GainFollower(strawberry.Follower);
                strawberry.Position = ((ISourceEntityPosition)leader.Entity).Position + storedOffsets[i];
                strawberry.Tags &= ~OriginalSceneTags.Global;
            }
        }
    }
}
