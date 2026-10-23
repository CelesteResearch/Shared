using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles;
using Celeste.Game.Gameplay.Hazards.TempleEyes;
using Celeste.Game.Presentation.Effects.SpeedRings;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Effects.Debris;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;
using Celeste.Simulation.Gameplay.Platforms.MoveBlock;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalPooledActualTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            catalog.RegisterRuntimeType(typeof(DebrisState),
                "Celeste.Debris");
            catalog.RegisterRuntimeType(
                typeof(MoveBlockDebrisState),
                "Celeste.MoveBlock.Debris");
            catalog.RegisterRuntimeType(
                typeof(OriginalTempleBigEyeballShockwaveState),
                "Celeste.TempleBigEyeballShockwave");
            catalog.RegisterRuntimeType(
                typeof(FinalBossBeamState),
                "Celeste.FinalBossBeam");
            catalog.RegisterRuntimeType(
                typeof(FinalBossShotState),
                "Celeste.FinalBossShot");
            catalog.RegisterRuntimeType(typeof(CrystalDebrisState),
                "Celeste.CrystalDebris");
            catalog.RegisterRuntimeType(
                typeof(OriginalSpeedRingState),
                "Celeste.SpeedRing");
            catalog.RegisterRuntimeType(typeof(OriginalSlashFxState),
                "Celeste.SlashFx");
            catalog.RegisterRuntimeType(
                typeof(BounceBlockRespawnDebrisState),
                "Celeste.BounceBlock.RespawnDebris");
            catalog.RegisterRuntimeType(
                typeof(BounceBlockBreakDebrisState),
                "Celeste.BounceBlock.BreakDebris");
            catalog.RegisterRuntimeType(
                typeof(TrailSnapshotState),
                "Celeste.TrailManager.Snapshot");
            catalog.RegisterRuntimeType(
                typeof(SeekerRecoverBlastState),
                "Celeste.Seeker.RecoverBlast");
        }
    }
}
