using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Gameplay.Triggers.Core
{
    [CustomEntity("everest/coreModeTrigger", "cavern/coremodetrigger")]
    public class CoreModeTrigger : SourceTriggerEntityState
    {
        private enum Modes
        {
            None,
            Hot,
            Cold,
            Toggle,
        }

        private readonly Modes mode;
        private readonly bool playEffects;
        private readonly ISourceEngineContext engine;

        public CoreModeTrigger(ISourceEngineContext engine, OriginalLevelEntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            mode = EntityAttributeReader.Enum(data.Values, "mode", Modes.None);
            playEffects = EntityAttributeReader.Bool(data.Values, "playEffects", true);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            var level = (OriginalLevelSceneRoot)Scene;
            var coreModes = RoomCoreMode.None;
            if (mode == Modes.Toggle)
            {
                if (level.CoreMode == RoomCoreMode.Hot)
                    coreModes = RoomCoreMode.Cold;
                else if (level.CoreMode == RoomCoreMode.Cold)
                    coreModes = RoomCoreMode.Hot;
            }
            else
            {
                coreModes = (RoomCoreMode)mode;
            }

            if (level.CoreMode != coreModes)
            {
                level.CoreMode = coreModes;
                if (playEffects)
                {
                    ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                        RumbleLength.Medium);
                    level.Flash(PackedColor.White * 0.15f, true);
                    ((ISourceFreezeEnvironment)engine).Freeze(0.05f);
                }
            }
        }
    }
}
