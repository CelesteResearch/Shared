using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Scene.Tracking;
using Celeste.Scene.Following;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Game.Audio;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Controls.Source;

namespace Celeste.Game.Stories.Temple.Cutscenes
{
    public class CS05SeeTheoState : OriginalCutsceneEntityState
    {
        private const float NewDarknessAlpha = 0.3f;

        public const string Flag = "seeTheoInCrystal";

        private int index;

        private RoomPlayerSession player;

        private readonly ISourceEngineContext engine;

        private TheoCrystalState theo;

        public CS05SeeTheoState(ISourceEngineContext engine, RoomPlayerSession player, int index) : base(engine)
        {
            this.engine = engine;
            this.player = player;
            this.index = index;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            while (player.Scene == null || !player.OnGround())
            {
                yield return null;
            }

            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return 0.25f;
            theo = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            if (theo != null && Math.Sign(player.X - theo.X) != 0)
            {
                player.Data.Facing = Math.Sign(theo.X - player.X);
            }

            yield return 0.25f;
            if (index == 0)
            {
                yield return TextboxState.Say("ch5_see_theo", engine, ZoomIn, MadelineTurnsAround, WaitABit,
                    MadelineTurnsBackAndBrighten);
            }
            else if (index == 1)
            {
                yield return TextboxState.Say("ch5_see_theo_b", engine);
            }

            yield return Level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        private IEnumerator ZoomIn()
        {
            yield return Level.ZoomTo(
                Vector2Interpolation.Lerp(player.Position, theo.Position, 0.5f,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic) - Level.Camera.Position +
                new Vector2(0f, -20f),
                2f, 0.5f);
        }

        private IEnumerator MadelineTurnsAround()
        {
            yield return 0.3f;
            player.Data.Facing = -1;
            yield return 0.1f;
        }

        private IEnumerator WaitABit()
        {
            yield return 1f;
        }

        private IEnumerator MadelineTurnsBackAndBrighten()
        {
            yield return 0.1f;
            SimulationCoroutine coroutine = new SimulationCoroutine(engine, Brighten());
            Add(coroutine);
            yield return 0.2f;
            player.Data.Facing = 1;
            yield return 0.1f;
            while (coroutine.Active)
            {
                yield return null;
            }
        }

        private IEnumerator Brighten()
        {
            yield return Level.ZoomBack(0.5f);
            yield return 0.3f;
            Level.Session.DarkRoomAlpha = 0.3f;
            float darkness = Level.Session.DarkRoomAlpha;
            while (Level.Lighting.Alpha != darkness)
            {
                Level.Lighting.Alpha = ScalarMath.Approach(Level.Lighting.Alpha, darkness,
                    engine.Frame.DeltaTime * 0.5f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            player.ForceCameraUpdate = false;
            player.Dummy.AutoAnimate = true;
            level.Session.DarkRoomAlpha = 0.3f;
            level.Lighting.Alpha = level.Session.DarkRoomAlpha;
            level.Session.SetFlag("seeTheoInCrystal");
        }
    }
}
