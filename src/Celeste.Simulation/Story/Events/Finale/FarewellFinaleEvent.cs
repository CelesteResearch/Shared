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
            return name is "ch5_mirror_reflection" or "ch6_reflect" or "ch9_farewell" or "ch9_ending"
                or "ch9_golden_snapshot";
        }

        // Returns false for an unhandled event name. triggerCenterX is the original
        // EventTrigger's Center.X (bounds centre), used by ch6_reflect.
        public static bool Enter(string name, IFarewellFinaleHost host, float triggerCenterX)
        {
            switch (name)
            {
                case "ch5_mirror_reflection":
                    if (!host.GetFlag(ReflectionFlag))
                        host.AddFarewellReflection1();
                    return true;
                case "ch6_reflect":
                    if (!host.GetFlag(ReflectionFlag))
                        host.AddFarewellReflection6(triggerCenterX - 5f);
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
