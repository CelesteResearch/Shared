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
    public class CS05TheoEntranceState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public const string Flag = "entrance";

        private OriginalNpcState theo;

        private RoomPlayerSession player;

        private Vector2 playerMoveTo;

        public CS05TheoEntranceState(ISourceEngineContext engine, OriginalNpcState theo)
            : base(engine)
        {
            this.engine = engine;
            this.theo = theo;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player = level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            player.Machine.State = 11;
            player.Machine.Locked = true;
            player.X = theo.X - 32f;
            playerMoveTo = new Vector2(theo.X - 32f, player.Y);
            player.Data.Facing = -1;
            ((ISourceScreenWipeEnvironment)engine).ProcessWipe.SpotlightFocusPoint =
                theo.TopCenter - Vector2.UnitX * 16f - level.Camera.Position;
            yield return 2f;
            player.Data.Facing = 1;
            yield return 0.3f;
            yield return theo.MoveTo(new Vector2(theo.X + 48f, theo.Y));
            yield return TextboxState.Say("ch5_entrance", engine, MaddyTurnsRight, TheoTurns, TheoLeaves);
            EndCutscene(level);
        }

        private IEnumerator MaddyTurnsRight()
        {
            player.Data.Facing = 1;
            yield break;
        }

        private IEnumerator TheoTurns()
        {
            theo.Sprite.Scale.X *= -1f;
            yield break;
        }

        private IEnumerator TheoLeaves()
        {
            yield return theo.MoveTo(new Vector2(Level.Bounds.Right + 32, theo.Y));
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (player != null)
            {
                player.Machine.Locked = false;
                player.Machine.State = 0;
                player.ForceCameraUpdate = false;
                player.Position = playerMoveTo;
                player.Data.Facing = 1;
            }

            ((ISourceScene)Scene).SourceScene.RemoveEntity(theo);
            level.Session.SetFlag("entrance");
        }
    }
}
