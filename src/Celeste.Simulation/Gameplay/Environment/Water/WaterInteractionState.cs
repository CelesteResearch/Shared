using System;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Environment.Water
{
    public class WaterInteractionState : SourceComponentState
    {
        public Func<bool> IsDashing;
        public float DrippingTimer;
        public float DrippingOffset;

        public WaterInteractionState(Func<bool> isDashing) : base(false, false)
        {
            IsDashing = isDashing;
        }

        public override void Update()
        {
            if (DrippingTimer > 0f)
            {
                var engine = ((ISourceEngineContextScene)Scene).EngineContext;
                DrippingTimer -= engine.DeltaTime;
                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.1f, engine))
                {
                    var entity = (ISourceEntityCollider)Entity;
                    var x = (entity.Collider != null ? entity.Position.X + entity.Collider.Left : entity.Position.X) -
                            2f +
                            (float)((ISourceRandomEnvironment)engine).Random.NextDouble() *
                            ((entity.Collider != null ? entity.Collider.Width : 0f) + 4f);
                    var y = (entity.Collider != null ? entity.Position.Y + entity.Collider.Top : entity.Position.Y) +
                            DrippingOffset +
                            (float)((ISourceRandomEnvironment)engine).Random.NextDouble() *
                            ((entity.Collider != null ? entity.Collider.Height : 0f) - DrippingOffset);
                    ((ISourceWaterInteractionParticleScene)Scene).EmitWaterDrip(new(x, y));
                }
            }
        }
    }
}
