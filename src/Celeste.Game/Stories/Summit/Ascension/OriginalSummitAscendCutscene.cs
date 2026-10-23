using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Game.Presentation.Hud.Height;

namespace Celeste.Game.Stories.Summit.Ascension
{
    public class OriginalSummitAscendCutscene : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private int index;

        private string cutscene;

        private BadelineDummyPresentation badeline;

        private RoomPlayerSession player;

        private Vector2 origin;

        private bool spinning;

        private bool dark;

        public OriginalSummitAscendCutscene(ISourceEngineContext engine, int index, string cutscene, bool dark) :
            base(engine)
        {
            this.engine = engine;
            this.index = index;
            this.cutscene = cutscene;
            this.dark = dark;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene()));
        }

        private IEnumerator Cutscene()
        {
            while ((player =
                       ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                           typeof(global::Celeste.Simulation.RoomPlayerSession).FullName)) == null)
            {
                yield return null;
            }

            origin = player.Position;
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/badeline/maddy_split");
            player.CreateSplitParticles();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 2);
            Level.Displacement.AddBurst(player.Position, 0.4f, 8f, 32f, 0.5f);
            player.Data.Dashes = 1;
            player.Data.Facing = 1;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(badeline =
                BadelineDummyPresentation.Create((OriginalLevelSceneRoot)Scene, player.Position));
            badeline.AutoAnimator.Enabled = false;
            spinning = true;
            OwnedComponents.Add(new SimulationCoroutine(engine, SpinCharacters()));
            yield return TextboxState.Say(cutscene, engine);
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/badeline/maddy_join");
            spinning = false;
            yield return 0.25f;
            badeline.RemoveSelf();
            player.Data.Dashes = 2;
            player.CreateSplitParticles();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 2);
            Level.Displacement.AddBurst(player.Position, 0.4f, 8f, 32f, 0.5f);
            EndCutscene(Level);
        }

        private IEnumerator SpinCharacters()
        {
            float dist = 0f;
            Vector2 center = player.Position;
            float timer = (float)Math.PI / 2f;
            player.Sprite.Play("spin");
            badeline.Sprite.Play("spin");
            badeline.Sprite.Scale.X = 1f;
            while (spinning || dist > 0f)
            {
                dist = ScalarMath.Approach(dist, spinning ? 1f : 0f, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                int num = (int)(timer / ((float)Math.PI * 2f) * 14f + 10f);
                float num2 = (float)Math.Sin(timer);
                float num3 = (float)Math.Cos(timer);
                float num4 = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(dist) * 32f;
                player.Sprite.SetAnimationFrame(num);
                badeline.Sprite.SetAnimationFrame(num + 7);
                player.Position = center - new Vector2(num2 * num4, num3 * dist * 8f);
                badeline.Position = center + new Vector2(num2 * num4, num3 * dist * 8f);
                timer -= engine.DeltaTime * 2f;
                if (timer <= 0f)
                {
                    timer += (float)Math.PI * 2f;
                }

                yield return null;
            }
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (badeline != null)
            {
                badeline.RemoveSelf();
            }

            if (player != null)
            {
                player.Data.Dashes = 2;
                player.Position = origin;
            }

            if (!dark)
            {
                level.SourceScene.QueueSourceEntity(new OriginalHeightDisplayState(engine, index));
            }
        }
    }
}
