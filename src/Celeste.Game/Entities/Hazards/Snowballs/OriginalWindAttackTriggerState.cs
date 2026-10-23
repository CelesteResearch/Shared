using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Entities.Hazards.Snowballs
{
    public sealed class OriginalWindAttackTriggerState : SourceTriggerEntityState
    {
        private readonly IOriginalSnowballEnvironment _engine;

        public OriginalWindAttackTriggerState(EntityData data, Vector2 offset,
            IOriginalSnowballEnvironment engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            _engine = engine;
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            var scene = ((ISourceScene)Scene).SourceScene;
            if (scene.Entities.FindFirst<OriginalSnowballState>() == null)
                scene.AddEntity(new OriginalSnowballState(_engine));
            RemoveSelf();
        }
    }
}
