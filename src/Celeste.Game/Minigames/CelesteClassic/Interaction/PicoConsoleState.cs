using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Minigames.CelesteClassic.Emulation;
using Celeste.Game.Minigames.CelesteClassic.Unlock;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Minigames.CelesteClassic.Interaction
{
    public class PicoConsoleState : SceneEntityState
    {
        private readonly SpriteImage sprite;
        private OriginalTalkComponent talk;
        private bool talking;
        private SoundSourceComponentState sfx;
        private readonly ISourceEngineContext engine;

        public PicoConsoleState(ISourceEngineContext engine, Vector2 position)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            Depth = 1000;
            AddTag(((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value);
            AddTag(((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value);
            Add(sprite =
                new(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/pico8Console"]));
            sprite.JustifyOrigin(.5f, 1f);
            Add(talk = new((IOriginalTalkProcess)engine,
                new(-12, -8, 24, 8), new(0f, -24f), OnInteract));
        }

        public override void Update()
        {
            base.Update();
            if (sfx == null)
            {
                var player = ((ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(RoomPlayerSession).FullName);
                if (player != null && player.Position.Y < Position.Y + 16f)
                {
                    sfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
                    sfx.Play("event:/env/local/03_resort/pico8_machine");
                    Add(sfx);
                }
            }
        }

        private void OnInteract(RoomPlayerSession player)
        {
            if (!talking)
            {
                (Scene as OriginalLevelSceneRoot).PauseLock = true;
                talking = true;
                Add(new SimulationCoroutine(engine, InteractRoutine(player)));
            }
        }

        private IEnumerator InteractRoutine(RoomPlayerSession player)
        {
            player.Machine.State = 11;
            yield return player.DummyWalkToExact((int)Position.X - 6);
            player.Data.Facing = 1;
            var wasUnlocked = ((ISettingsContext)engine).Settings.Pico8OnMainMenu;
            ((ISettingsContext)engine).Settings.Pico8OnMainMenu = true;
            if (!wasUnlocked)
            {
                ((IOriginalUserIOEnvironment)engine).UserIO.SaveHandler(false, true);
                while (((IOriginalUserIOEnvironment)engine).UserIO.Saving) yield return null;
            }
            else
            {
                yield return .5f;
            }

            var done = false;
            ((ISourceScreenWipeEnvironment)engine).ProcessWipe.SpotlightFocusPoint = player.Position -
                (Scene as OriginalLevelSceneRoot).Camera.Position + new Vector2(0f, -8f);
            new SpotlightWipePresentation((OriginalLevelSceneRoot)Scene, false, delegate
            {
                if (!wasUnlocked)
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                        new UnlockedPico8MessageState(engine, delegate { done = true; }));
                else done = true;
                engine.Frame.Scenes.NextScene = ClassicConsoleRuntime.Create(engine, Scene as OriginalLevelSceneRoot);
            });
            while (!done) yield return null;
            yield return .25f;
            talking = false;
            (Scene as OriginalLevelSceneRoot).PauseLock = false;
            player.Machine.State = 0;
        }

        public override void SceneEnd(object scene)
        {
            if (sfx != null)
            {
                sfx.Stop();
                sfx.RemoveSelf();
                sfx = null;
            }

            base.SceneEnd(scene);
        }
    }
}
