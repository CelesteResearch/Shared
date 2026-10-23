using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scenes;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Game.Components.Talking;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.StarJump;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Entities.Npcs.Theo
{
    public class OriginalTempleEntranceTheoState : OriginalNpcState
    {
        private readonly ISourceEngineContext engine;

        public OriginalTempleEntranceTheoState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            this.engine = engine;
            OwnedComponents.Add(Sprite =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).SpriteBank
                .Create("theo"));
            IdleAnim = "idle";
            MoveAnim = "walk";
            Maxspeed = 48f;
            OwnedComponents.Add(Light =
                new VertexLightState(engine, -Vector2.UnitY * 12f, PackedColor.White, 1f, 32, 64));
            SetupTheoSpriteSounds();
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (base.Session.GetFlag("entrance"))
            {
                RemoveSelf();
            }
            else
            {
                ((ISourceScene)scene).SourceScene.QueueSourceEntity(new CS05TheoEntranceState(engine, this));
            }
        }
    }
}
