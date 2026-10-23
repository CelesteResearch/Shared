using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Audio;
using Celeste.Game.UI.Dialogue.Textboxes;

namespace Celeste.Game.Stories.CelestialResort.Cutscenes
{
    public class CS03OshiroHallway2State : OriginalCutsceneEntityState
    {
        public const string Flag = "oshiro_resort_talked_3";

        private RoomPlayerSession player;

        private OriginalNpcState oshiro;

        private readonly ISourceEngineContext engine;

        public CS03OshiroHallway2State(ISourceEngineContext engine, RoomPlayerSession player, OriginalNpcState oshiro) :
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
            level.Session.Audio.Music.Layer(1, value: false);
            level.Session.Audio.Music.Layer(2, value: true);
            OriginalAudioSession.Apply(level.Session.Audio,
                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return TextboxState.Say("CH3_OSHIRO_HALLWAY_B", engine);
            oshiro.MoveToAndRemove(new Vector2(level.Bounds.Right + 64, oshiro.Y));
            oshiro.OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                .Play("event:/char/oshiro/move_03_08a_exit"));
            yield return 1f;
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            level.Session.Audio.Music.Layer(1, value: true);
            level.Session.Audio.Music.Layer(2, value: false);
            OriginalAudioSession.Apply(level.Session.Audio,
                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            player.Machine.Locked = false;
            player.Machine.State = 0;
            level.Session.SetFlag("oshiro_resort_talked_3");
            if (WasSkipped)
            {
                oshiro.RemoveSelf();
            }
        }
    }
}
