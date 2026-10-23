using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMemberMetadata
    {
        private static void PublishOriginal154(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Player+<BirdDashTutorialCoroutine>d__561", 385877743,
                "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property, 0,
                "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Player+<BirdDashTutorialCoroutine>d__561", 385877744, "System.Collections.IEnumerator.Current",
                SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 33555327, 1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Engine",
                [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Engine"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115739,
                "GameWidth",
                SourceMemberKind.Field, 32854, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x40, 0x01, 0x00, 0x00]), "System.Int32",
                "40010000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115740,
                "GameHeight",
                SourceMemberKind.Field, 32854, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0xB4, 0x00, 0x00, 0x00]), "System.Int32",
                "B4000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115741,
                "TargetWidth", SourceMemberKind.Field, 32854, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0x80, 0x07, 0x00, 0x00]), "System.Int32",
                "80070000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115742,
                "TargetHeight", SourceMemberKind.Field, 32854, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x38, 0x04, 0x00, 0x00]), "System.Int32",
                "38040000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115743,
                "PlayMode",
                SourceMemberKind.Field, 22, "Celeste.Celeste+PlayModes", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Celeste+PlayModes")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115744,
                "EventName",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String", []), "System.String", "",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115745, "Beta",
                SourceMemberKind.Field, 32854, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Boolean", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00]), "System.Boolean", "00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115746,
                "PLATFORM",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x50, 0x00, 0x43, 0x00]), "System.String",
                "50004300", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115747,
                "Instance",
                SourceMemberKind.Field, 22, "Celeste.Celeste", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Celeste")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115748,
                "HudTarget",
                SourceMemberKind.Field, 22, "Monocle.VirtualRenderTarget", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualRenderTarget")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115749,
                "WipeTarget",
                SourceMemberKind.Field, 22, "Monocle.VirtualRenderTarget", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualRenderTarget")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115750,
                "DisconnectUI", SourceMemberKind.Field, 22, "Celeste.DisconnectedControllerUI", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.DisconnectedControllerUI")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115751,
                "firstLoad",
                SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115752,
                "AutoSplitterInfo", SourceMemberKind.Field, 6, "Celeste.AutoSplitterInfo", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.AutoSplitterInfo")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115753,
                "SaveRoutine", SourceMemberKind.Field, 22, "Monocle.Coroutine", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Coroutine")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115754,
                "LoadTimer",
                SourceMemberKind.Field, 22, "System.Diagnostics.Stopwatch", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Diagnostics.Stopwatch")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115755,
                "SteamID",
                SourceMemberKind.Field, 54, "Steamworks.AppId_t", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "Steamworks.NET, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Steamworks.NET, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Steamworks.AppId_t")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 67115756,
                "_mainThreadId", SourceMemberKind.Field, 17, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 385876543,
                "TargetCenter", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Vector2", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste", 385876544,
                "IsMainThread", SourceMemberKind.Property, 0, "System.Boolean", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste+PlayModes", 33556308,
                258, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste+PlayModes", 67120856,
                "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste+PlayModes", 67120857,
                "Normal", SourceMemberKind.Field, 32854, "Celeste.Celeste+PlayModes", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Celeste+PlayModes")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste+PlayModes", 67120858,
                "Debug", SourceMemberKind.Field, 32854, "Celeste.Celeste+PlayModes", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Celeste+PlayModes")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste+PlayModes", 67120859,
                "Event", SourceMemberKind.Field, 32854, "Celeste.Celeste+PlayModes", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Celeste+PlayModes")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Celeste+PlayModes", 67120860,
                "Demo", SourceMemberKind.Field, 32854, "Celeste.Celeste+PlayModes", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Celeste+PlayModes")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SolidTiles", 33555328,
                1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Solid",
                [],
                [
                    new("Monocle.Tracked", "System.Void Monocle.Tracked::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Solid"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SolidTiles", 67115757,
                "Tiles",
                SourceMemberKind.Field, 6, "Monocle.TileGrid", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.TileGrid")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SolidTiles", 67115758,
                "AnimatedTiles", SourceMemberKind.Field, 6, "Celeste.AnimatedTiles", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.AnimatedTiles")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SolidTiles", 67115759,
                "Grid",
                SourceMemberKind.Field, 6, "Monocle.Grid", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Grid")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SolidTiles", 67115760,
                "tileTypes", SourceMemberKind.Field, 1, "Monocle.VirtualMap`1<System.Char>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Monocle.VirtualMap`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Char"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunLengthEncoding", 33555329,
                1048961, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread", 33555330,
                1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RunThread", 67115761,
                "threads",
                SourceMemberKind.Field, 17, "System.Collections.Generic.List`1<System.Threading.Thread>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Threading.Thread"),
                    ])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.RunThread+<>c__DisplayClass1_0",
                33556309, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.RunThread+<>c__DisplayClass1_0",
                67120861, "method", SourceMemberKind.Field, 6, "System.Action", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Action")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 33555331, 1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67115762, "GLOBAL",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */
                    [0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00]), "System.String",
                "6200750073003A002F00", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67115763, "MUSIC",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00,
                        0x69, 0x00, 0x63, 0x00,
                    ]), "System.String", "6200750073003A002F006D007500730069006300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67115764, "GAMEPLAY",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                        0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                        0x78, 0x00,
                    ]), "System.String", "6200750073003A002F00670061006D00650070006C00610079005F00730066007800",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67115765, "STINGS",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00,
                        0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00,
                        0x73, 0x00,
                    ]), "System.String", "6200750073003A002F006D0075007300690063002F007300740069006E0067007300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67115766, "UI",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x75, 0x00, 0x69, 0x00, 0x5F, 0x00,
                        0x73, 0x00, 0x66, 0x00, 0x78, 0x00,
                    ]), "System.String", "6200750073003A002F00750069005F00730066007800",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67115767, "AMBIENCE",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                        0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                        0x78, 0x00, 0x2F, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x62, 0x00, 0x69, 0x00, 0x65, 0x00, 0x6E, 0x00,
                        0x63, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6200750073003A002F00670061006D00650070006C00610079005F007300660078002F0061006D006200690065006E0063006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67115768, "CHAR",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                        0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                        0x78, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x68, 0x00, 0x61, 0x00, 0x72, 0x00,
                    ]), "System.String",
                "6200750073003A002F00670061006D00650070006C00610079005F007300660078002F006300680061007200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67115769,
                "YES_PAUSE",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                        0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                        0x78, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x2F, 0x00, 0x67, 0x00,
                        0x65, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x2F, 0x00, 0x79, 0x00,
                        0x65, 0x00, 0x73, 0x00, 0x5F, 0x00, 0x70, 0x00, 0x61, 0x00, 0x75, 0x00, 0x73, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6200750073003A002F00670061006D00650070006C00610079005F007300660078002F00670061006D0065002F00670065006E006500720061006C002F007900650073005F0070006100750073006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Buses", 67115770, "CHAPTERS",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x62, 0x00, 0x75, 0x00, 0x73, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                        0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                        0x78, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x2F, 0x00, 0x63, 0x00,
                        0x68, 0x00, 0x61, 0x00, 0x70, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00,
                    ]), "System.String",
                "6200750073003A002F00670061006D00650070006C00610079005F007300660078002F00670061006D0065002F0063006800610070007400650072007300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.VCAs", 33555332, 1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.VCAs", 67115771, "MUSIC",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x76, 0x00, 0x63, 0x00, 0x61, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00,
                        0x69, 0x00, 0x63, 0x00,
                    ]), "System.String", "7600630061003A002F006D007500730069006300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.VCAs", 67115772,
                "GAMEPLAY_SFX",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x76, 0x00, 0x63, 0x00, 0x61, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00,
                        0x65, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x61, 0x00, 0x79, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x66, 0x00,
                        0x78, 0x00,
                    ]), "System.String", "7600630061003A002F00670061006D00650070006C00610079005F00730066007800",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.VCAs", 67115773, "UI_SFX",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x76, 0x00, 0x63, 0x00, 0x61, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x75, 0x00, 0x69, 0x00, 0x5F, 0x00,
                        0x73, 0x00, 0x66, 0x00, 0x78, 0x00,
                    ]), "System.String", "7600630061003A002F00750069005F00730066007800",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 33555333,
                1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67115774,
                "PAUSE_MENU", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                        0x3A, 0x00, 0x2F, 0x00, 0x70, 0x00, 0x61, 0x00, 0x75, 0x00, 0x73, 0x00, 0x65, 0x00, 0x5F, 0x00,
                        0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x75, 0x00,
                    ]), "System.String",
                "73006E0061007000730068006F0074003A002F00700061007500730065005F006D0065006E007500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67115775,
                "MAIN_DOWN", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                        0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x5F, 0x00,
                        0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x73, 0x00, 0x5F, 0x00, 0x6D, 0x00, 0x75, 0x00,
                        0x74, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "73006E0061007000730068006F0074003A002F006D0075007300690063005F006D00610069006E0073005F006D00750074006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67115776,
                "UNDERWATER", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                        0x3A, 0x00, 0x2F, 0x00, 0x75, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x65, 0x00, 0x72, 0x00, 0x77, 0x00,
                        0x61, 0x00, 0x74, 0x00, 0x65, 0x00, 0x72, 0x00,
                    ]), "System.String",
                "73006E0061007000730068006F0074003A002F0075006E0064006500720077006100740065007200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67115777,
                "DIALOGUE",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                        0x3A, 0x00, 0x2F, 0x00, 0x64, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x67, 0x00,
                        0x75, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x70, 0x00, 0x72, 0x00,
                        0x6F, 0x00, 0x67, 0x00, 0x72, 0x00, 0x65, 0x00, 0x73, 0x00, 0x73, 0x00,
                    ]), "System.String",
                "73006E0061007000730068006F0074003A002F006400690061006C006F006700750065005F0069006E005F00700072006F0067007200650073007300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67115778,
                "GAME_10_INSIDE_CAFE", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                        0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x31, 0x00,
                        0x30, 0x00, 0x5F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x73, 0x00, 0x69, 0x00, 0x64, 0x00, 0x65, 0x00,
                        0x5F, 0x00, 0x63, 0x00, 0x61, 0x00, 0x66, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "73006E0061007000730068006F0074003A002F00670061006D0065005F00310030005F0069006E0073006900640065005F006300610066006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67115779,
                "GAME_10_GRANNY_CLOUDS", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                        0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x31, 0x00,
                        0x30, 0x00, 0x5F, 0x00, 0x67, 0x00, 0x72, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x6E, 0x00, 0x79, 0x00,
                        0x5F, 0x00, 0x63, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x75, 0x00, 0x64, 0x00, 0x73, 0x00, 0x5F, 0x00,
                        0x64, 0x00, 0x69, 0x00, 0x61, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x67, 0x00, 0x75, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "73006E0061007000730068006F0074003A002F00670061006D0065005F00310030005F006700720061006E006E0079005F0063006C006F007500640073005F006400690061006C006F00670075006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67115780,
                "GAME_10_GOLDEN_ROOM", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                        0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x31, 0x00,
                        0x30, 0x00, 0x5F, 0x00, 0x67, 0x00, 0x6F, 0x00, 0x6C, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6E, 0x00,
                        0x5F, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x5F, 0x00, 0x66, 0x00, 0x6C, 0x00,
                        0x61, 0x00, 0x76, 0x00, 0x6F, 0x00, 0x75, 0x00, 0x72, 0x00,
                    ]), "System.String",
                "73006E0061007000730068006F0074003A002F00670061006D0065005F00310030005F0067006F006C00640065006E005F0072006F006F006D005F0066006C00610076006F0075007200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67115781,
                "GAME_10_BIRD_WINGS_SILENCED", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                        0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x31, 0x00,
                        0x30, 0x00, 0x5F, 0x00, 0x62, 0x00, 0x69, 0x00, 0x72, 0x00, 0x64, 0x00, 0x5F, 0x00, 0x77, 0x00,
                        0x69, 0x00, 0x6E, 0x00, 0x67, 0x00, 0x73, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x69, 0x00, 0x6C, 0x00,
                        0x65, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x65, 0x00, 0x64, 0x00,
                    ]), "System.String",
                "73006E0061007000730068006F0074003A002F00670061006D0065005F00310030005F0062006900720064005F00770069006E00670073005F00730069006C0065006E00630065006400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snapshots", 67115782,
                "DASH_ASSIST_ACTIVE", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x73, 0x00, 0x6E, 0x00, 0x61, 0x00, 0x70, 0x00, 0x73, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x74, 0x00,
                        0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x67, 0x00,
                        0x65, 0x00, 0x6E, 0x00, 0x5F, 0x00, 0x64, 0x00, 0x61, 0x00, 0x73, 0x00, 0x68, 0x00, 0x5F, 0x00,
                        0x61, 0x00, 0x73, 0x00, 0x73, 0x00, 0x69, 0x00, 0x73, 0x00, 0x74, 0x00, 0x5F, 0x00, 0x61, 0x00,
                        0x63, 0x00, 0x74, 0x00, 0x69, 0x00, 0x76, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "73006E0061007000730068006F0074003A002F00670061006D0065005F00670065006E005F0064006100730068005F006100730073006900730074005F00610063007400690076006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 33555334, 1048961,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115783, "NONE",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [0x6E, 0x00, 0x75, 0x00, 0x6C, 0x00, 0x6C, 0x00]),
                "System.String", "6E0075006C006C00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115784,
                "music_levelselect", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                        0x75, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x5F, 0x00,
                        0x73, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x63, 0x00, 0x74, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F006C006500760065006C005F00730065006C00650063007400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115785,
                "music_credits",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                        0x75, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x72, 0x00, 0x65, 0x00, 0x64, 0x00, 0x69, 0x00, 0x74, 0x00,
                        0x73, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F006300720065006400690074007300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115786,
                "music_complete_area", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                        0x75, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x65, 0x00,
                        0x74, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x61, 0x00, 0x72, 0x00, 0x65, 0x00, 0x61, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F0063006F006D0070006C006500740065005F006100720065006100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115787,
                "music_complete_summit", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                        0x75, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x65, 0x00,
                        0x74, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x6D, 0x00, 0x69, 0x00,
                        0x74, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F0063006F006D0070006C006500740065005F00730075006D006D0069007400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115788,
                "music_complete_bside", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E, 0x00,
                        0x75, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x65, 0x00,
                        0x74, 0x00, 0x65, 0x00, 0x5F, 0x00, 0x62, 0x00, 0x73, 0x00, 0x69, 0x00, 0x64, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006D0065006E0075002F0063006F006D0070006C006500740065005F0062007300690064006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115789,
                "music_prologue_intro_vignette", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x67, 0x00,
                        0x61, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x2F, 0x00, 0x30, 0x00, 0x30, 0x00, 0x5F, 0x00, 0x70, 0x00,
                        0x72, 0x00, 0x6F, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x67, 0x00, 0x75, 0x00, 0x65, 0x00, 0x2F, 0x00,
                        0x69, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x5F, 0x00, 0x76, 0x00, 0x69, 0x00,
                        0x67, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x74, 0x00, 0x74, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F00670061006D0065002F00300030005F00700072006F006C006F006700750065002F0069006E00740072006F005F007600690067006E006500740074006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115790,
                "music_prologue_beginning", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x30, 0x00, 0x2F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x72, 0x00, 0x6F, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0030002F0069006E00740072006F00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115791,
                "music_prologue_collapse", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x30, 0x00, 0x2F, 0x00, 0x62, 0x00, 0x72, 0x00, 0x69, 0x00, 0x64, 0x00, 0x67, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0030002F00620072006900640067006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115792,
                "music_prologue_title_ping", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x30, 0x00, 0x2F, 0x00, 0x74, 0x00, 0x69, 0x00, 0x74, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x5F, 0x00,
                        0x70, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x67, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0030002F007400690074006C0065005F00700069006E006700",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115793, "music_city",
                SourceMemberKind.Field, 32854, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x31, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0031002F006D00610069006E00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115794,
                "music_city_theo", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x31, 0x00, 0x2F, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00, 0x6F, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0031002F007400680065006F00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115795,
                "music_oldsite_beginning", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x32, 0x00, 0x2F, 0x00, 0x62, 0x00, 0x65, 0x00, 0x67, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x6E, 0x00,
                        0x69, 0x00, 0x6E, 0x00, 0x67, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F0062006500670069006E006E0069006E006700",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115796,
                "music_oldsite_mirror", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x32, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x72, 0x00, 0x72, 0x00, 0x6F, 0x00, 0x72, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F006D006900720072006F007200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115797,
                "music_oldsite_dreamblock_sting_pt1", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x32, 0x00, 0x2F, 0x00, 0x64, 0x00, 0x72, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x62, 0x00,
                        0x6C, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x6B, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x69, 0x00,
                        0x6E, 0x00, 0x67, 0x00, 0x5F, 0x00, 0x70, 0x00, 0x74, 0x00, 0x31, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F0064007200650061006D0062006C006F0063006B005F007300740069006E0067005F00700074003100",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115798,
                "music_oldsite_dreamblock_sting_pt2", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x32, 0x00, 0x2F, 0x00, 0x64, 0x00, 0x72, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x62, 0x00,
                        0x6C, 0x00, 0x6F, 0x00, 0x63, 0x00, 0x6B, 0x00, 0x5F, 0x00, 0x73, 0x00, 0x74, 0x00, 0x69, 0x00,
                        0x6E, 0x00, 0x67, 0x00, 0x5F, 0x00, 0x70, 0x00, 0x74, 0x00, 0x32, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F0064007200650061006D0062006C006F0063006B005F007300740069006E0067005F00700074003200",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115799,
                "music_oldsite_evil_maddy", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x32, 0x00, 0x2F, 0x00, 0x65, 0x00, 0x76, 0x00, 0x69, 0x00, 0x6C, 0x00, 0x5F, 0x00, 0x6D, 0x00,
                        0x61, 0x00, 0x64, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F006500760069006C005F006D006100640065006C0069006E006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115800,
                "music_oldsite_chase", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x32, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x68, 0x00, 0x61, 0x00, 0x73, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F0063006800610073006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115801,
                "music_oldsite_payphone_loop", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x32, 0x00, 0x2F, 0x00, 0x70, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x5F, 0x00,
                        0x6C, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x70, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F00700068006F006E0065005F006C006F006F007000",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115802,
                "music_oldsite_payphone_end", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x32, 0x00, 0x2F, 0x00, 0x70, 0x00, 0x68, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x65, 0x00, 0x5F, 0x00,
                        0x65, 0x00, 0x6E, 0x00, 0x64, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F00700068006F006E0065005F0065006E006400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115803,
                "music_oldsite_awake", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x32, 0x00, 0x2F, 0x00, 0x61, 0x00, 0x77, 0x00, 0x61, 0x00, 0x6B, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0032002F006100770061006B006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115804,
                "music_resort_intro", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x33, 0x00, 0x2F, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x72, 0x00, 0x6F, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F0069006E00740072006F00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115805,
                "music_resort_explore", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x33, 0x00, 0x2F, 0x00, 0x65, 0x00, 0x78, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x72, 0x00,
                        0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F006500780070006C006F0072006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115806,
                "music_resort_clean", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x33, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6E, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F0063006C00650061006E00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115807,
                "music_resort_clean_extended", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x33, 0x00, 0x2F, 0x00, 0x63, 0x00, 0x6C, 0x00, 0x65, 0x00, 0x61, 0x00, 0x6E, 0x00, 0x5F, 0x00,
                        0x65, 0x00, 0x78, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x65, 0x00, 0x64, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F0063006C00650061006E005F0065007800740065006E00640065006400",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115808,
                "music_resort_oshiro_theme", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x33, 0x00, 0x2F, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x68, 0x00, 0x69, 0x00, 0x72, 0x00, 0x6F, 0x00,
                        0x5F, 0x00, 0x74, 0x00, 0x68, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F006F0073006800690072006F005F007400680065006D006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115809,
                "music_resort_oshiro_chase", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x33, 0x00, 0x2F, 0x00, 0x6F, 0x00, 0x73, 0x00, 0x68, 0x00, 0x69, 0x00, 0x72, 0x00, 0x6F, 0x00,
                        0x5F, 0x00, 0x63, 0x00, 0x68, 0x00, 0x61, 0x00, 0x73, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0033002F006F0073006800690072006F005F0063006800610073006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115810,
                "music_cliffside_main", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x34, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x69, 0x00, 0x6E, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0034002F006D00610069006E00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115811,
                "music_cliffside_heavywinds", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x34, 0x00, 0x2F, 0x00, 0x68, 0x00, 0x65, 0x00, 0x61, 0x00, 0x76, 0x00, 0x79, 0x00, 0x5F, 0x00,
                        0x77, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x64, 0x00, 0x73, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0034002F00680065006100760079005F00770069006E0064007300",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115812,
                "music_cliffside_panicattack", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x34, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x69, 0x00, 0x67, 0x00, 0x61, 0x00,
                        0x6D, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0034002F006D0069006E006900670061006D006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115813,
                "music_temple_normal", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x35, 0x00, 0x2F, 0x00, 0x6E, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6D, 0x00, 0x61, 0x00, 0x6C, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0035002F006E006F0072006D0061006C00",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SFX", 67115814,
                "music_temple_middle", SourceMemberKind.Field, 32854, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.String",
                    /* ReSharper disable once UseUtf8StringLiteral */ [
                        0x65, 0x00, 0x76, 0x00, 0x65, 0x00, 0x6E, 0x00, 0x74, 0x00, 0x3A, 0x00, 0x2F, 0x00, 0x6D, 0x00,
                        0x75, 0x00, 0x73, 0x00, 0x69, 0x00, 0x63, 0x00, 0x2F, 0x00, 0x6C, 0x00, 0x76, 0x00, 0x6C, 0x00,
                        0x35, 0x00, 0x2F, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x64, 0x00, 0x64, 0x00, 0x6C, 0x00, 0x65, 0x00,
                        0x5F, 0x00, 0x74, 0x00, 0x65, 0x00, 0x6D, 0x00, 0x70, 0x00, 0x6C, 0x00, 0x65, 0x00,
                    ]), "System.String",
                "6500760065006E0074003A002F006D0075007300690063002F006C0076006C0035002F006D006900640064006C0065005F00740065006D0070006C006500",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
        }
    }
}
