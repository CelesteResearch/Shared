using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart28(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiFileNamingRenderingAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiFileSelectSubmenuChecksAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiFileSelectSlotUpdateAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchFileSelectSlotRenderAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiFileSelectSlotOnContinueSelectedAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchFileSelectSlotRenderMissingVanillaDataDialog",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOuiJournalStatsHeartGemCheckAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchOverworldRegisterOuiAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTotalHeartGemCSidePostcardAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchCSidePostcardTextAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPathfinderRenderAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchEmulatorConstructorAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchChaserStateImport",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerOrigUpdateAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerBeforeUpTransition",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerStarFlyReturnToNormalHitboxAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerOnCollideV",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerClimbBegin",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerOrigWallJumpAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerCtorAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerExplodeLaunchAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPlayerApproachMaxMoveAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchRainFGRenderAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchResortMirrorBeforeRenderAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchRumbleTriggerAwakeAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSeekerBarrierDraw",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSessionOrigCtorAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSettingsSetDefaultKeyboardControls",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSolidAwakeAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSpikesDraw",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchStrawberryTrainCollectionOrder",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchStrawberryInterfaceAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchPatchStrawberrySeedOnAllCollectedAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTextMenuOptionColorAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTextMenuSettingUpdateAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTextMenuUpdateAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTrailManagerConstructorAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTrailManagerBeforeRenderAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchTrailManagerSnapshotRenderAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSaveRoutineAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchSaveDataFlushSavesAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchUserIOPathsAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchWaterUpdateAttribute",
                []);
            catalog.PublishDeclaredCommandMethods("MonoMod.PatchWireRender",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt", [
                new SourceCommandMethodFacts(100677290, "TextMenuExt", "DrawIcon", [],
                    [], []),
                new SourceCommandMethodFacts(100677291, "TextMenuExt", "GetItems", [],
                    [], []),
                new SourceCommandMethodFacts(100677292, "TextMenuExt", "Insert", [],
                    [], []),
                new SourceCommandMethodFacts(100677293, "TextMenuExt", "Remove", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+IItemExt",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+ButtonExt",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+SubHeaderExt",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+HeaderImage",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+EaseInSubHeaderExt",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+EnumSlider`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+EnumerableSlider`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+IntSlider",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+SubMenu", [
                new SourceCommandMethodFacts(100677413, "SubMenu", "DrawIcon", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+OptionSubMenu",
            [
                new SourceCommandMethodFacts(100677445, "OptionSubMenu", "DrawIcon", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+OptionSubMenu+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+BatchModeContext",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+SubMenuWithInputs",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+EaseInSubMenuWithInputs",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+TextBox", [
                new SourceCommandMethodFacts(100677518, "TextBox", "NegativeModulo", [],
                    [], []),
                new SourceCommandMethodFacts(100677519, "TextBox", "WrappingLinearSearch", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+TextBox+OnTextChangeHandler",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+TextBox+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+Modal",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TextMenuExt+SearchToolTip",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaDataExt", [
                new SourceCommandMethodFacts(100677544, "AreaDataExt", "Get", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100677545, "AreaDataExt", "Get", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100677546, "AreaDataExt", "IsInterludeUnsafe", [],
                    [], []),
                new SourceCommandMethodFacts(100677547, "AreaDataExt", "ToKey", [],
                    [], []),
                new SourceCommandMethodFacts(100677548, "AreaDataExt", "GetLevelSet", [],
                    [], []),
                new SourceCommandMethodFacts(100677549, "AreaDataExt", "IsOfficialLevelSet", [],
                    [], []),
                new SourceCommandMethodFacts(100677550, "AreaDataExt", "GetSID", [],
                    [], []),
                new SourceCommandMethodFacts(100677551, "AreaDataExt", "SetSID", [],
                    [], []),
                new SourceCommandMethodFacts(100677552, "AreaDataExt", "GetMeta", [],
                    [], []),
                new SourceCommandMethodFacts(100677553, "AreaDataExt", "SetMeta", [],
                    [], []),
                new SourceCommandMethodFacts(100677554, "AreaDataExt", "GetASideAreaDataBackup", [],
                    [], []),
                new SourceCommandMethodFacts(100677555, "AreaDataExt", "SetASideAreaDataBackup", [],
                    [], []),
                new SourceCommandMethodFacts(100677556, "AreaDataExt", "RestoreASideAreaData", [],
                    [], []),
                new SourceCommandMethodFacts(100677557, "AreaDataExt", "GetModeMeta", [],
                    [], []),
                new SourceCommandMethodFacts(100677558, "AreaDataExt", "OverrideASideMeta", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaKeyExt", [
                new SourceCommandMethodFacts(100677559, "AreaKeyExt", "GetLevelSet", [],
                    [], []),
                new SourceCommandMethodFacts(100677560, "AreaKeyExt", "GetSID", [],
                    [], []),
                new SourceCommandMethodFacts(100677561, "AreaKeyExt", "SetSID", [],
                    [], []),
                new SourceCommandMethodFacts(100677562, "AreaKeyExt", "GetRelativeIndex", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.AreaStatsExt", [
                new SourceCommandMethodFacts(100677563, "AreaStatsExt", "ToKey", [],
                    [], []),
                new SourceCommandMethodFacts(100677564, "AreaStatsExt", "GetLevelSet", [],
                    [], []),
                new SourceCommandMethodFacts(100677565, "AreaStatsExt", "GetSID", [],
                    [], []),
                new SourceCommandMethodFacts(100677566, "AreaStatsExt", "SetSID", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.AudioExt", [
                new SourceCommandMethodFacts(100677567, "AudioExt", "get_Banks", [],
                    [], []),
                new SourceCommandMethodFacts(100677568, "AudioExt", "CheckFMOD", [],
                    [], []),
                new SourceCommandMethodFacts(100677569, "AudioExt", "IngestBank", [],
                    [], []),
                new SourceCommandMethodFacts(100677570, "AudioExt", "IngestGUIDs", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.CheckpointDataExt", [
                new SourceCommandMethodFacts(100677571, "CheckpointDataExt", "GetArea", [],
                    [], []),
                new SourceCommandMethodFacts(100677572, "CheckpointDataExt", "SetArea", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.DecalExt", [
                new SourceCommandMethodFacts(100677573, "DecalExt", "GetScale", [],
                    [], []),
                new SourceCommandMethodFacts(100677574, "DecalExt", "SetScale", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.DialogExt", [
                new SourceCommandMethodFacts(100677575, "DialogExt", "CleanLevelSet", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.GameplayRendererExt", [
                new SourceCommandMethodFacts(100677576, "GameplayRendererExt", "get_RenderDebug", [],
                    [], []),
                new SourceCommandMethodFacts(100677577, "GameplayRendererExt", "set_RenderDebug", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelExt", [
                new SourceCommandMethodFacts(100677578, "LevelExt", "get_PauseSnapshot", [],
                    [], []),
                new SourceCommandMethodFacts(100677579, "LevelExt", "GetSubHudRenderer", [],
                    [], []),
                new SourceCommandMethodFacts(100677580, "LevelExt", "SetSubHudRenderer", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelEnterExt", [
                new SourceCommandMethodFacts(100677581, "LevelEnterExt", "get_ErrorMessage", [],
                    [], []),
                new SourceCommandMethodFacts(100677582, "LevelEnterExt", "set_ErrorMessage", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MainMenuSmallButtonExt", [
                new SourceCommandMethodFacts(100677583, "MainMenuSmallButtonExt", "GetLabelName", [],
                    [], []),
                new SourceCommandMethodFacts(100677584, "MainMenuSmallButtonExt", "GetIconName", [],
                    [], []),
                new SourceCommandMethodFacts(100677585, "MainMenuSmallButtonExt", "GetEase", [],
                    [], []),
                new SourceCommandMethodFacts(100677586, "MainMenuSmallButtonExt", "GetWiggler", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MapDataExt", [
                new SourceCommandMethodFacts(100677587, "MapDataExt", "GetMeta", [],
                    [], []),
                new SourceCommandMethodFacts(100677588, "MapDataExt", "GetDetectedCassette", [],
                    [], []),
                new SourceCommandMethodFacts(100677589, "MapDataExt", "SetDetectedCassette", [],
                    [], []),
                new SourceCommandMethodFacts(100677590, "MapDataExt", "GetDetectedStrawberriesIncludingUntracked",
                    [], [], []),
                new SourceCommandMethodFacts(100677591, "MapDataExt", "SetDetectedStrawberriesIncludingUntracked",
                    [], [], []),
                new SourceCommandMethodFacts(100677592, "MapDataExt", "GetDashlessGoldenberries", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MenuButtonExt", [
                new SourceCommandMethodFacts(100677593, "MenuButtonExt", "SetSelected", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.ModePropertiesExt", [
                new SourceCommandMethodFacts(100677594, "ModePropertiesExt", "GetMapMeta", [],
                    [], []),
                new SourceCommandMethodFacts(100677595, "ModePropertiesExt", "SetMapMeta", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MountainResources",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MTNExt", [
                new SourceCommandMethodFacts(100677597, "MTNExt", "get_ModsLoaded", [],
                    [], []),
                new SourceCommandMethodFacts(100677598, "MTNExt", "set_ModsLoaded", [],
                    [], []),
                new SourceCommandMethodFacts(100677599, "MTNExt", "get_ModsDataLoaded", [],
                    [], []),
                new SourceCommandMethodFacts(100677600, "MTNExt", "set_ModsDataLoaded", [],
                    [], []),
                new SourceCommandMethodFacts(100677601, "MTNExt", "ReloadModData", [],
                    [], []),
                new SourceCommandMethodFacts(100677602, "MTNExt", "ReloadMod", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100677603, "MTNExt", "LoadModData", [],
                    [], []),
                new SourceCommandMethodFacts(100677604, "MTNExt", "resolveModel", [],
                    [], []),
                new SourceCommandMethodFacts(100677605, "MTNExt", "loadModelFile", [],
                    [], []),
                new SourceCommandMethodFacts(100677606, "MTNExt", "LoadMod", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100677607, "MTNExt", "parseColorArray", [],
                    [], []),
            ]);
        }
    }
}
