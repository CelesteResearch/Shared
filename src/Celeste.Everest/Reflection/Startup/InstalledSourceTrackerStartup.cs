using System;
using Celeste.Core.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Chapters.Flow;
using Celeste.Everest.Content.Maps.Backdrops;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Entities.Mechanisms.RumbleWalls;
using Celeste.Everest.Gameplay.Effects.Debris;
using Celeste.Everest.Gameplay.Enemies.AngryOshiro;
using Celeste.Everest.Gameplay.Enemies.Seekers;
using Celeste.Everest.Gameplay.Environment.Ridge;
using Celeste.Everest.Gameplay.Environment.Water;
using Celeste.Everest.Gameplay.Hazards.TriggerSpikes;
using Celeste.Everest.Gameplay.Lookouts;
using Celeste.Everest.Gameplay.Platforms.BounceBlocks;
using Celeste.Everest.Gameplay.Platforms.Cassette;
using Celeste.Everest.Gameplay.Platforms.Clouds;
using Celeste.Everest.Gameplay.Platforms.Crumble;
using Celeste.Everest.Menus.Journal;
using Celeste.Everest.Menus.Overworld;
using Celeste.Everest.Menus.Pause;
using Celeste.Everest.Menus.Title;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Presentation.Completion;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Settings;
using Celeste.Everest.Tracking.Initialization;
using Celeste.Everest.UI.Controls;
using Celeste.Everest.UI.Menus.Buttons;
using Celeste.Everest.UI.Progress;
using Celeste.Game.Gameplay.Triggers.Audio;
using Celeste.Game.Reflection.Startup;
using Celeste.Scene.Tracking;
using Celeste.Scene.Tracking.Initialization;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;

namespace Celeste.Everest.Reflection.Startup
{
    public static class InstalledSourceTrackerStartup
    {
        public static SourceTrackerInitialization Create(SceneEntityCatalog catalog,
            ISourceEverestModulesEnvironment modules,
            Func<Type, string> requireOriginalAssemblyIdentity,
            Func<string, ISourceTypeMetadata[]> requireOriginalAssemblyTypes)
        {
            const string identity = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var assembly = new SourceCatalogAssemblyMetadata(catalog, identity);
            InstalledLogicalTypeFacts.Register(catalog, identity, assembly);
            catalog.RegisterRuntimeType(typeof(TimeRateModifier),
                "Celeste.Mod.Entities.TimeRateModifier");
            catalog.SelectLogicalActualType(typeof(TimeRateModifier),
                "Celeste.Mod.Entities.TimeRateModifier");
            catalog.RegisterRuntimeType(typeof(EverestKeyboardConfigPresentation),
                "Celeste.KeyboardConfigUI");
            catalog.SelectLogicalActualType(
                typeof(EverestKeyboardConfigPresentation),
                "Celeste.KeyboardConfigUI");
            catalog.RegisterRuntimeType(typeof(EverestButtonConfigPresentation),
                "Celeste.ButtonConfigUI");
            catalog.SelectLogicalActualType(typeof(EverestButtonConfigPresentation),
                "Celeste.ButtonConfigUI");
            catalog.RegisterRuntimeType(typeof(ModuleSettingsKeyboardConfigUI),
                "Celeste.Mod.ModuleSettingsKeyboardConfigUI");
            catalog.RegisterRuntimeType(typeof(ModuleSettingsButtonConfigUI),
                "Celeste.Mod.ModuleSettingsButtonConfigUI");
            catalog.RegisterRuntimeType(
                typeof(InstalledCassetteListenerState),
                "Celeste.Mod.Entities.CassetteListener");
            catalog.RegisterRuntimeType(typeof(MainMenuModOptionsButton),
                "Celeste.Mod.UI.MainMenuModOptionsButton");
            catalog.RegisterRuntimeType(typeof(EverestVanillaTristate),
                "Celeste.Mod.Core.CoreModuleSettings.VanillaTristate");
            catalog.SelectLogicalActualType(typeof(EverestVanillaTristate),
                "Celeste.Mod.Core.CoreModuleSettings+VanillaTristate");
            OriginalTrackerFrameworkTypeBindings.Register(catalog);
            catalog.RegisterRuntimeType(
                typeof(EverestRainBackdropPresentation),
                "Celeste.RainFG");
            catalog.SelectLogicalActualType(
                typeof(EverestRainBackdropPresentation),
                "Celeste.RainFG");
            OriginalTrackedComponentActualTypeBindings.Register(catalog);
            OriginalOwnActorActualTypeBindings.Register(catalog);
            OriginalScreenWipeActualTypeBindings.Register(catalog);
            catalog.RegisterRuntimeType(
                typeof(EverestCrumblePlatformState),
                "Celeste.CrumblePlatform");
            catalog.SelectLogicalActualType(
                typeof(EverestCrumblePlatformState),
                "Celeste.CrumblePlatform");
            catalog.RegisterRuntimeType(typeof(EverestCloudState),
                "Celeste.Cloud");
            catalog.SelectLogicalActualType(typeof(EverestCloudState),
                "Celeste.Cloud");
            catalog.RegisterRuntimeType(typeof(EverestGameLoaderScene),
                "Celeste.GameLoader");
            catalog.SelectLogicalActualType(typeof(EverestGameLoaderScene),
                "Celeste.GameLoader");
            catalog.RegisterRuntimeType(typeof(EverestOverworldSequence),
                "Celeste.Overworld");
            catalog.SelectLogicalActualType(typeof(EverestOverworldSequence),
                "Celeste.Overworld");
            OriginalPooledActualTypeBindings.Register(catalog);
            catalog.RegisterRuntimeType(typeof(EverestDebrisState),
                "Celeste.Debris");
            catalog.SelectLogicalActualType(typeof(EverestDebrisState),
                "Celeste.Debris");
            catalog.RegisterRuntimeType(
                typeof(EverestCrystalDebrisState),
                "Celeste.CrystalDebris");
            catalog.SelectLogicalActualType(
                typeof(EverestCrystalDebrisState),
                "Celeste.CrystalDebris");
            catalog.RegisterRuntimeType(
                typeof(EverestBounceBlockState),
                "Celeste.BounceBlock");
            catalog.SelectLogicalActualType(
                typeof(EverestBounceBlockState),
                "Celeste.BounceBlock");
            catalog.RegisterRuntimeType(typeof(EverestSeekerState),
                "Celeste.Seeker");
            catalog.SelectLogicalActualType(typeof(EverestSeekerState),
                "Celeste.Seeker");
            catalog.RegisterRuntimeType(typeof(NamedSimulationStateMachine),
                "Monocle.StateMachine");
            catalog.SelectLogicalActualType(typeof(NamedSimulationStateMachine),
                "Monocle.StateMachine");
            EverestWaterRuntimeTypeBindings.Register(catalog);
            catalog.RegisterRuntimeType(
                typeof(EverestRumbleTriggerState),
                "Celeste.RumbleTrigger");
            catalog.RegisterRuntimeType(
                typeof(EverestAngryOshiroState),
                "Celeste.AngryOshiro");
            catalog.SelectLogicalActualType(
                typeof(EverestWaterState),
                "Celeste.Water");
            catalog.SelectLogicalActualType(
                typeof(EverestWaterInteractionState),
                "Celeste.WaterInteraction");
            catalog.SelectLogicalActualType(
                typeof(EverestRumbleTriggerState),
                "Celeste.RumbleTrigger");
            catalog.SelectLogicalActualType(
                typeof(EverestAngryOshiroState),
                "Celeste.AngryOshiro");
            catalog.RegisterRuntimeType(typeof(EverestFlaglineState),
                "Celeste.Flagline");
            catalog.SelectLogicalActualType(
                typeof(EverestFlaglineState),
                "Celeste.Flagline");
            catalog.RegisterRuntimeType(
                typeof(InstalledCassetteBlockManagerState),
                "Celeste.CassetteBlockManager");
            catalog.SelectLogicalActualType(
                typeof(InstalledCassetteBlockManagerState),
                "Celeste.CassetteBlockManager");
            catalog.RegisterRuntimeType(typeof(EverestLookoutState),
                "Celeste.Lookout");
            catalog.SelectLogicalActualType(typeof(EverestLookoutState),
                "Celeste.Lookout");
            catalog.RegisterRuntimeType(typeof(EverestReturnMapHintState),
                "Celeste.ReturnMapHint");
            catalog.SelectLogicalActualType(typeof(EverestReturnMapHintState),
                "Celeste.ReturnMapHint");
            catalog.RegisterRuntimeType(
                typeof(InstalledMusicFadeTriggerState),
                "Celeste.MusicFadeTrigger");
            catalog.SelectLogicalActualType(
                typeof(InstalledMusicFadeTriggerState),
                "Celeste.MusicFadeTrigger");
            catalog.RegisterRuntimeType(typeof(EverestLoggedProgressState),
                "Celeste.Mod.UI.OuiLoggedProgress");
            catalog.SelectLogicalActualType(typeof(EverestLoggedProgressState),
                "Celeste.Mod.UI.OuiLoggedProgress");
            catalog.RegisterRuntimeType(
                typeof(ISourceStrawberryCollectible),
                "Celeste.Mod.IStrawberry");
            catalog.SelectLogicalActualType(
                typeof(ISourceStrawberryCollectible),
                "Celeste.Mod.IStrawberry");
            catalog.RegisterRuntimeType(typeof(EverestCheckpointData),
                "Celeste.CheckpointData");
            catalog.SelectLogicalActualType(typeof(EverestCheckpointData),
                "Celeste.CheckpointData");
            catalog.RegisterRuntimeType(typeof(EverestAreaCompleteSequence),
                "Celeste.AreaComplete");
            catalog.SelectLogicalActualType(typeof(EverestAreaCompleteSequence),
                "Celeste.AreaComplete");
            catalog.RegisterRuntimeType(
                typeof(EverestCompleteRendererState),
                "Celeste.CompleteRenderer");
            catalog.SelectLogicalActualType(
                typeof(EverestCompleteRendererState),
                "Celeste.CompleteRenderer");
            catalog.RegisterRuntimeType(
                typeof(EverestCompleteRendererState.InstalledImageLayer),
                "Celeste.CompleteRenderer.ImageLayer");
            catalog.SelectLogicalActualType(
                typeof(EverestCompleteRendererState.InstalledImageLayer),
                "Celeste.CompleteRenderer+ImageLayer");
            catalog.RegisterRuntimeType(
                typeof(EverestCompleteRendererState.LayerNoXML),
                "Celeste.CompleteRenderer.LayerNoXML");
            catalog.SelectLogicalActualType(
                typeof(EverestCompleteRendererState.LayerNoXML),
                "Celeste.CompleteRenderer+LayerNoXML");
            catalog.RegisterRuntimeType(
                typeof(EverestCompleteRendererState.UILayerNoXML),
                "Celeste.CompleteRenderer.UILayerNoXML");
            catalog.SelectLogicalActualType(
                typeof(EverestCompleteRendererState.UILayerNoXML),
                "Celeste.CompleteRenderer+UILayerNoXML");
            catalog.RegisterRuntimeType(
                typeof(EverestCompleteRendererState.ImageLayerNoXML),
                "Celeste.CompleteRenderer.ImageLayerNoXML");
            catalog.SelectLogicalActualType(
                typeof(EverestCompleteRendererState.ImageLayerNoXML),
                "Celeste.CompleteRenderer+ImageLayerNoXML");
            catalog.RegisterRuntimeType(typeof(EverestMainMenuSequence),
                "Celeste.OuiMainMenu");
            catalog.SelectLogicalActualType(typeof(EverestMainMenuSequence),
                "Celeste.OuiMainMenu");
            catalog.RegisterRuntimeType(typeof(EverestTitleScreenSequence),
                "Celeste.OuiTitleScreen");
            catalog.SelectLogicalActualType(typeof(EverestTitleScreenSequence),
                "Celeste.OuiTitleScreen");
            catalog.RegisterRuntimeType(typeof(EverestJournalSequence),
                "Celeste.OuiJournal");
            catalog.SelectLogicalActualType(typeof(EverestJournalSequence),
                "Celeste.OuiJournal");
            TriggerSpikesRuntimeTypeBindings.Register(catalog);
            InstalledCustomEntityActualTypeBindings.Register(catalog);
            return new SourceInstalledTrackerInitialization(new SourceInstalledCatalogTrackerTypeUniverse(catalog,
                modules,
                requireOriginalAssemblyIdentity, requireOriginalAssemblyTypes));
        }
    }
}
