using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Audio;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes
{
    public class CS06BossIntroState : OriginalCutsceneEntityState
    {
        public const string Flag = "boss_intro";
        private RoomPlayerSession player;
        private FinalBossState boss;
        private Vector2 bossEndPosition;
        private BadelineAutoAnimatorPresentation animator;
        private float playerTargetX;
        private readonly ISourceEngineContext engine;

        public CS06BossIntroState(float playerTargetX, RoomPlayerSession player, FinalBossState boss,
            ISourceEngineContext engine)
            : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.boss = boss;
            this.playerTargetX = playerTargetX;
            bossEndPosition = boss.Position + new Vector2(0f, -16f);
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
            => OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            while (!player.Dead && !player.OnGround()) yield return null;
            while (player.Dead) yield return null;
            player.Data.Facing = 1;
            OwnedComponents.Add(new SimulationCoroutine(engine, CameraTo(engine,
                new Vector2((player.X + boss.X) / 2f - 160f, level.Bounds.Bottom - 180), 1f)));
            yield return .5f;
            if (!player.Dead) yield return player.DummyWalkToExact((int)(playerTargetX - 8f));
            player.Data.Facing = 1;
            yield return TextboxState.Say("ch6_boss_start", engine, BadelineFloat, PlayerStepForward);
            yield return level.ZoomBack(.5f);
            EndCutscene(level);
        }

        private IEnumerator BadelineFloat()
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Level.ZoomTo(new Vector2(170f, 110f), 2f, 1f)));
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/badeline/boss_prefight_getup",
                boss.Position);
            boss.Sitting = false;
            boss.NormalSprite.Play("fallSlow");
            boss.NormalSprite.Scale.X = -1f;
            animator = new BadelineAutoAnimatorPresentation(engine);
            boss.OwnedComponents.Add(animator);
            float fromY = boss.Y;
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                boss.Y = ScalarMath.Lerp(fromY, bossEndPosition.Y,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }
        }

        private IEnumerator PlayerStepForward()
        {
            yield return player.DummyWalkToExact((int)player.X + 8);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (WasSkipped && player != null)
            {
                player.X = playerTargetX;
                while (!player.OnGround() && player.Y < level.Bounds.Bottom) player.Y++;
            }

            player.Machine.Locked = false;
            player.Machine.State = 0;
            boss.Position = bossEndPosition;
            if (boss.NormalSprite != null)
            {
                boss.NormalSprite.Scale.X = -1f;
                boss.NormalSprite.Play("laugh");
            }

            boss.Sitting = false;
            if (animator != null) boss.OwnedComponents.Remove(animator);
            level.Session.SetFlag(Flag);
        }
    }
}
