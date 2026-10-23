using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public class OriginalReflectionGrannyCutscene : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext Engine;

        public const string FlagPrefix = "granny_";

        private readonly OriginalReflectionGrannyState granny;

        private readonly RoomPlayerSession player;

        private float startX;

        private readonly int index;

        private bool firstLaugh;

        public OriginalReflectionGrannyCutscene(ISourceEngineContext engine, OriginalReflectionGrannyState granny,
            RoomPlayerSession player, int index) : base(engine)
        {
            Engine = engine;
            this.granny = granny;
            this.player = player;
            this.index = index;
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
            if (index == 0)
            {
                yield return player.DummyWalkTo(granny.X - 40f);
                startX = player.X;
                player.Data.Facing = 1;
                firstLaugh = true;
                yield return TextboxState.Say("ch6_oldlady", Engine, ZoomIn, Laughs, StopLaughing, MaddyWalksRight,
                    MaddyWalksLeft, WaitABit, MaddyTurnsRight);
            }
            else if (index == 1)
            {
                yield return ZoomIn();
                yield return player.DummyWalkTo(granny.X - 20f);
                player.Data.Facing = 1;
                yield return TextboxState.Say("ch6_oldlady_b", Engine);
            }
            else if (index == 2)
            {
                yield return ZoomIn();
                yield return player.DummyWalkTo(granny.X - 20f);
                player.Data.Facing = 1;
                yield return TextboxState.Say("ch6_oldlady_c", Engine);
            }

            yield return Level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        private IEnumerator ZoomIn()
        {
            var screenSpaceFocusPoint =
                Vector2Interpolation.Lerp(granny.Position, player.Position, 0.5f,
                    ((ISourceScalarEnvironment)Engine).ScalarArithmetic) - Level.Camera.Position +
                new Vector2(0f, -20f);
            yield return Level.ZoomTo(screenSpaceFocusPoint, 2f, 0.5f);
        }

        private IEnumerator Laughs()
        {
            if (firstLaugh)
            {
                firstLaugh = false;
                yield return 0.5f;
            }

            granny.Sprite.Play("laugh");
            yield return 1f;
        }

        private IEnumerator StopLaughing()
        {
            granny.Sprite.Play("idle");
            yield return 0.25f;
        }

        private IEnumerator MaddyWalksLeft()
        {
            yield return 0.1f;
            player.Data.Facing = -1;
            yield return player.DummyWalkToExact((int)player.X - 8);
            yield return 0.1f;
        }

        private IEnumerator MaddyWalksRight()
        {
            yield return 0.1f;
            player.Data.Facing = 1;
            yield return player.DummyWalkToExact((int)player.X + 8);
            yield return 0.1f;
        }

        private IEnumerator WaitABit()
        {
            yield return 0.8f;
        }

        private IEnumerator MaddyTurnsRight()
        {
            yield return 0.1f;
            player.Data.Facing = 1;
            yield return 0.1f;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            player.ForceCameraUpdate = false;
            granny.Sprite.Play("idle");
            level.Session.SetFlag("granny_" + index);
        }
    }
}
