using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Walls.Breakable;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Stories.CelestialResort.Cutscenes
{
    public class CS03OshiroMasterSuiteState : OriginalCutsceneEntityState
    {
        public const string Flag = "oshiro_resort_suite";

        private RoomPlayerSession player;

        private readonly OriginalNpcState oshiro;

        private BadelineDummyPresentation evil;

        private OriginalResortMirrorState mirror;

        private readonly ISourceEngineContext engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceScalarArithmetic Scalar => ((ISourceScalarEnvironment)engine).ScalarArithmetic;
        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public CS03OshiroMasterSuiteState(ISourceEngineContext engine, OriginalNpcState oshiro) : base(engine)
        {
            this.engine = engine;
            this.oshiro = oshiro;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            mirror = Level.SourceScene.Entities.FindFirst<OriginalResortMirrorState>();
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            while (true)
            {
                player = Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
                if (player != null) break;

                yield return null;
            }

            ((IOriginalGameplayProcess)engine).AudioSession.SetMusic(null);
            yield return 0.4f;
            player.Machine.State = 11;
            player.Machine.Locked = true;
            OwnedComponents.Add(new SimulationCoroutine(engine, player.DummyWalkTo(oshiro.X + 32f)));
            yield return 1f;
            ((IOriginalGameplayProcess)engine).AudioSession.SetMusic("event:/music/lvl3/oshiro_theme");
            yield return TextboxState.Say("CH3_OSHIRO_SUITE", engine, SuiteShadowAppear, SuiteShadowDisrupt,
                SuiteShadowCeiling, Wander, Console, JumpBack, Collapse, AwkwardPause);
            evil.OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                .Play("event:/game/03_resort/suite_bad_exittop"));
            yield return evil.FloatTo(new(evil.X, level.Bounds.Top - 32));
            evil.RemoveSelf();
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (level.Lighting.Alpha != level.BaseLightingAlpha)
            {
                level.Lighting.Alpha = ScalarMath.Approach(level.Lighting.Alpha, level.BaseLightingAlpha,
                    engine.DeltaTime * 0.5f, Extrema);
                yield return null;
            }

            EndCutscene(level);
        }

        private IEnumerator Wander()
        {
            yield return 0.5f;
            player.Data.Facing = 1;
            yield return 0.1f;
            yield return player.DummyWalkToExact((int)oshiro.X + 48);
            yield return 1f;
            player.Data.Facing = -1;
            yield return 0.2f;
            yield return player.DummyWalkToExact((int)oshiro.X - 32);
            yield return 0.1f;
            oshiro.Sprite.Scale.X = -1f;
            yield return 0.2f;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("lookUp");
            yield return 1f;
            player.Dummy.AutoAnimate = true;
            yield return 0.4f;
            player.Data.Facing = 1;
            yield return 0.2f;
            yield return player.DummyWalkToExact((int)oshiro.X - 24);
            yield return 0.5f;
            var level = Level;
            yield return level.ZoomTo(new(190f, 110f), 2f, 0.5f);
        }

        private IEnumerator AwkwardPause()
        {
            yield return 2f;
        }

        private IEnumerator SuiteShadowAppear()
        {
            if (mirror != null)
            {
                mirror.EvilAppear();
                SetMusic();
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/03_resort/suite_bad_intro",
                    mirror.Position, ((IOriginalGameplayProcess)engine).SaveContext);
                var from = Level.ZoomFocusPoint;
                var to = new Vector2(216f, 110f);
                for (var p = 0f; p < 1f; p += engine.DeltaTime * 2f)
                {
                    Level.ZoomFocusPoint = from + (to - from) * Ease.SineInOut(p);
                    yield return null;
                }

                yield return null;
            }
        }

        private IEnumerator SuiteShadowDisrupt()
        {
            if (mirror != null)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/03_resort/suite_bad_mirrorbreak",
                    mirror.Position, ((IOriginalGameplayProcess)engine).SaveContext);
                yield return mirror.SmashRoutine();
                evil = BadelineDummyPresentation.Create(Level, mirror.Position + new Vector2(0f, -8f));
                Level.Scheduler.QueueSourceEntity(evil);
                yield return 1.2f;
                oshiro.Sprite.Scale.X = 1f;
                yield return evil.FloatTo(oshiro.Position + new Vector2(32f, -24f));
            }
        }

        private IEnumerator Collapse()
        {
            oshiro.Sprite.Play("fall");
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/oshiro/chat_collapse", oshiro.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            yield return null;
        }

        private IEnumerator Console()
        {
            yield return player.DummyWalkToExact((int)oshiro.X - 16);
        }

        private IEnumerator JumpBack()
        {
            yield return player.DummyWalkToExact((int)oshiro.X - 24, true);
            yield return 0.8f;
        }

        private IEnumerator SuiteShadowCeiling()
        {
            yield return Level.ZoomBack(0.5f);
            evil.OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                .Play("event:/game/03_resort/suite_bad_movestageleft"));
            yield return evil.FloatTo(new(Level.Bounds.Left + 96, evil.Y - 16f), 1);
            player.Data.Facing = -1;
            yield return 0.25f;
            evil.OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                .Play("event:/game/03_resort/suite_bad_ceilingbreak"));
            Rumble(2, 2);
            Level.DirectionalShake(-Vector2.UnitY);
            yield return evil.SmashBlock(evil.Position + new Vector2(0f, -32f));
            yield return 0.8f;
        }

        private void SetMusic()
        {
            if (Level.Session.Mode == (int)OriginalAreaMode.Normal)
            {
                Level.Session.Audio.Music.Event = "event:/music/lvl2/evil_madeline";
                ApplyAudio(Level);
            }
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (WasSkipped)
            {
                if (evil != null) evil.RemoveSelf();

                if (mirror != null) mirror.Broken();

                Level.SourceScene.Entities
                    .FindFirst<OriginalDashBlockState>()
                    ?.RemoveAndFlagAsGone();
                oshiro.Sprite.Play("idle_ground");
            }

            oshiro.Talker.Enabled = true;
            if (player != null)
            {
                player.Machine.Locked = false;
                player.Machine.State = 0;
            }

            level.Lighting.Alpha = level.BaseLightingAlpha;
            level.Session.SetFlag("oshiro_resort_suite");
            SetMusic();
        }

        private void ApplyAudio(OriginalLevelSceneRoot level)
        {
            OriginalAudioSession.Apply(level.Session.Audio,
                ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
        }

        private void Rumble(int strength, int length)
        {
            ((ISourceRumbleEnvironment)engine).RumbleSession
                .Rumble(strength, length);
        }
    }
}
