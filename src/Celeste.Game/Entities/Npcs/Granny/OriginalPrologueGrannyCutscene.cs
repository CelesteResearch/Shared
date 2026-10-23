using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public class OriginalPrologueGrannyCutscene : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext Engine;

        public const string Flag = "granny";

        private readonly OriginalPrologueGrannyState granny;

        private readonly RoomPlayerSession player;

        private readonly Vector2 endPlayerPosition;

        private SimulationCoroutine zoomCoroutine;

        public OriginalPrologueGrannyCutscene(ISourceEngineContext engine, OriginalPrologueGrannyState granny,
            RoomPlayerSession player) : base(engine)
        {
            Engine = engine;
            this.granny = granny;
            this.player = player;
            endPlayerPosition = granny.Position + new Vector2(48f, 0f);
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(Engine, Cutscene()));
        }

        private IEnumerator Cutscene()
        {
            player.Machine.State = 11;
            if (Math.Abs(player.X - granny.X) < 20f) yield return player.DummyWalkTo(granny.X - 48f);

            player.Data.Facing = 1;
            yield return 0.5f;
            yield return TextboxState.Say("CH0_GRANNY", Engine, Meet, RunAlong, LaughAndAirQuotes, Laugh, StopLaughing,
                OminousZoom, PanToMaddy);
            yield return Level.ZoomBack(0.5f);
            EndCutscene(Level);
        }

        private IEnumerator Meet()
        {
            yield return 0.25f;
            granny.Sprite.Scale.X = Math.Sign(player.X - granny.X);
            yield return player.DummyWalkTo(granny.X - 20f);
            player.Data.Facing = 1;
            yield return 0.8f;
        }

        private IEnumerator RunAlong()
        {
            yield return player.DummyWalkToExact((int)endPlayerPosition.X);
            yield return 0.8f;
            player.Data.Facing = -1;
            yield return 0.4f;
            granny.Sprite.Scale.X = 1f;
            yield return Level.ZoomTo(new(210f, 90f), 2f, 0.5f);
            yield return 0.2f;
        }

        private IEnumerator LaughAndAirQuotes()
        {
            yield return 0.6f;
            granny.LaughSfx.FirstPlay = true;
            granny.Sprite.Play("laugh");
            yield return 2f;
            granny.Sprite.Play("airQuotes");
        }

        private IEnumerator Laugh()
        {
            granny.LaughSfx.FirstPlay = false;
            yield return null;
            granny.Sprite.Play("laugh");
        }

        private IEnumerator StopLaughing()
        {
            granny.Sprite.Play("idle");
            yield break;
        }

        private IEnumerator OminousZoom()
        {
            var screenSpaceFocusPoint = new Vector2(210f, 100f);
            zoomCoroutine = new(Engine, Level.ZoomAcross(screenSpaceFocusPoint, 4f, 3f));
            OwnedComponents.Add(zoomCoroutine);
            granny.Sprite.Play("idle");
            yield return 0.2f;
        }

        private IEnumerator PanToMaddy()
        {
            while (zoomCoroutine != null && zoomCoroutine.Active) yield return null;

            yield return 0.2f;
            yield return Level.ZoomAcross(new(210f, 90f), 2f, 0.5f);
            yield return 0.2f;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            granny.Hahaha.Enabled = true;
            granny.Sprite.Play("laugh");
            granny.Sprite.Scale.X = 1f;
            player.X = endPlayerPosition.X;
            player.Data.Facing = -1;
            player.Machine.State = 0;
            level.Session.SetFlag("granny");
            level.ResetZoom();
        }
    }
}
