using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Stories.CelestialResort.Cutscenes
{
    public class CS03OshiroHallway1State : OriginalCutsceneEntityState
    {
        public const string Flag = "oshiro_resort_talked_2";

        private readonly RoomPlayerSession player;

        private readonly OriginalNpcState oshiro;

        private readonly ISourceEngineContext engine;

        public CS03OshiroHallway1State(ISourceEngineContext engine, RoomPlayerSession player, OriginalNpcState oshiro) :
            base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.oshiro = oshiro;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            level.Session.Audio.Music.Layer(1, false);
            level.Session.Audio.Music.Layer(2, true);
            OriginalAudioSession.Apply(level.Session.Audio,
                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return TextboxState.Say("CH3_OSHIRO_HALLWAY_A", engine);
            oshiro.MoveToAndRemove(new(Level.Bounds.Right + 64, oshiro.Y));
            oshiro.OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                .Play("event:/char/oshiro/move_02_03a_exit"));
            yield return 1f;
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.Session.Audio.Music.Layer(1, true);
            level.Session.Audio.Music.Layer(2, false);
            OriginalAudioSession.Apply(level.Session.Audio,
                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            player.Machine.Locked = false;
            player.Machine.State = 0;
            level.Session.SetFlag("oshiro_resort_talked_2");
            if (WasSkipped) oshiro.RemoveSelf();
        }
    }
}
