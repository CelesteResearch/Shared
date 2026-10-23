using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Entities.Hazards.Spinners.Crystal;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Gameplay.Triggers.Hazards
{
    [CustomEntity("everest/crystalShatterTrigger", "outback/destroycrystalstrigger")]
    public class CrystalShatterTrigger : SourceTriggerEntityState
    {
        public enum Modes
        {
            Contained,
            All
        }

        private enum ModesLegacy
        {
            InTrigger,
            EveryCrystal
        }

        private Modes mode;
        private readonly ISourceEngineContext engine;

        public CrystalShatterTrigger(ISourceEngineContext engine, OriginalLevelEntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            if (data.Values != null && EntityAttributeReader.Has(data.Values, "destroyEveryCrystal"))
                mode = (Modes)EntityAttributeReader.Enum(data.Values, "destroyEveryCrystal", ModesLegacy.InTrigger);
            if (data.Values != null && EntityAttributeReader.Has(data.Values, "mode"))
                mode = EntityAttributeReader.Enum(data.Values, "mode", Modes.Contained);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            var entities =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.CrystalStaticSpinner");
            if (entities.Count > 0)
            {
                if (mode == Modes.All)
                    ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/06_reflection/boss_spikes_burst");
                foreach (var entity in entities)
                {
                    var item = (OriginalCrystalStaticSpinner)entity;
                    bool collidable = item.Collidable;
                    item.Collidable = true;
                    if (mode == Modes.All || SourceEntityCollision.Check(this, item))
                        item.Destroy();
                    item.Collidable = collidable;
                }
            }

            RemoveSelf();
        }
    }
}
