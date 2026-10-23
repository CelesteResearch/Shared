using System;
using Celeste.Game.Presentation.Particles.Definitions.BadelineBoost;
using Celeste.Game.Presentation.Particles.Definitions.BadelineOldsite;
using Celeste.Game.Presentation.Particles.Definitions.BirdNPC;
using Celeste.Game.Presentation.Particles.Definitions.BladeTrackSpinner;
using Celeste.Game.Presentation.Particles.Definitions.Booster;
using Celeste.Game.Presentation.Particles.Definitions.BounceBlock;
using Celeste.Game.Presentation.Particles.Definitions.Bumper;
using Celeste.Game.Presentation.Particles.Definitions.Cassette;
using Celeste.Game.Presentation.Particles.Definitions.Cloud;
using Celeste.Game.Presentation.Particles.Definitions.ClutterSwitch;
using Celeste.Game.Presentation.Particles.Definitions.CrumblePlatform;
using Celeste.Game.Presentation.Particles.Definitions.CrushBlock;
using Celeste.Game.Presentation.Particles.Definitions.CrystalDebris;
using Celeste.Game.Presentation.Particles.Definitions.DashSwitch;
using Celeste.Game.Presentation.Particles.Definitions.DreamMirror;
using Celeste.Game.Presentation.Particles.Definitions.DustStaticSpinner;
using Celeste.Game.Presentation.Particles.Definitions.FallingBlock;
using Celeste.Game.Presentation.Particles.Definitions.FinalBoss;
using Celeste.Game.Presentation.Particles.Definitions.FinalBossBeam;
using Celeste.Game.Presentation.Particles.Definitions.FinalBossMovingBlock;
using Celeste.Game.Presentation.Particles.Definitions.FinalBossShot;
using Celeste.Game.Presentation.Particles.Definitions.FireBall;
using Celeste.Game.Presentation.Particles.Definitions.FireBarrier;
using Celeste.Game.Presentation.Particles.Definitions.FlingBird;
using Celeste.Game.Presentation.Particles.Definitions.FlyFeather;
using Celeste.Game.Presentation.Particles.Definitions.ForsakenCitySatellite;
using Celeste.Game.Presentation.Particles.Definitions.Glider;
using Celeste.Game.Presentation.Particles.Definitions.HeartGem;
using Celeste.Game.Presentation.Particles.Definitions.HeartGemDoor;
using Celeste.Game.Presentation.Particles.Definitions.IceBlock;
using Celeste.Game.Presentation.Particles.Definitions.Key;
using Celeste.Game.Presentation.Particles.Definitions.LightBeam;
using Celeste.Game.Presentation.Particles.Definitions.Lightning;
using Celeste.Game.Presentation.Particles.Definitions.LightningBreakerBox;
using Celeste.Game.Presentation.Particles.Definitions.LockBlock;
using Celeste.Game.Presentation.Particles.Definitions.MoveBlock;
using Celeste.Game.Presentation.Particles.Definitions.NPC01_Theo;
using Celeste.Game.Presentation.Particles.Definitions.NPC03_Oshiro_Lobby;
using Celeste.Game.Presentation.Particles.Definitions.Payphone;
using Celeste.Game.Presentation.Particles.Definitions.Player;
using Celeste.Game.Presentation.Particles.Definitions.Refill;
using Celeste.Game.Presentation.Particles.Definitions.Seeker;
using Celeste.Game.Presentation.Particles.Definitions.StarTrackSpinner;
using Celeste.Game.Presentation.Particles.Definitions.Strawberry;
using Celeste.Game.Presentation.Particles.Definitions.StrawberrySeed;
using Celeste.Game.Presentation.Particles.Definitions.SummitGem;
using Celeste.Game.Presentation.Particles.Definitions.SwapBlock;
using Celeste.Game.Presentation.Particles.Definitions.SwitchGate;
using Celeste.Game.Presentation.Particles.Definitions.TempleMirrorPortal;
using Celeste.Game.Presentation.Particles.Definitions.TheoCrystal;
using Celeste.Game.Presentation.Particles.Definitions.Torch;
using Celeste.Game.Presentation.Particles.Definitions.TouchSwitch;
using Celeste.Game.Presentation.Particles.Definitions.Water;
using Celeste.Game.Presentation.Particles.Definitions.WaterInteraction;
using Celeste.Game.Presentation.Particles.Definitions.ZipMover;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Presentation.Particles
{
    public sealed partial class OriginalParticleCatalog
    {
        private readonly ISourceParticleTypeConstruction construction;

        public OriginalParticleCatalog(ISourceParticleTypeConstruction construction)
        {
            this.construction = construction ?? throw new ArgumentNullException(nameof(construction));
        }

        public ParticleTypePresentation Dust;
        public ParticleTypePresentation SparkyDust;
        public ParticleTypePresentation Chimney;
        public ParticleTypePresentation Steam;
        public ParticleTypePresentation VentDust;
        public readonly PlayerParticleDefinitions Player = new();
        public readonly TorchParticleDefinitions Torch = new();
        public readonly CloudParticleDefinitions Cloud = new();
        public readonly BoosterParticleDefinitions Booster = new();
        public readonly TouchSwitchParticleDefinitions TouchSwitch = new();
        public readonly WaterParticleDefinitions Water = new();
        public readonly StrawberryParticleDefinitions Strawberry = new();
        public readonly BirdNPCParticleDefinitions BirdNPC = new();
        public readonly FlingBirdParticleDefinitions FlingBird = new();
        public readonly KeyParticleDefinitions Key = new();
        public readonly RefillParticleDefinitions Refill = new();
        public readonly DashSwitchParticleDefinitions DashSwitch = new();
        public readonly FallingBlockParticleDefinitions FallingBlock = new();
        public readonly LockBlockParticleDefinitions LockBlock = new();
        public readonly SwitchGateParticleDefinitions SwitchGate = new();
        public readonly CrumblePlatformParticleDefinitions CrumblePlatform = new();
        public readonly ZipMoverParticleDefinitions ZipMover = new();
        public readonly NPC01_TheoParticleDefinitions NPC01_Theo = new();
        public readonly ClutterSwitchParticleDefinitions ClutterSwitch = new();
        public readonly BadelineOldsiteParticleDefinitions BadelineOldsite = new();
        public readonly DreamMirrorParticleDefinitions DreamMirror = new();
        public readonly NPC03_Oshiro_LobbyParticleDefinitions NPC03_Oshiro_Lobby = new();
        public readonly DustStaticSpinnerParticleDefinitions DustStaticSpinner = new();
        public readonly StarTrackSpinnerParticleDefinitions StarTrackSpinner = new();
        public readonly BladeTrackSpinnerParticleDefinitions BladeTrackSpinner = new();
        public readonly StrawberrySeedParticleDefinitions StrawberrySeed = new();
        public readonly SummitGemParticleDefinitions SummitGem = new();
        public readonly PayphoneParticleDefinitions Payphone = new();
        public readonly TempleMirrorPortalParticleDefinitions TempleMirrorPortal = new();
        public readonly LightBeamParticleDefinitions LightBeam = new();
        public readonly BadelineBoostParticleDefinitions BadelineBoost = new();
        public readonly FlyFeatherParticleDefinitions FlyFeather = new();
        public readonly CrushBlockParticleDefinitions CrushBlock = new();
        public readonly BumperParticleDefinitions Bumper = new();
        public readonly SwapBlockParticleDefinitions SwapBlock = new();
        public readonly MoveBlockParticleDefinitions MoveBlock = new();
        public readonly SeekerParticleDefinitions Seeker = new();
        public readonly WaterInteractionParticleDefinitions WaterInteraction = new();
        public readonly FireBarrierParticleDefinitions FireBarrier = new();
        public readonly IceBlockParticleDefinitions IceBlock = new();
        public readonly BounceBlockParticleDefinitions BounceBlock = new();
        public readonly FireBallParticleDefinitions FireBall = new();
        public readonly CrystalDebrisParticleDefinitions CrystalDebris = new();
        public readonly FinalBossShotParticleDefinitions FinalBossShot = new();
        public readonly FinalBossBeamParticleDefinitions FinalBossBeam = new();

        public readonly FinalBossMovingBlockParticleDefinitions FinalBossMovingBlock =
            new();

        public readonly FinalBossParticleDefinitions FinalBoss = new();
        public readonly CassetteParticleDefinitions Cassette = new();
        public readonly TheoCrystalParticleDefinitions TheoCrystal = new();
        public readonly HeartGemParticleDefinitions HeartGem = new();
        public readonly HeartGemDoorParticleDefinitions HeartGemDoor = new();
        public readonly LightningParticleDefinitions Lightning = new();
        public readonly GliderParticleDefinitions Glider = new();

        public readonly LightningBreakerBoxParticleDefinitions LightningBreakerBox =
            new();

        // The original satellite color table and particle dictionary have process lifetime.
        public readonly ForsakenCitySatelliteParticleDefinitions
            ForsakenCitySatellite =
                new();
    }
}
