using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.MoveBlock;

namespace Celeste.Game.Gameplay.Platforms.MoveBlocks
{
    public class MoveBlockState : MovingBlockState
    {
        public MoveBlockState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds) : base(data, offset,
            worlds)
        {
        }

        public MoveBlockState(Vector2 position, int width, int height, MoveBlockDirection direction, bool canSteer,
            bool fast, ISourceSolidWorld world) : base(position, width, height, direction, canSteer, fast, world)
        {
        }

        // Keep original concrete methods as hook targets; helper siblings use the common implementation directly.
        public override void Update()
        {
            base.Update();
        }

        public override bool MoveCheck(Vector2 amount)
        {
            return base.MoveCheck(amount);
        }

        public override IEnumerator ControllerRoutine()
        {
            return base.ControllerRoutine();
        }

        protected override MovingBlockDebrisState CreateDebris(Vector2 position, Vector2 center, Vector2 home)
        {
            return SourceWorld.EngineContext.EntityPools.Create<MoveBlockDebrisState>().Init(position, center, home);
        }

        protected override MovingBlockBorderState CreateBorder(ISourceEntitySourceDataRegistration registration)
        {
            return new MoveBlockBorderState(this, registration);
        }
    }
}
