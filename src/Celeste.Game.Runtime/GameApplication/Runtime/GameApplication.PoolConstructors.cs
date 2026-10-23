using System;
using Celeste.Game.Profiles;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Platforms.MoveBlock;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;
using Celeste.Simulation.Gameplay.Effects.Debris;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Game.Gameplay.Hazards.TempleEyes;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Game.Presentation.Effects.SpeedRings;
using Celeste.Everest.Gameplay.Effects.Debris;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        public void ConfigureActualSourcePoolConstructors()
        {
            EntityPools.ConfigureConstructor<OriginalTempleBigEyeballShockwaveState>(() =>
                new OriginalTempleBigEyeballShockwaveState(this));
            EntityPools.ConfigureConstructor<FinalBossBeamState>(() => new FinalBossBeamState(this));
            EntityPools.ConfigureConstructor<FinalBossShotState>(() => new FinalBossShotState(this));
            if (SourceProfile == GameProfile.Original)
                EntityPools.ConfigureConstructor<CrystalDebrisState>(() =>
                    new CrystalDebrisState(
                        ((Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources)
                            ((Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)this).GameGraphics).GameAtlas,
                        this,
                        ((Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformTargetMotionEnvironment)this)
                        .TargetMotionPolicy));
            else if (SourceProfile == GameProfile.InstalledEverest)
                EntityPools.ConfigureConstructor<CrystalDebrisState, EverestCrystalDebrisState>("Celeste.CrystalDebris",
                    () => new EverestCrystalDebrisState(
                        ((Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources)
                            ((Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)this).GameGraphics).GameAtlas,
                        this,
                        ((Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformTargetMotionEnvironment)this)
                        .TargetMotionPolicy));
            else
                throw new InvalidOperationException("The source profile has not been selected.");
            EntityPools.ConfigureConstructor<OriginalSpeedRingState>(() => new OriginalSpeedRingState(this));
            if (SourceProfile == GameProfile.Original)
                EntityPools.ConfigureConstructor<DebrisState>(() => new DebrisState(this,
                    ((Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformTargetMotionEnvironment)this)
                    .TargetMotionPolicy));
            else if (SourceProfile == GameProfile.InstalledEverest)
                EntityPools.ConfigureConstructor<DebrisState, EverestDebrisState>("Celeste.Debris",
                    () => new EverestDebrisState(this,
                        ((Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformTargetMotionEnvironment)this)
                        .TargetMotionPolicy));
            else
                throw new InvalidOperationException("The source profile has not been selected.");
            EntityPools.ConfigureConstructor<OriginalSlashFxState>(() => new OriginalSlashFxState(this));
            EntityPools.ConfigureConstructor<BounceBlockRespawnDebrisState>(() =>
                new BounceBlockRespawnDebrisState(this));
            EntityPools.ConfigureConstructor<BounceBlockBreakDebrisState>(() => new BounceBlockBreakDebrisState(this));
            EntityPools.ConfigureConstructor<TrailSnapshotState>(() => new TrailSnapshotState(this));
            EntityPools.ConfigureConstructor<SeekerRecoverBlastState>(() => new SeekerRecoverBlastState(this));
            EntityPools.ConfigureConstructor<MoveBlockDebrisState>(() =>
                new MoveBlockDebrisState(
                    ((Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources)
                        ((Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)this).GameGraphics).GameAtlas, this,
                    ((Celeste.Simulation.Gameplay.Platforms.Foundation.ISourcePlatformTargetMotionEnvironment)this)
                    .TargetMotionPolicy));
        }
    }
}
