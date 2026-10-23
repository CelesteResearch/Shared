using System;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Commands
{
    public static partial class OriginalDeclaredCommandMethodFacts
    {
        private static void RegisterPart4(SceneEntityCatalog catalog)
        {
            catalog.PublishDeclaredCommandMethods("Monocle.ChoiceSet`1+Choice",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Chooser`1", [
                new SourceCommandMethodFacts(100665991, "Chooser`1", "FromString", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Chooser`1+Choice",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Commands", [
                new SourceCommandMethodFacts(100666010, "Commands", "ArgString", [],
                    [], []),
                new SourceCommandMethodFacts(100666011, "Commands", "ArgBool", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666012, "Commands", "ArgInt", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666013, "Commands", "ArgFloat", [],
                    [], []),
                new SourceCommandMethodFacts(100666014, "Commands", "Clear", ["clear"],
                    ["Clears the terminal"], []),
                new SourceCommandMethodFacts(100666015, "Commands", "Exit", ["exit"],
                    ["Exits the game"], []),
                new SourceCommandMethodFacts(100666016, "Commands", "Vsync", ["vsync"],
                    ["Enables or disables vertical sync"],
                    [new("enabled", "System.Boolean", true)]),
                new SourceCommandMethodFacts(100666017, "Commands", "Count", ["count"],
                    [
                        "Logs amount of Entities in the Scene. Pass a tagIndex to count only Entities with that tag",
                    ],
                    [new("tagIndex", "System.Int32", -1)]),
                new SourceCommandMethodFacts(100666018, "Commands", "Tracker", ["tracker"],
                    [
                        "Logs all tracked objects in the scene. Set mode to 'e' for just entities, or 'c' for just components",
                    ],
                    [new("mode", "System.String", DBNull.Value)]),
                new SourceCommandMethodFacts(100666019, "Commands", "Pooler", ["pooler"],
                    ["Logs the pooled Entity counts"], []),
                new SourceCommandMethodFacts(100666020, "Commands", "Fullscreen", ["fullscreen"],
                    ["Switches to fullscreen mode"], []),
                new SourceCommandMethodFacts(100666021, "Commands", "Window", ["window"],
                    ["Switches to window mode"],
                    [new("scale", "System.Int32", 1)]),
                new SourceCommandMethodFacts(100666022, "Commands", "Help", ["help"],
                    ["Shows usage help for a given command"],
                    [new("command", "System.String", DBNull.Value)]),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Commands+CommandInfo",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Commands+Line", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Commands+<>c__DisplayClass38_0",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Commands+<>c__DisplayClass38_1",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Command", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Draw", [
                new SourceCommandMethodFacts(100666024, "Draw", "get_Renderer", [],
                    [], []),
                new SourceCommandMethodFacts(100666025, "Draw", "set_Renderer", [],
                    [], []),
                new SourceCommandMethodFacts(100666026, "Draw", "get_SpriteBatch", [],
                    [], []),
                new SourceCommandMethodFacts(100666027, "Draw", "set_SpriteBatch", [],
                    [], []),
                new SourceCommandMethodFacts(100666028, "Draw", "get_DefaultFont", [],
                    [], []),
                new SourceCommandMethodFacts(100666029, "Draw", "set_DefaultFont", [],
                    [], []),
                new SourceCommandMethodFacts(100666030, "Draw", "Initialize", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666031, "Draw", "UseDebugPixelTexture", [],
                    [], []),
                new SourceCommandMethodFacts(100666032, "Draw", "Point", [], [],
                    []),
                new SourceCommandMethodFacts(100666033, "Draw", "Line", [], [],
                    []),
                new SourceCommandMethodFacts(100666034, "Draw", "Line", [], [],
                    []),
                new SourceCommandMethodFacts(100666035, "Draw", "Line", [], [],
                    []),
                new SourceCommandMethodFacts(100666036, "Draw", "Line", [], [],
                    []),
                new SourceCommandMethodFacts(100666037, "Draw", "LineAngle", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666038, "Draw", "LineAngle", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666039, "Draw", "LineAngle", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666040, "Draw", "Circle", [], [],
                    []),
                new SourceCommandMethodFacts(100666041, "Draw", "Circle", [], [],
                    []),
                new SourceCommandMethodFacts(100666042, "Draw", "Circle", [], [],
                    []),
                new SourceCommandMethodFacts(100666043, "Draw", "Circle", [], [],
                    []),
                new SourceCommandMethodFacts(100666044, "Draw", "Rect", [], [],
                    []),
                new SourceCommandMethodFacts(100666045, "Draw", "Rect", [], [],
                    []),
                new SourceCommandMethodFacts(100666046, "Draw", "Rect", [], [],
                    []),
                new SourceCommandMethodFacts(100666047, "Draw", "Rect", [], [],
                    []),
                new SourceCommandMethodFacts(100666048, "Draw", "HollowRect", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666049, "Draw", "HollowRect", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666050, "Draw", "HollowRect", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666051, "Draw", "HollowRect", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666052, "Draw", "Text", [], [],
                    []),
                new SourceCommandMethodFacts(100666053, "Draw", "Text", [], [],
                    []),
                new SourceCommandMethodFacts(100666054, "Draw", "TextJustified", [],
                    [], []),
                new SourceCommandMethodFacts(100666055, "Draw", "TextJustified", [],
                    [], []),
                new SourceCommandMethodFacts(100666056, "Draw", "TextCentered", [],
                    [], []),
                new SourceCommandMethodFacts(100666057, "Draw", "TextCentered", [],
                    [], []),
                new SourceCommandMethodFacts(100666058, "Draw", "TextCentered", [],
                    [], []),
                new SourceCommandMethodFacts(100666059, "Draw", "TextCentered", [],
                    [], []),
                new SourceCommandMethodFacts(100666060, "Draw", "OutlineTextCentered", [],
                    [], []),
                new SourceCommandMethodFacts(100666061, "Draw", "OutlineTextCentered", [],
                    [], []),
                new SourceCommandMethodFacts(100666062, "Draw", "OutlineTextCentered", [],
                    [], []),
                new SourceCommandMethodFacts(100666063, "Draw", "OutlineTextJustify", [],
                    [], []),
                new SourceCommandMethodFacts(100666064, "Draw", "OutlineTextJustify", [],
                    [], []),
                new SourceCommandMethodFacts(100666065, "Draw", "SineTextureH", [],
                    [], []),
                new SourceCommandMethodFacts(100666066, "Draw", "SineTextureV", [],
                    [], []),
                new SourceCommandMethodFacts(100666067, "Draw", "TextureBannerV", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Ease", [
                new SourceCommandMethodFacts(100666068, "Ease", "Invert", [], [],
                    []),
                new SourceCommandMethodFacts(100666069, "Ease", "Follow", [], [],
                    []),
                new SourceCommandMethodFacts(100666070, "Ease", "UpDown", [], [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Ease+Easer", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Ease+<>c__DisplayClass35_0",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Ease+<>c__DisplayClass36_0",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Ease+<>c", []);
            catalog.PublishDeclaredCommandMethods("Monocle.ErrorLog", [
                new SourceCommandMethodFacts(100666072, "ErrorLog", "Write", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666073, "ErrorLog", "Write", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666074, "ErrorLog", "Open", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.MethodHandle`1",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.PixelFontCharacter",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.PixelFontSize", []);
            catalog.PublishDeclaredCommandMethods("Monocle.PixelFont", []);
            catalog.PublishDeclaredCommandMethods("Monocle.PixelFont+<>c", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Pnt", [
                new SourceCommandMethodFacts(100666104, "Pnt", "op_Equality", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666105, "Pnt", "op_Inequality", [],
                    [], []),
                new SourceCommandMethodFacts(100666106, "Pnt", "op_Addition", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666107, "Pnt", "op_Subtraction", [],
                    [], []),
                new SourceCommandMethodFacts(100666108, "Pnt", "op_Multiply", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666109, "Pnt", "op_Division", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666110, "Pnt", "op_Modulus", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666111, "Pnt", "op_Equality", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666112, "Pnt", "op_Inequality", [],
                    [], []),
                new SourceCommandMethodFacts(100666113, "Pnt", "op_Addition", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666114, "Pnt", "op_Subtraction", [],
                    [], []),
                new SourceCommandMethodFacts(100666115, "Pnt", "op_Multiply", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666116, "Pnt", "op_Division", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666117, "Pnt", "op_Modulus", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Pooler", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Pooled", []);
            catalog.PublishDeclaredCommandMethods("Monocle.SaveLoad", [
                new SourceCommandMethodFacts(100666129, "SaveLoad", "SerializeToFile", [],
                    [], []),
                new SourceCommandMethodFacts(100666130, "SaveLoad", "SafeSerializeToFile", [],
                    [], []),
                new SourceCommandMethodFacts(100666131, "SaveLoad", "DeserializeFromFile", [],
                    [], []),
                new SourceCommandMethodFacts(100666132, "SaveLoad", "SafeDeserializeFromFile", [],
                    [], []),
                new SourceCommandMethodFacts(100666133, "SaveLoad", "SafeDeserializeFromFile", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.SaveLoad+SerializeModes",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.SimpleCurve", []);
            catalog.PublishDeclaredCommandMethods("Monocle.SpecEntity`1", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Tiler", [
                new SourceCommandMethodFacts(100666148, "Tiler", "Tile", [], [],
                    []),
                new SourceCommandMethodFacts(100666149, "Tiler", "Tile", [], [],
                    []),
                new SourceCommandMethodFacts(100666150, "Tiler", "Tile", [], [],
                    []),
                new SourceCommandMethodFacts(100666151, "Tiler", "Tile", [], [],
                    []),
                new SourceCommandMethodFacts(100666152, "Tiler", "get_TileX", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666153, "Tiler", "set_TileX", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666154, "Tiler", "get_TileY", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666155, "Tiler", "set_TileY", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666156, "Tiler", "get_Left", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666157, "Tiler", "set_Left", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666158, "Tiler", "get_Right", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666159, "Tiler", "set_Right", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666160, "Tiler", "get_Up", [], [],
                    []),
                new SourceCommandMethodFacts(100666161, "Tiler", "set_Up", [], [],
                    []),
                new SourceCommandMethodFacts(100666162, "Tiler", "get_Down", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666163, "Tiler", "set_Down", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666164, "Tiler", "get_UpLeft", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666165, "Tiler", "set_UpLeft", [],
                    [],
                    []),
                new SourceCommandMethodFacts(100666166, "Tiler", "get_UpRight", [],
                    [], []),
                new SourceCommandMethodFacts(100666167, "Tiler", "set_UpRight", [],
                    [], []),
                new SourceCommandMethodFacts(100666168, "Tiler", "get_DownLeft", [],
                    [], []),
                new SourceCommandMethodFacts(100666169, "Tiler", "set_DownLeft", [],
                    [], []),
                new SourceCommandMethodFacts(100666170, "Tiler", "get_DownRight", [],
                    [], []),
                new SourceCommandMethodFacts(100666171, "Tiler", "set_DownRight", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Tiler+EdgeBehavior",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.AutotileData", []);
            catalog.PublishDeclaredCommandMethods("Monocle.Tracker", [
                new SourceCommandMethodFacts(100666175, "Tracker", "get_TrackedEntityTypes", [],
                    [], []),
                new SourceCommandMethodFacts(100666176, "Tracker", "set_TrackedEntityTypes", [],
                    [], []),
                new SourceCommandMethodFacts(100666177, "Tracker", "get_TrackedComponentTypes", [],
                    [], []),
                new SourceCommandMethodFacts(100666178, "Tracker", "set_TrackedComponentTypes", [],
                    [], []),
                new SourceCommandMethodFacts(100666179, "Tracker", "get_StoredEntityTypes", [],
                    [], []),
                new SourceCommandMethodFacts(100666180, "Tracker", "set_StoredEntityTypes", [],
                    [], []),
                new SourceCommandMethodFacts(100666181, "Tracker", "get_StoredComponentTypes", [],
                    [], []),
                new SourceCommandMethodFacts(100666182, "Tracker", "set_StoredComponentTypes", [],
                    [], []),
                new SourceCommandMethodFacts(100666183, "Tracker", "Initialize", [],
                    [], []),
                new SourceCommandMethodFacts(100666184, "Tracker", "GetSubclasses", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.Tracker+<EnumerateEntities>d__33`1",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Tracker+<EnumerateComponents>d__39`1",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.Tracked", []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualAsset", []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualTexture",
                []);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualRenderTarget", [
                new SourceCommandMethodFacts(100666240, "VirtualRenderTarget", "op_Implicit", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualContent", [
                new SourceCommandMethodFacts(100666241, "VirtualContent", "get_Count", [],
                    [], []),
                new SourceCommandMethodFacts(100666242, "VirtualContent", "CreateTexture", [],
                    [], []),
                new SourceCommandMethodFacts(100666243, "VirtualContent", "CreateTexture", [],
                    [], []),
                new SourceCommandMethodFacts(100666244, "VirtualContent", "CreateRenderTarget", [],
                    [], []),
                new SourceCommandMethodFacts(100666245, "VirtualContent", "BySize", [],
                    [], []),
                new SourceCommandMethodFacts(100666246, "VirtualContent", "ByName", [],
                    [], []),
                new SourceCommandMethodFacts(100666247, "VirtualContent", "Remove", [],
                    [], []),
                new SourceCommandMethodFacts(100666248, "VirtualContent", "Reload", [],
                    [], []),
                new SourceCommandMethodFacts(100666249, "VirtualContent", "Unload", [],
                    [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualMap`1", []);
            catalog.PublishDeclaredCommandMethods("Celeste.Language", [
                new SourceCommandMethodFacts(100666267, "Language", "FromExport", [],
                    [], []),
                new SourceCommandMethodFacts(100666268, "Language", "FromTxt", [],
                    [],
                    []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.DisconnectedControllerUI", [
                new SourceCommandMethodFacts(100666276, "DisconnectedControllerUI", "IsGamepadConnected",
                    [], [], []),
                new SourceCommandMethodFacts(100666277, "DisconnectedControllerUI", "RequiresGamepad",
                    [], [], []),
                new SourceCommandMethodFacts(100666278, "DisconnectedControllerUI", "CheckGamepadDisconnect",
                    [], [], []),
            ]);
            catalog.PublishDeclaredCommandMethods("Celeste.BounceBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.BounceBlock+States",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BounceBlock+RespawnDebris",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.BounceBlock+BreakDebris",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CassetteBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CassetteBlock+Modes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CassetteBlock+BoxSide",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CassetteBlockManager",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.FloatySpaceBlock",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<Cutscene>d__9",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<WaitForGranny>d__10",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<Laugh>d__11",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<StopLaughing>d__12",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<StepForward>d__13",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<GrannyDisappear>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<FadeToWhite>d__15",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<DoFadeToWhite>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch+<Cutscene>d__14",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch+<>c__DisplayClass15_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch+<WaveCamera>d__16",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch+<BirdRoutine>d__17",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalRoom",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalRoom+<Cutscene>d__5",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalRoom+<BadelineAppears>d__6",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalRoom+<BadelineVanishes>d__7",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StarRotateSpinner",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.StarTrackSpinner",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrumbleWallOnRumble",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+Axes",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+MoveState",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+<>c__DisplayClass39_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+<>c__DisplayClass41_0",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+<AttackSequence>d__41",
                []);
            catalog.PublishDeclaredCommandMethods("Celeste.GlassBlock", []);
            catalog.PublishDeclaredCommandMethods("Celeste.GlassBlock+Line",
                []);
        }
    }
}
