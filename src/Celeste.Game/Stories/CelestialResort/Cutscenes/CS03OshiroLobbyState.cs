using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Graphics.Display;
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
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Components.Animation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Simulation.Gameplay.Walls.Breakable;

namespace Celeste.Game.Stories.CelestialResort.Cutscenes
{
    public class CS03OshiroLobbyState : OriginalCutsceneEntityState
    {
        public const string Flag = "oshiro_resort_talked_1";

        private RoomPlayerSession player;

        private OriginalNpcState oshiro;

        private float startLightAlpha;

        private bool createSparks;

        private SoundSourceComponentState sfx;

        private readonly ISourceEngineContext engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceScalarArithmetic Scalar => ((ISourceScalarEnvironment)engine).ScalarArithmetic;
        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public CS03OshiroLobbyState(ISourceEngineContext engine, RoomPlayerSession player, OriginalNpcState oshiro)
            : this(engine, player, oshiro, ((ISourceSoundSourceEnvironment)engine).SoundSources.Create())
        {
        }

        private CS03OshiroLobbyState(ISourceEngineContext engine, RoomPlayerSession player, OriginalNpcState oshiro,
            SoundSourceComponentState sourceSfx) : base(engine)
        {
            this.player = player;
            this.engine = engine;
            this.oshiro = oshiro;
            OwnedComponents.Add(sfx = sourceSfx);
        }

        public override void Update()
        {
            base.Update();
            if (createSparks && Level.OnInterval(0.025f))
            {
                Vector2 vector = oshiro.Position + new Vector2(0f, -12f) + new Vector2(
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 4, 12) *
                    RandomSelection.Choose(((ISourceRandomEnvironment)engine).Random, 1, -1),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 4, 12) *
                    RandomSelection.Choose(((ISourceRandomEnvironment)engine).Random, 1, -1));
                Level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.NPC03_Oshiro_Lobby.P_AppearSpark,
                    vector, Vector2Geometry.Angle(vector - oshiro.Position));
            }
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            startLightAlpha = level.Lighting.Alpha;
            float endLightAlpha = 1f;
            float from = oshiro.Y;
            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return 0.5f;
            yield return player.DummyWalkTo(oshiro.X - 16f);
            player.Data.Facing = 1;
            sfx.Play("event:/game/03_resort/sequence_oshiro_intro");
            Rumble(1, 1);
            yield return 1.4f;
            level.Shake();
            level.Lighting.Alpha += 0.5f;
            while (level.Lighting.Alpha > startLightAlpha)
            {
                level.Lighting.Alpha -= engine.DeltaTime * 4f;
                yield return null;
            }

            VertexLightState light = new VertexLightState(engine, new Vector2(0f, -8f), PackedColor.White, 1f, 32, 64);
            BloomPointState bloom = new BloomPointState(new Vector2(0f, -8f), 1f, 16f);
            level.Lighting.SetSpotlight(light);
            oshiro.OwnedComponents.Add(light);
            oshiro.OwnedComponents.Add(bloom);
            oshiro.Y -= 16f;
            Vector2 target = light.Position;
            SourceTweenState tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                Ease.CubeOut, 0.5f, start: true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                light.Alpha = (bloom.Alpha = t.Percent);
                light.Position = Vector2Interpolation.Lerp(target - Vector2.UnitY * 48f, target, t.Percent, Scalar);
                level.Lighting.Alpha = Scalar.Lerp(startLightAlpha, endLightAlpha, t.Eased);
            };
            OwnedComponents.Add(tween);
            yield return tween.Wait();
            yield return 0.2f;
            yield return level.ZoomTo(new Vector2(170f, 126f), 2f, 0.5f);
            yield return 0.6f;
            level.Shake();
            oshiro.Sprite.Visible = true;
            oshiro.Sprite.Play("appear");
            yield return player.DummyWalkToExact((int)(player.X - 12f), walkBackwards: true);
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("shaking");
            Rumble(1, 3);
            yield return 0.6f;
            createSparks = true;
            yield return 0.4f;
            createSparks = false;
            yield return 0.2f;
            level.Shake();
            Rumble(2, 1);
            yield return 1.4f;
            level.Lighting.UnsetSpotlight();
            SourceTweenState tween2 = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                Ease.CubeIn, 0.5f, start: true);
            tween2.OnUpdate = delegate(SourceTweenState t)
            {
                level.Lighting.Alpha = Scalar.Lerp(endLightAlpha, startLightAlpha, t.Percent);
                bloom.Alpha = 1f - t.Percent;
            };
            OwnedComponents.Add(tween2);
            while (oshiro.Y != from)
            {
                oshiro.Y = ScalarMath.Approach(oshiro.Y, from, engine.DeltaTime * 40f, Extrema);
                yield return null;
            }

            yield return tween2.Wait();
            ((IOriginalGameplayProcess)engine).AudioSession.SetMusic("event:/music/lvl3/oshiro_theme");
            player.Dummy.AutoAnimate = true;
            yield return TextboxState.Say("CH3_OSHIRO_FRONT_DESK", engine, ZoomOut);
            foreach (OriginalMrOshiroDoorState item in Level.SourceScene.Entities.FindAll<OriginalMrOshiroDoorState>())
            {
                item.Open();
            }

            oshiro.MoveToAndRemove(new Vector2(level.Bounds.Right + 64, oshiro.Y));
            oshiro.OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                .Play("event:/char/oshiro/move_01_0xa_exit"));
            yield return 1.5f;
            EndCutscene(level);
        }

        private IEnumerator ZoomOut()
        {
            yield return 0.2f;
            yield return Level.ZoomBack(0.5f);
            yield return 0.2f;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            if (WasSkipped)
            {
                foreach (OriginalMrOshiroDoorState item in
                         Level.SourceScene.Entities.FindAll<OriginalMrOshiroDoorState>())
                {
                    item.InstantOpen();
                }
            }

            level.Lighting.Alpha = startLightAlpha;
            level.Lighting.UnsetSpotlight();
            level.Session.SetFlag("oshiro_resort_talked_1");
            level.Session.Audio.Music.Event = "event:/music/lvl3/explore";
            level.Session.Audio.Music.SetProgress(1);
            ApplyAudio(level);
            if (WasSkipped)
            {
                oshiro.RemoveSelf();
            }
        }

        private void ApplyAudio(OriginalLevelSceneRoot level) => OriginalAudioSession.Apply(level.Session.Audio,
            ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
            ((IOriginalGameplayProcess)engine).AudioApplyPolicy);

        private void Rumble(int strength, int length) =>
            ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession
            .Rumble(strength, length);
    }
}
