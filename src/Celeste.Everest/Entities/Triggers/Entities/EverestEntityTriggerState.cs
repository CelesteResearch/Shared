using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Entities.Triggers.Entities
{
    public class EverestEntityTriggerState : SourceTriggerEntityState
    {
        private readonly bool manualTrigger;
        private readonly bool persistent;
        private MapEntityId id;
        private readonly float left;
        private readonly float right;
        private readonly float top;
        private readonly float bottom;
        private readonly List<EntityTriggerListenerState> listeners;
        private bool triggered;

        public EverestEntityTriggerState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            MapEntityId id)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            manualTrigger = data.Bool("manualTrigger");
            persistent = data.Bool("persistent");
            this.id = id;
            listeners = [];
            var array = data.NodesOffset(offset);
            if (array.Length >= 2)
            {
                var extrema = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
                left = extrema.Min(array[0].X, array[1].X);
                right = extrema.Max(array[0].X, array[1].X);
                top = extrema.Min(array[0].Y, array[1].Y);
                bottom = extrema.Max(array[0].Y, array[1].Y);
            }
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var flag = persistent && ((OriginalLevelSceneRoot)Scene).Session.GetFlag(id.ToString());
            foreach (EntityTriggerListenerState component in
                     ((ISourceTrackedComponents)((ISourceScene)scene).ComponentIndex)
                     .GetTrackedComponents("Celeste.Mod.Entities.EntityTriggerListener"))
            {
                var entity = (SceneEntityState)component.Entity;
                if (entity.X >= left && entity.X <= right && entity.Y >= top && entity.Y <= bottom)
                {
                    if (flag) component.OnStartTriggered?.Invoke();
                    else listeners.Add(component);
                }
            }

            if (flag) RemoveSelf();
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            if (!manualTrigger) Invoke();
        }

        public static void ManuallyTrigger(ISourceEngineContext engine, Vector2 point)
        {
            foreach (EverestEntityTriggerState entity in ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene
                     .Entities
                     .GetTrackedEntities("Celeste.Mod.Entities.EntityTrigger"))
                if (entity.manualTrigger && point.X >= entity.left && point.X <= entity.right &&
                    point.Y >= entity.top &&
                    point.Y <= entity.bottom)
                    entity.Invoke();
        }

        private void Invoke()
        {
            if (triggered) return;
            triggered = true;
            if (persistent) ((OriginalLevelSceneRoot)Scene).Session.SetFlag(id.ToString());
            foreach (var listener in listeners) listener.OnTrigger?.Invoke();
        }
    }
}
