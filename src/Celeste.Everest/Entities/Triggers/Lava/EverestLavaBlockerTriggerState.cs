using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Gameplay.Environment.Lava.Rising;
using Celeste.Game.Gameplay.Environment.Lava.Sandwich;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using MonoMod.Utils;

namespace Celeste.Everest.Entities.Triggers.Lava
{
    public class EverestLavaBlockerTriggerState : SourceTriggerEntityState
    {
        private List<DynData<OriginalRisingLavaState>> risingLavas;
        private List<OriginalSandwichLavaState> sandwichLavas;
        private readonly bool canReenter;
        private bool enabled = true;

        public EverestLavaBlockerTriggerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            canReenter = data.Bool("canReenter");
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            risingLavas = ((ISourceScene)scene).SourceScene.Entities.OfType<OriginalRisingLavaState>()
                .Select(lava => new DynData<OriginalRisingLavaState>(lava)).ToList();
            sandwichLavas = ((ISourceScene)scene).SourceScene.Entities.OfType<OriginalSandwichLavaState>().ToList();
        }

        public override void OnStay(RoomPlayerSession player)
        {
            if (!enabled) return;
            foreach (DynData<OriginalRisingLavaState> risingLava in risingLavas)
            {
                if (risingLava.IsAlive) risingLava.Set("waiting", true);
            }

            foreach (OriginalSandwichLavaState sandwichLava in sandwichLavas)
            {
                if (sandwichLava != null) sandwichLava.Waiting = true;
            }
        }

        public override void OnLeave(RoomPlayerSession player)
        {
            base.OnLeave(player);
            if (!canReenter) enabled = false;
        }
    }
}
