using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.UI.Dialogue.MiniTextboxes;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Triggers.Dialogue
{
    public class MiniTextboxTriggerState : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;

        private enum Modes
        {
            OnPlayerEnter,
            OnLevelStart,
            OnTheoEnter,
        }

        private readonly MapEntityId id;

        private readonly string[] dialogOptions;

        private readonly Modes mode;

        private bool triggered;

        private readonly bool onlyOnce;

        private readonly int deathCount;

        public MiniTextboxTriggerState(EntityData data, Vector2 offset, MapEntityId id,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            this.id = id;
            mode = EntityAttributeReader.Enum(data.Values, "mode", Modes.OnPlayerEnter);
            dialogOptions = EntityAttributeReader.Attr(data.Values, "dialog_id").Split(',');
            onlyOnce = EntityAttributeReader.Bool(data.Values, "only_once");
            deathCount = EntityAttributeReader.Int(data.Values, "death_count", -1);
            if (mode == Modes.OnTheoEnter) Add(new HoldableColliderState(delegate { Trigger(); }));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (mode == Modes.OnLevelStart) Trigger();
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            if (mode == Modes.OnPlayerEnter) Trigger();
        }

        private void Trigger()
        {
            if (!triggered && (deathCount < 0 ||
                               (Scene as OriginalLevelSceneRoot).Session.DeathsInCurrentLevel == deathCount))
            {
                triggered = true;
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                    new MiniTextboxState(((ISourceRandomEnvironment)engine).Random.Choose(dialogOptions), engine));
                if (onlyOnce) (Scene as OriginalLevelSceneRoot).Session.DoNotLoad.Add(id);
            }
        }
    }
}
