using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Game.Reflection.Metadata;

public static partial class SourceGameMemberMetadata
{
    private static void PublishOriginal133(SourceMemberCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StaticMover", 67114650, "OnMove",
            SourceMemberKind.Field, 6, "System.Action`1<Microsoft.Xna.Framework.Vector2>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Action`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StaticMover", 67114651,
            "OnShake", SourceMemberKind.Field, 6, "System.Action`1<Microsoft.Xna.Framework.Vector2>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Action`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StaticMover", 67114652,
            "OnAttach", SourceMemberKind.Field, 6, "System.Action`1<Celeste.Platform>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Action`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Platform")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StaticMover", 67114653,
            "OnDestroy", SourceMemberKind.Field, 6, "System.Action", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Action")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StaticMover", 67114654,
            "OnDisable", SourceMemberKind.Field, 6, "System.Action", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Action")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StaticMover", 67114655,
            "OnEnable", SourceMemberKind.Field, 6, "System.Action", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Action")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.StaticMover", 67114656,
            "Platform", SourceMemberKind.Field, 6, "Celeste.Platform", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Platform")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 33555260, 1048577,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Component",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("Monocle.Tracked", "System.Void Monocle.Tracked::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Component"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 67114657, "GroundReset",
            SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 67114658, "OnActivate",
            SourceMemberKind.Field, 6, "System.Action", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Action")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 67114659,
            "OnDeactivate", SourceMemberKind.Field, 6, "System.Action", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Action")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 67114660, "OnFinish",
            SourceMemberKind.Field, 6, "System.Action", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Action")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 67114661,
            "OnStartFinished", SourceMemberKind.Field, 6, "System.Action", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Action")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 67114662,
            "<Activated>k__BackingField", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 67114663,
            "<Finished>k__BackingField", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 385876451, "Activated",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2177, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Switch", 385876452, "Finished",
            SourceMemberKind.Property, 0, "System.Boolean", 2182, 2177, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform", 33555261,
            1048577, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Solid",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Solid"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform", 67114664,
            "P_Crumble", SourceMemberKind.Field, 22, "Monocle.ParticleType", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.ParticleType")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform", 67114665,
            "images", SourceMemberKind.Field, 1, "System.Collections.Generic.List`1<Monocle.Image>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
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
                        typeIdentity: "Monocle.Image")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform", 67114666,
            "outline", SourceMemberKind.Field, 1, "System.Collections.Generic.List`1<Monocle.Image>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
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
                        typeIdentity: "Monocle.Image")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform", 67114667,
            "falls", SourceMemberKind.Field, 1, "System.Collections.Generic.List`1<Monocle.Coroutine>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
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
                        typeIdentity: "Monocle.Coroutine")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform", 67114668,
            "fallOrder", SourceMemberKind.Field, 1, "System.Collections.Generic.List`1<System.Int32>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
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
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform", 67114669,
            "shaker", SourceMemberKind.Field, 1, "Monocle.ShakerList", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.ShakerList")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform", 67114670,
            "occluder", SourceMemberKind.Field, 1, "Celeste.LightOcclude", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.LightOcclude")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform", 67114671,
            "outlineFader", SourceMemberKind.Field, 1, "Monocle.Coroutine", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Coroutine")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<Sequence>d__11",
            33556200, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object",
            new string[]
            {
                "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
            {
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.IEnumerator`1"),
                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                    {
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Object")
                    }),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.IDisposable"),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.IEnumerator")
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<Sequence>d__11",
            67120325, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<Sequence>d__11",
            67120326, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<Sequence>d__11",
            67120327, "<>4__this", SourceMemberKind.Field, 6, "Celeste.CrumblePlatform", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.CrumblePlatform")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<Sequence>d__11",
            67120328, "<onTop>5__2", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<Sequence>d__11",
            67120329, "<timer>5__3", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<Sequence>d__11",
            67120330, "<i>5__4", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<Sequence>d__11",
            385877624, "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property, 0,
            "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<Sequence>d__11",
            385877625, "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrumblePlatform+<OutlineFade>d__12", 33556201, 1048835,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            new string[]
            {
                "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
            {
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.IEnumerator`1"),
                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                    {
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Object")
                    }),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.IDisposable"),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.IEnumerator")
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrumblePlatform+<OutlineFade>d__12", 67120331, "<>1__state", SourceMemberKind.Field, 1,
            "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrumblePlatform+<OutlineFade>d__12", 67120332, "<>2__current", SourceMemberKind.Field, 1,
            "System.Object", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrumblePlatform+<OutlineFade>d__12", 67120333, "to", SourceMemberKind.Field, 6, "System.Single",
            -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrumblePlatform+<OutlineFade>d__12", 67120334, "<>4__this", SourceMemberKind.Field, 6,
            "Celeste.CrumblePlatform", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.CrumblePlatform")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrumblePlatform+<OutlineFade>d__12", 67120335, "<from>5__2", SourceMemberKind.Field, 1,
            "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrumblePlatform+<OutlineFade>d__12", 67120336, "<t>5__3", SourceMemberKind.Field, 1,
            "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrumblePlatform+<OutlineFade>d__12", 385877626,
            "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property, 0,
            "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.CrumblePlatform+<OutlineFade>d__12", 385877627, "System.Collections.IEnumerator.Current",
            SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            33556202, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object",
            new string[]
            {
                "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
            {
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.IEnumerator`1"),
                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                    {
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Object")
                    }),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.IDisposable"),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.IEnumerator")
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            67120337, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            67120338, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            67120339, "img", SourceMemberKind.Field, 6, "Monocle.Image", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Image")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            67120340, "delay", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            67120341, "<distance>5__2", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            67120342, "<from>5__3", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            67120343, "<time>5__4", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            385877628, "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property, 0,
            "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileOut>d__13",
            385877629, "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            33556203, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object",
            new string[]
            {
                "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
            {
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.IEnumerator`1"),
                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                    {
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Object")
                    }),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.IDisposable"),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.IEnumerator")
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            67120344, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            67120345, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            67120346, "delay", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            67120347, "<>4__this", SourceMemberKind.Field, 6, "Celeste.CrumblePlatform", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.CrumblePlatform")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            67120348, "img", SourceMemberKind.Field, 6, "Monocle.Image", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Image")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            67120349, "index", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            67120350, "<time>5__2", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            385877630, "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property, 0,
            "System.Object", 2529, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CrumblePlatform+<TileIn>d__14",
            385877631, "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object", 2529,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 33555262, 1048577,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Solid", Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("Monocle.Tracked", "System.Void Monocle.Tracked::.ctor(System.Boolean)",
                    new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Solid"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114672,
            "activeBackColor", SourceMemberKind.Field, 49, "Microsoft.Xna.Framework.Color", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Color")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114673,
            "disabledBackColor", SourceMemberKind.Field, 49, "Microsoft.Xna.Framework.Color", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Color")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114674,
            "activeLineColor", SourceMemberKind.Field, 49, "Microsoft.Xna.Framework.Color", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Color")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114675,
            "disabledLineColor", SourceMemberKind.Field, 49, "Microsoft.Xna.Framework.Color", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Color")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114676,
            "playerHasDreamDash", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114677, "node",
            SourceMemberKind.Field, 1, "System.Nullable`1<Microsoft.Xna.Framework.Vector2>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Nullable`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2")
                })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114678, "occlude",
            SourceMemberKind.Field, 1, "Celeste.LightOcclude", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.LightOcclude")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114679,
            "particleTextures", SourceMemberKind.Field, 1, "Monocle.MTexture[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    typeIdentity: "Monocle.MTexture"), arrayRank: 1,
                arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                    { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114680,
            "particles", SourceMemberKind.Field, 1, "Celeste.DreamBlock+DreamParticle[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    typeIdentity: "Celeste.DreamBlock+DreamParticle"), arrayRank: 1,
                arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                    { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114681,
            "whiteFill", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114682,
            "whiteHeight", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114683, "shake",
            SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114684,
            "animTimer", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114685, "shaker",
            SourceMemberKind.Field, 1, "Monocle.Shaker", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Shaker")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114686,
            "fastMoving", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114687, "oneUse",
            SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null,
            null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114688,
            "wobbleFrom", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114689,
            "wobbleTo", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock", 67114690,
            "wobbleEase", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock+DreamParticle",
            33556204, 1048843, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.ValueType", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.ValueType"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock+DreamParticle",
            67120351, "Position", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock+DreamParticle",
            67120352, "Layer", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock+DreamParticle",
            67120353, "Color", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Color", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Color")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock+DreamParticle",
            67120354, "TimeOffset", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.DreamBlock+<>c__DisplayClass22_0", 33556205, 1048835,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(),
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null, new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.DreamBlock+<>c__DisplayClass22_0", 67120355, "start", SourceMemberKind.Field, 6,
            "Microsoft.Xna.Framework.Vector2", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.DreamBlock+<>c__DisplayClass22_0", 67120356, "end", SourceMemberKind.Field, 6,
            "Microsoft.Xna.Framework.Vector2", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null,
            null, "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.DreamBlock+<>c__DisplayClass22_0", 67120357, "<>4__this", SourceMemberKind.Field, 6,
            "Celeste.DreamBlock", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.DreamBlock")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock+<Activate>d__34",
            33556206, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object",
            new string[]
            {
                "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                "System.Collections.IEnumerator"
            },
            new SourceDeclaredAttribute[]
            {
                new SourceDeclaredAttribute("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                    new byte[] { 0x01, 0x00, 0x00, 0x00 })
            }, null,
            new string[]
            {
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
            {
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                    elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.IEnumerator`1"),
                    genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                    {
                        new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.Object")
                    }),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.IDisposable"),
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.IEnumerator")
            }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock+<Activate>d__34",
            67120358, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DreamBlock+<Activate>d__34",
            67120359, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object")));
    }
}
