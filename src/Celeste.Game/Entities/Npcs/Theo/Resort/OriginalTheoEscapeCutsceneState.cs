using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Audio;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Game.Components.Talking;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;

namespace Celeste.Game.Entities.Npcs.Theo.Resort
{
    public class OriginalTheoEscapeCutsceneState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public const string Flag = "resort_theo";

        private OriginalTheoEscapingState theo;

        private RoomPlayerSession player;

        private Vector2 theoStart;

        public OriginalTheoEscapeCutsceneState(ISourceEngineContext engine, OriginalTheoEscapingState theo,
            RoomPlayerSession player)
            : base(engine)
        {
            this.engine = engine;
            this.theo = theo;
            theoStart = theo.Position;
            this.player = player;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return player.DummyWalkTo(theo.X - 64f);
            player.Data.Facing = 1;
            yield return Level.ZoomTo(new Vector2(240f, 135f), 2f, 0.5f);
            Func<IEnumerator>[] events = new Func<IEnumerator>[4]
                { StopRemovingVent, StartRemoveVent, RemoveVent, GivePhone };
            string dialog = "CH3_THEO_INTRO";
            if (!((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Flags.Contains("MetTheo"))
            {
                dialog = "CH3_THEO_NEVER_MET";
            }
            else if (!((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Flags.Contains("TheoKnowsName"))
            {
                dialog = "CH3_THEO_NEVER_INTRODUCED";
            }

            yield return TextboxState.Say(dialog, engine, events);
            theo.Sprite.Scale.X = 1f;
            yield return 0.2f;
            theo.Sprite.Play("walk");
            while (!theo.CollideCheck("Celeste.Solid", theo.Position + new Vector2(2f, 0f)))
            {
                yield return null;
                theo.X += 48f * engine.DeltaTime;
            }

            theo.Sprite.Play("idle");
            yield return 0.2f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/theo/resort_standtocrawl",
                theo.Position);
            theo.Sprite.Play("duck");
            yield return 0.5f;
            if (theo.Talker != null)
            {
                theo.Talker.Active = false;
            }

            level.Session.SetFlag("resort_theo");
            player.Machine.Locked = false;
            player.Machine.State = 0;
            theo.CrawlUntilOut();
            yield return level.ZoomBack(0.5f);
            EndCutscene(level);
        }

        private IEnumerator StartRemoveVent()
        {
            theo.Sprite.Scale.X = 1f;
            yield return 0.1f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/theo/resort_vent_grab",
                theo.Position);
            theo.Sprite.Play("goToVent");
            yield return 0.25f;
        }

        private IEnumerator StopRemovingVent()
        {
            theo.Sprite.Play("idle");
            yield return 0.1f;
            theo.Sprite.Scale.X = -1f;
        }

        private IEnumerator RemoveVent()
        {
            yield return 0.8f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/theo/resort_vent_rip",
                theo.Position);
            theo.Sprite.Play("fallVent");
            yield return 0.8f;
            theo.grate.Fall();
            yield return 0.8f;
            theo.Sprite.Scale.X = -1f;
            yield return 0.25f;
        }

        private IEnumerator GivePhone()
        {
            RoomPlayerSession player =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (player != null)
            {
                theo.Sprite.Play("walk");
                theo.Sprite.Scale.X = -1f;
                while (theo.X > player.X + 24f)
                {
                    theo.X -= 48f * engine.DeltaTime;
                    yield return null;
                }
            }

            theo.Sprite.Play("idle");
            yield return 1f;
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            level.Session.SetFlag("resort_theo");
            var metTheoSave = ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave;
            if (!metTheoSave.Flags.Contains("MetTheo")) metTheoSave.Flags.Add("MetTheo");
            var nameSave = ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave;
            if (!nameSave.Flags.Contains("TheoKnowsName")) nameSave.Flags.Add("TheoKnowsName");
            if (theo != null && WasSkipped)
            {
                theo.Position = theoStart;
                theo.CrawlUntilOut();
                if (theo.grate != null)
                {
                    theo.grate.RemoveSelf();
                }
            }
        }
    }
}
