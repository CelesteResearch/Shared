using System;
using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Theo
{
    public class CS05TheoPhoneState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly RoomPlayerSession player;

        private readonly float targetX;

        public CS05TheoPhoneState(ISourceEngineContext engine, RoomPlayerSession player, float targetX)
            : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.targetX = targetX;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
        }

        private IEnumerator Routine()
        {
            player.Machine.State = 11;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (player.X != targetX) player.Data.Facing = Math.Sign(targetX - player.X);

            yield return 0.5f;
            yield return Level.ZoomTo(new(80f, 60f), 2f, 0.5f);
            yield return TextboxState.Say("CH5_PHONE", engine, WalkToPhone, StandBackUp);
            yield return Level.ZoomBack(0.5f);
            EndCutscene(Level);
        }

        private IEnumerator WalkToPhone()
        {
            yield return 0.25f;
            yield return player.DummyWalkToExact((int)targetX);
            player.Data.Facing = -1;
            yield return 0.5f;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("duck");
            yield return 0.5f;
        }

        private IEnumerator StandBackUp()
        {
            RemovePhone();
            yield return 0.6f;
            player.Sprite.Play("idle");
            yield return 0.2f;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            RemovePhone();
            player.Machine.State = 0;
        }

        private void RemovePhone()
        {
            ((ISourceScene)Scene).SourceScene.Entities.FindFirst<OriginalTheoPhoneState>()?.RemoveSelf();
        }
    }
}
