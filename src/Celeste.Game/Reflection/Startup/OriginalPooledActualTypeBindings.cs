using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalPooledActualTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            catalog.RegisterRuntimeType(typeof(global::Celeste.Simulation.Gameplay.Actors.Debris.DebrisState),
                "Celeste.Debris");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Platforms.MoveBlock.MoveBlockDebrisState),
                "Celeste.MoveBlock.Debris");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.TempleEyes.OriginalTempleBigEyeballShockwaveState),
                "Celeste.TempleBigEyeballShockwave");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles.FinalBossBeamState),
                "Celeste.FinalBossBeam");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles.FinalBossShotState),
                "Celeste.FinalBossShot");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Simulation.Gameplay.Effects.Debris.CrystalDebrisState),
                "Celeste.CrystalDebris");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Game.Presentation.Effects.SpeedRings.OriginalSpeedRingState),
                "Celeste.SpeedRing");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Effects.Slashes.OriginalSlashFxState),
                "Celeste.SlashFx");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Platforms.BounceBlock.BounceBlockRespawnDebrisState),
                "Celeste.BounceBlock.RespawnDebris");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Platforms.BounceBlock.BounceBlockBreakDebrisState),
                "Celeste.BounceBlock.BreakDebris");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Presentation.Effects.Trails.Lifecycle.TrailSnapshotState),
                "Celeste.TrailManager.Snapshot");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Enemies.Seeker.SeekerRecoverBlastState),
                "Celeste.Seeker.RecoverBlast");
        }
    }
}
