

// Candidate file: Packages/local.celeste.simulation/Runtime/NpcVariantStates.cs
// Pure states for the map `npc` ids that the coverage sweep found unhandled.
// Every class cites the original file/line it reproduces. Cutscenes owned by
// CS03_*/CS04_*/CS05_*/CS06_* are NOT ported here: each state stops at the exact
// instruction that constructs the cutscene and hands a request to the host.
namespace Celeste.Simulation
{
    // Level.cs:1097-1177 -> the cutscene each branch constructs.
    public enum NpcVariantCutscene
    {
        OshiroMasterSuite, // CS03_OshiroMasterSuite.cs:12 (NPC03_Oshiro_Suite.cs:29)
        OshiroHallway1, // CS03_OshiroHallway1.cs:12 (NPC03_Oshiro_Hallway1.cs:34)
        OshiroHallway2, // CS03_OshiroHallway2.cs:12 (NPC03_Oshiro_Hallway2.cs:38)
        OshiroBreakdown, // CS03_OshiroBreakdown.cs:13 (NPC03_Oshiro_Breakdown.cs:34)
        TheoEscape, // CS03_TheoEscape.cs:12 (NPC03_Theo_Escaping.cs:108)
        Campfire, // CS06_Campfire.cs:14 (NPC06_Theo_Plateau.cs:24)
        ReflectionGranny, // CS06_Granny.cs:12 (NPC06_Granny.cs:50)
        ReflectionEnding, // CS06_Ending.cs:12 (NPC06_Granny_Ending.cs:32)
        CliffsideGranny, // CS04_Granny.cs:15 (NPC04_Granny.cs:53)
        TempleBadeline, // CS05_Badeline.cs:24 (NPC05_Badeline.cs:147)
    }
}
