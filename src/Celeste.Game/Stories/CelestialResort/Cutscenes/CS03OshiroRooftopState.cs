using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Stories.CelestialResort.Cutscenes
{
    public class CS03OshiroRooftopState : OriginalCutsceneEntityState
    {
        public const string Flag = "oshiro_resort_roof";

        private const float playerEndPosition = 170f;

        private RoomPlayerSession player;

        private readonly OriginalNpcState oshiro;

        private BadelineDummyPresentation evil;

        private Vector2 bossSpawnPosition;

        private float anxiety;

        private float anxietyFlicker;

        private readonly Sprite bossSprite;

        private float bossSpriteOffset;

        private bool oshiroRumble;

        private readonly ISourceEngineContext engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceScalarArithmetic Scalar => ((ISourceScalarEnvironment)engine).ScalarArithmetic;
        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public CS03OshiroRooftopState(ISourceEngineContext engine, OriginalNpcState oshiro)
            : this(engine, oshiro,
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("oshiro_boss"))
        {
        }

        private CS03OshiroRooftopState(ISourceEngineContext engine, OriginalNpcState oshiro, Sprite sourceBossSprite) :
            base(engine)
        {
            this.engine = engine;
            this.oshiro = oshiro;
            bossSprite = sourceBossSprite;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            bossSpawnPosition = new(oshiro.X, level.Bounds.Bottom - 40);
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            while (player == null)
            {
                player = Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
                if (player != null) break;

                yield return null;
            }

            player.Machine.State = 11;
            player.Machine.Locked = true;
            while (!player.OnGround() || player.Data.Motion.Normal.Speed.Y < 0f) yield return null;

            yield return 0.6f;
            evil = BadelineDummyPresentation.Create(Level, new(oshiro.X - 40f, level.Bounds.Bottom - 60));
            evil.Sprite.Scale.X = 1f;
            evil.Appear(level);
            level.Scheduler.QueueSourceEntity(evil);
            yield return 0.1f;
            player.Data.Facing = -1;
            yield return TextboxState.Say("CH3_OSHIRO_START_CHASE", engine, MaddyWalkAway, MaddyTurnAround, EnterOshiro,
                OshiroGetsAngry);
            yield return OshiroTransform();
            OwnedComponents.Add(new SimulationCoroutine(engine, AnxietyAndCameraOut()));
            yield return level.ZoomBack(0.5f);
            yield return 0.25f;
            EndCutscene(level);
        }

        private IEnumerator MaddyWalkAway()
        {
            var level = Level;
            OwnedComponents.Add(new SimulationCoroutine(engine, player.DummyWalkTo(level.Bounds.Left + 170f)));
            yield return 0.2f;
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/03_resort/suite_bad_moveroof",
                evil.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            OwnedComponents.Add(new SimulationCoroutine(engine, evil.FloatTo(evil.Position + new Vector2(80f, 30f))));
            yield return null;
        }

        private IEnumerator MaddyTurnAround()
        {
            yield return 0.25f;
            player.Data.Facing = -1;
            yield return 0.1f;
            var level = Level;
            yield return level.ZoomTo(new(150f, bossSpawnPosition.Y - level.Bounds.Y - 8f), 2f, 0.5f);
        }

        private IEnumerator EnterOshiro()
        {
            yield return 0.3f;
            bossSpriteOffset = (bossSprite.Justify.Value.Y - oshiro.Sprite.Justify.Value.Y) * bossSprite.Height;
            oshiro.Visible = true;
            oshiro.Sprite.Scale.X = 1f;
            OwnedComponents.Add(new SimulationCoroutine(engine,
                oshiro.MoveTo(bossSpawnPosition - new Vector2(0f, bossSpriteOffset))));
            oshiro.OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                .Play("event:/char/oshiro/move_07_roof00_enter"));
            var from = Level.ZoomFocusPoint.X;
            for (var p = 0f; p < 1f; p += engine.DeltaTime / 0.7f)
            {
                Level.ZoomFocusPoint.X = from + (126f - from) * Ease.CubeInOut(p);
                yield return null;
            }

            yield return 0.3f;
            player.Data.Facing = -1;
            yield return 0.1f;
            evil.Sprite.Scale.X = -1f;
        }

        private IEnumerator OshiroGetsAngry()
        {
            yield return 0.1f;
            evil.Vanish();
            Rumble(1, 1);
            evil = null;
            yield return 0.8f;
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/oshiro/boss_transform_begin",
                oshiro.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            oshiro.OwnedComponents.Remove(oshiro.Sprite);
            oshiro.Sprite = bossSprite;
            oshiro.Sprite.Play("transformStart");
            oshiro.Y += bossSpriteOffset;
            oshiro.OwnedComponents.Add(oshiro.Sprite);
            oshiro.Depth = -12500;
            oshiroRumble = true;
            yield return 1f;
        }

        private IEnumerator OshiroTransform()
        {
            yield return 0.2f;
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/oshiro/boss_transform_burst",
                oshiro.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            oshiro.Sprite.Play("transformFinish");
            Rumble(2, 2);
            Level.Shake(0.5f);
            SetChaseMusic();
            while (anxiety < 0.5f)
            {
                anxiety = ScalarMath.Approach(anxiety, 0.5f, engine.DeltaTime * 0.5f, Extrema);
                yield return null;
            }

            yield return 0.25f;
        }

        private IEnumerator AnxietyAndCameraOut()
        {
            var level = Level;
            var from = level.Camera.Position;
            var to = player.CameraTarget;
            for (var t = 0f; t < 1f; t += engine.DeltaTime * 2f)
            {
                anxiety = ScalarMath.Approach(anxiety, 0f, engine.DeltaTime * 4f, Extrema);
                level.Camera.Position = from + (to - from) * Ease.CubeInOut(t);
                yield return null;
            }
        }

        private void SetChaseMusic()
        {
            var obj = Level;
            obj.Session.Audio.Music.Event = "event:/music/lvl3/oshiro_chase";
            ApplyAudio(obj);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            engine.Effects.Anxiety = anxiety = anxietyFlicker = 0f;
            if (evil != null) evil.RemoveSelf();

            player = Level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(RoomPlayerSession).FullName);
            if (player != null)
            {
                player.Machine.Locked = false;
                player.Machine.State = 0;
                player.X = level.Bounds.Left + 170f;
                player.Data.Motion.Normal.Speed.Y = 0f;
                while (player.Body.CollideSolidAt(player.Position)) player.Y--;

                level.Camera.Position = player.CameraTarget;
            }

            if (WasSkipped) SetChaseMusic();

            oshiro.RemoveSelf();
            Level.Scheduler.QueueSourceEntity(
                ((IOriginalAngryOshiroConstructorEnvironment)
                    engine).AngryOshiroConstructors.Create(bossSpawnPosition, true,
                    (IOriginalAngryOshiroProcess)engine));
            level.Session.RespawnPoint = new Vector2(level.Bounds.Left + 170f, level.Bounds.Top + 160);
            level.Session.SetFlag("oshiro_resort_roof");
        }

        public override void Update()
        {
            engine.Effects.Anxiety = anxiety + anxiety * anxietyFlicker;
            if (Level.OnInterval(0.05f))
                anxietyFlicker = -0.2f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.4f);

            base.Update();
            if (oshiroRumble) Rumble(0, 0);
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
