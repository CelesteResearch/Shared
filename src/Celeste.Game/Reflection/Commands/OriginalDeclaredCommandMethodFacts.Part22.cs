using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart22(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Celeste.Spikes", [
                new SourceCommandMethodFacts(100670131, "Spikes", "GetSize", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Spikes+Directions",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Spring", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Spring+Orientations",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Strawberry", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Strawberry+<>c__DisplayClass44_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Strawberry+<FlyAwayRoutine>d__46",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Strawberry+<CollectRoutine>d__47",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Strawberry+<>c__DisplayClass48_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.JumpthruPlatform",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ZipMover", []);
            catalog.PublishDeclaredCommandMethods("Celeste.ZipMover+Themes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ZipMover+ZipMoverPathRenderer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ZipMover+<Sequence>d__24",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Backdrop", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Backdrop+Fader",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Backdrop+Fader+Segment",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BackgroundTiles",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.TheoCrystal", []);
            catalog.PublishDeclaredCommandMethods("Celeste.TheoCrystal+<Shatter>d__22",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GFX", [
                new SourceCommandMethodFacts(100670218, "GFX", "get_Loaded", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670219, "GFX", "set_Loaded", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670220, "GFX", "get_DataLoaded", [],
                    [], []),
                new SourceCommandMethodFacts(100670221, "GFX", "set_DataLoaded", [],
                    [], []),
                new SourceCommandMethodFacts(100670222, "GFX", "Load", [], [],
                    []),
                new SourceCommandMethodFacts(100670223, "GFX", "LoadData", [], [],
                    []),
                new SourceCommandMethodFacts(100670224, "GFX", "Unload", [], [],
                    []),
                new SourceCommandMethodFacts(100670225, "GFX", "UnloadData", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670226, "GFX", "LoadEffects", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670227, "GFX", "LoadFx", [], [],
                    []),
                new SourceCommandMethodFacts(100670228, "GFX", "DrawVertices", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670229, "GFX", "DrawIndexedVertices", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Input", [
                new SourceCommandMethodFacts(100670231, "Input", "get_Gamepad", [],
                    [], []),
                new SourceCommandMethodFacts(100670232, "Input", "set_Gamepad", [],
                    [], []),
                new SourceCommandMethodFacts(100670233, "Input", "Initialize", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670234, "Input", "Deregister", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670235, "Input", "AnyGamepadConfirmPressed", [],
                    [], []),
                new SourceCommandMethodFacts(100670236, "Input", "Rumble", [], [],
                    []),
                new SourceCommandMethodFacts(100670237, "Input", "RumbleSpecific", [],
                    [], []),
                new SourceCommandMethodFacts(100670238, "Input", "get_GrabCheck", [],
                    [], []),
                new SourceCommandMethodFacts(100670239, "Input", "get_DashPressed", [],
                    [], []),
                new SourceCommandMethodFacts(100670240, "Input", "get_CrouchDashPressed", [],
                    [], []),
                new SourceCommandMethodFacts(100670241, "Input", "UpdateGrab", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670242, "Input", "ResetGrab", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670243, "Input", "GetAimVector", [],
                    [], []),
                new SourceCommandMethodFacts(100670244, "Input", "GuiInputPrefix", [],
                    [], []),
                new SourceCommandMethodFacts(100670245, "Input", "GuiInputController", [],
                    [], []),
                new SourceCommandMethodFacts(100670246, "Input", "GuiButton", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670247, "Input", "GuiSingleButton", [],
                    [], []),
                new SourceCommandMethodFacts(100670248, "Input", "GuiKey", [], [],
                    []),
                new SourceCommandMethodFacts(100670249, "Input", "FirstButton", [],
                    [], []),
                new SourceCommandMethodFacts(100670250, "Input", "FirstKey", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670251, "Input", "GuiDirection", [],
                    [], []),
                new SourceCommandMethodFacts(100670252, "Input", "GuiTexture", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100670253, "Input", "SetLightbarColor", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Input+PrefixMode",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.RumbleStrength",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.RumbleLength", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Distort", [
                new SourceCommandMethodFacts(100670255, "Distort", "get_AnxietyOrigin", [],
                    [], []),
                new SourceCommandMethodFacts(100670256, "Distort", "set_AnxietyOrigin", [],
                    [], []),
                new SourceCommandMethodFacts(100670257, "Distort", "get_Anxiety", [],
                    [], []),
                new SourceCommandMethodFacts(100670258, "Distort", "set_Anxiety", [],
                    [], []),
                new SourceCommandMethodFacts(100670259, "Distort", "get_GameRate", [],
                    [], []),
                new SourceCommandMethodFacts(100670260, "Distort", "set_GameRate", [],
                    [], []),
                new SourceCommandMethodFacts(100670261, "Distort", "get_WaterSine", [],
                    [], []),
                new SourceCommandMethodFacts(100670262, "Distort", "set_WaterSine", [],
                    [], []),
                new SourceCommandMethodFacts(100670263, "Distort", "get_WaterCameraY", [],
                    [], []),
                new SourceCommandMethodFacts(100670264, "Distort", "set_WaterCameraY", [],
                    [], []),
                new SourceCommandMethodFacts(100670265, "Distort", "get_WaterAlpha", [],
                    [], []),
                new SourceCommandMethodFacts(100670266, "Distort", "set_WaterAlpha", [],
                    [], []),
                new SourceCommandMethodFacts(100670267, "Distort", "Render", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.GaussianBlur", [
                new SourceCommandMethodFacts(100670269, "GaussianBlur", "Blur", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.GaussianBlur+Samples",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GaussianBlur+Direction",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Hahaha", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Hahaha+Ha", []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerHair", []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerSpriteMode",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerSprite", [
                new SourceCommandMethodFacts(100670295, "PlayerSprite", "CreateFramesMetadata", [],
                    [], []),
                new SourceCommandMethodFacts(100670296, "PlayerSprite", "ClearFramesMetadata", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.PlayerAnimMetadata",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BloomRenderer", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DisplacementRenderer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.DisplacementRenderer+Burst",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BackdropRenderer",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BackdropRenderer+<GetEach>d__9`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BackdropRenderer+<GetEach>d__10`1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.ScreenWipe", [
                new SourceCommandMethodFacts(100670327, "ScreenWipe", "DrawPrimitives", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.ScreenWipe+<Wait>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Snow", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Snow+Particle", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Parallax", []);
            catalog.PublishDeclaredCommandMethods("Celeste.ChimneySmokeFx", [
                new SourceCommandMethodFacts(100670337, "ChimneySmokeFx", "Burst", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.Dust", [
                new SourceCommandMethodFacts(100670339, "Dust", "Burst", [], [],
                    []),
                new SourceCommandMethodFacts(100670340, "Dust", "BurstFG", [], [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.MapData", []);
            catalog.PublishDeclaredCommandMethods("Celeste.EntityData", []);
            catalog.PublishDeclaredCommandMethods("Celeste.DecalData", []);
            catalog.PublishDeclaredCommandMethods("Celeste.LevelData", []);
            catalog.PublishDeclaredCommandMethods("Celeste.VertexLight", []);
            catalog.PublishDeclaredCommandMethods("Celeste.VertexLight+<>c__DisplayClass39_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.VertexLight+<>c__DisplayClass40_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.VertexLight+<>c__DisplayClass41_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+CameraLockModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+ConditionBlockModes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass126_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<TransitionRoutine>d__126",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<SavingRoutine>d__141",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_1",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_2",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_3",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_4",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass149_5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass150_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass151_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<SaveFromOptions>d__152",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass153_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass154_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<ZoomTo>d__162",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<ZoomAcross>d__163",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<ZoomBack>d__164",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<SkipCutsceneRoutine>d__181",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Level+<>c__DisplayClass183_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.Facings", []);
        }
    }
}
