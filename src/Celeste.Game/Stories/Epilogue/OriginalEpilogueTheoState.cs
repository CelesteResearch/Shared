using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Input.Gameplay;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Presentation.Hud.Speedrun;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Settings;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Presentation.Hud.Counters;
using Celeste.Game.Presentation.Hud.Speedrun;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Stories.Epilogue
{
    public class OriginalEpilogueTheoState : OriginalNpcState
    {
        public OriginalEpilogueTheoState(ISourceEngineContext engine,
            global::Celeste.Formats.Map.Entities.Structure.EntityData data, Vector2 position)
            : base(engine, data.Position + position)
        {
            OwnedComponents.Add(Sprite = ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine)
                .GameGraphics.SpriteFactory.Create("theo"));
            Sprite.Scale.X = -1f;
            Sprite.Play("idle");
            IdleAnim = "idle";
            MoveAnim = "walk";
            Maxspeed = 30f;
        }
    }
}
