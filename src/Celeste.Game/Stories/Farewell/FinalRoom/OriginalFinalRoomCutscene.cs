using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Audio;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.UI.Dialogue.Textboxes;
using Player = Celeste.Simulation.RoomPlayerSession;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;
using BadelineDummy = Celeste.Game.Entities.BadelineDummy.BadelineDummyPresentation;

namespace Celeste.Game.Stories.Farewell.FinalRoom
{
    public class OriginalFinalRoomCutscene : OriginalCutsceneEntityState
    {
        private Player player;

        private BadelineDummy badeline;

        private bool first;

        private readonly ISourceEngineContext engine;

        public OriginalFinalRoomCutscene(ISourceEngineContext engine, Player player, bool first) : base(engine)
        {
            base.Depth = -8500;
            this.engine = engine;
            this.player = player;
            this.first = first;
        }

        public override void OnBegin(Level level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(Level level)
        {
            player.Machine.State = 11;
            if (first)
            {
                yield return player.DummyWalkToExact((int)(player.X + 16f));
                yield return 0.5f;
            }
            else
            {
                player.Dummy.AutoAnimate = false;
                player.Sprite.Play("sitDown");
                player.Sprite.SetAnimationFrame(player.Sprite.CurrentAnimationTotalFrames - 1);
                yield return 1.25f;
            }

            yield return BadelineAppears();
            if (first)
            {
                yield return TextboxState.Say("CH9_LAST_ROOM", engine);
            }
            else
            {
                yield return TextboxState.Say("CH9_LAST_ROOM_ALT", engine);
            }

            yield return BadelineVanishes();
            EndCutscene(level);
        }

        private IEnumerator BadelineAppears()
        {
            Level.AddEntity(badeline = new BadelineDummy(engine, player.Position + new Vector2(18f, -8f)));
            Level.Displacement.AddBurst(badeline.Center, 0.5f, 8f, 32f, 0.5f);
            ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/badeline/maddy_split", badeline.Position,
                ((IOriginalGameplayProcess)engine).SaveContext);
            badeline.Sprite.Scale.X = -1f;
            yield return null;
        }

        private IEnumerator BadelineVanishes()
        {
            yield return 0.2f;
            badeline.Vanish();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
            badeline = null;
            yield return 0.5f;
            player.Data.Facing = 1;
        }

        public override void OnEnd(Level level)
        {
            Level.Session.Inventory.Dashes = 1;
            player.Machine.State = 0;
            if (!first && !WasSkipped)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/char/madeline/stand", player.Position,
                    ((IOriginalGameplayProcess)engine).SaveContext);
            }

            if (badeline != null)
            {
                badeline.RemoveSelf();
            }
        }
    }
}
