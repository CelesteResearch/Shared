using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Entities.Triggers.Flags
{
    public class EverestFlagTriggerState : SourceTriggerEntityState
    {
        private enum Modes
        {
            OnPlayerEnter,
            OnPlayerLeave,
            OnLevelStart
        }

        private string flag;
        private bool state;
        private Modes mode;
        private bool onlyOnce;
        private int deathCount;
        private bool triggered;

        public EverestFlagTriggerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            flag = data.Attr("flag");
            state = data.Bool("state");
            mode = data.Enum("mode", Modes.OnPlayerEnter);
            onlyOnce = data.Bool("only_once");
            deathCount = data.Int("death_count", -1);
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

        public override void OnLeave(RoomPlayerSession player)
        {
            if (mode == Modes.OnPlayerLeave) Trigger();
        }

        private void Trigger()
        {
            if (!triggered &&
                (deathCount < 0 || (Scene as OriginalLevelSceneRoot).Session.DeathsInCurrentLevel == deathCount))
            {
                (Scene as OriginalLevelSceneRoot).Session.SetFlag(flag, state);
                if (onlyOnce) triggered = true;
            }
        }
    }
}
