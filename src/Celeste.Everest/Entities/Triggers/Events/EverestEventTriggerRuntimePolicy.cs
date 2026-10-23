using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Entities.Triggers.Events;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using Celeste.Simulation;

namespace Celeste.Everest.Entities.Triggers.Events
{
    public sealed class EverestEventTriggerRuntimePolicy : IOriginalEventTriggerRuntimePolicy
    {
        public delegate SceneEntityState CutsceneLoader(OriginalEventTriggerState trigger, RoomPlayerSession player,
            string eventID);

        private readonly ISourceEngineContext engine;
        public readonly EverestEventTriggerEvents Events = new();
        public readonly Dictionary<string, CutsceneLoader> CutsceneLoaders = new();

        private readonly HashSet<string> _LoadStrings =
        [
            "end_city", "end_oldsite_dream", "end_oldsite_awake", "ch5_see_theo", "ch5_found_theo",
            "ch5_mirror_reflection",
            "cancel_ch5_see_theo", "ch6_boss_intro", "ch6_reflect", "ch7_summit",
            "ch8_door", "ch9_goto_the_future", "ch9_goto_the_past", "ch9_moon_intro", "ch9_hub_intro",
            "ch9_hub_transition_out", "ch9_badeline_helps", "ch9_farewell", "ch9_ending", "ch9_end_golden",
            "ch9_final_room", "ch9_ding_ding_ding", "ch9_golden_snapshot", "seeTheoInCrystal", "foundTheoInCrystal",
            "reflection", "it_ch5_see_theo", "it_ch5_see_theo_b", "ignore_darkness_", "boss_intro",
            "moon_intro", "hub_intro", "badeline_helps", "final_room_deaths",
            "event:/new_content/game/10_farewell/pico8_flag", "decals/10-farewell/finalflag",
            "snapshot:/game_10_golden_room_flavour", "golden",
            "Event '", "' does not exist!",
        ];

        public EverestEventTriggerRuntimePolicy(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public bool TriggerCustomEvent(OriginalEventTriggerState trigger, RoomPlayerSession player, string eventID)
        {
            if (Events.TriggerEvent(trigger, player, eventID)) return true;
            if (CutsceneLoaders.TryGetValue(eventID, out var value))
            {
                var entity = value(trigger, player, eventID);
                if (entity != null)
                {
                    ((OriginalLevelSceneRoot)trigger.Scene).Scheduler.QueueSourceEntity(entity);
                    return true;
                }
            }

            if (!_LoadStrings.Contains(eventID))
            {
                var scope = "EventTrigger";
                var logger = ((IEverestLoggerProcessEnvironment)engine).Logger;
                if (logger.GetLogLevel(scope) <= EverestLogLevel.Warn)
                    logger.Log(EverestLogLevel.Warn, scope, $"Event '{eventID}' does not exist!");
                return true;
            }

            return false;
        }
    }
}
