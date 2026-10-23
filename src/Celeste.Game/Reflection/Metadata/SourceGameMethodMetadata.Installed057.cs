using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMethodMetadata
    {
        private static void PublishInstalled057(SourceAssemblyMethodCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamWipe", 33555837,
                100672417,
                "Update", 198, "200101128588", (KeyValuePair<string, string>[])[], "System.Void",
                ["Monocle.Scene"], 0,
                [
                    new("scene", 0, 0, "Monocle.Scene", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Scene"), 1, 134226580),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 69, 198));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamWipe", 33555837,
                100672418,
                "Render", 198, "200101128588", (KeyValuePair<string, string>[])[], "System.Void",
                ["Monocle.Scene"], 0,
                [
                    new("scene", 0, 0, "Monocle.Scene", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Scene"), 1, 134226581),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 93, 278));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672419, "get_IdlePosition", 2182, "20001180A1", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", [], 0, [],
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 23, 63));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672420, "get_SelectedPosition", 2182, "20001180A1", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", [], 0, [],
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 4, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672421, "get_highlighted", 2177, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 7, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672422, "get_selected", 2177, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 9, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672423, "get_Golden", 2177, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 17, 41));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672424, "get_Card", 2177, "20001283E8", (KeyValuePair<string, string>[])[], "Monocle.Sprite",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Sprite"), true, 9, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672425, "get_Ticket", 2177, "20001283E8", (KeyValuePair<string, string>[])[], "Monocle.Sprite",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Sprite"), true, 9, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672426, ".ctor", 6273, "20020108129A8C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32", "Celeste.OuiFileSelect"], 0,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226582),
                    new("fileSelect", 1, 0, "Celeste.OuiFileSelect", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiFileSelect"), 2, 134226583),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 172, 605));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672427, ".ctor", 6278, "20030108129A8C02", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32", "Celeste.OuiFileSelect", "System.Boolean"], 0,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226584),
                    new("fileSelect", 1, 0, "Celeste.OuiFileSelect", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiFileSelect"), 2, 134226585),
                    new("corrupted", 2, 0, "System.Boolean", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134226586),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 29));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672428, ".ctor", 6278, "20030108129A8C129BB0",
                (KeyValuePair<string, string>[])[new("MonoMod.PatchTotalHeartGemChecksAttribute", "01000000")],
                "System.Void", ["System.Int32", "Celeste.OuiFileSelect", "Celeste.SaveData"], 0,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226587),
                    new("fileSelect", 1, 0, "Celeste.OuiFileSelect", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiFileSelect"), 2, 134226588),
                    new("data", 2, 0, "Celeste.SaveData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.SaveData"), 3, 134226589),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 157, 461));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672429, "Setup", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 39, 131));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672430, "CreateButtons", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 75, 252));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672431, "OnContinueSelected", 129, "200001",
                (KeyValuePair<string, string>[])
                [
                    new("MonoMod.PatchOuiFileSelectSlotOnContinueSelectedAttribute",
                        "01000000"),
                ], "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 125, 412));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672432, "OnDeleteSelected", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672433, "OnNewGameSelected", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 37, 112));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672434, "EnterFirstArea", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 18, 58));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672435, "EnterFirstAreaRoutine", 129, "2000128109",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "01003643656C657374652E4F756946696C6553656C656374536C6F742B3C456E746572466972737441726561526F7574696E653E645F5F34370000"),
                ], "System.Collections.IEnumerator", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Collections.IEnumerator"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672436, "OnRenameSelected", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 53));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672437, "OnAssistSelected", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 41));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672438, "OnVariantSelected", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 56, 188));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672439, "HiddenPosition", 134, "20021180A10808", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", ["System.Int32", "System.Int32"], 0,
                [
                    new("x", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226590),
                    new("y", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134226591),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 34, 119));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672440, "Show", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 223, 666));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672441, "Select", 134, "20010102", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Boolean"], 0,
                [
                    new("resetButtonIndex", 0, 0, "System.Boolean", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134226592),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 60, 166));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672442, "Unselect", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672443, "MoveTo", 134, "2002010C0C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single", "System.Single"], 0,
                [
                    new("x", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134226593),
                    new("y", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134226594),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 22, 63));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672444, "Hide", 134, "2002010808", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32", "System.Int32"], 0,
                [
                    new("x", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226595),
                    new("y", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134226596),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 23, 64));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672445, "StartTween", 129, "2003010C151280F50112845002", (KeyValuePair<string, string>[])[],
                "System.Void", ["System.Single", "System.Action`1<Monocle.Tween>", "System.Boolean"], 0,
                [
                    new("duration", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134226597),
                    new("callback", 1, 0, "System.Action`1<Monocle.Tween>", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Monocle.Tween"),
                            ]), 2, 134226598),
                    new("hide", 2, 4112, "System.Boolean", true, "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134226599),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 45, 128));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672446, "Update", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 74, 268));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672447, "Render", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 73, 188));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672448, "SelectionColor", 134, "20011180AD02", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Color", ["System.Boolean"], 0,
                [
                    new("selected", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134226600),
                ], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Color"), true, 16, 51));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672449, "orig_get_Golden", 129, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 16, 40));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672450, "orig_Show", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 41, 118));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672451, "orig_CreateButtons", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 202, 693));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672452, "OnExistingFileRenameSelected", 129, "200001", (KeyValuePair<string, string>[])[],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 60));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672453, "orig_OnNewGameSelected", 129, "200001", (KeyValuePair<string, string>[])[],
                "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 34, 94));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672454, "orig_Update", 134, "200001",
                (KeyValuePair<string, string>[])[new("MonoMod.PatchOuiFileSelectSlotUpdateAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 316, 1055));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672455, "WiggleMenu", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672456, "orig_Unselect", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 20, 57));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672457, "orig_Render", 134, "200001",
                (KeyValuePair<string, string>[])
                [
                    new("MonoMod.PatchFileSelectSlotRenderMissingVanillaDataDialog",
                        "01000000"),
                    new("MonoMod.PatchFileSelectSlotRenderAttribute", "01000000"),
                ], "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 968, 3242));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot", 33555839,
                100672458, "ScrollTo", 131, "2002010C0C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Single", "System.Single"], 0,
                [
                    new("x", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134226601),
                    new("y", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134226602),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 69, 195));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot+Button",
                33555840, 100672459, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot+<>c",
                33555841,
                100672460, ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot+<>c",
                33555841,
                100672461, ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot+<>c",
                33555841,
                100672462, "<OnContinueSelected>b__64_0", 131, "200001", (KeyValuePair<string, string>[])[],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot+<>c",
                33555841,
                100672463, "orig_ctor_<>c", 145, "000001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot+<>c",
                33555841,
                100672464, "<CreateButtons>b__39_0", 131, "20010E1296F4", (KeyValuePair<string, string>[])[],
                "System.String", ["Celeste.AreaData"], 0,
                [
                    new("area", 0, 0, "Celeste.AreaData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.AreaData"), 1, 134226603),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiFileSelectSlot+<>c",
                33555841,
                100672465, "<CreateButtons>b__39_1", 131, "200102129600", (KeyValuePair<string, string>[])[],
                "System.Boolean", ["Celeste.OuiFileSelectSlot+Button"], 0,
                [
                    new("button", 0, 0, "Celeste.OuiFileSelectSlot+Button", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.OuiFileSelectSlot+Button"), 1, 134226604),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 7, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__68", 33555842, 100672466, ".ctor", 6278,
                "20010108",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Int32"], 0,
                [
                    new("<>1__state", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226605),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__68", 33555842, 100672467,
                "System.IDisposable.Dispose",
                481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__68", 33555842, 100672468, "MoveNext", 481,
                "200002",
                (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 137, 411));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__68", 33555842, 100672469,
                "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__68", 33555842, 100672470,
                "System.Collections.IEnumerator.Reset", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__68", 33555842, 100672471,
                "System.Collections.IEnumerator.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass73_0", 33555843, 100672472, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass73_0", 33555843, 100672473, "<Show>b__0", 131,
                "200101128450",
                (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("f", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226606),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 40));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass74_0", 33555844, 100672474, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass74_0", 33555844, 100672475, "<Select>b__0", 131,
                "200101128450",
                (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("f", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226607),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 27, 87));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass75_0", 33555845, 100672476, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass75_0", 33555845, 100672477, "<Unselect>b__0", 131,
                "200101128450", (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("f", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226608),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 26, 86));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass76_0", 33555846, 100672478, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass76_0", 33555846, 100672479, "<MoveTo>b__0", 131,
                "200101128450",
                (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("f", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226609),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass77_0", 33555847, 100672480, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass77_0", 33555847, 100672481, "<Hide>b__0", 131,
                "200101128450",
                (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("f", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226610),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass78_0", 33555848, 100672482, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass78_0", 33555848, 100672483, "<StartTween>b__0", 131,
                "200101128450", (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("t", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226611),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 12, 33));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass43_0", 33555850, 100672484, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass43_0", 33555850, 100672485, "<OnNewGameSelected>b__0", 131,
                "2001021296F4", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["Celeste.AreaData"], 0,
                [
                    new("area", 0, 0, "Celeste.AreaData", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.AreaData"), 1, 134226612),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass53_0", 33555851, 100672486, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass53_0", 33555851, 100672487, "<ScrollTo>b__0", 131,
                "200101128450", (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("t", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226613),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<>c__DisplayClass53_0", 33555851, 100672488, "<ScrollTo>b__1", 131,
                "200101128450", (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("t", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226614),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__47", 33555852, 100672489,
                "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__47", 33555852, 100672490,
                "System.Collections.IEnumerator.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__47", 33555852, 100672491, ".ctor", 6278,
                "20010108",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Int32"], 0,
                [
                    new("<>1__state", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226615),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__47", 33555852, 100672492,
                "System.IDisposable.Dispose",
                481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__47", 33555852, 100672493, "MoveNext", 481,
                "200002",
                (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 174, 553));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiFileSelectSlot+<EnterFirstAreaRoutine>d__47", 33555852, 100672494,
                "System.Collections.IEnumerator.Reset", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672495, "get_IdlePosition", 2182, "20001180A1", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", [], 0, [],
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 47, 143));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672496, "get_HiddenPosition", 2182, "20001180A1", (KeyValuePair<string, string>[])[],
                "Microsoft.Xna.Framework.Vector2", [], 0, [],
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2"), true, 6, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672497, ".ctor", 6278, "20030108128478128478", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32", "Monocle.MTexture", "Monocle.MTexture"], 0,
                [
                    new("area", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226616),
                    new("front", 1, 0, "Monocle.MTexture", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.MTexture"), 2, 134226617),
                    new("back", 2, 0, "Monocle.MTexture", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.MTexture"), 3, 134226618),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 180, 541));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672498, "Hovered", 134, "20010108", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Int32"], 0,
                [
                    new("dir", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226619),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 22));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672499, "Select", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 74));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672500, "SnapToSelected", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672501, "Unselect", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 74));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672502, "Hide", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 74));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672503, "Show", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 43, 127));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672504, "AssistModeUnlock", 134, "200101128139", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["System.Action"], 0,
                [
                    new("onComplete", 0, 0, "System.Action", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Action"), 1, 134226620),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672505, "AssistModeUnlockRoutine", 129, "2001128109128139",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "01003B43656C657374652E4F75694368617074657253656C65637449636F6E2B3C4173736973744D6F6465556E6C6F636B526F7574696E653E645F5F33370000"),
                ], "System.Collections.IEnumerator", ["System.Action"], 0,
                [
                    new("onComplete", 0, 0, "System.Action", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Action"), 1, 134226621),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Collections.IEnumerator"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672506, "HighlightUnlock", 134, "200101128139", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["System.Action"], 0,
                [
                    new("onComplete", 0, 0, "System.Action", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Action"), 1, 134226622),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672507, "HighlightUnlockRoutine", 129, "2001128109128139",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "01003A43656C657374652E4F75694368617074657253656C65637449636F6E2B3C486967686C69676874556E6C6F636B526F7574696E653E645F5F33390000"),
                ], "System.Collections.IEnumerator", ["System.Action"], 0,
                [
                    new("onComplete", 0, 0, "System.Action", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Action"), 1, 134226623),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Collections.IEnumerator"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672508, "StartTween", 129, "2002010C151280F501128450", (KeyValuePair<string, string>[])[],
                "System.Void", ["System.Single", "System.Action`1<Monocle.Tween>"], 0,
                [
                    new("duration", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134226624),
                    new("callback", 1, 0, "System.Action`1<Monocle.Tween>", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.GenericInstance,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Action`1"),
                            genericArguments:
                            [
                                new(
                                    SourceTypeReferenceKind.Named,
                                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    "Monocle.Tween"),
                            ]), 2, 134226625),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 25, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672509, "StopTween", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 11, 28));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672510, "SetSelectedPercent", 129, "2002011180A10C", (KeyValuePair<string, string>[])[],
                "System.Void", ["Microsoft.Xna.Framework.Vector2", "System.Single"], 0,
                [
                    new("from", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                        [], "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"), 1, 134226626),
                    new("p", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134226627),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 92, 270));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672511, "Update", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 102, 277));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672512, "Render", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [],
                0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 178, 591));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672513, "<.ctor>b__29_0", 129, "2001010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Single"], 0,
                [
                    new("f", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134226628),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 21, 55));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672514, "<StartTween>b__40_0", 129, "200101128450",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("t", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226629),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672515, "get_IsHidden", 2182, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672516, "get_IsSelected", 2182, "200002", (KeyValuePair<string, string>[])[], "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672517, "orig_ctor", 134, "20030108128478128478", (KeyValuePair<string, string>[])[],
                "System.Void",
                ["System.Int32", "Monocle.MTexture", "Monocle.MTexture"], 0,
                [
                    new("area", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226630),
                    new("front", 1, 0, "Monocle.MTexture", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.MTexture"), 2, 134226631),
                    new("back", 2, 0, "Monocle.MTexture", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.MTexture"), 3, 134226632),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 68, 201));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiChapterSelectIcon",
                33555853,
                100672518, "orig_Update", 134, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 84, 274));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<>c__DisplayClass31_0", 33555854, 100672519, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<>c__DisplayClass31_0", 33555854, 100672520, "<Select>b__0", 131,
                "200101128450", (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("t", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226633),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 8, 24));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<>c__DisplayClass33_0", 33555855, 100672521, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<>c__DisplayClass33_0", 33555855, 100672522, "<Unselect>b__0", 131,
                "200101128450", (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("t", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226634),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 10, 30));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<>c__DisplayClass34_0", 33555856, 100672523, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<>c__DisplayClass34_0", 33555856, 100672524, "<Hide>b__0", 131,
                "200101128450", (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("t", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226635),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 14, 50));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<>c__DisplayClass35_0", 33555857, 100672525, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<>c__DisplayClass35_0", 33555857, 100672526, "<Show>b__0", 131,
                "200101128450", (KeyValuePair<string, string>[])[], "System.Void", ["Monocle.Tween"], 0,
                [
                    new("t", 0, 0, "Monocle.Tween", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Monocle.Tween"), 1, 134226636),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 14, 50));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<AssistModeUnlockRoutine>d__37", 33555858, 100672527, ".ctor", 6278,
                "20010108",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Int32"], 0,
                [
                    new("<>1__state", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226637),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<AssistModeUnlockRoutine>d__37", 33555858, 100672528,
                "System.IDisposable.Dispose", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<AssistModeUnlockRoutine>d__37", 33555858, 100672529, "MoveNext", 481,
                "200002", (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 238, 725));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<AssistModeUnlockRoutine>d__37", 33555858, 100672530,
                "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<AssistModeUnlockRoutine>d__37", 33555858, 100672531,
                "System.Collections.IEnumerator.Reset", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<AssistModeUnlockRoutine>d__37", 33555858, 100672532,
                "System.Collections.IEnumerator.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<HighlightUnlockRoutine>d__39", 33555859, 100672533, ".ctor", 6278,
                "20010108",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Int32"], 0,
                [
                    new("<>1__state", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226638),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<HighlightUnlockRoutine>d__39", 33555859, 100672534,
                "System.IDisposable.Dispose", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<HighlightUnlockRoutine>d__39", 33555859, 100672535, "MoveNext", 481,
                "200002", (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 139, 426));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<HighlightUnlockRoutine>d__39", 33555859, 100672536,
                "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<HighlightUnlockRoutine>d__39", 33555859, 100672537,
                "System.Collections.IEnumerator.Reset", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+<HighlightUnlockRoutine>d__39", 33555859, 100672538,
                "System.Collections.IEnumerator.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta", 33555860, 100672539, "get_FrontFPS", 2182,
                "200015118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<System.Single>", [], 0, [],
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
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta", 33555860, 100672540, "set_FrontFPS", 2182,
                "20010115118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<System.Single>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<System.Single>", false, null,
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
                            ]), 1, 134226639),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta", 33555860, 100672541, "get_BackFPS", 2182,
                "200015118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Nullable`1<System.Single>", [], 0, [],
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
                    ]), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta", 33555860, 100672542, "set_BackFPS", 2182,
                "20010115118141010C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.Void", ["System.Nullable`1<System.Single>"], 0,
                [
                    new("value", 0, 0, "System.Nullable`1<System.Single>", false, null,
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
                            ]), 1, 134226640),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta", 33555860, 100672543, "get_FrontFrames", 2182,
                "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta", 33555860, 100672544, "set_FrontFrames", 2182,
                "2001010E",
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
                            "System.String"), 1, 134226641),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta", 33555860, 100672545, "get_BackFrames", 2182,
                "20000E",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "01000000"),
                ], "System.String", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta", 33555860, 100672546, "set_BackFrames", 2182,
                "2001010E",
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
                            "System.String"), 1, 134226642),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OuiChapterSelectIcon+AnimatedMapIconMeta", 33555860, 100672547, ".ctor", 6278, "200001",
                (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672548,
                "get_Page", 2182, "2000129670", (KeyValuePair<string, string>[])[], "Celeste.OuiJournalPage",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672549,
                "get_NextPage", 2182, "2000129670", (KeyValuePair<string, string>[])[], "Celeste.OuiJournalPage",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672550,
                "get_PrevPage", 2182, "2000129670", (KeyValuePair<string, string>[])[], "Celeste.OuiJournalPage",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage"), true, 8, 20));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672551,
                "Enter", 198, "2001128109129AE4",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "01001F43656C657374652E4F75694A6F75726E616C2B3C456E7465723E645F5F32360000"),
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "01001E43656C657374652E4F75694A6F75726E616C2B3C456E7465723E645F5F310000"),
                ], "System.Collections.IEnumerator", ["Celeste.Oui"], 0,
                [
                    new("from", 0, 0, "Celeste.Oui", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Oui"), 1, 134226643),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Collections.IEnumerator"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672552,
                "HandleGraphicsReset", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 38));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672553,
                "TurnPage", 134, "200112810908",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "01002243656C657374652E4F75694A6F75726E616C2B3C5475726E506167653E645F5F32380000"),
                ], "System.Collections.IEnumerator", ["System.Int32"], 0,
                [
                    new("direction", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226644),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Collections.IEnumerator"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672554,
                "Leave", 198, "2001128109129AE4",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "01001F43656C657374652E4F75694A6F75726E616C2B3C4C656176653E645F5F32390000"),
                ], "System.Collections.IEnumerator", ["Celeste.Oui"], 0,
                [
                    new("next", 0, 0, "Celeste.Oui", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Oui"), 1, 134226645),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Collections.IEnumerator"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672555,
                "EaseOut", 129, "20011281090C",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "01002143656C657374652E4F75694A6F75726E616C2B3C456173654F75743E645F5F33300000"),
                ], "System.Collections.IEnumerator", ["System.Single"], 0,
                [
                    new("duration", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134226646),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Collections.IEnumerator"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672556,
                "Update", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 133, 397));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672557,
                "Close", 129, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 13, 34));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672558,
                "Render", 198, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 332, 1153));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672559,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 17, 65));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal", 33555861,
                100672560,
                "orig_Enter", 134, "2001128109129AE4",
                (KeyValuePair<string, string>[])
                [
                    new("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                        "01001F43656C657374652E4F75694A6F75726E616C2B3C456E7465723E645F5F32360000"),
                ], "System.Collections.IEnumerator", ["Celeste.Oui"], 0,
                [
                    new("from", 0, 0, "Celeste.Oui", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "Celeste.Oui"), 1, 134226647),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Collections.IEnumerator"), true, 9, 21));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                33555862, 100672561, ".ctor", 6278, "20010108",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Int32"], 0,
                [
                    new("<>1__state", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226648),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                33555862, 100672562, "System.IDisposable.Dispose", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                33555862, 100672563, "MoveNext", 481, "200002", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 239, 750));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                33555862, 100672564, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529,
                "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                33555862, 100672565, "System.Collections.IEnumerator.Reset", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Enter>d__26",
                33555862, 100672566, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                33555863, 100672567, ".ctor", 6278, "20010108",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Int32"], 0,
                [
                    new("<>1__state", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226649),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                33555863, 100672568, "System.IDisposable.Dispose", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                33555863, 100672569, "MoveNext", 481, "200002", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 131, 375));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                33555863, 100672570, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529,
                "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                33555863, 100672571, "System.Collections.IEnumerator.Reset", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 2, 6));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<TurnPage>d__28",
                33555863, 100672572, "System.Collections.IEnumerator.get_Current", 2529, "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                33555864, 100672573, ".ctor", 6278, "20010108",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", ["System.Int32"], 0,
                [
                    new("<>1__state", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134226650),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                33555864, 100672574, "System.IDisposable.Dispose", 481, "200001",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Void", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 1, 1));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                33555864, 100672575, "MoveNext", 481, "200002", (KeyValuePair<string, string>[])[],
                "System.Boolean",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 84, 246));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournal+<Leave>d__29",
                33555864, 100672576, "System.Collections.Generic.IEnumerator<System.Object>.get_Current", 2529,
                "20001C",
                (KeyValuePair<string, string>[])[new("System.Diagnostics.DebuggerHiddenAttribute", "01000000")],
                "System.Object", [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), true, 3, 7));
        }
    }
}
