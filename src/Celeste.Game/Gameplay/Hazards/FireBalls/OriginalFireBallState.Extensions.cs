using System.Numerics;
using Celeste.Graphics.Animation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public partial class OriginalFireBallState
    {
        protected Sprite FireBallSprite => sprite;
        protected Vector2[] PathNodes => nodes;
        protected int InstanceAmount => amount;
        protected int InstanceIndex => index;
        protected float PathOffset => offset;
        protected float PathSpeedMultiplier => mult;
        protected float PathPercent => percent;
        protected SoundSourceComponentState TrackSound => trackSfx;

        protected bool IceMode
        {
            get => iceMode;
            set => iceMode = value;
        }

        protected float CurrentSpeedMultiplier
        {
            get => speedMult;
            set => speedMult = value;
        }

        protected virtual ParticleTypePresentation FireTrailParticle => engine.ParticleTypes.FireBall.P_FireTrail;
        protected void AddedAsEntity(object scene) => base.Added(scene);
    }
}
