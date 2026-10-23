using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMethodMetadata
    {
        private static void PublishInstalled091(SourceAssemblyMethodCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+PauseHandler", 33556789, 100677857, "Invoke", 454,
                "200401129E94080202",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Level", "System.Int32", "System.Boolean", "System.Boolean"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230542),
                    new("startIndex", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134230543),
                    new("minimal", 2, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230544),
                    new("quickReset", 3, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 4, 134230545),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+PauseHandler", 33556789, 100677858, "BeginInvoke", 454,
                "2006128631129E940802021286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                [
                    "Celeste.Level", "System.Int32", "System.Boolean", "System.Boolean", "System.AsyncCallback",
                    "System.Object",
                ], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230546),
                    new("startIndex", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134230547),
                    new("minimal", 2, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230548),
                    new("quickReset", 3, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 4, 134230549),
                    new("callback", 4, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 5, 134230550),
                    new("object", 5, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 6, 134230551),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+PauseHandler", 33556789, 100677859, "EndInvoke", 454, "200101128631",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230552),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+UnpauseHandler", 33556790, 100677860, ".ctor", 6278, "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230553),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230554),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+UnpauseHandler", 33556790, 100677861, "Invoke", 454, "200101129E94",
                (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Level"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230555),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+UnpauseHandler", 33556790, 100677862, "BeginInvoke", 454,
                "2003128631129E941286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["Celeste.Level", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230556),
                    new("callback", 1, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 2, 134230557),
                    new("object", 2, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 3, 134230558),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+UnpauseHandler", 33556790, 100677863, "EndInvoke", 454,
                "200101128631",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230559),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+CreatePauseMenuButtonsHandler", 33556791, 100677864, ".ctor", 6278,
                "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230560),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230561),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+CreatePauseMenuButtonsHandler", 33556791, 100677865, "Invoke", 454,
                "200301129E9412916802", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Level", "Celeste.TextMenu", "System.Boolean"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230562),
                    new("menu", 1, 0, "Celeste.TextMenu", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.TextMenu"), 2, 134230563),
                    new("minimal", 2, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230564),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+CreatePauseMenuButtonsHandler", 33556791, 100677866, "BeginInvoke",
                454,
                "2005128631129E94129168021286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["Celeste.Level", "Celeste.TextMenu", "System.Boolean", "System.AsyncCallback", "System.Object"],
                0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230565),
                    new("menu", 1, 0, "Celeste.TextMenu", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.TextMenu"), 2, 134230566),
                    new("minimal", 2, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230567),
                    new("callback", 3, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 4, 134230568),
                    new("object", 4, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 5, 134230569),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+CreatePauseMenuButtonsHandler", 33556791, 100677867, "EndInvoke", 454,
                "200101128631", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230570),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+TransitionToHandler", 33556792, 100677868, ".ctor", 6278,
                "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230571),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230572),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+TransitionToHandler", 33556792, 100677869, "Invoke", 454,
                "200301129E94129E801180A1", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Level", "Celeste.LevelData", "Microsoft.Xna.Framework.Vector2"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230573),
                    new("next", 1, 0, "Celeste.LevelData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.LevelData"), 2, 134230574),
                    new("direction", 2, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134230575),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+TransitionToHandler", 33556792, 100677870, "BeginInvoke", 454,
                "2005128631129E94129E801180A11286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                [
                    "Celeste.Level", "Celeste.LevelData", "Microsoft.Xna.Framework.Vector2", "System.AsyncCallback",
                    "System.Object",
                ], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230576),
                    new("next", 1, 0, "Celeste.LevelData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.LevelData"), 2, 134230577),
                    new("direction", 2, 0, "Microsoft.Xna.Framework.Vector2", false,
                        null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134230578),
                    new("callback", 3, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 4, 134230579),
                    new("object", 4, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 5, 134230580),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+TransitionToHandler", 33556792, 100677871, "EndInvoke", 454,
                "200101128631", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230581),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadEntityHandler", 33556793, 100677872, ".ctor", 6278, "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230582),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230583),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadEntityHandler", 33556793, 100677873, "Invoke", 454,
                "200402129E94129E801180A1129E78", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["Celeste.Level", "Celeste.LevelData", "Microsoft.Xna.Framework.Vector2", "Celeste.EntityData"],
                0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230584),
                    new("levelData", 1, 0, "Celeste.LevelData", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.LevelData"), 2, 134230585),
                    new("offset", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134230586),
                    new("entityData", 3, 0, "Celeste.EntityData", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.EntityData"), 4, 134230587),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadEntityHandler", 33556793, 100677874, "BeginInvoke", 454,
                "2006128631129E94129E801180A1129E781286351C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "Celeste.Level", "Celeste.LevelData", "Microsoft.Xna.Framework.Vector2", "Celeste.EntityData",
                    "System.AsyncCallback", "System.Object",
                ], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230588),
                    new("levelData", 1, 0, "Celeste.LevelData", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.LevelData"), 2, 134230589),
                    new("offset", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 3, 134230590),
                    new("entityData", 3, 0, "Celeste.EntityData", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.EntityData"), 4, 134230591),
                    new("callback", 4, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 5, 134230592),
                    new("object", 5, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 6, 134230593),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadEntityHandler", 33556793, 100677875, "EndInvoke", 454,
                "200102128631",
                (KeyValuePair<string, string>[])[], "System.Boolean", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230594),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadLevelHandler", 33556794, 100677876, ".ctor", 6278, "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230595),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230596),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadLevelHandler", 33556794, 100677877, "Invoke", 454,
                "200301129E94119F2802", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Level", "Celeste.Player+IntroTypes", "System.Boolean"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230597),
                    new("playerIntro", 1, 0, "Celeste.Player+IntroTypes", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Player+IntroTypes"), 2, 134230598),
                    new("isFromLoader", 2, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230599),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadLevelHandler", 33556794, 100677878, "BeginInvoke", 454,
                "2005128631129E94119F28021286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                [
                    "Celeste.Level", "Celeste.Player+IntroTypes", "System.Boolean", "System.AsyncCallback",
                    "System.Object",
                ], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230600),
                    new("playerIntro", 1, 0, "Celeste.Player+IntroTypes", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Player+IntroTypes"), 2, 134230601),
                    new("isFromLoader", 2, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230602),
                    new("callback", 3, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 4, 134230603),
                    new("object", 4, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 5, 134230604),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadLevelHandler", 33556794, 100677879, "EndInvoke", 454,
                "200101128631",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230605),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+CompleteHandler", 33556795, 100677880, ".ctor", 6278, "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230606),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230607),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+CompleteHandler", 33556795, 100677881, "Invoke", 454, "200101129E94",
                (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Level"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230608),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+CompleteHandler", 33556795, 100677882, "BeginInvoke", 454,
                "2003128631129E941286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["Celeste.Level", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230609),
                    new("callback", 1, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 2, 134230610),
                    new("object", 2, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 3, 134230611),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+CompleteHandler", 33556795, 100677883, "EndInvoke", 454,
                "200101128631",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230612),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+EndHandler", 33556796, 100677884, ".ctor", 6278, "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230613),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230614),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+EndHandler", 33556796, 100677885, "Invoke", 454,
                "200401129E9412858810021002", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Level", "Monocle.Scene", "System.Boolean&", "System.Boolean&"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230615),
                    new("nextScene", 1, 0, "Monocle.Scene", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Scene"), 2, 134230616),
                    new("shouldReloadPortraits", 2, 0, "System.Boolean&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 3, 134230617),
                    new("shouldDissociateEntities", 3, 0, "System.Boolean&", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 4, 134230618),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+EndHandler", 33556796, 100677886, "BeginInvoke", 454,
                "2006128631129E94128588100210021286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                [
                    "Celeste.Level", "Monocle.Scene", "System.Boolean&", "System.Boolean&", "System.AsyncCallback",
                    "System.Object",
                ], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230619),
                    new("nextScene", 1, 0, "Monocle.Scene", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Scene"), 2, 134230620),
                    new("shouldReloadPortraits", 2, 0, "System.Boolean&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 3, 134230621),
                    new("shouldDissociateEntities", 3, 0, "System.Boolean&", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 4, 134230622),
                    new("callback", 4, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 5, 134230623),
                    new("object", 5, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 6, 134230624),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+EndHandler", 33556796, 100677887, "EndInvoke", 454,
                "20030110021002128631", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Boolean&", "System.Boolean&", "System.IAsyncResult"], 0,
                [
                    new("shouldReloadPortraits", 0, 0, "System.Boolean&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 1, 134230625),
                    new("shouldDissociateEntities", 1, 0, "System.Boolean&", false,
                        null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134230626),
                    new("result", 2, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 3, 134230627),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+EnterHandler", 33556797, 100677888, ".ctor", 6278, "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230628),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230629),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+EnterHandler", 33556797, 100677889, "Invoke", 454, "200201129BD802",
                (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Session", "System.Boolean"],
                0,
                [
                    new("session", 0, 0, "Celeste.Session", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session"), 1, 134230630),
                    new("fromSaveData", 1, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134230631),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+EnterHandler", 33556797, 100677890, "BeginInvoke", 454,
                "2004128631129BD8021286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["Celeste.Session", "System.Boolean", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("session", 0, 0, "Celeste.Session", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session"), 1, 134230632),
                    new("fromSaveData", 1, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134230633),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 3, 134230634),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134230635),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+EnterHandler", 33556797, 100677891, "EndInvoke", 454, "200101128631",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230636),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+ExitHandler", 33556798, 100677892, ".ctor", 6278, "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230637),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230638),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+ExitHandler", 33556798, 100677893, "Invoke", 454,
                "200501129E94129290119294129BD8129138", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "Celeste.Level", "Celeste.LevelExit", "Celeste.LevelExit+Mode", "Celeste.Session",
                    "Celeste.HiresSnow",
                ], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230639),
                    new("exit", 1, 0, "Celeste.LevelExit", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.LevelExit"), 2, 134230640),
                    new("mode", 2, 0, "Celeste.LevelExit+Mode", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.LevelExit+Mode"), 3, 134230641),
                    new("session", 3, 0, "Celeste.Session", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session"), 4, 134230642),
                    new("snow", 4, 0, "Celeste.HiresSnow", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.HiresSnow"), 5, 134230643),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+ExitHandler", 33556798, 100677894, "BeginInvoke", 454,
                "2007128631129E94129290119294129BD81291381286351C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "Celeste.Level", "Celeste.LevelExit", "Celeste.LevelExit+Mode", "Celeste.Session",
                    "Celeste.HiresSnow",
                    "System.AsyncCallback", "System.Object",
                ], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230644),
                    new("exit", 1, 0, "Celeste.LevelExit", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.LevelExit"), 2, 134230645),
                    new("mode", 2, 0, "Celeste.LevelExit+Mode", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.LevelExit+Mode"), 3, 134230646),
                    new("session", 3, 0, "Celeste.Session", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session"), 4, 134230647),
                    new("snow", 4, 0, "Celeste.HiresSnow", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.HiresSnow"), 5, 134230648),
                    new("callback", 5, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 6, 134230649),
                    new("object", 6, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 7, 134230650),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+ExitHandler", 33556798, 100677895, "EndInvoke", 454, "200101128631",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230651),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadBackdropHandler", 33556799, 100677896, ".ctor", 6278,
                "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230652),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230653),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadBackdropHandler", 33556799, 100677897, "Invoke", 454,
                "2003129DE0129E68129234129234", (KeyValuePair<string, string>[])[], "Celeste.Backdrop",
                ["Celeste.MapData", "Celeste.BinaryPacker+Element", "Celeste.BinaryPacker+Element"], 0,
                [
                    new("map", 0, 0, "Celeste.MapData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.MapData"), 1, 134230654),
                    new("child", 1, 0, "Celeste.BinaryPacker+Element", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.BinaryPacker+Element"), 2, 134230655),
                    new("above", 2, 0, "Celeste.BinaryPacker+Element", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.BinaryPacker+Element"), 3, 134230656),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Backdrop"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadBackdropHandler", 33556799, 100677898, "BeginInvoke", 454,
                "2005128631129E681292341292341286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                [
                    "Celeste.MapData", "Celeste.BinaryPacker+Element", "Celeste.BinaryPacker+Element",
                    "System.AsyncCallback", "System.Object",
                ], 0,
                [
                    new("map", 0, 0, "Celeste.MapData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.MapData"), 1, 134230657),
                    new("child", 1, 0, "Celeste.BinaryPacker+Element", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.BinaryPacker+Element"), 2, 134230658),
                    new("above", 2, 0, "Celeste.BinaryPacker+Element", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.BinaryPacker+Element"), 3, 134230659),
                    new("callback", 3, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 4, 134230660),
                    new("object", 4, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 5, 134230661),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Level+LoadBackdropHandler", 33556799, 100677899, "EndInvoke", 454,
                "2001129DE0128631", (KeyValuePair<string, string>[])[], "Celeste.Backdrop",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230662),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Backdrop"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelEnter",
                33556800, 100677900, "add_OnPlayVignette", 2198, "00010112A504",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler"), 1, 134230663),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelEnter",
                33556800, 100677901, "remove_OnPlayVignette", 2198, "00010112A504",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler"), 1, 134230664),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelEnter",
                33556800, 100677902, "PlayVignette", 147, "0002128588129BD802", (KeyValuePair<string, string>[])[],
                "Monocle.Scene", ["Celeste.Session", "System.Boolean"], 0,
                [
                    new("session", 0, 0, "Celeste.Session", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session"), 1, 134230665),
                    new("fromSaveData", 1, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134230666),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Scene"), true, 33, 57));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler", 33556801, 100677903, ".ctor", 6278,
                "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230667),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230668),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler", 33556801, 100677904, "Invoke", 454,
                "2002128588129BD802", (KeyValuePair<string, string>[])[], "Monocle.Scene",
                ["Celeste.Session", "System.Boolean"], 0,
                [
                    new("session", 0, 0, "Celeste.Session", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session"), 1, 134230669),
                    new("fromSaveData", 1, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134230670),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Scene"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler", 33556801, 100677905, "BeginInvoke", 454,
                "2004128631129BD8021286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["Celeste.Session", "System.Boolean", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("session", 0, 0, "Celeste.Session", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session"), 1, 134230671),
                    new("fromSaveData", 1, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134230672),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 3, 134230673),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134230674),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelEnter+CustomVignetteHandler", 33556801, 100677906, "EndInvoke", 454,
                "2001128588128631", (KeyValuePair<string, string>[])[], "Monocle.Scene",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230675),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Scene"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelLoader",
                33556802, 100677907, "add_OnLoadingThread", 2198, "00010112A50C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler"), 1, 134230676),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelLoader",
                33556802, 100677908, "remove_OnLoadingThread", 2198, "00010112A50C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler"), 1, 134230677),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelLoader",
                33556802, 100677909, "LoadingThread", 147, "000101129E94", (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.Level"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230678),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler", 33556803, 100677910, ".ctor", 6278,
                "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230679),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230680),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler", 33556803, 100677911, "Invoke", 454,
                "200101129E94", (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.Level"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230681),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler", 33556803, 100677912, "BeginInvoke", 454,
                "2003128631129E941286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["Celeste.Level", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("level", 0, 0, "Celeste.Level", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Level"), 1, 134230682),
                    new("callback", 1, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 2, 134230683),
                    new("object", 2, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 3, 134230684),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+LevelLoader+LoadingThreadHandler", 33556803, 100677913, "EndInvoke", 454,
                "200101128631", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230685),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Atlas",
                33556804, 100677914, "add_OnGetCustomFallback", 2198, "00010112A514",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler"), 1, 134230686),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Atlas",
                33556804, 100677915, "remove_OnGetCustomFallback", 2198, "00010112A514",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler"), 1, 134230687),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Atlas",
                33556804, 100677916, "GetCustomFallback", 147, "00021284781284700E",
                (KeyValuePair<string, string>[])[],
                "Monocle.MTexture", ["Monocle.Atlas", "System.String"], 0,
                [
                    new("atlas", 0, 0, "Monocle.Atlas", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Atlas"), 1, 134230688),
                    new("id", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134230689),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.MTexture"), true, 18, 31));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler", 33556805, 100677917, ".ctor", 6278,
                "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230690),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230691),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler", 33556805, 100677918, "Invoke", 454,
                "20021284781284700E", (KeyValuePair<string, string>[])[], "Monocle.MTexture",
                ["Monocle.Atlas", "System.String"], 0,
                [
                    new("atlas", 0, 0, "Monocle.Atlas", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Atlas"), 1, 134230692),
                    new("id", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134230693),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.MTexture"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler", 33556805, 100677919, "BeginInvoke", 454,
                "20041286311284700E1286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["Monocle.Atlas", "System.String", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("atlas", 0, 0, "Monocle.Atlas", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Atlas"), 1, 134230694),
                    new("id", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134230695),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 3, 134230696),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134230697),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Atlas+CustomFallbackHandler", 33556805, 100677920, "EndInvoke", 454,
                "2001128478128631", (KeyValuePair<string, string>[])[], "Monocle.MTexture",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230698),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.MTexture"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+FileSelectSlot", 33556806, 100677921, "add_OnCreateButtons", 2198,
                "00010112A51C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler"), 1, 134230699),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+FileSelectSlot", 33556806, 100677922, "remove_OnCreateButtons", 2198,
                "00010112A51C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler"), 1, 134230700),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+FileSelectSlot", 33556806, 100677923, "HandleCreateButtons", 147,
                "000301151269011296001295FC02", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Collections.Generic.List`1<Celeste.OuiFileSelectSlot+Button>", "Celeste.OuiFileSelectSlot",
                    "System.Boolean",
                ], 0,
                [
                    new("buttons", 0, 0,
                        "System.Collections.Generic.List`1<Celeste.OuiFileSelectSlot+Button>", false, null,
                        [],
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.OuiFileSelectSlot+Button"),
                            ]), 1, 134230701),
                    new("slot", 1, 0, "Celeste.OuiFileSelectSlot", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiFileSelectSlot"), 2, 134230702),
                    new("fileExists", 2, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230703),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 62, 126));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler", 33556807, 100677924, ".ctor", 6278,
                "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230704),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230705),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler", 33556807, 100677925, "Invoke", 454,
                "200401151269011296001295FC12A94C02", (KeyValuePair<string, string>[])[], "System.Void",
                [
                    "System.Collections.Generic.List`1<Celeste.OuiFileSelectSlot+Button>", "Celeste.OuiFileSelectSlot",
                    "Celeste.Mod.EverestModuleSaveData", "System.Boolean",
                ], 0,
                [
                    new("buttons", 0, 0,
                        "System.Collections.Generic.List`1<Celeste.OuiFileSelectSlot+Button>", false, null,
                        [],
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.OuiFileSelectSlot+Button"),
                            ]), 1, 134230706),
                    new("slot", 1, 0, "Celeste.OuiFileSelectSlot", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiFileSelectSlot"), 2, 134230707),
                    new("modSaveData", 2, 0, "Celeste.Mod.EverestModuleSaveData", false,
                        null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.EverestModuleSaveData"), 3, 134230708),
                    new("fileExists", 3, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 4, 134230709),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler", 33556807, 100677926, "BeginInvoke",
                454,
                "2006128631151269011296001295FC12A94C021286351C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "System.Collections.Generic.List`1<Celeste.OuiFileSelectSlot+Button>", "Celeste.OuiFileSelectSlot",
                    "Celeste.Mod.EverestModuleSaveData", "System.Boolean", "System.AsyncCallback", "System.Object",
                ], 0,
                [
                    new("buttons", 0, 0,
                        "System.Collections.Generic.List`1<Celeste.OuiFileSelectSlot+Button>", false, null,
                        [],
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.OuiFileSelectSlot+Button"),
                            ]), 1, 134230710),
                    new("slot", 1, 0, "Celeste.OuiFileSelectSlot", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiFileSelectSlot"), 2, 134230711),
                    new("modSaveData", 2, 0, "Celeste.Mod.EverestModuleSaveData", false,
                        null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.EverestModuleSaveData"), 3, 134230712),
                    new("fileExists", 3, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 4, 134230713),
                    new("callback", 4, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 5, 134230714),
                    new("object", 5, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 6, 134230715),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+FileSelectSlot+CreateButtonsHandler", 33556807, 100677927, "EndInvoke", 454,
                "200101128631", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230716),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+FileSelectSlot+<>c__DisplayClass4_0", 33556808, 100677928, ".ctor", 6278,
                "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+FileSelectSlot+<>c__DisplayClass4_0", 33556808, 100677929,
                "<HandleCreateButtons>b__0", 131, "20010212A8EC", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                ["Celeste.Mod.EverestModule"], 0,
                [
                    new("module", 0, 0, "Celeste.Mod.EverestModule", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.EverestModule"), 1, 134230717),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 10, 38));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiJournal",
                33556809, 100677930, "add_OnCreateButtons", 2198, "00010112A528",
                (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.Mod.Everest+Events+OuiJournal+EnterHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+OuiJournal+EnterHandler",
                        false, null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+OuiJournal+EnterHandler"), 1, 134230718),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiJournal",
                33556809, 100677931, "remove_OnCreateButtons", 2198, "00010112A528",
                (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.Mod.Everest+Events+OuiJournal+EnterHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+OuiJournal+EnterHandler",
                        false, null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+OuiJournal+EnterHandler"), 1, 134230719),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiJournal+EnterHandler", 33556810, 100677932, ".ctor", 6278, "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230720),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230721),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiJournal+EnterHandler", 33556810, 100677933, "Invoke", 454,
                "200201129654129AE4", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.OuiJournal", "Celeste.Oui"], 0,
                [
                    new("journal", 0, 0, "Celeste.OuiJournal", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiJournal"), 1, 134230722),
                    new("from", 1, 0, "Celeste.Oui", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Oui"), 2, 134230723),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiJournal+EnterHandler", 33556810, 100677934, "BeginInvoke", 454,
                "2004128631129654129AE41286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["Celeste.OuiJournal", "Celeste.Oui", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("journal", 0, 0, "Celeste.OuiJournal", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiJournal"), 1, 134230724),
                    new("from", 1, 0, "Celeste.Oui", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Oui"), 2, 134230725),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 3, 134230726),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134230727),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiJournal+EnterHandler", 33556810, 100677935, "EndInvoke", 454,
                "200101128631",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230728),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Journal",
                33556811, 100677936, "add_OnEnter", 2198, "00010112A530",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+Journal+EnterHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+Journal+EnterHandler",
                        false, null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+Journal+EnterHandler"), 1, 134230729),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Journal",
                33556811, 100677937, "remove_OnEnter", 2198, "00010112A530",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+Journal+EnterHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+Journal+EnterHandler",
                        false, null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+Journal+EnterHandler"), 1, 134230730),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Journal",
                33556811, 100677938, "Enter", 147, "000201129654129AE4", (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.OuiJournal", "Celeste.Oui"], 0,
                [
                    new("journal", 0, 0, "Celeste.OuiJournal", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiJournal"), 1, 134230731),
                    new("from", 1, 0, "Celeste.Oui", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Oui"), 2, 134230732),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Journal+EnterHandler", 33556812, 100677939, ".ctor", 6278, "2002011C18",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230733),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230734),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Journal+EnterHandler", 33556812, 100677940, "Invoke", 454,
                "200201129654129AE4",
                (KeyValuePair<string, string>[])[], "System.Void", ["Celeste.OuiJournal", "Celeste.Oui"],
                0,
                [
                    new("journal", 0, 0, "Celeste.OuiJournal", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiJournal"), 1, 134230735),
                    new("from", 1, 0, "Celeste.Oui", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Oui"), 2, 134230736),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Journal+EnterHandler", 33556812, 100677941, "BeginInvoke", 454,
                "2004128631129654129AE41286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                ["Celeste.OuiJournal", "Celeste.Oui", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("journal", 0, 0, "Celeste.OuiJournal", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiJournal"), 1, 134230737),
                    new("from", 1, 0, "Celeste.Oui", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Oui"), 2, 134230738),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 3, 134230739),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134230740),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+Journal+EnterHandler", 33556812, 100677942, "EndInvoke", 454,
                "200101128631",
                (KeyValuePair<string, string>[])[], "System.Void", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230741),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiMainMenu",
                33556813, 100677943, "add_OnCreateButtons", 2198, "00010112A538",
                (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler"), 1, 134230742),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiMainMenu",
                33556813, 100677944, "remove_OnCreateButtons", 2198, "00010112A538",
                (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler"), 1, 134230743),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler", 33556814, 100677945, ".ctor", 6278,
                "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230744),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230745),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler", 33556814, 100677946, "Invoke", 454,
                "200201129AA4151269011296AC", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.OuiMainMenu", "System.Collections.Generic.List`1<Celeste.MenuButton>"], 0,
                [
                    new("menu", 0, 0, "Celeste.OuiMainMenu", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiMainMenu"), 1, 134230746),
                    new("buttons", 1, 0,
                        "System.Collections.Generic.List`1<Celeste.MenuButton>", false, null, [],
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.MenuButton"),
                            ]), 2, 134230747),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler", 33556814, 100677947, "BeginInvoke", 454,
                "2004128631129AA4151269011296AC1286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                [
                    "Celeste.OuiMainMenu", "System.Collections.Generic.List`1<Celeste.MenuButton>",
                    "System.AsyncCallback",
                    "System.Object",
                ], 0,
                [
                    new("menu", 0, 0, "Celeste.OuiMainMenu", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiMainMenu"), 1, 134230748),
                    new("buttons", 1, 0,
                        "System.Collections.Generic.List`1<Celeste.MenuButton>", false, null, [],
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.MenuButton"),
                            ]), 2, 134230749),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 3, 134230750),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134230751),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+OuiMainMenu+CreateButtonsHandler", 33556814, 100677948, "EndInvoke", 454,
                "200101128631", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230752),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+MainMenu",
                33556815, 100677949, "add_OnCreateButtons", 2198, "00010112A540",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler"), 1, 134230753),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+MainMenu",
                33556815, 100677950, "remove_OnCreateButtons", 2198, "00010112A540",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler"], 0,
                [
                    new("value", 0, 0,
                        "Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler"), 1, 134230754),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+MainMenu",
                33556815, 100677951, "CreateButtons", 147, "000201129AA4151269011296AC",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.OuiMainMenu", "System.Collections.Generic.List`1<Celeste.MenuButton>"], 0,
                [
                    new("menu", 0, 0, "Celeste.OuiMainMenu", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiMainMenu"), 1, 134230755),
                    new("buttons", 1, 0,
                        "System.Collections.Generic.List`1<Celeste.MenuButton>", false, null, [],
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.MenuButton"),
                            ]), 2, 134230756),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler", 33556816, 100677952, ".ctor", 6278,
                "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230757),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134230758),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler", 33556816, 100677953, "Invoke", 454,
                "200201129AA4151269011296AC", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.OuiMainMenu", "System.Collections.Generic.List`1<Celeste.MenuButton>"], 0,
                [
                    new("menu", 0, 0, "Celeste.OuiMainMenu", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiMainMenu"), 1, 134230759),
                    new("buttons", 1, 0,
                        "System.Collections.Generic.List`1<Celeste.MenuButton>", false, null, [],
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.MenuButton"),
                            ]), 2, 134230760),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler", 33556816, 100677954, "BeginInvoke", 454,
                "2004128631129AA4151269011296AC1286351C", (KeyValuePair<string, string>[])[], "System.IAsyncResult",
                [
                    "Celeste.OuiMainMenu", "System.Collections.Generic.List`1<Celeste.MenuButton>",
                    "System.AsyncCallback",
                    "System.Object",
                ], 0,
                [
                    new("menu", 0, 0, "Celeste.OuiMainMenu", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiMainMenu"), 1, 134230761),
                    new("buttons", 1, 0,
                        "System.Collections.Generic.List`1<Celeste.MenuButton>", false, null, [],
                        "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Collections.Generic.List`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.MenuButton"),
                            ]), 2, 134230762),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.AsyncCallback"), 3, 134230763),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134230764),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.Named,
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.Mod.Everest+Events+MainMenu+CreateButtonsHandler", 33556816, 100677955, "EndInvoke", 454,
                "200101128631", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.Named,
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            "System.IAsyncResult"), 1, 134230765),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677956, "add_OnSpawn", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230766),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677957, "remove_OnSpawn", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230767),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677958, "add_OnDie", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230768),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677959, "remove_OnDie", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230769),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677960, "add_OnPauseInGBJ", 2198, "0001011512809102129F2402",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Func`2<Celeste.Player,System.Boolean>"], 0,
                [
                    new("value", 0, 0, "System.Func`2<Celeste.Player,System.Boolean>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Func`2"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Boolean"),
                            ]), 1, 134230770),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677961, "remove_OnPauseInGBJ", 2198, "0001011512809102129F2402",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Func`2<Celeste.Player,System.Boolean>"], 0,
                [
                    new("value", 0, 0, "System.Func`2<Celeste.Player,System.Boolean>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Func`2"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Boolean"),
                            ]), 1, 134230771),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677962, "add_OnRegisterStates", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230772),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677963, "remove_OnRegisterStates", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230773),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677964, "add_OnBeforeUpdate", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230774),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677965, "remove_OnBeforeUpdate", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230775),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677966, "add_OnAfterUpdate", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230776),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677967, "remove_OnAfterUpdate", 2198, "0001011512814D01129F24",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Player>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Player>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Player"),
                            ]), 1, 134230777),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677968, "Spawn", 147, "000101129F24", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["Celeste.Player"], 0,
                [
                    new("player", 0, 0, "Celeste.Player", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Player"), 1, 134230778),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677969, "Die", 147, "000101129F24", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Player"], 0,
                [
                    new("player", 0, 0, "Celeste.Player", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Player"), 1, 134230779),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677970, "PauseInGBJ", 147, "000102129F24", (KeyValuePair<string, string>[])[],
                "System.Boolean", ["Celeste.Player"], 0,
                [
                    new("player", 0, 0, "Celeste.Player", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Player"), 1, 134230780),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677971, "RegisterStates", 147, "000101129F24", (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.Player"], 0,
                [
                    new("player", 0, 0, "Celeste.Player", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Player"), 1, 134230781),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677972, "BeforeUpdate", 147, "000101129F24", (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.Player"], 0,
                [
                    new("player", 0, 0, "Celeste.Player", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Player"), 1, 134230782),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Player",
                33556817, 100677973, "AfterUpdate", 147, "000101129F24", (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.Player"], 0,
                [
                    new("player", 0, 0, "Celeste.Player", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Player"), 1, 134230783),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Seeker",
                33556818, 100677974, "add_OnRegisterStates", 2198, "0001011512814D011297AC",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Seeker>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Seeker>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Seeker"),
                            ]), 1, 134230784),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Seeker",
                33556818, 100677975, "remove_OnRegisterStates", 2198, "0001011512814D011297AC",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`1<Celeste.Seeker>"], 0,
                [
                    new("value", 0, 0, "System.Action`1<Celeste.Seeker>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Seeker"),
                            ]), 1, 134230785),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Seeker",
                33556818, 100677976, "RegisterStates", 147, "0001011297AC", (KeyValuePair<string, string>[])[],
                "System.Void", ["Celeste.Seeker"], 0,
                [
                    new("seeker", 0, 0, "Celeste.Seeker", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Seeker"), 1, 134230786),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Session",
                33556819, 100677977, "add_OnSliderChanged", 2198, "0001011512858503129BD8129BE415118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void",
                ["System.Action`3<Celeste.Session,Celeste.Session+Slider,System.Nullable`1<System.Single>>"],
                0,
                [
                    new("value", 0, 0,
                        "System.Action`3<Celeste.Session,Celeste.Session+Slider,System.Nullable`1<System.Single>>",
                        false,
                        null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`3"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Session"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Session+Slider"),
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Nullable`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.Named,
                                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                            "System.Single"),
                                    ]),
                            ]), 1, 134230787),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Session",
                33556819, 100677978, "remove_OnSliderChanged", 2198, "0001011512858503129BD8129BE415118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void",
                ["System.Action`3<Celeste.Session,Celeste.Session+Slider,System.Nullable`1<System.Single>>"],
                0,
                [
                    new("value", 0, 0,
                        "System.Action`3<Celeste.Session,Celeste.Session+Slider,System.Nullable`1<System.Single>>",
                        false,
                        null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`3"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Session"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Session+Slider"),
                                new(
                                    SourceTypeReferenceKind.GenericInstance,
                                    elementType: new(
                                        SourceTypeReferenceKind.Named,
                                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "System.Nullable`1"),
                                    genericArguments:
                                    [
                                        new(
                                            SourceTypeReferenceKind.Named,
                                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                            "System.Single"),
                                    ]),
                            ]), 1, 134230788),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Events+Session",
                33556819, 100677979, "SliderChanged", 147, "000301129BD8129BE415118141010C",
                (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Session", "Celeste.Session+Slider", "System.Nullable`1<System.Single>"], 0,
                [
                    new("session", 0, 0, "Celeste.Session", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session"), 1, 134230789),
                    new("slider", 1, 0, "Celeste.Session+Slider", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Session+Slider"), 2, 134230790),
                    new("previous", 2, 0, "System.Nullable`1<System.Single>", false,
                        null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Nullable`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Single"),
                            ]), 3, 134230791),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677980, "get_PathContentOrig", 2198, "00000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677981, "set_PathContentOrig", 2195, "0001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230792),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677982, "get_PathDUMP", 2198, "00000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677983, "set_PathDUMP", 2195, "0001010E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.String"], 0,
                [
                    new("value", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230793),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677984, "add_OnGuessType", 2198, "00010112A794",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.TypeGuesser"], 0,
                [
                    new("value", 0, 0, "Celeste.Mod.TypeGuesser", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.TypeGuesser"), 1, 134230794),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677985, "remove_OnGuessType", 2198, "00010112A794",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Celeste.Mod.TypeGuesser"], 0,
                [
                    new("value", 0, 0, "Celeste.Mod.TypeGuesser", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.TypeGuesser"), 1, 134230795),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677986, "add_OnUpdate", 2198, "000101151285F10212A81012A810",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`2<Celeste.Mod.ModAsset,Celeste.Mod.ModAsset>"], 0,
                [
                    new("value", 0, 0,
                        "System.Action`2<Celeste.Mod.ModAsset,Celeste.Mod.ModAsset>", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`2"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Mod.ModAsset"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Mod.ModAsset"),
                            ]), 1, 134230796),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677987, "remove_OnUpdate", 2198, "000101151285F10212A81012A810",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`2<Celeste.Mod.ModAsset,Celeste.Mod.ModAsset>"], 0,
                [
                    new("value", 0, 0,
                        "System.Action`2<Celeste.Mod.ModAsset,Celeste.Mod.ModAsset>", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`2"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Mod.ModAsset"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Mod.ModAsset"),
                            ]), 1, 134230797),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677988, "add_OnProcessLoad", 2198, "000101151285F1021C0E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`2<System.Object,System.String>"], 0,
                [
                    new("value", 0, 0, "System.Action`2<System.Object,System.String>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`2"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Object"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.String"),
                            ]), 1, 134230798),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677989, "remove_OnProcessLoad", 2198, "000101151285F1021C0E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`2<System.Object,System.String>"], 0,
                [
                    new("value", 0, 0, "System.Action`2<System.Object,System.String>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`2"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Object"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.String"),
                            ]), 1, 134230799),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677990, "add_OnProcessUpdate", 2198, "00010115128585031C12A81002",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`3<System.Object,Celeste.Mod.ModAsset,System.Boolean>"], 0,
                [
                    new("value", 0, 0,
                        "System.Action`3<System.Object,Celeste.Mod.ModAsset,System.Boolean>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`3"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Object"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Mod.ModAsset"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Boolean"),
                            ]), 1, 134230800),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677991, "remove_OnProcessUpdate", 2198, "00010115128585031C12A81002",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Action`3<System.Object,Celeste.Mod.ModAsset,System.Boolean>"], 0,
                [
                    new("value", 0, 0,
                        "System.Action`3<System.Object,Celeste.Mod.ModAsset,System.Boolean>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Action`3"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Object"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Celeste.Mod.ModAsset"),
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Boolean"),
                            ]), 1, 134230801),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677992, "Initialize", 147, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 27, 119));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677993, "TryGet", 150, "0003020E1012A81002", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                ["System.String", "Celeste.Mod.ModAsset&", "System.Boolean"], 0,
                [
                    new("path", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230802),
                    new("metadata", 1, 2, "Celeste.Mod.ModAsset&", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.ModAsset")), 2, 134230803),
                    new("includeDirs", 2, 4112, "System.Boolean", true,
                        "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230804),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 36, 69));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677994, "Get", 150, "000212A8100E02", (KeyValuePair<string, string>[])[], "Celeste.Mod.ModAsset",
                ["System.String", "System.Boolean"], 0,
                [
                    new("path", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230805),
                    new("includeDirs", 1, 4112, "System.Boolean", true,
                        "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134230806),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.ModAsset"), true, 9, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677995, "TryGet", 150, "100103020E1012A81002", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                ["System.String", "Celeste.Mod.ModAsset&", "System.Boolean"], 1,
                [
                    new("path", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230807),
                    new("metadata", 1, 2, "Celeste.Mod.ModAsset&", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "Celeste.Mod.ModAsset")), 2, 134230808),
                    new("includeDirs", 2, 4112, "System.Boolean", true,
                        "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230809),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 96, 212));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677996, "Get", 150, "10010212A8100E02", (KeyValuePair<string, string>[])[],
                "Celeste.Mod.ModAsset",
                ["System.String", "System.Boolean"], 1,
                [
                    new("path", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230810),
                    new("includeDirs", 1, 4112, "System.Boolean", true,
                        "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134230811),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Mod.ModAsset"), true, 9, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677997, "TryAdd", 150, "0002020E12A810", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.String", "Celeste.Mod.ModAsset"], 0,
                [
                    new("path", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230812),
                    new("metadata", 1, 0, "Celeste.Mod.ModAsset", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModAsset"), 2, 134230813),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 361, 969));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677998, "Add", 150, "0002010E12A810", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String", "Celeste.Mod.ModAsset"], 0,
                [
                    new("path", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230814),
                    new("metadata", 1, 0, "Celeste.Mod.ModAsset", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModAsset"), 2, 134230815),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100677999, "GuessType", 150, "00030E0E101280D1100E", (KeyValuePair<string, string>[])[],
                "System.String", ["System.String", "System.Type&", "System.String&"], 0,
                [
                    new("file", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230816),
                    new("type", 1, 2, "System.Type&", false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.Type")), 2, 134230817),
                    new("format", 2, 2, "System.String&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.String")), 3, 134230818),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 765, 2047));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678000, "SpanEqualsAny", 145, "000202151180B901031D0E", (KeyValuePair<string, string>[])[],
                "System.Boolean", ["System.ReadOnlySpan`1<System.Char>", "System.String[]"], 0,
                [
                    new("left", 0, 0, "System.ReadOnlySpan`1<System.Char>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ReadOnlySpan`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 1, 134230819),
                    new("right", 1, 0, "System.String[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.String"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 2,
                        134230820),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 28, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678001, "SpanEquals", 145, "000202151180B901030E", (KeyValuePair<string, string>[])[],
                "System.Boolean", ["System.ReadOnlySpan`1<System.Char>", "System.String"], 0,
                [
                    new("left", 0, 0, "System.ReadOnlySpan`1<System.Char>", false, null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ReadOnlySpan`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 1, 134230821),
                    new("right", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134230822),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678002, "MatchExtension", 145, "000502151180B90103151180B90103151180B90103100202",
                (KeyValuePair<string, string>[])[], "System.Boolean",
                [
                    "System.ReadOnlySpan`1<System.Char>", "System.ReadOnlySpan`1<System.Char>",
                    "System.ReadOnlySpan`1<System.Char>", "System.Boolean&", "System.Boolean",
                ], 0,
                [
                    new("filePath", 0, 0, "System.ReadOnlySpan`1<System.Char>", false,
                        null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ReadOnlySpan`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 1, 134230823),
                    new("fileName", 1, 0, "System.ReadOnlySpan`1<System.Char>", false,
                        null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ReadOnlySpan`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 2, 134230824),
                    new("expectedExtension", 2, 0, "System.ReadOnlySpan`1<System.Char>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ReadOnlySpan`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 3, 134230825),
                    new("warningAlreadySent", 3, 0, "System.Boolean&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 4, 134230826),
                    new("isTextBased", 4, 4112, "System.Boolean", true,
                        "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 5, 134230827),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 133, 314));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678003, "MatchMultipartExtension", 145, "000502151180B90103151180B90103151180B90103100202",
                (KeyValuePair<string, string>[])[], "System.Boolean",
                [
                    "System.ReadOnlySpan`1<System.Char>", "System.ReadOnlySpan`1<System.Char>",
                    "System.ReadOnlySpan`1<System.Char>", "System.Boolean&", "System.Boolean",
                ], 0,
                [
                    new("filePath", 0, 0, "System.ReadOnlySpan`1<System.Char>", false,
                        null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ReadOnlySpan`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 1, 134230828),
                    new("fileName", 1, 0, "System.ReadOnlySpan`1<System.Char>", false,
                        null,
                        [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ReadOnlySpan`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 2, 134230829),
                    new("expectedExtension", 2, 0, "System.ReadOnlySpan`1<System.Char>",
                        false, null, [],
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                "System.ReadOnlySpan`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    "System.Char"),
                            ]), 3, 134230830),
                    new("warningAlreadySent", 3, 0, "System.Boolean&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 4, 134230831),
                    new("isTextBased", 4, 4112, "System.Boolean", true,
                        "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 5, 134230832),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 229, 522));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678004, "RecrawlMod", 145, "00010112A798", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Mod.ModContent"], 0,
                [
                    new("mod", 0, 0, "Celeste.Mod.ModContent", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModContent"), 1, 134230833),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678005, "Update", 150, "00020112A81012A810", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Mod.ModAsset", "Celeste.Mod.ModAsset"], 0,
                [
                    new("prev", 0, 0, "Celeste.Mod.ModAsset", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModAsset"), 1, 134230834),
                    new("next", 1, 0, "Celeste.Mod.ModAsset", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModAsset"), 2, 134230835),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 353, 1223));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678006, "Crawl", 150, "00010112A798", (KeyValuePair<string, string>[])[], "System.Void",
                ["Celeste.Mod.ModContent"], 0,
                [
                    new("meta", 0, 0, "Celeste.Mod.ModContent", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModContent"), 1, 134230836),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 65, 195));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678007, "ProcessLoad", 150, "0002011C0E", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.String"], 0,
                [
                    new("asset", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230837),
                    new("assetNameFull", 1, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134230838),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 61, 165));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678008, "ProcessUpdate", 150, "0003011C12A81002", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["System.Object", "Celeste.Mod.ModAsset", "System.Boolean"], 0,
                [
                    new("asset", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134230839),
                    new("mapping", 1, 0, "Celeste.Mod.ModAsset", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModAsset"), 2, 134230840),
                    new("load", 2, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134230841),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 98, 303));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678009, "refreshEmojis", 145, "00010212A810", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                ["Celeste.Mod.ModAsset"], 0,
                [
                    new("mapping", 0, 0, "Celeste.Mod.ModAsset", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModAsset"), 1, 134230842),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 85, 237));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678010, "potentiallyContainsMountainTextures", 145, "00010212A810",
                (KeyValuePair<string, string>[])[], "System.Boolean", ["Celeste.Mod.ModAsset"], 0,
                [
                    new("mapping", 0, 0, "Celeste.Mod.ModAsset", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Mod.ModAsset"), 1, 134230843),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 49, 130));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678011, "DumpAll", 150, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 57, 163));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678012, "Dump", 150, "0002010E1C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.String", "System.Object"], 0,
                [
                    new("assetNameFull", 0, 0, "System.String", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134230844),
                    new("asset", 1, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 2, 134230845),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 175, 515));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content",
                33556820,
                100678013, ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 106, 355));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content+<>c",
                33556821, 100678014, ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content+<>c",
                33556821, 100678015, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest+Content+<>c",
                33556821, 100678016, "<Update>b__39_4", 131, "20011512808D011296F01296F4",
                (KeyValuePair<string, string>[])[],
                "System.Collections.Generic.IEnumerable`1<Celeste.ModeProperties>",
                ["Celeste.AreaData"], 0,
                [
                    new("area", 0, 0, "Celeste.AreaData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.AreaData"), 1, 134230847),
                ], "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        "System.Collections.Generic.IEnumerable`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.ModeProperties"),
                    ]), true, 3, 7));
        }
    }
}
