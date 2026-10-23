using System.Collections;
using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Clutter.Doors;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Stories.CelestialResort
{
    public class OshiroClutterSequence : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly int index;

        private readonly RoomPlayerSession player;

        private readonly NpcOshiroClutterState oshiro;

        private List<ClutterDoorState> doors;

        public OshiroClutterSequence(RoomPlayerSession player, NpcOshiroClutterState oshiro, int index,
            ISourceEngineContext engine)
            : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.oshiro = oshiro;
            this.index = index;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            doors = Level.SourceScene.Entities.FindAll<ClutterDoorState>();
            doors.Sort((a, b) => (int)(a.Y - b.Y));
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            var num = index != 1 && index != 2 ? 1 : -1;
            if (num == -1)
            {
                yield return player.DummyWalkToExact((int)oshiro.X - 24);
                player.Data.Facing = 1;
                oshiro.Sprite.Scale.X = -1f;
            }
            else
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, oshiro.PaceRight()));
                yield return player.DummyWalkToExact((int)oshiro.HomePosition.X + 24);
                player.Data.Facing = -1;
                oshiro.Sprite.Scale.X = 1f;
            }

            if (index < 3)
            {
                yield return Level.ZoomTo(oshiro.ZoomPoint, 2f, 0.5f);
                yield return TextboxState.Say("CH3_OSHIRO_CLUTTER" + index, Level.EngineContext, Collapse,
                    oshiro.PaceLeft,
                    oshiro.PaceRight);
                yield return Level.ZoomBack(0.5f);
                level.Session.SetFlag("oshiro_clutter_door_open");
                if (index == 0) SetMusic();

                foreach (var door in doors)
                    if (!door.IsLocked(level.Session))
                        yield return door.UnlockRoutine();
            }
            else
            {
                yield return CameraTo(Level.EngineContext,
                    new(Level.Bounds.X, Level.Bounds.Y), 0.5f);
                yield return Level.ZoomTo(new(90f, 60f), 2f, 0.5f);
                yield return TextboxState.Say("CH3_OSHIRO_CLUTTER_ENDING", Level.EngineContext);
                yield return oshiro.MoveTo(new(oshiro.X, level.Bounds.Top - 32));
                oshiro.PlayAttachedSound("event:/char/oshiro/move_05_09b_exit");
                yield return Level.ZoomBack(0.5f);
            }

            EndCutscene(level);
        }

        private IEnumerator Collapse()
        {
            var process = (IOriginalGameplayProcess)Level.EngineContext;
            process.AudioSession.Play("event:/char/oshiro/chat_collapse", oshiro.Position, process.SaveContext);
            oshiro.Sprite.Play("fall");
            yield return 0.5f;
        }

        private void SetMusic()
        {
            var obj = Scene as OriginalLevelSceneRoot;
            obj.Session.Audio.Music.Event = "event:/music/lvl3/clean";
            obj.Session.Audio.Music.SetProgress(1);
            var process = (IOriginalGameplayProcess)obj.EngineContext;
            OriginalAudioSession.Apply(obj.Session.Audio, process.AudioSession.ChannelOutput, process.AudioApplyPolicy);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            if (oshiro.Sprite.CurrentAnimationID == "side") (oshiro.Sprite as OshiroSpriteState).Pop("idle", true);

            if (index < 3)
            {
                level.Session.SetFlag("oshiro_clutter_door_open");
                level.Session.SetFlag("oshiro_clutter_" + index);
                if (index == 0 && WasSkipped) SetMusic();

                foreach (var door in doors)
                    if (!door.IsLocked(level.Session))
                        door.InstantUnlock();

                if (WasSkipped && index == 0) oshiro.Sprite.Play("idle_ground");
            }
            else
            {
                level.Session.SetFlag("oshiro_clutter_finished");
                oshiro.RemoveSelf();
            }
        }
    }
}
