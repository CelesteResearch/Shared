using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Stories.Temple.Badeline
{
    public class CS05BadelineState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly RoomPlayerSession player;

        private readonly OriginalTempleBadelineState npc;

        private readonly BadelineDummyPresentation badeline;

        private readonly int index;

        private bool moved;

        public static string GetFlag(int index)
        {
            return "badeline_" + index;
        }

        public CS05BadelineState(RoomPlayerSession player, OriginalTempleBadelineState npc,
            BadelineDummyPresentation badeline, int index, ISourceEngineContext engine)
            : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.npc = npc;
            this.badeline = badeline;
            this.index = index;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return 0.25f;
            if (index == 3)
            {
                player.Dummy.AutoAnimate = false;
                player.Sprite.Play("tired");
                yield return 0.2f;
            }

            while (player.Scene != null && !player.OnGround()) yield return null;

            var screenSpaceFocusPoint =
                (badeline.Center + player.Center) * 0.5f - Level.Camera.Position + new Vector2(0f, -12f);
            yield return Level.ZoomTo(screenSpaceFocusPoint, 2f, 0.5f);
            yield return TextboxState.Say("ch5_shadow_maddy_" + index, engine, BadelineLeaves);
            if (!moved) npc.MoveToNode(index);

            yield return Level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            npc.SnapToNode(index);
            player.Machine.Locked = false;
            player.Machine.State = 0;
            level.Session.SetFlag(GetFlag(index));
        }

        private IEnumerator BadelineLeaves()
        {
            yield return 0.1f;
            moved = true;
            npc.MoveToNode(index);
            yield return 0.5f;
            player.Sprite.Play("tiredStill");
            yield return 0.5f;
            player.Sprite.Play("idle");
            yield return 0.6f;
        }
    }
}
