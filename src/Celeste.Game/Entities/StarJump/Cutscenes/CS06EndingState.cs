using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components.Timing;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Entities.StarJump.Cutscenes
{
    public class CS06EndingState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private RoomPlayerSession player;

        private BadelineDummyPresentation badeline;

        private OriginalNpcState granny;

        private OriginalNpcState theo;

        public CS06EndingState(RoomPlayerSession player, OriginalNpcState granny, ISourceEngineContext engine)
            : base(engine, false, true)
        {
            this.engine = engine;
            this.player = player;
            this.granny = granny;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            level.RegisterAreaComplete();
            theo = Level.SourceScene.Entities.FindFirst<OriginalTheoEndingState>();
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return 1f;
            player.Data.Dashes = 1;
            level.Session.Inventory.Dashes = 1;
            level.Scheduler.QueueSourceEntity(badeline = BadelineDummyPresentation.Create(level, player.Center));
            badeline.Appear(level, silent: true);
            badeline.FloatSpeed = 80f;
            badeline.Sprite.Scale.X = -1f;
            Process.AudioSession.Play("event:/char/badeline/maddy_split", player.Center, Process.SaveContext);
            yield return badeline.FloatTo(player.Position + new Vector2(24f, -20f), -1, faceDirection: false);
            yield return level.ZoomTo(new Vector2(160f, 120f), 2f, 1f);
            yield return TextboxState.Say("ch6_ending", engine, GrannyEnter, TheoEnter, MaddyTurnsRight,
                BadelineTurnsRight,
                BadelineTurnsLeft, WaitAbit, TurnToLeft, TheoRaiseFist, TheoStopTired);
            Process.AudioSession.Play("event:/char/madeline/backpack_drop", player.Position, Process.SaveContext);
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("bagdown");
            EndCutscene(level);
        }

        private IEnumerator GrannyEnter()
        {
            yield return 0.25f;
            badeline.Sprite.Scale.X = 1f;
            yield return 0.1f;
            granny.Visible = true;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                badeline.FloatTo(new Vector2(badeline.X - 10f, badeline.Y), 1, faceDirection: false)));
            yield return granny.MoveTo(player.Position + new Vector2(40f, 0f));
        }

        private IEnumerator TheoEnter()
        {
            player.Data.Facing = -1;
            badeline.Sprite.Scale.X = -1f;
            yield return 0.25f;
            yield return OriginalCutsceneEntityState.CameraTo(engine, new Vector2(Level.Camera.X - 40f, Level.Camera.Y),
                1f);
            theo.Visible = true;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, new Vector2(Level.Camera.X + 40f, Level.Camera.Y), 2f,
                    null,
                    1f)));
            OwnedComponents.Add(new SimulationCoroutine(engine,
                badeline.FloatTo(new Vector2(badeline.X + 6f, badeline.Y + 4f), -1, faceDirection: false)));
            yield return theo.MoveTo(player.Position + new Vector2(-32f, 0f));
            theo.Sprite.Play("tired");
        }

        private IEnumerator MaddyTurnsRight()
        {
            yield return 0.1f;
            player.Data.Facing = 1;
            yield return 0.1f;
            yield return badeline.FloatTo(badeline.Position + new Vector2(-2f, 10f), -1, faceDirection: false);
            yield return 0.1f;
        }

        private IEnumerator BadelineTurnsRight()
        {
            yield return 0.1f;
            badeline.Sprite.Scale.X = 1f;
            yield return 0.1f;
        }

        private IEnumerator BadelineTurnsLeft()
        {
            yield return 0.1f;
            badeline.Sprite.Scale.X = -1f;
            yield return 0.1f;
        }

        private IEnumerator WaitAbit()
        {
            yield return 0.4f;
        }

        private IEnumerator TurnToLeft()
        {
            yield return 0.1f;
            player.Data.Facing = -1;
            yield return 0.05f;
            badeline.Sprite.Scale.X = -1f;
            yield return 0.1f;
        }

        private IEnumerator TheoRaiseFist()
        {
            theo.Sprite.Play("yolo");
            OwnedComponents.Add(SourceAlarmState.Create(engine.AlarmPool, SourceAlarmState.AlarmMode.Oneshot,
                delegate { theo.Sprite.Play("yoloEnd"); }, 0.8f, start: true));
            yield return null;
        }

        private IEnumerator TheoStopTired()
        {
            theo.Sprite.Play("idle");
            yield return null;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.CompleteArea();
            ((ISourceScreenWipeEnvironment)engine).ProcessWipe.SpotlightFocusPoint += new Vector2(0f, -20f);
        }
    }
}
