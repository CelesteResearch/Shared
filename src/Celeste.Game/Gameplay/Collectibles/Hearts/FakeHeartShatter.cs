using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Scene.Entities;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Collectibles.Hearts
{
    public static class FakeHeartShatter
    {
        public static void Process(ISourceEngineContext engine, SceneEntityState owner, RoomPlayerSession player,
            float angle, float respawnTime, ref float respawnTimer)
        {
            if (owner.Collidable)
            {
                owner.Collidable = owner.Visible = false;
                respawnTimer = respawnTime;
                OriginalCelesteFreeze.Freeze(engine, 0.05f);
                ((OriginalLevelSceneRoot)owner.Scene).Shake();
                OriginalSlashFxState.Burst(engine, owner.Position, angle);
                player?.RefillDash();
            }
        }
    }
}
