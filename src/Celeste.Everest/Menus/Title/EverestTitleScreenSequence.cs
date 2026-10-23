using Celeste.Core.Display;
using Celeste.Scene.Rendering;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Everest.Menus.InitialSetup;
using Celeste.Everest;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.UI.Shutdown;
using Celeste.Game.Menus.Title;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Scenes;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Everest.Menus.Title
{
    public sealed class EverestTitleScreenSequence : TitleScreenSequence
    {
        private EverestCoreSettings CoreSettings =>
            ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings;

        private SourceEverestModule CoreModule => ((IEverestCoreModuleEnvironment)engine).CoreModule;
        private EverestStartupRuntimeProcess Runtime => ((IEverestStartupRuntimeEnvironment)engine).EverestRuntime;
        private EverestUpdaterProcess Updater => ((IEverestUpdaterEnvironment)engine).Updater;

        private float Clamp(float value, float min, float max) => Celeste.Core.Mathematics.ScalarMath.Clamp(value, min,
            max,
            ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);

        private float switchingToVanilla;

        private float switchingToVanillaBack;

        private const float SwitchingToVanillaDuration = 2f;

        private AtlasEntry updateTex;

        private float updateAlpha;

        private bool updateChecked;

        private SpriteImage vanillaLogo;

        private AtlasEntry vanillaTitle;

        private List<AtlasEntry> vanillaReflections;

        private SpriteImage everestLogo;

        private AtlasEntry everestTitle;

        private List<AtlasEntry> everestReflections;

        private AtlasEntry arrowToVanilla;

        public EverestTitleScreenSequence(ISourceEngineContext engine) : this(engine, BeginConstruction(engine))
        {
        }

        private static bool BeginConstruction(ISourceEngineContext engine)
        {
            var settings = ((ISettingsContext)engine).Settings;
            bool previous = settings.LaunchWithFMODLiveUpdate;
            settings.LaunchWithFMODLiveUpdate |= ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings
                .LaunchWithFMODLiveUpdateInEverest;
            return previous;
        }

        private EverestTitleScreenSequence(ISourceEngineContext engine, bool launchWithFMODLiveUpdate) : base(engine)
        {
            Settings.LaunchWithFMODLiveUpdate = launchWithFMODLiveUpdate;
            vanillaLogo = logo;
            vanillaTitle = title;
            vanillaReflections = reflections;
            everestLogo = new SpriteImage(Graphics.GuiAtlas["logo_everest"]);
            everestLogo.CenterOrigin();
            everestLogo.Position = new Vector2(1920f, 1080f) / 2f;
            everestTitle = Graphics.GuiAtlas["title_everest"];
            everestReflections = new List<AtlasEntry>();
            for (int num = everestTitle.FrameHeight - 4; num > 0; num -= 4)
            {
                everestReflections.Add(everestTitle.GetSubtexture(0, num, everestTitle.FrameWidth, 4));
            }

            arrowToVanilla = Graphics.GuiAtlas["dotarrow"];
            version += $"\nEverest v.{Runtime.Version}-{Runtime.VersionTag}";
            ((IEverestDebugRemoteControlEnvironment)engine).DebugRC.Initialize();
        }

        public override bool IsStart(OverworldSequence overworld, OverworldStartMode start)
        {
            var hooks =
                global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                    .Get<IEverestMenuStartupHooksEnvironment>(engine);
            return hooks != null
                ? hooks.InvokeSourceTitleStart(() => IsStartInstalled(overworld, start),
                    () => base.IsStart(overworld, start))
                : IsStartInstalled(overworld, start);
        }

        private bool IsStartInstalled(OverworldSequence overworld, OverworldStartMode start)
        {
            if (CoreSettings.CurrentVersion == null && !overworld.IsCurrent<EverestCoreOobeSequence>() &&
                !((IEverestUpdaterPhysicalEnvironment)engine).Flags.IsHeadless)
            {
                start = OverworldStartMode.MainMenu;
            }

            return base.IsStart(overworld, start);
        }

        public override void Update()
        {
            base.Update();
            if (CoreSettings.QuickRestart.HasValue)
            {
                int value = CoreSettings.QuickRestart.Value;
                CoreSettings.QuickRestart = null;
                if (CoreSettings.SaveDataFlush == true)
                {
                    CoreModule.ForceSaveDataFlush++;
                }

                CoreModule.SaveSettings();
                OriginalSaveDataState saveData =
                    ((IOriginalUserIOStorageEnvironment)engine).UserIOStorage.Load<OriginalSaveDataState>(
                        ((IOriginalSaveInitializationEnvironment)engine).SaveInitialization.GetFilename(value), false);
                if (saveData != null)
                {
                    ((IOriginalSaveStartEnvironment)engine).SaveStart.Start(saveData, value,
                        ((IOriginalSaveInitializationEnvironment)engine).SaveInitializationServices);
                    if (value == -1)
                    {
                        saveData.DebugMode = true;
                    }

                    var currentSession_Safe = ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection
                        .GetCurrentSessionSafe(saveData);
                    if (currentSession_Safe != null && currentSession_Safe.InArea)
                    {
                        OriginalLevelEntryRouting.Go(
                            ((IOriginalSaveSessionSelectionEnvironment)engine).SaveSessionSelection
                            .GetCurrentSessionSafe(
                                saveData), true, engine.Frame.Scenes,
                            ((IOriginalLevelEntryEnvironment)engine).LevelEntries);
                    }
                    else
                    {
                        base.Overworld.Goto<ChapterSelectSequence>();
                    }
                }
            }

            if (!updateChecked && Updater.HasUpdate &&
                Updater.Newest.Source.UpdatePriority != EverestUpdatePriority.None &&
                alpha >= 1f)
            {
                updateChecked = true;
                updateTex = ((Updater.Newest.Source.UpdatePriority == EverestUpdatePriority.High)
                    ? Graphics.GuiAtlas["areas/new"]
                    : Graphics.GuiAtlas["areas/new-yellow"]);
                SourceTweenState tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                    Easing.CubeInOut, 0.3f, start: true);
                tween.OnUpdate = delegate(SourceTweenState t) { updateAlpha = t.Percent; };
                Add(tween);
            }

            if (alpha >= 1f && base.Selected && Input.MenuRight.Check && arrowToVanilla != null)
            {
                switchingToVanillaBack = Math.Max(0f, switchingToVanillaBack - engine.DeltaTime * 8f);
                switchingToVanilla += engine.DeltaTime;
                if (switchingToVanilla >= 2f && !Runtime.RestartVanilla)
                {
                    Runtime.RestartVanilla = true;
                    new FadeWipePresentation((ISourceRendererScene)base.Scene, wipeIn: false, delegate
                    {
                        engine.Frame.Scenes.NextScene = new OriginalPlainScene(engine);
                        ((IEverestApplicationExitEnvironment)engine).ApplicationLoop.Exit();
                    });
                }
            }
            else if (switchingToVanilla < 2f)
            {
                if (switchingToVanilla > 0f)
                {
                    switchingToVanillaBack = Math.Max(switchingToVanilla, switchingToVanillaBack);
                }

                switchingToVanillaBack = Math.Max(0f, switchingToVanillaBack - engine.DeltaTime * 4f);
                switchingToVanilla = 0f;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (CoreSettings.ShowEverestTitleScreen)
            {
                logo = everestLogo;
                title = everestTitle;
                reflections = everestReflections;
            }
            else
            {
                logo = vanillaLogo;
                title = vanillaTitle;
                reflections = vanillaReflections;
            }

            float num = alpha;
            float num2 = textY;
            float num3 = Easing.CubeInOut(Clamp(Math.Max(switchingToVanilla, switchingToVanillaBack), 0f, 1f));
            alpha = Clamp(alpha - num3, 0f, 1f);
            textY += num3 * 200f;
            base.Render(context);
            if (arrowToVanilla != null)
                SourceAtlasDrawing.DrawJustified(context, this, arrowToVanilla,
                    new Vector2(1840f + (textY - 1000f) * 2f, 540f), new Vector2(1f, 0.5f), PackedColor.White * alpha);
            if (updateTex != null)
                SourceAtlasDrawing.DrawJustified(context, this, updateTex,
                    new Vector2(76f, textY + 8f * (1f - updateAlpha) + 2f), new Vector2(1f, 1f),
                    PackedColor.White * updateAlpha, 0.8f);
            alpha = num;
            textY = num2;
            if (num3 > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, 0f, 0f, 1920f, 1080f, PackedColor.Black * num3);
                float num4 = 40f * (1f - num3);
                Text.ActiveFont.Draw(context, this, Text.Dialog.Clean("MENU_TITLESCREEN_RESTART_VANILLA"),
                    new Vector2(960f + num4, 536f), new Vector2(0.5f, 1f), Vector2.One, PackedColor.White * num3);
                if (!Runtime.ShareVanillaSaveFiles)
                {
                    Text.ActiveFont.Draw(context, this,
                        Text.Dialog.Clean("MENU_TITLESCREEN_RESTART_VANILLA_SAVES_WARN"),
                        new Vector2(960f + num4, 556f), new Vector2(0.5f, 0f), Vector2.One * 0.9f,
                        PackedColor.OrangeRed * num3);
                }

                SourcePrimitiveDrawing.Rect(context, this, 760f + num4, 544f, 400f, 4f,
                    PackedColor.Black * num3 * num3);
                SourcePrimitiveDrawing.HollowRect(context, this, 760f + num4, 544f, 400f, 4f,
                    PackedColor.DarkSlateGray * num3);
                SourcePrimitiveDrawing.Rect(context, this, 760f + num4, 544f,
                    400f * Clamp(Math.Max(switchingToVanilla, switchingToVanillaBack) / 2f, 0f, 1f), 4f,
                    PackedColor.White * num3);
            }
        }
    }
}
