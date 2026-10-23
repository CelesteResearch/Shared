using System.Numerics;
using Celeste.Graphics.Animation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public partial class OriginalFireBallState
    {
        // ReSharper disable once ConvertToAutoProperty
        protected Sprite FireBallSprite => sprite;
        // ReSharper disable once ConvertToAutoProperty
        protected Vector2[] PathNodes => nodes;
        // ReSharper disable once ConvertToAutoProperty
        protected int InstanceAmount => amount;
        // ReSharper disable once ConvertToAutoProperty
        protected int InstanceIndex => index;
        // ReSharper disable once ConvertToAutoProperty
        protected float PathOffset => offset;
        // ReSharper disable once ConvertToAutoProperty
        protected float PathSpeedMultiplier => mult;
        // ReSharper disable once ConvertToAutoProperty
        protected float PathPercent => percent;
        // ReSharper disable once ConvertToAutoProperty
        protected SoundSourceComponentState TrackSound => trackSfx;

        // ReSharper disable once ConvertToAutoProperty
        protected bool IceMode
        {
            get => iceMode;
            set => iceMode = value;
        }

        // ReSharper disable once ConvertToAutoProperty
        protected float CurrentSpeedMultiplier
        {
            get => speedMult;
            set => speedMult = value;
        }

        protected virtual ParticleTypePresentation FireTrailParticle => engine.ParticleTypes.FireBall.P_FireTrail;

        protected void AddedAsEntity(object scene)
        {
            base.Added(scene);
        }
    }
}
