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
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Chooser`1", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100665991, "Chooser`1", "FromString", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Chooser`1+Choice",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Commands", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666010, "Commands", "ArgString", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666011, "Commands", "ArgBool", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666012, "Commands", "ArgInt", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666013, "Commands", "ArgFloat", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666014, "Commands", "Clear", new string[] { "clear" },
                    new string[] { "Clears the terminal" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666015, "Commands", "Exit", new string[] { "exit" },
                    new string[] { "Exits the game" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666016, "Commands", "Vsync", new string[] { "vsync" },
                    new string[] { "Enables or disables vertical sync" },
                    new SourceCommandParameter[] { new SourceCommandParameter("enabled", "System.Boolean", true) }),
                new SourceCommandMethodFacts(100666017, "Commands", "Count", new string[] { "count" },
                    new string[]
                    {
                        "Logs amount of Entities in the Scene. Pass a tagIndex to count only Entities with that tag"
                    },
                    new SourceCommandParameter[] { new SourceCommandParameter("tagIndex", "System.Int32", -1) }),
                new SourceCommandMethodFacts(100666018, "Commands", "Tracker", new string[] { "tracker" },
                    new string[]
                    {
                        "Logs all tracked objects in the scene. Set mode to 'e' for just entities, or 'c' for just components"
                    },
                    new SourceCommandParameter[] { new SourceCommandParameter("mode", "System.String", DBNull.Value) }),
                new SourceCommandMethodFacts(100666019, "Commands", "Pooler", new string[] { "pooler" },
                    new string[] { "Logs the pooled Entity counts" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666020, "Commands", "Fullscreen", new string[] { "fullscreen" },
                    new string[] { "Switches to fullscreen mode" }, Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666021, "Commands", "Window", new string[] { "window" },
                    new string[] { "Switches to window mode" },
                    new SourceCommandParameter[] { new SourceCommandParameter("scale", "System.Int32", 1) }),
                new SourceCommandMethodFacts(100666022, "Commands", "Help", new string[] { "help" },
                    new string[] { "Shows usage help for a given command" },
                    new SourceCommandParameter[]
                        { new SourceCommandParameter("command", "System.String", DBNull.Value) })
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Commands+CommandInfo",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Commands+Line", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Commands+<>c__DisplayClass38_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Commands+<>c__DisplayClass38_1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Command", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Draw", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666024, "Draw", "get_Renderer", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666025, "Draw", "set_Renderer", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666026, "Draw", "get_SpriteBatch", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666027, "Draw", "set_SpriteBatch", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666028, "Draw", "get_DefaultFont", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666029, "Draw", "set_DefaultFont", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666030, "Draw", "Initialize", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666031, "Draw", "UseDebugPixelTexture", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666032, "Draw", "Point", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666033, "Draw", "Line", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666034, "Draw", "Line", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666035, "Draw", "Line", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666036, "Draw", "Line", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666037, "Draw", "LineAngle", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666038, "Draw", "LineAngle", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666039, "Draw", "LineAngle", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666040, "Draw", "Circle", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666041, "Draw", "Circle", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666042, "Draw", "Circle", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666043, "Draw", "Circle", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666044, "Draw", "Rect", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666045, "Draw", "Rect", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666046, "Draw", "Rect", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666047, "Draw", "Rect", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666048, "Draw", "HollowRect", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666049, "Draw", "HollowRect", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666050, "Draw", "HollowRect", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666051, "Draw", "HollowRect", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666052, "Draw", "Text", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666053, "Draw", "Text", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666054, "Draw", "TextJustified", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666055, "Draw", "TextJustified", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666056, "Draw", "TextCentered", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666057, "Draw", "TextCentered", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666058, "Draw", "TextCentered", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666059, "Draw", "TextCentered", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666060, "Draw", "OutlineTextCentered", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666061, "Draw", "OutlineTextCentered", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666062, "Draw", "OutlineTextCentered", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666063, "Draw", "OutlineTextJustify", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666064, "Draw", "OutlineTextJustify", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666065, "Draw", "SineTextureH", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666066, "Draw", "SineTextureV", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666067, "Draw", "TextureBannerV", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Ease", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666068, "Ease", "Invert", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666069, "Ease", "Follow", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666070, "Ease", "UpDown", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Ease+Easer", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Ease+<>c__DisplayClass35_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Ease+<>c__DisplayClass36_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Ease+<>c", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.ErrorLog", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666072, "ErrorLog", "Write", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666073, "ErrorLog", "Write", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666074, "ErrorLog", "Open", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.MethodHandle`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.PixelFontCharacter",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.PixelFontSize", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.PixelFont", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.PixelFont+<>c", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Pnt", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666104, "Pnt", "op_Equality", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666105, "Pnt", "op_Inequality", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666106, "Pnt", "op_Addition", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666107, "Pnt", "op_Subtraction", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666108, "Pnt", "op_Multiply", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666109, "Pnt", "op_Division", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666110, "Pnt", "op_Modulus", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666111, "Pnt", "op_Equality", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666112, "Pnt", "op_Inequality", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666113, "Pnt", "op_Addition", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666114, "Pnt", "op_Subtraction", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666115, "Pnt", "op_Multiply", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666116, "Pnt", "op_Division", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666117, "Pnt", "op_Modulus", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Pooler", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Pooled", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.SaveLoad", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666129, "SaveLoad", "SerializeToFile", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666130, "SaveLoad", "SafeSerializeToFile", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666131, "SaveLoad", "DeserializeFromFile", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666132, "SaveLoad", "SafeDeserializeFromFile", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666133, "SaveLoad", "SafeDeserializeFromFile", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.SaveLoad+SerializeModes",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.SimpleCurve", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.SpecEntity`1", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Tiler", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666148, "Tiler", "Tile", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666149, "Tiler", "Tile", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666150, "Tiler", "Tile", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666151, "Tiler", "Tile", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666152, "Tiler", "get_TileX", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666153, "Tiler", "set_TileX", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666154, "Tiler", "get_TileY", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666155, "Tiler", "set_TileY", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666156, "Tiler", "get_Left", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666157, "Tiler", "set_Left", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666158, "Tiler", "get_Right", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666159, "Tiler", "set_Right", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666160, "Tiler", "get_Up", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666161, "Tiler", "set_Up", Array.Empty<string>(), Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666162, "Tiler", "get_Down", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666163, "Tiler", "set_Down", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666164, "Tiler", "get_UpLeft", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666165, "Tiler", "set_UpLeft", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666166, "Tiler", "get_UpRight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666167, "Tiler", "set_UpRight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666168, "Tiler", "get_DownLeft", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666169, "Tiler", "set_DownLeft", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666170, "Tiler", "get_DownRight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666171, "Tiler", "set_DownRight", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Tiler+EdgeBehavior",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.AutotileData", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Tracker", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666175, "Tracker", "get_TrackedEntityTypes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666176, "Tracker", "set_TrackedEntityTypes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666177, "Tracker", "get_TrackedComponentTypes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666178, "Tracker", "set_TrackedComponentTypes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666179, "Tracker", "get_StoredEntityTypes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666180, "Tracker", "set_StoredEntityTypes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666181, "Tracker", "get_StoredComponentTypes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666182, "Tracker", "set_StoredComponentTypes", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666183, "Tracker", "Initialize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666184, "Tracker", "GetSubclasses", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.Tracker+<EnumerateEntities>d__33`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Tracker+<EnumerateComponents>d__39`1",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.Tracked", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualAsset", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualTexture",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualRenderTarget", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666240, "VirtualRenderTarget", "op_Implicit", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualContent", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666241, "VirtualContent", "get_Count", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666242, "VirtualContent", "CreateTexture", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666243, "VirtualContent", "CreateTexture", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666244, "VirtualContent", "CreateRenderTarget", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666245, "VirtualContent", "BySize", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666246, "VirtualContent", "ByName", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666247, "VirtualContent", "Remove", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666248, "VirtualContent", "Reload", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666249, "VirtualContent", "Unload", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Monocle.VirtualMap`1", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.Language", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666267, "Language", "FromExport", Array.Empty<string>(),
                    Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666268, "Language", "FromTxt", Array.Empty<string>(),
                    Array.Empty<string>(),
                    Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.DisconnectedControllerUI", new ISourceCommandMethodMetadata[]
            {
                new SourceCommandMethodFacts(100666276, "DisconnectedControllerUI", "IsGamepadConnected",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666277, "DisconnectedControllerUI", "RequiresGamepad",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>()),
                new SourceCommandMethodFacts(100666278, "DisconnectedControllerUI", "CheckGamepadDisconnect",
                    Array.Empty<string>(), Array.Empty<string>(), Array.Empty<SourceCommandParameter>())
            });
            catalog.PublishDeclaredCommandMethods("Celeste.BounceBlock", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.BounceBlock+States",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.BounceBlock+RespawnDebris",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.BounceBlock+BreakDebris",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CassetteBlock", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CassetteBlock+Modes",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CassetteBlock+BoxSide",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CassetteBlockManager",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.FloatySpaceBlock",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<Cutscene>d__9",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<WaitForGranny>d__10",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<Laugh>d__11",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<StopLaughing>d__12",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<StepForward>d__13",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<GrannyDisappear>d__14",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<FadeToWhite>d__15",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_Farewell+<DoFadeToWhite>d__16",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch+<Cutscene>d__14",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch+<>c__DisplayClass15_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch+<WaveCamera>d__16",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalLaunch+<BirdRoutine>d__17",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalRoom",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalRoom+<Cutscene>d__5",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalRoom+<BadelineAppears>d__6",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CS10_FinalRoom+<BadelineVanishes>d__7",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.StarRotateSpinner",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.StarTrackSpinner",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CrumbleWallOnRumble",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+Axes",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+MoveState",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+<>c__DisplayClass39_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+<>c__DisplayClass41_0",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.CrushBlock+<AttackSequence>d__41",
                Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.GlassBlock", Array.Empty<ISourceCommandMethodMetadata>());
            catalog.PublishDeclaredCommandMethods("Celeste.GlassBlock+Line",
                Array.Empty<ISourceCommandMethodMetadata>());
        }
    }
}
