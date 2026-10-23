using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Game.Reflection.Metadata;

public static partial class SourceGameMethodMetadata
{
    private static void PublishOriginal031(SourceAssemblyMethodCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<Cutscene>d__12",
            33555600, 100672274, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<StartMusic>d__13",
            33555601, 100672275, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134227740)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<StartMusic>d__13",
            33555601, 100672276, "System.IDisposable.Dispose", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<StartMusic>d__13",
            33555601, 100672277, "MoveNext", 481, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 42, 112));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<StartMusic>d__13",
            33555601, 100672278, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<StartMusic>d__13",
            33555601, 100672279, "System.Collections.IEnumerator.Reset", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<StartMusic>d__13",
            33555601, 100672280, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PlayerHug>d__14",
            33555602, 100672281, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134227741)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PlayerHug>d__14",
            33555602, 100672282, "System.IDisposable.Dispose", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PlayerHug>d__14",
            33555602, 100672283, "MoveNext", 481, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 109, 334));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PlayerHug>d__14",
            33555602, 100672284, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PlayerHug>d__14",
            33555602, 100672285, "System.Collections.IEnumerator.Reset", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PlayerHug>d__14",
            33555602, 100672286, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
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
            "Celeste.CS06_BossEnd+<BadelineCalmDown>d__15", 33555603, 100672287, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134227742)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS06_BossEnd+<BadelineCalmDown>d__15", 33555603, 100672288, "System.IDisposable.Dispose", 481,
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
            "Celeste.CS06_BossEnd+<BadelineCalmDown>d__15", 33555603, 100672289, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 93, 284));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS06_BossEnd+<BadelineCalmDown>d__15", 33555603, 100672290,
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
            "Celeste.CS06_BossEnd+<BadelineCalmDown>d__15", 33555603, 100672291, "System.Collections.IEnumerator.Reset",
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
            "Celeste.CS06_BossEnd+<BadelineCalmDown>d__15", 33555603, 100672292,
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
            "Celeste.CS06_BossEnd+<CenterCameraOnPlayer>d__16", 33555604, 100672293, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134227743)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS06_BossEnd+<CenterCameraOnPlayer>d__16", 33555604, 100672294, "System.IDisposable.Dispose", 481,
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
            "Celeste.CS06_BossEnd+<CenterCameraOnPlayer>d__16", 33555604, 100672295, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 99, 300));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS06_BossEnd+<CenterCameraOnPlayer>d__16", 33555604, 100672296,
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
            "Celeste.CS06_BossEnd+<CenterCameraOnPlayer>d__16", 33555604, 100672297,
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
            "Celeste.CS06_BossEnd+<CenterCameraOnPlayer>d__16", 33555604, 100672298,
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
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PictureFade>d__17",
            33555605, 100672299, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134227744)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PictureFade>d__17",
            33555605, 100672300, "System.IDisposable.Dispose", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PictureFade>d__17",
            33555605, 100672301, "MoveNext", 481, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 47, 103));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PictureFade>d__17",
            33555605, 100672302, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PictureFade>d__17",
            33555605, 100672303, "System.Collections.IEnumerator.Reset", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS06_BossEnd+<PictureFade>d__17",
            33555605, 100672304, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
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
            "Celeste.CS06_BossEnd+<WaitForPress>d__18", 33555606, 100672305, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134227745)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS06_BossEnd+<WaitForPress>d__18", 33555606, 100672306, "System.IDisposable.Dispose", 481,
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
            "Celeste.CS06_BossEnd+<WaitForPress>d__18", 33555606, 100672307, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 39, 83));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CS06_BossEnd+<WaitForPress>d__18", 33555606, 100672308,
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
            "Celeste.CS06_BossEnd+<WaitForPress>d__18", 33555606, 100672309, "System.Collections.IEnumerator.Reset",
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
            "Celeste.CS06_BossEnd+<WaitForPress>d__18", 33555606, 100672310,
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
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BladeRotateSpinner", 33554839,
            100666920, ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223741),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223742)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 27, 76));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BladeRotateSpinner", 33554839,
            100666921, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 30, 104));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666922, "get_Angle", 2182, "20000C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 8, 28));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666923, "get_Clockwise", 2182, "200002",
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
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666924, "set_Clockwise", 2177, "20010102",
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
                        typeIdentity: "System.Boolean"), 1, 134223743)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666925, ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223744),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223745)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 104, 331));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666926, "Easer", 129, "20010C0C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("v", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223746)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 2, 2));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666927, "EaserInverse", 129, "20010C0C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("v", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223747)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 2, 2));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666928, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 76, 222));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666929, "OnPlayer", 454, "200101128DF8", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223748)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666930, "<.ctor>b__12_0", 129, "200102128DF4",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Boolean", new string[] { "Celeste.Solid" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("s", 0, 0, "Celeste.Solid", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Solid"), 1, 134223749)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666931, "<.ctor>b__12_1", 129, "200102128DE4",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Boolean", new string[] { "Celeste.JumpThru" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("jt", 0, 0, "Celeste.JumpThru", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.JumpThru"), 1, 134223750)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666932, "<.ctor>b__12_2", 129, "200101118085",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("v", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223751)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 37));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.RotateSpinner", 33554840,
            100666933, "<.ctor>b__12_3", 129, "200001",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SeekerStatue", 33554841,
            100666934, ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223752),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223753)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 52, 161));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SeekerStatue", 33554841,
            100666935, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 70, 202));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.SeekerStatue", 33554841,
            100666936, "BreakOutParticles", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 36, 104));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.SeekerStatue+<>c__DisplayClass3_0", 33555608, 100672311, ".ctor", 6278, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.SeekerStatue+<>c__DisplayClass3_0", 33555608, 100672312, "<.ctor>b__0", 131, "2001010E",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("f", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134227746)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 23, 76));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666937, ".ctor", 6278, "20030111808502118668", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Boolean", "Celeste.CrystalColor" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223754),
                new SourceMethodParameterDefinition("attachToSolid", 1, 0, "System.Boolean", false, null,
                    new byte[] { }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134223755),
                new SourceMethodParameterDefinition("color", 2, 0, "Celeste.CrystalColor", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.CrystalColor"), 3, 134223756)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 89, 287));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666938, ".ctor", 6278, "200301128DBC118085118668", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2", "Celeste.CrystalColor" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223757),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223758),
                new SourceMethodParameterDefinition("color", 2, 0, "Celeste.CrystalColor", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.CrystalColor"), 3, 134223759)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 32));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666939, "Awake", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223760)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 32, 89));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666940, "ForceInstantiate", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666941, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 95, 283));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666942, "UpdateHue", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 63, 170));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666943, "InView", 129, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 40, 112));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666944, "CreateSprites", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 207, 651));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666945, "AddSprite", 129, "200101118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("offset", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223761)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 67, 189));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666946, "SolidCheck", 129, "200102118085", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223762)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 31, 77));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666947, "ClearSprites", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 40, 110));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666948, "OnShake", 129, "200101118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("pos", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223763)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 25, 62));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666949, "IsRiding", 129, "200102128DF4", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Celeste.Solid" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("solid", 0, 0, "Celeste.Solid", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Solid"), 1, 134223764)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666950, "OnPlayer", 129, "200101128DF8", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223765)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 32));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666951, "OnHoldable", 129, "200101128DE0", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Holdable" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("h", 0, 0, "Celeste.Holdable", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Holdable"), 1, 134223766)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666952, "Removed", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223767)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 26, 74));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666953, "Destroy", 134, "20010102", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("boss", 0, 4112, "System.Boolean", true, "System.Boolean",
                    new byte[] { 0x00 }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134223768)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 41, 115));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666954, "GetHue", 129, "200111808D118085", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Color", new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223769)
            }, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Color"), true, 25, 70));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner", 33554843,
            100666955, ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 37, 117));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrystalStaticSpinner+CoreModeListener", 33555609, 100672313, ".ctor", 6278, "20010112866C",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { "Celeste.CrystalStaticSpinner" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("parent", 0, 0, "Celeste.CrystalStaticSpinner", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.CrystalStaticSpinner"), 1, 134227747)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrystalStaticSpinner+CoreModeListener", 33555609, 100672314, "Update", 198, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 41, 119));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner+Border",
            33555610, 100672315, ".ctor", 6278, "200201128418128418", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Monocle.Entity", "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("parent", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134227748),
                new SourceMethodParameterDefinition("filler", 1, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 2, 134227749)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 23, 51));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner+Border",
            33555610, 100672316, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 20, 45));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrystalStaticSpinner+Border",
            33555610, 100672317, "DrawBorder", 129, "200101128418", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134227750)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 75, 234));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666956, "get_Start", 2182, "2000118085",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "Microsoft.Xna.Framework.Vector2", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Vector2"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666957, "set_Start", 2177, "200101118085",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223770)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666958, "get_End", 2182, "2000118085",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "Microsoft.Xna.Framework.Vector2", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Vector2"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666959, "set_End", 2177, "200101118085",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223771)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666960, "get_Percent", 2182, "20000C",
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
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666961, "set_Percent", 2177, "2001010C",
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
                        typeIdentity: "System.Single"), 1, 134223772)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666962, ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223773),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223774)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 85, 261));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666963, "UpdatePosition", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666964, "Awake", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223775)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666965, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 71, 207));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666966, "OnPlayer", 454, "200101128DF8", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223776)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666967, "OnTrackStart", 454, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666968, "OnTrackEnd", 454, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner", 33554844,
            100666969, ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 45));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666970,
            ".ctor", 6278, "2007011180851D118085080C020202", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2[]", "System.Int32", "System.Single",
                "System.Boolean", "System.Boolean", "System.Boolean"
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
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223777),
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
                    134223778),
                new SourceMethodParameterDefinition("patternIndex", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223779),
                new SourceMethodParameterDefinition("cameraYPastMax", 3, 0, "System.Single", false, null,
                    new byte[] { }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134223780),
                new SourceMethodParameterDefinition("dialog", 4, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 5, 134223781),
                new SourceMethodParameterDefinition("startHit", 5, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 6, 134223782),
                new SourceMethodParameterDefinition("cameraLockY", 6, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 7, 134223783)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 147, 385));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666971,
            ".ctor", 6278, "200201128DBC118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("e", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223784),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223785)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 30, 90));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666972,
            "Added", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223786)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 167, 578));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666973,
            "Awake", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223787)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 40, 136));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666974,
            "CreateBossSprite", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 46, 137));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666975,
            "get_BeamOrigin", 2182, "2000118085", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Vector2", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Vector2"), true, 11, 43));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666976,
            "get_ShotOrigin", 2182, "2000118085", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Vector2", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Vector2"), true, 16, 60));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666977,
            "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 212, 637));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666978,
            "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 52, 170));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666979,
            "OnPlayer", 134, "200101128DF8", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223788)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 242, 809));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666980,
            "MoveSequence", 129, "20021280B5128DF802",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002543656C657374652E46696E616C426F73732B3C4D6F766553657175656E63653E645F5F34320000")
            }, "System.Collections.IEnumerator", new string[] { "Celeste.Player", "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223789),
                new SourceMethodParameterDefinition("lastHit", 1, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134223790)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 12, 28));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666981,
            "PushPlayer", 129, "200101128DF8", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223791)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 63, 194));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666982,
            "TriggerFallingBlocks", 129, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("leftOfX", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223792)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 56, 150));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666983,
            "TriggerMovingBlocks", 129, "20010108", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("nodeIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223793)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 39, 96));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666984,
            "DestroyMovingBlocks", 129, "20010108", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("nodeIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223794)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 31, 83));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666985,
            "StartAttacking", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 90, 330));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666986,
            "StartShootCharge", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 14, 42));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666987,
            "Attack01Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B303153657175656E63653E645F5F34390000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666988,
            "Attack02Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B303253657175656E63653E645F5F35300000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666989,
            "Attack03Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B303353657175656E63653E645F5F35310000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666990,
            "Attack04Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B303453657175656E63653E645F5F35320000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666991,
            "Attack05Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B303553657175656E63653E645F5F35330000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666992,
            "Attack06Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B303653657175656E63653E645F5F35340000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666993,
            "Attack07Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B303753657175656E63653E645F5F35350000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666994,
            "Attack08Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B303853657175656E63653E645F5F35360000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666995,
            "Attack09Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B303953657175656E63653E645F5F35370000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666996,
            "Attack10Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B313053657175656E63653E645F5F35380000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666997,
            "Attack11Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B313153657175656E63653E645F5F35390000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666998,
            "Attack13Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B313353657175656E63653E645F5F36300000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100666999,
            "Attack14Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B313453657175656E63653E645F5F36310000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100667000,
            "Attack15Sequence", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002943656C657374652E46696E616C426F73732B3C41747461636B313553657175656E63653E645F5F36320000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100667001,
            "Shoot", 129, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("angleOffset", 0, 4112, "System.Single", true, "System.Single",
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223795)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 41, 132));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100667002,
            "ShootAt", 129, "200101118085", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("at", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { },
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223796)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 33, 111));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100667003,
            "Beam", 129, "20001280B5",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01001D43656C657374652E46696E616C426F73732B3C4265616D3E645F5F36350000")
            }, "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100667004,
            "Removed", 198, "200101128478", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223797)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 14, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100667005,
            "<Added>b__32_0", 129, "200001",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100667006,
            "<CreateBossSprite>b__34_0", 129, "2001010E",
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
                        typeIdentity: "System.String"), 1, 134223798)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 46));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss", 33554845, 100667007,
            "<OnPlayer>b__41_0", 129, "200001",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 24, 79));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c", 33555612,
            100672318, ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 11));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c", 33555612,
            100672319, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c", 33555612,
            100672320, "<Awake>b__33_0", 131, "200208128418128418", new KeyValuePair<string, string>[] { },
            "System.Int32", new string[] { "Monocle.Entity", "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134227751),
                new SourceMethodParameterDefinition("b", 1, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 2, 134227752)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 7, 15));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c", 33555612,
            100672321, "<Awake>b__33_1", 131, "200208128418128418", new KeyValuePair<string, string>[] { },
            "System.Int32", new string[] { "Monocle.Entity", "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134227753),
                new SourceMethodParameterDefinition("b", 1, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 2, 134227754)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 7, 15));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c", 33555612,
            100672322, "<MoveSequence>b__42_0", 131, "20010112840C", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Monocle.Tween" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("t", 0, 0, "Monocle.Tween", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Tween"), 1, 134227755)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 18));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c", 33555612,
            100672323, "<MoveSequence>b__42_1", 131, "20010112840C", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Monocle.Tween" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("t", 0, 0, "Monocle.Tween", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Tween"), 1, 134227756)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 24));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c__DisplayClass42_0",
            33555613, 100672324, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c__DisplayClass42_0",
            33555613, 100672325, "<MoveSequence>b__4", 131, "20010112840C", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Monocle.Tween" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("t", 0, 0, "Monocle.Tween", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Tween"), 1, 134227757)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 49, 159));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c__DisplayClass42_1",
            33555614, 100672326, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c__DisplayClass42_1",
            33555614, 100672327, "<MoveSequence>b__2", 131, "20010112840C", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Monocle.Tween" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("t", 0, 0, "Monocle.Tween", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Tween"), 1, 134227758)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 39, 138));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c__DisplayClass42_2",
            33555615, 100672328, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<>c__DisplayClass42_2",
            33555615, 100672329, "<MoveSequence>b__3", 131, "20010112840C", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Monocle.Tween" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("t", 0, 0, "Monocle.Tween", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Tween"), 1, 134227759)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 52, 194));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<MoveSequence>d__42",
            33555616, 100672330, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134227760)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<MoveSequence>d__42",
            33555616, 100672331, "System.IDisposable.Dispose", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 1, 1));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<MoveSequence>d__42",
            33555616, 100672332, "MoveNext", 481, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 342, 1102));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<MoveSequence>d__42",
            33555616, 100672333, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<MoveSequence>d__42",
            33555616, 100672334, "System.Collections.IEnumerator.Reset", 481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FinalBoss+<MoveSequence>d__42",
            33555616, 100672335, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
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
            "Celeste.FinalBoss+<Attack01Sequence>d__49", 33555617, 100672336, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134227761)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.FinalBoss+<Attack01Sequence>d__49", 33555617, 100672337, "System.IDisposable.Dispose", 481,
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
            "Celeste.FinalBoss+<Attack01Sequence>d__49", 33555617, 100672338, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 69, 205));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.FinalBoss+<Attack01Sequence>d__49", 33555617, 100672339,
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
            "Celeste.FinalBoss+<Attack01Sequence>d__49", 33555617, 100672340, "System.Collections.IEnumerator.Reset",
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
            "Celeste.FinalBoss+<Attack01Sequence>d__49", 33555617, 100672341,
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
            "Celeste.FinalBoss+<Attack02Sequence>d__50", 33555618, 100672342, ".ctor", 6278, "20010108",
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
                        typeIdentity: "System.Int32"), 1, 134227762)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.FinalBoss+<Attack02Sequence>d__50", 33555618, 100672343, "System.IDisposable.Dispose", 481,
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
            "Celeste.FinalBoss+<Attack02Sequence>d__50", 33555618, 100672344, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 91, 267));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.FinalBoss+<Attack02Sequence>d__50", 33555618, 100672345,
            "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
    }
}
