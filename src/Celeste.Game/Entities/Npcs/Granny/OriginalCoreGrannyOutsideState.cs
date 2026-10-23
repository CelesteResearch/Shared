using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Hahaha;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Game.Stories.Farewell.Effects;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public class OriginalCoreGrannyOutsideState : OriginalNpcState
    {
        public const string Flag = "granny_outside";

        public OriginalHahahaState Hahaha;

        public OriginalGrannyLaughSfxState LaughSfx;

        private bool talking;

        private RoomPlayerSession player;

        private bool leaving;

        public OriginalCoreGrannyOutsideState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(engine, data.Position + offset)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("granny"));
            Sprite.Play("idle");
            OwnedComponents.Add(LaughSfx = new OriginalGrannyLaughSfxState(Engine, Sprite));
            MoveAnim = "walk";
            IdleAnim = "idle";
            Maxspeed = 40f;
            SetupGrannySpriteSounds();
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if ((scene as OriginalLevelSceneRoot).Session.GetFlag("granny_outside"))
            {
                RemoveSelf();
            }

            ((ISourceScene)scene).SourceScene.QueueSourceEntity(Hahaha =
                new OriginalHahahaState(Engine, Position + new Vector2(8f, -4f)));
            Hahaha.Enabled = false;
        }

        public override void Update()
        {
            if (!talking)
            {
                player = Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                if (player != null && player.X > base.X - 48f)
                {
                    (base.Scene as OriginalLevelSceneRoot).StartCutscene(EndTalking);
                    OwnedComponents.Add(new SimulationCoroutine(Engine, TalkRoutine(player)));
                    talking = true;
                }
            }

            Hahaha.Enabled = Sprite.CurrentAnimationID == "laugh";
            base.Update();
        }

        private IEnumerator TalkRoutine(RoomPlayerSession player)
        {
            player.Machine.State = 11;
            while (!player.OnGround())
            {
                yield return null;
            }

            Sprite.Scale.X = -1f;
            yield return player.DummyWalkToExact((int)base.X - 16);
            yield return 0.5f;
            yield return Level.ZoomTo(new Vector2(200f, 110f), 2f, 0.5f);
            yield return TextboxState.Say("APP_OLDLADY_A", Engine, MoveRight, ExitRight);
            yield return Level.ZoomBack(0.5f);
            Sprite.Scale.X = 1f;
            if (!leaving)
            {
                yield return ExitRight();
            }

            while (base.X < (float)(Level.Bounds.Right + 8))
            {
                yield return null;
            }

            Level.EndCutscene();
            EndTalking(Level);
        }

        private IEnumerator MoveRight()
        {
            yield return MoveTo(new Vector2(base.X + 8f, base.Y));
        }

        private IEnumerator ExitRight()
        {
            leaving = true;
            OwnedComponents.Add(new SimulationCoroutine(Engine, MoveTo(new Vector2(Level.Bounds.Right + 16, base.Y))));
            yield return null;
        }

        private void EndTalking(OriginalLevelSceneRoot level)
        {
            if (player != null)
            {
                player.Machine.State = 0;
            }

            Level.Session.SetFlag("granny_outside");
            RemoveSelf();
        }
    }
}
