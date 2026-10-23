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
    // Shared light component: the original VertexLight is a real component after the
    // sprite and before TalkComponent, so owners update it from their component loop.
    public sealed class NpcVariantLightComponent : INpcComponent
    {
        public readonly EntityLightVisual Light;
        public Action<EntityLightVisual, float, float> Updated;

        public NpcVariantLightComponent(EntityLightVisual light)
        {
            Light = light;
        }

        public bool Active => true;
        public void Update(float dt, float raw) => Updated?.Invoke(Light, dt, raw);
    }
}
