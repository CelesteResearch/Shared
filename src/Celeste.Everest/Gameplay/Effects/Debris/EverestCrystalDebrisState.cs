using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Effects.Debris;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Gameplay.Effects.Debris
{
    public class EverestCrystalDebrisState : CrystalDebrisState
    {
        public EverestCrystalDebrisState(AtlasData atlas, ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy) : base(atlas, engine, targetMotionPolicy)
        {
        }

        public override void Update()
        {
            Speed.X = ScalarMath.Clamp(Speed.X, -100000f, 100000f);
            Speed.Y = ScalarMath.Clamp(Speed.Y, -100000f, 100000f);
            base.Update();
        }
    }
}
