using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Everest.Presentation.Hud.Height;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Presentation.Hud.Height;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Gameplay.Triggers.Height
{
    [CustomEntity("everest/CustomHeightDisplayTrigger")]
    public class CustomHeightDisplayTriggerState : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly bool isVanilla;

        private readonly int target;

        private readonly int from;

        private readonly string text;

        private readonly bool progressAudio;

        private readonly bool displayOnTransition;

        public CustomHeightDisplayTriggerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            isVanilla = EntityAttributeReader.Bool(data.Values, "vanilla");
            target = EntityAttributeReader.Int(data.Values, "target");
            from = EntityAttributeReader.Int(data.Values, "from");
            text = EntityAttributeReader.Attr(data.Values, "text", "{X}m");
            progressAudio = EntityAttributeReader.Bool(data.Values, "progressAudio");
            displayOnTransition = EntityAttributeReader.Bool(data.Values, "displayOnTransition");
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            if (isVanilla)
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new OriginalHeightDisplayState(engine, target));
            else
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                    new CustomHeightDisplayState(engine, text, target, from, progressAudio, displayOnTransition));

            RemoveSelf();
        }
    }
}
