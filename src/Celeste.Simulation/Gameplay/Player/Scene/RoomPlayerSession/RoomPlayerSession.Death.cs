using System.Numerics;
using Celeste.Core.Components;
using Celeste.Scene.Lifecycle;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;
using Celeste.Simulation.Gameplay.Lookout;
using Celeste.Simulation.Gameplay.Player.Death;
using Celeste.Simulation.Presentation.Player.Death;
using Celeste.Simulation.Presentation.ScreenEffects;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public PlayerDeathPresentation Die(Vector2 direction, bool evenIfInvincible = false,
            bool registerDeathInStats = true) =>
            ((global::Celeste.Simulation.Gameplay.Player.Runtime.ISourcePlayerRuntimeEnvironment)engineContext)
            .PlayerRuntimePolicy.Die(this, direction, evenIfInvincible, registerDeathInStats);

        public PlayerDeathPresentation DieSourceBody(Vector2 direction, bool evenIfInvincible = false,
            bool registerDeathInStats = true)
        {
            var session = ((ISourceGoldenBerryRestartScene)Level).GoldenRestartSession;
            bool invincible = !evenIfInvincible && Settings.Invincible;
            if (Dead || invincible || Machine.State == 18) return null;
            Stop(WallSlideSoundComponent);
            if (registerDeathInStats)
            {
                unchecked
                {
                    session.Deaths++;
                    session.DeathsInCurrentLevel++;
                }

                ((ISourcePlayerDeathStatisticsScene)Level).RegisterPlayerDeath(session);
            }

            ISourceStrawberryFollower golden = null;
            foreach (var follower in Leader.Followers)
                if (follower.Entity is ISourceStrawberryFollower strawberry && strawberry.Golden && !strawberry.Winged)
                    golden = strawberry;
            Dead = true;
            Leader.LoseFollowers();
            Depth = -1000000;
            Data.Motion.Normal.Speed = Vector2.Zero;
            Machine.Locked = true;
            Collidable = false;
            Holding.Drop();
            boostSequence.PlayerDied();
            ((ISceneCutsceneState)Level).ClearInCutscene();
            ((ISourceLevelShakeScene)Level).Shake();
            Rumble(0, 1);
            var corpse = new PlayerDeathPresentation(this, direction);
            if (golden != null)
            {
                corpse.HasGolden = true;
                corpse.DeathAction = ((ISourceGoldenBerryRestartScene)Level).CreateGoldenRestartAction(session, golden);
            }

            ((ISourceScene)Scene).SourceScene.AddEntity(corpse);
            ((ISourceScene)Scene).SourceScene.RemoveEntity(this);
            var lookouts = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.Lookout");
            if (lookouts.Count > 0)
                ((ISourceLookoutInteraction)lookouts[0]).StopInteracting();
            return corpse;
        }
    }
}
