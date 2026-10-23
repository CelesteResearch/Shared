using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

// Candidate file: Packages/local.celeste.simulation/Runtime/NpcVariantStates.cs
// Pure states for the map `npc` ids that the coverage sweep found unhandled.
// Every class cites the original file/line it reproduces. Cutscenes owned by
// CS03_*/CS04_*/CS05_*/CS06_* are NOT ported here: each state stops at the exact
// instruction that constructs the cutscene and hands a request to the host.
namespace Celeste.Simulation
{
    // Monocle/Tween.cs:122-179 Oneshot semantics (CubeInOut, 0.5s, start:true) as used
    // by NPC05_Badeline.MoveToNode (NPC05_Badeline.cs:175-188).
    public sealed class NpcVariantTween : INpcComponent
    {
        public readonly float Duration;
        public float TimeLeft { get; private set; }
        public float Percent { get; private set; }
        public float Eased { get; private set; }
        public bool Active { get; private set; }
        public Action<float> OnUpdate;

        public NpcVariantTween(float duration)
        {
            Duration = duration <= 0 ? .000001f : duration;
            TimeLeft = Duration;
            Active = true;
        }

        public void Update(float dt, float rawDt)
        {
            if (!Active) return;
            TimeLeft -= dt;
            Percent = 1 - Math.Max(0, TimeLeft) / Duration;
            Eased = CubeInOut(Percent);
            OnUpdate?.Invoke(Eased);
            if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                Active = false;
            }
        }

        public static float CubeIn(float t) => t * t * t;

        public static float CubeOut(float t)
        {
            t -= 1;
            return 1 + t * t * t;
        }

        public static float CubeInOut(float t) => t <= .5f ? CubeIn(t * 2) / 2 : CubeOut(t * 2 - 1) / 2 + .5f;
        public static float BackIn(float t) => t * t * (2.70158f * t - 1.70158f);
    }
}
