using Celeste.Graphics.Animation;

// Candidate file: Packages/local.celeste.simulation/Runtime/NpcVariantStates.cs
// Pure states for the map `npc` ids that the coverage sweep found unhandled.
// Every class cites the original file/line it reproduces. Cutscenes owned by
// CS03_*/CS04_*/CS05_*/CS06_* are NOT ported here: each state stops at the exact
// instruction that constructs the cutscene and hands a request to the host.
namespace Celeste.Simulation
{
    // Player fields the resort/reflection/core NPCs read. NPC03_Oshiro_Breakdown.cs:32
    // reads Player.OnSafeGround; NPC03_Theo_Vents.cs:171-172 DummyAutoAnimate/Sprite;
    // NPC09_Granny_Inside.cs:102-110 Dashes/ForceCameraUpdate.
    public interface INpcVariantPlayer : INpcPlayer
    {
        bool OnGround();
        bool OnSafeGround { get; }
        bool DummyAutoAnimate { get; set; }
        int Dashes { get; set; }
        Sprite Sprite { get; }
    }
}
