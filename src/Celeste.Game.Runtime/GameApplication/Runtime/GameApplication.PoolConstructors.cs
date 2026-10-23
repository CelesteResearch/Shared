using System;
using Celeste.Everest.Gameplay.Effects.Debris;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles;
using Celeste.Game.Gameplay.Hazards.TempleEyes;
using Celeste.Game.Presentation.Effects.SpeedRings;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Effects.Debris;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;
using Celeste.Simulation.Gameplay.Platforms.MoveBlock;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        public void ConfigureActualSourcePoolConstructors()
        {
            EntityPools.ConfigureConstructor(() =>
                new OriginalTempleBigEyeballShockwaveState(this));
            EntityPools.ConfigureConstructor(() => new FinalBossBeamState(this));
            EntityPools.ConfigureConstructor(() => new FinalBossShotState(this));
            if (SourceProfile == GameProfile.Original)
                EntityPools.ConfigureConstructor(() =>
                    new CrystalDebrisState(
                        ((OriginalGameGraphicsResources)
                            ((ISourceGameGraphicsEnvironment)this).GameGraphics).GameAtlas,
                        this,
                        TargetMotionPolicy));
            else if (SourceProfile == GameProfile.InstalledEverest)
                EntityPools.ConfigureConstructor<CrystalDebrisState, EverestCrystalDebrisState>("Celeste.CrystalDebris",
                    () => new(
                        ((OriginalGameGraphicsResources)
                            ((ISourceGameGraphicsEnvironment)this).GameGraphics).GameAtlas,
                        this,
                        TargetMotionPolicy));
            else
                throw new InvalidOperationException("The source profile has not been selected.");
            EntityPools.ConfigureConstructor(() => new OriginalSpeedRingState(this));
            if (SourceProfile == GameProfile.Original)
                EntityPools.ConfigureConstructor(() => new DebrisState(this,
                    TargetMotionPolicy));
            else if (SourceProfile == GameProfile.InstalledEverest)
                EntityPools.ConfigureConstructor<DebrisState, EverestDebrisState>("Celeste.Debris",
                    () => new(this,
                        TargetMotionPolicy));
            else
                throw new InvalidOperationException("The source profile has not been selected.");
            EntityPools.ConfigureConstructor(() => new OriginalSlashFxState(this));
            EntityPools.ConfigureConstructor(() =>
                new BounceBlockRespawnDebrisState(this));
            EntityPools.ConfigureConstructor(() => new BounceBlockBreakDebrisState(this));
            EntityPools.ConfigureConstructor(() => new TrailSnapshotState(this));
            EntityPools.ConfigureConstructor(() => new SeekerRecoverBlastState(this));
            EntityPools.ConfigureConstructor(() =>
                new MoveBlockDebrisState(
                    ((OriginalGameGraphicsResources)
                        ((ISourceGameGraphicsEnvironment)this).GameGraphics).GameAtlas, this,
                    TargetMotionPolicy));
        }
    }
}
