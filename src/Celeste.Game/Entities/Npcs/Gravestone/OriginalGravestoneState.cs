using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Scene.Entities;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Components.Talking;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.BadelineBoosts;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Gravestone
{
    public class OriginalGravestoneState : OriginalNpcState
    {
        private readonly ISourceEngineContext engine;
        private const string Flag = "gravestone";

#pragma warning disable CS0169 // Retain the original field and its original default state.
        private RoomPlayerSession player;
#pragma warning restore CS0169

        private Vector2 boostTarget;

        private OriginalTalkComponent talk;

        public OriginalGravestoneState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(engine, data.Position + offset)
        {
            this.engine = engine;
            boostTarget = data.FirstNodeNullable(offset) ?? Vector2.Zero;
            OwnedComponents.Add(talk = new OriginalTalkComponent((IOriginalTalkProcess)engine,
                new IntRect(-24, -8, 32, 8),
                new Vector2(-0.5f, -20f), Interact));
            talk.PlayerMustBeFacing = false;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Level.Session.GetFlag("gravestone"))
            {
                Level.Scheduler.QueueSourceEntity(new BadelineBoostState(engine, new Vector2[1] { boostTarget },
                    lockCamera: false));
                talk.RemoveSelf();
            }
        }

        private void Interact(RoomPlayerSession player)
        {
            Level.Session.SetFlag("gravestone");
            Level.Scheduler.QueueSourceEntity(new CS10GravestoneState(engine, player, this, boostTarget));
            talk.Enabled = false;
        }
    }
}
