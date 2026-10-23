using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMethodMetadata
    {
        private static void PublishOriginal000(SourceAssemblyMethodCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663297,
                "Generate", 150, "00010C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single"], 0,
                [
                    new("x", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134217729),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 58, 106));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663298,
                "Generate", 150, "00020C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single"], 0,
                [
                    new("x", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134217730),
                    new("y", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134217731),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 208, 420));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663299,
                "Generate", 150, "00030C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("x", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134217732),
                    new("y", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134217733),
                    new("z", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134217734),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 429, 839));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663300,
                "FastFloor", 145, "0001080C", (KeyValuePair<string, string>[])[], "System.Int32",
                ["System.Single"], 0,
                [
                    new("x", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134217735),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 11, 16));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663301,
                "Mod", 145, "0002080808", (KeyValuePair<string, string>[])[], "System.Int32",
                ["System.Int32", "System.Int32"], 0,
                [
                    new("x", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134217736),
                    new("m", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134217737),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 13, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663302,
                "grad", 145, "00020C080C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Int32", "System.Single"], 0,
                [
                    new("hash", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134217738),
                    new("x", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134217739),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 22, 28));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663303,
                "grad", 145, "00030C080C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Int32", "System.Single", "System.Single"], 0,
                [
                    new("hash", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134217740),
                    new("x", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134217741),
                    new("y", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134217742),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 39, 55));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663304,
                "grad", 145, "00040C080C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Int32", "System.Single", "System.Single", "System.Single"], 0,
                [
                    new("hash", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134217743),
                    new("x", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134217744),
                    new("y", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134217745),
                    new("z", 3, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134217746),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 44, 58));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663305,
                "grad", 145, "00050C080C0C0C0C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.Int32", "System.Single", "System.Single", "System.Single", "System.Single"], 0,
                [
                    new("hash", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134217747),
                    new("x", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134217748),
                    new("y", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134217749),
                    new("z", 3, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134217750),
                    new("t", 4, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134217751),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), true, 52, 68));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663306,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "SimplexNoise.Noise", 33554434,
                100663307,
                ".cctor", 6289, "000001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 7, 27));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.VERSION", 33554435, 100663308,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.CONSTANTS", 33554436, 100663309,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ERRORCALLBACK_INFO", 33554461,
                100663310, "get_functionname", 2182, "20000E", (KeyValuePair<string, string>[])[], "System.String",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ERRORCALLBACK_INFO", 33554461,
                100663311, "get_functionparams", 2182, "20000E", (KeyValuePair<string, string>[])[],
                "System.String",
                [], 0, [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.StringWrapper", 33554463,
                100663312,
                "op_Implicit", 2198, "00010E117C", (KeyValuePair<string, string>[])[], "System.String",
                ["FMOD.StringWrapper"], 0,
                [
                    new("fstring", 0, 0, "FMOD.StringWrapper", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.StringWrapper"), 1, 134217752),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 39, 91));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ASYNCREADINFO_DONE_CALLBACK",
                33554464, 100663313, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217753),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217754),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ASYNCREADINFO_DONE_CALLBACK",
                33554464, 100663314, "Invoke", 454, "20021114181114", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "FMOD.RESULT"], 0,
                [
                    new("info", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217755),
                    new("result", 1, 0, "FMOD.RESULT", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.RESULT"), 2, 134217756),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ASYNCREADINFO_DONE_CALLBACK",
                33554464, 100663315, "BeginInvoke", 454, "2004125D18111412611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                ["System.IntPtr", "FMOD.RESULT", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("info", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217757),
                    new("result", 1, 0, "FMOD.RESULT", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.RESULT"), 2, 134217758),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 3, 134217759),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134217760),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ASYNCREADINFO_DONE_CALLBACK",
                33554464, 100663316, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217761),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DEBUG_CALLBACK", 33554465,
                100663317, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217762),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217763),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DEBUG_CALLBACK", 33554465,
                100663318, "Invoke", 454, "2005111411300E080E0E", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.DEBUG_FLAGS", "System.String", "System.Int32", "System.String", "System.String"], 0,
                [
                    new("flags", 0, 0, "FMOD.DEBUG_FLAGS", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DEBUG_FLAGS"), 1, 134217764),
                    new("file", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134217765),
                    new("line", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134217766),
                    new("func", 3, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 4, 134217767),
                    new("message", 4, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 5, 134217768),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DEBUG_CALLBACK", 33554465,
                100663319, "BeginInvoke", 454, "2007125D11300E080E0E12611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "FMOD.DEBUG_FLAGS", "System.String", "System.Int32", "System.String", "System.String",
                    "System.AsyncCallback", "System.Object",
                ], 0,
                [
                    new("flags", 0, 0, "FMOD.DEBUG_FLAGS", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DEBUG_FLAGS"), 1, 134217769),
                    new("file", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134217770),
                    new("line", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134217771),
                    new("func", 3, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 4, 134217772),
                    new("message", 4, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 5, 134217773),
                    new("callback", 5, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 6, 134217774),
                    new("object", 6, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 7, 134217775),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DEBUG_CALLBACK", 33554465,
                100663320, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217776),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SYSTEM_CALLBACK", 33554466,
                100663321, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217777),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217778),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SYSTEM_CALLBACK", 33554466,
                100663322, "Invoke", 454, "20051114181178181818", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "FMOD.SYSTEM_CALLBACK_TYPE", "System.IntPtr", "System.IntPtr", "System.IntPtr"],
                0,
                [
                    new("systemraw", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217779),
                    new("type", 1, 0, "FMOD.SYSTEM_CALLBACK_TYPE", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.SYSTEM_CALLBACK_TYPE"), 2, 134217780),
                    new("commanddata1", 2, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 3, 134217781),
                    new("commanddata2", 3, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 4, 134217782),
                    new("userdata", 4, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 5, 134217783),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SYSTEM_CALLBACK", 33554466,
                100663323, "BeginInvoke", 454, "2007125D18117818181812611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "System.IntPtr", "FMOD.SYSTEM_CALLBACK_TYPE", "System.IntPtr", "System.IntPtr", "System.IntPtr",
                    "System.AsyncCallback", "System.Object",
                ], 0,
                [
                    new("systemraw", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217784),
                    new("type", 1, 0, "FMOD.SYSTEM_CALLBACK_TYPE", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.SYSTEM_CALLBACK_TYPE"), 2, 134217785),
                    new("commanddata1", 2, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 3, 134217786),
                    new("commanddata2", 3, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 4, 134217787),
                    new("userdata", 4, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 5, 134217788),
                    new("callback", 5, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 6, 134217789),
                    new("object", 6, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 7, 134217790),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SYSTEM_CALLBACK", 33554466,
                100663324, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217791),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.CHANNEL_CALLBACK", 33554467,
                100663325, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217792),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217793),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.CHANNEL_CALLBACK", 33554467,
                100663326, "Invoke", 454, "2005111418111811681818", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                [
                    "System.IntPtr", "FMOD.CHANNELCONTROL_TYPE", "FMOD.CHANNELCONTROL_CALLBACK_TYPE", "System.IntPtr",
                    "System.IntPtr",
                ], 0,
                [
                    new("channelraw", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217794),
                    new("controltype", 1, 0, "FMOD.CHANNELCONTROL_TYPE", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.CHANNELCONTROL_TYPE"), 2, 134217795),
                    new("type", 2, 0, "FMOD.CHANNELCONTROL_CALLBACK_TYPE", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.CHANNELCONTROL_CALLBACK_TYPE"), 3, 134217796),
                    new("commanddata1", 3, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 4, 134217797),
                    new("commanddata2", 4, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 5, 134217798),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.CHANNEL_CALLBACK", 33554467,
                100663327, "BeginInvoke", 454, "2007125D1811181168181812611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "System.IntPtr", "FMOD.CHANNELCONTROL_TYPE", "FMOD.CHANNELCONTROL_CALLBACK_TYPE", "System.IntPtr",
                    "System.IntPtr", "System.AsyncCallback", "System.Object",
                ], 0,
                [
                    new("channelraw", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217799),
                    new("controltype", 1, 0, "FMOD.CHANNELCONTROL_TYPE", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.CHANNELCONTROL_TYPE"), 2, 134217800),
                    new("type", 2, 0, "FMOD.CHANNELCONTROL_CALLBACK_TYPE", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.CHANNELCONTROL_CALLBACK_TYPE"), 3, 134217801),
                    new("commanddata1", 3, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 4, 134217802),
                    new("commanddata2", 4, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 5, 134217803),
                    new("callback", 5, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 6, 134217804),
                    new("object", 6, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 7, 134217805),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.CHANNEL_CALLBACK", 33554467,
                100663328, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217806),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_NONBLOCKCALLBACK",
                33554468,
                100663329, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217807),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217808),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_NONBLOCKCALLBACK",
                33554468,
                100663330, "Invoke", 454, "20021114181114", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "FMOD.RESULT"], 0,
                [
                    new("soundraw", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217809),
                    new("result", 1, 0, "FMOD.RESULT", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.RESULT"), 2, 134217810),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_NONBLOCKCALLBACK",
                33554468,
                100663331, "BeginInvoke", 454, "2004125D18111412611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                ["System.IntPtr", "FMOD.RESULT", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("soundraw", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217811),
                    new("result", 1, 0, "FMOD.RESULT", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.RESULT"), 2, 134217812),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 3, 134217813),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134217814),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_NONBLOCKCALLBACK",
                33554468,
                100663332, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217815),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_PCMREADCALLBACK",
                33554469,
                100663333, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217816),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217817),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_PCMREADCALLBACK",
                33554469,
                100663334, "Invoke", 454, "20031114181809", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr", "System.UInt32"], 0,
                [
                    new("soundraw", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217818),
                    new("data", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217819),
                    new("datalen", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134217820),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_PCMREADCALLBACK",
                33554469,
                100663335, "BeginInvoke", 454, "2005125D18180912611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                ["System.IntPtr", "System.IntPtr", "System.UInt32", "System.AsyncCallback", "System.Object"],
                0,
                [
                    new("soundraw", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217821),
                    new("data", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217822),
                    new("datalen", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134217823),
                    new("callback", 3, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 4, 134217824),
                    new("object", 4, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 5, 134217825),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_PCMREADCALLBACK",
                33554469,
                100663336, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217826),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_PCMSETPOSCALLBACK",
                33554470,
                100663337, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217827),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217828),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_PCMSETPOSCALLBACK",
                33554470,
                100663338, "Invoke", 454, "200411141808091180D8", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.Int32", "System.UInt32", "FMOD.TIMEUNIT"], 0,
                [
                    new("soundraw", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217829),
                    new("subsound", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134217830),
                    new("position", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134217831),
                    new("postype", 3, 0, "FMOD.TIMEUNIT", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 4, 134217832),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_PCMSETPOSCALLBACK",
                33554470,
                100663339, "BeginInvoke", 454, "2006125D1808091180D812611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "System.IntPtr", "System.Int32", "System.UInt32", "FMOD.TIMEUNIT", "System.AsyncCallback",
                    "System.Object",
                ], 0,
                [
                    new("soundraw", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217833),
                    new("subsound", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134217834),
                    new("position", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134217835),
                    new("postype", 3, 0, "FMOD.TIMEUNIT", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 4, 134217836),
                    new("callback", 4, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 5, 134217837),
                    new("object", 5, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 6, 134217838),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.SOUND_PCMSETPOSCALLBACK",
                33554470,
                100663340, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217839),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_OPENCALLBACK", 33554471,
                100663341, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217840),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217841),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_OPENCALLBACK", 33554471,
                100663342, "Invoke", 454, "20041114117C1009101818", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["FMOD.StringWrapper", "System.UInt32&", "System.IntPtr&", "System.IntPtr"], 0,
                [
                    new("name", 0, 0, "FMOD.StringWrapper", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.StringWrapper"), 1, 134217842),
                    new("filesize", 1, 0, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 2, 134217843),
                    new("handle", 2, 0, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 3, 134217844),
                    new("userdata", 3, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 4, 134217845),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_OPENCALLBACK", 33554471,
                100663343, "BeginInvoke", 454, "2006125D117C100910181812611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "FMOD.StringWrapper", "System.UInt32&", "System.IntPtr&", "System.IntPtr", "System.AsyncCallback",
                    "System.Object",
                ], 0,
                [
                    new("name", 0, 0, "FMOD.StringWrapper", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.StringWrapper"), 1, 134217846),
                    new("filesize", 1, 0, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 2, 134217847),
                    new("handle", 2, 0, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 3, 134217848),
                    new("userdata", 3, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 4, 134217849),
                    new("callback", 4, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 5, 134217850),
                    new("object", 5, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 6, 134217851),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_OPENCALLBACK", 33554471,
                100663344, "EndInvoke", 454, "2003111410091018125D", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.UInt32&", "System.IntPtr&", "System.IAsyncResult"], 0,
                [
                    new("filesize", 0, 0, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 1, 134217852),
                    new("handle", 1, 0, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 2, 134217853),
                    new("result", 2, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 3, 134217854),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_CLOSECALLBACK", 33554472,
                100663345, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217855),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217856),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_CLOSECALLBACK", 33554472,
                100663346, "Invoke", 454, "200211141818", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr"], 0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217857),
                    new("userdata", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217858),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_CLOSECALLBACK", 33554472,
                100663347, "BeginInvoke", 454, "2004125D181812611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                ["System.IntPtr", "System.IntPtr", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217859),
                    new("userdata", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217860),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 3, 134217861),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134217862),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_CLOSECALLBACK", 33554472,
                100663348, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217863),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_READCALLBACK", 33554473,
                100663349, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217864),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217865),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_READCALLBACK", 33554473,
                100663350, "Invoke", 454, "20051114181809100918", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr", "System.UInt32", "System.UInt32&", "System.IntPtr"], 0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217866),
                    new("buffer", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217867),
                    new("sizebytes", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134217868),
                    new("bytesread", 3, 0, "System.UInt32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 4, 134217869),
                    new("userdata", 4, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 5, 134217870),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_READCALLBACK", 33554473,
                100663351, "BeginInvoke", 454, "2007125D18180910091812611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "System.IntPtr", "System.IntPtr", "System.UInt32", "System.UInt32&", "System.IntPtr",
                    "System.AsyncCallback", "System.Object",
                ], 0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217871),
                    new("buffer", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217872),
                    new("sizebytes", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134217873),
                    new("bytesread", 3, 0, "System.UInt32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 4, 134217874),
                    new("userdata", 4, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 5, 134217875),
                    new("callback", 5, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 6, 134217876),
                    new("object", 6, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 7, 134217877),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_READCALLBACK", 33554473,
                100663352, "EndInvoke", 454, "200211141009125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32&", "System.IAsyncResult"], 0,
                [
                    new("bytesread", 0, 0, "System.UInt32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 1, 134217878),
                    new("result", 1, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 2, 134217879),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_SEEKCALLBACK", 33554474,
                100663353, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217880),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217881),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_SEEKCALLBACK", 33554474,
                100663354, "Invoke", 454, "20031114180918", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.UInt32", "System.IntPtr"], 0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217882),
                    new("pos", 1, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 2, 134217883),
                    new("userdata", 2, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 3, 134217884),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_SEEKCALLBACK", 33554474,
                100663355, "BeginInvoke", 454, "2005125D18091812611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                ["System.IntPtr", "System.UInt32", "System.IntPtr", "System.AsyncCallback", "System.Object"],
                0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217885),
                    new("pos", 1, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 2, 134217886),
                    new("userdata", 2, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 3, 134217887),
                    new("callback", 3, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 4, 134217888),
                    new("object", 4, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 5, 134217889),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_SEEKCALLBACK", 33554474,
                100663356, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217890),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_ASYNCREADCALLBACK",
                33554475,
                100663357, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217891),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217892),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_ASYNCREADCALLBACK",
                33554475,
                100663358, "Invoke", 454, "20031114181818", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr", "System.IntPtr"], 0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217893),
                    new("info", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217894),
                    new("userdata", 2, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 3, 134217895),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_ASYNCREADCALLBACK",
                33554475,
                100663359, "BeginInvoke", 454, "2005125D18181812611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                ["System.IntPtr", "System.IntPtr", "System.IntPtr", "System.AsyncCallback", "System.Object"],
                0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217896),
                    new("info", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217897),
                    new("userdata", 2, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 3, 134217898),
                    new("callback", 3, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 4, 134217899),
                    new("object", 4, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 5, 134217900),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_ASYNCREADCALLBACK",
                33554475,
                100663360, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217901),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_ASYNCCANCELCALLBACK",
                33554476,
                100663361, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217902),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217903),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_ASYNCCANCELCALLBACK",
                33554476,
                100663362, "Invoke", 454, "200211141818", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr"], 0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217904),
                    new("userdata", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217905),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_ASYNCCANCELCALLBACK",
                33554476,
                100663363, "BeginInvoke", 454, "2004125D181812611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                ["System.IntPtr", "System.IntPtr", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("handle", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217906),
                    new("userdata", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217907),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 3, 134217908),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134217909),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.FILE_ASYNCCANCELCALLBACK",
                33554476,
                100663364, "EndInvoke", 454, "20011114125D", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217910),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_ALLOC_CALLBACK",
                33554477,
                100663365, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217911),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217912),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_ALLOC_CALLBACK",
                33554477,
                100663366, "Invoke", 454, "200318091134117C", (KeyValuePair<string, string>[])[], "System.IntPtr",
                ["System.UInt32", "FMOD.MEMORY_TYPE", "FMOD.StringWrapper"], 0,
                [
                    new("size", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134217913),
                    new("type", 1, 0, "FMOD.MEMORY_TYPE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_TYPE"), 2, 134217914),
                    new("sourcestr", 2, 0, "FMOD.StringWrapper", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.StringWrapper"), 3, 134217915),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IntPtr"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_ALLOC_CALLBACK",
                33554477,
                100663367, "BeginInvoke", 454, "2005125D091134117C12611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "System.UInt32", "FMOD.MEMORY_TYPE", "FMOD.StringWrapper", "System.AsyncCallback", "System.Object",
                ],
                0,
                [
                    new("size", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134217916),
                    new("type", 1, 0, "FMOD.MEMORY_TYPE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_TYPE"), 2, 134217917),
                    new("sourcestr", 2, 0, "FMOD.StringWrapper", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.StringWrapper"), 3, 134217918),
                    new("callback", 3, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 4, 134217919),
                    new("object", 4, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 5, 134217920),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_ALLOC_CALLBACK",
                33554477,
                100663368, "EndInvoke", 454, "200118125D", (KeyValuePair<string, string>[])[], "System.IntPtr",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217921),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IntPtr"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_REALLOC_CALLBACK",
                33554478,
                100663369, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217922),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217923),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_REALLOC_CALLBACK",
                33554478,
                100663370, "Invoke", 454, "20041818091134117C", (KeyValuePair<string, string>[])[], "System.IntPtr",
                ["System.IntPtr", "System.UInt32", "FMOD.MEMORY_TYPE", "FMOD.StringWrapper"], 0,
                [
                    new("ptr", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217924),
                    new("size", 1, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 2, 134217925),
                    new("type", 2, 0, "FMOD.MEMORY_TYPE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_TYPE"), 3, 134217926),
                    new("sourcestr", 3, 0, "FMOD.StringWrapper", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.StringWrapper"), 4, 134217927),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IntPtr"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_REALLOC_CALLBACK",
                33554478,
                100663371, "BeginInvoke", 454, "2006125D18091134117C12611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "System.IntPtr", "System.UInt32", "FMOD.MEMORY_TYPE", "FMOD.StringWrapper", "System.AsyncCallback",
                    "System.Object",
                ], 0,
                [
                    new("ptr", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217928),
                    new("size", 1, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 2, 134217929),
                    new("type", 2, 0, "FMOD.MEMORY_TYPE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_TYPE"), 3, 134217930),
                    new("sourcestr", 3, 0, "FMOD.StringWrapper", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.StringWrapper"), 4, 134217931),
                    new("callback", 4, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 5, 134217932),
                    new("object", 5, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 6, 134217933),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_REALLOC_CALLBACK",
                33554478,
                100663372, "EndInvoke", 454, "200118125D", (KeyValuePair<string, string>[])[], "System.IntPtr",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217934),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IntPtr"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_FREE_CALLBACK", 33554479,
                100663373, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217935),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217936),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_FREE_CALLBACK", 33554479,
                100663374, "Invoke", 454, "200301181134117C", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IntPtr", "FMOD.MEMORY_TYPE", "FMOD.StringWrapper"], 0,
                [
                    new("ptr", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217937),
                    new("type", 1, 0, "FMOD.MEMORY_TYPE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_TYPE"), 2, 134217938),
                    new("sourcestr", 2, 0, "FMOD.StringWrapper", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.StringWrapper"), 3, 134217939),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_FREE_CALLBACK", 33554479,
                100663375, "BeginInvoke", 454, "2005125D181134117C12611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                [
                    "System.IntPtr", "FMOD.MEMORY_TYPE", "FMOD.StringWrapper", "System.AsyncCallback", "System.Object",
                ],
                0,
                [
                    new("ptr", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217940),
                    new("type", 1, 0, "FMOD.MEMORY_TYPE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_TYPE"), 2, 134217941),
                    new("sourcestr", 2, 0, "FMOD.StringWrapper", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.StringWrapper"), 3, 134217942),
                    new("callback", 3, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 4, 134217943),
                    new("object", 4, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 5, 134217944),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.MEMORY_FREE_CALLBACK", 33554479,
                100663376, "EndInvoke", 454, "200101125D", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217945),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.CB_3D_ROLLOFFCALLBACK",
                33554480,
                100663377, ".ctor", 6278, "2002011C18", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.Object", "System.IntPtr"], 0,
                [
                    new("object", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217946),
                    new("method", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134217947),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.CB_3D_ROLLOFFCALLBACK",
                33554480,
                100663378, "Invoke", 454, "20020C180C", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.IntPtr", "System.Single"], 0,
                [
                    new("channelraw", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217948),
                    new("distance", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134217949),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.CB_3D_ROLLOFFCALLBACK",
                33554480,
                100663379, "BeginInvoke", 454, "2004125D180C12611C", (KeyValuePair<string, string>[])[],
                "System.IAsyncResult",
                ["System.IntPtr", "System.Single", "System.AsyncCallback", "System.Object"], 0,
                [
                    new("channelraw", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217950),
                    new("distance", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134217951),
                    new("callback", 2, 0, "System.AsyncCallback", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.AsyncCallback"), 3, 134217952),
                    new("object", 3, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 4, 134217953),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IAsyncResult"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.CB_3D_ROLLOFFCALLBACK",
                33554480,
                100663380, "EndInvoke", 454, "20010C125D", (KeyValuePair<string, string>[])[], "System.Single",
                ["System.IAsyncResult"], 0,
                [
                    new("result", 0, 0, "System.IAsyncResult", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IAsyncResult"), 1, 134217954),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.TAG", 33554485, 100663381,
                "get_name", 2182, "20000E", (KeyValuePair<string, string>[])[], "System.String", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.REVERB_PROPERTIES", 33554489,
                100663382, ".ctor", 6278, "200C010C0C0C0C0C0C0C0C0C0C0C0C", (KeyValuePair<string, string>[])[],
                "System.Void",
                [
                    "System.Single", "System.Single", "System.Single", "System.Single", "System.Single",
                    "System.Single",
                    "System.Single", "System.Single", "System.Single", "System.Single", "System.Single",
                    "System.Single",
                ], 0,
                [
                    new("decayTime", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134217955),
                    new("earlyDelay", 1, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134217956),
                    new("lateDelay", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134217957),
                    new("hfReference", 3, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134217958),
                    new("hfDecayRatio", 4, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134217959),
                    new("diffusion", 5, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 6, 134217960),
                    new("density", 6, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 7, 134217961),
                    new("lowShelfFrequency", 7, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 8, 134217962),
                    new("lowShelfGain", 8, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 9, 134217963),
                    new("highCut", 9, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 10, 134217964),
                    new("earlyLateMix", 10, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 11, 134217965),
                    new("wetLevel", 11, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 12, 134217966),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 37, 94));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663383,
                "OFF",
                150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES", [],
                0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663384,
                "GENERIC", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663385,
                "PADDEDCELL", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663386,
                "ROOM", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663387,
                "BATHROOM", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663388,
                "LIVINGROOM", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663389,
                "STONEROOM", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663390,
                "AUDITORIUM", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663391,
                "CONCERTHALL", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663392,
                "CAVE", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663393,
                "ARENA", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663394,
                "HANGAR", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663395,
                "CARPETTEDHALLWAY", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663396,
                "HALLWAY", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663397,
                "STONECORRIDOR", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663398,
                "ALLEY", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663399,
                "FOREST", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663400,
                "CITY", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663401,
                "MOUNTAINS", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663402,
                "QUARRY", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663403,
                "PLAIN", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663404,
                "PARKINGLOT", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663405,
                "SEWERPIPE", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663406,
                "UNDERWATER", 150, "00001180E4", (KeyValuePair<string, string>[])[], "FMOD.REVERB_PROPERTIES",
                [], 0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.REVERB_PROPERTIES"), true, 14, 66));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.PRESET", 33554490, 100663407,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Factory", 33554493, 100663408,
                "System_Create", 150, "0001111410128104", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.System&"], 0,
                [
                    new("system", 0, 2, "FMOD.System&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.System")), 1, 134217967),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 20, 36));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Factory", 33554493, 100663409,
                "FMOD_System_Create", 8337, "000111141018", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr&"], 0,
                [
                    new("system", 0, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 1, 134217968),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Factory", 33554493, 100663410,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Memory", 33554494, 100663411,
                "Initialize", 150, "0006111418081280B41280B81280BC1134", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                [
                    "System.IntPtr", "System.Int32", "FMOD.MEMORY_ALLOC_CALLBACK", "FMOD.MEMORY_REALLOC_CALLBACK",
                    "FMOD.MEMORY_FREE_CALLBACK", "FMOD.MEMORY_TYPE",
                ], 0,
                [
                    new("poolmem", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217969),
                    new("poollen", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134217970),
                    new("useralloc", 2, 0, "FMOD.MEMORY_ALLOC_CALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_ALLOC_CALLBACK"), 3, 134217971),
                    new("userrealloc", 3, 0, "FMOD.MEMORY_REALLOC_CALLBACK", false,
                        null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_REALLOC_CALLBACK"), 4, 134217972),
                    new("userfree", 4, 0, "FMOD.MEMORY_FREE_CALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_FREE_CALLBACK"), 5, 134217973),
                    new("memtypeflags", 5, 4112, "FMOD.MEMORY_TYPE", true,
                        "System.UInt32",
                        [0xFF, 0xFF, 0xFF, 0xFF],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_TYPE"), 6, 134217974),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 8, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Memory", 33554494, 100663412,
                "GetStats", 150, "0002111410081008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&", "System.Int32&"], 0,
                [
                    new("currentalloced", 0, 2, "System.Int32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134217975),
                    new("maxalloced", 1, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134217976),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Memory", 33554494, 100663413,
                "GetStats", 150, "000311141008100802", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&", "System.Int32&", "System.Boolean"], 0,
                [
                    new("currentalloced", 0, 2, "System.Int32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134217977),
                    new("maxalloced", 1, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134217978),
                    new("blocking", 2, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134217979),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 9));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Memory", 33554494, 100663414,
                "FMOD_Memory_Initialize", 8337, "0006111418081280B41280B81280BC1134",
                (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                [
                    "System.IntPtr", "System.Int32", "FMOD.MEMORY_ALLOC_CALLBACK", "FMOD.MEMORY_REALLOC_CALLBACK",
                    "FMOD.MEMORY_FREE_CALLBACK", "FMOD.MEMORY_TYPE",
                ], 0,
                [
                    new("poolmem", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217980),
                    new("poollen", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134217981),
                    new("useralloc", 2, 0, "FMOD.MEMORY_ALLOC_CALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_ALLOC_CALLBACK"), 3, 134217982),
                    new("userrealloc", 3, 0, "FMOD.MEMORY_REALLOC_CALLBACK", false,
                        null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_REALLOC_CALLBACK"), 4, 134217983),
                    new("userfree", 4, 0, "FMOD.MEMORY_FREE_CALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_FREE_CALLBACK"), 5, 134217984),
                    new("memtypeflags", 5, 0, "FMOD.MEMORY_TYPE", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MEMORY_TYPE"), 6, 134217985),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Memory", 33554494, 100663415,
                "FMOD_Memory_GetStats", 8337, "000311141008100802", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.Int32&", "System.Int32&", "System.Boolean"], 0,
                [
                    new("currentalloced", 0, 2, "System.Int32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134217986),
                    new("maxalloced", 1, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134217987),
                    new("blocking", 2, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134217988),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Memory", 33554494, 100663416,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Debug", 33554495, 100663417,
                "Initialize", 150, "000411141130112C1280840E", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.DEBUG_FLAGS", "FMOD.DEBUG_MODE", "FMOD.DEBUG_CALLBACK", "System.String"], 0,
                [
                    new("flags", 0, 0, "FMOD.DEBUG_FLAGS", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DEBUG_FLAGS"), 1, 134217989),
                    new("mode", 1, 4112, "FMOD.DEBUG_MODE", true, "System.Int32",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DEBUG_MODE"), 2, 134217990),
                    new("callback", 2, 4112, "FMOD.DEBUG_CALLBACK", true, null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DEBUG_CALLBACK"), 3, 134217991),
                    new("filename", 3, 4112, "System.String", true, null,
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 4, 134217992),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 10));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Debug", 33554495, 100663418,
                "FMOD_Debug_Initialize", 8337, "000411141130112C1280840E", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["FMOD.DEBUG_FLAGS", "FMOD.DEBUG_MODE", "FMOD.DEBUG_CALLBACK", "System.String"], 0,
                [
                    new("flags", 0, 0, "FMOD.DEBUG_FLAGS", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DEBUG_FLAGS"), 1, 134217993),
                    new("mode", 1, 0, "FMOD.DEBUG_MODE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DEBUG_MODE"), 2, 134217994),
                    new("callback", 2, 0, "FMOD.DEBUG_CALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DEBUG_CALLBACK"), 3, 134217995),
                    new("filename", 3, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 4, 134217996),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Debug", 33554495, 100663419,
                ".ctor", 6278, "200001", (KeyValuePair<string, string>[])[], "System.Void", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.HandleBase", 33554496,
                100663420,
                ".ctor", 6278, "20010118", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IntPtr"], 0,
                [
                    new("newPtr", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134217997),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.HandleBase", 33554496,
                100663421,
                "isValid", 134, "200002", (KeyValuePair<string, string>[])[], "System.Boolean", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 5, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.HandleBase", 33554496,
                100663422,
                "getRaw", 134, "200018", (KeyValuePair<string, string>[])[], "System.IntPtr", [], 0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.IntPtr"), true, 3, 7));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.HandleBase", 33554496,
                100663423,
                "Equals", 198, "2001021C", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["System.Object"], 0,
                [
                    new("obj", 0, 0, "System.Object", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Object"), 1, 134217998),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.HandleBase", 33554496,
                100663424,
                "Equals", 134, "200102128100", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["FMOD.HandleBase"], 0,
                [
                    new("p", 0, 0, "FMOD.HandleBase", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.HandleBase"), 1, 134217999),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 10, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.HandleBase", 33554496,
                100663425,
                "GetHashCode", 198, "200008", (KeyValuePair<string, string>[])[], "System.Int32", [],
                0,
                [],
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.HandleBase", 33554496,
                100663426,
                "op_Equality", 2198, "000202128100128100", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["FMOD.HandleBase", "FMOD.HandleBase"], 0,
                [
                    new("a", 0, 0, "FMOD.HandleBase", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.HandleBase"), 1, 134218000),
                    new("b", 1, 0, "FMOD.HandleBase", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.HandleBase"), 2, 134218001),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 17, 32));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.HandleBase", 33554496,
                100663427,
                "op_Inequality", 2198, "000202128100128100", (KeyValuePair<string, string>[])[], "System.Boolean",
                ["FMOD.HandleBase", "FMOD.HandleBase"], 0,
                [
                    new("a", 0, 0, "FMOD.HandleBase", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.HandleBase"), 1, 134218002),
                    new("b", 1, 0, "FMOD.HandleBase", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.HandleBase"), 2, 134218003),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean"), true, 6, 11));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663428,
                "release", 134, "20001114", (KeyValuePair<string, string>[])[], "FMOD.RESULT", [], 0,
                [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 9, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663429,
                "setOutput", 134, "200111141128", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.OUTPUTTYPE"], 0,
                [
                    new("output", 0, 0, "FMOD.OUTPUTTYPE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.OUTPUTTYPE"), 1, 134218004),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663430,
                "getOutput", 134, "20011114101128", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.OUTPUTTYPE&"], 0,
                [
                    new("output", 0, 2, "FMOD.OUTPUTTYPE&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.OUTPUTTYPE")), 1, 134218005),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663431,
                "getNumDrivers", 134, "200111141008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&"], 0,
                [
                    new("numdrivers", 0, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218006),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663432,
                "getDriverInfo", 134, "200711140812650810116910081011381008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                [
                    "System.Int32", "System.Text.StringBuilder", "System.Int32", "System.Guid&", "System.Int32&",
                    "FMOD.SPEAKERMODE&", "System.Int32&",
                ], 0,
                [
                    new("id", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218007),
                    new("name", 1, 0, "System.Text.StringBuilder", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Text.StringBuilder"), 2, 134218008),
                    new("namelen", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134218009),
                    new("guid", 3, 2, "System.Guid&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Guid")), 4, 134218010),
                    new("systemrate", 4, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 5, 134218011),
                    new("speakermode", 5, 2, "FMOD.SPEAKERMODE&", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.SPEAKERMODE")), 6, 134218012),
                    new("speakermodechannels", 6, 2, "System.Int32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 7, 134218013),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 20, 48));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663433,
                "setDriver", 134, "2001111408", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32"], 0,
                [
                    new("driver", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218014),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663434,
                "getDriver", 134, "200111141008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&"], 0,
                [
                    new("driver", 0, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218015),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663435,
                "setSoftwareChannels", 134, "2001111408", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32"], 0,
                [
                    new("numsoftwarechannels", 0, 0, "System.Int32", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218016),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663436,
                "getSoftwareChannels", 134, "200111141008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&"], 0,
                [
                    new("numsoftwarechannels", 0, 2, "System.Int32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218017),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663437,
                "setSoftwareFormat", 134, "2003111408113808", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32", "FMOD.SPEAKERMODE", "System.Int32"], 0,
                [
                    new("samplerate", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218018),
                    new("speakermode", 1, 0, "FMOD.SPEAKERMODE", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.SPEAKERMODE"), 2, 134218019),
                    new("numrawspeakers", 2, 0, "System.Int32", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134218020),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663438,
                "getSoftwareFormat", 134, "2003111410081011381008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.Int32&", "FMOD.SPEAKERMODE&", "System.Int32&"], 0,
                [
                    new("samplerate", 0, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218021),
                    new("speakermode", 1, 2, "FMOD.SPEAKERMODE&", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.SPEAKERMODE")), 2, 134218022),
                    new("numrawspeakers", 2, 2, "System.Int32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 3, 134218023),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663439,
                "setDSPBufferSize", 134, "200211140908", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32", "System.Int32"], 0,
                [
                    new("bufferlength", 0, 0, "System.UInt32", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218024),
                    new("numbuffers", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218025),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663440,
                "getDSPBufferSize", 134, "2002111410091008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32&", "System.Int32&"], 0,
                [
                    new("bufferlength", 0, 2, "System.UInt32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 1, 134218026),
                    new("numbuffers", 1, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218027),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663441,
                "setFileSystem", 134, "2007111412809C1280A01280A41280A81280AC1280B008",
                (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                [
                    "FMOD.FILE_OPENCALLBACK", "FMOD.FILE_CLOSECALLBACK", "FMOD.FILE_READCALLBACK",
                    "FMOD.FILE_SEEKCALLBACK",
                    "FMOD.FILE_ASYNCREADCALLBACK", "FMOD.FILE_ASYNCCANCELCALLBACK", "System.Int32",
                ], 0,
                [
                    new("useropen", 0, 0, "FMOD.FILE_OPENCALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_OPENCALLBACK"), 1, 134218028),
                    new("userclose", 1, 0, "FMOD.FILE_CLOSECALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_CLOSECALLBACK"), 2, 134218029),
                    new("userread", 2, 0, "FMOD.FILE_READCALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_READCALLBACK"), 3, 134218030),
                    new("userseek", 3, 0, "FMOD.FILE_SEEKCALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_SEEKCALLBACK"), 4, 134218031),
                    new("userasyncread", 4, 0, "FMOD.FILE_ASYNCREADCALLBACK", false,
                        null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_ASYNCREADCALLBACK"), 5, 134218032),
                    new("userasynccancel", 5, 0, "FMOD.FILE_ASYNCCANCELCALLBACK", false,
                        null, [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_ASYNCCANCELCALLBACK"), 6, 134218033),
                    new("blockalign", 6, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 7, 134218034),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 11, 23));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663442,
                "attachFileSystem", 134, "2004111412809C1280A01280A41280A8", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                [
                    "FMOD.FILE_OPENCALLBACK", "FMOD.FILE_CLOSECALLBACK", "FMOD.FILE_READCALLBACK",
                    "FMOD.FILE_SEEKCALLBACK",
                ], 0,
                [
                    new("useropen", 0, 0, "FMOD.FILE_OPENCALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_OPENCALLBACK"), 1, 134218035),
                    new("userclose", 1, 0, "FMOD.FILE_CLOSECALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_CLOSECALLBACK"), 2, 134218036),
                    new("userread", 2, 0, "FMOD.FILE_READCALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_READCALLBACK"), 3, 134218037),
                    new("userseek", 3, 0, "FMOD.FILE_SEEKCALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.FILE_SEEKCALLBACK"), 4, 134218038),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663443,
                "setAdvancedSettings", 134, "20011114101180EC", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.ADVANCEDSETTINGS&"], 0,
                [
                    new("settings", 0, 0, "FMOD.ADVANCEDSETTINGS&", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.ADVANCEDSETTINGS")), 1, 134218039),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 11, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663444,
                "getAdvancedSettings", 134, "20011114101180EC", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.ADVANCEDSETTINGS&"], 0,
                [
                    new("settings", 0, 0, "FMOD.ADVANCEDSETTINGS&", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.ADVANCEDSETTINGS")), 1, 134218040),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 11, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663445,
                "setCallback", 134, "200211141280881178", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.SYSTEM_CALLBACK", "FMOD.SYSTEM_CALLBACK_TYPE"], 0,
                [
                    new("callback", 0, 0, "FMOD.SYSTEM_CALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.SYSTEM_CALLBACK"), 1, 134218041),
                    new("callbackmask", 1, 4112, "FMOD.SYSTEM_CALLBACK_TYPE", true,
                        "System.UInt32", [0xFF, 0xFF, 0xFF, 0xFF],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.SYSTEM_CALLBACK_TYPE"), 2, 134218042),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663446,
                "setPluginPath", 134, "200111140E", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.String"], 0,
                [
                    new("path", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134218043),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 9, 33));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663447,
                "loadPlugin", 134, "200311140E100909", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.String", "System.UInt32&", "System.UInt32"], 0,
                [
                    new("filename", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134218044),
                    new("handle", 1, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 2, 134218045),
                    new("priority", 2, 4112, "System.UInt32", true, "System.UInt32",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134218046),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 11, 35));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663448,
                "unloadPlugin", 134, "2001111409", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32"], 0,
                [
                    new("handle", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218047),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663449,
                "getNumNestedPlugins", 134, "20021114091008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32", "System.Int32&"], 0,
                [
                    new("handle", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218048),
                    new("count", 1, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218049),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663450,
                "getNestedPlugin", 134, "2003111409081009", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32", "System.Int32", "System.UInt32&"], 0,
                [
                    new("handle", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218050),
                    new("index", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218051),
                    new("nestedhandle", 2, 2, "System.UInt32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 3, 134218052),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663451,
                "getNumPlugins", 134, "2002111411481008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.PLUGINTYPE", "System.Int32&"], 0,
                [
                    new("plugintype", 0, 0, "FMOD.PLUGINTYPE", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.PLUGINTYPE"), 1, 134218053),
                    new("numplugins", 1, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218054),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663452,
                "getPluginHandle", 134, "200311141148081009", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.PLUGINTYPE", "System.Int32", "System.UInt32&"], 0,
                [
                    new("plugintype", 0, 0, "FMOD.PLUGINTYPE", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.PLUGINTYPE"), 1, 134218055),
                    new("index", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218056),
                    new("handle", 2, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 3, 134218057),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663453,
                "getPluginInfo", 134, "20051114091011481265081009", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                [
                    "System.UInt32", "FMOD.PLUGINTYPE&", "System.Text.StringBuilder", "System.Int32", "System.UInt32&",
                ],
                0,
                [
                    new("handle", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218058),
                    new("plugintype", 1, 2, "FMOD.PLUGINTYPE&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.PLUGINTYPE")), 2, 134218059),
                    new("name", 2, 0, "System.Text.StringBuilder", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Text.StringBuilder"), 3, 134218060),
                    new("namelen", 3, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 4, 134218061),
                    new("version", 4, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 5, 134218062),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 18, 44));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663454,
                "setOutputByPlugin", 134, "2001111409", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32"], 0,
                [
                    new("handle", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218063),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663455,
                "getOutputByPlugin", 134, "200111141009", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32&"], 0,
                [
                    new("handle", 0, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 1, 134218064),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.System", 33554497, 100663456,
                "createDSPByPlugin", 134, "20021114091012811C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32", "FMOD.DSP&"], 0,
                [
                    new("handle", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218065),
                    new("dsp", 1, 2, "FMOD.DSP&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.DSP")), 2, 134218066),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 13, 26));
        }
    }
}
