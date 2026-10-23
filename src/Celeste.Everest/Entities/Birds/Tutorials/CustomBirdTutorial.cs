using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Input.Bindings;
using Celeste.Everest.Modules.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;

namespace Celeste.Everest.Entities.Birds.Tutorials
{
    public class CustomBirdTutorial : BirdNpcState
    {
        public string BirdId;
        private readonly bool onlyOnce;
        private readonly bool caw;
        private bool triggered;
        private bool flewAway;
        protected BirdTutorialGuiState CustomTutorialGui { get; }

        private static readonly Dictionary<string, Vector2> directions = new()
        {
            ["Left"] = new(-1, 0), ["Right"] = new(1, 0),
            ["Up"] = new(0, -1), ["Down"] = new(0, 1),
            ["UpLeft"] = new(-1, -1), ["UpRight"] = new(1, -1),
            ["DownLeft"] = new(-1, 1), ["DownRight"] = new(1, 1),
        };

        protected CustomBirdTutorial(OriginalLevelSceneRoot level, OriginalLevelEntityData data, Vector2 offset)
            : base(level, data, offset, new(data.Level.Name, data.ID))
        {
            BirdId = data.Attr("birdId");
            onlyOnce = data.Bool("onlyOnce");
            caw = data.Bool("caw");
            Facing = data.Bool("faceLeft") ? -1 : 1;
            Sprite.Scale.X = Facing;
            var process = (IOriginalBirdProcess)EngineContext;
            var custom = (IEverestCustomBirdTutorialEnvironment)EngineContext;
            var textProcess = ((IOriginalGameTextEnvironment)EngineContext).Text;
            var text = data.Attr("info");
            var info = process.GuiAtlas.Has(text) ? process.GuiAtlas[text] : (object)textProcess.CleanDialog(text);
            var spacing = 0;
            var commands = data.Attr("controls").Split(',');
            var controls = new object[commands.Length];
            for (var i = 0; i < controls.Length; i++)
            {
                var command = commands[i];
                var parsed = custom.CustomBirdTutorialEvents.ParseCommand(command);
                if (parsed is EverestButtonBinding binding) parsed = binding.Button;
                if (parsed != null)
                {
                    controls[i] = parsed;
                }
                else if (command.StartsWith("mod:"))
                {
                    var autoBinding = command.Substring(4).Split('/');
                    var module = ((ISourceEverestModulesEnvironment)EngineContext).Modules
                        .FirstOrDefault(m => m.Metadata.Name == autoBinding[0]);
                    if (module?.SettingsType != null)
                    {
                        var modBinding = module.SettingsType.GetProperty(autoBinding[1])?.GetGetMethod()
                            ?.Invoke(module._Settings, null) as EverestButtonBinding;
                        if (modBinding?.Button != null) controls[i] = modBinding.Button;
                        else
                            ((IEverestLoggerProcessEnvironment)EngineContext).Logger.Log(EverestLogLevel.Warn,
                                "CustomBird",
                                "Public ButtonBinding property not found in " + module.SettingsType +
                                ". ControlString: " +
                                command);
                    }
                    else
                    {
                        ((IEverestLoggerProcessEnvironment)EngineContext).Logger.Log(EverestLogLevel.Warn,
                            "CustomBird",
                            "EverestModule or EverestModule.SettingsType not found. ControlString: " + command);
                    }
                }
                else if (process.GuiAtlas.Has(command))
                {
                    controls[i] = process.GuiAtlas[command];
                }
                else if (directions.ContainsKey(command))
                {
                    controls[i] = directions[command];
                }
                else
                {
                    var button = custom.ReadCustomBirdInputField(command);
                    if (button != null) controls[i] = button;
                    else if (command.StartsWith("dialog:")) controls[i] = textProcess.CleanDialog(command.Substring(7));
                    else controls[i] = command;
                }

                if (controls[i] is string)
                {
                    spacing++;
                    if (i == 0) spacing++;
                }
            }

            CustomTutorialGui = new(EngineContext, ((IOriginalGameTagsEnvironment)EngineContext).Tags.HUD.Value,
                process.BirdTutorialResources, this, new(0, -16), info, controls);
            CustomTutorialGui.ApplyCustomTutorialSpacing(string.IsNullOrEmpty(text), spacing);
        }

        public static SceneEntityState Load(OriginalLevelSceneRoot level, OriginalLevelRoomData levelData,
            Vector2 offset, OriginalLevelEntityData data)
        {
            return new CustomBirdTutorial(level, data, offset);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (((ISourceScene)scene).SourceScene.Entities
                .GetTrackedEntities("Celeste.Mod.Entities.CustomBirdTutorialTrigger")
                .OfType<CustomBirdTutorialTrigger>().All(trigger => !trigger.ShowTutorial || trigger.BirdId != BirdId))
                TriggerShowTutorial();
        }

        public void TriggerShowTutorial()
        {
            if (triggered) return;
            triggered = true;
            OwnedComponents.Add(new SimulationCoroutine(EngineContext, ShowTutorial(CustomTutorialGui, caw)));
        }

        public void TriggerHideTutorial()
        {
            if (flewAway) return;
            flewAway = true;
            if (triggered) OwnedComponents.Add(new SimulationCoroutine(EngineContext, HideTutorial()));
            triggered = true;
            OwnedComponents.Add(new SimulationCoroutine(EngineContext, StartleAndFlyAway()));
            if (onlyOnce) ((OriginalLevelSceneRoot)Scene).Session.DoNotLoad.Add(EntityID);
        }

        public static CustomBirdTutorial FindById(OriginalLevelSceneRoot level, string birdId)
        {
            return ((ISourceScene)level).SourceScene.Entities
                .GetTrackedEntities("Celeste.Mod.Entities.CustomBirdTutorial")
                .OfType<CustomBirdTutorial>().FirstOrDefault(bird => bird.BirdId == birdId);
        }
    }
}
