using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Game.Reflection.Metadata;

public static partial class SourceGameMethodMetadata
{
    private static void PublishInstalled008(SourceAssemblyMethodCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664577, "setCreateInstanceCallback", 134, "20011114128364", new KeyValuePair<string, string>[] { },
            "FMOD.RESULT", new string[] { "FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("callback", 0, 0,
                    "FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK"), 1, 134220697)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664578, "getUserData", 134, "200111141018", new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("userdata", 0, 2, "System.IntPtr&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.IntPtr")), 1, 134220698)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664579, "setUserData", 134, "2001111418", new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("userdata", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220699)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664580, "FMOD_Studio_CommandReplay_IsValid", 8337, "00010218", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "System.IntPtr" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220700)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664581, "FMOD_Studio_CommandReplay_GetSystem", 8337, "00021114181018",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.IntPtr&" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220701),
                new SourceMethodParameterDefinition("system", 1, 2, "System.IntPtr&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.IntPtr")), 2, 134220702)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664582, "FMOD_Studio_CommandReplay_GetLength", 8337, "0002111418100C",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.Single&" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220703),
                new SourceMethodParameterDefinition("totalTime", 1, 2, "System.Single&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Single")), 2, 134220704)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664583, "FMOD_Studio_CommandReplay_GetCommandCount", 8337, "00021114181008",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.Int32&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220705),
                new SourceMethodParameterDefinition("count", 1, 2, "System.Int32&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Int32")), 2, 134220706)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664584, "FMOD_Studio_CommandReplay_GetCommandInfo", 8337, "00031114180810118330",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr", "System.Int32", "FMOD.Studio.COMMAND_INFO_INTERNAL&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220707),
                new SourceMethodParameterDefinition("commandIndex", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134220708),
                new SourceMethodParameterDefinition("info", 2, 2, "FMOD.Studio.COMMAND_INFO_INTERNAL&", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "FMOD.Studio.COMMAND_INFO_INTERNAL")), 3, 134220709)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664585, "FMOD_Studio_CommandReplay_GetCommandString", 8337, "0004111418081D0508",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr", "System.Int32", "System.Byte[]", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220710),
                new SourceMethodParameterDefinition("commandIndex", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134220711),
                new SourceMethodParameterDefinition("description", 2, 2, "System.Byte[]", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Byte"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 3,
                    134220712),
                new SourceMethodParameterDefinition("capacity", 3, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 4, 134220713)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664586, "FMOD_Studio_CommandReplay_GetCommandAtTime", 8337, "00031114180C1008",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr", "System.Single", "System.Int32&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220714),
                new SourceMethodParameterDefinition("time", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220715),
                new SourceMethodParameterDefinition("commandIndex", 2, 2, "System.Int32&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Int32")), 3, 134220716)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664587, "FMOD_Studio_CommandReplay_SetBankPath", 8337, "00021114181D05",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.Byte[]" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220717),
                new SourceMethodParameterDefinition("bankPath", 1, 0, "System.Byte[]", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Byte"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 2,
                    134220718)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664588, "FMOD_Studio_CommandReplay_Start", 8337, "0001111418", new KeyValuePair<string, string>[] { },
            "FMOD.RESULT", new string[] { "System.IntPtr" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220719)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664589, "FMOD_Studio_CommandReplay_Stop", 8337, "0001111418", new KeyValuePair<string, string>[] { },
            "FMOD.RESULT", new string[] { "System.IntPtr" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220720)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664590, "FMOD_Studio_CommandReplay_SeekToTime", 8337, "00021114180C",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220721),
                new SourceMethodParameterDefinition("time", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220722)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664591, "FMOD_Studio_CommandReplay_SeekToCommand", 8337, "000211141808",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220723),
                new SourceMethodParameterDefinition("commandIndex", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134220724)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664592, "FMOD_Studio_CommandReplay_GetPaused", 8337, "00021114181002",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.Boolean&" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220725),
                new SourceMethodParameterDefinition("paused", 1, 2, "System.Boolean&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Boolean")), 2, 134220726)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664593, "FMOD_Studio_CommandReplay_SetPaused", 8337, "000211141802",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.Boolean" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220727),
                new SourceMethodParameterDefinition("paused", 1, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 2, 134220728)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664594, "FMOD_Studio_CommandReplay_GetPlaybackState", 8337, "000211141810118348",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr", "FMOD.Studio.PLAYBACK_STATE&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220729),
                new SourceMethodParameterDefinition("state", 1, 2, "FMOD.Studio.PLAYBACK_STATE&", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "FMOD.Studio.PLAYBACK_STATE")), 2, 134220730)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664595, "FMOD_Studio_CommandReplay_GetCurrentCommand", 8337, "00031114181008100C",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr", "System.Int32&", "System.Single&" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220731),
                new SourceMethodParameterDefinition("commandIndex", 1, 2, "System.Int32&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Int32")), 2, 134220732),
                new SourceMethodParameterDefinition("currentTime", 2, 2, "System.Single&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Single")), 3, 134220733)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664596, "FMOD_Studio_CommandReplay_Release", 8337, "0001111418", new KeyValuePair<string, string>[] { },
            "FMOD.RESULT", new string[] { "System.IntPtr" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220734)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664597, "FMOD_Studio_CommandReplay_SetFrameCallback", 8337, "000211141812835C",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr", "FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220735),
                new SourceMethodParameterDefinition("callback", 1, 0, "FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK", false,
                    null, new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "FMOD.Studio.COMMANDREPLAY_FRAME_CALLBACK"), 2, 134220736)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664598, "FMOD_Studio_CommandReplay_SetLoadBankCallback", 8337, "0002111418128360",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr", "FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220737),
                new SourceMethodParameterDefinition("callback", 1, 0, "FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK",
                    false, null, new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "FMOD.Studio.COMMANDREPLAY_LOAD_BANK_CALLBACK"), 2, 134220738)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664599, "FMOD_Studio_CommandReplay_SetCreateInstanceCallback", 8337, "0002111418128364",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT",
            new string[] { "System.IntPtr", "FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220739),
                new SourceMethodParameterDefinition("callback", 1, 0,
                    "FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "FMOD.Studio.COMMANDREPLAY_CREATE_INSTANCE_CALLBACK"), 2, 134220740)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664600, "FMOD_Studio_CommandReplay_GetUserData", 8337, "00021114181018",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.IntPtr&" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220741),
                new SourceMethodParameterDefinition("userdata", 1, 2, "System.IntPtr&", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.IntPtr")), 2, 134220742)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664601, "FMOD_Studio_CommandReplay_SetUserData", 8337, "000211141818",
            new KeyValuePair<string, string>[] { }, "FMOD.RESULT", new string[] { "System.IntPtr", "System.IntPtr" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("replay", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220743),
                new SourceMethodParameterDefinition("userdata", 1, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 2, 134220744)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "FMOD.RESULT"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664602, ".ctor", 6278, "20010118", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.IntPtr" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("raw", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220745)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.CommandReplay", 33554661,
            100664603, "isValidInternal", 196, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 4, 12));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.MarshallingHelper", 33554662,
            100664604, "stringLengthUtf8", 150, "00010818", new KeyValuePair<string, string>[] { }, "System.Int32",
            new string[] { "System.IntPtr" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("nativeUtf8", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220746)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 13, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.MarshallingHelper", 33554662,
            100664605, "stringFromNativeUtf8", 150, "00010E18", new KeyValuePair<string, string>[] { }, "System.String",
            new string[] { "System.IntPtr" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("nativeUtf8", 0, 0, "System.IntPtr", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IntPtr"), 1, 134220747)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String"), true, 23, 48));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.Studio.MarshallingHelper", 33554662,
            100664606, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664607,
            "get_HasInput", 134, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 18, 45));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664608,
            "Add", 134, "2001021D115D", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Input.Keys[]" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("keys", 0, 0, "Microsoft.Xna.Framework.Input.Keys[]", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Input.Keys"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 1,
                    134220748)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 52, 109));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664609,
            "Add", 134, "2001021D1161", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Input.Buttons[]" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("buttons", 0, 0, "Microsoft.Xna.Framework.Input.Buttons[]", false,
                    null, new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Input.Buttons"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 1,
                    134220749)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 52, 109));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664610,
            "Needs", 134, "2001021161", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Input.Buttons" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("button", 0, 0, "Microsoft.Xna.Framework.Input.Buttons", false,
                    null, new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Input.Buttons"), 1, 134220750)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 50, 111));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664611,
            "Needs", 134, "200102115D", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Input.Keys" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("key", 0, 0, "Microsoft.Xna.Framework.Input.Keys", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Input.Keys"), 1, 134220751)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 50, 111));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664612,
            "IsExclusive", 134, "2001021161", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Input.Buttons" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("button", 0, 0, "Microsoft.Xna.Framework.Input.Buttons", false,
                    null, new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Input.Buttons"), 1, 134220752)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 26, 67));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664613,
            "IsExclusive", 134, "200102115D", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Input.Keys" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("key", 0, 0, "Microsoft.Xna.Framework.Input.Keys", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Input.Keys"), 1, 134220753)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 26, 67));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664614,
            "ClearKeyboard", 134, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 53, 127));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664615,
            "ClearGamepad", 134, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 53, 127));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664616,
            "Axis", 134, "20020C080C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { "System.Int32", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("gamepadIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220754),
                new SourceMethodParameterDefinition("threshold", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220755)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 31, 71));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664617,
            "Check", 134, "200202080C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Int32", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("gamepadIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220756),
                new SourceMethodParameterDefinition("threshold", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220757)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 30, 62));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664618,
            "Pressed", 134, "200202080C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Int32", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("gamepadIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220758),
                new SourceMethodParameterDefinition("threshold", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220759)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 30, 62));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664619,
            "Released", 134, "200202080C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Int32", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("gamepadIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220760),
                new SourceMethodParameterDefinition("threshold", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220761)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 30, 62));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664620,
            "SetExclusive", 150, "0001011D12839C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Binding[]" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("list", 0, 0, "Monocle.Binding[]", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Monocle.Binding"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 1,
                    134220762)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 67, 107));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664621,
            ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 18));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664622,
            "orig_ctor", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664623,
            "Add", 134, "2001021D1184A0", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.MInput+MouseData+MouseButtons[]" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("buttons", 0, 0, "Monocle.MInput+MouseData+MouseButtons[]", false,
                    null, new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Monocle.MInput+MouseData+MouseButtons"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 1,
                    134220763)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 45, 98));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664624,
            "Needs", 134, "2001021184A0", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.MInput+MouseData+MouseButtons" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("button", 0, 0, "Monocle.MInput+MouseData+MouseButtons", false,
                    null, new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.MInput+MouseData+MouseButtons"), 1, 134220764)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 54, 126));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664625,
            "IsExclusive", 134, "2001021184A0", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.MInput+MouseData+MouseButtons" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("button", 0, 0, "Monocle.MInput+MouseData+MouseButtons", false,
                    null, new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.MInput+MouseData+MouseButtons"), 1, 134220765)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 27, 72));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664626,
            "ClearMouse", 134, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 9, 26));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664627,
            "orig_Axis", 134, "20020C080C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { "System.Int32", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("gamepadIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220766),
                new SourceMethodParameterDefinition("threshold", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220767)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 56, 158));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664628,
            "orig_Check", 134, "200202080C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Int32", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("gamepadIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220768),
                new SourceMethodParameterDefinition("threshold", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220769)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 47, 101));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664629,
            "orig_Pressed", 134, "200202080C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Int32", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("gamepadIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220770),
                new SourceMethodParameterDefinition("threshold", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220771)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 47, 101));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664630,
            "orig_Released", 134, "200202080C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Int32", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("gamepadIndex", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134220772),
                new SourceMethodParameterDefinition("threshold", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220773)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 47, 101));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664631,
            "Remove", 134, "2001021D115D", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Input.Keys[]" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("keys", 0, 0, "Microsoft.Xna.Framework.Input.Keys[]", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Input.Keys"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 1,
                    134220774)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 69, 188));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding", 33554663, 100664632,
            "Remove", 134, "2001021D1161", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Input.Buttons[]" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("buttons", 0, 0, "Microsoft.Xna.Framework.Input.Buttons[]", false,
                    null, new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Input.Buttons"), arrayRank: 1,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                            { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) }), 1,
                    134220775)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 69, 188));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass16_0",
            33554664, 100664633, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass16_0",
            33554664, 100664634, "<Remove>b__0", 131, "200102115D", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Microsoft.Xna.Framework.Input.Keys" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("key", 0, 0, "Microsoft.Xna.Framework.Input.Keys", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Input.Keys"), 1, 134220776)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 7, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass16_1",
            33554665, 100664635, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass16_1",
            33554665, 100664636, "<Remove>b__1", 131, "20010212839C", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Monocle.Binding" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("b", 0, 0, "Monocle.Binding", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Binding"), 1, 134220777)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass17_0",
            33554666, 100664637, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass17_0",
            33554666, 100664638, "<Remove>b__0", 131, "2001021161", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Microsoft.Xna.Framework.Input.Buttons" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("button", 0, 0, "Microsoft.Xna.Framework.Input.Buttons", false,
                    null, new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Input.Buttons"), 1, 134220778)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 7, 16));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass17_1",
            33554667, 100664639, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass17_1",
            33554667, 100664640, "<Remove>b__1", 131, "20010212839C", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Monocle.Binding" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("b", 0, 0, "Monocle.Binding", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Binding"), 1, 134220779)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass4_0",
            33554668, 100664641, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Binding+<>c__DisplayClass4_0",
            33554668, 100664642, "<Add>b__0", 131, "20010212839C", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Monocle.Binding" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("item", 0, 0, "Monocle.Binding", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Binding"), 1, 134220780)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 8, 21));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ParticleEmitter", 33554669,
            100664643, ".ctor", 6278, "2006011285641285681180A11180A1080C", new KeyValuePair<string, string>[] { },
            "System.Void",
            new string[]
            {
                "Monocle.ParticleSystem", "Monocle.ParticleType", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2", "System.Int32", "System.Single"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("system", 0, 0, "Monocle.ParticleSystem", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.ParticleSystem"), 1, 134220781),
                new SourceMethodParameterDefinition("type", 1, 0, "Monocle.ParticleType", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.ParticleType"), 2, 134220782),
                new SourceMethodParameterDefinition("position", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220783),
                new SourceMethodParameterDefinition("range", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 4, 134220784),
                new SourceMethodParameterDefinition("amount", 4, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 5, 134220785),
                new SourceMethodParameterDefinition("interval", 5, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 6, 134220786)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 23, 54));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ParticleEmitter", 33554669,
            100664644, ".ctor", 6278, "2007011285641285681180A11180A10C080C", new KeyValuePair<string, string>[] { },
            "System.Void",
            new string[]
            {
                "Monocle.ParticleSystem", "Monocle.ParticleType", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Int32", "System.Single"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("system", 0, 0, "Monocle.ParticleSystem", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.ParticleSystem"), 1, 134220787),
                new SourceMethodParameterDefinition("type", 1, 0, "Monocle.ParticleType", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.ParticleType"), 2, 134220788),
                new SourceMethodParameterDefinition("position", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220789),
                new SourceMethodParameterDefinition("range", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 4, 134220790),
                new SourceMethodParameterDefinition("direction", 4, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 5, 134220791),
                new SourceMethodParameterDefinition("amount", 5, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 6, 134220792),
                new SourceMethodParameterDefinition("interval", 6, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 7, 134220793)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 13, 29));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ParticleEmitter", 33554669,
            100664645, ".ctor", 6278, "20080112856412856812846C1180A11180A10C080C",
            new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Monocle.ParticleSystem", "Monocle.ParticleType", "Monocle.Entity", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Int32", "System.Single"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("system", 0, 0, "Monocle.ParticleSystem", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.ParticleSystem"), 1, 134220794),
                new SourceMethodParameterDefinition("type", 1, 0, "Monocle.ParticleType", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.ParticleType"), 2, 134220795),
                new SourceMethodParameterDefinition("track", 2, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 3, 134220796),
                new SourceMethodParameterDefinition("position", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 4, 134220797),
                new SourceMethodParameterDefinition("range", 4, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 5, 134220798),
                new SourceMethodParameterDefinition("direction", 5, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 6, 134220799),
                new SourceMethodParameterDefinition("amount", 6, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 7, 134220800),
                new SourceMethodParameterDefinition("interval", 7, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 8, 134220801)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 16, 37));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ParticleEmitter", 33554669,
            100664646, "SimulateCycle", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 18));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ParticleEmitter", 33554669,
            100664647, "Simulate", 134, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("duration", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220802)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 85, 223));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ParticleEmitter", 33554669,
            100664648, "Emit", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 39, 128));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.ParticleEmitter", 33554669,
            100664649, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 17, 50));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664650,
            ".ctor", 6278, "2003010C0C0C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single", "System.Single", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("radius", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220803),
                new SourceMethodParameterDefinition("x", 1, 4112, "System.Single", true, "System.Single",
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220804),
                new SourceMethodParameterDefinition("y", 2, 4112, "System.Single", true, "System.Single",
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134220805)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 14, 38));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664651,
            "get_Width", 2246, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664652,
            "set_Width", 2246, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220806)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664653,
            "get_Height", 2246, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664654,
            "set_Height", 2246, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220807)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664655,
            "get_Left", 2246, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664656,
            "set_Left", 2246, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220808)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664657,
            "get_Top", 2246, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664658,
            "set_Top", 2246, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220809)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664659,
            "get_Right", 2246, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664660,
            "set_Right", 2246, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220810)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664661,
            "get_Bottom", 2246, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664662,
            "set_Bottom", 2246, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220811)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664663,
            "Clone", 198, "20001283C4", new KeyValuePair<string, string>[] { }, "Monocle.Collider", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Collider"), true, 10, 34));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664664,
            "Render", 198, "2002011285A41180AD", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Camera", "Microsoft.Xna.Framework.Color" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("camera", 0, 0, "Monocle.Camera", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Camera"), 1, 134220812),
                new SourceMethodParameterDefinition("color", 1, 0, "Microsoft.Xna.Framework.Color", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Color"), 2, 134220813)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664665,
            "Collide", 198, "2001021180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("point", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220814)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664666,
            "Collide", 198, "2001021180B1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rect", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220815)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664667,
            "Collide", 198, "2002021180A11180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("from", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220816),
                new SourceMethodParameterDefinition("to", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220817)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664668,
            "Collide", 198, "2001021283B8", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Circle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("circle", 0, 0, "Monocle.Circle", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Circle"), 1, 134220818)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 18, 47));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664669,
            "Collide", 198, "2001021283D0", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Hitbox" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("hitbox", 0, 0, "Monocle.Hitbox", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Hitbox"), 1, 134220819)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664670,
            "Collide", 198, "2001021283CC", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Grid" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("grid", 0, 0, "Monocle.Grid", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Grid"), 1, 134220820)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Circle", 33554670, 100664671,
            "Collide", 198, "2001021283C8", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.ColliderList" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("list", 0, 0, "Monocle.ColliderList", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.ColliderList"), 1, 134220821)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664672,
            "Check", 150, "00020212846C12846C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220822),
                new SourceMethodParameterDefinition("b", 1, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 2, 134220823)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 21, 45));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664673,
            "Check", 150, "00030212846C12846C1180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "Monocle.Entity", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220824),
                new SourceMethodParameterDefinition("b", 1, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 2, 134220825),
                new SourceMethodParameterDefinition("at", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220826)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 13, 29));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664674,
            "Check", 150, "00020212846C151280B50112846C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220827),
                new SourceMethodParameterDefinition("b", 1, 0,
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220828)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 6, 11));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664675,
            "Check", 150, "00030212846C151280B50112846C1180A1", new KeyValuePair<string, string>[] { },
            "System.Boolean",
            new string[]
            {
                "Monocle.Entity", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220829),
                new SourceMethodParameterDefinition("b", 1, 0,
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220830),
                new SourceMethodParameterDefinition("at", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220831)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 13, 29));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664676,
            "First", 150, "000212846C12846C151280B50112846C", new KeyValuePair<string, string>[] { }, "Monocle.Entity",
            new string[] { "Monocle.Entity", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220832),
                new SourceMethodParameterDefinition("b", 1, 0,
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220833)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Entity"), true, 35, 71));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664677,
            "First", 150, "000312846C12846C151280B50112846C1180A1", new KeyValuePair<string, string>[] { },
            "Monocle.Entity",
            new string[]
            {
                "Monocle.Entity", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220834),
                new SourceMethodParameterDefinition("b", 1, 0,
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220835),
                new SourceMethodParameterDefinition("at", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220836)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Entity"), true, 13, 29));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664678,
            "All", 150, "00031512590112846C12846C151280B50112846C1512590112846C",
            new KeyValuePair<string, string>[] { }, "System.Collections.Generic.List`1<Monocle.Entity>",
            new string[]
            {
                "Monocle.Entity", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.Generic.List`1<Monocle.Entity>"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220837),
                new SourceMethodParameterDefinition("b", 1, 0,
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220838),
                new SourceMethodParameterDefinition("into", 2, 0, "System.Collections.Generic.List`1<Monocle.Entity>",
                    false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.List`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 3, 134220839)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity")
                }), true, 34, 73));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664679,
            "All", 150, "00041512590112846C12846C151280B50112846C1512590112846C1180A1",
            new KeyValuePair<string, string>[] { }, "System.Collections.Generic.List`1<Monocle.Entity>",
            new string[]
            {
                "Monocle.Entity", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "System.Collections.Generic.List`1<Monocle.Entity>", "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220840),
                new SourceMethodParameterDefinition("b", 1, 0,
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220841),
                new SourceMethodParameterDefinition("into", 2, 0, "System.Collections.Generic.List`1<Monocle.Entity>",
                    false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.List`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 3, 134220842),
                new SourceMethodParameterDefinition("at", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 4, 134220843)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity")
                }), true, 14, 30));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664680,
            "All", 150, "00021512590112846C12846C151280B50112846C", new KeyValuePair<string, string>[] { },
            "System.Collections.Generic.List`1<Monocle.Entity>",
            new string[] { "Monocle.Entity", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220844),
                new SourceMethodParameterDefinition("b", 1, 0,
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220845)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity")
                }), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664681,
            "All", 150, "00031512590112846C12846C151280B50112846C1180A1", new KeyValuePair<string, string>[] { },
            "System.Collections.Generic.List`1<Monocle.Entity>",
            new string[]
            {
                "Monocle.Entity", "System.Collections.Generic.IEnumerable`1<Monocle.Entity>",
                "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220846),
                new SourceMethodParameterDefinition("b", 1, 0,
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220847),
                new SourceMethodParameterDefinition("at", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220848)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity")
                }), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664682,
            "CheckPoint", 150, "00020212846C1180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220849),
                new SourceMethodParameterDefinition("point", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220850)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 10, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664683,
            "CheckPoint", 150, "00030212846C1180A11180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220851),
                new SourceMethodParameterDefinition("point", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220852),
                new SourceMethodParameterDefinition("at", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220853)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 13, 29));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664684,
            "CheckLine", 150, "00030212846C1180A11180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220854),
                new SourceMethodParameterDefinition("from", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220855),
                new SourceMethodParameterDefinition("to", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220856)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 11, 24));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664685,
            "CheckLine", 150, "00040212846C1180A11180A11180A1", new KeyValuePair<string, string>[] { },
            "System.Boolean",
            new string[]
            {
                "Monocle.Entity", "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220857),
                new SourceMethodParameterDefinition("from", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220858),
                new SourceMethodParameterDefinition("to", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220859),
                new SourceMethodParameterDefinition("at", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 4, 134220860)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 14, 30));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664686,
            "CheckRect", 150, "00020212846C1180B1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220861),
                new SourceMethodParameterDefinition("rect", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134220862)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 10, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664687,
            "CheckRect", 150, "00030212846C1180B11180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Vector2" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220863),
                new SourceMethodParameterDefinition("rect", 1, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 2, 134220864),
                new SourceMethodParameterDefinition("at", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220865)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 13, 29));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664688,
            "LineCheck", 150, "0004021180A11180A11180A11180A1", new KeyValuePair<string, string>[] { },
            "System.Boolean",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220866),
                new SourceMethodParameterDefinition("a2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220867),
                new SourceMethodParameterDefinition("b1", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220868),
                new SourceMethodParameterDefinition("b2", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 4, 134220869)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 75, 166));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664689,
            "LineCheck", 150, "0005021180A11180A11180A11180A1101180A1", new KeyValuePair<string, string>[] { },
            "System.Boolean",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2&"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a1", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220870),
                new SourceMethodParameterDefinition("a2", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220871),
                new SourceMethodParameterDefinition("b1", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220872),
                new SourceMethodParameterDefinition("b2", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 4, 134220873),
                new SourceMethodParameterDefinition("intersection", 4, 2, "Microsoft.Xna.Framework.Vector2&", false,
                    null, new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            typeIdentity: "Microsoft.Xna.Framework.Vector2")), 5, 134220874)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 85, 199));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664690,
            "CircleToLine", 150, "0004021180A10C1180A11180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "System.Single", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("cPosiition", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220875),
                new SourceMethodParameterDefinition("cRadius", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220876),
                new SourceMethodParameterDefinition("lineFrom", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220877),
                new SourceMethodParameterDefinition("lineTo", 3, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 4, 134220878)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 11, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664691,
            "CircleToPoint", 150, "0003021180A10C1180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Single", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("cPosition", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220879),
                new SourceMethodParameterDefinition("cRadius", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220880),
                new SourceMethodParameterDefinition("point", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220881)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 8, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664692,
            "CircleToRect", 150, "0006021180A10C0C0C0C0C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single", "System.Single", "System.Single",
                "System.Single"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("cPosition", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220882),
                new SourceMethodParameterDefinition("cRadius", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220883),
                new SourceMethodParameterDefinition("rX", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134220884),
                new SourceMethodParameterDefinition("rY", 3, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134220885),
                new SourceMethodParameterDefinition("rW", 4, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 5, 134220886),
                new SourceMethodParameterDefinition("rH", 5, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 6, 134220887)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 8, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664693,
            "CircleToRect", 150, "0003021180A10C1180B1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Single", "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("cPosition", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220888),
                new SourceMethodParameterDefinition("cRadius", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220889),
                new SourceMethodParameterDefinition("rect", 2, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 3, 134220890)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 5, 9));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664694,
            "RectToCircle", 150, "0006020C0C0C0C1180A10C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[]
            {
                "System.Single", "System.Single", "System.Single", "System.Single", "Microsoft.Xna.Framework.Vector2",
                "System.Single"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rX", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220891),
                new SourceMethodParameterDefinition("rY", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220892),
                new SourceMethodParameterDefinition("rW", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134220893),
                new SourceMethodParameterDefinition("rH", 3, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134220894),
                new SourceMethodParameterDefinition("cPosition", 4, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 5, 134220895),
                new SourceMethodParameterDefinition("cRadius", 5, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 6, 134220896)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 114, 197));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664695,
            "RectToCircle", 150, "0003021180B11180A10C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Vector2", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rect", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220897),
                new SourceMethodParameterDefinition("cPosition", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220898),
                new SourceMethodParameterDefinition("cRadius", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134220899)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 16, 36));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664696,
            "RectToLine", 150, "0006020C0C0C0C1180A11180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[]
            {
                "System.Single", "System.Single", "System.Single", "System.Single", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rX", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220900),
                new SourceMethodParameterDefinition("rY", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220901),
                new SourceMethodParameterDefinition("rW", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134220902),
                new SourceMethodParameterDefinition("rH", 3, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134220903),
                new SourceMethodParameterDefinition("lineFrom", 4, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 5, 134220904),
                new SourceMethodParameterDefinition("lineTo", 5, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 6, 134220905)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 120, 201));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664697,
            "RectToLine", 150, "0003021180B11180A11180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[]
            {
                "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Vector2",
                "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rect", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220906),
                new SourceMethodParameterDefinition("lineFrom", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220907),
                new SourceMethodParameterDefinition("lineTo", 2, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 3, 134220908)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 16, 36));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664698,
            "RectToPoint", 150, "0005020C0C0C0C1180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[]
            {
                "System.Single", "System.Single", "System.Single", "System.Single", "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rX", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220909),
                new SourceMethodParameterDefinition("rY", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220910),
                new SourceMethodParameterDefinition("rW", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134220911),
                new SourceMethodParameterDefinition("rH", 3, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134220912),
                new SourceMethodParameterDefinition("point", 4, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 5, 134220913)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 23, 47));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664699,
            "RectToPoint", 150, "0002021180B11180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rect", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220914),
                new SourceMethodParameterDefinition("point", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220915)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 15, 35));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664700,
            "GetSector", 150, "00021183BC1180B11180A1", new KeyValuePair<string, string>[] { }, "Monocle.PointSectors",
            new string[] { "Microsoft.Xna.Framework.Rectangle", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rect", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220916),
                new SourceMethodParameterDefinition("point", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220917)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.PointSectors"), true, 46, 88));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664701,
            "GetSector", 150, "00051183BC0C0C0C0C1180A1", new KeyValuePair<string, string>[] { },
            "Monocle.PointSectors",
            new string[]
            {
                "System.Single", "System.Single", "System.Single", "System.Single", "Microsoft.Xna.Framework.Vector2"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rX", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220918),
                new SourceMethodParameterDefinition("rY", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134220919),
                new SourceMethodParameterDefinition("rW", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134220920),
                new SourceMethodParameterDefinition("rH", 3, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134220921),
                new SourceMethodParameterDefinition("point", 4, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 5, 134220922)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.PointSectors"), true, 42, 68));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664702,
            "Check", 150, "00020212846C1512690112846C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "System.Collections.Generic.List`1<Monocle.Entity>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220923),
                new SourceMethodParameterDefinition("b", 1, 0, "System.Collections.Generic.List`1<Monocle.Entity>",
                    false, null, new byte[] { },
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Collections.Generic.List`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220924)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 8, 21));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664703,
            "Check", 150, "00020212846C151180B90112846C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity", "System.ReadOnlySpan`1<Monocle.Entity>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220925),
                new SourceMethodParameterDefinition("b", 1, 0, "System.ReadOnlySpan`1<Monocle.Entity>", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.ReadOnlySpan`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220926)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 6, 11));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664704,
            "First", 150, "000212846C12846C1512690112846C", new KeyValuePair<string, string>[] { }, "Monocle.Entity",
            new string[] { "Monocle.Entity", "System.Collections.Generic.List`1<Monocle.Entity>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220927),
                new SourceMethodParameterDefinition("b", 1, 0, "System.Collections.Generic.List`1<Monocle.Entity>",
                    false, null, new byte[] { },
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Collections.Generic.List`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220928)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Entity"), true, 6, 18));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664705,
            "First", 150, "000212846C12846C151180B90112846C", new KeyValuePair<string, string>[] { }, "Monocle.Entity",
            new string[] { "Monocle.Entity", "System.ReadOnlySpan`1<Monocle.Entity>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220929),
                new SourceMethodParameterDefinition("b", 1, 0, "System.ReadOnlySpan`1<Monocle.Entity>", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.ReadOnlySpan`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220930)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Entity"), true, 26, 43));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664706,
            "All", 150, "00031512690112846C12846C1512690112846C1512690112846C", new KeyValuePair<string, string>[] { },
            "System.Collections.Generic.List`1<Monocle.Entity>",
            new string[]
            {
                "Monocle.Entity", "System.Collections.Generic.List`1<Monocle.Entity>",
                "System.Collections.Generic.List`1<Monocle.Entity>"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220931),
                new SourceMethodParameterDefinition("b", 1, 0, "System.Collections.Generic.List`1<Monocle.Entity>",
                    false, null, new byte[] { },
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Collections.Generic.List`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220932),
                new SourceMethodParameterDefinition("into", 2, 0, "System.Collections.Generic.List`1<Monocle.Entity>",
                    false, null, new byte[] { },
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Collections.Generic.List`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 3, 134220933)
            }, "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity")
                }), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664707,
            "All", 150, "00031512690112846C12846C151180B90112846C1512690112846C",
            new KeyValuePair<string, string>[] { }, "System.Collections.Generic.List`1<Monocle.Entity>",
            new string[]
            {
                "Monocle.Entity", "System.ReadOnlySpan`1<Monocle.Entity>",
                "System.Collections.Generic.List`1<Monocle.Entity>"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("a", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220934),
                new SourceMethodParameterDefinition("b", 1, 0, "System.ReadOnlySpan`1<Monocle.Entity>", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.ReadOnlySpan`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 2, 134220935),
                new SourceMethodParameterDefinition("into", 2, 0, "System.Collections.Generic.List`1<Monocle.Entity>",
                    false, null, new byte[] { },
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Collections.Generic.List`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 3, 134220936)
            }, "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity")
                }), true, 27, 48));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collide", 33554672, 100664708,
            "TryGetSpan", 145, "0002021512808D0112846C10151180B90112846C", new KeyValuePair<string, string>[] { },
            "System.Boolean",
            new string[]
            {
                "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", "System.ReadOnlySpan`1<Monocle.Entity>&"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("source", 0, 0,
                    "System.Collections.Generic.IEnumerable`1<Monocle.Entity>", false, null, new byte[] { },
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Monocle.Entity")
                        }), 1, 134220937),
                new SourceMethodParameterDefinition("span", 1, 2, "System.ReadOnlySpan`1<Monocle.Entity>&", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                            elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                typeIdentity: "System.ReadOnlySpan`1"),
                            genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                            {
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                    assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                    typeIdentity: "Monocle.Entity")
                            })), 2, 134220938)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 33, 102));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664709,
            "get_Entity", 2182, "200012846C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "Monocle.Entity", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Entity"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664710,
            "set_Entity", 2177, "20010112846C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220939)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664711,
            "Added", 963, "20010112846C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220940)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664712,
            "Removed", 963, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664713,
            "Collide", 134, "20010212846C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entity", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134220941)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664714,
            "Collide", 134, "2001021283C4", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Collider" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("collider", 0, 0, "Monocle.Collider", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Collider"), 1, 134220942)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 35, 95));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664715,
            "Collide", 1478, "2001021180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("point", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220943)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664716,
            "Collide", 1478, "2001021180B1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Rectangle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("rect", 0, 0, "Microsoft.Xna.Framework.Rectangle", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Rectangle"), 1, 134220944)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664717,
            "Collide", 1478, "2002021180A11180A1", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("from", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134220945),
                new SourceMethodParameterDefinition("to", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134220946)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664718,
            "Collide", 1478, "2001021283D0", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Hitbox" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("hitbox", 0, 0, "Monocle.Hitbox", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Hitbox"), 1, 134220947)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664719,
            "Collide", 1478, "2001021283CC", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Grid" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("grid", 0, 0, "Monocle.Grid", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Grid"), 1, 134220948)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664720,
            "Collide", 1478, "2001021283B8", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.Circle" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("circle", 0, 0, "Monocle.Circle", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Circle"), 1, 134220949)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664721,
            "Collide", 1478, "2001021283C8", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "Monocle.ColliderList" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("list", 0, 0, "Monocle.ColliderList", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.ColliderList"), 1, 134220950)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664722,
            "Clone", 1478, "20001283C4", new KeyValuePair<string, string>[] { }, "Monocle.Collider", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Collider"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664723,
            "Render", 1478, "2002011285A41180AD", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Camera", "Microsoft.Xna.Framework.Color" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("camera", 0, 0, "Monocle.Camera", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Camera"), 1, 134220951),
                new SourceMethodParameterDefinition("color", 1, 0, "Microsoft.Xna.Framework.Color", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Color"), 2, 134220952)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664724,
            "get_Width", 3526, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664725,
            "set_Width", 3526, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220953)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664726,
            "get_Height", 3526, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664727,
            "set_Height", 3526, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220954)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664728,
            "get_Top", 3526, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664729,
            "set_Top", 3526, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220955)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664730,
            "get_Bottom", 3526, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664731,
            "set_Bottom", 3526, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220956)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664732,
            "get_Left", 3526, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664733,
            "set_Left", 3526, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220957)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664734,
            "get_Right", 3526, "20000C", new KeyValuePair<string, string>[] { }, "System.Single", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664735,
            "set_Right", 3526, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134220958)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), false, 0, 0));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Collider", 33554673, 100664736,
            "CenterOrigin", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 17, 49));
    }
}
