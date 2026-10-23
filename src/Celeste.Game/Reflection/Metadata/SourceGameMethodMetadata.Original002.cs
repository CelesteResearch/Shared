using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMethodMetadata
    {
        private static void PublishOriginal002(SourceAssemblyMethodCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663617,
                "setDefaults", 134, "200211140C08", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single", "System.Int32"], 0,
                [
                    new("frequency", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218514),
                    new("priority", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218515),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663618,
                "getDefaults", 134, "20021114100C1008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&", "System.Int32&"], 0,
                [
                    new("frequency", 0, 2, "System.Single&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218516),
                    new("priority", 1, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218517),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663619,
                "set3DMinMaxDistance", 134, "200211140C0C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single", "System.Single"], 0,
                [
                    new("min", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218518),
                    new("max", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218519),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663620,
                "get3DMinMaxDistance", 134, "20021114100C100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&", "System.Single&"], 0,
                [
                    new("min", 0, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218520),
                    new("max", 1, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218521),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663621,
                "set3DConeSettings", 134, "200311140C0C0C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("insideconeangle", 0, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218522),
                    new("outsideconeangle", 1, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218523),
                    new("outsidevolume", 2, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134218524),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663622,
                "get3DConeSettings", 134, "20031114100C100C100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&", "System.Single&", "System.Single&"], 0,
                [
                    new("insideconeangle", 0, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218525),
                    new("outsideconeangle", 1, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218526),
                    new("outsidevolume", 2, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134218527),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663623,
                "set3DCustomRolloff", 134, "2002111410111C08", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.VECTOR&", "System.Int32"], 0,
                [
                    new("points", 0, 0, "FMOD.VECTOR&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 1, 134218528),
                    new("numpoints", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218529),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663624,
                "get3DCustomRolloff", 134, "2002111410181008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr&", "System.Int32&"], 0,
                [
                    new("points", 0, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 1, 134218530),
                    new("numpoints", 1, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218531),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663625,
                "getSubSound", 134, "200211140810128108", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32", "FMOD.Sound&"], 0,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218532),
                    new("subsound", 1, 2, "FMOD.Sound&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.Sound")), 2, 134218533),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 13, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663626,
                "getSubSoundParent", 134, "2001111410128108", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.Sound&"], 0,
                [
                    new("parentsound", 0, 2, "FMOD.Sound&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.Sound")), 1, 134218534),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 12, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663627,
                "getName", 134, "20021114126508", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Text.StringBuilder", "System.Int32"], 0,
                [
                    new("name", 0, 0, "System.Text.StringBuilder", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Text.StringBuilder"), 1, 134218535),
                    new("namelen", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218536),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 15, 39));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663628,
                "getLength", 134, "2002111410091180D8", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32&", "FMOD.TIMEUNIT"], 0,
                [
                    new("length", 0, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 1, 134218537),
                    new("lengthtype", 1, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 2, 134218538),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663629,
                "getFormat", 134, "2004111410115410115810081008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.SOUND_TYPE&", "FMOD.SOUND_FORMAT&", "System.Int32&", "System.Int32&"], 0,
                [
                    new("type", 0, 2, "FMOD.SOUND_TYPE&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.SOUND_TYPE")), 1, 134218539),
                    new("format", 1, 2, "FMOD.SOUND_FORMAT&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.SOUND_FORMAT")), 2, 134218540),
                    new("channels", 2, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 3, 134218541),
                    new("bits", 3, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 4, 134218542),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663630,
                "getNumSubSounds", 134, "200111141008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&"], 0,
                [
                    new("numsubsounds", 0, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218543),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663631,
                "getNumTags", 134, "2002111410081008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&", "System.Int32&"], 0,
                [
                    new("numtags", 0, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218544),
                    new("numtagsupdated", 1, 2, "System.Int32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218545),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663632,
                "getTag", 134, "200311140E08101180D4", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.String", "System.Int32", "FMOD.TAG&"], 0,
                [
                    new("name", 0, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 1, 134218546),
                    new("index", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218547),
                    new("tag", 2, 2, "FMOD.TAG&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.TAG")), 3, 134218548),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663633,
                "getOpenState", 134, "20041114101160100910021002", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["FMOD.OPENSTATE&", "System.UInt32&", "System.Boolean&", "System.Boolean&"], 0,
                [
                    new("openstate", 0, 2, "FMOD.OPENSTATE&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.OPENSTATE")), 1, 134218549),
                    new("percentbuffered", 1, 2, "System.UInt32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 2, 134218550),
                    new("starving", 2, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 3, 134218551),
                    new("diskbusy", 3, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 4, 134218552),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663634,
                "readData", 134, "2003111418091009", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.UInt32", "System.UInt32&"], 0,
                [
                    new("buffer", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218553),
                    new("length", 1, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 2, 134218554),
                    new("read", 2, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 3, 134218555),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663635,
                "seekData", 134, "2001111409", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32"], 0,
                [
                    new("pcm", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218556),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663636,
                "setSoundGroup", 134, "20011114128118", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.SoundGroup"], 0,
                [
                    new("soundgroup", 0, 0, "FMOD.SoundGroup", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.SoundGroup"), 1, 134218557),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663637,
                "getSoundGroup", 134, "2001111410128118", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.SoundGroup&"], 0,
                [
                    new("soundgroup", 0, 2, "FMOD.SoundGroup&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.SoundGroup")), 1, 134218558),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 12, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663638,
                "getNumSyncPoints", 134, "200111141008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&"], 0,
                [
                    new("numsyncpoints", 0, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218559),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663639,
                "getSyncPoint", 134, "20021114081018", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32", "System.IntPtr&"], 0,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218560),
                    new("point", 1, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 2, 134218561),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663640,
                "getSyncPointInfo", 134, "200511141812650810091180D8", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.Text.StringBuilder", "System.Int32", "System.UInt32&", "FMOD.TIMEUNIT"],
                0,
                [
                    new("point", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218562),
                    new("name", 1, 0, "System.Text.StringBuilder", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Text.StringBuilder"), 2, 134218563),
                    new("namelen", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134218564),
                    new("offset", 3, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 4, 134218565),
                    new("offsettype", 4, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 5, 134218566),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 18, 44));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663641,
                "addSyncPoint", 134, "20041114091180D80E1018", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32", "FMOD.TIMEUNIT", "System.String", "System.IntPtr&"], 0,
                [
                    new("offset", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218567),
                    new("offsettype", 1, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 2, 134218568),
                    new("name", 2, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 3, 134218569),
                    new("point", 3, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 4, 134218570),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663642,
                "deleteSyncPoint", 134, "2001111418", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr"], 0,
                [
                    new("point", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218571),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663643,
                "setMode", 134, "20011114115C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.MODE"], 0,
                [
                    new("mode", 0, 0, "FMOD.MODE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MODE"), 1, 134218572),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663644,
                "getMode", 134, "2001111410115C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.MODE&"], 0,
                [
                    new("mode", 0, 2, "FMOD.MODE&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.MODE")), 1, 134218573),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663645,
                "setLoopCount", 134, "2001111408", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32"], 0,
                [
                    new("loopcount", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218574),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663646,
                "getLoopCount", 134, "200111141008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&"], 0,
                [
                    new("loopcount", 0, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218575),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663647,
                "setLoopPoints", 134, "20041114091180D8091180D8", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt32", "FMOD.TIMEUNIT", "System.UInt32", "FMOD.TIMEUNIT"], 0,
                [
                    new("loopstart", 0, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 1, 134218576),
                    new("loopstarttype", 1, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 2, 134218577),
                    new("loopend", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134218578),
                    new("loopendtype", 3, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 4, 134218579),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663648,
                "getLoopPoints", 134, "2004111410091180D810091180D8", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.UInt32&", "FMOD.TIMEUNIT", "System.UInt32&", "FMOD.TIMEUNIT"], 0,
                [
                    new("loopstart", 0, 2, "System.UInt32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 1, 134218580),
                    new("loopstarttype", 1, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 2, 134218581),
                    new("loopend", 2, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 3, 134218582),
                    new("loopendtype", 3, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 4, 134218583),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663649,
                "getMusicNumChannels", 134, "200111141008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&"], 0,
                [
                    new("numchannels", 0, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218584),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663650,
                "setMusicChannelVolume", 134, "20021114080C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32", "System.Single"], 0,
                [
                    new("channel", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218585),
                    new("volume", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218586),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663651,
                "getMusicChannelVolume", 134, "2002111408100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32", "System.Single&"], 0,
                [
                    new("channel", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218587),
                    new("volume", 1, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218588),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663652,
                "setMusicSpeed", 134, "200111140C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single"], 0,
                [
                    new("speed", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218589),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663653,
                "getMusicSpeed", 134, "20011114100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&"], 0,
                [
                    new("speed", 0, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218590),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663654,
                "setUserData", 134, "2001111418", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr"], 0,
                [
                    new("userdata", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218591),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663655,
                "getUserData", 134, "200111141018", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr&"], 0,
                [
                    new("userdata", 0, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 1, 134218592),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663656,
                "FMOD_Sound_Release", 8337, "0001111418", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218593),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663657,
                "FMOD_Sound_GetSystemObject", 8337, "00021114181018", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218594),
                    new("system", 1, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 2, 134218595),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663658,
                "FMOD_Sound_Lock", 8337, "000711141809091018101810091009", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                [
                    "System.IntPtr", "System.UInt32", "System.UInt32", "System.IntPtr&", "System.IntPtr&",
                    "System.UInt32&",
                    "System.UInt32&",
                ], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218596),
                    new("offset", 1, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 2, 134218597),
                    new("length", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134218598),
                    new("ptr1", 3, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 4, 134218599),
                    new("ptr2", 4, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 5, 134218600),
                    new("len1", 5, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 6, 134218601),
                    new("len2", 6, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 7, 134218602),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663659,
                "FMOD_Sound_Unlock", 8337, "000511141818180909", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr", "System.IntPtr", "System.UInt32", "System.UInt32"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218603),
                    new("ptr1", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134218604),
                    new("ptr2", 2, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 3, 134218605),
                    new("len1", 3, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 4, 134218606),
                    new("len2", 4, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 5, 134218607),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663660,
                "FMOD_Sound_SetDefaults", 8337, "00031114180C08", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.Single", "System.Int32"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218608),
                    new("frequency", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218609),
                    new("priority", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134218610),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663661,
                "FMOD_Sound_GetDefaults", 8337, "0003111418100C1008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.Single&", "System.Int32&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218611),
                    new("frequency", 1, 2, "System.Single&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218612),
                    new("priority", 2, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 3, 134218613),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663662,
                "FMOD_Sound_Set3DMinMaxDistance", 8337, "00031114180C0C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Single", "System.Single"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218614),
                    new("min", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218615),
                    new("max", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134218616),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663663,
                "FMOD_Sound_Get3DMinMaxDistance", 8337, "0003111418100C100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Single&", "System.Single&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218617),
                    new("min", 1, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218618),
                    new("max", 2, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134218619),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663664,
                "FMOD_Sound_Set3DConeSettings", 8337, "00041114180C0C0C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Single", "System.Single", "System.Single"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218620),
                    new("insideconeangle", 1, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218621),
                    new("outsideconeangle", 2, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134218622),
                    new("outsidevolume", 3, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134218623),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663665,
                "FMOD_Sound_Get3DConeSettings", 8337, "0004111418100C100C100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Single&", "System.Single&", "System.Single&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218624),
                    new("insideconeangle", 1, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218625),
                    new("outsideconeangle", 2, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134218626),
                    new("outsidevolume", 3, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 4, 134218627),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663666,
                "FMOD_Sound_Set3DCustomRolloff", 8337, "000311141810111C08", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "FMOD.VECTOR&", "System.Int32"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218628),
                    new("points", 1, 0, "FMOD.VECTOR&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 2, 134218629),
                    new("numpoints", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134218630),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663667,
                "FMOD_Sound_Get3DCustomRolloff", 8337, "000311141810181008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.IntPtr&", "System.Int32&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218631),
                    new("points", 1, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 2, 134218632),
                    new("numpoints", 2, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 3, 134218633),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663668,
                "FMOD_Sound_GetSubSound", 8337, "0003111418081018", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.Int32", "System.IntPtr&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218634),
                    new("index", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218635),
                    new("subsound", 2, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 3, 134218636),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663669,
                "FMOD_Sound_GetSubSoundParent", 8337, "00021114181018", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.IntPtr&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218637),
                    new("parentsound", 1, 2, "System.IntPtr&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 2, 134218638),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663670,
                "FMOD_Sound_GetName", 8337, "00031114181808", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr", "System.Int32"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218639),
                    new("name", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134218640),
                    new("namelen", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134218641),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663671,
                "FMOD_Sound_GetLength", 8337, "000311141810091180D8", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.UInt32&", "FMOD.TIMEUNIT"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218642),
                    new("length", 1, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 2, 134218643),
                    new("lengthtype", 2, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 3, 134218644),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663672,
                "FMOD_Sound_GetFormat", 8337, "000511141810115410115810081008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "FMOD.SOUND_TYPE&", "FMOD.SOUND_FORMAT&", "System.Int32&", "System.Int32&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218645),
                    new("type", 1, 2, "FMOD.SOUND_TYPE&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.SOUND_TYPE")), 2, 134218646),
                    new("format", 2, 2, "FMOD.SOUND_FORMAT&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.SOUND_FORMAT")), 3, 134218647),
                    new("channels", 3, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 4, 134218648),
                    new("bits", 4, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 5, 134218649),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663673,
                "FMOD_Sound_GetNumSubSounds", 8337, "00021114181008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.Int32&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218650),
                    new("numsubsounds", 1, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218651),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663674,
                "FMOD_Sound_GetNumTags", 8337, "000311141810081008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.Int32&", "System.Int32&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218652),
                    new("numtags", 1, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218653),
                    new("numtagsupdated", 2, 2, "System.Int32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 3, 134218654),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663675,
                "FMOD_Sound_GetTag", 8337, "00041114180E08101180D4", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.String", "System.Int32", "FMOD.TAG&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218655),
                    new("name", 1, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 2, 134218656),
                    new("index", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134218657),
                    new("tag", 3, 2, "FMOD.TAG&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.TAG")), 4, 134218658),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663676,
                "FMOD_Sound_GetOpenState", 8337, "0005111418101160100910021002", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "FMOD.OPENSTATE&", "System.UInt32&", "System.Boolean&", "System.Boolean&"],
                0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218659),
                    new("openstate", 1, 2, "FMOD.OPENSTATE&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.OPENSTATE")), 2, 134218660),
                    new("percentbuffered", 2, 2, "System.UInt32&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 3, 134218661),
                    new("starving", 3, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 4, 134218662),
                    new("diskbusy", 4, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 5, 134218663),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663677,
                "FMOD_Sound_ReadData", 8337, "000411141818091009", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr", "System.UInt32", "System.UInt32&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218664),
                    new("buffer", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134218665),
                    new("length", 2, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 3, 134218666),
                    new("read", 3, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 4, 134218667),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663678,
                "FMOD_Sound_SeekData", 8337, "000211141809", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.UInt32"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218668),
                    new("pcm", 1, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 2, 134218669),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663679,
                "FMOD_Sound_SetSoundGroup", 8337, "000211141818", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218670),
                    new("soundgroup", 1, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134218671),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663680,
                "FMOD_Sound_GetSoundGroup", 8337, "00021114181018", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218672),
                    new("soundgroup", 1, 2, "System.IntPtr&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 2, 134218673),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663681,
                "FMOD_Sound_GetNumSyncPoints", 8337, "00021114181008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Int32&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218674),
                    new("numsyncpoints", 1, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218675),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663682,
                "FMOD_Sound_GetSyncPoint", 8337, "0003111418081018", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.Int32", "System.IntPtr&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218676),
                    new("index", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218677),
                    new("point", 2, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 3, 134218678),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663683,
                "FMOD_Sound_GetSyncPointInfo", 8337, "000611141818180810091180D8",
                (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                [
                    "System.IntPtr", "System.IntPtr", "System.IntPtr", "System.Int32", "System.UInt32&",
                    "FMOD.TIMEUNIT",
                ], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218679),
                    new("point", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134218680),
                    new("name", 2, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 3, 134218681),
                    new("namelen", 3, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 4, 134218682),
                    new("offset", 4, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 5, 134218683),
                    new("offsettype", 5, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 6, 134218684),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663684,
                "FMOD_Sound_AddSyncPoint", 8337, "0005111418091180D80E1018", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.UInt32", "FMOD.TIMEUNIT", "System.String", "System.IntPtr&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218685),
                    new("offset", 1, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 2, 134218686),
                    new("offsettype", 2, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 3, 134218687),
                    new("name", 3, 0, "System.String", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.String"), 4, 134218688),
                    new("point", 4, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 5, 134218689),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663685,
                "FMOD_Sound_DeleteSyncPoint", 8337, "000211141818", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218690),
                    new("point", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134218691),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663686,
                "FMOD_Sound_SetMode", 8337, "0002111418115C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "FMOD.MODE"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218692),
                    new("mode", 1, 0, "FMOD.MODE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MODE"), 2, 134218693),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663687,
                "FMOD_Sound_GetMode", 8337, "000211141810115C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "FMOD.MODE&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218694),
                    new("mode", 1, 2, "FMOD.MODE&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.MODE")), 2, 134218695),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663688,
                "FMOD_Sound_SetLoopCount", 8337, "000211141808", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.Int32"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218696),
                    new("loopcount", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218697),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663689,
                "FMOD_Sound_GetLoopCount", 8337, "00021114181008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.Int32&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218698),
                    new("loopcount", 1, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218699),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663690,
                "FMOD_Sound_SetLoopPoints", 8337, "0005111418091180D8091180D8", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.UInt32", "FMOD.TIMEUNIT", "System.UInt32", "FMOD.TIMEUNIT"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218700),
                    new("loopstart", 1, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 2, 134218701),
                    new("loopstarttype", 2, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 3, 134218702),
                    new("loopend", 3, 0, "System.UInt32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt32"), 4, 134218703),
                    new("loopendtype", 4, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 5, 134218704),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663691,
                "FMOD_Sound_GetLoopPoints", 8337, "000511141810091180D810091180D8",
                (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.UInt32&", "FMOD.TIMEUNIT", "System.UInt32&", "FMOD.TIMEUNIT"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218705),
                    new("loopstart", 1, 2, "System.UInt32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 2, 134218706),
                    new("loopstarttype", 2, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 3, 134218707),
                    new("loopend", 3, 2, "System.UInt32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 4, 134218708),
                    new("loopendtype", 4, 0, "FMOD.TIMEUNIT", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.TIMEUNIT"), 5, 134218709),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663692,
                "FMOD_Sound_GetMusicNumChannels", 8337, "00021114181008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Int32&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218710),
                    new("numchannels", 1, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218711),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663693,
                "FMOD_Sound_SetMusicChannelVolume", 8337, "0003111418080C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Int32", "System.Single"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218712),
                    new("channel", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218713),
                    new("volume", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134218714),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663694,
                "FMOD_Sound_GetMusicChannelVolume", 8337, "000311141808100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Int32", "System.Single&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218715),
                    new("channel", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218716),
                    new("volume", 2, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134218717),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663695,
                "FMOD_Sound_SetMusicSpeed", 8337, "00021114180C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.Single"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218718),
                    new("speed", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218719),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663696,
                "FMOD_Sound_GetMusicSpeed", 8337, "0002111418100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.IntPtr", "System.Single&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218720),
                    new("speed", 1, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218721),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663697,
                "FMOD_Sound_SetUserData", 8337, "000211141818", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218722),
                    new("userdata", 1, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 2, 134218723),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663698,
                "FMOD_Sound_GetUserData", 8337, "00021114181018", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.IntPtr&"], 0,
                [
                    new("sound", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218724),
                    new("userdata", 1, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 2, 134218725),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Sound", 33554498, 100663699,
                ".ctor", 6278, "20010118", (KeyValuePair<string, string>[])[], "System.Void",
                ["System.IntPtr"], 0,
                [
                    new("raw", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218726),
                ], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Void"), true, 4, 8));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663700, "getSystemObject", 134, "2001111410128104", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["FMOD.System&"], 0,
                [
                    new("system", 0, 2, "FMOD.System&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.System")), 1, 134218727),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 12, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663701, "stop", 134, "20001114", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                [],
                0, [],
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 4, 12));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663702, "setPaused", 134, "2001111402", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Boolean"], 0,
                [
                    new("paused", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134218728),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663703, "getPaused", 134, "200111141002", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Boolean&"], 0,
                [
                    new("paused", 0, 2, "System.Boolean&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 1, 134218729),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663704, "setVolume", 134, "200111140C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single"], 0,
                [
                    new("volume", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218730),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663705, "getVolume", 134, "20011114100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&"], 0,
                [
                    new("volume", 0, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218731),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663706, "setVolumeRamp", 134, "2001111402", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Boolean"], 0,
                [
                    new("ramp", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134218732),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663707, "getVolumeRamp", 134, "200111141002", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Boolean&"], 0,
                [
                    new("ramp", 0, 2, "System.Boolean&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 1, 134218733),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663708, "getAudibility", 134, "20011114100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&"], 0,
                [
                    new("audibility", 0, 2, "System.Single&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218734),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663709, "setPitch", 134, "200111140C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single"], 0,
                [
                    new("pitch", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218735),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663710, "getPitch", 134, "20011114100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&"], 0,
                [
                    new("pitch", 0, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218736),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663711, "setMute", 134, "2001111402", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Boolean"], 0,
                [
                    new("mute", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134218737),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663712, "getMute", 134, "200111141002", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Boolean&"], 0,
                [
                    new("mute", 0, 2, "System.Boolean&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 1, 134218738),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663713, "setReverbProperties", 134, "20021114080C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Int32", "System.Single"], 0,
                [
                    new("instance", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218739),
                    new("wet", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218740),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663714, "getReverbProperties", 134, "2002111408100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Int32", "System.Single&"], 0,
                [
                    new("instance", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218741),
                    new("wet", 1, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218742),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663715, "setLowPassGain", 134, "200111140C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single"], 0,
                [
                    new("gain", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218743),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663716, "getLowPassGain", 134, "20011114100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&"], 0,
                [
                    new("gain", 0, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218744),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663717, "setMode", 134, "20011114115C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.MODE"], 0,
                [
                    new("mode", 0, 0, "FMOD.MODE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MODE"), 1, 134218745),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663718, "getMode", 134, "2001111410115C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.MODE&"], 0,
                [
                    new("mode", 0, 2, "FMOD.MODE&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.MODE")), 1, 134218746),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663719, "setCallback", 134, "2001111412808C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.CHANNEL_CALLBACK"], 0,
                [
                    new("callback", 0, 0, "FMOD.CHANNEL_CALLBACK", false, null,
                        [], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.CHANNEL_CALLBACK"), 1, 134218747),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663720, "isPlaying", 134, "200111141002", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Boolean&"], 0,
                [
                    new("isplaying", 0, 2, "System.Boolean&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 1, 134218748),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663721, "setPan", 134, "200111140C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single"], 0,
                [
                    new("pan", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218749),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663722, "setMixLevelsOutput", 134, "200811140C0C0C0C0C0C0C0C",
                (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                [
                    "System.Single", "System.Single", "System.Single", "System.Single", "System.Single",
                    "System.Single",
                    "System.Single", "System.Single",
                ], 0,
                [
                    new("frontleft", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218750),
                    new("frontright", 1, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218751),
                    new("center", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134218752),
                    new("lfe", 3, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 4, 134218753),
                    new("surroundleft", 4, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 5, 134218754),
                    new("surroundright", 5, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 6, 134218755),
                    new("backleft", 6, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 7, 134218756),
                    new("backright", 7, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 8, 134218757),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 12, 25));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663723, "setMixLevelsInput", 134, "200211141D0C08", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Single[]", "System.Int32"], 0,
                [
                    new("levels", 0, 0, "System.Single[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134218758),
                    new("numlevels", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218759),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663724, "setMixMatrix", 134, "200411141D0C080808", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.Single[]", "System.Int32", "System.Int32", "System.Int32"], 0,
                [
                    new("matrix", 0, 0, "System.Single[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134218760),
                    new("outchannels", 1, 0, "System.Int32", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218761),
                    new("inchannels", 2, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 3, 134218762),
                    new("inchannel_hop", 3, 4112, "System.Int32", true, "System.Int32",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 4, 134218763),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663725, "getMixMatrix", 134, "200411141D0C1008100808", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Single[]", "System.Int32&", "System.Int32&", "System.Int32"], 0,
                [
                    new("matrix", 0, 0, "System.Single[]", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 1,
                        134218764),
                    new("outchannels", 1, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218765),
                    new("inchannels", 2, 2, "System.Int32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 3, 134218766),
                    new("inchannel_hop", 3, 4112, "System.Int32", true, "System.Int32",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x00, 0x00, 0x00, 0x00],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 4, 134218767),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 8, 17));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663726, "getDSPClock", 134, "20021114100B100B", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.UInt64&", "System.UInt64&"], 0,
                [
                    new("dspclock", 0, 2, "System.UInt64&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt64")), 1, 134218768),
                    new("parentclock", 1, 2, "System.UInt64&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt64")), 2, 134218769),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663727, "setDelay", 134, "200311140B0B02", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt64", "System.UInt64", "System.Boolean"], 0,
                [
                    new("dspclock_start", 0, 0, "System.UInt64", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt64"), 1, 134218770),
                    new("dspclock_end", 1, 0, "System.UInt64", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt64"), 2, 134218771),
                    new("stopchannels", 2, 4112, "System.Boolean", true,
                        "System.Boolean",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 3, 134218772),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663728, "getDelay", 134, "20031114100B100B1002", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.UInt64&", "System.UInt64&", "System.Boolean&"], 0,
                [
                    new("dspclock_start", 0, 2, "System.UInt64&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt64")), 1, 134218773),
                    new("dspclock_end", 1, 2, "System.UInt64&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt64")), 2, 134218774),
                    new("stopchannels", 2, 2, "System.Boolean&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 3, 134218775),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663729, "addFadePoint", 134, "200211140B0C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.UInt64", "System.Single"], 0,
                [
                    new("dspclock", 0, 0, "System.UInt64", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt64"), 1, 134218776),
                    new("volume", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218777),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663730, "setFadePointRamp", 134, "200211140B0C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.UInt64", "System.Single"], 0,
                [
                    new("dspclock", 0, 0, "System.UInt64", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt64"), 1, 134218778),
                    new("volume", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218779),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663731, "removeFadePoints", 134, "200211140B0B", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.UInt64", "System.UInt64"], 0,
                [
                    new("dspclock_start", 0, 0, "System.UInt64", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt64"), 1, 134218780),
                    new("dspclock_end", 1, 0, "System.UInt64", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.UInt64"), 2, 134218781),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663732, "getFadePoints", 134, "2003111410091D0B1D0C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.UInt32&", "System.UInt64[]", "System.Single[]"], 0,
                [
                    new("numpoints", 0, 0, "System.UInt32&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt32")), 1, 134218782),
                    new("point_dspclock", 1, 0, "System.UInt64[]", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.UInt64"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 2,
                        134218783),
                    new("point_volume", 2, 0, "System.Single[]", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.SzArray,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single"), arrayRank: 1,
                            arrayDimensions: [new(null, null)]), 3,
                        134218784),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663733, "getDSP", 134, "20021114081012811C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32", "FMOD.DSP&"], 0,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218785),
                    new("dsp", 1, 2, "FMOD.DSP&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.DSP")), 2, 134218786),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 13, 26));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663734, "addDSP", 134, "200211140812811C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32", "FMOD.DSP"], 0,
                [
                    new("index", 0, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 1, 134218787),
                    new("dsp", 1, 0, "FMOD.DSP", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DSP"), 2, 134218788),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663735, "removeDSP", 134, "2001111412811C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["FMOD.DSP"], 0,
                [
                    new("dsp", 0, 0, "FMOD.DSP", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DSP"), 1, 134218789),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 18));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663736, "getNumDSPs", 134, "200111141008", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Int32&"], 0,
                [
                    new("numdsps", 0, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 1, 134218790),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663737, "setDSPIndex", 134, "2002111412811C08", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["FMOD.DSP", "System.Int32"], 0,
                [
                    new("dsp", 0, 0, "FMOD.DSP", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DSP"), 1, 134218791),
                    new("index", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218792),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663738, "getDSPIndex", 134, "2002111412811C1008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["FMOD.DSP", "System.Int32&"], 0,
                [
                    new("dsp", 0, 0, "FMOD.DSP", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.DSP"), 1, 134218793),
                    new("index", 1, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218794),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 19));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663739, "set3DAttributes", 134, "2003111410111C10111C10111C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["FMOD.VECTOR&", "FMOD.VECTOR&", "FMOD.VECTOR&"], 0,
                [
                    new("pos", 0, 0, "FMOD.VECTOR&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 1, 134218795),
                    new("vel", 1, 0, "FMOD.VECTOR&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 2, 134218796),
                    new("alt_pan_pos", 2, 0, "FMOD.VECTOR&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 3, 134218797),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663740, "get3DAttributes", 134, "2003111410111C10111C10111C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["FMOD.VECTOR&", "FMOD.VECTOR&", "FMOD.VECTOR&"], 0,
                [
                    new("pos", 0, 2, "FMOD.VECTOR&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 1, 134218798),
                    new("vel", 1, 2, "FMOD.VECTOR&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 2, 134218799),
                    new("alt_pan_pos", 2, 2, "FMOD.VECTOR&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 3, 134218800),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663741, "set3DMinMaxDistance", 134, "200211140C0C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Single", "System.Single"], 0,
                [
                    new("mindistance", 0, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218801),
                    new("maxdistance", 1, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218802),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663742, "get3DMinMaxDistance", 134, "20021114100C100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Single&", "System.Single&"], 0,
                [
                    new("mindistance", 0, 2, "System.Single&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218803),
                    new("maxdistance", 1, 2, "System.Single&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218804),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663743, "set3DConeSettings", 134, "200311140C0C0C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Single", "System.Single", "System.Single"], 0,
                [
                    new("insideconeangle", 0, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218805),
                    new("outsideconeangle", 1, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218806),
                    new("outsidevolume", 2, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134218807),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663744, "get3DConeSettings", 134, "20031114100C100C100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Single&", "System.Single&", "System.Single&"], 0,
                [
                    new("insideconeangle", 0, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218808),
                    new("outsideconeangle", 1, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218809),
                    new("outsidevolume", 2, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134218810),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663745, "set3DConeOrientation", 134, "2001111410111C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["FMOD.VECTOR&"], 0,
                [
                    new("orientation", 0, 0, "FMOD.VECTOR&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 1, 134218811),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663746, "get3DConeOrientation", 134, "2001111410111C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["FMOD.VECTOR&"], 0,
                [
                    new("orientation", 0, 2, "FMOD.VECTOR&", false, null,
                        [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 1, 134218812),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663747, "set3DCustomRolloff", 134, "2002111410111C08", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["FMOD.VECTOR&", "System.Int32"], 0,
                [
                    new("points", 0, 0, "FMOD.VECTOR&", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                "FMOD.VECTOR")), 1, 134218813),
                    new("numpoints", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218814),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663748, "get3DCustomRolloff", 134, "2002111410181008", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr&", "System.Int32&"], 0,
                [
                    new("points", 0, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 1, 134218815),
                    new("numpoints", 1, 2, "System.Int32&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Int32")), 2, 134218816),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663749, "set3DOcclusion", 134, "200211140C0C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single", "System.Single"], 0,
                [
                    new("directocclusion", 0, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218817),
                    new("reverbocclusion", 1, 0, "System.Single", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218818),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663750, "get3DOcclusion", 134, "20021114100C100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.Single&", "System.Single&"], 0,
                [
                    new("directocclusion", 0, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218819),
                    new("reverbocclusion", 1, 2, "System.Single&", false, null,
                        [], "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218820),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 6, 14));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663751, "set3DSpread", 134, "200111140C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single"], 0,
                [
                    new("angle", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218821),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663752, "get3DSpread", 134, "20011114100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&"], 0,
                [
                    new("angle", 0, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218822),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663753, "set3DLevel", 134, "200111140C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single"], 0,
                [
                    new("level", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218823),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663754, "get3DLevel", 134, "20011114100C", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.Single&"], 0,
                [
                    new("level", 0, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218824),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663755, "set3DDopplerLevel", 134, "200111140C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.Single"], 0,
                [
                    new("level", 0, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 1, 134218825),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663756, "get3DDopplerLevel", 134, "20011114100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT",
                ["System.Single&"], 0,
                [
                    new("level", 0, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 1, 134218826),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663757, "set3DDistanceFilter", 134, "20031114020C0C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Boolean", "System.Single", "System.Single"], 0,
                [
                    new("custom", 0, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 1, 134218827),
                    new("customLevel", 1, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218828),
                    new("centerFreq", 2, 0, "System.Single", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134218829),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663758, "get3DDistanceFilter", 134, "200311141002100C100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.Boolean&", "System.Single&", "System.Single&"], 0,
                [
                    new("custom", 0, 2, "System.Boolean&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 1, 134218830),
                    new("customLevel", 1, 2, "System.Single&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218831),
                    new("centerFreq", 2, 2, "System.Single&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134218832),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 7, 15));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663759, "setUserData", 134, "2001111418", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr"], 0,
                [
                    new("userdata", 0, 0, "System.IntPtr", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218833),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663760, "getUserData", 134, "200111141018", (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr&"], 0,
                [
                    new("userdata", 0, 2, "System.IntPtr&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.IntPtr")), 1, 134218834),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), true, 5, 13));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663761, "FMOD_ChannelGroup_Stop", 8337, "0001111418", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218835),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663762, "FMOD_ChannelGroup_SetPaused", 8337, "000211141802", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Boolean"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218836),
                    new("paused", 1, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134218837),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663763, "FMOD_ChannelGroup_GetPaused", 8337, "00021114181002",
                (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Boolean&"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218838),
                    new("paused", 1, 2, "System.Boolean&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134218839),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663764, "FMOD_ChannelGroup_GetVolume", 8337, "0002111418100C",
                (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Single&"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218840),
                    new("volume", 1, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218841),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663765, "FMOD_ChannelGroup_SetVolumeRamp", 8337, "000211141802",
                (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Boolean"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218842),
                    new("ramp", 1, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134218843),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663766, "FMOD_ChannelGroup_GetVolumeRamp", 8337, "00021114181002",
                (KeyValuePair<string, string>[])[], "FMOD.RESULT", ["System.IntPtr", "System.Boolean&"],
                0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218844),
                    new("ramp", 1, 2, "System.Boolean&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134218845),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663767, "FMOD_ChannelGroup_GetAudibility", 8337, "0002111418100C",
                (KeyValuePair<string, string>[])[], "FMOD.RESULT", ["System.IntPtr", "System.Single&"],
                0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218846),
                    new("audibility", 1, 2, "System.Single&", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218847),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663768, "FMOD_ChannelGroup_SetPitch", 8337, "00021114180C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Single"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218848),
                    new("pitch", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218849),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663769, "FMOD_ChannelGroup_GetPitch", 8337, "0002111418100C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Single&"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218850),
                    new("pitch", 1, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218851),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663770, "FMOD_ChannelGroup_SetMute", 8337, "000211141802", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Boolean"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218852),
                    new("mute", 1, 0, "System.Boolean", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Boolean"), 2, 134218853),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663771, "FMOD_ChannelGroup_GetMute", 8337, "00021114181002", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Boolean&"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218854),
                    new("mute", 1, 2, "System.Boolean&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Boolean")), 2, 134218855),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663772, "FMOD_ChannelGroup_SetReverbProperties", 8337, "0003111418080C",
                (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.Int32", "System.Single"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218856),
                    new("instance", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218857),
                    new("wet", 2, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 3, 134218858),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663773, "FMOD_ChannelGroup_GetReverbProperties", 8337, "000311141808100C",
                (KeyValuePair<string, string>[])[], "FMOD.RESULT",
                ["System.IntPtr", "System.Int32", "System.Single&"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218859),
                    new("instance", 1, 0, "System.Int32", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Int32"), 2, 134218860),
                    new("wet", 2, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 3, 134218861),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663774, "FMOD_ChannelGroup_SetLowPassGain", 8337, "00021114180C",
                (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "System.Single"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218862),
                    new("gain", 1, 0, "System.Single", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"), 2, 134218863),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663775, "FMOD_ChannelGroup_GetLowPassGain", 8337, "0002111418100C",
                (KeyValuePair<string, string>[])[], "FMOD.RESULT", ["System.IntPtr", "System.Single&"],
                0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218864),
                    new("gain", 1, 2, "System.Single&", false, null, [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.ByReference,
                            elementType: new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Single")), 2, 134218865),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.ChannelControl", 33554499,
                100663776, "FMOD_ChannelGroup_SetMode", 8337, "0002111418115C", (KeyValuePair<string, string>[])[],
                "FMOD.RESULT", ["System.IntPtr", "FMOD.MODE"], 0,
                [
                    new("channelgroup", 0, 0, "System.IntPtr", false, null,
                        [],
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.IntPtr"), 1, 134218866),
                    new("mode", 1, 0, "FMOD.MODE", false, null, [],
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        new(
                            SourceTypeReferenceKind.Named,
                            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            "FMOD.MODE"), 2, 134218867),
                ], "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.RESULT"), false, 0, 0));
        }
    }
}
