using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Entities.Environment.Wind;
using Celeste.Simulation.Gameplay.Environment.Wind;

namespace Celeste.Game.Entities.Triggers.Wind
{
    public class OriginalWindTrigger : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        public RoomWindPattern Pattern;

        public OriginalWindTrigger(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            Pattern = EntityAttributeReader.Enum(data.Values, "pattern", RoomWindPattern.None);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            var scene = (OriginalLevelSceneRoot)Scene;
            OriginalWindController windController = scene.SourceScene.Entities.FindFirst<OriginalWindController>();
            if (windController == null)
            {
                windController = new OriginalWindController(Pattern, engine);
                scene.SourceScene.QueueSourceEntity(windController);
            }
            else windController.SetPattern(Pattern);
        }
    }
}
