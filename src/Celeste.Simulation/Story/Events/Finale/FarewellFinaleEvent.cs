using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Story.Events.Finale
{
    // Dispatch helper for RoomPresentation.Events.cs. HasEventHandler must call
    // Handles(name); EnterEventTrigger's switch must call Enter(...).
    // Original sources: EventTrigger.cs:80-85, 98-103, 169-174, 216-219.
    public static class FarewellFinaleEvent
    {
        public const string ReflectionFlag = "reflection";

        public static bool Handles(string name)
        {
            return name == "ch5_mirror_reflection" || name == "ch6_reflect" || name == "ch9_farewell"
                   || name == "ch9_ending" || name == "ch9_golden_snapshot";
        }

        // Returns false for an unhandled event name. triggerCenterX is the original
        // EventTrigger's Center.X (bounds centre), used by ch6_reflect.
        public static bool Enter(string name, global::Celeste.Simulation.Story.Events.Finale.IFarewellFinaleHost host,
            float triggerCenterX)
        {
            switch (name)
            {
                case "ch5_mirror_reflection":
                    if (!host.GetFlag(ReflectionFlag)) host.AddFarewellReflection1();
                    return true;
                case "ch6_reflect":
                    if (!host.GetFlag(ReflectionFlag)) host.AddFarewellReflection6(triggerCenterX - 5f);
                    return true;
                case "ch9_farewell":
                    host.AddFarewellGrannyCutscene();
                    return true;
                case "ch9_ending":
                    host.AddFarewellEnding();
                    return true;
                case "ch9_golden_snapshot":
                    host.EnterFarewellGoldenSnapshot();
                    return true;
                default:
                    return false;
            }
        }
    }
}
