using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Theo
{
    public class CS05TheoMirrorState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public const string Flag = "theoInMirror";

        private readonly OriginalNpcState theo;

        private readonly RoomPlayerSession player;

        private readonly int playerFinalX;

        public CS05TheoMirrorState(ISourceEngineContext engine, OriginalNpcState theo, RoomPlayerSession player)
            : base(engine)
        {
            this.engine = engine;
            this.theo = theo;
            this.player = player;
            playerFinalX = (int)theo.Position.X + 24;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return player.DummyWalkTo(theo.X - 16f);
            yield return 0.5f;
            theo.Sprite.Scale.X = -1f;
            yield return 0.25f;
            yield return TextboxState.Say("ch5_theo_mirror", engine);
            OwnedComponents.Add(new SimulationCoroutine(engine, theo.MoveTo(theo.Position + new Vector2(64f, 0f))));
            yield return 0.4f;
            yield return player.DummyWalkToExact(playerFinalX);
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            player.X = playerFinalX;
            player.MoveV(200f);
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            ((ISourceScene)Scene).SourceScene.RemoveEntity(theo);
            level.Session.SetFlag("theoInMirror");
        }
    }
}
