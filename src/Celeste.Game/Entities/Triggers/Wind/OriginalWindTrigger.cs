using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Environment.Wind;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Wind;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

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
            var windController = scene.SourceScene.Entities.FindFirst<OriginalWindController>();
            if (windController == null)
            {
                windController = new(Pattern, engine);
                scene.SourceScene.QueueSourceEntity(windController);
            }
            else
            {
                windController.SetPattern(Pattern);
            }
        }
    }
}
