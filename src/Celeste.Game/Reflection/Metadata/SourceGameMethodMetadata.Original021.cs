using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Game.Reflection.Metadata;

public static partial class SourceGameMethodMetadata
{
    private static void PublishOriginal021(SourceAssemblyMethodCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS10_FinalRoom+<BadelineAppears>d__6", 33555413, 100671279, "System.Collections.IEnumerator.Reset",
            481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS10_FinalRoom+<BadelineAppears>d__6", 33555413, 100671280,
            "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS10_FinalRoom+<BadelineVanishes>d__7", 33555414, 100671281, ".ctor", 6278, "20010108",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("<>1__state", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134227554)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS10_FinalRoom+<BadelineVanishes>d__7", 33555414, 100671282, "System.IDisposable.Dispose", 481,
            "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS10_FinalRoom+<BadelineVanishes>d__7", 33555414, 100671283, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 52, 144));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS10_FinalRoom+<BadelineVanishes>d__7", 33555414, 100671284,
            "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS10_FinalRoom+<BadelineVanishes>d__7", 33555414, 100671285,
            "System.Collections.IEnumerator.Reset", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS10_FinalRoom+<BadelineVanishes>d__7", 33555414, 100671286,
            "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StarRotateSpinner", 33554760,
            100666369, ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223233),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223234)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 38, 111));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StarRotateSpinner", 33554760,
            100666370, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 52, 163));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StarTrackSpinner", 33554761,
            100666371, ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223235),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223236)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 38, 111));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StarTrackSpinner", 33554761,
            100666372, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 25, 83));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StarTrackSpinner", 33554761,
            100666373, "OnTrackStart", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 37, 102));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StarTrackSpinner", 33554761,
            100666374, "OnTrackEnd", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumbleWallOnRumble", 33554762,
            100666375, ".ctor", 6278, "200701118085030C0C0202118C68", new KeyValuePair<string, string>[] { },
            "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "System.Char", "System.Single", "System.Single", "System.Boolean",
                "System.Boolean", "Celeste.EntityID"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223237),
                new SourceMethodParameterDefinition("tileType", 1, 0, "System.Char", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Char"), 2, 134223238),
                new SourceMethodParameterDefinition("width", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134223239),
                new SourceMethodParameterDefinition("height", 3, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134223240),
                new SourceMethodParameterDefinition("blendIn", 4, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 5, 134223241),
                new SourceMethodParameterDefinition("persistent", 5, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 6, 134223242),
                new SourceMethodParameterDefinition("id", 6, 0, "Celeste.EntityID", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityID"), 7, 134223243)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 28, 76));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumbleWallOnRumble", 33554762,
            100666376, ".ctor", 6278, "200301128DBC118085118C68", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2", "Celeste.EntityID" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223244),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223245),
                new SourceMethodParameterDefinition("id", 2, 0, "Celeste.EntityID", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityID"), 3, 134223246)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 26, 71));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumbleWallOnRumble", 33554762,
            100666377, "Awake", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223247)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 94, 248));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumbleWallOnRumble", 33554762,
            100666378, "Break", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 105, 260));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666379,
            ".ctor", 6278, "2005011180850C0C118F5C02", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single", "Celeste.CrushBlock+Axes",
                "System.Boolean"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223248),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223249),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134223250),
                new SourceMethodParameterDefinition("axes", 3, 0, "Celeste.CrushBlock+Axes", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.CrushBlock+Axes"), 4, 134223251),
                new SourceMethodParameterDefinition("chillOut", 4, 4112, "System.Boolean", true, "System.Boolean",
                    new byte[] { 0x00 }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 5, 134223252)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 283, 721));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666380,
            ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223253),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223254)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 21, 57));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666381,
            "Added", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223255)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666382,
            "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 98, 317));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666383,
            "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 35, 103));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666384,
            "get_Submerged", 2177, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 17, 49));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666385,
            "AddImage", 129, "200701128420080808080808", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Monocle.MTexture", "System.Int32", "System.Int32", "System.Int32", "System.Int32", "System.Int32",
                "System.Int32"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("idle", 0, 0, "Monocle.MTexture", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.MTexture"), 1, 134223256),
                new SourceMethodParameterDefinition("x", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223257),
                new SourceMethodParameterDefinition("y", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223258),
                new SourceMethodParameterDefinition("tx", 3, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 4, 134223259),
                new SourceMethodParameterDefinition("ty", 4, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 5, 134223260),
                new SourceMethodParameterDefinition("borderX", 5, 4112, "System.Int32", true, "System.Int32",
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 6, 134223261),
                new SourceMethodParameterDefinition("borderY", 6, 4112, "System.Int32", true, "System.Int32",
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 7, 134223262)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 196, 501));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666386,
            "TurnOffImages", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 69, 209));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666387,
            "OnDashed", 129, "2002118DE8128DF8118085", new KeyValuePair<string, string>[] { },
            "Celeste.DashCollisionResults", new string[] { "Celeste.Player", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223263),
                new SourceMethodParameterDefinition("direction", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223264)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.DashCollisionResults"), true, 13, 30));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666388,
            "CanActivate", 129, "200102118085", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("direction", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223265)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 39, 95));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666389,
            "Attack", 129, "200101118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("direction", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223266)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 240, 758));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666390,
            "ActivateParticles", 129, "200101118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("dir", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223267)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 126, 374));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666391,
            "AttackSequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002843656C657374652E4372757368426C6F636B2B3C41747461636B53657175656E63653E645F5F34310000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666392,
            "MoveHCheck", 129, "2001020C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("amount", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223268)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 89, 185));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666393,
            "MoveVCheck", 129, "2001020C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("amount", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223269)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 75, 145));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666394,
            "<.ctor>b__28_0", 129, "2001010E",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("f", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223270)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 33));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock", 33554763, 100666395,
            "<.ctor>b__28_1", 129, "200002",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 5, 17));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrushBlock+MoveState", 33555416,
            100671287, ".ctor", 6278, "200201118085118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("from", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134227555),
                new SourceMethodParameterDefinition("direction", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134227556)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 7, 15));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<>c__DisplayClass39_0", 33555417, 100671288, ".ctor", 6278, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<>c__DisplayClass39_0", 33555417, 100671289, "<Attack>b__0", 131, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 12));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<>c__DisplayClass41_0", 33555418, 100671290, ".ctor", 6278, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<>c__DisplayClass41_0", 33555418, 100671291, "<AttackSequence>b__1", 131, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 17, 53));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<>c__DisplayClass41_0", 33555418, 100671292, "<AttackSequence>b__0", 131, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 12));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<AttackSequence>d__41", 33555419, 100671293, ".ctor", 6278, "20010108",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("<>1__state", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134227557)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<AttackSequence>d__41", 33555419, 100671294, "System.IDisposable.Dispose", 481,
            "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<AttackSequence>d__41", 33555419, 100671295, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 824, 2618));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<AttackSequence>d__41", 33555419, 100671296,
            "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<AttackSequence>d__41", 33555419, 100671297, "System.Collections.IEnumerator.Reset",
            481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrushBlock+<AttackSequence>d__41", 33555419, 100671298,
            "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GlassBlock", 33554764, 100666396,
            ".ctor", 6278, "2004011180850C0C02", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single", "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223271),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223272),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134223273),
                new SourceMethodParameterDefinition("sinks", 3, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 4, 134223274)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 34, 100));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GlassBlock", 33554764, 100666397,
            ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223275),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223276)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 17, 45));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GlassBlock", 33554764, 100666398,
            "Awake", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223277)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 64, 172));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GlassBlock", 33554764, 100666399,
            "Mod", 129, "20020C0C0C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { "System.Single", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223278),
                new SourceMethodParameterDefinition("m", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223279)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 8, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GlassBlock", 33554764, 100666400,
            "AddSide", 129, "20030111808511808508", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("start", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223280),
                new SourceMethodParameterDefinition("normal", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223281),
                new SourceMethodParameterDefinition("tiles", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223282)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 126, 344));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GlassBlock", 33554764, 100666401,
            "Open", 129, "200102118085", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("tile", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223283)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 34, 89));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GlassBlock", 33554764, 100666402,
            "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 30, 93));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GlassBlock+Line", 33555420,
            100671299, ".ctor", 6278, "200201118085118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134227558),
                new SourceMethodParameterDefinition("b", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134227559)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 7, 15));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GoldenBlock", 33554765,
            100666403, ".ctor", 6278, "2003011180850C0C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223284),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223285),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134223286)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 90, 223));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GoldenBlock", 33554765,
            100666404, ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223287),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223288)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 33));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GoldenBlock", 33554765,
            100666405, "Awake", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223289)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 46, 121));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GoldenBlock", 33554765,
            100666406, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 96, 301));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GoldenBlock", 33554765,
            100666407, "DrawBlock", 129, "20020111808511808D", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Color" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("offset", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223290),
                new SourceMethodParameterDefinition("color", 1, 0, "Microsoft.Xna.Framework.Color", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Color"), 2, 134223291)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 84, 176));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GoldenBlock", 33554765,
            100666408, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 76, 266));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.IceBlock", 33554766, 100666409,
            ".ctor", 6278, "2003011180850C0C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223292),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223293),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134223294)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 74, 256));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.IceBlock", 33554766, 100666410,
            ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223295),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223296)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 33));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.IceBlock", 33554766, 100666411,
            "Added", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223297)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 40, 113));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.IceBlock", 33554766, 100666412,
            "OnChangeMode", 129, "200101119B70", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Session+CoreModes" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("mode", 0, 0, "Celeste.Session+CoreModes", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Session+CoreModes"), 1, 134223298)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 77, 204));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.IceBlock", 33554766, 100666413,
            "OnPlayer", 129, "200101128DF8", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223299)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 32));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.IceBlock", 33554766, 100666414,
            "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 15));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666415, ".ctor", 6278, "20020111808502", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223300),
                new SourceMethodParameterDefinition("flipX", 1, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134223301)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 93, 296));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666416, ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("e", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223302),
                new SourceMethodParameterDefinition("levelOffset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223303)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 35, 103));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666417, "Awake", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223304)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 36, 120));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666418, "Dashed", 134, "2002118DE8128DF8118085", new KeyValuePair<string, string>[] { },
            "Celeste.DashCollisionResults", new string[] { "Celeste.Player", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223305),
                new SourceMethodParameterDefinition("dir", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223306)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.DashCollisionResults"), true, 155, 459));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666419, "SmashParticles", 129, "200101118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("dir", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223307)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 134, 414));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666420, "Added", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223308)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 16, 50));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666421, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 168, 560));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666422, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 20, 64));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666423, "Pulse", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 36));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666424, "Break", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 118, 373));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LightningBreakerBox", 33554767,
            100666425, "<.ctor>b__23_0", 129, "2001010E",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("anim", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223309)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 16, 42));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666426,
            ".ctor", 6278, "2002011180851D118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2[]" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223310),
                new SourceMethodParameterDefinition("nodes", 1, 0, "Microsoft.Xna.Framework.Vector2[]", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 2,
                    134223311)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 22, 71));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666427,
            ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223312),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223313)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 10, 26));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666428,
            "Added", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223314)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 98, 315));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666429,
            "SceneEnd", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223315)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666430,
            "Removed", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223316)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666431,
            "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 22, 76));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666432,
            "OnPlayer", 129, "200101128DF8", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223317)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 25, 71));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666433,
            "CollectRoutine", 129, "20011280B5128DF8",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002643656C657374652E43617373657474652B3C436F6C6C656374526F7574696E653E645F5F31390000")
            }, "System.Collections.IEnumerator", new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223318)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 9, 21));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666434,
            "<Added>b__14_0", 129, "2001010C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("f", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223319)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 35));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette", 33554768, 100666435,
            "<Added>b__14_1", 129, "2001010C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("f", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223320)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 19, 47));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+UnlockedBSide",
            33555421, 100671300, "Added", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134227560)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 22, 78));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+UnlockedBSide",
            33555421, 100671301, "EaseIn", 134, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002B43656C657374652E43617373657474652B556E6C6F636B656442536964652B3C45617365496E3E645F5F350000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+UnlockedBSide",
            33555421, 100671302, "EaseOut", 134, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002C43656C657374652E43617373657474652B556E6C6F636B656442536964652B3C456173654F75743E645F5F360000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+UnlockedBSide",
            33555421, 100671303, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 25));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+UnlockedBSide",
            33555421, 100671304, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 81, 308));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+UnlockedBSide",
            33555421, 100671305, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseIn>d__5", 33556349, 100675482, ".ctor", 6278, "20010108",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("<>1__state", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134228672)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseIn>d__5", 33556349, 100675483, "System.IDisposable.Dispose", 481,
            "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseIn>d__5", 33556349, 100675484, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 61, 159));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseIn>d__5", 33556349, 100675485,
            "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseIn>d__5", 33556349, 100675486, "System.Collections.IEnumerator.Reset",
            481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseIn>d__5", 33556349, 100675487,
            "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseOut>d__6", 33556350, 100675488, ".ctor", 6278, "20010108",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("<>1__state", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134228673)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseOut>d__6", 33556350, 100675489, "System.IDisposable.Dispose", 481,
            "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseOut>d__6", 33556350, 100675490, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 51, 115));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseOut>d__6", 33556350, 100675491,
            "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseOut>d__6", 33556350, 100675492, "System.Collections.IEnumerator.Reset",
            481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Cassette+UnlockedBSide+<EaseOut>d__6", 33556350, 100675493,
            "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+<CollectRoutine>d__19",
            33555422, 100671306, ".ctor", 6278, "20010108",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("<>1__state", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134227561)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+<CollectRoutine>d__19",
            33555422, 100671307, "System.IDisposable.Dispose", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+<CollectRoutine>d__19",
            33555422, 100671308, "MoveNext", 481, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 525, 1713));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+<CollectRoutine>d__19",
            33555422, 100671309, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+<CollectRoutine>d__19",
            33555422, 100671310, "System.Collections.IEnumerator.Reset", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cassette+<CollectRoutine>d__19",
            33555422, 100671311, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StrawberryPoints", 33554769,
            100666436, ".ctor", 6278, "200401118085020802", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Boolean", "System.Int32", "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223321),
                new SourceMethodParameterDefinition("ghostberry", 1, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134223322),
                new SourceMethodParameterDefinition("index", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223323),
                new SourceMethodParameterDefinition("moonberry", 3, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 4, 134223324)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 58, 173));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StrawberryPoints", 33554769,
            100666437, "Added", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223325)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 86, 268));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StrawberryPoints", 33554769,
            100666438, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 146, 474));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StrawberryPoints", 33554769,
            100666439, "<Added>b__8_0", 129, "2001010E",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223326)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem", 33554770, 100666440,
            ".ctor", 6278, "200301128DBC118085118C68", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2", "Celeste.EntityID" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223327),
                new SourceMethodParameterDefinition("position", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223328),
                new SourceMethodParameterDefinition("gid", 2, 0, "Celeste.EntityID", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityID"), 3, 134223329)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 108, 356));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem", 33554770, 100666441,
            "OnPlayer", 129, "200101128DF8", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223330)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 51, 157));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem", 33554770, 100666442,
            "SmashRoutine", 129, "20021280B5128DF8128DCC",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002543656C657374652E53756D6D697447656D2B3C536D617368526F7574696E653E645F5F31310000")
            }, "System.Collections.IEnumerator", new string[] { "Celeste.Player", "Celeste.Level" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223331),
                new SourceMethodParameterDefinition("level", 1, 0, "Celeste.Level", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Level"), 2, 134223332)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 12, 28));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem", 33554770, 100666443,
            "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 20, 68));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem", 33554770, 100666444,
            ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 34, 114));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem", 33554770, 100666445,
            "<.ctor>b__9_0", 129, "2001010C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("f", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223333)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 35));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem+BgFlash", 33555423,
            100671312, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 45));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem+BgFlash", 33555423,
            100671313, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 18, 59));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem+BgFlash", 33555423,
            100671314, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 22, 78));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem+<SmashRoutine>d__11",
            33555424, 100671315, ".ctor", 6278, "20010108",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("<>1__state", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134227562)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem+<SmashRoutine>d__11",
            33555424, 100671316, "System.IDisposable.Dispose", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem+<SmashRoutine>d__11",
            33555424, 100671317, "MoveNext", 481, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 159, 493));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem+<SmashRoutine>d__11",
            33555424, 100671318, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem+<SmashRoutine>d__11",
            33555424, 100671319, "System.Collections.IEnumerator.Reset", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SummitGem+<SmashRoutine>d__11",
            33555424, 100671320, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BadelineAutoAnimator", 33554771,
            100666446, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BadelineAutoAnimator", 33554771,
            100666447, "Added", 198, "200101128418", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134223334)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 19, 52));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BadelineAutoAnimator", 33554771,
            100666448, "Removed", 198, "200101128418", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134223335)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BadelineAutoAnimator", 33554771,
            100666449, "SetReturnToAnimation", 134, "2001010E", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("anim", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223336)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BadelineAutoAnimator", 33554771,
            100666450, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 136, 374));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BadelineAutoAnimator", 33554771,
            100666451, "<Added>b__5_0", 129, "2001010C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("f", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223337)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 22, 67));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClimbBlocker", 33554772,
            100666452, ".ctor", 6278, "20010102", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("edge", 0, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134223338)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClimbBlocker", 33554772,
            100666453, "Check", 150, "000302128478128418118085", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Monocle.Scene", "Monocle.Entity", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223339),
                new SourceMethodParameterDefinition("entity", 1, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 2, 134223340),
                new SourceMethodParameterDefinition("at", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134223341)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 13, 29));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClimbBlocker", 33554772,
            100666454, "Check", 150, "000202128478128418", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Scene", "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223342),
                new SourceMethodParameterDefinition("entity", 1, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 2, 134223343)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 33, 87));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClimbBlocker", 33554772,
            100666455, "EdgeCheck", 150, "00030212847812841808", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Monocle.Scene", "Monocle.Entity", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223344),
                new SourceMethodParameterDefinition("entity", 1, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 2, 134223345),
                new SourceMethodParameterDefinition("dir", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223346)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 43, 118));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CoreModeListener", 33554773,
            100666456, ".ctor", 6278, "200101151280A901119B70", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Action`1<Celeste.Session+CoreModes>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("onChange", 0, 0, "System.Action`1<Celeste.Session+CoreModes>",
                    false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Action`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Celeste.Session+CoreModes")
                        }), 1, 134223347)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DeathEffect", 33554774,
            100666457, ".ctor", 6278, "20020111808D1511808901118085", new KeyValuePair<string, string>[] { },
            "System.Void",
            new string[] { "Microsoft.Xna.Framework.Color", "System.Nullable`1<Microsoft.Xna.Framework.Vector2>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("color", 0, 0, "Microsoft.Xna.Framework.Color", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Color"), 1, 134223348),
                new SourceMethodParameterDefinition("offset", 1, 4112,
                    "System.Nullable`1<Microsoft.Xna.Framework.Vector2>", true, null,
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Nullable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                                typeIdentity: "Microsoft.Xna.Framework.Vector2")
                        }), 2, 134223349)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 23, 67));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DeathEffect", 33554774,
            100666458, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 33, 104));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DeathEffect", 33554774,
            100666459, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DeathEffect", 33554774,
            100666460, "Draw", 150, "00030111808511808D0C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Color", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223350),
                new SourceMethodParameterDefinition("color", 1, 0, "Microsoft.Xna.Framework.Color", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Color"), 2, 134223351),
                new SourceMethodParameterDefinition("ease", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134223352)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 150, 440));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GrannyLaughSfx", 33554775,
            100666461, ".ctor", 6278, "2001011283D0", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Sprite" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("sprite", 0, 0, "Monocle.Sprite", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Sprite"), 1, 134223353)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.GrannyLaughSfx", 33554775,
            100666462, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 50, 158));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666463,
            "get_SurfaceStep", 2182, "200008",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Int32", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666464,
            "set_SurfaceStep", 2177, "20010108",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223354)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666465,
            "get_Width", 2182, "20000C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Single", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666466,
            "set_Width", 2177, "2001010C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223355)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666467,
            "get_Height", 2182, "20000C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Single", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666468,
            "set_Height", 2177, "2001010C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223356)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666469,
            ".ctor", 6278, "2003010C0C08", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single", "System.Single", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("width", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223357),
                new SourceMethodParameterDefinition("height", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223358),
                new SourceMethodParameterDefinition("step", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223359)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 39, 127));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666470,
            "Resize", 134, "2003010C0C08", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single", "System.Single", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("width", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223360),
                new SourceMethodParameterDefinition("height", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223361),
                new SourceMethodParameterDefinition("step", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223362)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 142, 381));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666471,
            "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 186, 557));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666472,
            "Sin", 129, "20010C0C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223363)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 9, 21));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666473,
            "Wave", 129, "20020C080C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { "System.Int32", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("step", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223364),
                new SourceMethodParameterDefinition("length", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223365)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 91, 203));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LavaRect", 33554776, 100666474,
            "Quad", 129, "200601100811808511808511808511808511808D", new KeyValuePair<string, string>[] { },
            "System.Void",
            new string[]
            {
                "System.Int32&", "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Color"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("vert", 0, 0, "System.Int32&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Int32")), 1, 134223366),
                new SourceMethodParameterDefinition("va", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223367),
                new SourceMethodParameterDefinition("vb", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134223368),
                new SourceMethodParameterDefinition("vc", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 4, 134223369),
                new SourceMethodParameterDefinition("vd", 4, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 5, 134223370),
                new SourceMethodParameterDefinition("color", 5, 0, "Microsoft.Xna.Framework.Color", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Color"), 6, 134223371)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 22));
    }
}
