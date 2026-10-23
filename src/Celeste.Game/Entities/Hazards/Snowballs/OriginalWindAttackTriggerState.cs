using Celeste.Core.Components;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Hazards.Snowballs
{
    public sealed class OriginalWindAttackTriggerState : SourceTriggerEntityState
    {
        private readonly IOriginalSnowballEnvironment engine;

        public OriginalWindAttackTriggerState(EntityData data, Vector2 offset,
            IOriginalSnowballEnvironment engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            var scene = ((ISourceScene)Scene).SourceScene;
            if (scene.Entities.FindFirst<OriginalSnowballState>() == null)
                scene.AddEntity(new OriginalSnowballState(engine));
            RemoveSelf();
        }
    }
}
