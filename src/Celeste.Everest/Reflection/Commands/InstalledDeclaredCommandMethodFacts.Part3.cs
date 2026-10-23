using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart3(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Monocle.ColliderList", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Grid", [
                new SourceCommandMethodFacts(100664841, "Grid", "IsBitstringEmpty", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Hitbox", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Component", []);
            catalog.PublishDeclaredCommandMethods("Monocle.GraphicsComponent",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Image", []);
            catalog.PublishDeclaredCommandMethods("Monocle.PixelText", []);
            catalog.PublishDeclaredCommandMethods("Monocle.PixelText+Char",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Sprite", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Sprite+Animation",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Sprite+<PlayUtil>d__40",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Spritesheet`1", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Spritesheet`1+Animation",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.NumberText", []);
            catalog.PublishDeclaredCommandMethods("Monocle.OutlineText", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Text", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Text+HorizontalAlign",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Text+VerticalAlign",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.TimerText", []);
            catalog.PublishDeclaredCommandMethods("Monocle.TimerText+CountModes",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.TimerText+TimerModes",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.TileGrid", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Alarm", [
                new SourceCommandMethodFacts(100665064, "Alarm", "Create", [], [],
                    []),
                new SourceCommandMethodFacts(100665065, "Alarm", "Set", [], [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Alarm+AlarmMode",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Coroutine", []);
            catalog.PublishDeclaredCommandMethods("Monocle.CoroutineHolder", [
                new SourceCommandMethodFacts(100665089, "CoroutineHolder", "WaitForFrames", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.CoroutineHolder+CoroutineData",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.CoroutineHolder+<WaitForFrames>d__8",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.CounterSet`1", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Shaker", []);
            catalog.PublishDeclaredCommandMethods("Monocle.ShakerList", []);
            catalog.PublishDeclaredCommandMethods("Monocle.SineWave", []);
            catalog.PublishDeclaredCommandMethods("Monocle.StateMachine", [
                new SourceCommandMethodFacts(100665142, "StateMachine", "op_Implicit", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.StateMachine+<>c__DisplayClass9_0`1",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Tween", [
                new SourceCommandMethodFacts(100665170, "Tween", "Create", [], [],
                    []),
                new SourceCommandMethodFacts(100665171, "Tween", "Set", [], [],
                    []),
                new SourceCommandMethodFacts(100665172, "Tween", "Position", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Tween+TweenMode",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Tween+<>c__DisplayClass35_0",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Tween+<Wait>d__45",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Wiggler", [
                new SourceCommandMethodFacts(100665198, "Wiggler", "Create", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Engine", [
                new SourceCommandMethodFacts(100665208, "Engine", "get_Instance", [],
                    [], []),
                new SourceCommandMethodFacts(100665209, "Engine", "set_Instance", [],
                    [], []),
                new SourceCommandMethodFacts(100665210, "Engine", "get_Graphics", [],
                    [], []),
                new SourceCommandMethodFacts(100665211, "Engine", "set_Graphics", [],
                    [], []),
                new SourceCommandMethodFacts(100665212, "Engine", "get_Commands", [],
                    [], []),
                new SourceCommandMethodFacts(100665213, "Engine", "set_Commands", [],
                    [], []),
                new SourceCommandMethodFacts(100665214, "Engine", "get_Pooler", [],
                    [], []),
                new SourceCommandMethodFacts(100665215, "Engine", "set_Pooler", [],
                    [], []),
                new SourceCommandMethodFacts(100665216, "Engine", "get_Width", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100665217, "Engine", "set_Width", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100665218, "Engine", "get_Height", [],
                    [], []),
                new SourceCommandMethodFacts(100665219, "Engine", "set_Height", [],
                    [], []),
                new SourceCommandMethodFacts(100665220, "Engine", "get_ViewWidth", [],
                    [], []),
                new SourceCommandMethodFacts(100665221, "Engine", "set_ViewWidth", [],
                    [], []),
                new SourceCommandMethodFacts(100665222, "Engine", "get_ViewHeight", [],
                    [], []),
                new SourceCommandMethodFacts(100665223, "Engine", "set_ViewHeight", [],
                    [], []),
                new SourceCommandMethodFacts(100665224, "Engine", "get_ViewPadding", [],
                    [], []),
                new SourceCommandMethodFacts(100665225, "Engine", "set_ViewPadding", [],
                    [], []),
                new SourceCommandMethodFacts(100665226, "Engine", "get_DeltaTime", [],
                    [], []),
                new SourceCommandMethodFacts(100665227, "Engine", "set_DeltaTime", [],
                    [], []),
                new SourceCommandMethodFacts(100665228, "Engine", "get_RawDeltaTime", [],
                    [], []),
                new SourceCommandMethodFacts(100665229, "Engine", "set_RawDeltaTime", [],
                    [], []),
                new SourceCommandMethodFacts(100665230, "Engine", "get_FrameCounter", [],
                    [], []),
                new SourceCommandMethodFacts(100665231, "Engine", "set_FrameCounter", [],
                    [], []),
                new SourceCommandMethodFacts(100665232, "Engine", "get_ContentDirectory", [],
                    [], []),
                new SourceCommandMethodFacts(100665248, "Engine", "get_Scene", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100665249, "Engine", "set_Scene", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100665250, "Engine", "get_Viewport", [],
                    [], []),
                new SourceCommandMethodFacts(100665251, "Engine", "set_Viewport", [],
                    [], []),
                new SourceCommandMethodFacts(100665252, "Engine", "SetWindowed", [],
                    [], []),
                new SourceCommandMethodFacts(100665253, "Engine", "SetFullscreen", [],
                    [], []),
                new SourceCommandMethodFacts(100665256, "Engine", "orig_get_ViewWidth", [],
                    [], []),
                new SourceCommandMethodFacts(100665257, "Engine", "orig_set_ViewWidth", [],
                    [], []),
                new SourceCommandMethodFacts(100665258, "Engine", "orig_get_ViewHeight", [],
                    [], []),
                new SourceCommandMethodFacts(100665259, "Engine", "orig_set_ViewHeight", [],
                    [], []),
                new SourceCommandMethodFacts(100665260, "Engine", "orig_get_Viewport", [],
                    [], []),
                new SourceCommandMethodFacts(100665261, "Engine", "orig_set_Viewport", [],
                    [], []),
                new SourceCommandMethodFacts(100665262, "Engine", "get_NextScene", [],
                    [], []),
                new SourceCommandMethodFacts(100665263, "Engine", "SetViewWidth", [],
                    [], []),
                new SourceCommandMethodFacts(100665264, "Engine", "SetViewHeight", [],
                    [], []),
                new SourceCommandMethodFacts(100665265, "Engine", "SetViewport", [],
                    [], []),
                new SourceCommandMethodFacts(100665266, "Engine", "GetTimeRateComponentMultiplier",
                    [],
                    [], []),
                new SourceCommandMethodFacts(100665267, "Engine", "orig_ctor_Engine", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Engine+<>c", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Entity", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Atlas", [
                new SourceCommandMethodFacts(100665401, "Atlas", "FromAtlas", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100665402, "Atlas", "ReadAtlasData", [],
                    [], []),
                new SourceCommandMethodFacts(100665403, "Atlas", "FromMultiAtlas", [],
                    [], []),
                new SourceCommandMethodFacts(100665404, "Atlas", "FromMultiAtlas", [],
                    [], []),
                new SourceCommandMethodFacts(100665405, "Atlas", "FromDirectory", [],
                    [], []),
                new SourceCommandMethodFacts(100665418, "Atlas", "orig_FromAtlas", [],
                    [], []),
                new SourceCommandMethodFacts(100665419, "Atlas", "orig_FromMultiAtlas", [],
                    [], []),
                new SourceCommandMethodFacts(100665420, "Atlas", "orig_FromMultiAtlas", [],
                    [], []),
                new SourceCommandMethodFacts(100665421, "Atlas", "orig_FromDirectory", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Atlas+AtlasDataFormat",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.MTexture", []);
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteBank", [
                new SourceCommandMethodFacts(100665536, "SpriteBank", "LoadSpriteBank", [],
                    [], []),
                new SourceCommandMethodFacts(100665537, "SpriteBank", "GetSpriteBankExcludingVanillaCopyPastes",
                    [], [], []),
                new SourceCommandMethodFacts(100665538, "SpriteBank", "xmlNodesAreIdentical", [],
                    [], []),
                new SourceCommandMethodFacts(100665539, "SpriteBank", "getChildElements", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteBank+<>c",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteBank+<>c__DisplayClass5_0",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteDataSource",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteData", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Tileset", []);
            catalog.PublishDeclaredCommandMethods("Monocle.MInput", [
                new SourceCommandMethodFacts(100665562, "MInput", "get_Keyboard", [],
                    [], []),
                new SourceCommandMethodFacts(100665563, "MInput", "set_Keyboard", [],
                    [], []),
                new SourceCommandMethodFacts(100665564, "MInput", "get_Mouse", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100665565, "MInput", "set_Mouse", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100665566, "MInput", "get_GamePads", [],
                    [], []),
                new SourceCommandMethodFacts(100665567, "MInput", "set_GamePads", [],
                    [], []),
                new SourceCommandMethodFacts(100665568, "MInput", "Initialize", [],
                    [], []),
                new SourceCommandMethodFacts(100665569, "MInput", "Shutdown", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100665570, "MInput", "Update", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100665571, "MInput", "UpdateNull", [],
                    [], []),
                new SourceCommandMethodFacts(100665572, "MInput", "UpdateVirtualInputs", [],
                    [], []),
                new SourceCommandMethodFacts(100665573, "MInput", "RumbleFirst", [],
                    [], []),
                new SourceCommandMethodFacts(100665574, "MInput", "Axis", [], [],
                    []),
                new SourceCommandMethodFacts(100665575, "MInput", "Axis", [], [],
                    []),
                new SourceCommandMethodFacts(100665576, "MInput", "Axis", [], [],
                    []),
                new SourceCommandMethodFacts(100665578, "MInput", "orig_get_Mouse", [],
                    [], []),
                new SourceCommandMethodFacts(100665579, "MInput", "orig_set_Mouse", [],
                    [], []),
                new SourceCommandMethodFacts(100665580, "MInput", "orig_UpdateVirtualInputs", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.MInput+KeyboardData",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.MInput+MouseData",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.MInput+MouseData+MouseButtons",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.MInput+GamePadData",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton", [
                new SourceCommandMethodFacts(100665707, "VirtualButton", "op_Implicit", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+Node",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+KeyboardKey",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadButton",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftStickRight",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftStickLeft",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftStickUp",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftStickDown",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightStickRight",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightStickLeft",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightStickUp",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightStickDown",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadDPadRight",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadDPadLeft",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadDPadUp",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadDPadDown",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+MouseLeftButton",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+MouseRightButton",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+MouseMiddleButton",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+VirtualAxisTrigger",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+VirtualAxisTrigger+Modes",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+VirtualIntegerAxisTrigger",
                []);
        }
    }
}
