using Celeste.Simulation;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes
{
    public class CS06BossMidState : OriginalCutsceneEntityState
    {
        public const string Flag = "boss_mid";
        private RoomPlayerSession player;
        private readonly ISourceEngineContext engine;

        public CS06BossMidState(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            while (player == null)
            {
                player = ((Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                yield return null;
            }

            player.Machine.State = 11;
            player.Machine.Locked = true;
            while (!player.OnGround()) yield return null;
            yield return player.DummyWalkToExact((int)player.X + 20);
            yield return level.ZoomTo(new Vector2(80f, 110f), 2f, .5f);
            yield return Celeste.Game.UI.Dialogue.Textboxes.TextboxState.Say("ch6_boss_middle", engine);
            yield return .1f;
            yield return level.ZoomBack(.4f);
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            if (WasSkipped && player != null)
                while (!player.OnGround() && player.Y < level.Bounds.Bottom)
                    player.Y++;
            if (player != null)
            {
                player.Machine.Locked = false;
                player.Machine.State = 0;
            }

            level.SourceScene.Entities.FindFirst<FinalBossState>()?.OnPlayer(null);
            level.Session.SetFlag(Flag);
        }
    }
}
