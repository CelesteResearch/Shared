using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart28(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiFileNamingRenderingAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiFileSelectSubmenuChecksAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiFileSelectSlotUpdateAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchFileSelectSlotRenderAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiFileSelectSlotOnContinueSelectedAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchFileSelectSlotRenderMissingVanillaDataDialog",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiJournalStatsHeartGemCheckAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOverworldRegisterOuiAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTotalHeartGemCSidePostcardAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchCSidePostcardTextAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPathfinderRenderAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchEmulatorConstructorAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchChaserStateImport",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerOrigUpdateAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerBeforeUpTransition",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerStarFlyReturnToNormalHitboxAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerOnCollideV",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerClimbBegin",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerOrigWallJumpAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerCtorAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerExplodeLaunchAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerApproachMaxMoveAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchRainFGRenderAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchResortMirrorBeforeRenderAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchRumbleTriggerAwakeAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSeekerBarrierDraw",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSessionOrigCtorAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSettingsSetDefaultKeyboardControls",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSolidAwakeAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSpikesDraw",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchStrawberryTrainCollectionOrder",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchStrawberryInterfaceAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPatchStrawberrySeedOnAllCollectedAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTextMenuOptionColorAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTextMenuSettingUpdateAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTextMenuUpdateAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTrailManagerConstructorAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTrailManagerBeforeRenderAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTrailManagerSnapshotRenderAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSaveRoutineAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSaveDataFlushSavesAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchUserIOPathsAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchWaterUpdateAttribute",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchWireRender",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677290, "TextMenuExt", "DrawIcon", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677291, "TextMenuExt", "GetItems", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677292, "TextMenuExt", "Insert", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677293, "TextMenuExt", "Remove", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+IItemExt",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+ButtonExt",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+SubHeaderExt",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+HeaderImage",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+EaseInSubHeaderExt",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+EnumSlider`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+EnumerableSlider`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+IntSlider",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+SubMenu", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677413, "SubMenu", "DrawIcon", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+OptionSubMenu",
                new ISourceCommandMethodMetadata[]
                {
                    new SourceCommandMethodFacts(100677445, "OptionSubMenu", "DrawIcon", Array.Empty<string>(),
                        Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
                });
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+OptionSubMenu+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+BatchModeContext",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+SubMenuWithInputs",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+EaseInSubMenuWithInputs",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+TextBox", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677518, "TextBox", "NegativeModulo", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677519, "TextBox", "WrappingLinearSearch", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+TextBox+OnTextChangeHandler",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+TextBox+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+Modal",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+SearchToolTip",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.AreaDataExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677544, "AreaDataExt", "Get", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677545, "AreaDataExt", "Get", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677546, "AreaDataExt", "IsInterludeUnsafe", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677547, "AreaDataExt", "ToKey", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677548, "AreaDataExt", "GetLevelSet", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677549, "AreaDataExt", "IsOfficialLevelSet", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677550, "AreaDataExt", "GetSID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677551, "AreaDataExt", "SetSID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677552, "AreaDataExt", "GetMeta", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677553, "AreaDataExt", "SetMeta", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677554, "AreaDataExt", "GetASideAreaDataBackup", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677555, "AreaDataExt", "SetASideAreaDataBackup", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677556, "AreaDataExt", "RestoreASideAreaData", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677557, "AreaDataExt", "GetModeMeta", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677558, "AreaDataExt", "OverrideASideMeta", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.AreaKeyExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677559, "AreaKeyExt", "GetLevelSet", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677560, "AreaKeyExt", "GetSID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677561, "AreaKeyExt", "SetSID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677562, "AreaKeyExt", "GetRelativeIndex", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.AreaStatsExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677563, "AreaStatsExt", "ToKey", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677564, "AreaStatsExt", "GetLevelSet", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677565, "AreaStatsExt", "GetSID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677566, "AreaStatsExt", "SetSID", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.AudioExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677567, "AudioExt", "get_Banks", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677568, "AudioExt", "CheckFMOD", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677569, "AudioExt", "IngestBank", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677570, "AudioExt", "IngestGUIDs", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.CheckpointDataExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677571, "CheckpointDataExt", "GetArea", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677572, "CheckpointDataExt", "SetArea", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.DecalExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677573, "DecalExt", "GetScale", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677574, "DecalExt", "SetScale", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.DialogExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677575, "DialogExt", "CleanLevelSet", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.GameplayRendererExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677576, "GameplayRendererExt", "get_RenderDebug", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677577, "GameplayRendererExt", "set_RenderDebug", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.LevelExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677578, "LevelExt", "get_PauseSnapshot", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677579, "LevelExt", "GetSubHudRenderer", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677580, "LevelExt", "SetSubHudRenderer", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnterExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677581, "LevelEnterExt", "get_ErrorMessage", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677582, "LevelEnterExt", "set_ErrorMessage", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.MainMenuSmallButtonExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677583, "MainMenuSmallButtonExt", "GetLabelName", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677584, "MainMenuSmallButtonExt", "GetIconName", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677585, "MainMenuSmallButtonExt", "GetEase", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677586, "MainMenuSmallButtonExt", "GetWiggler", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.MapDataExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677587, "MapDataExt", "GetMeta", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677588, "MapDataExt", "GetDetectedCassette", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677589, "MapDataExt", "SetDetectedCassette", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677590, "MapDataExt", "GetDetectedStrawberriesIncludingUntracked",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677591, "MapDataExt", "SetDetectedStrawberriesIncludingUntracked",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677592, "MapDataExt", "GetDashlessGoldenberries", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.MenuButtonExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677593, "MenuButtonExt", "SetSelected", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.ModePropertiesExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677594, "ModePropertiesExt", "GetMapMeta", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677595, "ModePropertiesExt", "SetMapMeta", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.MountainResources",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.MTNExt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100677597, "MTNExt", "get_ModsLoaded", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677598, "MTNExt", "set_ModsLoaded", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677599, "MTNExt", "get_ModsDataLoaded", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677600, "MTNExt", "set_ModsDataLoaded", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677601, "MTNExt", "ReloadModData", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677602, "MTNExt", "ReloadMod", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677603, "MTNExt", "LoadModData", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677604, "MTNExt", "resolveModel", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677605, "MTNExt", "loadModelFile", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677606, "MTNExt", "LoadMod", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100677607, "MTNExt", "parseColorArray", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
        }
    }
}
