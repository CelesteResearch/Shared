using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart22(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.ActiveFont", [
                new SourceCommandMethodFacts(100674685, "ActiveFont", "get_Font", [],
                    [], []),
                new SourceCommandMethodFacts(100674686, "ActiveFont", "get_FontSize", [],
                    [], []),
                new SourceCommandMethodFacts(100674687, "ActiveFont", "get_BaseSize", [],
                    [], []),
                new SourceCommandMethodFacts(100674688, "ActiveFont", "get_LineHeight", [],
                    [], []),
                new SourceCommandMethodFacts(100674689, "ActiveFont", "Measure", [],
                    [], []),
                new SourceCommandMethodFacts(100674690, "ActiveFont", "Measure", [],
                    [], []),
                new SourceCommandMethodFacts(100674691, "ActiveFont", "WidthToNextLine", [],
                    [], []),
                new SourceCommandMethodFacts(100674692, "ActiveFont", "HeightOf", [],
                    [], []),
                new SourceCommandMethodFacts(100674693, "ActiveFont", "Draw", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100674694, "ActiveFont", "Draw", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100674695, "ActiveFont", "Draw", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100674696, "ActiveFont", "Draw", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100674697, "ActiveFont", "DrawOutline", [],
                    [], []),
                new SourceCommandMethodFacts(100674698, "ActiveFont", "DrawEdgeOutline", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.GameplayRenderer", [
                new SourceCommandMethodFacts(100674700, "GameplayRenderer", "Begin", [],
                    [], []),
                new SourceCommandMethodFacts(100674702, "GameplayRenderer", "End", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.HudRenderer", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Glitch", [
                new SourceCommandMethodFacts(100674705, "Glitch", "Apply", [], [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MenuOptions", [
                new SourceCommandMethodFacts(100674707, "MenuOptions", "Create", [],
                    [], []),
                new SourceCommandMethodFacts(100674708, "MenuOptions", "CreateRumble", [],
                    [], []),
                new SourceCommandMethodFacts(100674709, "MenuOptions", "CreateGrabMode", [],
                    [], []),
                new SourceCommandMethodFacts(100674710, "MenuOptions", "CreateCrouchDashMode", [],
                    [], []),
                new SourceCommandMethodFacts(100674711, "MenuOptions", "SetFullscreen", [],
                    [], []),
                new SourceCommandMethodFacts(100674712, "MenuOptions", "SetVSync", [],
                    [], []),
                new SourceCommandMethodFacts(100674713, "MenuOptions", "SetWindow", [],
                    [], []),
                new SourceCommandMethodFacts(100674714, "MenuOptions", "SetMusic", [],
                    [], []),
                new SourceCommandMethodFacts(100674715, "MenuOptions", "SetSfx", [],
                    [], []),
                new SourceCommandMethodFacts(100674716, "MenuOptions", "SetSpeedrunClock", [],
                    [], []),
                new SourceCommandMethodFacts(100674717, "MenuOptions", "OpenViewportAdjustment", [],
                    [], []),
                new SourceCommandMethodFacts(100674718, "MenuOptions", "SelectLanguage", [],
                    [], []),
                new SourceCommandMethodFacts(100674719, "MenuOptions", "OpenKeyboardConfig", [],
                    [], []),
                new SourceCommandMethodFacts(100674720, "MenuOptions", "OpenButtonConfig", [],
                    [], []),
                new SourceCommandMethodFacts(100674721, "MenuOptions", "EnterSound", [],
                    [], []),
                new SourceCommandMethodFacts(100674722, "MenuOptions", "LeaveSound", [],
                    [], []),
                new SourceCommandMethodFacts(100674723, "MenuOptions", "UpdateCrouchDashModeVisibility",
                    [], [], []),
                new SourceCommandMethodFacts(100674724, "MenuOptions", "orig_Create", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MenuOptions+<>c", [
                new SourceCommandMethodFacts(100674749, "<>c", "orig_ctor_<>c", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MenuOptions+<>c__DisplayClass1_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ParticleTypes", [
                new SourceCommandMethodFacts(100674768, "ParticleTypes", "Load", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.DeathData", []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerInventory",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData", [
                new SourceCommandMethodFacts(100674775, "SaveData", "Start", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100674776, "SaveData", "GetFilename", [],
                    [], []),
                new SourceCommandMethodFacts(100674777, "SaveData", "GetFilename", [],
                    [], []),
                new SourceCommandMethodFacts(100674778, "SaveData", "InitializeDebugMode", [],
                    [], []),
                new SourceCommandMethodFacts(100674779, "SaveData", "TryDelete", [],
                    [], []),
                new SourceCommandMethodFacts(100674782, "SaveData", "NoFileAssistChecks", [],
                    [], []),
                new SourceCommandMethodFacts(100674824, "SaveData", "orig_Start", [],
                    [], []),
                new SourceCommandMethodFacts(100674825, "SaveData", "LoadModSaveData", [],
                    [], []),
                new SourceCommandMethodFacts(100674826, "SaveData", "orig_TryDelete", [],
                    [], []),
                new SourceCommandMethodFacts(100674827, "SaveData", "TryDeleteModSaveData", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData+<>c", []);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData+<>c__DisplayClass62_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData+<>c__DisplayClass62_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData+<>c__DisplayClass64_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData+<>c__DisplayClass65_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData+<>c__DisplayClass66_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData+<>c__DisplayClass68_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData+<>c__DisplayClass68_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SaveData+<>c__DisplayClass9_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Session", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Session+Counter",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Session+CoreModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Session+Slider",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Session+SerializationOnly",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Session+SerializationOnly+Slider",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.EntityID", []);
            catalog.PublishDeclaredCommandMethods("Celeste.RumbleAmount", []);
            catalog.PublishDeclaredCommandMethods("Celeste.SpeedrunType", []);
            catalog.PublishDeclaredCommandMethods("Celeste.ScreenshakeAmount",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GrabModes", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrouchDashModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Settings", [
                new SourceCommandMethodFacts(100674906, "Settings", "Initialize", [],
                    [], []),
                new SourceCommandMethodFacts(100674907, "Settings", "Reload", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100674948, "Settings", "orig_Initialize", [],
                    [], []),
                new SourceCommandMethodFacts(100674950, "Settings", "TranslateKeys", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Assists", [
                new SourceCommandMethodFacts(100674951, "Assists", "get_Default", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Assists+DashModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StaminaDisplay",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ExitBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.MovingPlatform",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.MovingPlatformLine",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.RotatingPlatform",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.HangingLamp", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CameraOffsetTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CameraTargetTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.RespawnTargetTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DustRotateSpinner",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TriggerSpikes", [
                new SourceCommandMethodFacts(100675004, "TriggerSpikes", "GetSize", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.TriggerSpikes+Directions",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TriggerSpikes+SpikeInfo",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DashBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DashBlock+Modes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.InvisibleBarrier",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Key", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Key+<NodeRoutine>d__26",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Key+<>c__DisplayClass28_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Key+<UseRoutine>d__28",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.LockBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LockBlock+<UnlockRoutine>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.NegaBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberrySeed",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberrySeed+<ReturnRoutine>d__30",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberrySeed+<>c__DisplayClass32_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberrySeed+<>c__DisplayClass33_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StrawberrySeed+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SinkingPlatform",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.SinkingPlatformLine",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ChaserBarrier", []);
            catalog.PublishDeclaredCommandMethods("Celeste.BloomPoint", []);
            catalog.PublishDeclaredCommandMethods("Celeste.EffectCutout", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Follower", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Leader", [
                new SourceCommandMethodFacts(100675145, "Leader", "StoreStrawberries", [],
                    [], []),
                new SourceCommandMethodFacts(100675146, "Leader", "RestoreStrawberries", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.LightOcclude", []);
            catalog.PublishDeclaredCommandMethods("Celeste.StaticMover", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Switch", [
                new SourceCommandMethodFacts(100675179, "Switch", "Check", [], [],
                    []),
                new SourceCommandMethodFacts(100675180, "Switch", "FinishedCheck", [],
                    [], []),
                new SourceCommandMethodFacts(100675181, "Switch", "CheckLevelFlag", [],
                    [], []),
                new SourceCommandMethodFacts(100675182, "Switch", "SetLevelFlag", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform+<Sequence>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform+<OutlineFade>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform+<TileOut>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumblePlatform+<TileIn>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DreamBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DreamBlock+DreamParticle",
                []);
        }
    }
}
