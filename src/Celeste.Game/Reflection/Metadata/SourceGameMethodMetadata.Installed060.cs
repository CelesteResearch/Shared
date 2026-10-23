using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Game.Reflection.Metadata;

public static partial class SourceGameMethodMetadata
{
    private static void PublishInstalled060(SourceAssemblyMethodCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterBlock", 33555917,
            100672897, "WeightDown", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 23, 74));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterBlock", 33555917,
            100672898, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 154, 438));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterBlock", 33555917,
            100672899, "get_WaveTarget", 2177, "20000C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 25, 62));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterBlock", 33555917,
            100672900, "Absorb", 134, "200101129760", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.ClutterAbsorbEffect" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("effect", 0, 0, "Celeste.ClutterAbsorbEffect", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.ClutterAbsorbEffect"), 1, 134226895)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 31, 103));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterBlockBase", 33555919,
            100672901, ".ctor", 6278, "2005011180A1080802119738", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "System.Int32", "System.Int32", "System.Boolean",
                "Celeste.ClutterBlock+Colors"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134226896),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134226897),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134226898),
                new SourceMethodParameterDefinition("enabled", 3, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 4, 134226899),
                new SourceMethodParameterDefinition("blockColor", 4, 0, "Celeste.ClutterBlock+Colors", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.ClutterBlock+Colors"), 5, 134226900)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 62, 147));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterBlockBase", 33555919,
            100672902, "Deactivate", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 20, 53));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterBlockBase", 33555919,
            100672903, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 20, 50));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterBlockBase", 33555919,
            100672904, ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 41));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor", 33555920,
            100672905, ".ctor", 6278, "200301129E781180A1129BD8", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2", "Celeste.Session" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134226901),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134226902),
                new SourceMethodParameterDefinition("session", 2, 0, "Celeste.Session", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Session"), 3, 134226903)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 79, 239));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor", 33555920,
            100672906, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 45, 123));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor", 33555920,
            100672907, "IsLocked", 134, "200102129BD8", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Celeste.Session" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("session", 0, 0, "Celeste.Session", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Session"), 1, 134226904)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 10, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor", 33555920,
            100672908, "IsComplete", 134, "200102129BD8", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Celeste.Session" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("session", 0, 0, "Celeste.Session", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Session"), 1, 134226905)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 8, 28));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor", 33555920,
            100672909, "UnlockRoutine", 134, "2000128109",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002743656C657374652E436C7574746572446F6F722B3C556E6C6F636B526F7574696E653E645F5F370000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor", 33555920,
            100672910, "InstantUnlock", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 17));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor", 33555920,
            100672911, "CameraTarget", 129, "20001180A1", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Vector2", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Vector2"), true, 52, 154));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor", 33555920,
            100672912, "OnDashed", 129, "2002119F14129F241180A1", new KeyValuePair<string, string>[] { },
            "Celeste.DashCollisionResults", new string[] { "Celeste.Player", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134226906),
                new SourceMethodParameterDefinition("direction", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134226907)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.DashCollisionResults"), true, 10, 30));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor", 33555920,
            100672913, "<.ctor>b__3_0", 129, "2001010C",
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
                        typeIdentity: "System.Single"), 1, 134226908)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 35));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor+<UnlockRoutine>d__7",
            33555921, 100672914, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134226909)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor+<UnlockRoutine>d__7",
            33555921, 100672915, "System.IDisposable.Dispose", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor+<UnlockRoutine>d__7",
            33555921, 100672916, "MoveNext", 481, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 140, 422));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor+<UnlockRoutine>d__7",
            33555921, 100672917, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor+<UnlockRoutine>d__7",
            33555921, 100672918, "System.Collections.IEnumerator.Reset", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterDoor+<UnlockRoutine>d__7",
            33555921, 100672919, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterSwitch", 33555922,
            100672920, ".ctor", 6278, "2002011180A1119738", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Celeste.ClutterBlock+Colors" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134226910),
                new SourceMethodParameterDefinition("color", 1, 0, "Celeste.ClutterBlock+Colors", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.ClutterBlock+Colors"), 2, 134226911)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 96, 306));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterSwitch", 33555922,
            100672921, ".ctor", 6278, "200201129E781180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134226912),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134226913)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 31));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterSwitch", 33555922,
            100672922, "Added", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226914)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 29, 92));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterSwitch", 33555922,
            100672923, "BePressed", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 41, 129));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterSwitch", 33555922,
            100672924, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 106, 340));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterSwitch", 33555922,
            100672925, "OnDashed", 129, "2002119F14129F241180A1", new KeyValuePair<string, string>[] { },
            "Celeste.DashCollisionResults", new string[] { "Celeste.Player", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134226915),
                new SourceMethodParameterDefinition("direction", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134226916)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.DashCollisionResults"), true, 82, 289));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterSwitch", 33555922,
            100672926, "LightningRoutine", 129, "2001128109129F24",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002D43656C657374652E436C75747465725377697463682B3C4C696768746E696E67526F7574696E653E645F5F32350000")
            }, "System.Collections.IEnumerator", new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134226917)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterSwitch", 33555922,
            100672927, "AbsorbRoutine", 129, "2001128109129F24",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002A43656C657374652E436C75747465725377697463682B3C4162736F7262526F7574696E653E645F5F32360000")
            }, "System.Collections.IEnumerator", new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134226918)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 9, 21));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterSwitch", 33555922,
            100672928, "Removed", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226919)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 16, 44));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<LightningRoutine>d__25", 33555923, 100672929, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134226920)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<LightningRoutine>d__25", 33555923, 100672930, "System.IDisposable.Dispose", 481,
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
            "Celeste.ClutterSwitch+<LightningRoutine>d__25", 33555923, 100672931, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 55, 133));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<LightningRoutine>d__25", 33555923, 100672932,
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
            "Celeste.ClutterSwitch+<LightningRoutine>d__25", 33555923, 100672933,
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
            "Celeste.ClutterSwitch+<LightningRoutine>d__25", 33555923, 100672934,
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
            "Celeste.ClutterSwitch+<>c__DisplayClass26_0", 33555924, 100672935, ".ctor", 6278, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<>c__DisplayClass26_0", 33555924, 100672936, "<AbsorbRoutine>b__0", 131, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 7, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<>c__DisplayClass26_0", 33555924, 100672937, "<AbsorbRoutine>b__1", 131, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 33, 106));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<>c__DisplayClass26_1", 33555925, 100672938, ".ctor", 6278, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<>c__DisplayClass26_1", 33555925, 100672939, "<AbsorbRoutine>b__2", 131,
            "200101128450", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { "Monocle.Tween" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("t", 0, 0, "Monocle.Tween", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Tween"), 1, 134226921)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 44));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<>c__DisplayClass26_2", 33555926, 100672940, ".ctor", 6278, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<>c__DisplayClass26_2", 33555926, 100672941, "<AbsorbRoutine>b__3", 131,
            "200101128450", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { "Monocle.Tween" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("t", 0, 0, "Monocle.Tween", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Tween"), 1, 134226922)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 50, 178));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<AbsorbRoutine>d__26", 33555927, 100672942, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134226923)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<AbsorbRoutine>d__26", 33555927, 100672943, "System.IDisposable.Dispose", 481,
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
            "Celeste.ClutterSwitch+<AbsorbRoutine>d__26", 33555927, 100672944, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 373, 1184));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterSwitch+<AbsorbRoutine>d__26", 33555927, 100672945,
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
            "Celeste.ClutterSwitch+<AbsorbRoutine>d__26", 33555927, 100672946, "System.Collections.IEnumerator.Reset",
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
            "Celeste.ClutterSwitch+<AbsorbRoutine>d__26", 33555927, 100672947,
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
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterAbsorbEffect", 33555928,
            100672948, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 16, 56));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterAbsorbEffect", 33555928,
            100672949, "Added", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226924)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 31, 94));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterAbsorbEffect", 33555928,
            100672950, "FlyClutter", 134, "2004011180A1128478020C", new KeyValuePair<string, string>[] { },
            "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Monocle.MTexture", "System.Boolean", "System.Single" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134226925),
                new SourceMethodParameterDefinition("texture", 1, 0, "Monocle.MTexture", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.MTexture"), 2, 134226926),
                new SourceMethodParameterDefinition("shake", 2, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 3, 134226927),
                new SourceMethodParameterDefinition("delay", 3, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134226928)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 30, 71));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterAbsorbEffect", 33555928,
            100672951, "FlyClutterRoutine", 129, "20031281091283DC020C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01003343656C657374652E436C75747465724162736F72624566666563742B3C466C79436C7574746572526F7574696E653E645F5F350000")
            }, "System.Collections.IEnumerator", new string[] { "Monocle.Image", "System.Boolean", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("img", 0, 0, "Monocle.Image", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Image"), 1, 134226929),
                new SourceMethodParameterDefinition("shake", 1, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134226930),
                new SourceMethodParameterDefinition("delay", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134226931)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 15, 35));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterAbsorbEffect", 33555928,
            100672952, "CloseCabinets", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterAbsorbEffect", 33555928,
            100672953, "CloseCabinetsRoutine", 129, "2000128109",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01003643656C657374652E436C75747465724162736F72624566666563742B3C436C6F7365436162696E657473526F7574696E653E645F5F370000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterAbsorbEffect+<FlyClutterRoutine>d__5", 33555929, 100672954, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134226932)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterAbsorbEffect+<FlyClutterRoutine>d__5", 33555929, 100672955, "System.IDisposable.Dispose",
            481, "200001",
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
            "Celeste.ClutterAbsorbEffect+<FlyClutterRoutine>d__5", 33555929, 100672956, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 242, 771));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterAbsorbEffect+<FlyClutterRoutine>d__5", 33555929, 100672957,
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
            "Celeste.ClutterAbsorbEffect+<FlyClutterRoutine>d__5", 33555929, 100672958,
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
            "Celeste.ClutterAbsorbEffect+<FlyClutterRoutine>d__5", 33555929, 100672959,
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
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterAbsorbEffect+<>c",
            33555930, 100672960, ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 11));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterAbsorbEffect+<>c",
            33555930, 100672961, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ClutterAbsorbEffect+<>c",
            33555930, 100672962, "<CloseCabinetsRoutine>b__7_0", 131, "2002081295C41295C4",
            new KeyValuePair<string, string>[] { }, "System.Int32",
            new string[] { "Celeste.ClutterCabinet", "Celeste.ClutterCabinet" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Celeste.ClutterCabinet", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.ClutterCabinet"), 1, 134226933),
                new SourceMethodParameterDefinition("b", 1, 0, "Celeste.ClutterCabinet", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.ClutterCabinet"), 2, 134226934)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 22, 63));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterAbsorbEffect+<CloseCabinetsRoutine>d__7", 33555931, 100672963, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134226935)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterAbsorbEffect+<CloseCabinetsRoutine>d__7", 33555931, 100672964, "System.IDisposable.Dispose",
            481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 27));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterAbsorbEffect+<CloseCabinetsRoutine>d__7", 33555931, 100672965, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 87, 230));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterAbsorbEffect+<CloseCabinetsRoutine>d__7", 33555931, 100672966, "<>m__Finally1", 129,
            "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 25));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.ClutterAbsorbEffect+<CloseCabinetsRoutine>d__7", 33555931, 100672967,
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
            "Celeste.ClutterAbsorbEffect+<CloseCabinetsRoutine>d__7", 33555931, 100672968,
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
            "Celeste.ClutterAbsorbEffect+<CloseCabinetsRoutine>d__7", 33555931, 100672969,
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
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashListener", 33555932,
            100672970, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 5, 9));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashListener", 33555932,
            100672971, ".ctor", 6278, "2001011512814D011180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Action`1<Microsoft.Xna.Framework.Vector2>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("onDash", 0, 0, "System.Action`1<Microsoft.Xna.Framework.Vector2>",
                    false, null, new byte[] { },
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Action`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Microsoft.Xna.Framework.Vector2")
                        }), 1, 134226936)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LedgeBlocker", 33555933,
            100672972, ".ctor", 6278, "2001011512833502129F2402", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Func`2<Celeste.Player,System.Boolean>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("blockChecker", 0, 4112,
                    "System.Func`2<Celeste.Player,System.Boolean>", true, null, new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Func`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Celeste.Player"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                typeIdentity: "System.Boolean")
                        }), 1, 134226937)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LedgeBlocker", 33555933,
            100672973, "HopBlockCheck", 134, "200102129F24", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134226938)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 30, 85));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LedgeBlocker", 33555933,
            100672974, "JumpThruBoostCheck", 134, "200102129F24", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134226939)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 26, 73));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LedgeBlocker", 33555933,
            100672975, "DashCorrectCheck", 134, "200102129F24", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134226940)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 22, 53));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672976, "get_Estableshed", 2182, "200002",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672977, "set_Estableshed", 2177, "20010102",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134226941)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672978, "get_RenderPosition", 2182, "20001180A1", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Vector2", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Vector2"), true, 10, 34));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672979, "get_InView", 2177, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 50, 133));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672980, ".ctor", 6278, "200301020202", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Boolean", "System.Boolean", "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("ignoreSolids", 0, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134226942),
                new SourceMethodParameterDefinition("autoControlEyes", 1, 4112, "System.Boolean", true,
                    "System.Boolean", new byte[] { 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134226943),
                new SourceMethodParameterDefinition("autoExpandDust", 2, 4112, "System.Boolean", true, "System.Boolean",
                    new byte[] { 0x00 }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 3, 134226944)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 94, 315));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672981, "Added", 198, "20010112846C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134226945)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 21, 63));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672982, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 178, 548));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672983, "OnHitPlayer", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 26, 80));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672984, "AddDustNodesIfInCamera", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 397, 1167));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672985, "AddNode", 129, "2002011180A102", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("angle", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134226946),
                new SourceMethodParameterDefinition("enabled", 1, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134226947)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 205, 567));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672986, "BlinkRoutine", 129, "2000128109",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002743656C657374652E44757374477261706869632B3C426C696E6B526F7574696E653E645F5F34350000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672987, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 67, 207));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic", 33555934,
            100672988, "<Added>b__40_0", 129, "2001010C",
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
                        typeIdentity: "System.Single"), 1, 134226948)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+Node", 33555935,
            100672989, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+Eyeballs", 33555936,
            100672990, ".ctor", 6278, "200101129778", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.DustGraphic" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("dust", 0, 0, "Celeste.DustGraphic", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.DustGraphic"), 1, 134226949)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 14, 38));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+Eyeballs", 33555936,
            100672991, "Added", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226950)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 25));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+Eyeballs", 33555936,
            100672992, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 39));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+Eyeballs", 33555936,
            100672993, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 82, 312));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+<BlinkRoutine>d__45",
            33555937, 100672994, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134226951)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+<BlinkRoutine>d__45",
            33555937, 100672995, "System.IDisposable.Dispose", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+<BlinkRoutine>d__45",
            33555937, 100672996, "MoveNext", 481, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 72, 208));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+<BlinkRoutine>d__45",
            33555937, 100672997, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+<BlinkRoutine>d__45",
            33555937, 100672998, "System.Collections.IEnumerator.Reset", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustGraphic+<BlinkRoutine>d__45",
            33555937, 100672999, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SafeGroundBlocker", 33555938,
            100673000, ".ctor", 6278, "2001011283C4", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Collider" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("checkWith", 0, 4112, "Monocle.Collider", true, null,
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Collider"), 1, 134226952)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SafeGroundBlocker", 33555938,
            100673001, "Check", 134, "200102129F24", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134226953)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 26, 72));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SafeGroundBlocker", 33555938,
            100673002, "DebugRender", 198, "2001011285A4", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Camera" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("camera", 0, 0, "Monocle.Camera", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Camera"), 1, 134226954)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 23, 72));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673003, "get_Playing", 2182, "200002",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673004, "set_Playing", 2177, "20010102",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134226955)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673005, "get_Is3D", 2182, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673006, "get_IsOneshot", 2182, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673007, "get_InstancePlaying", 2182, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 22, 43));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673008, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 27));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673009, ".ctor", 6278, "2001010E", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("path", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134226956)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 21));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673010, ".ctor", 6278, "2002011180A10E", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("offset", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134226957),
                new SourceMethodParameterDefinition("path", 1, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 2, 134226958)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 28));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673011, "Added", 198, "20010112846C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134226959)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673012, "Play", 134, "200312978C0E0E0C", new KeyValuePair<string, string>[] { }, "Celeste.SoundSource",
            new string[] { "System.String", "System.String", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("path", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134226960),
                new SourceMethodParameterDefinition("param", 1, 4112, "System.String", true, null,
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 2, 134226961),
                new SourceMethodParameterDefinition("value", 2, 4112, "System.Single", true, "System.Single",
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134226962)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.SoundSource"), true, 70, 175));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673013, "Param", 134, "200212978C0E0C", new KeyValuePair<string, string>[] { }, "Celeste.SoundSource",
            new string[] { "System.String", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("param", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134226963),
                new SourceMethodParameterDefinition("value", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134226964)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.SoundSource"), true, 13, 30));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673014, "Pause", 134, "200012978C", new KeyValuePair<string, string>[] { }, "Celeste.SoundSource",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.SoundSource"), true, 15, 36));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673015, "Resume", 134, "200012978C", new KeyValuePair<string, string>[] { }, "Celeste.SoundSource",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.SoundSource"), true, 22, 53));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673016, "Stop", 134, "200112978C02", new KeyValuePair<string, string>[] { }, "Celeste.SoundSource",
            new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("allowFadeout", 0, 4112, "System.Boolean", true, "System.Boolean",
                    new byte[] { 0x01 }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134226965)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.SoundSource"), true, 12, 28));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673017, "UpdateSfxPosition", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 25, 68));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673018, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 34, 87));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673019, "EntityRemoved", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226966)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673020, "Removed", 198, "20010112846C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134226967)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673021, "SceneEnd", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226968)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SoundSource", 33555939,
            100673022, "DebugRender", 198, "2001011285A4", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Camera" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("camera", 0, 0, "Monocle.Camera", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Camera"), 1, 134226969)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 48, 148));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent", 33555940,
            100673023, ".ctor", 6278, "2004011180B11180A1151280F501129F24129794",
            new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Vector2",
                "System.Action`1<Celeste.Player>", "Celeste.TalkComponent+HoverDisplay"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("bounds", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134226970),
                new SourceMethodParameterDefinition("drawAt", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134226971),
                new SourceMethodParameterDefinition("onTalk", 2, 0, "System.Action`1<Celeste.Player>", false, null,
                    new byte[] { }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
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
                                typeIdentity: "Celeste.Player")
                        }), 3, 134226972),
                new SourceMethodParameterDefinition("hoverDisplay", 3, 4112, "Celeste.TalkComponent+HoverDisplay", true,
                    null, new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.TalkComponent+HoverDisplay"), 4, 134226973)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 39, 110));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent", 33555940,
            100673024, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 205, 601));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent", 33555940,
            100673025, "Removed", 198, "20010112846C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134226974)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent", 33555940,
            100673026, "EntityRemoved", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226975)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent", 33555940,
            100673027, "SceneEnd", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226976)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent", 33555940,
            100673028, "Dispose", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 14, 39));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent", 33555940,
            100673029, "DebugRender", 198, "2001011285A4", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Camera" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("camera", 0, 0, "Monocle.Camera", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Camera"), 1, 134226977)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 30, 90));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent+HoverDisplay",
            33555941, 100673030, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 29));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent+TalkComponentUI",
            33555942, 100673031, "get_Highlighted", 2182, "200002", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent+TalkComponentUI",
            33555942, 100673032, "set_Highlighted", 2182, "20010102", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134226978)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 33, 94));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent+TalkComponentUI",
            33555942, 100673033, "get_Display", 2182, "200002", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 46, 114));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent+TalkComponentUI",
            33555942, 100673034, ".ctor", 6278, "200101129790", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.TalkComponent" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("handler", 0, 0, "Celeste.TalkComponent", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.TalkComponent"), 1, 134226979)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 35, 111));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent+TalkComponentUI",
            33555942, 100673035, "Awake", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226980)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 48, 152));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent+TalkComponentUI",
            33555942, 100673036, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 86, 283));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TalkComponent+TalkComponentUI",
            33555942, 100673037, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 193, 630));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TileInterceptor", 33555943,
            100673038, ".ctor", 6278, "200201151284B5031284781180A11184B102", new KeyValuePair<string, string>[] { },
            "System.Void",
            new string[]
            {
                "System.Action`3<Monocle.MTexture,Microsoft.Xna.Framework.Vector2,Microsoft.Xna.Framework.Point>",
                "System.Boolean"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("intercepter", 0, 0,
                    "System.Action`3<Monocle.MTexture,Microsoft.Xna.Framework.Vector2,Microsoft.Xna.Framework.Point>",
                    false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Action`3"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.MTexture"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Microsoft.Xna.Framework.Vector2"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Microsoft.Xna.Framework.Point")
                        }), 1, 134226981),
                new SourceMethodParameterDefinition("highPriority", 1, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134226982)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TileInterceptor", 33555943,
            100673039, ".ctor", 6278, "20020112841C02", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.TileGrid", "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("applyToGrid", 0, 0, "Monocle.TileGrid", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.TileGrid"), 1, 134226983),
                new SourceMethodParameterDefinition("highPriority", 1, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134226984)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 18, 47));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TileInterceptor", 33555943,
            100673040, "TileCheck", 150, "0003021285881284781180A1", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Monocle.Scene", "Monocle.MTexture", "Microsoft.Xna.Framework.Vector2" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226985),
                new SourceMethodParameterDefinition("tile", 1, 0, "Monocle.MTexture", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.MTexture"), 2, 134226986),
                new SourceMethodParameterDefinition("at", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134226987)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 77, 183));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.TileInterceptor+<>c__DisplayClass3_0", 33555944, 100673041, ".ctor", 6278, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.TileInterceptor+<>c__DisplayClass3_0", 33555944, 100673042, "<.ctor>b__0", 131,
            "2003011284781180A11184B1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.MTexture", "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Point" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("t", 0, 0, "Monocle.MTexture", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.MTexture"), 1, 134226988),
                new SourceMethodParameterDefinition("v", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134226989),
                new SourceMethodParameterDefinition("p", 2, 0, "Microsoft.Xna.Framework.Point", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Point"), 3, 134226990)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 10, 30));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TransitionListener", 33555945,
            100673043, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 5, 9));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.WindMover", 33555946, 100673044,
            ".ctor", 6278, "200101151280F5011180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Action`1<Microsoft.Xna.Framework.Vector2>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("move", 0, 0, "System.Action`1<Microsoft.Xna.Framework.Vector2>",
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
                                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Microsoft.Xna.Framework.Vector2")
                        }), 1, 134226991)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673045,
            ".ctor", 6278, "2002011180A11D1180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2[]" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134226992),
                new SourceMethodParameterDefinition("patrolPoints", 1, 0, "Microsoft.Xna.Framework.Vector2[]", false,
                    null, new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Vector2"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 2,
                    134226993)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 55, 191));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673046,
            ".ctor", 6278, "200201129E781180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134226994),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134226995)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 10, 26));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673047,
            "Added", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226996)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673048,
            "Awake", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134226997)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 29, 79));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673049,
            "IsRiding", 198, "200102129F10", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Celeste.JumpThru" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("jumpThru", 0, 0, "Celeste.JumpThru", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.JumpThru"), 1, 134226998)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 2, 2));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673050,
            "IsRiding", 198, "200102129F20", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Celeste.Solid" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("solid", 0, 0, "Celeste.Solid", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Solid"), 1, 134226999)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 2, 2));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673051,
            "get_Attacking", 2182, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 12, 26));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673052,
            "get_Spotted", 2182, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 13, 31));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673053,
            "get_Regenerating", 2182, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 6, 15));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673054,
            "OnAttackPlayer", 129, "200101129F24", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134227000)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 44, 129));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673055,
            "OnBouncePlayer", 129, "200101129F24", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134227001)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 26, 64));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Seeker", 33555947, 100673056,
            "GotBouncedOn", 129, "20010112846C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134227002)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 37, 145));
    }
}
