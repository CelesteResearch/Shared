using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Presentation.Particles
{
    public sealed partial class OriginalParticleCatalog
    {
        private readonly ISourceParticleTypeConstruction construction;

        public OriginalParticleCatalog(ISourceParticleTypeConstruction construction)
        {
            this.construction = construction ?? throw new System.ArgumentNullException(nameof(construction));
        }

        public ParticleTypePresentation Dust;
        public ParticleTypePresentation SparkyDust;
        public ParticleTypePresentation Chimney;
        public ParticleTypePresentation Steam;
        public ParticleTypePresentation VentDust;
        public readonly Definitions.Player.PlayerParticleDefinitions Player = new();
        public readonly Definitions.Torch.TorchParticleDefinitions Torch = new();
        public readonly Definitions.Cloud.CloudParticleDefinitions Cloud = new();
        public readonly Definitions.Booster.BoosterParticleDefinitions Booster = new();
        public readonly Definitions.TouchSwitch.TouchSwitchParticleDefinitions TouchSwitch = new();
        public readonly Definitions.Water.WaterParticleDefinitions Water = new();
        public readonly Definitions.Strawberry.StrawberryParticleDefinitions Strawberry = new();
        public readonly Definitions.BirdNPC.BirdNPCParticleDefinitions BirdNPC = new();
        public readonly Definitions.FlingBird.FlingBirdParticleDefinitions FlingBird = new();
        public readonly Definitions.Key.KeyParticleDefinitions Key = new();
        public readonly Definitions.Refill.RefillParticleDefinitions Refill = new();
        public readonly Definitions.DashSwitch.DashSwitchParticleDefinitions DashSwitch = new();
        public readonly Definitions.FallingBlock.FallingBlockParticleDefinitions FallingBlock = new();
        public readonly Definitions.LockBlock.LockBlockParticleDefinitions LockBlock = new();
        public readonly Definitions.SwitchGate.SwitchGateParticleDefinitions SwitchGate = new();
        public readonly Definitions.CrumblePlatform.CrumblePlatformParticleDefinitions CrumblePlatform = new();
        public readonly Definitions.ZipMover.ZipMoverParticleDefinitions ZipMover = new();
        public readonly Definitions.NPC01_Theo.NPC01_TheoParticleDefinitions NPC01_Theo = new();
        public readonly Definitions.ClutterSwitch.ClutterSwitchParticleDefinitions ClutterSwitch = new();
        public readonly Definitions.BadelineOldsite.BadelineOldsiteParticleDefinitions BadelineOldsite = new();
        public readonly Definitions.DreamMirror.DreamMirrorParticleDefinitions DreamMirror = new();
        public readonly Definitions.NPC03_Oshiro_Lobby.NPC03_Oshiro_LobbyParticleDefinitions NPC03_Oshiro_Lobby = new();
        public readonly Definitions.DustStaticSpinner.DustStaticSpinnerParticleDefinitions DustStaticSpinner = new();
        public readonly Definitions.StarTrackSpinner.StarTrackSpinnerParticleDefinitions StarTrackSpinner = new();
        public readonly Definitions.BladeTrackSpinner.BladeTrackSpinnerParticleDefinitions BladeTrackSpinner = new();
        public readonly Definitions.StrawberrySeed.StrawberrySeedParticleDefinitions StrawberrySeed = new();
        public readonly Definitions.SummitGem.SummitGemParticleDefinitions SummitGem = new();
        public readonly Definitions.Payphone.PayphoneParticleDefinitions Payphone = new();
        public readonly Definitions.TempleMirrorPortal.TempleMirrorPortalParticleDefinitions TempleMirrorPortal = new();
        public readonly Definitions.LightBeam.LightBeamParticleDefinitions LightBeam = new();
        public readonly Definitions.BadelineBoost.BadelineBoostParticleDefinitions BadelineBoost = new();
        public readonly Definitions.FlyFeather.FlyFeatherParticleDefinitions FlyFeather = new();
        public readonly Definitions.CrushBlock.CrushBlockParticleDefinitions CrushBlock = new();
        public readonly Definitions.Bumper.BumperParticleDefinitions Bumper = new();
        public readonly Definitions.SwapBlock.SwapBlockParticleDefinitions SwapBlock = new();
        public readonly Definitions.MoveBlock.MoveBlockParticleDefinitions MoveBlock = new();
        public readonly Definitions.Seeker.SeekerParticleDefinitions Seeker = new();
        public readonly Definitions.WaterInteraction.WaterInteractionParticleDefinitions WaterInteraction = new();
        public readonly Definitions.FireBarrier.FireBarrierParticleDefinitions FireBarrier = new();
        public readonly Definitions.IceBlock.IceBlockParticleDefinitions IceBlock = new();
        public readonly Definitions.BounceBlock.BounceBlockParticleDefinitions BounceBlock = new();
        public readonly Definitions.FireBall.FireBallParticleDefinitions FireBall = new();
        public readonly Definitions.CrystalDebris.CrystalDebrisParticleDefinitions CrystalDebris = new();
        public readonly Definitions.FinalBossShot.FinalBossShotParticleDefinitions FinalBossShot = new();
        public readonly Definitions.FinalBossBeam.FinalBossBeamParticleDefinitions FinalBossBeam = new();

        public readonly Definitions.FinalBossMovingBlock.FinalBossMovingBlockParticleDefinitions FinalBossMovingBlock =
            new();

        public readonly Definitions.FinalBoss.FinalBossParticleDefinitions FinalBoss = new();
        public readonly Definitions.Cassette.CassetteParticleDefinitions Cassette = new();
        public readonly Definitions.TheoCrystal.TheoCrystalParticleDefinitions TheoCrystal = new();
        public readonly Definitions.HeartGem.HeartGemParticleDefinitions HeartGem = new();
        public readonly Definitions.HeartGemDoor.HeartGemDoorParticleDefinitions HeartGemDoor = new();
        public readonly Definitions.Lightning.LightningParticleDefinitions Lightning = new();
        public readonly Definitions.Glider.GliderParticleDefinitions Glider = new();

        public readonly Definitions.LightningBreakerBox.LightningBreakerBoxParticleDefinitions LightningBreakerBox =
            new();

        // The original satellite color table and particle dictionary have process lifetime.
        public readonly Definitions.ForsakenCitySatellite.ForsakenCitySatelliteParticleDefinitions
            ForsakenCitySatellite =
                new();
    }
}
