using System.Collections;
using EventInstance = Celeste.Audio.Fmod.Events.FmodEventReference;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Audio;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Game.UI.Dialogue.Textboxes;
using Player = Celeste.Simulation.RoomPlayerSession;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;
using BadelineDummy = Celeste.Game.Entities.BadelineDummy.BadelineDummyPresentation;

namespace Celeste.Game.Stories.Farewell.Help
{
    public class OriginalBadelineHelpsCutscene : OriginalCutsceneEntityState
    {
        public const string Flag = "badeline_helps";

        private Player player;

        private BadelineDummy badeline;

        private EventInstance entrySfx;

        private readonly ISourceEngineContext engine;

        public OriginalBadelineHelpsCutscene(ISourceEngineContext engine, Player player) : base(engine)
        {
            base.Depth = -8500;
            this.engine = engine;
            this.player = player;
        }

        public override void OnBegin(Level level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(Level level)
        {
            Vector2 spawn = level.GetSpawnPoint(player.Position);
            player.Data.Dashes = 2;
            player.Machine.State = 11;
            player.Dummy.Gravity = false;
            entrySfx = ((IOriginalGameplayProcess)engine).AudioSession.Play(
                "event:/new_content/char/madeline/screenentry_stubborn", player.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            yield return player.MoonLanding(spawn);
            yield return level.ZoomTo(new Vector2(spawn.X - level.Camera.X, 134f), 2f, 0.5f);
            yield return 1f;
            yield return BadelineAppears();
            yield return 0.3f;
            yield return TextboxState.Say("CH9_HELPING_HAND", engine, MadelineFacesAway, MadelineFacesBadeline,
                MadelineStepsForwards);
            if (badeline != null)
            {
                yield return BadelineVanishes();
            }

            yield return level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        private IEnumerator BadelineAppears()
        {
            StartMusic();
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/badeline/maddy_split", player.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            Level.AddEntity(badeline = new BadelineDummy(engine, player.Center));
            Level.Displacement.AddBurst(badeline.Center, 0.5f, 8f, 32f, 0.5f);
            player.Data.Dashes = 1;
            badeline.Sprite.Scale.X = -1f;
            yield return badeline.FloatTo(player.Center + new Vector2(18f, -10f), -1, faceDirection: false);
            yield return 0.2f;
            player.Data.Facing = 1;
            yield return null;
        }

        private IEnumerator MadelineFacesAway()
        {
            Level.NextColorGrade("feelingdown", 0.1f);
            yield return player.Dummy.WalkTo(player.X - 16f);
        }

        private IEnumerator MadelineFacesBadeline()
        {
            player.Data.Facing = 1;
            yield return 0.2f;
        }

        private IEnumerator MadelineStepsForwards()
        {
            Vector2 spawnPoint = Level.GetSpawnPoint(player.Position);
            OwnedComponents.Add(new SimulationCoroutine(engine, player.DummyWalkToExact((int)spawnPoint.X)));
            yield return 0.1f;
            yield return badeline.FloatTo(badeline.Position + new Vector2(20f, 0f), null, faceDirection: false);
        }

        private IEnumerator BadelineVanishes()
        {
            yield return 0.2f;
            badeline.Vanish();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
            badeline = null;
            yield return 0.2f;
        }

        private void StartMusic()
        {
            if (Level.Session.Audio.Music.Event != "event:/new_content/music/lvl10/cassette_rooms")
            {
                int num = 0;
                var managers = Level.Scheduler.Entities.GetTrackedEntities("Celeste.CassetteBlockManager");
                OriginalCassetteBlockManagerState entity =
                    managers.Count == 0 ? null : (OriginalCassetteBlockManagerState)managers[0];
                if (entity != null)
                {
                    num = entity.GetSixteenthNote();
                }

                Level.Session.Audio.Music.Event = "event:/new_content/music/lvl10/cassette_rooms";
                Level.Session.Audio.Music.Param("sixteenth_note", num);
                Celeste.Game.Audio.OriginalAudioSession.Apply(Level.Session.Audio,
                    ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                    ((IOriginalGameplayProcess)engine).AudioApplyPolicy, forceSixteenthNoteHack: true);
                Level.Session.Audio.Music.Param("sixteenth_note", 7f);
            }
        }

        public override void OnEnd(Level level)
        {
            Level.Session.Inventory.Dashes = 1;
            player.Data.Dashes = 1;
            player.Depth = 0;
            player.Data.Dashes = 1;
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Position = level.GetSpawnPoint(player.Position);
            player.Position -= Vector2.UnitY * 12f;
            player.MoveVExact(100);
            player.Active = true;
            player.Visible = true;
            player.Machine.State = 0;
            if (badeline != null)
            {
                badeline.RemoveSelf();
            }

            level.ResetZoom();
            level.Session.SetFlag("badeline_helps");
            if (WasSkipped)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Stop(entrySfx);
                StartMusic();
                level.SnapColorGrade("feelingdown");
            }
        }
    }
}
