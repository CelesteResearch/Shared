using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Reflection.Commands
{
    public static partial class InstalledDeclaredCommandMethodFacts
    {
        private static void RegisterPart3(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Monocle.ColliderList", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Grid", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100664841, "Grid", "IsBitstringEmpty", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Hitbox", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Component", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.GraphicsComponent",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Image", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.PixelText", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.PixelText+Char",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Sprite", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Sprite+Animation",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Sprite+<PlayUtil>d__40",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Spritesheet`1", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Spritesheet`1+Animation",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.NumberText", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.OutlineText", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Text", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Text+HorizontalAlign",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Text+VerticalAlign",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.TimerText", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.TimerText+CountModes",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.TimerText+TimerModes",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.TileGrid", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Alarm", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665064, "Alarm", "Create", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665065, "Alarm", "Set", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Alarm+AlarmMode",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Coroutine", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.CoroutineHolder", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665089, "CoroutineHolder", "WaitForFrames", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.CoroutineHolder+CoroutineData",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.CoroutineHolder+<WaitForFrames>d__8",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.CounterSet`1", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Shaker", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.ShakerList", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.SineWave", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.StateMachine", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665142, "StateMachine", "op_Implicit", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.StateMachine+<>c__DisplayClass9_0`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Tween", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665170, "Tween", "Create", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665171, "Tween", "Set", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665172, "Tween", "Position", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Tween+TweenMode",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Tween+<>c__DisplayClass35_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Tween+<Wait>d__45",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Wiggler", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665198, "Wiggler", "Create", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Engine", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665208, "Engine", "get_Instance", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665209, "Engine", "set_Instance", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665210, "Engine", "get_Graphics", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665211, "Engine", "set_Graphics", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665212, "Engine", "get_Commands", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665213, "Engine", "set_Commands", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665214, "Engine", "get_Pooler", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665215, "Engine", "set_Pooler", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665216, "Engine", "get_Width", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665217, "Engine", "set_Width", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665218, "Engine", "get_Height", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665219, "Engine", "set_Height", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665220, "Engine", "get_ViewWidth", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665221, "Engine", "set_ViewWidth", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665222, "Engine", "get_ViewHeight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665223, "Engine", "set_ViewHeight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665224, "Engine", "get_ViewPadding", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665225, "Engine", "set_ViewPadding", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665226, "Engine", "get_DeltaTime", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665227, "Engine", "set_DeltaTime", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665228, "Engine", "get_RawDeltaTime", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665229, "Engine", "set_RawDeltaTime", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665230, "Engine", "get_FrameCounter", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665231, "Engine", "set_FrameCounter", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665232, "Engine", "get_ContentDirectory", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665248, "Engine", "get_Scene", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665249, "Engine", "set_Scene", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665250, "Engine", "get_Viewport", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665251, "Engine", "set_Viewport", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665252, "Engine", "SetWindowed", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665253, "Engine", "SetFullscreen", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665256, "Engine", "orig_get_ViewWidth", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665257, "Engine", "orig_set_ViewWidth", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665258, "Engine", "orig_get_ViewHeight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665259, "Engine", "orig_set_ViewHeight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665260, "Engine", "orig_get_Viewport", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665261, "Engine", "orig_set_Viewport", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665262, "Engine", "get_NextScene", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665263, "Engine", "SetViewWidth", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665264, "Engine", "SetViewHeight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665265, "Engine", "SetViewport", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665266, "Engine", "GetTimeRateComponentMultiplier",
                    Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665267, "Engine", "orig_ctor_Engine", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Engine+<>c", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Entity", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Atlas", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665401, "Atlas", "FromAtlas", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665402, "Atlas", "ReadAtlasData", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665403, "Atlas", "FromMultiAtlas", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665404, "Atlas", "FromMultiAtlas", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665405, "Atlas", "FromDirectory", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665418, "Atlas", "orig_FromAtlas", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665419, "Atlas", "orig_FromMultiAtlas", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665420, "Atlas", "orig_FromMultiAtlas", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665421, "Atlas", "orig_FromDirectory", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Atlas+AtlasDataFormat",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.MTexture", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteBank", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665536, "SpriteBank", "LoadSpriteBank", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665537, "SpriteBank", "GetSpriteBankExcludingVanillaCopyPastes",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665538, "SpriteBank", "xmlNodesAreIdentical", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665539, "SpriteBank", "getChildElements", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteBank+<>c",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteBank+<>c__DisplayClass5_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteDataSource",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.SpriteData", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Tileset", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.MInput", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665562, "MInput", "get_Keyboard", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665563, "MInput", "set_Keyboard", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665564, "MInput", "get_Mouse", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665565, "MInput", "set_Mouse", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665566, "MInput", "get_GamePads", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665567, "MInput", "set_GamePads", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665568, "MInput", "Initialize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665569, "MInput", "Shutdown", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665570, "MInput", "Update", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665571, "MInput", "UpdateNull", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665572, "MInput", "UpdateVirtualInputs", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665573, "MInput", "RumbleFirst", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665574, "MInput", "Axis", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665575, "MInput", "Axis", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665576, "MInput", "Axis", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665578, "MInput", "orig_get_Mouse", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665579, "MInput", "orig_set_Mouse", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100665580, "MInput", "orig_UpdateVirtualInputs", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.MInput+KeyboardData",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.MInput+MouseData",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.MInput+MouseData+MouseButtons",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.MInput+GamePadData",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665707, "VirtualButton", "op_Implicit", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+Node",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+KeyboardKey",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadButton",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftStickRight",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftStickLeft",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftStickUp",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftStickDown",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightStickRight",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightStickLeft",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightStickUp",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightStickDown",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadLeftTrigger",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadRightTrigger",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadDPadRight",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadDPadLeft",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadDPadUp",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+PadDPadDown",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+MouseLeftButton",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+MouseRightButton",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+MouseMiddleButton",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+VirtualAxisTrigger",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+VirtualAxisTrigger+Modes",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualButton+VirtualIntegerAxisTrigger",
                Array.Empty<ISourceCommandMethodMetadata>());
        }
    }
}
