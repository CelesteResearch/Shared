using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Graphics.Display;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Settings;
using Celeste.Game.Audio;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalOshiroHallway2State : OriginalNpcState
    {
        private bool talked;

        public OriginalOshiroHallway2State(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            OwnedComponents.Add(Sprite = new OshiroSpriteState(engine, -1));
            OwnedComponents.Add(Light =
                new VertexLightState(engine, -Vector2.UnitY * 16f, PackedColor.White, 1f, 32, 64));
            MoveAnim = "move";
            IdleAnim = "idle";
        }

        public OriginalOshiroHallway2State(EntityData data, Vector2 offset, ISourceEngineContext engine) : this(
            engine, data.Position + offset)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (base.Session.GetFlag("oshiro_resort_talked_3"))
            {
                RemoveSelf();
            }
            else
            {
                base.Session.LightingAlphaAdd = 0.15f;
            }
        }

        public override void Update()
        {
            base.Update();
            RoomPlayerSession entity =
                Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (!talked && entity != null && entity.X > base.X - 60f)
            {
                Level.Scheduler.QueueSourceEntity(new CS03OshiroHallway2State(Engine, entity, this));
                talked = true;
            }
        }
    }
}
