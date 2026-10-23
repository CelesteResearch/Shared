using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;
using Celeste.Game.Reflection.Metadata.Resources;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMemberMetadata
    {
        private static void PublishInstalled178(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121836,
                "MapData", SourceMemberKind.Field, 32849, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourcePico8MapData.Value, "System.String",
                SourcePico8MapData.HexBlob,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121837,
                "ReturnTo", SourceMemberKind.Field, 6, "Monocle.Scene", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Scene")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121838,
                "game", SourceMemberKind.Field, 1, "Celeste.Pico8.Classic", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Pico8.Classic")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121839,
                "gameFrame", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121840,
                "gameActive", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121841,
                "gameDelay", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121842,
                "bootLevel", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Point", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Point")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121843,
                "leaving", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121844,
                "skipFrame", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121845,
                "bgSfx", SourceMemberKind.Field, 1, "FMOD.Studio.EventInstance", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.Studio.EventInstance")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121846,
                "buffer", SourceMemberKind.Field, 1, "Monocle.VirtualRenderTarget", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualRenderTarget")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121847,
                "pixels", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Color[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        "Microsoft.Xna.Framework.Color"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121848,
                "offset", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121849,
                "pauseMenu", SourceMemberKind.Field, 1, "Celeste.TextMenu", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.TextMenu")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121850,
                "pauseFade", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121851,
                "snapshot", SourceMemberKind.Field, 1, "FMOD.Studio.EventInstance", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.Studio.EventInstance")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121852,
                "picoBootLogo", SourceMemberKind.Field, 1, "Monocle.MTexture", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.MTexture")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121853,
                "tilemap", SourceMemberKind.Field, 1, "System.Byte[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Byte"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121854,
                "sprites", SourceMemberKind.Field, 1, "Monocle.MTexture[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Monocle.MTexture"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121855,
                "mask", SourceMemberKind.Field, 1, "System.Byte[]", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Byte"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121856,
                "colors", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Color[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        "Microsoft.Xna.Framework.Color"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121857,
                "paletteSwap", SourceMemberKind.Field, 1,
                "System.Collections.Generic.Dictionary`2<Microsoft.Xna.Framework.Color,System.Int32>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.Dictionary`2"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Color"),
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121858,
                "font", SourceMemberKind.Field, 1, "Monocle.MTexture[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Monocle.MTexture"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 67121859,
                "fontMap", SourceMemberKind.Field, 1, "System.String", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 385878004,
                "CanPause", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 385878005,
                "booting", SourceMemberKind.Property, 0, "System.Boolean", 2177, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Pico8.Emulator+<>c__DisplayClass34_0", 33556515, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [],
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
                "Celeste.Pico8.Emulator+<>c__DisplayClass34_0", 67121860, "menu", SourceMemberKind.Field, 6,
                "Celeste.TextMenu", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.TextMenu")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Pico8.Emulator+<>c__DisplayClass34_0", 67121861, "<>4__this", SourceMemberKind.Field, 6,
                "Celeste.Pico8.Emulator", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Pico8.Emulator")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Pico8.Emulator+<>c__DisplayClass34_0", 67121862, "<>9__4", SourceMemberKind.Field, 6,
                "System.Action", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Action")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Pico8.Emulator+<>c__DisplayClass34_0", 67121863, "<>9__5", SourceMemberKind.Field, 6,
                "System.Action", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Action")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                33556516, 256, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
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
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121864, "00904527E87CC0432C714C0F615E92F5E1E28138", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121865, "010B8B625DC7B5F17CF0EC4CCE414EDEB165594F", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=40", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=40")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121866, "02E4414E7DFA0F3AA2387EE8EA7AB31431CB406A", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121867, "04FA4A4C7F357EA7D6F81E4A14E461F02B35CC32", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=128", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=128")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121868, "1672BE8EEC36F23949F4E47561C8F666A0395273", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121869, "261FB989D4503427F8BDA5F14B6FC176CD5AA844", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=56", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=56")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121870, "26775554253D9358326F598D47732F883351F71D", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121871, "2974E6188BC8B38A20D74C764B1B591407425BE3", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=160", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=160")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121872, "3AC4A90D6575620612B002BB060DAB04D3D007CB", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121873, "43C95568B0DD539C3C647B8B9A44D6F5969D5C4C", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121874, "515DF08D6811B8F8827E4529B4601146BF4C74C3", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=64", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=64")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121875, "51C6BEBDF2826791A1E66BA6E28F77216FAD2C6C", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=40", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=40")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121876, "66336979A2F1495881DE511DADF5E095C9571DCC", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121877, "6DA21F8E611B60E3AAAD9858C7A1994039C5A5F3", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=44", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=44")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121878, "76421D8ACD0C21BFF4344CAF0F240B6E97325A86", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121879, "7BEC6B376E605ABC5F948D2C7064A1EFBF9A29D3", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121880, "8A35AAA64DE93269276BE018286D7962E4BA0B32", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121881, "C4E70AB31EF6C8908F896CAD1C6BC75F7FA65E27", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121882, "D23438D384D699F23EDE64DCFC7D789D54EF9A1E", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121883, "DB17E883A647963A26D973378923EF4649801319", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121884, "E0D670B3D59D8283B8B6434E59A115951D8FC0CE", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121885, "E74588860CA220F5327520E16546CBB6016903F4", SourceMemberKind.Field, 275,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=512", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=512")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121886, "182B32F98384849B6CF1D57656FEE0A83F179C35B45061F8FBE89E0F65BD04E2", SourceMemberKind.Field,
                307,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121887, "3C17DA885F7916F14BECDDD5A559E146795A03758C28EA455EC8E9E803B90531", SourceMemberKind.Field,
                307,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121888, "5687824BC955147FA9656C5DCEDE53D2E75AD3BF2F1A4EAECAD8399A2D89F33B", SourceMemberKind.Field,
                307,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121889, "5E2418822BBD89842A0D38ED3A381BE3805DCB5CCAF0A49116C01DC05969300C", SourceMemberKind.Field,
                307,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121890, "783049F5B150D5C580C720346FA0B6FE7050B2222BAEB41C25CAEBA95610C86C", SourceMemberKind.Field,
                307,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121891, "7ADB6BF3C484E8BAE8622CE1D8B60AB912D2FF8B43FD23CB90DC9BAC393B0E5F", SourceMemberKind.Field,
                307,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121892, "8D9651F7522817FAA76506ACB60222F15131E0100193E161125BABC6C1248910", SourceMemberKind.Field,
                307,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121893, "9E69105FB69F54DCEC96D26199449E4F9A2B54A1DE914A3946946DC04047894F", SourceMemberKind.Field,
                307,
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "<PrivateImplementationDetails>",
                67121894, "FEA4CE6719F1FDB6D2E30CFB86C2E797DBD4A3247FF2B0EFC15A814C5B25C75E", SourceMemberKind.Field,
                307,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=12", 33556517, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=16", 33556518, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=20", 33556519, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=24", 33556520, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=40", 33556521, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=44", 33556522, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=56", 33556523, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=64", 33556524, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=128", 33556525, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=160", 33556526, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "<PrivateImplementationDetails>+__StaticArrayInitTypeSize=512", 33556527, 275,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.ValueType"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__WholeLineIsCommandsRegex_0",
                33556528, 1048832,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.Regex", [],
                [
                    new("System.CodeDom.Compiler.GeneratedCodeAttribute",
                        "System.Void System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(System.String,System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x28, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x2E,
                            0x52,
                            0x65, 0x67, 0x75, 0x6C, 0x61, 0x72, 0x45, 0x78, 0x70, 0x72, 0x65, 0x73, 0x73, 0x69, 0x6F,
                            0x6E,
                            0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x61, 0x74, 0x6F, 0x72, 0x0C, 0x38, 0x2E, 0x30,
                            0x2E,
                            0x31, 0x32, 0x2E, 0x33, 0x36, 0x35, 0x31, 0x34, 0x00, 0x00,
                        ]),
                    new("System.Runtime.CompilerServices.SkipLocalsInitAttribute",
                        "System.Void System.Runtime.CompilerServices.SkipLocalsInitAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.Regex"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__WholeLineIsCommandsRegex_0",
                67121895, "Instance", SourceMemberKind.Field, 51,
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__WholeLineIsCommandsRegex_0",
                -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__WholeLineIsCommandsRegex_0")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__WholeLineIsCommandsRegex_0+RunnerFactory",
                33556529, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunnerFactory", [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunnerFactory"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__WholeLineIsCommandsRegex_0+RunnerFactory+Runner",
                33556530, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunner", [],
                [],
                null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunner"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "MonoMod.MonoModAdded", 33556531, 1,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Attribute",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Attribute"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__CommandRegex_1",
                33556532, 1048832,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.Regex", [],
                [
                    new("System.CodeDom.Compiler.GeneratedCodeAttribute",
                        "System.Void System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(System.String,System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x28, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x2E,
                            0x52,
                            0x65, 0x67, 0x75, 0x6C, 0x61, 0x72, 0x45, 0x78, 0x70, 0x72, 0x65, 0x73, 0x73, 0x69, 0x6F,
                            0x6E,
                            0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x61, 0x74, 0x6F, 0x72, 0x0C, 0x38, 0x2E, 0x30,
                            0x2E,
                            0x31, 0x32, 0x2E, 0x33, 0x36, 0x35, 0x31, 0x34, 0x00, 0x00,
                        ]),
                    new("System.Runtime.CompilerServices.SkipLocalsInitAttribute",
                        "System.Void System.Runtime.CompilerServices.SkipLocalsInitAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.Regex"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__CommandRegex_1",
                67121896, "Instance", SourceMemberKind.Field, 51,
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__CommandRegex_1",
                -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__CommandRegex_1")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__CommandRegex_1+RunnerFactory",
                33556533, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunnerFactory", [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunnerFactory"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__CommandRegex_1+RunnerFactory+Runner",
                33556534, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunner", [],
                [],
                null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunner"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__PortraitRegex_2",
                33556535, 1048832,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.Regex", [],
                [
                    new("System.CodeDom.Compiler.GeneratedCodeAttribute",
                        "System.Void System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(System.String,System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x28, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x2E,
                            0x52,
                            0x65, 0x67, 0x75, 0x6C, 0x61, 0x72, 0x45, 0x78, 0x70, 0x72, 0x65, 0x73, 0x73, 0x69, 0x6F,
                            0x6E,
                            0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x61, 0x74, 0x6F, 0x72, 0x0C, 0x38, 0x2E, 0x30,
                            0x2E,
                            0x31, 0x32, 0x2E, 0x33, 0x36, 0x35, 0x31, 0x34, 0x00, 0x00,
                        ]),
                    new("System.Runtime.CompilerServices.SkipLocalsInitAttribute",
                        "System.Void System.Runtime.CompilerServices.SkipLocalsInitAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.Regex"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__PortraitRegex_2",
                67121897, "Instance", SourceMemberKind.Field, 51,
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__PortraitRegex_2",
                -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__PortraitRegex_2")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__PortraitRegex_2+RunnerFactory",
                33556536, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunnerFactory", [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunnerFactory"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__PortraitRegex_2+RunnerFactory+Runner",
                33556537, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunner", [],
                [],
                null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunner"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__VariableRegex_3",
                33556538, 1048832,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.Regex", [],
                [
                    new("System.CodeDom.Compiler.GeneratedCodeAttribute",
                        "System.Void System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(System.String,System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x28, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x2E,
                            0x52,
                            0x65, 0x67, 0x75, 0x6C, 0x61, 0x72, 0x45, 0x78, 0x70, 0x72, 0x65, 0x73, 0x73, 0x69, 0x6F,
                            0x6E,
                            0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x61, 0x74, 0x6F, 0x72, 0x0C, 0x38, 0x2E, 0x30,
                            0x2E,
                            0x31, 0x32, 0x2E, 0x33, 0x36, 0x35, 0x31, 0x34, 0x00, 0x00,
                        ]),
                    new("System.Runtime.CompilerServices.SkipLocalsInitAttribute",
                        "System.Void System.Runtime.CompilerServices.SkipLocalsInitAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.Regex"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__VariableRegex_3",
                67121898, "Instance", SourceMemberKind.Field, 51,
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__VariableRegex_3",
                -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__VariableRegex_3")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__VariableRegex_3+RunnerFactory",
                33556539, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunnerFactory", [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunnerFactory"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__VariableRegex_3+RunnerFactory+Runner",
                33556540, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunner", [],
                [],
                null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunner"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__InsertRegex_4",
                33556541, 1048832,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.Regex", [],
                [
                    new("System.CodeDom.Compiler.GeneratedCodeAttribute",
                        "System.Void System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(System.String,System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x28, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x2E,
                            0x52,
                            0x65, 0x67, 0x75, 0x6C, 0x61, 0x72, 0x45, 0x78, 0x70, 0x72, 0x65, 0x73, 0x73, 0x69, 0x6F,
                            0x6E,
                            0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x61, 0x74, 0x6F, 0x72, 0x0C, 0x38, 0x2E, 0x30,
                            0x2E,
                            0x31, 0x32, 0x2E, 0x33, 0x36, 0x35, 0x31, 0x34, 0x00, 0x00,
                        ]),
                    new("System.Runtime.CompilerServices.SkipLocalsInitAttribute",
                        "System.Void System.Runtime.CompilerServices.SkipLocalsInitAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.Regex"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__InsertRegex_4",
                67121899, "Instance", SourceMemberKind.Field, 51,
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__InsertRegex_4",
                -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__InsertRegex_4")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__InsertRegex_4+RunnerFactory",
                33556542, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunnerFactory", [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunnerFactory"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__InsertRegex_4+RunnerFactory+Runner",
                33556543, 1048835,
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Text.RegularExpressions.RegexRunner", [],
                [],
                null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Text.RegularExpressions.RegexRunner"),
                []));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "System.Text.RegularExpressions.Generated.<RegexGenerator_g>FA7630E35E3439DDB43992F944EBA21901B3A72C7C6E49475E5CD49294F139831__Utilities",
                33556544, 1048960, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Object", [],
                [
                    new("System.Runtime.CompilerServices.NullableContextAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.CompilerServices.NullableAttribute",
                        "System.Void System.Runtime.CompilerServices.NullableAttribute::.ctor(System.Byte)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                    new("System.CodeDom.Compiler.GeneratedCodeAttribute",
                        "System.Void System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(System.String,System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x28, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x2E,
                            0x52,
                            0x65, 0x67, 0x75, 0x6C, 0x61, 0x72, 0x45, 0x78, 0x70, 0x72, 0x65, 0x73, 0x73, 0x69, 0x6F,
                            0x6E,
                            0x73, 0x2E, 0x47, 0x65, 0x6E, 0x65, 0x72, 0x61, 0x74, 0x6F, 0x72, 0x0C, 0x38, 0x2E, 0x30,
                            0x2E,
                            0x31, 0x32, 0x2E, 0x33, 0x36, 0x35, 0x31, 0x34, 0x00, 0x00,
                        ]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Object"), []));
        }
    }
}
