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
    public class CS08EnterDoorState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private RoomPlayerSession player;

        private float targetX;

        public CS08EnterDoorState(ISourceEngineContext engine, RoomPlayerSession player, float targetX) : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.targetX = targetX;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                player.DummyWalkToExact((int)targetX, walkBackwards: false, 0.7f)));
            OwnedComponents.Add(new SimulationCoroutine(engine,
                level.ZoomTo(new Vector2(targetX - level.Camera.X, 90f), 2f, 2f)));
            FadeWipePresentation fadeWipe = new FadeWipePresentation(level, wipeIn: false);
            fadeWipe.Duration = 2f;
            yield return fadeWipe.Wait();
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.OnEndOfFrame += delegate
            {
                level.RemoveEntity(player);
                level.UnloadLevel();
                level.Session.Level = "inside";
                level.Session.RespawnPoint = level.GetSpawnPoint(new Vector2(level.Bounds.Left, level.Bounds.Top));
                level.LoadLevel(PlayerIntroType.None);
                level.Scheduler.QueueSourceEntity(new CS08EndingState(engine));
            };
        }
    }
}
