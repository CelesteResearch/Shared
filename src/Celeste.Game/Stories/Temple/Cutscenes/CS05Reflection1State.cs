using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Gameplay.Environment.Mirrors;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Stories.Temple.Cutscenes
{
    public class CS05Reflection1State : OriginalCutsceneEntityState
    {
        public const string Flag = "reflection";

        private readonly RoomPlayerSession player;

        private readonly ISourceEngineContext engine;

        public CS05Reflection1State(ISourceEngineContext engine, RoomPlayerSession player) : base(engine)
        {
            this.engine = engine;
            this.player = player;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            player.ForceCameraUpdate = true;
            var templeMirror =
                ((ISourceScene)Scene).SourceScene.Entities.FindFirst<OriginalTempleMirrorState>();
            yield return player.DummyWalkTo(templeMirror.Center.X + 8f);
            yield return 0.2f;
            player.Data.Facing = -1;
            yield return 0.3f;
            if (!player.Dead)
                yield return TextboxState.Say("ch5_reflection", engine, MadelineFallsToKnees, MadelineStopsPanicking,
                    MadelineGetsUp);
            else
                yield return 100f;

            yield return Level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        private IEnumerator MadelineFallsToKnees()
        {
            yield return 0.2f;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("tired");
            yield return 0.2f;
            yield return Level.ZoomTo(new(90f, 116f), 2f, 0.5f);
            yield return 0.2f;
        }

        private IEnumerator MadelineStopsPanicking()
        {
            yield return 0.8f;
            player.Sprite.Play("tiredStill");
            yield return 0.4f;
        }

        private IEnumerator MadelineGetsUp()
        {
            player.Dummy.AutoAnimate = true;
            player.Sprite.Play("idle");
            yield break;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            player.ForceCameraUpdate = false;
            player.FlipInReflection = false;
            level.Session.SetFlag("reflection");
        }
    }
}
