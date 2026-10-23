using Celeste.Scene.Entities;

namespace Celeste.Simulation.Gameplay.Hazards.TriggerSpikes
{
    public static class TriggerSpikeCollision
    {
        public static void GetPlayerCollideIndices(RoomPlayerSession player, SceneEntityState spikes,
            TriggerSpikesDirection direction, float spacing, out int minIndex, out int maxIndex,
            bool evenIfSameDirection = false)
        {
            minIndex = maxIndex = -1;
            switch (direction)
            {
                case TriggerSpikesDirection.Up:
                    if (player.Data.Motion.Normal.Speed.Y >= 0f || evenIfSameDirection)
                    {
                        minIndex = (int)((player.Left - spikes.Left) / spacing);
                        maxIndex = (int)((player.Right - spikes.Left) / spacing);
                    }

                    break;
                case TriggerSpikesDirection.Down:
                    if (player.Data.Motion.Normal.Speed.Y <= 0f || evenIfSameDirection)
                    {
                        minIndex = (int)((player.Left - spikes.Left) / spacing);
                        maxIndex = (int)((player.Right - spikes.Left) / spacing);
                    }

                    break;
                case TriggerSpikesDirection.Left:
                    if (player.Data.Motion.Normal.Speed.X >= 0f || evenIfSameDirection)
                    {
                        minIndex = (int)((player.Top - spikes.Top) / spacing);
                        maxIndex = (int)((player.Bottom - spikes.Top) / spacing);
                    }

                    break;
                case TriggerSpikesDirection.Right:
                    if (player.Data.Motion.Normal.Speed.X <= 0f || evenIfSameDirection)
                    {
                        minIndex = (int)((player.Top - spikes.Top) / spacing);
                        maxIndex = (int)((player.Bottom - spikes.Top) / spacing);
                    }

                    break;
            }
        }
    }
}
