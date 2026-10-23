using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public class OriginalCliffsideGrannyCutscene : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext Engine;

        public const string Flag = "granny_1";

        private readonly OriginalCliffsideGrannyState granny;

        private readonly RoomPlayerSession player;

        public OriginalCliffsideGrannyCutscene(ISourceEngineContext engine, OriginalCliffsideGrannyState granny,
            RoomPlayerSession player) : base(engine)
        {
            Engine = engine;
            this.granny = granny;
            this.player = player;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(Engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            player.ForceCameraUpdate = true;
            yield return player.DummyWalkTo(granny.X - 30f);
            player.Data.Facing = 1;
            yield return TextboxState.Say("CH4_GRANNY_1", Engine, Laughs, StopLaughing, WaitABeat, ZoomIn,
                MaddyTurnsAround,
                MaddyApproaches, MaddyWalksPastGranny);
            yield return Level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        private IEnumerator Laughs()
        {
            granny.Sprite.Play("laugh");
            yield return 1f;
        }

        private IEnumerator StopLaughing()
        {
            granny.Sprite.Play("idle");
            yield return 0.25f;
        }

        private IEnumerator WaitABeat()
        {
            yield return 1.2f;
        }

        private IEnumerator ZoomIn()
        {
            yield return Level.ZoomTo(new(123f, 116f), 2f, 0.5f);
        }

        private IEnumerator MaddyTurnsAround()
        {
            yield return 0.2f;
            player.Data.Facing = -1;
            yield return 0.1f;
        }

        private IEnumerator MaddyApproaches()
        {
            yield return player.DummyWalkTo(granny.X - 20f);
        }

        private IEnumerator MaddyWalksPastGranny()
        {
            yield return player.DummyWalkToExact((int)granny.X + 30);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.X = granny.X + 30f;
            player.Machine.Locked = false;
            player.Machine.State = 0;
            player.ForceCameraUpdate = false;
            if (WasSkipped) level.Camera.Position = player.CameraTarget;

            granny.Sprite.Play("laugh");
            level.Session.SetFlag("granny_1");
        }
    }
}
