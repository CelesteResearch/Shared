using System;
using JetBrains.Annotations;

namespace Celeste.Simulation.Diagnostics.Frames
{
    // Owned by one TAS run and carried across host/scene replacements. Reference
    // identity is used only to detect a new shared simulation scene, never written
    // to a trace. A savestate seek back creates a new generation as well.
    public sealed class FrameSceneGeneration
    {
        private RoomPlayerSession lastPlayer;
        private object lastRoom;
        private long lastFeed = -1;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private int generation;

        public int Current => generation;

        // Call after an explicit world restore or engine scene replacement even
        // if the feed and both shared object identities happen to be reused.
        public void BeginNewSceneEpoch()
        {
            lastPlayer = null;
            lastRoom = null;
            lastFeed = -1;
        }

        public int Observe(RoomPlayerSession player, object room, long fedInputIndex)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (room == null) throw new ArgumentNullException(nameof(room));
            if (fedInputIndex < 0) throw new ArgumentOutOfRangeException(nameof(fedInputIndex));
            if (!ReferenceEquals(lastPlayer, player) || !ReferenceEquals(lastRoom, room) ||
                fedInputIndex < lastFeed)
            {
                checked
                {
                    generation++;
                }

                lastPlayer = player;
                lastRoom = room;
            }

            lastFeed = fedInputIndex;
            return generation;
        }
    }
}
