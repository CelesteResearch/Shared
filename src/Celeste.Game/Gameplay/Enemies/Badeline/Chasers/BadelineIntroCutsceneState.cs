using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Controls.Source;

namespace Celeste.Game.Gameplay.Enemies.Badeline.Chasers
{
    public class BadelineIntroCutsceneState : OriginalCutsceneEntityState
    {
        public const string Flag = "evil_maddy_intro";

        private RoomPlayerSession player;

        private BadelineOldsiteState badeline;

        private Vector2 badelineEndPosition;

        private float anxietyFade;

        private float anxietyFadeTarget;

        private SineWaveState anxietySine;

        private float anxietyJitter;

        private readonly ISourceEngineContext engine;

        public BadelineIntroCutsceneState(ISourceEngineContext engine, BadelineOldsiteState badeline) : base(engine)
        {
            this.engine = engine;
            this.badeline = badeline;
            badelineEndPosition = badeline.Position + new Vector2(8f, -24f);
            OwnedComponents.Add(anxietySine = new SineWaveState(engine, 0.3f));
            engine.Effects.AnxietyOrigin = new Vector2(0.5f, 0.75f);
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        public override void Update()
        {
            base.Update();
            anxietyFade = ScalarMath.Approach(anxietyFade, anxietyFadeTarget, 2.5f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(.1f, engine))
            {
                anxietyJitter = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -.1f, .1f);
            }

            engine.Effects.Anxiety = anxietyFade *
                                     ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(0f,
                                         0f + anxietyJitter + anxietySine.Value * .3f);
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            anxietyFadeTarget = 1f;
            while (true)
            {
                player = level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (player != null)
                {
                    break;
                }

                yield return null;
            }

            while (!player.OnGround())
            {
                yield return null;
            }

            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return 1f;
            if (((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session).Mode ==
                (int)OriginalAreaMode.Normal)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusic("event:/music/lvl2/evil_madeline");
            }

            yield return TextboxState.Say("CH2_BADELINE_INTRO", engine, TurnAround, RevealBadeline, StartLaughing,
                StopLaughing);
            anxietyFadeTarget = 0f;
            yield return Level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        private IEnumerator TurnAround()
        {
            player.Data.Facing = -1;
            yield return 0.2f;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                OriginalCutsceneEntityState.CameraTo(engine, new Vector2(Level.Bounds.X, Level.Camera.Y), 0.5f)));
            yield return Level.ZoomTo(new Vector2(84f, 135f), 2f, 0.5f);
            yield return 0.2f;
        }

        private IEnumerator RevealBadeline()
        {
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/game/02_old_site/sequence_badeline_intro",
                badeline.Position);
            yield return 0.1f;
            Level.Displacement.AddBurst(badeline.Position + new Vector2(0f, -4f), 0.8f, 8f, 48f, 0.5f);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble((int)RumbleStrength.Light,
                (int)RumbleLength.Medium);
            yield return 0.1f;
            badeline.Hovering = true;
            badeline.Hair.Visible = true;
            badeline.Sprite.Play("fallSlow");
            Vector2 from = badeline.Position;
            Vector2 to = badelineEndPosition;
            for (float t = 0f; t < 1f; t += engine.DeltaTime)
            {
                badeline.Position =
                    from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(t);
                yield return null;
            }

            player.Data.Facing = (int)Math.Sign(badeline.X - player.X);
            yield return 1f;
        }

        private IEnumerator StartLaughing()
        {
            yield return 0.2f;
            badeline.Sprite.Play("laugh", restart: true);
            yield return null;
        }

        private IEnumerator StopLaughing()
        {
            badeline.Sprite.Play("fallSlow", restart: true);
            yield return null;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            ((IOriginalGameplayProcess)engine).AudioSession.SetMusic(null);
            engine.Effects.Anxiety = 0f;
            if (player != null)
            {
                player.Machine.Locked = false;
                player.Data.Facing = -1;
                player.Machine.State = 0;
                player.JustRespawned = true;
            }

            badeline.Position = badelineEndPosition;
            badeline.Visible = true;
            badeline.Hair.Visible = true;
            badeline.Sprite.Play("fallSlow");
            badeline.Hovering = false;
            badeline.OwnedComponents.Add(new SimulationCoroutine(engine, badeline.StartChasingRoutine(level)));
            level.Session.SetFlag("evil_maddy_intro");
        }
    }
}
