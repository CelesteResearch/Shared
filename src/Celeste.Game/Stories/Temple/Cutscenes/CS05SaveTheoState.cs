using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Input.Runtime;
using Celeste.Scene.Following;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Stories.Temple.Cutscenes
{
    public class CS05SaveTheoState : OriginalCutsceneEntityState
    {
        public const string Flag = "foundTheoInCrystal";

        private RoomPlayerSession player;

        private readonly ISourceEngineContext engine;

        private TheoCrystalState theo;

        private Vector2 playerEndPosition;

        private bool wasDashAssistOn;

        public CS05SaveTheoState(ISourceEngineContext engine, RoomPlayerSession player) : base(engine)
        {
            this.engine = engine;
            this.player = player;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            theo = level.SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            playerEndPosition = theo.Position + new Vector2(-24f, 0f);
            wasDashAssistOn = ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.DashAssist;
            Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            player.ForceCameraUpdate = true;
            level.Session.Audio.Music.Layer(6, 0f);
            OriginalAudioSession.Apply(level.Session.Audio,
                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            yield return player.DummyWalkTo(theo.X - 18f);
            player.Data.Facing = 1;
            yield return TextboxState.Say("ch5_found_theo", engine, TryToBreakCrystal);
            yield return 0.25f;
            yield return Level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        private IEnumerator TryToBreakCrystal()
        {
            ((ISourceScene)Scene).SourceScene.Entities.FindFirst<TheoCrystalPedestalState>().Collidable = true;
            yield return player.DummyWalkTo(theo.X);
            yield return 0.1f;
            yield return Level.ZoomTo(new(160f, 90f), 2f, 0.5f);
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("lookUp");
            yield return 1f;
            wasDashAssistOn = ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.DashAssist;
            ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.DashAssist = false;
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                RumbleLength.Medium);
            ((ISourceMInputEnvironment)engine).MInput.Disabled = true;
            player.Motor.Dash.Data.OverrideDirection = new Vector2(0f, -1f);
            player.Machine.Locked = false;
            player.Machine.State = player.StartDash();
            player.Data.Dashes = 0;
            yield return 0.1f;
            while (!player.OnGround() || player.Data.Motion.Normal.Speed.Y < 0f)
            {
                player.Data.Dashes = 0;
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.MoveY.Value = -1;
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.MoveX.Value = 0;
                yield return null;
            }

            player.Motor.Dash.Data.OverrideDirection = null;
            player.Machine.State = 11;
            player.Machine.Locked = true;
            ((ISourceMInputEnvironment)engine).MInput.Disabled = false;
            player.Dummy.AutoAnimate = true;
            yield return player.DummyWalkToExact((int)playerEndPosition.X, true);
            yield return 1.5f;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Assists.DashAssist = wasDashAssistOn;
            player.Position = playerEndPosition;
            while (!player.OnGround()) player.MoveV(1f);

            level.Camera.Position = player.CameraTarget;
            level.Session.SetFlag("foundTheoInCrystal");
            level.ResetZoom();
            level.Session.Audio.Music.Layer(6, 1f);
            OriginalAudioSession.Apply(level.Session.Audio,
                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            var list = new List<FollowerState>(player.Leader.Followers);
            player.RemoveSelf();
            level.Scheduler.QueueSourceEntity(player = level.CreatePlayer(player.Position, player.DefaultSpriteMode));
            foreach (var item in list)
            {
                player.Leader.Followers.Add(item);
                item.Leader = player.Leader;
            }

            player.Data.Facing = 1;
            player.IntroType = PlayerIntroType.None;
            var theoCrystalPedestal =
                ((ISourceScene)Scene).SourceScene.Entities.FindFirst<TheoCrystalPedestalState>();
            theoCrystalPedestal.Collidable = false;
            theoCrystalPedestal.DroppedTheo = true;
            theo.Depth = 100;
            theo.OnPedestal = false;
            theo.Speed = Vector2.Zero;
            while (!theo.OnGround()) theo.MoveV(1f);
        }
    }
}
