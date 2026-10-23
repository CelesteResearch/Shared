using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Platforms.Dream;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Gameplay.Triggers.Dream
{
    [CustomEntity("everest/activateDreamBlocksTrigger")]
    public class ActivateDreamBlocksTrigger : SourceTriggerEntityState
    {
        private bool rumble;
        private bool activate;
        private bool fastAnimation;
        private readonly ISourceEngineContext engine;

        public ActivateDreamBlocksTrigger(ISourceEngineContext engine, OriginalLevelEntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            rumble = EntityAttributeReader.Bool(data.Values, "fullRoutine");
            activate = EntityAttributeReader.Bool(data.Values, "activate", true);
            fastAnimation = EntityAttributeReader.Bool(data.Values, "fastAnimation");
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            var level = (OriginalLevelSceneRoot)Scene;
            if (activate && !level.Session.Inventory.DreamDash)
            {
                level.Session.Inventory.DreamDash = true;
                foreach (var item in level.SourceScene.Entities.GetTrackedEntities("Celeste.DreamBlock"))
                {
                    var entity = (OriginalDreamBlockState)item;
                    if (rumble)
                    {
                        if (fastAnimation)
                            entity.Add(new SimulationCoroutine(engine, entity.FastActivate()));
                        else
                            entity.Add(new SimulationCoroutine(engine, entity.Activate()));
                    }
                    else
                    {
                        entity.ActivateNoRoutine();
                    }
                }

                return;
            }

            if (activate || !level.Session.Inventory.DreamDash)
                return;
            level.Session.Inventory.DreamDash = false;
            foreach (var item in level.SourceScene.Entities.GetTrackedEntities("Celeste.DreamBlock"))
            {
                var entity = (OriginalDreamBlockState)item;
                if (rumble)
                {
                    if (fastAnimation)
                        entity.Add(new SimulationCoroutine(engine, entity.FastDeactivate()));
                    else
                        entity.Add(new SimulationCoroutine(engine, entity.Deactivate()));
                }
                else
                {
                    entity.DeactivateNoRoutine();
                }
            }
        }
    }
}
